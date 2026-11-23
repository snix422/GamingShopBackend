import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { ProductType } from "../../types/Product";

interface favoritesListType {
  favoritesProducts: ProductType[];
}

const initialState: favoritesListType = {
  favoritesProducts: [],
};

const favoritesListSlice = createSlice({
  name: "favoritesList",
  initialState,
  reducers: {
    addFavoriteProduct: (state, action: PayloadAction<ProductType>) => {
      const newItem: ProductType = action.payload;
      const existItem = state.favoritesProducts.find(
        (p: ProductType) => p.id === newItem.id,
      );
      if (existItem) {
        return;
      }
      state.favoritesProducts.push(newItem);
    },
    removeFavoriteProduct: (state, action: PayloadAction<number>) => {
      const id = action.payload;
      const filteredFavoritesProduct = state.favoritesProducts.filter(
        (p: ProductType) => p.id !== id,
      );
      state.favoritesProducts = filteredFavoritesProduct;
    },
    removeAll: (state) => {
      state.favoritesProducts = [];
    },
  },
});

export const { addFavoriteProduct, removeFavoriteProduct, removeAll } =
  favoritesListSlice.actions;
export default favoritesListSlice.reducer;
