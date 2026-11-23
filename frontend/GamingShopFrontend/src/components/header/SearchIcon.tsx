import SearchIcon from "@mui/icons-material/Search";
import React, { SetStateAction } from "react";

type SearchBoxProps = {
  setOpenSearch: React.Dispatch<SetStateAction<boolean>>;
};

const SearchBox: React.FC<SearchBoxProps> = ({ setOpenSearch }) => {
  return (
    <div className="max-lg:flex hidden">
      <SearchIcon
        data-testid="s-icon"
        onClick={() => setOpenSearch(true)}
        color="primary"
      />
    </div>
  );
};

export default SearchBox;
