import React from "react";

type ProductCardPlaceholderProps = {
  lines: number;
  height: number;
};

const ProductCardPlaceholder: React.FC<ProductCardPlaceholderProps> = ({
  lines,
  height,
}) => {
  return (
    <>
      {Array.from({ length: lines }).map((_, i) => (
        <div
          key={i}
          data-testid="placeholder-card-product"
          className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[20vw] max-xl:w-[40vw] max-sm:w-[80vw]"
          style={{ height: `${height}px` }}
        ></div>
      ))}
    </>
  );
};

export default ProductCardPlaceholder;
