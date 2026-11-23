import { Outlet } from "react-router-dom";

const AppLayout = () => {
  return (
    <main className="font-sans">
      <Navbar />
      <Outlet />
      <Footer />
    </main>
  );
};

export default AppLayout;
