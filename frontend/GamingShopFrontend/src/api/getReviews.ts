import { reviewSchemaArray } from "../components/schemas/reviewSchema";

import { api } from "../lib/axiosClient";

export const getReviewsByProduct = async (idProduct: number): Promise<any> => {
  const res = await api.get("/reviews", {
    params: {
      productId: idProduct,
    },
  });
  const parsed = reviewSchemaArray.safeParse(res.data);
  if (!parsed.success) {
    throw new Error("Invalid data structure from API");
  }
  return res.data;
};
