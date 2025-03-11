import React from "react";
import { useNavigate } from "react-router-dom";
import useAuth from "../Context/useAuth";

function LogoutBar() {
  const { logout } = useAuth();

  const navigate = useNavigate();

  const handleLogout = async () => {
    try {
      await logout();
      sessionStorage.clear();
      localStorage.clear();
    
      navigate("/");
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div id="logoutBar">
      <p>Du bist eingeloggt</p>
      <button onClick={handleLogout}>Logout</button>
    </div>
  );
}

export default LogoutBar;

