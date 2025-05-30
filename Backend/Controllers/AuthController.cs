using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos;
using Backend.Dtos.Authentication;
using Backend.Models;
using Backend.Services;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager,
        ITokenGenerator tokenGenerator)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
        }

        //////////////////////////////////////////////////////////////

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var emailExists = await _context.Users.
                FirstOrDefaultAsync(x => x.Email == registerDto.Email);

                if (emailExists != null)
                {
                    return BadRequest("Diese Email wurde bereits registriert.");
                }

                if (registerDto.Password != registerDto.ConfirmPassword)
                {
                    return BadRequest("Die Passwörter stimmen nicht überein.");
                }

                var user = new User
                {
                    Email = registerDto.Email,
                    UserName = registerDto.Email,
                    RefreshToken = null,
                    RefreshTokenExpiryTime = null
                };

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");

                    if (roleResult.Succeeded)
                    {
                        return Ok(new
                        {
                            Message = "Du hast dich erfolgreich registriert. Bitte log dich ein.",

                            User = new RegisterResponseDto
                            {
                                Email = user.Email,
                            }
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync
            (x => x.Email == loginDto.Email.ToLower());

            if (user == null)
            {
                return Unauthorized("Login-Eingaben waren inkorrekt, bitte erneut versuchen.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Login-Eingaben waren inkorrekt, bitte erneut versuchen.");

            var accessToken = _tokenGenerator.CreateAccessToken(user);

            var refreshToken = _tokenGenerator.CreateRefreshToken();
            var refreshTokenExpiryTime = DateTime.Now.AddDays(60);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = refreshTokenExpiryTime;

            var rememberMe = loginDto.RememberMe;

            user.RememberMe = rememberMe;

            await _userManager.UpdateAsync(user);

            Response.Cookies.Append("accessToken", accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.Now.AddMinutes(60)
            });

            // Mit "Remember Me", Refresh Token hat Gültigkeit von 60 Tagen. Nach Ablauf muss User wieder anmelden.
            if (rememberMe == true)
            {
                Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTime.Now.AddDays(60)
                });
            }

            //Ohne "Remember Me", der Token gilt also nur bis der Browser schliesst.
            else
            {
                Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                });
            }

            return Ok(new
            {
                Message = "Du wurdest erfolgreich eingeloggt.",

                User = new LoginResponseDto
                {
                    Email = user.Email,
                    AccessToken = accessToken,
                    RememberMe = rememberMe
                }
            });
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var accessTokenInCookies = Request.Cookies["accessToken"];

            if (accessTokenInCookies == null)
            {
                var refreshTokenInCookies = Request.Cookies["refreshToken"];

                if (string.IsNullOrEmpty(refreshTokenInCookies))
                    return Unauthorized("Kein Refresh Token gefunden.");

                var user = await _userManager.Users.
                FirstOrDefaultAsync(x => x.RefreshToken == refreshTokenInCookies);

                if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
                    return Unauthorized("Ungültiger oder abgelaufener Refresh Token.");

                var newAccessToken = _tokenGenerator.CreateAccessToken(user);

                var newRefreshToken = _tokenGenerator.CreateRefreshToken();
                var newRefreshTokenExpiryTime = DateTime.Now.AddDays(60);

                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = newRefreshTokenExpiryTime;

                await _userManager.UpdateAsync(user);

                Response.Cookies.Append("accessToken", newAccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTime.Now.AddMinutes(60)
                });

                //Wir schauen in der Datenbank, ob der User sich zuvor mit "Remember Me" anmeldete oder nicht.
                //Dadurch wissen wir, ob in den Cookies ein RefreshToken mit 60 Tage- oder nur Session-Laufzeit
                //gespeichert werden soll.
                if (user.RememberMe == true)
                {
                    Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Lax,
                        Expires = newRefreshTokenExpiryTime
                    });
                }

                // War "RememberMe" in der Datenbank "false", wird der neue RefreshToken ebenfalls nur in
                //einer Session-Cookie gespeichert.
                else
                {
                    Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Lax,
                    });
                }

                return Ok(new
                {
                    Message = "Tokens erfolgreich aktualisiert.",
                    AccessToken = newAccessToken //Müsste das nicht "user.AccessToken" heissen?
                });

            }

            else
            {
                var refreshTokenInCookies = Request.Cookies["refreshToken"];

                if (string.IsNullOrEmpty(refreshTokenInCookies))
                    return Unauthorized("Kein Refresh Token gefunden.");

                var user = await _userManager.Users.
                FirstOrDefaultAsync(x => x.RefreshToken == refreshTokenInCookies);

                if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
                    return Unauthorized("Ungültiger oder abgelaufener Refresh Token.");

                return Ok("Gültiger Access Token bereits vorhanden.");
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");
            Response.Cookies.Delete("email");

            return Ok("Du hast dich erfolgreich ausgeloggt.");
        }
    }
}