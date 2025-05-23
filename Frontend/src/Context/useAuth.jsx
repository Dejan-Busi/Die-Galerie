import { useContext } from "react";
import AuthContext from "./AuthProvider";

const useAuth = () => {
  const { auth, setAuth, loading, logout } = useContext(AuthContext);
  
  return { auth, setAuth, loading, logout };
};

export default useAuth;
