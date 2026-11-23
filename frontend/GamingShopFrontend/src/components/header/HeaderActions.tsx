import BurgerIcon from "../burger-menu-aside/BurgerIcon";
import ShoppingCartBadge from "./ShoppingCartBadge";
import WishListIcon from "./WishListIcon";
import AccountOptions from "./AccountOptions";
import SearchBox from "./SearchIcon";
import { SetStateAction, useState } from "react";
import { useNavigate } from "react-router-dom";
import { User } from "@firebase/auth";
import React from "react";

type HeaderActionsProps = {
  setOpenCart: React.Dispatch<SetStateAction<boolean>>;
  setOpenBurger: React.Dispatch<SetStateAction<boolean>>;
  setOpenSearch: React.Dispatch<SetStateAction<boolean>>;
  isAuth: User | null;
};

const HeaderActions: React.FC<HeaderActionsProps> = ({
  setOpenCart,
  setOpenBurger,
  setOpenSearch,
  isAuth,
}) => {
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [isOpenAccountOptions, setIsOpenAccountOptions] = useState(false);
  const navigate = useNavigate();

  const handleMenuOpen = (event: React.MouseEvent<Element>) => {
    setAnchorEl(event.currentTarget as HTMLElement);
    setIsOpenAccountOptions(!isOpenAccountOptions);
  };

  const handleMenuClose = () => {
    setAnchorEl(null);
    setIsOpenAccountOptions(false);
  };

  const handleAuthOption = (option: string) => {
    if (option == "login") {
      navigate("/signin");
    } else if (option == "register") navigate("/signup");
    setIsOpenAccountOptions(false);
  };
  return (
    <div className="flex gap-4 absolute right-10">
      <SearchBox setOpenSearch={setOpenSearch} />
      <WishListIcon />
      <ShoppingCartBadge openCart={setOpenCart} />
      <BurgerIcon setBurger={setOpenBurger} />
      <AccountOptions
        setOpenAccount={handleMenuOpen}
        isOpenAccount={isOpenAccountOptions}
        closeMenu={handleMenuClose}
        anchor={anchorEl}
        handleAuthOption={handleAuthOption}
        isAuth={isAuth}
      />
    </div>
  );
};

export default HeaderActions;
