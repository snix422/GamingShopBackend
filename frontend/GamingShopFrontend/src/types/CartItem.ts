export type CartItemPayload = {
  id: number;
  name: string;
  league: string;
  isRecommended: boolean;
  image: string;
  description: string;
  slug: string;
  size: string;
  price: number;
};

export interface CartItemType extends CartItemPayload {
  amount: number;
}
