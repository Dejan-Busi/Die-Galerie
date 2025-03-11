import { createContext, useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import axios from "axios";

const AuthContext = createContext({});

const port = import.meta.env.VITE_API_URL;

const api = axios.create({ baseURL: `${port}` });

export const AuthProvider = ({ children }) => {
  const [auth, setAuth] = useState({ isAuthenticated: false, user: null });
  const [loading, setLoading] = useState(true);
  const location = useLocation();

  useEffect(() => {
    const verifyTokens = async () => {
      setLoading(true);
      
      try {
    
      // Bei jeder Route soll geprüft werden, ob ein accessToken in der Storage ist, für die Erneuerung
      await api.post("/api/account/refreshToken", {}, { withCredentials: true });
        
        const response = await api.post("/api/account/checkAccessToken",
          {},
          { withCredentials: true }
        );

        if (response.status == 200) {
          setAuth({ isAuthenticated: true });
        } else {
          setAuth({ isAuthenticated: false });
        }
      } catch (error) {
        console.error("Error bei Token Verifizierung:", error);
        setAuth({ isAuthenticated: false });

      } finally {
        setLoading(false);
      }
    };

    verifyTokens();
  }, [location]);

  const logout = async () => {
    try {
      await api.post("api/account/logout", {}, { withCredentials: true });
      setAuth({ isAuthenticated: false });
    } catch (error) {
      console.log("Logout error:", error);
    }
  };

  return (
    <AuthContext.Provider value={{ auth, setAuth, loading, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
