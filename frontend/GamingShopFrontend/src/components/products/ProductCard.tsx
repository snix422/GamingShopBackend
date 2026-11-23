import Heading from "../Headings/Heading";
import { Link } from "react-router-dom";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import useWishList from "../../hooks/useWishList";
import { ProductType } from "../../types/Product";
import FavoriteIcon from "@mui/icons-material/Favorite";
import useAuth from "../../hooks/useAuth";
import React from "react";

type ProductCardProps = {
  data: ProductType;
};

const ProductCard: React.FC<ProductCardProps> = ({ data }) => {
  const { user } = useAuth();
  const { wishList, addToWishList, removeFromWishList } = useWishList(
    user?.uid,
  );
  const existFav = wishList.some((item: ProductType) => item.id === data.id);

  return (
    <div className="relative flex flex-col items-center w-[20vw] max-lg:w-[40vw] max-sm:w-[70vw] min-h-[30vh] max-h-[60vh] max-lg:max-h-[100vh] max-md:h-[50vh] bg-gray-200 rounded-md gap-2 pb-2">
      <img className="w-full h-[70%]" src={data.image} alt={data.name} />
      <Heading className="text-base font-bold" level={3}>
        {data.name}
      </Heading>
      <Link
        to={`/product/${data.slug}`}
        className="relative group inline-block"
      >
        <button
          className="px-6 py-2 font-semibold text-white !bg-blue-600 rounded-lg shadow-md transition-all duration-300 ease-in-out transform group-hover:bg-blue-700 group-hover:-translate-y-1 group-hover:shadow-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2"
          style={{ backgroundColor: "#1e40af" }}
        >
          Pokaż szczegóły
        </button>
      </Link>
      {existFav ? (
        <FavoriteIcon
          onClick={() => removeFromWishList(data.id)}
          fontSize="large"
          className="absolute top-2 right-2 transition-all duration-300 ease-in-out hover:cursor-pointer text-red-500"
        />
      ) : (
        <FavoriteBorderIcon
          onClick={() =>
            addToWishList({
              ...data,
              userId: user?.uid,
            })
          }
          fontSize="large"
          className="absolute top-2 right-2 transition-all duration-300 ease-in-out hover:cursor-pointer"
        />
      )}
    </div>
  );
};

export default ProductCard;
