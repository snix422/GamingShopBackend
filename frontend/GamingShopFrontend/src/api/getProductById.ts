import { AxiosResponse } from "axios";
import { ProductType } from "../types/Product";
import apiClient from "./axiosConfig";
import { productArraySchema } from "../schemas/productSchema";

export const getProductById = async (slug: string): Promise<ProductType> => {
  const res: AxiosResponse<ProductType> = await apiClient.get(`/products`, {
    params: { slug },
  });
  const parsed = productArraySchema.safeParse(res.data);
  if (!parsed.success) {
    throw new Error("Invalid data structure from API");
  }
  return parsed.data[0];
};
