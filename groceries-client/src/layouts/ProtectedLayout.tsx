import { Navigate, Outlet } from "react-router-dom";

function ProtectedLayout() {
  const token = localStorage.getItem("token");

  if (!token) return <Navigate to="/login" />;

  return <Outlet />;
}

export default ProtectedLayout;
