import { useNavigate } from "react-router-dom";

const navigate = useNavigate();

export const searchProduct = (query: string) => {
  navigate(`/search?query=${encodeURIComponent(query)}`);
};
