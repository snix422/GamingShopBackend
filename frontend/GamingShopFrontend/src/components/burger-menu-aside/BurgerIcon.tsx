import MenuIcon from "@mui/icons-material/Menu";
import { SetStateAction } from "react";
import React from "react";

type BurgerIconProps = {
  setBurger: React.Dispatch<SetStateAction<boolean>>;
};

const BurgerIcon: React.FC<BurgerIconProps> = ({ setBurger }) => {
  return (
    <div className="max-lg:flex hidden">
      <MenuIcon
        data-testid="burger-icon"
        color="primary"
        onClick={() => setBurger(true)}
      />
    </div>
  );
};

export default BurgerIcon;
