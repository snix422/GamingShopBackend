import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import Badge from "@mui/material/Badge";
import { Link } from "react-router-dom";
import useWishList from "../../hooks/useWishList";
import React from "react";

const WishListIcon = () => {
  const { wishList } = useWishList();
  return (
    <Badge data-testid="badge" badgeContent={wishList.length} color="primary">
      <Link to="/wishlist">
        <FavoriteBorderIcon data-testid="favorite-icon" color="primary" />
      </Link>
    </Badge>
  );
};

export default WishListIcon;
