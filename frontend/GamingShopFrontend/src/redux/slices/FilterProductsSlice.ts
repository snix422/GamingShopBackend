import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { ProductType } from "../../types/Product";

interface ProductsState {
  products: ProductType[];
  filteredProducts: ProductType[];
  selectedCategory: string;
  selectedPrice: string;
}

const initialState: ProductsState = {
  products: [],
  filteredProducts: [],
  selectedCategory: "",
  selectedPrice: "",
};

const filterProductsSlice = createSlice({
  name: "filterProducts",
  initialState,
  reducers: {
    setProducts: (state, action: PayloadAction<ProductType[]>) => {
      state.products = action.payload;
      state.filteredProducts = action.payload;
    },
    setCategoryFilter: (state, action: PayloadAction<string>) => {
      state.selectedCategory = action.payload;
    },
    setPriceFilter: (state, action: PayloadAction<string>) => {
      state.selectedPrice = action.payload;
    },
    applyFilters: (state) => {
      state.filteredProducts = state.products
        .filter((product) =>
          state.selectedCategory
            ? product.league === state.selectedCategory
            : true,
        )
        .sort((a, b) => {
          const priceA = Math.min(...a.size.map((s) => s.price));
          const priceB = Math.min(...b.size.map((s) => s.price));

          if (state.selectedPrice === "asc") {
            return priceA - priceB;
          } else {
            return priceB - priceA;
          }
        });
    },
  },
});

export const { setProducts, setCategoryFilter, setPriceFilter, applyFilters } =
  filterProductsSlice.actions;
export default filterProductsSlice.reducer;
