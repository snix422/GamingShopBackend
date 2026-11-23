import React from "react";

const Header = ({ children }: { children: React.ReactNode }) => {
  return (
    <header className="w-[100vw] flex justify-evenly items-center gap-24 relative py-4 border-b-2 border-gray-300 shadow-sm max-sm:py-8">
      {children}
    </header>
  );
};

export default Header;
