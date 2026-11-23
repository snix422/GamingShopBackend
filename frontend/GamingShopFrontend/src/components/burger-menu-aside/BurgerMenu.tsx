import { Link } from "react-router-dom";
import { User } from "@firebase/auth";
import { SetStateAction } from "react";
import React from "react";

type BurgerMenuProps = {
  user: User | null;
  setOpen: React.Dispatch<SetStateAction<boolean>>;
};

const BurgerMenu: React.FC<BurgerMenuProps> = ({ user, setOpen }) => {
  return (
    <nav className="w-[30vw] flex mt-12">
      <ul className="w-full flex flex-col items-center gap-4">
        <li>
          <Link
            className="text-xl"
            to="/products"
            onClick={() => setOpen(false)}
          >
            Sklep
          </Link>
        </li>
      </ul>
    </nav>
  );
};

export default BurgerMenu;
