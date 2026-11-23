import { useEffect, useState } from "react";
import useProducts from "../../hooks/useProducts";
import { ProductType } from "../../types/Product";
import Heading from "../Headings/Heading";
import ProductCard from "./ProductCard";
import ProductsList from "./ProductsList";
import CategorySelect from "./CategorySelect";
import PriceSelect from "./PriceSelect";
import FilterSelect from "./FilterSelect";
import { useDispatch, useSelector } from "react-redux";
import {
  applyFilters,
  setCategoryFilter,
  setPriceFilter,
  setProducts,
} from "../../redux/slices/FilterProductsSlice";
import { RootState } from "../../redux/store";

const ProductsContainer = () => {
  const { isLoading, error, products } = useProducts();
  const dispatch = useDispatch();
  const { filteredProducts, selectedCategory, selectedPrice } = useSelector(
    (state: RootState) => state.filterProductsSlice,
  );
  const leagues = products
    ? Array.from(new Set(products.map((product) => product.league)))
    : [];

  useEffect(() => {
    if (products.length > 0) {
      dispatch(setProducts(products));
    }
  }, [products, dispatch]);

  useEffect(() => {
    dispatch(applyFilters());
  }, [selectedCategory, selectedPrice, dispatch]);

  const handleCategoryChange = (category: string) => {
    dispatch(setCategoryFilter(category));
  };

  const handlePriceChange = (price: string) => {
    dispatch(setPriceFilter(price));
  };

  return (
    <main className="w-[100vw] min-h-[50vh] flex flex-col gap-24 pt-12 bg-green-300">
      <Heading className="text-2xl text-red-800" level={2}>
        Nasze Produkty
      </Heading>
      <FilterSelect>
        <CategorySelect
          selectedCategory={selectedCategory}
          onChangeCategory={handleCategoryChange}
          leagues={leagues}
        />
        <PriceSelect
          selectedPrice={selectedPrice}
          onChangePrice={handlePriceChange}
        />
      </FilterSelect>
      <ProductsList
        products={filteredProducts}
        isLoading={isLoading}
        error={error}
        viewFn={(product: ProductType) => (
          <ProductCard key={product.id} data={product} />
        )}
      />
    </main>
  );
};

export default ProductsContainer;
