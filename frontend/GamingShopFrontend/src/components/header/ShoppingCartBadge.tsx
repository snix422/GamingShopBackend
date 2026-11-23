import ShoppingCart from "@mui/icons-material/ShoppingCart";
import { Badge } from "@mui/material";
import { useAppSelector } from "../../hooks/rtk";
import { selectCartItems } from "../../redux/slices/CartSlice";
import { SetStateAction } from "react";
import React from "react";

type ShoppingCartBadgeProps = {
  openCart: React.Dispatch<SetStateAction<boolean>>;
};

const ShoppingCartBadge: React.FC<ShoppingCartBadgeProps> = ({ openCart }) => {
  const cartItems = useAppSelector(selectCartItems);
  return (
    <Badge
      data-testid="badge"
      badgeContent={cartItems.length}
      color="secondary"
    >
      <ShoppingCart
        data-testid="shoppingcart-icon"
        color="primary"
        onClick={() => openCart(true)}
      />
    </Badge>
  );
};

export default ShoppingCartBadge;
