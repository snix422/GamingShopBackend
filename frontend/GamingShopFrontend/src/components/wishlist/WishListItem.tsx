import { Link } from "react-router-dom";
import DeleteIcon from "@mui/icons-material/Delete";
import { ProductType } from "../../types/Product";
import React from "react";

type WishListItemProps = {
  data: ProductType;
  removeItem: (id: number) => void;
};

const WishListItem: React.FC<WishListItemProps> = ({ data, removeItem }) => {
  return (
    <div className="flex items-center justify-between w-[60vw] max-md:w-[100vw] bg-white shadow-md rounded-lg p-4 hover:shadow-lg transition-shadow duration-300">
      {/* Obrazek Produktu */}
      <img
        className="w-[15%] h-auto object-cover rounded-lg transition-transform duration-300 hover:scale-105"
        src={data.image}
        alt={data.name}
      />
      {/* Nazwa Produktu i Link */}
      <div className="flex flex-col flex-grow px-4">
        <span className="text-lg font-semibold underline text-gray-800">
          {data.name}
        </span>
        <Link
          to={`/product/${data.slug}`}
          className="text-sm text-blue-500 hover:text-blue-700 transition-colors"
        >
          Zobacz więcej
        </Link>
      </div>
      {/* Ikona usuwania */}
      <DeleteIcon
        data-testid="btn-delete"
        className="text-red-500 cursor-pointer hover:text-red-700 transition-colors duration-300"
        onClick={() => removeItem(data.id)}
      />
    </div>
  );
};

export default WishListItem;
