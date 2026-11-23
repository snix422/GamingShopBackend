import { AxiosResponse } from "axios";
import { ProductType } from "../types/Product";
import apiClient from "./axiosConfig";
import { productsArraySchema } from "../schemas/productSchema";

export const getProductsByQuery = async (
  query: string,
  signal: AbortSignal,
): Promise<ProductType[]> => {
  const res: AxiosResponse<ProductType[]> = await apiClient.get("/products", {
    signal,
  });
  const parsed = productsArraySchema.safeParse(res.data);
  if (!parsed.success) {
    throw new Error("Invalid data structure from API");
  }
  const filteredResults = res.data.filter((r: ProductType) =>
    r.name.toLowerCase().includes(query.toLowerCase()),
  );
  return filteredResults;
};
