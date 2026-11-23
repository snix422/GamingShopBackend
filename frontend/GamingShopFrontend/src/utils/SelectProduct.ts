import { ProductType } from "../types/Product";

export const selectProduct = (product: ProductType[]) => {
  const singleProduct = product.length == 1 ? product[0] : [];
  return singleProduct;
};
