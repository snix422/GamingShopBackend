import { ProductType } from "../../types/Product";
import ProductCardPlaceholder from "../placeholders/ProductCardPlaceholder";
import React from "react";

type BestsellersListProps = {
  bestsellers: ProductType[];
  isLoading: boolean;
  error: any;
  viewFn: (bestseller: ProductType) => React.ReactNode;
};

const BestsellersList: React.FC<BestsellersListProps> = ({
  bestsellers,
  isLoading,
  error,
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
      <div className="w-full flex flex-wrap justify-center gap-8">
        <ProductCardPlaceholder lines={6} height={500} />
      </div>
    );
  }
  return (
    <div className="flex flex-wrap justify-center mt-4">
      <div
        data-testid="bestsellers-list"
        className="flex justify-center gap-8 flex-wrap"
      >
        {bestsellers.map((b: ProductType) => viewFn(b))}
      </div>
    </div>
  );
};

export default BestsellersList;
