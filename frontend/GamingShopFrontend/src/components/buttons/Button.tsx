import React from "react";

type ButtonProps = {
  children: string;
  className: string;
};

const Button: React.FC<ButtonProps> = ({ children, className }) => {
  return <button className={className}>{children}</button>;
};

export default Button;
