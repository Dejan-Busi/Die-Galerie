import { useContext } from "react";
import AuthContext from "./AuthProvider";

const useAuth = () => {
  const { auth, setAuth, logout } = useContext(AuthContext);
  
  return { auth, setAuth, logout };
};

export default useAuth;
