import { ProductType, SizeArrayType } from "../../types/Product";
import Heading from "../Headings/Heading";
import ProductPagePlaceholder from "../placeholders/ProductPagePlaceholder";
import AddToCartButton from "./AddToCartButton";
import CommentSection from "./CommentSection";
import ProductImage from "./ProductImage";
import ProductInfo from "./ProductInfo";
import SizeSelector from "./SizeSelector";
import React from "react";

interface ProductDetailsProps {
  product: ProductType | null;
  selectedSize: SizeArrayType | null;
  onSizeSelect: (size: SizeArrayType) => void;
  onAddToCart: () => void;
  errorSize: string | null;
  priceRange: string | null;
  selectedPrice: number | undefined;
  isLoading: boolean;
  error: any;
  slug: string | undefined;
}

const ProductDetails: React.FC<ProductDetailsProps> = ({
  product,
  selectedSize,
  onSizeSelect,
  onAddToCart,
  errorSize,
  priceRange,
  selectedPrice,
  slug,
  isLoading,
  error,
}) => {
  if (isLoading) {
    return <ProductPagePlaceholder lines={5} height={100} />;
  }

  if (!slug) {
    return <h2>Problem z wczytaniem strony produktu</h2>;
  }

  if (!product) {
    return <h2>Nie znaleziono produktu</h2>;
  }

  if (error) {
    return (
      <main className="w-[100vw] h-[100vh] flex justify-center items-center">
        <Heading level={2} className="text-2xl font-bold text-red-800">
          Wystąpił problem z wczytaniem produktu. Przepraszamy za utrudnienia
        </Heading>
      </main>
    );
  }

  return (
    <main className="w-[100vw] min-h-[100vh] flex flex-col items-center gap-12 lg:pt-8 xl:pt-12 2xl:pt-24  ">
      <div className="w-full flex max-lg:flex-col max-lg:pt-12 max-lg:items-center max-lg:gap-8 justify-evenly items-center">
        <ProductImage image={product.image} name={product?.name} />
        <div className="flex-1 flex flex-col max-lg:items-center">
          <ProductInfo product={product} />
          <SizeSelector
            sizes={product.size}
            selectedSize={selectedSize}
            onSizeSelect={onSizeSelect}
            errorSize={errorSize}
            priceRange={priceRange ?? "Brak widełek dla produktu"}
            price={selectedPrice ?? 0}
          />
          <AddToCartButton onAddToCart={onAddToCart} />
        </div>
      </div>
      <CommentSection productId={product.id} />
    </main>
  );
};

export default ProductDetails;
