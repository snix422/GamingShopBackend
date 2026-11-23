import toast from "react-hot-toast";
import { ReviewProduct } from "../types/ReviewProduct";
import apiClient from "./axiosConfig";
import { reviewSchema } from "../schemas/reviewSchema";

export const sendReviewProduct = async (
  review: ReviewProduct,
): Promise<void> => {
  const parsed = reviewSchema.safeParse(review);
  if (!parsed.success) {
    toast.error("Nieprawidłowy dane opinii");
    throw new Error("Nieprawidłowy dane opinii");
  }

  if (!review) {
    throw Error("Brak informacji o opinii");
  }
  await apiClient.post("/reviews", review);
};
