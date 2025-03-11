using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos;
using Backend.Dtos.Authentication;
using Backend.Models;
using Backend.Services;
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
        private readonly TokenGenerator _tokenGenerator;

        public AuthController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager,
        TokenGenerator tokenGenerator)
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

                var user = new User
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
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
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync
            (x => x.Email == loginDto.Email.ToLower());

            var rememberMe = loginDto.RememberMe; // Weist deinen "Remember me"-State einer Variable zu.

            if (user == null) return Unauthorized("Login-Eingaben waren inkorrekt, bitte erneut versuchen.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Login-Eingaben waren inkorrekt, bitte erneut versuchen.");

            var email = user.Email;
            var accessToken = _tokenGenerator.CreateAccessToken(user);
            var refreshToken = _tokenGenerator.CreateRefreshToken();
            var refreshTokenExpiryTime = DateTime.Now.AddDays(30);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = refreshTokenExpiryTime;
            await _userManager.UpdateAsync(user);

            // Ohne "Remember Me"
            if (rememberMe == false)
            {

                // Wir speichern einen Access Token, der eine Gültigkeit nur für die Session hat.
                Response.Cookies.Append("accessToken", accessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    //Hier gibt es kein expires, die Tokens gilten also nur bis Browser schliesst
                });
                Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    //Hier gibt es kein expires, die Tokens gilten also nur bis Browser schliesst
                });

                Response.Cookies.Append("email", email, new CookieOptions
                {
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                });
            }

            // Mit "Remember Me"
            else
            {
                Response.Cookies.Append("accessToken", accessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTime.Now.AddMinutes(30)
                });

                Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = refreshTokenExpiryTime
                });

                // Das ist neu ↓
                Response.Cookies.Append("email", email, new CookieOptions
                {
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                });
                // Das ist neu ↑
            }
            
            return Ok(new
            {
                Message = "Du wurdest erfolgreich eingeloggt.",

                User = new LoginResponseDto
                {
                    Email = user.Email,
                    AccessToken = accessToken,
                    RememberMe = rememberMe // Das ist neu
                }
            });
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var accessToken = Request.Cookies["accessToken"]; // Das ist neu

            if (accessToken == null)
            {
                var refreshToken = Request.Cookies["refreshToken"];

                if (string.IsNullOrEmpty(refreshToken))
                    return Unauthorized("Kein Refresh Token vorhanden.");

                var userToken = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

                if (userToken == null || userToken.RefreshTokenExpiryTime <= DateTime.Now)
                    return Unauthorized("Ungültiger oder abgelaufener Refresh Token.");

                var newAccessToken = _tokenGenerator.CreateAccessToken(userToken);
                var newRefreshToken = _tokenGenerator.CreateRefreshToken();
                var newRefreshTokenExpiryTime = DateTime.Now.AddDays(30);

                userToken.RefreshToken = newRefreshToken;
                userToken.RefreshTokenExpiryTime = newRefreshTokenExpiryTime;
                await _userManager.UpdateAsync(userToken);

                Response.Cookies.Append("accessToken", newAccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTime.Now.AddMinutes(30)
                });

                Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = newRefreshTokenExpiryTime
                });

                return Ok(new
                {
                    Message = "Tokens erfolgreich aktualisiert.",
                    AccessToken = newAccessToken
                });

            }
            else return Ok("Du hast bereits einen Access Token."); // Das ist neu
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");
            Response.Cookies.Delete("email");

            return Ok("Du hast dich erfolgreich ausgeloggt.");
        }

        // Prüft, ob ein accessToken in den Cookies gespeichert ist. Falls ja, ist User authentifiziert
        [HttpPost("checkAccessToken")]
        public IActionResult CheckAccessToken()
        {
            var accessToken = Request.Cookies["accessToken"];

            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized("Kein Access Token gefunden");

            return Ok("Du bist authentifiziert.");
        }
    }
}

