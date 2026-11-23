import { Link } from "react-router-dom";
import React from "react";

const Logo = () => {
  return (
    <Link
      data-testid="link"
      className="absolute left-10 max-sm:left-4 max-sm:text-base text-2xl text-black"
      to="/"
    >
      <span>Logo</span>
    </Link>
  );
};

export default Logo;
