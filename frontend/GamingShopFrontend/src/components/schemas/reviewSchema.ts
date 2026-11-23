import { z } from "zod";

export const reviewSchema = z.object({
  id: z.string().optional(),
  author: z.string().nullable(),
  review: z.string(),
  productId: z.number(),
});

export const reviewSchemaArray = z.array(reviewSchema);
