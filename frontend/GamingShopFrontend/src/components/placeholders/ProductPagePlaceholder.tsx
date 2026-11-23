type ProductCardPlaceholderProps = {
  lines?: number;
  height?: number;
};

const ProductPagePlaceholder: React.FC<ProductCardPlaceholderProps> = ({
  lines,
  height,
}) => {
  return (
    <div
      data-testid="product-page-placeholder"
      className="w-[100vw] h-[100vh] flex justify-evenly items-center max-md:flex-col"
    >
      <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[20vw] h-[50vh] max-md:w-[80vw]" />
      <div className="flex flex-col max-md:items-center gap-4">
        <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[40vw] h-[10vh] max-md:w-[80vw]" />
        <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[40vw] h-[5vh] max-md:w-[50vw]" />
        <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[20vw] h-[5vh] max-md:w-[50vw]" />
        <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[40vw] h-[10vh] max-md:w-[80vw]" />
        <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[40vw] h-[10vh] max-md:w-[50vw]" />
        <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[5vw] h-[5vh] max-md:w-[80vw]" />
        <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[40vw] h-[5vh] max-md:w-[50vw]" />
      </div>
    </div>
  );
};

export default ProductPagePlaceholder;
