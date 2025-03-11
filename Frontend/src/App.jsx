import "./App.css";
import SignUp from "./Components/SignUp";
import Login from "./Components/Login";
import LogoutBar from "./Components/LogoutBar";
import Lobby from "./Components/Lobby";
import Kontakt from "./Components/Kontakt";
import MonaLisa from "./Components/Portrait/MonaLisa";
import CreationOfAdam from "./Components/Portrait/CreationOfAdam";
import Girl from "./Components/Portrait/Girl";
import LastSupper from "./Components/Portrait/LastSupper";
import Scream from "./Components/Portrait/Scream";
import Sternnacht from "./Components/Portrait/Sternnacht";
import TheKiss from "./Components/Portrait/TheKiss";
import Venus from "./Components/Portrait/Venus";
import ProtectedRoutes from "./Services/ProtectedRoutes";
import { Routes, Route } from "react-router-dom";
import useAuth from "./Context/useAuth";
import { Navigate } from "react-router-dom";

function App() {
  const { auth } = useAuth();

  return (
    <>
      {auth.isAuthenticated && <LogoutBar />}
      <Routes>
        <Route path="/" element={auth.isAuthenticated ? <Navigate to="/lobby" /> : <SignUp />} />
        <Route path="/lobby" element={<Lobby />} />
        <Route path="/login" element={auth.isAuthenticated ? <Navigate to="/lobby" /> : <Login />} />
        <Route path="/logoutBar" element={<LogoutBar />} />
        <Route path="/monaLisa" element={<MonaLisa />} />
        <Route path="/sternNacht" element={<Sternnacht />} />
        <Route path="/girl" element={<Girl />} />
        <Route path="/theKiss" element={<TheKiss />} />

        <Route element={<ProtectedRoutes />}>
          <Route path="/creationOfAdam" element={<CreationOfAdam />} />
          <Route path="/lastSupper" element={<LastSupper />} />
          <Route path="/scream" element={<Scream />} />
          <Route path="/venus" element={<Venus />} />
          <Route path="/kontakt" element={<Kontakt />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
