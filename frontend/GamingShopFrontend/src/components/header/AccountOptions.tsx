import { Menu, MenuItem } from "@mui/material";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import React from "react";
import { User } from "@firebase/auth";
import { logout } from "../../libs/LogOut";

type AccountOptionsProps = {
  setOpenAccount: (event: React.MouseEvent<HTMLElement>) => void;
  isOpenAccount: boolean;
  closeMenu: () => void;
  anchor: null | HTMLElement;
  handleAuthOption: (option: string) => void;
  isAuth: User | null;
};

const AccountOptions: React.FC<AccountOptionsProps> = ({
  setOpenAccount,
  isOpenAccount,
  closeMenu,
  anchor,
  handleAuthOption,
  isAuth,
}) => {
  return (
    <div className="flex flex-col">
      <AccountCircleIcon
        data-testid="account-icon"
        onClick={(event) =>
          setOpenAccount(event as unknown as React.MouseEvent<HTMLElement>)
        }
        color="primary"
      />
      <Menu anchorEl={anchor} open={isOpenAccount} onClose={closeMenu}>
        {!isAuth
          ? [
              <MenuItem
                data-testid="login-option"
                key="login"
                onClick={() => handleAuthOption("login")}
              >
                Zaloguj się
              </MenuItem>,
              <MenuItem
                key="register"
                onClick={() => handleAuthOption("register")}
              >
                Rejestracja
              </MenuItem>,
            ]
          : [
              <MenuItem key="logout" onClick={() => logout()}>
                Wyloguj się
              </MenuItem>,
            ]}
      </Menu>
    </div>
  );
};

export default AccountOptions;
