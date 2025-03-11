import stern1 from "../../Assets/Bilder/stern1.png";
import stern2 from "../../Assets/Bilder/stern2.png";
import stern3 from "../../Assets/Bilder/stern3.png";
import stern4 from "../../Assets/Bilder/stern4.png";
import stern5 from "../../Assets/Bilder/stern5.png";
import useAuth from "../../Context/useAuth";
import sternNacht from "../../Assets/Bilder/Sternnacht.webp";
import { NavLink } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";

// Funktion für das Abspielen des Sounds beim Zurück-Buttons
const handleZurueckButton = () => {
  const audio = new Audio(backSound);
  audio.volume = 0.8;
  audio.play();
};

// Funktion für den Hover-Soundeffekt
const handleLogoOver = () => {
  const audio = new Audio(hover_sfx);
  audio.volume = 0.3;
  audio.play();
};

function Sternennacht() {
  const [mitteilung, setMitteilung] = useState("");
  const [note, setNote] = useState(1);
  const [kommentar, setKommentar] = useState("");
  const [gepostetVon, setGepostetVon] = useState("");
  const [bewertungListe, setBewertungListe] = useState([]);
  const [leereFelderMeldung, setLeereFelderMeldung] = useState("");

  const port = import.meta.env.VITE_API_URL;

  const api = axios.create({ baseURL: `${port}` });

  // Ladet alle Bewertungen automatisch
  useEffect(() => {
    const getBewertungen = async () => {
      try {
        const response = await api.get("/api/bewertung");

        console.log("response:", response);

        const filteredResponse = response.data
          .filter((elem) => elem.gemaeldeId === 5)
          .reverse();

        setBewertungListe(filteredResponse);

        console.log("filteredResponse:", filteredResponse);
      } catch (error) {
        console.log("error: ", error);
      }
    };

    getBewertungen();
  }, []);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const bewertung = { note, kommentar, gepostetVon };

    try {
      const response = await api.post(`/api/bewertung/${5}`, bewertung, {
        headers: { "Content-Type": "application/json" },
      });
      console.log("Response: ", response);
      setMitteilung(
        "Deine Bewertung wurde gepostet, bitte aktualisiere die Seite."
      );
      setLeereFelderMeldung("");
    } catch (error) {
      console.log(error);
      if (error.response = 400) {
        setLeereFelderMeldung("Bitte fülle alle Felder aus.")
      }
    }
  };

  // Scrollt das Fenster ganz oben sobald es aufgemacht wird
  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  const { auth } = useAuth();

  return (
    <section className="portrait_Page">
      <div className="portrait_Biographie">
        <h1 style={{ fontSize: "3vw" }}>Sternennacht</h1>
        <div className="flexbox_Portrait">
          <img src={sternNacht} alt="Sternnacht" className="portrait" />
          <div className="flexbox_vertikal">
            <p className="portraitParagraph">
              <h3>
                Jahr: 1889 <br /> <br />
                Künstler: Vincent van Gogh (Niederlande)
              </h3>
              Die Sternennacht von Vincent van Gogh wurde gemalt und zeigt einen
              dramatisch leuchtenden Nachthimmel über einem ruhigen Dorf. Der
              Himmel ist in wirbelnden, intensiven Farben dargestellt, die
              Bewegung und Energie vermitteln. Die Zypressen im Vordergrund
              stehen im Kontrast zum lebendigen Himmel und symbolisieren
              Stabilität. Das Gemälde spiegelt van Goghs innere Unruhe und seine
              psychischen Kämpfe wider, die er während seines Aufenthalts in
              einer Nervenheilanstalt erlebte. Es gilt als eines seiner
              bekanntesten Werke und ist heute im Museum of Modern Art in New
              York ausgestellt.
            </p>
          </div>
        </div>
        <br /> <br />
      </div>
      <footer className="footer">
        {auth.isAuthenticated && (
          <>
            <h2
              style={{
                color: "white",
                fontFamily:
                  "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
              }}
            >
              <br />
              Benote dieses Bild:
            </h2>
            <br />
            {/* Formular */}
            <div>
              <form>
                <div className="Bewertung">
                  <label className="radioButtons">
                    <input
                      type="radio"
                      name="bewertung"
                      value={note}
                      onChange={(e) => setNote(1)}
                    />
                    1
                  </label>

                  <label className="radioButtons">
                    <input
                      type="radio"
                      name="bewertung"
                      value={note}
                      onChange={(e) => setNote(2)}
                    />
                    2
                  </label>

                  <label className="radioButtons">
                    <input
                      type="radio"
                      name="bewertung"
                      value={note}
                      onChange={(e) => setNote(3)}
                    />
                    3
                  </label>

                  <label className="radioButtons">
                    <input
                      type="radio"
                      name="bewertung"
                      value={note}
                      onChange={(e) => setNote(4)}
                    />
                    4
                  </label>

                  <label className="radioButtons">
                    <input
                      type="radio"
                      name="bewertung"
                      value={note}
                      onChange={(e) => setNote(5)}
                    />
                    5
                  </label>

                  <label className="radioButtons">
                    <input
                      type="radio"
                      name="bewertung"
                      value={note}
                      onChange={(e) => setNote(6)}
                    />
                    6
                  </label>
                </div>
                <br />
                {/* Dein Name */}
                <div>
                  <h1> Dein Name: </h1>
                  <input
                    type="text"
                    value={gepostetVon}
                    onChange={(e) => setGepostetVon(e.target.value)}
                    id="gepostetVon"
                    name="gepostetVon"
                  />
                </div>
                <br />
                <div>
                  {/* Meinung zum Bild */}
                  <h2
                    style={{
                      color: "white",
                      fontFamily:
                        "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                    }}
                  >
                    Deine Meinung zum Bild:
                  </h2>
                  <textarea
                    id="textFeld"
                    rows={15}
                    cols={70}
                    placeholder="Dein Kommentar"
                    value={kommentar}
                    onChange={(e) => setKommentar(e.target.value)}
                  />
                </div>{" "}
                <br />
                <button type="button" onClick={handleSubmit}>
                  Absenden
                </button>
              </form>
            </div>
            <h2 style={{ backgroundColor: "green" }}>{mitteilung}</h2>
            <h2 style={{ backgroundColor: "red" }}>{leereFelderMeldung}</h2>
            {/* Kommentare */}
            <section
              style={{
                border: "solid",
                borderRadius: "20px",
                paddingInline: "30px",
              }}
            >
              <h2>Kommentare:</h2>
              {bewertungListe.map((elem) => (
                <div key={elem.id} className="bewertungenResponse">
                  <br />
                  <strong>Gepostet von:</strong> {elem.gepostetVon} <br />{" "}
                  <br />
                  <strong>Note:</strong> {elem.note} <br /> <br />
                  <div>
                    <strong>Kommentar:</strong> <br />
                    {elem.kommentar} <br /> <br />
                  </div>
                  <div style={{ textAlign: "right", color: "lightskyblue" }}>
                    <strong>Gepostet am:</strong> {elem.gepostetAm} <br />{" "}
                    <br />
                  </div>
                </div>
              ))}
              <div></div>
            </section>
          </>
        )}
        <br /> <br />
        <div className="bildKommentierenFrage">
          {!auth.isAuthenticated && (
            <div style={{ paddingBlock: 1 }}>
              <h3>Möchtest du das Gemälde bewerten und kommentieren?</h3>
              <NavLink to="/login">
                <h2 style={{ textDecoration: "underline" }}> Melde dich an</h2>
              </NavLink>
            </div>
          )}
        </div>
        <br />
        {/* Zurück zur Lobby */}
        <div style={{ textAlign: "center" }}>
          <NavLink
            to="/lobby"
            className="zurueckZurLobby"
            onClick={handleZurueckButton}
            onMouseOver={handleLogoOver}
          >
            <h2 style={{ textDecoration: "underline" }}>Zurück zur Lobby</h2>
          </NavLink>
        </div>
      </footer>
    </section>
  );
}

export default Sternennacht;
