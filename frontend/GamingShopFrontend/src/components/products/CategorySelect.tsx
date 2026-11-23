import { MenuItem, Select } from "@mui/material";
import React from "react";

type CategorySelectProps = {
  selectedCategory: string;
  onChangeCategory: (category: string) => void;
  leagues: string[];
};

const CategorySelect: React.FC<CategorySelectProps> = ({
  selectedCategory,
  onChangeCategory,
  leagues,
}) => {
  return (
    <Select
      value={selectedCategory}
      label="Sortuj po kategorii"
      onChange={(e) => onChangeCategory(e.target.value)}
      displayEmpty
      data-testid="select"
    >
      <MenuItem value="">
        <em>Sortuj po kategorii</em>
      </MenuItem>
      {leagues.map((l: string, index: number) => (
        <MenuItem key={index} value={l}>
          {l}
        </MenuItem>
      ))}
    </Select>
  );
};

export default CategorySelect;
