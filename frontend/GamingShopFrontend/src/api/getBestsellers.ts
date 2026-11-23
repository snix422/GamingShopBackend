import { AxiosResponse } from "axios";
import { ProductType } from "../types/Product";
import apiClient from "./axiosConfig";
import { productsArraySchema } from "../schemas/productSchema";

export const getBestsellers = async (): Promise<ProductType[]> => {
  const res: AxiosResponse<ProductType[]> = await apiClient.get("/products", {
    params: {
      isRecommended: true,
    },
  });
  const parsed = productsArraySchema.safeParse(res.data);
  if (!parsed.success) {
    console.error(parsed.error);
    throw new Error("Invalid data structure from API");
  }
  return res.data;
};
