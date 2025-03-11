import React from "react";
import { useEffect } from "react";
import { NavLink } from "react-router-dom";
import monaLisa from "../Assets/Bilder/MonaLisa.webp";
import scream from "../Assets/Bilder/Scream.webp";
import lastSupper from "../Assets/Bilder/LastSupper.webp";
import sternNacht from "../Assets/Bilder/Sternnacht.webp";
import creationOfAdam from "../Assets/Bilder/CreationOfAdam.webp";
import girl from "../Assets/Bilder/Girl.webp";
import theKiss from "../Assets/Bilder/TheKiss.webp";
import venus from "../Assets/Bilder/Venus.webp";
import useAuth from "../Context/useAuth";
import brush1 from "../Assets/Audio/Brush_1.mp3";
import brush2 from "../Assets/Audio/Brush_2.mp3";
import brush3 from "../Assets/Audio/Brush_3.mp3";
import brush4 from "../Assets/Audio/Brush_4.mp3";
function Lobby() {
  const emailAnfrageNachricht = sessionStorage.getItem("Bestätigung");

  // Löscht die Nachricht, wenn der User von der "Lobby" umgeleitet wird.
  useEffect(() => {
    return () => {
      console.log("Session Storage Einträge gelöscht.");
      sessionStorage.removeItem("Bestätigung");
    };
  }, []);

  const { auth } = useAuth();

  const handleContactUs = async (event) => {
    if (auth.isAuthenticated == false && auth.user == null) {
      sessionStorage.setItem(
        "Bitte einloggen",
        "Bitte logge dich ein, um uns zu kontaktieren."
      );
    }
  };

  // const brushSounds = [
  //   brush1,
  //   brush2,
  //   brush3,
  //   brush4,
  // ];

  // const painting = document.get("scream");

  // painting.onmouseover = () => {
  //   const i = Math.floor(Math.random() * brushSounds.length);
  //   const audio = new Audio(brushSounds[i]);
  //   audio.play();
  //   console.log("Mauszeiger darüber")
  // };

  return (
    <div>
      <h1>Lobby</h1>

      <h2>Wähle ein Gemälde aus:</h2>

      {/* Oben */}
      <div className="paintings_flexbox">
        <div className="flexbox_reihe">
          <NavLink to="/monalisa">
            <img
              src={monaLisa}
              alt="MonaLisa"
              id="monaLisa"
              className="painting"
            />
          </NavLink>

          {auth.isAuthenticated && (
            <NavLink to="/scream">
              <img src={scream} alt="Scream" id="scream" className="painting" />
            </NavLink>
          )}
          {auth.isAuthenticated && (
            <NavLink to="/lastSupper">
              <img
                src={lastSupper}
                alt="LastSupper"
                id="lastSupper"
                className="painting"
              />
            </NavLink>
          )}

          <NavLink to="/sternNacht">
            <img
              src={sternNacht}
              alt="Sternnacht"
              id="sternNacht"
              className="painting"
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
                className="painting"
              />
            </NavLink>
          )}

          <NavLink to="/theKiss">
            <img
              src={theKiss}
              alt="TheKiss"
              id="theKiss"
              className="painting"
            />
          </NavLink>

          <NavLink to="/girl">
            <img
              src={girl}
              alt="Girl"
              to="/girl"
              id="girl"
              className="painting"
            />
          </NavLink>

          {auth.isAuthenticated && (
            <NavLink to="/venus">
              <img src={venus} alt="Venus" id="venus" className="painting" />
            </NavLink>
          )}
        </div>
      </div>

      <br />

      {!auth.isAuthenticated && (
        <div>
          <h2>Möchtest du die gesamte Auswahl ansehen? </h2>
          <NavLink to="/login">
            <h2 style={{ textDecoration: "underline" }}> Melde dich an</h2>
          </NavLink>
        </div>
      )}

      <br />

      <p style={{ backgroundColor: "green", color: "white", paddingBlock: 1, fontSize: "large" }}>
        {emailAnfrageNachricht}
      </p>

      <div  style={{ backgroundColor: "lightblue", paddingBlock: "0.2vw", marginBottom: "3vw" }}>
        <h2>Fragen oder Anregungen?</h2>

        <NavLink to="/kontakt" onClick={handleContactUs}>
          <h2 style={{ textDecoration: "underline" }}>Kontaktiere uns</h2>
        </NavLink>
      </div>
    </div>
  );
}

export default Lobby;
