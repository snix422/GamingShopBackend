import React from "react";

type FilterSelectProps = {
  children: React.ReactNode;
};

const FilterSelect: React.FC<FilterSelectProps> = ({ children }) => {
  return (
    <div className="flex justify-center gap-4 w-[100vw] pb-4 pt-4">
      {children}
    </div>
  );
};

export default FilterSelect;
