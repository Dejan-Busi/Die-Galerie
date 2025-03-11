import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { NavLink } from "react-router-dom";
import axios from "axios";

function Kontakt() {
  const navigate = useNavigate();

  const [anrede, setAnrede] = useState("");
  const [vorName, setVorname] = useState("");
  const [nachName, setNachname] = useState("");
  const [absenderEmail, setAbsenderEmail] = useState("");
  const [nachricht, setNachricht] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const port = import.meta.env.VITE_API_URL;
  const api = axios.create({ baseURL: `${port}` });

  const handleSubmit = async (event) => {
    event.preventDefault();

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

      sessionStorage.setItem("Bestätigung", "Deine Anfrage wurde geschickt ✓");
      setErrorMessage("");
      navigate("/lobby");
    } catch (error) {
      console.error("Error:", error);
      if (error.response) {
        setErrorMessage(
          "Es gab ein Problem beim Senden der Nachricht: " + error.response.data
        );
      } else {
        setErrorMessage(
          "Netzwerkfehler: Bitte versuche es später noch einmal."
        );
      }
    }
  };

  return (
    <div>
      <h1>Kontakt</h1> <br />
      <form onSubmit={handleSubmit}>
        {/* Anrede */}
        <div>
          <label htmlFor="anrede">Anrede* </label> <br />
          <select
            name="anrede"
            id="anrede"
            required
            value={anrede}
            onChange={(e) => setAnrede(e.target.value)}
          >
            <option disabled value="">
              Auswahl
            </option>
            <option value="Herr">Herr</option>
            <option value="Frau">Frau</option>
            <option value="Andere">Andere</option>
          </select>
        </div>
        <br />
        {/* Vorname */}
        <div>
          <label htmlFor="vorName">Vorname* </label>
          <input
            type="text"
            id="vorName"
            name="vorName"
            value={vorName}
            onChange={(e) => setVorname(e.target.value)}
            required
          />
        </div>
        <br />
        {/* Nachname */}
        <div>
          <label htmlFor="nachName">Nachname* </label>
          <input
            type="text"
            id="nachName"
            name="nachName"
            value={nachName}
            onChange={(e) => setNachname(e.target.value)}
            required
          />
        </div>
        <br />
        {/* Absender Email */}
        <div>
          <label htmlFor="email">Deine Kontakt-Email* </label>
          <input
            type="email"
            id="email"
            name="email"
            value={absenderEmail}
            onChange={(e) => setAbsenderEmail(e.target.value)}
            required
          />
        </div>
        <br /> <br />
        {/* Nachricht */}
        <div id="textAreaBox_Container">
          <h3>Deine Nachricht:</h3>
          <label htmlFor="nachricht"></label>
          <textarea
            className="eingabeFelder"
            id="nachricht"
            name="nachricht"
            rows={15}
            cols={50}
            value={nachricht}
            onChange={(e) => setNachricht(e.target.value)}
            required
          />
        </div>
        <br />
        {/* Submit Button */}
        <div id="flexbox_button">
          <button type="submit" id="submitButton">
            Senden
          </button>

          <p style={{ color: "red" }}>{errorMessage}</p>
        </div>
      </form>
      <br /> <br />
      <div style={{ textAlign: "center" }}>
        <NavLink
          to="/lobby"
          className="zurueckZurLobby"
        >
          <h2 style={{ textDecoration: "underline" }}>Zurück zur Lobby</h2>
        </NavLink>
      </div>
    </div>
  );
}

export default Kontakt;
