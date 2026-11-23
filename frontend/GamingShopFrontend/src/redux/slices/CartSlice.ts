import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { act } from "react";
import { Root } from "react-dom/client";
import { RootState } from "../store";
import { CartItemPayload, CartItemType } from "../../types/CartItem";
import { toast } from "react-hot-toast";

export type initialStateType = {
  items: CartItemType[];
};

const initialState: any = {
  items: [],
};

const cartSlice = createSlice({
  name: "cartSlice",
  initialState,
  reducers: {
    addToCart: (
      state,
      action: PayloadAction<CartItemPayload | CartItemType>,
    ) => {
      const cartItem = state.items.find(
        (item: CartItemType | CartItemPayload) =>
          item.id === action.payload.id && item.size == action.payload.size,
      );
      if (cartItem) {
        state.items = state.items.map((item: CartItemType) =>
          item.id == action.payload.id && item.size == action.payload.size
            ? { ...item, amount: cartItem.amount + 1 }
            : item,
        );
      } else {
        const newItem = { ...action.payload, amount: 1 };
        state.items.push(newItem);
      }
      toast.success("Produkt dodany do koszyka");
    },
    decreaseAmount: (state, action: PayloadAction<any>) => {
      const existItem = state.items.find(
        (item: any) =>
          item.id === action.payload.id && item.size == action.payload.size,
      );
      console.log(existItem, "remove");
      if (!existItem) {
        toast.error("Nie znaleziono produktu do usunięca");
        return;
      }
      if (existItem.amount <= 1) {
        state.items = state.items.filter(
          (item: any) =>
            !(
              item.id === action.payload.id && item.size === action.payload.size
            ),
        );
        toast("Produkt został usunięty!", {
          icon: "ℹ️",
        });
        return;
      }
      const newCart = state.items.map((item: any) =>
        item.id === existItem.id && item.size === existItem.size
          ? { ...item, amount: existItem.amount - 1 }
          : item,
      );
      state.items = newCart;
      toast("Ilość została zmniejszona!", {
        icon: "ℹ️",
      });
    },
    removeFromCart: (state, action: PayloadAction<any>) => {
      console.log(state.items);
      const newCart = state.items.filter(
        (item: any) =>
          !(item.id === action.payload.id && item.size === action.payload.size),
      );
      state.items = newCart;
      toast("Produkt został usunięty!", {
        icon: "ℹ️",
      });
    },
    clearCart: (state) => {
      ((state.items = []),
        toast("Koszyk został opróżniony!", {
          icon: "ℹ️",
        }));
    },
  },
});

export const { addToCart, decreaseAmount, removeFromCart, clearCart } =
  cartSlice.actions;

export const selectCartItems = (state: RootState) => state.cartSlice.items;
/*export const selectItemAmount = (state:RootState) => 
    state.cartSlice.items.reduce((accumulator:number,currentItem:CartItemType)=> accumulator + currentItem?.amount,0)*/
export const selectTotalPrice = (state: RootState) =>
  state.cartSlice.items.reduce(
    (accumulator: number, currentItem: CartItemType) =>
      accumulator + currentItem?.price * currentItem?.amount,
    0,
  );
export default cartSlice.reducer;
