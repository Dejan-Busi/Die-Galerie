import { createContext, useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import axios from "axios";

const AuthContext = createContext({});

const port = import.meta.env.VITE_API_URL;

const api = axios.create({ baseURL: `${port}` });

export const AuthProvider = ({ children }) => {
  const [auth, setAuth] = useState({
    isAuthenticated: false,
    accessToken: null,
  });
  const [loading, setLoading] = useState(true);
  const location = useLocation();

  useEffect(() => {
    const verifyToken = async () => {
      setLoading(true);

      const accessToken = localStorage.getItem("accessToken");

      try {
        const response = await api.post(
          "/api/account/refreshToken",
          {},
          {
            withCredentials: true,
            headers: {
              Authorization: `Bearer ${accessToken}`,
            },
          }
        );

        if (response.status == 200 && !response.data.accessToken) {
          setAuth({ isAuthenticated: true });
        } else if (response.data.accessToken) {
          localStorage.setItem("accessToken", response.data.accessToken);
        } else {
          setAuth({ isAuthenticated: false });
        }
      } catch (error) {
        console.log("Fehler bei Token-Verifizierung:", error);
        setAuth({ isAuthenticated: false });
      } finally {
        setLoading(false);
      }
    };

    verifyToken();
  }, [location]);

  const logout = async () => {
    try {
      await api.post("/api/account/logout", {}, { withCredentials: true });
      setAuth({ isAuthenticated: false, user: null });
    } catch (error) {
      console.error("Logout-Fehler:", error);
    }
  };

  return (
    <AuthContext.Provider value={{ auth, setAuth, loading, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
