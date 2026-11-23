import React from "react";

interface AddToCartButtonProps {
  onAddToCart: () => void;
}

const AddToCartButton: React.FC<AddToCartButtonProps> = ({ onAddToCart }) => {
  return (
    <button
      className="w-[15vw] max-lg:w-[30vw] max-sm:w-[50vw]
        bg-green-500 text-white font-semibold py-3 px-6 
    rounded-lg transition duration-300 ease-in-out
    hover:bg-green-600 hover:shadow-lg active:scale-95
    focus:outline-none focus:ring-2 focus:ring-green-400
        "
      onClick={onAddToCart}
    >
      Dodaj do koszyka
    </button>
  );
};

export default AddToCartButton;
