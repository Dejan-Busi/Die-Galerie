import { useState, useEffect } from "react";
import { useNavigate, NavLink } from "react-router-dom";
import axios from "axios";
import useAuth from "../Context/useAuth";
import loginSfx from "../Assets/Audio/login.mp3";
import menuBackSfx from "../Assets/Audio/menuBack.mp3";
import myFace from "../Assets/Bilder/myFace.png"

function Login() {
  
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [singleErrorMessage, setSingleErrorMessage] = useState("");
  const [rememberMe, setRememberMe] = useState(false);
  const [loading, setLoading] = useState(false);

  function handleLoginSfx() {
    const audio = new Audio(loginSfx);
    audio.play();
  }

  function handleMenuBack() {
    const audio = new Audio(menuBackSfx);
    audio.play();
  }

  const { auth, setAuth } = useAuth();

  const navigate = useNavigate();

  const erfolgreichRegistriert = sessionStorage.getItem("Signup response");
  const bitteEinloggen = sessionStorage.getItem("Bitte einloggen");

  useEffect(() => {
    return () => {
      sessionStorage.clear();
    };
  }, []);

  const port = import.meta.env.VITE_API_URL;

  const api = axios.create({ baseURL: `${port}` });

  // POST
  const handleSubmit = async (event) => {
    event.preventDefault();

    setLoading(true);

    const loginCredentials = { email, password, rememberMe };

    try {
      const response = await api.post("/api/account/login", loginCredentials, {
        headers: {"Content-Type": "application/json"},
        withCredentials: true,
      });

      console.log("Login Response:", response);

      localStorage.setItem("accessToken", response.data.user.accessToken);
      localStorage.setItem("email", response.data.user.email);

      setAuth({
        isAuthenticated: true,
      });

      navigate("/lobby");
      
      setEmail("");
      setPassword("");
      handleLoginSfx();
    } catch (error) {
      console.log("Login Error:", error);

      if (error.response.status == 400) {
        setSingleErrorMessage("Bitte fülle alle Felder aus.");
        sessionStorage.removeItem("Signup response");
      } 
      
      else {
        setSingleErrorMessage(error.response.data);
        setEmail("");
        setPassword("");
        sessionStorage.removeItem("Signup response");
      }
    } finally {
      setLoading(false);
    }
  };

  const handleRememberMe = () => {
    setRememberMe(!rememberMe);
  };

  return (
    <div>

      <br /> <br /><br /><br />
      <h1 style={{ fontSize: "3.5rem" }}>Login</h1>
      <br /> <br />
      <form>
        <label htmlFor="email" className="formularLabels">
          Email:
        </label>
        <br />
        <input
          type="email"
          id="email"
          className="inputField"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <br /> <br />
        <label htmlFor="password" className="formularLabels">
          Passwort:{" "}
        </label>{" "}
        <br />
        <input
          type="password"
          id="password"
          className="inputField"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <br />
        <label
          htmlFor="rememberMe"
          className="formularLabels"
          style={{ position: "relative" }}
        >
          Angemeldet bleiben
          <input
            type="checkbox"
            name="rememberMe"
            id="rememberMe"
            checked={rememberMe}
            onChange={handleRememberMe}
          />
        </label>
        <br /> <br /> <br />
        <div id="flexbox_button">
          <button type="submit" className="button"  onClick={handleSubmit}>
            {loading ? (
              <img src={myFace} className="loadingSymbol" />
            ) : (
              <p style={{ margin: 0 }}> Login</p>
            )}
          </button>
        </div>
      </form>
      <br />
      <p
        style={{
          backgroundColor: "green",
          color: "white",
          fontSize: "1.4rem",
          marginTop: "2rem",
        }}
      >
        {erfolgreichRegistriert}
      </p>
      <h2 style={{ backgroundColor: "Red", marginBlock: "2rem" }}>
        {bitteEinloggen}
      </h2>
      <p style={{ color: "red", fontSize: "1.4rem" }}> {singleErrorMessage}</p>
      <br /> <br />
      <br /> <br />
      <div style={{ backgroundColor: "lightblue", paddingBlock: 1 }}>
        <h2  style={{color: "black"}}>Noch nicht registriert?</h2>
        <NavLink to="/" onClick={handleMenuBack}>
          <p className="navLink">Registriere dich jetzt</p>
        </NavLink>
        {auth.isAuthenticated && (
          <NavLink to="/lobby" onClick={handleMenuBack}>
            <p className="navLink">Zurück zur Lobby</p>
          </NavLink>
        )}
      </div>
      <br />
      <br />
    </div>
  );
}

export default Login;
