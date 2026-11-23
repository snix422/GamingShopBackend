import React from "react";
import { render, RenderOptions } from "@testing-library/react";
import { Provider } from "react-redux";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { configureStore } from "@reduxjs/toolkit";
import filterProducts from "../redux/slices/FilterProductsSlice";
import favoritesList from "../redux/slices/FavoritesListSlice";
import cart from "../redux/slices/CartSlice";
import { BrowserRouter as Router } from "react-router-dom";

const queryClient = new QueryClient();
const store = configureStore({
  reducer: {
    filterProductsSlice: filterProducts,
    favoritesListSlice: favoritesList,
    cartSlice: cart,
  },
});

const AllProviders = ({ children }: { children: React.ReactNode }) => {
  return (
    <Provider store={store}>
      <QueryClientProvider client={queryClient}>
        <Router>{children}</Router>
      </QueryClientProvider>
    </Provider>
  );
};

const customRender = (ui: React.ReactElement, options?: RenderOptions) =>
  render(ui, { wrapper: AllProviders, ...options });

export * from "@testing-library/react";
export { customRender as render };
