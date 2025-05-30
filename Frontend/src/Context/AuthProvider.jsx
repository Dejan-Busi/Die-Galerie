import { createContext, useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import axios from "axios";

const AuthContext = createContext({});

const port = import.meta.env.VITE_API_URL;

const api = axios.create({ baseURL: `${port}` });

export const AuthProvider = ({ children }) => {
  const [auth, setAuth] = useState({ isAuthenticated: false });

  const location = useLocation();

  useEffect(() => {
    const verifyToken = async () => {

      try {
        const response = await api.post("/api/account/refreshToken", {},
          {
            withCredentials: true,
          }
        );

        console.log("POST refreshToken Response:", response);
        
        // Wenn der AccessToken noch gültig war, ist alles ok und es wurde
        // kein neuer AccessToken zurückgegeben.
        if (response.status == 200 && !response.data.accessToken) {
          setAuth({ isAuthenticated: true });
        }
        
        // Wenn alter AccessToken abgelaufen ist und neuer zurückgegeben wurde.
        else if (response.data.accessToken) {
          localStorage.setItem("accessToken", response.data.accessToken);
          setAuth({ isAuthenticated: true });
        } 
        
        // Wenn irgendetwas falsch gelaufen ist.
        else {
          setAuth({ isAuthenticated: false });
        }
        
      } catch (error) {
        console.log("POST refreshToken Error:", error);
        setAuth({ isAuthenticated: false });
      } 
    };
    
    verifyToken();
  }, [location]);

  const logout = async () => {

    try {
      await api.post("/api/account/logout", {}, { withCredentials: true });
      setAuth({ isAuthenticated: false });
      
    } catch (error) {
      console.log("Logout-Error:", error);
    }
  };

  return (
    <AuthContext.Provider value={{ auth, setAuth, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
