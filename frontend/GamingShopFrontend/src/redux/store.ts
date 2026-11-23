import { configureStore } from "@reduxjs/toolkit";
import filterProducts from "./slices/FilterProductsSlice";
import favoritesList from "./slices/FavoritesListSlice";
import cart from "./slices/CartSlice";

export const store = configureStore({
  reducer: {
    filterProductsSlice: filterProducts,
    favoritesListSlice: favoritesList,
    cartSlice: cart,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
