import { MenuItem, Select } from "@mui/material";
import React from "react";

type PriceSelectProps = {
  selectedPrice: string;
  onChangePrice: (price: string) => void;
};

const PriceSelect: React.FC<PriceSelectProps> = ({
  selectedPrice,
  onChangePrice,
}) => {
  return (
    <>
      <Select
        value={selectedPrice}
        onChange={(e) => onChangePrice(e.target.value)}
        displayEmpty
        data-testid="price-select"
      >
        <MenuItem value="">
          <em>Sortuj cenę</em>
        </MenuItem>
        <MenuItem data-testid="desc" value="desc">
          Malejąco
        </MenuItem>
        <MenuItem data-testid="asc" value="asc">
          Rosnąco
        </MenuItem>
      </Select>
    </>
  );
};

export default PriceSelect;
