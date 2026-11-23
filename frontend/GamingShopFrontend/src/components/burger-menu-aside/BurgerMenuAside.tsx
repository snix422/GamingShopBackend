import { Drawer } from "@mui/material";
import Heading from "../Headings/Heading";
import BurgerMenu from "./BurgerMenu";
import { SetStateAction } from "react";
import { User } from "@firebase/auth";
import CloseIcon from "@mui/icons-material/Close";
import React from "react";

type BurgerMenuAsideProps = {
  isOpen: boolean;
  setOpen: React.Dispatch<SetStateAction<boolean>>;
  auth: User | null;
};

const BurgerMenuAside: React.FC<BurgerMenuAsideProps> = ({
  isOpen,
  setOpen,
  auth,
}) => {
  return (
    <Drawer
      data-testid="drawer"
      open={isOpen}
      onClose={() => setOpen(false)}
      anchor="right"
      sx={{ width: "50vw" }}
      PaperProps={{
        sx: {
          width: {
            xs: "100vw",
            sm: "70vw",
            md: "50vw",
            lg: "40vw",
            xl: "30vw",
          },
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          zIndex: 10,
        },
      }}
    >
      <div className="w-[100%] flex flex-col items-center z-10 relative">
        <CloseIcon
          color="primary"
          className="absolute top-2 right-2"
          onClick={() => setOpen(false)}
        />
        <Heading level={1} className="text-3xl">
          Menu
        </Heading>
        <BurgerMenu user={auth} setOpen={setOpen} />
      </div>
    </Drawer>
  );
};

export default BurgerMenuAside;
