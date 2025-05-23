import React from "react";
import { useNavigate } from "react-router-dom";
import useAuth from "../Context/useAuth";
import logoutSfx from "../Assets/Audio/logout.mp3";
import { NavLink } from "react-router-dom";
import menuForwardSfx from "../Assets/Audio/menuForward.mp3";

function LogoutBar() {
  const { logout, auth } = useAuth();

  function handleLogin() {
    const audio = new Audio(logoutSfx);
    audio.play();
  }

  function handleMoveForward() {
    const audio = new Audio(menuForwardSfx);
    audio.play();
  }

  const navigate = useNavigate();

  const email = localStorage.getItem("email");

  const handleLogout = async () => {
    try {
      await logout();
      sessionStorage.clear();
      localStorage.clear();
      handleLogin();
      navigate("/");
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <>
      {auth.isAuthenticated ? (
        <div id="logoutBarGreen">
          <p style={{ paddingInline: "1rem" }}>
            '{email}' <br />
            ist eingeloggt
          </p>
          <button onClick={handleLogout}>Logout</button>
        </div>
      ) : (
        <div id="logoutBarRed">
          <p style={{ paddingInline: "1rem" }}>Du bist nicht eingeloggt</p>
          <NavLink to="/login" onClick={handleMoveForward}>
            <button>Einloggen</button>
          </NavLink>
        </div>
      )}
    </>
  );
}

export default LogoutBar;
