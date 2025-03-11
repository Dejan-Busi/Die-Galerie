import stern1 from "../../Assets/Bilder/stern1.png";
import stern2 from "../../Assets/Bilder/stern2.png";
import stern3 from "../../Assets/Bilder/stern3.png";
import stern4 from "../../Assets/Bilder/stern4.png";
import stern5 from "../../Assets/Bilder/stern5.png";
import useAuth from "../../Context/useAuth";
import venus from "../../Assets/Bilder/Venus.webp";
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

function Venus() {
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
          .filter((elem) => elem.gemaeldeId === 9)
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
      const response = await api.post(`/api/bewertung/${9}`, bewertung, {
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
        <h1 style={{ fontSize: "3vw" }}>Venus</h1>
        <div className="flexbox_Portrait">
          <img src={venus} alt="Venus" className="portrait" />
          <div className="flexbox_vertikal">
            <p className="portraitParagraph">
              <h3>
                Jahr: ca. 1485 <br /> <br />
                Künstler: Sandro Botticelli (Italien)
              </h3>
              Die Geburt der Venus zeigt die Göttin Venus, die auf einer Muschel
              aus dem Meer emporsteigt. Sie wird von zwei mythischen Wesen
              begleitet, die sie mit einem Tuch bedecken und den Wind erzeugen,
              der sie an den Strand bringt. Das Gemälde ist bekannt für seine
              Eleganz, die Detailgenauigkeit und die idealisierte Darstellung
              des menschlichen Körpers. Venus wird als Symbol der Schönheit,
              Liebe und Fruchtbarkeit dargestellt, und das Bild ist ein
              Meisterwerk der italienischen Renaissance. Es befindet sich heute
              in den Uffizien in Florenz und ist eines der berühmtesten Werke
              der westlichen Kunstgeschichte.
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

export default Venus;
