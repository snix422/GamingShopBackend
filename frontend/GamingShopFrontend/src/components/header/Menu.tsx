import { Link } from "react-router-dom";
import { User } from "@firebase/auth";
import React from "react";

type MenuProps = {
  isAuth: User | null;
};

const Menu: React.FC<MenuProps> = ({ isAuth }) => {
  return (
    <nav className="flex max-lg:hidden">
      <ul className="w-full flex justify-center gap-24">
        <li>
          <Link
            className="text-xl text-black hover:text-blue-600 transition duration-300"
            to="/products"
          >
            Sklep
          </Link>
        </li>
      </ul>
    </nav>
  );
};

export default Menu;
