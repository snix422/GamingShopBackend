import { ProductType, SizeArrayType } from "../types/Product";

export const selectSizePrice = (
  product: ProductType,
  selectedSize: SizeArrayType | null,
) => {
  if (!selectedSize) {
    return undefined;
  }
  const sizeEntry = product.size.find((s) => s.size === selectedSize.size);
  return sizeEntry?.price;
};
