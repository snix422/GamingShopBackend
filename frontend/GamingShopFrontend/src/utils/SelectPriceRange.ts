import { ProductType } from "../types/Product";

export const selectPriceRange = (singleProduct: ProductType | []) => {
  if (!Array.isArray(singleProduct)) {
    const prices = singleProduct.size.map((s) => s.price);
    if (prices.length === 0) {
      return "Brak cen dostępnych";
    }
    const priceRange = `${Math.min(...prices)} - ${Math.max(...prices)} PLN`;
    return priceRange;
  } else {
    return "Produkt niedostępny";
  }
};
