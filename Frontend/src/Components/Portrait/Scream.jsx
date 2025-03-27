import useAuth from "../../Context/useAuth";
import scream from "../../Assets/Bilder/Scream.webp";
import { NavLink } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import menuBackSfx from "../../Assets/Audio/menuBack.mp3";
import BewertungGepostetSfx from "../../Assets/Audio/bewertungGepostet.mp3";
import trashBin from "../../Assets/Bilder/trashBin.png";
import deleteSfx from "../../Assets/Audio/deleteSoundEffect.mp3";
import arrowBack from "../../Assets/Bilder/arrowBack.png";

function Scream() {
  const [postResponseMessage, setPostResponseMessage] = useState("");
  const [note, setNote] = useState();
  const [kommentar, setKommentar] = useState();
  const [gepostetVon, setGepostetVon] = useState();
  const [bewertungListe, setBewertungListe] = useState([]);
  const [leereFelderMeldung, setLeereFelderMeldung] = useState("");
  const [keineKommentareMessage, setKeineKommentareMessage] = useState("");

  const port = import.meta.env.VITE_API_URL;

  const { auth } = useAuth();

  const api = axios.create({ baseURL: `${port}` });

  // Sound Effects
  function handleMenuBack() {
    const audio = new Audio(menuBackSfx);
    audio.play();
  }

  function playConfirmSound() {
    const audio = new Audio(BewertungGepostetSfx);
    audio.volume = 0.8;
    audio.play();
  }

  function playDeleteSound() {
    const audio = new Audio(deleteSfx);
    audio.volume = 0.8;
    audio.play();
  }

  function handleEnterTaste(event) {
    if (event.key === "Enter") {
      event.preventDefault();
    }
  }

  // Scrollt die Seite ganz oben, sobald sie aufgemacht wird.
  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  // GET
  const getBewertungen = async () => {
    try {
      const response = await api.get("/api/bewertung");

      console.log("GET response:", response);

      const filteredResponse = response.data
        .filter((elem) => elem.gemaeldeId === 2)
        .reverse();

      setBewertungListe(filteredResponse);
      setKeineKommentareMessage("");
      console.log("filteredResponse:", filteredResponse);

      if (response.data.length == 0) {
        setKeineKommentareMessage("Es wurden noch keine Kommentare gepostet.");
      }
    } catch (error) {
      console.log("Error: ", error);
    }
  };

  useEffect(() => {
    getBewertungen();
  }, []);

  // POST
  const handleSubmit = async (event) => {
    event.preventDefault();
    const bewertung = { note, kommentar, gepostetVon };

    try {
      const response = await api.post(`/api/bewertung/${2}`, bewertung, {
        headers: { "Content-Type": "application/json" },
      });
      console.log("POST response: ", response);
      setPostResponseMessage("Deine Bewertung wurde gepostet ↓");
      setLeereFelderMeldung("");
      setKommentar("");
      setGepostetVon("");
      playConfirmSound();
      getBewertungen();
    } catch (error) {
      console.log(error);
      if ((error.response = 400)) {
        setPostResponseMessage("");
        setLeereFelderMeldung("Bitte fülle alle Felder aus.");
      }
      setPostResponseMessage("");
    }
  };

  // DELETE
  const handleDelete = async (bewertungId) => {
    const response = await api.delete(`/api/bewertung/${bewertungId}`);

    console.log("DELETE response:", response);

    setPostResponseMessage("");

    playDeleteSound();

    getBewertungen();
  };

  return (
    <section className="portrait_Page">
      <div className="portrait_Biographie">
        <NavLink to="/lobby" onClick={handleMenuBack}>
          <p className="zurueckZurLobby">
            <img src={arrowBack} alt="arrowBack" className="arrowBack" />
            Zurück zur Lobby
          </p>
        </NavLink>
        <h1 style={{ fontSize: "3.2rem", color: "white" }}>Der Schrei</h1>
        <div className="flexbox_Portrait">
          <img src={scream} alt="Der Schrei" className="portrait" />
          <div className="flexbox_vertikal">
            <p className="portraitParagraph">
              <br />
              Jahr: ca. 1893 <br /> <br />
              Künstler: Edvard Munch (Norwegen)
              <br /> <br />
              Der Schrei von ist eines der bekanntesten Werke der modernen
              Kunst. Es zeigt eine verzerrte Figur auf einer Brücke, die den
              Mund aufreißt und in einem Ausdruck völliger Verzweiflung in einen
              stürmischen Himmel blickt. Der Hintergrund ist in lebendigen, fast
              unheimlichen Farben gehalten, die die emotionale Intensität der
              Szene verstärken. Das Bild vermittelt Gefühle von Angst, Isolation
              und existenzieller Angst, die als Munchs persönliche
              Auseinandersetzung mit den düsteren Seiten des Lebens
              interpretiert werden. Der Schrei ist in verschiedenen Versionen
              entstanden und befindet sich heute in mehreren Museen, darunter in
              der Nationalgalerie in Oslo.
            </p>
          </div>
        </div>
        <br /> <br />
      </div>
      <div>
        <br /> <br />
        {auth.isAuthenticated && (
          <>
            {/* Formular */}
            <div>
              <form onKeyDown={handleEnterTaste} className="bewertungsFormular">
                <h1 className="kommentarFelder">Benote dieses Bild:</h1>
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
                <div>
                  {/* Meinung zum Bild */}
                  <h1 className="kommentarFelder">Deine Meinung zum Bild:</h1>
                  <textarea
                    id="textFeld"
                    rows={5}
                    cols={70}
                    placeholder="Dein Kommentar"
                    value={kommentar}
                    onChange={(e) => setKommentar(e.target.value)}
                    required
                  />
                </div>
                <br />
                {/* Dein Name */}
                <div>
                  <h1 className="kommentarFelder">Dein Name:</h1>
                  <input
                    type="text"
                    value={gepostetVon}
                    onChange={(e) => setGepostetVon(e.target.value)}
                    id="gepostetVon"
                    name="gepostetVon"
                  />
                </div>
                <br /> <br />
                <button type="button" onClick={handleSubmit} className="button">
                  Posten
                </button>
              </form>
            </div>
            <h2 style={{ backgroundColor: "lightgreen" }}>
              {postResponseMessage}
            </h2>
            <h2 style={{ backgroundColor: "red" }}>{leereFelderMeldung}</h2>
            {/* Kommentare */}
            <section className="bewertungListe">
              <h2>Kommentare:</h2>

              <p
                style={{
                  backgroundColor: "orange",
                  fontSize: "1.3rem",
                }}
              >
                {keineKommentareMessage}
              </p>

              {bewertungListe.map((elem) => (
                <div key={elem.id} className="kommentare">
                  <img
                    src={trashBin}
                    className="trashBin textPop"
                    onClick={() => handleDelete(elem.id)}
                  />
                  <br />
                  <p style={{ fontSize: "2rem" }}> {elem.gepostetVon} </p>
                  <br />
                  <strong>Note:</strong> {elem.note} <br /> <br /> <br />
                  <div>
                    <strong>Kommentar:</strong> <br />
                    {elem.kommentar} <br /> <br />
                  </div>
                  <div style={{ textAlign: "right", color: "lightskyblue" }}>
                    <strong>Gepostet am:</strong> {elem.gepostetAm} <br />
                    <br />
                    <br />
                  </div>
                </div>
              ))}
            </section>
          </>
        )}
        <br />
        {!auth.isAuthenticated && (
          <div className="bildKommentierenFrage">
            <h3>Möchtest du das Gemälde bewerten und kommentieren?</h3>
            <NavLink to="/" onClick={handleMenuBack}>
              <p className="navLink"> Registriere dich jetzt</p>
            </NavLink>
          </div>
        )}
      </div>
    </section>
  );
}

export default Scream;
