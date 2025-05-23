import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { NavLink } from "react-router-dom";
import useAuth from "../Context/useAuth";
import axios from "axios";
import vanGogh from "../Assets/Bilder/vanGogh.webp";
import davinci from "../Assets/Bilder/daVinci.webp";
import previewEye from "../Assets/Bilder/eye.png";
import menuForwardSfx from "../Assets/Audio/menuForward.mp3";
import snapSfx from "../Assets/Audio/snap.mp3";
import myFace from "../Assets/Bilder/myFace.png";
import actionClapper from "../Assets/Bilder/actionClapper.png";
import feder from "../Assets/Bilder/feder.png";

function SignUp() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [passwordErrorMessage, setPasswordErrorMessage] = useState([]);
  const [loading, setLoading] = useState(false);

  const navigate = useNavigate();

  const { auth } = useAuth();

  // Diese Zeile importiert die Umgebungsvariable
  const port = import.meta.env.VITE_API_URL;

  const handleContactUs = async () => {
    if (auth.isAuthenticated == false && auth.user == null) {
      sessionStorage.setItem(
        "Bitte einloggen",
        "Info: Bitte logge dich ein, um das Kontaktformular zu benutzen."
      );
      handleMenuForward();
    }
  };

  function handleMenuForward() {
    const audio = new Audio(menuForwardSfx);
    audio.play();
  }

    function handleSnap() {
      const audio = new Audio(snapSfx);
      audio.play();
    }

  const api = axios.create({ baseURL: `${port}` });

  // POST
  const handleSubmit = async (event) => {
    event.preventDefault();

    setLoading(true);

    const newUser = { email, password, confirmPassword };

    try {
      const response = await api.post("/api/account/register", newUser);
      console.log(response.data.message);
      sessionStorage.setItem("Signup response", response.data.message);
      navigate("/login");
    } catch (error) {
      if (error.response.status == 500) {
        console.log("Passwortkriterien nicht erfüllt", error);
        const passwordErrorMessage = error.response.data;
        setPasswordErrorMessage(passwordErrorMessage);
        setErrorMessage("");
      } else if (error.response.status === 400) {
        console.log("Passwörter stimmen nicht überein", error);

        let errorResponse = "";

        if (error.response.data.errors?.ConfirmPassword) {
          errorResponse = error.response.data.errors.ConfirmPassword;
        } else if (error.response.data?.message) {
          errorResponse = error.response.data.message;
        } else if (typeof error.response.data === "string") {
          errorResponse = error.response.data;
        }
        setErrorMessage(errorResponse);
        setPasswordErrorMessage([]);
      }
    } finally {
      setLoading(false);
    }
  };
  return (
    <div>
      <div id="signUpPage">
        <div id="introBanner">
          <h1 style={{ fontSize: "4rem", marginTop: 0 }}>Die Galerie</h1>
          <p style={{ fontSize: "1.5rem" }}>
            Das Portal, wo die bekanntesten Gemälder der Welt aufgelistet sind.
            <br /> <br />
            By <strong>Dejan Busikovic</strong>
          </p>
        </div>
        <br />
        <div id="registrieren_flexbox">
          <img src={vanGogh} alt="Napoleon" id="vanGogh" />

          <div>
            <h1 style={{ fontSize: "2.5rem" }}>Registrieren:</h1>
            <form onSubmit={handleSubmit}>
              <br />
              <label className="formularLabels">Email: </label> <br />
              <input
                type="email"
                value={email}
                name="email"
                placeholder="test@test.de"
                onChange={(e) => setEmail(e.target.value)}
                required
              />
              <br /> <br />
              <label className="formularLabels">Passwort: </label> <br />
              <input
                type="password"
                value={password}
                name="password"
                placeholder="admin1234"
                onChange={(e) => setPassword(e.target.value)}
                required
              />
              <br /> <br />
              <label className="formularLabels">
                Passwort bestätigen:{" "}
              </label>{" "}
              <br />
              <input
                type="password"
                value={confirmPassword}
                name="confirmPassword"
                placeholder="admin1234"
                onChange={(e) => setConfirmPassword(e.target.value)}
                required
              />
              <br /> <br /> <br />
              <div id="flexbox_button">
                <button type="submit" className="button">
                  {loading ? (
                    <img src={myFace} className="loadingSymbol" />
                  ) : (
                    <p style={{ margin: 0 }}> Senden</p>
                  )}
                </button>
              </div>
              <br /> <br />
            </form>
          </div>

          <img src={davinci} alt="Napoleon" id="daVinci" />
        </div>
        <br /> <br />
        <p style={{ color: "red", fontSize: "1.5rem" }}>{errorMessage}</p>
        {passwordErrorMessage.map((elem) => (
          <div key={elem.code}>
            <p style={{ color: "red", fontSize: "1.3rem" }}>
              {" "}
              - {elem.description}
            </p>
          </div>
        ))}
        <br /> <br />
        {/* Section */}
        <section id="startSeiteFlexbox">

        {/* Behind The Scenes */}
        <div id="behind_the_Scenes">
            <h2 style={{ color: "black", textAlign: "center", fontSize: "1.8rem"}}>Trivia:</h2>

            <NavLink
              to="/behindTheScenes"
              style={{ margin: "auto" }}
              onClick={handleSnap}
            >
              <p className="navLink" style={{ fontSize: "2rem", color: "lightcoral"   }}>
                <img id="actionClapperSignup" src={actionClapper} alt="Action Clapper" />
                Behind the Scenes
              </p>
            </NavLink>
      
          </div>
          {/* Vorteile beim Registrieren */}
          <div id="vorteile_Registrieren">
            <h2 style={{ color: "black", textAlign: "center", fontSize: "1.7rem"   }}>Vorteile beim Registrieren:</h2>

            <p className="formularLabels">
              <span style={{ color: "lightgreen", fontSize: "2rem" }}>✓</span>{" "}
              Siehe die gesamte Auswahl der Gemälder an.
            </p>
            <p className="formularLabels">
              <span style={{ color: "lightgreen", fontSize: "2rem" }}>✓</span>{" "}
              Bewerte und kommentiere die Gemälder.
            </p>
            <p className="formularLabels">
              <span style={{ color: "lightgreen", fontSize: "2rem" }}>✓</span>{" "}
              Zugriff auf Kontaktformular für Feedbacks.
            </p>
          </div>
          {/* Vorgeschmack der App */}
          <div id="vorgeschmack_App">
            <h2 style={{ color: "black", fontSize: "1.7rem" }}>Ein Vorgeschmack der App:</h2>
            <NavLink
              to="/lobby"
              style={{ margin: "auto" }}
              onClick={handleMenuForward}
            >
              <p className="navLink" style={{ fontSize: "2rem" }}>
                <img id="previewEye" src={previewEye} alt="eye" />
                Preview
              </p>
            </NavLink>
          </div>
          <br />
        </section>
        <br /> <br />
        <div
          style={{
            backgroundColor: "lightblue",
            paddingBlock: "0.2rem",
            marginBottom: "1rem",
          }}
        >
          <h2 style={{color: "black"}}>Fragen oder Feedback:</h2>

          <NavLink
            to="/kontakt"
            onClick={handleContactUs}
            style={{ textDecoration: "underline", color: "black", position: "relative" }}
          >
            <p className="navLink">Kontaktiere mich
            <img src={feder} className="feder" alt="Schreibfeder" />
            </p>
          </NavLink>
        </div>
      </div>
    </div>
  );
}

export default SignUp;
