import { z } from "zod";

const sizeSchema = z.object({
  size: z.string(),
  price: z.number(),
});

export const productSchema = z.object({
  id: z.string().transform((val) => parseInt(val, 10)),
  name: z.string(),
  league: z.string(),
  size: z.array(sizeSchema),
  isRecommended: z.boolean(),
  image: z.string().url(),
  description: z.string(),
  relatedProducts: z.array(z.number()),
  slug: z.string(),
});

export const productsArraySchema = z.array(productSchema);
export const productArraySchema = z.tuple([productSchema]);
