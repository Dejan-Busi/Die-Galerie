import React, { useState, useRef, useEffect } from "react";
import { useNavigate, useLocation, NavLink } from "react-router-dom";
import useAuth from "../Context/useAuth";
import axios from "axios";

function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [rememberMe, setRememberMe] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");
  const location = useLocation();

  const { setAuth } = useAuth();
  const navigate = useNavigate();

  const signupResponse = sessionStorage.getItem("Signup response");
  const bitteEinloggen = sessionStorage.getItem("Bitte einloggen");

  // Löscht die Nachricht, wenn der User von der "Kontakiere Mich"-Seite umgeleitet wird.
  useEffect(() => {
    return () => {
      console.log("Session Storage Einträge gelöscht.");
      sessionStorage.removeItem("Bitte einloggen");
    };
  }, []);

  const port = import.meta.env.VITE_API_URL;

  const api = axios.create({ baseURL: `${port}` });

  // HandleSubmit
  const handleSubmit = async (event) => {
    event.preventDefault();

    const loginCredentials = { email, password, rememberMe };

    try {
      const response = await api.post("/api/account/login", loginCredentials, {
        headers: { "Content-Type": "application/json" },
        withCredentials: true,
      });

      navigate("/lobby");

      setEmail("");
      setPassword("");
    } catch (error) {
      console.log(error);

      if (error.response.status === 400) {
        setErrorMessage("Bitte fülle alle Felder aus.");
        sessionStorage.removeItem("Signup response");
      } else {
        setErrorMessage(error.response?.data);
        setEmail("");
        setPassword("");
        sessionStorage.removeItem("Signup response");
      }
    }
  };

  const handleCheckout = () => {
    setRememberMe(!rememberMe);
  };

  return (
    <div>
      <h2 style={{ backgroundColor: "Red" }}>{bitteEinloggen}</h2>
      <h1>Login</h1>
      <form onSubmit={handleSubmit}>
        <label htmlFor="email">Email: </label>
        <input
          type="email"
          id="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <br /> <br />
        <label htmlFor="password">Passwort: </label>
        <input
          type="password"
          id="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <br /> <br />
        <label htmlFor="rememberMe">Angemeldet bleiben</label>
        <input
          type="checkbox"
          id="rememberMe"
          checked={rememberMe}
          onChange={handleCheckout}
        />
        <br /> <br />
        <button type="submit" id="login" onclick={handleSubmit}>
          Login
        </button>
      </form>
      <br />
      <p style={{ backgroundColor: "green", color: "white" }}>
        {signupResponse}
      </p>
      <p style={{ color: "red" }}>{errorMessage}</p>
      <br /> <br />
      <div style={{ backgroundColor: "lightblue", paddingBlock: 1 }}>
        <h2>Noch kein Konto?</h2>
        <NavLink to="/">
          <h2 style={{ textDecoration: "underline" }}>
            Registriere dich jetzt
          </h2>
        </NavLink>
      </div>
      <br />
      <br />
    </div>
  );
}

export default Login;
