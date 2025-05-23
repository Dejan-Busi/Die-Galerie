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
import Sternennacht from "./Components/Portrait/Sternennacht";
import TheKiss from "./Components/Portrait/TheKiss";
import Venus from "./Components/Portrait/Venus";
import BehindTheScenes from "./Components/BehindTheScenes";
import ProtectedRoutes from "./Services/ProtectedRoutes";
import { Routes, Route, Navigate } from "react-router-dom";
import useAuth from "./Context/useAuth";
import LoadingScreen from "./Components/LoadingScreen";
import { useState, useEffect } from "react";

function App() {
  const { auth } = useAuth();
  
  const [loading, setLoading] = useState(true);

  useEffect(() => {

    setTimeout(() => {
      setLoading(false);
    }, 1000);
    
  }, [])

  return (
    <>
      {loading ? (
        <LoadingScreen />
      ) : (
        <>
          <LogoutBar />
          <Routes>
            <Route
              path="/"
              element={
                auth.isAuthenticated ? <Navigate to="/lobby" /> : <SignUp />
              }
            />
            <Route path="/lobby" element={<Lobby />} />
            <Route
              path="/login"
              element={
                auth.isAuthenticated ? <Navigate to="/lobby" /> : <Login />
              }
            />
            <Route path="/logoutBar" element={<LogoutBar />} />
            <Route path="/monaLisa" element={<MonaLisa />} />
            <Route path="/sternenNacht" element={<Sternennacht />} />
            <Route path="/girl" element={<Girl />} />
            <Route path="/theKiss" element={<TheKiss />} />
            <Route path="/behindTheScenes" element={<BehindTheScenes />} />

            <Route element={<ProtectedRoutes />}>
              <Route path="/creationOfAdam" element={<CreationOfAdam />} />
              <Route path="/lastSupper" element={<LastSupper />} />
              <Route path="/scream" element={<Scream />} />
              <Route path="/venus" element={<Venus />} />
              <Route path="/kontakt" element={<Kontakt />} />
            </Route>

            <Route path="/*" element={<Navigate to="/lobby" />} />
          </Routes>
        </>
      )}
      
    </>
  );
}

export default App;
