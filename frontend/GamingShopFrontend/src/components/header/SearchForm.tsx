import { IconButton, InputBase, Paper, useMediaQuery } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import { useHandleSearchChange } from "../../hooks/useHandleSearchChange";
import React from "react";

const SearchForm = () => {
  const isLargeScreen = useMediaQuery("(min-width:1024px)");
  const { handleInputChange } = useHandleSearchChange();

  return (
    isLargeScreen && (
      <Paper
        component="form"
        sx={{
          p: "2px 4px",
          display: "flex",
          alignItems: "center",
          width: 400,
          height: "80%",
        }}
      >
        <InputBase
          sx={{ ml: 1, flex: 1 }}
          placeholder="Wyszukaj produkt"
          onChange={handleInputChange}
          data-testid="search-input"
        />
        <IconButton type="button" sx={{ p: "10px" }} aria-label="search">
          <SearchIcon data-testid="search-icon" />
        </IconButton>
      </Paper>
    )
  );
};

export default SearchForm;
