export type ProductType = {
  id: number;
  name: string;
  league: string;
  size: SizeArrayType[];
  isRecommended: boolean;
  image: string;
  description: string;
  relatedProducts: number[];
  slug: string;
};

export type SizeArrayType = {
  size: string;
  price: number;
};
