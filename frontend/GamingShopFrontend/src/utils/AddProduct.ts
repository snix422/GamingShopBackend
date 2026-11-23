import { Dispatch } from "@reduxjs/toolkit";
import { addToCart } from "../redux/slices/CartSlice";
import { SizeArrayType } from "../types/Product";

export const addProductToCart = (
  product: any,
  selectedSize: SizeArrayType,
  dispatch: Dispatch,
) => {
  const newItemCart = {
    id: product.id,
    name: product.name,
    league: product.league,
    isRecommended: product.isRecommended,
    image: product.image,
    description: product.description,
    slug: product.slug,
    size: selectedSize.size,
    price: selectedSize.price,
  };

  dispatch(addToCart(newItemCart));
};
