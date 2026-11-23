import { ProductType } from "../../types/Product";
import ProductCardPlaceholder from "../placeholders/ProductCardPlaceholder";
import React from "react";

type WishListProps = {
  wishList: ProductType[];
  isLoading?: boolean;
  error?: any;
  viewFn: (product: ProductType) => React.ReactNode;
};

const WishList: React.FC<WishListProps> = ({
  isLoading,
  error,
  wishList,
  viewFn,
}) => {
  if (error)
    return (
      <p className="text-2xl text-red-500 underline">
        Wystąpił problem z pobraniem Bestsellerów. Przepraszamy za utrudnienia
      </p>
    );
  if (isLoading) {
    return (
      <div className="w-full flex justify-evenly">
        <ProductCardPlaceholder lines={3} height={100} />
      </div>
    );
  }
  return (
    <div className="flex flex-col w-[100vw] flex-wrap justify-center items-center gap-24">
      {wishList.map((b: ProductType) => viewFn(b))}
    </div>
  );
};

export default WishList;
