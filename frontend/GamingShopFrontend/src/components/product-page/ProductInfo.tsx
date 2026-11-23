import { ProductType } from "../../types/Product";
import React from "react";

interface ProductInfoProps {
  product: ProductType;
}

const ProductInfo: React.FC<ProductInfoProps> = ({ product }) => {
  return (
    <div className="flex flex-col max-lg:items-center gap-4">
      <h1 className="text-2xl md:text-3xl font-bold mb-4 max-sm:w-4/5">
        {product.name}
      </h1>
      <div className="flex max-lg:flex-col gap-2 items-center">
        <span className="w-[15vw] max-lg:w-[30vw] max-sm:w-[50vw] px-3 py-1 bg-gray-200 text-center rounded-md font-semibold">
          {product.league}
        </span>
        {product.isRecommended && (
          <span className="w-[15vw] max-lg:w-[30vw] max-sm:w-[50vw] px-3 py-1 bg-blue-400 text-white text-center text-red rounded-md font-semibold">
            Polecany produkt
          </span>
        )}
      </div>
      <p className="mb-6 text-gray-700 max-lg:text-base text-xl max-sm:w-4/5">
        {product.description}
      </p>
    </div>
  );
};

export default ProductInfo;
