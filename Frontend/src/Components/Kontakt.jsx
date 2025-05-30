import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { NavLink } from "react-router-dom";
import menuBackSfx from "../Assets/Audio/menuBack.mp3";
import arrowBack from "../Assets/Bilder/arrowBack.png";
import messageSentSfx from "../Assets/Audio/messageSent.mp3";
import axios from "axios";
import myFace from "../Assets/Bilder/myFace.png";

function Kontakt() {
  const navigate = useNavigate();

  const [anrede, setAnrede] = useState("");
  const [vorName, setVorname] = useState("");
  const [nachName, setNachname] = useState("");
  const [absenderEmail, setAbsenderEmail] = useState("");
  const [nachricht, setNachricht] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [loading, setLoading] = useState(false);

  function handleMenuBack() {
    const audio = new Audio(menuBackSfx);
    audio.play();
  }

  const audio = new Audio(messageSentSfx);

  const port = import.meta.env.VITE_API_URL;

  const api = axios.create({ baseURL: `${port}` });

  // POST
  const handleSubmit = async (event) => {
    event.preventDefault();

    setLoading(true);

    const kontaktFormular = {
      anrede,
      vorName,
      nachName,
      absenderEmail,
      nachricht,
    };

    try {
      const response = await api.post("/api/email", kontaktFormular, {
        headers: { "Content-Type": "application/json" },
      });

      sessionStorage.setItem(
        "Email geschickt",
        "Deine Anfrage wurde gesendet ✓"
      );

      setErrorMessage("");
      navigate("/lobby");
      audio.play();
    } catch (error) {
      if (error.response) {
        setErrorMessage(
          "Es gab ein Problem beim Senden der Nachricht: " + error.response.data
        );
      } else {
        setErrorMessage(
          "Netzwerkfehler: Bitte versuche es später noch einmal."
        );
      }
    } finally {
      setLoading(false);
    }
  };

  return (
    <div id="kontaktHintergrund">
      <form onSubmit={handleSubmit} id="kontaktFormular">
        <h1 style={{ fontSize: "3.5rem" }}>Kontakt</h1> <br />
        {/* Anrede */}
        <div>
          <label htmlFor="anrede" className="formularLabels">
            Anrede{" "}
          </label>{" "}
          <br />
          <select
            name="anrede"
            id="anrede"
            value={anrede}
            onChange={(e) => setAnrede(e.target.value)}
          >
            <option disabled value="">Auswahl</option>
            <option value="Herr">Herr</option>
            <option value="Frau">Frau</option>
            <option value="Andere">Andere</option>
          </select>
        </div>
        <br /> <br />
        {/* Vorname */}
        <div>
          <label htmlFor="vorName" className="formularLabels">
            Vorname*{" "}
          </label>{" "}
          <br />
          <input
            type="text"
            className="inputField"
            name="vorName"
            id="vorName"
            placeholder="Max"
            value={vorName}
            onChange={(e) => setVorname(e.target.value)}
            required
          />
        </div>
        <br />
        {/* Nachname */}
        <div>
          <label htmlFor="nachName" className="formularLabels">
            Nachname*{" "}
          </label>{" "}
          <br />
          <input
            type="text"
            className="inputField"
            name="nachName"
            id="nachName"
            placeholder="Mustermann"
            value={nachName}
            onChange={(e) => setNachname(e.target.value)}
            required
          />
        </div>
        <br />
        {/* Absender Email */}
        <div>
          <label htmlFor="email" className="formularLabels">
            Deine Kontakt-Email*{" "}
          </label>{" "}
          <br />
          <input
            type="email"
            className="inputField"
            placeholder="beliebige@email.com"
            name="email"
            id="email"
            value={absenderEmail}
            onChange={(e) => setAbsenderEmail(e.target.value)}
            required
          />
        </div>
        <br />
        {/* Nachricht */}
        <div id="textAreaBox_Container" style={{ position: "relative" }}>
          <h3 style={{ fontSize: "1.7rem" }}>Deine Nachricht:</h3>
          <label htmlFor="nachricht"></label>
          <textarea
            className="eingabeFelder"
            id="nachricht"
            name="nachricht"
            rows={10}
            cols={50}
            value={nachricht}
            onChange={(e) => setNachricht(e.target.value)}
            required
          />
        </div>
        <br />
        {/* Submit Button */}
        <div id="flexbox_button">
          <button type="submit" className="button">
            {loading ? (
              <img src={myFace} className="loadingSymbol" />
            ) : (
              <p style={{ margin: 0 }}> Senden</p>
            )}
          </button>
        </div>
        <p style={{ color: "red" }}>{errorMessage}</p>
      </form>
      <br /> <br /> <br />
      <NavLink to="/lobby" onClick={handleMenuBack}>
        <p id="kontaktSeiteNavLink">
          <img src={arrowBack} alt="arrowBack" id="kontaktSeiteArrowBack" />
          Zurück zur Lobby
        </p>
      </NavLink>
    </div>
  );
}

export default Kontakt;
