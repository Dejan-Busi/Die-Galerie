import { useLocation, Navigate, Outlet } from "react-router-dom";
import useAuth from "../Context/useAuth";

const ProtectedRoutes = () => {
  
  const location = useLocation();
  const { auth } = useAuth();

  return (
    auth.isAuthenticated 
      ? <Outlet />
      : <Navigate to="/login" state={{ from: location }} replace />
  );
};

export default ProtectedRoutes;

