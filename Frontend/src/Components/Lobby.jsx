import React from "react";
import { useEffect } from "react";
import { NavLink } from "react-router-dom";
import monaLisa from "../Assets/Bilder/MonaLisa.webp";
import scream from "../Assets/Bilder/Scream.webp";
import lastSupper from "../Assets/Bilder/LastSupper.webp";
import sternenNacht from "../Assets/Bilder/Sternennacht.webp";
import creationOfAdam from "../Assets/Bilder/CreationOfAdam.webp";
import girl from "../Assets/Bilder/Girl.webp";
import theKiss from "../Assets/Bilder/TheKiss.webp";
import venus from "../Assets/Bilder/Venus.webp";
import useAuth from "../Context/useAuth";
import hoverOverPaintingSfx from "../Assets/Audio/hoverOverPainting.mp3";
import clickOnPainting from "../Assets/Audio/clickOnPainting.mp3";
import menuForwardSfx from "../Assets/Audio/menuForward.mp3";
import menuBackSfx from "../Assets/Audio/menuBack.mp3";

function Lobby() {
  const emailGeschickt = sessionStorage.getItem("Email geschickt");

  useEffect(() => {
    return () => {
      sessionStorage.removeItem("Email geschickt");
    };
  }, []);

  const { auth } = useAuth();

  function handleMenuForward() {
    const audio = new Audio(menuForwardSfx);
    audio.play();
  }

  function handleMoveBack() {
    const audio = new Audio(menuBackSfx);
    audio.play();
  }

  function handleMouseOver() {
    const audio = new Audio(hoverOverPaintingSfx);
    audio.play();
  }

  function handleClickOnPainting() {
    const audio = new Audio(clickOnPainting);
    audio.play();
  }

  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  return (
    <div>
      {auth.isAuthenticated ? (
        <h1 style={{ fontSize: "3.5rem" }}>Lobby</h1>
      ) : (
        <h1 style={{ fontSize: "3rem" }}>Lobby (Preview)</h1>
      )}
      <p
        style={{
          backgroundColor: "green",
          color: "white",
          fontSize: "1.4rem",
        }}
      >
        {emailGeschickt}
      </p>
      ________________________________________________________________
      <h2>Wähle ein Gemälde aus:</h2> <br />
      {/* Oben */}
      <div className="paintings_flexbox">
        <div className="flexbox_reihe">
          <NavLink to="/monalisa">
            <img
              src={monaLisa}
              alt="MonaLisa"
              id="monaLisa"
              className="paintingLobby"
              onMouseOver={handleMouseOver}
              onClick={handleClickOnPainting}
            />
          </NavLink>

          {auth.isAuthenticated && (
            <NavLink to="/scream">
              <img
                src={scream}
                alt="Scream"
                id="scream"
                className="paintingLobby"
                onMouseOver={handleMouseOver}
                onClick={handleClickOnPainting}
              />
            </NavLink>
          )}
          {auth.isAuthenticated && (
            <NavLink to="/lastSupper">
              <img
                src={lastSupper}
                alt="LastSupper"
                id="lastSupper"
                className="paintingLobby"
                onMouseOver={handleMouseOver}
                onClick={handleClickOnPainting}
              />
            </NavLink>
          )}

          <NavLink to="/sternenNacht">
            <img
              src={sternenNacht}
              alt="Sternennacht"
              id="sternenNacht"
              className="paintingLobby"
              onMouseOver={handleMouseOver}
              onClick={handleClickOnPainting}
            />
          </NavLink>
        </div>

        <br />

        {/* Unten */}
        <div className="flexbox_reihe">
          {auth.isAuthenticated && (
            <NavLink to="/creationOfAdam">
              <img
                id="creationOfAdam"
                src={creationOfAdam}
                alt="CreationOfAdam"
                className="paintingLobby"
                onMouseOver={handleMouseOver}
                onClick={handleClickOnPainting}
              />
            </NavLink>
          )}

          <NavLink to="/theKiss">
            <img
              src={theKiss}
              alt="TheKiss"
              id="theKiss"
              className="paintingLobby"
              onMouseOver={handleMouseOver}
              onClick={handleClickOnPainting}
            />
          </NavLink>

          <NavLink to="/girl">
            <img
              src={girl}
              alt="Girl"
              to="/girl"
              id="girl"
              className="paintingLobby"
              onMouseOver={handleMouseOver}
              onClick={handleClickOnPainting}
            />
          </NavLink>

          {auth.isAuthenticated && (
            <NavLink to="/venus">
              <img
                src={venus}
                alt="Venus"
                id="venus"
                className="paintingLobby"
                onMouseOver={handleMouseOver}
                onClick={handleClickOnPainting}
              />
            </NavLink>
          )}
        </div>
      </div>
      <br />
      <br />
      <br />
      {auth.isAuthenticated && (
        <div
          style={{
            backgroundColor: "lightblue",
            paddingBlock: "0.2rem",
            marginBottom: "3rem",
          }}
        >
          <h2>Fragen oder Feedback:</h2>

          <NavLink
            to="/kontakt"
            onClick={handleMenuForward}
            className="navLink"
          >
            Kontaktiere mich
          </NavLink>
        </div>
      )}
      {!auth.isAuthenticated && (
        <div
          style={{
            backgroundColor: "lightblue",
            paddingBlock: "0.2rem",
            marginBottom: "3rem",
          }}
        >
          <h2>
            Möchtest du die{" "}
            <span style={{ textDecoration: "underline" }}>gesamte</span> Auswahl
            ansehen?{" "}
          </h2>
          <NavLink to="/" onClick={handleMoveBack}>
            <p className="navLink">Registriere dich jetzt!</p>
          </NavLink>
        </div>
      )}
      <br />
    </div>
  );
}

export default Lobby;
