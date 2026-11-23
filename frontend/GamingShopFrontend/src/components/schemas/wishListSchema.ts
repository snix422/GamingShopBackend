import { z } from "zod";

export const wishListSchema = z.object({
  id: z.string(),
  name: z.string(),
  league: z.string(),
  size: z.array(
    z.object({
      size: z.string(),
      price: z.number(),
    }),
  ),
  isRecommended: z.boolean(),
  image: z.string(),
  description: z.string(),
  relatedProducts: z.array(z.number()),
  slug: z.string(),
  userId: z.string(),
});

export const wishListSchemaArray = z.array(wishListSchema);
