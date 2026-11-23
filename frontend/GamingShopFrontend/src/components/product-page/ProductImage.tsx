import React from "react";

interface ProductImageProps {
  image: string;
  name: string;
}

const ProductImage: React.FC<ProductImageProps> = ({ image, name }) => {
  return (
    <div className="flex-1 flex justify-center items-center">
      <img
        src={image}
        alt={name}
        className="w-full max-w-sm rounded-lg shadow-lg"
      />
    </div>
  );
};

export default ProductImage;
