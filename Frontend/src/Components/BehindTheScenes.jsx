import React from "react";
import { useEffect } from "react";
import { NavLink } from "react-router-dom";
import useAuth from "../Context/useAuth";
import menuBackSfx from "../Assets/Audio/menuBack.mp3";
import react from "../Assets/Bilder/vite+React.png";
import arrowBack from "../Assets/Bilder/arrowBack.png";
import aspNetCore from "../Assets/Bilder/ASP.NET.Core.png";
import entityFramework from "../Assets/Bilder/entityFrameworkCore.png";
import sqlServer from "../Assets/Bilder/Microsoft_SQL_Server_Logo.svg";
import jwt from "../Assets/Bilder/JWT.png";
import dejan from "../Assets/Bilder/dejan.jpg";

function BehindTheScenes() {
  const { auth } = useAuth();

  function handleMenuBack() {
    const audio = new Audio(menuBackSfx);
    audio.play();
  }

  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  return (
    <div id="behindTheScenes">
      {" "}
      <br />
      {auth.isAuthenticated ? (
        <NavLink to="/lobby" onClick={handleMenuBack}>
          <p className="zurueckZurLobbyBehindTheScenes">
            <img
              src={arrowBack}
              alt="Arrow Back"
              className="arrowBackBehindTheScenes"
            />
            Zurück zur Lobby
          </p>
        </NavLink>
      ) : (
        <NavLink to="/" onClick={handleMenuBack}>
          <p className="zurueckZurLobbyBehindTheScenes">
            <img
              src={arrowBack}
              alt="Arrow Back"
              style={{ width: "23%" }}
              className="arrowBackBehindTheScenes"
            />
            Zurück zur Startseite
          </p>
        </NavLink>
      )}
      <h1 style={{ fontSize: "4rem", textDecoration: "underline" }}>Motiv:</h1>{" "}
      <br /> <br />
      <div id="flexBox_behindTheScenes">
        <img src={dejan} id="dejan" alt="Ich" />
        <p id="motivText">
          Die Motivation für das Entwickeln dieses Projektes war, mich selbst
          herauszufordern, eine kleine Full-Stack-Anwendung mit der
          Implementierung aller CRUD-Operationen, einer einfachen Form der
          Authentifizierung, Conditional Rendering basierend auf
          User-Interaktion sowie einer stylischen UI zu realisieren. Die Idee
          einer Bildergalerie kommt daher, dass die App einerseits einen Fokus
          auf die Optik legen sollte, wodurch ein visuell-lastiges Konzept wie
          eine Bildergalerie als natürliche Lösung erschien, und andererseits
          der User beim Interagieren mit der App, beispielsweise beim Lesen der
          Hintergrundgeschichten der Gemälde, etwas lernen kann. Das Projekt war
          sehr lehrreich und es war sehr spannend, die oben genannten
          Anforderungen zu einem lauffähigen Produkt zusammenzuführen.
          <br /> <br /> <br />- Dejan Busikovic
        </p>
      </div>
      <br /> <br />
      <div id="verwendete_Technologien">
        <h1 style={{ fontSize: "2rem", backgroundColor: "white" }}>
          Verwendete Technologien:
        </h1>{" "}
        <br /> <br />
        <div id="flexBox_Technologien_Oben">
          <img src={react} id="Vite_React" alt="Vite + React" />
          <img src={aspNetCore} id="ASPNET" alt="ASP.NET Core" /> <br />
        </div>{" "}
        <br /> <br />
        <div id="flexBox_Technologien_Unten">
          <img src={sqlServer} id="sqlServer" alt="MS SQL Server" />
          <img src={jwt} id="jwt" alt="MS SQL Server" />
          <img
            src={entityFramework}
            id="entityFramework"
            alt="entityFramework"
          />
        </div>
      </div>
    </div>
  );
}

export default BehindTheScenes;
