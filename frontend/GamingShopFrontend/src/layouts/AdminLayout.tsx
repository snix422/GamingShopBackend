import { Outlet } from "react-router-dom";

const AdminLayout = () => {
  return (
    <main className="font-sans">
      <Navbar />
      <Outlet />
      <Footer />
    </main>
  );
};

export default AdminLayout;
