import { SizeArrayType } from "../../types/Product";
import React from "react";

interface SizeSelectorProps {
  sizes: SizeArrayType[];
  selectedSize: SizeArrayType | null;
  onSizeSelect: (size: SizeArrayType) => void;
  errorSize: string | null;
  priceRange: string;
  price: number;
}

const SizeSeletor: React.FC<SizeSelectorProps> = ({
  sizes,
  onSizeSelect,
  errorSize,
  selectedSize,
  priceRange,
  price,
}) => {
  return (
    <div className="flex flex-col max-lg:items-center gap-4 mb-6">
      <h3 className="text-lg md:text-xl font-semibold mb-2">
        Wybierz rozmiar:
      </h3>
      <div className="flex gap-2">
        {sizes.map((s) => (
          <button
            key={s.size}
            onClick={() => onSizeSelect({ size: s.size, price: s.price })}
            className={`px-4 py-2 border rounded-lg ${
              selectedSize?.size === s.size
                ? "bg-blue-400 text-gray-800 border-gray-300"
                : "bg-white text-gray-800 border-gray-300"
            }`}
          >
            {s.size}
          </button>
        ))}
      </div>
      <div className="text-xl font-semibold mb-4">
        Cena:{" "}
        {selectedSize ? `${price} PLN` : `Przedział cenowy: ${priceRange}`}
      </div>
      {errorSize && <p className="text-red-300 font-bold">{errorSize}</p>}
    </div>
  );
};

export default SizeSeletor;
