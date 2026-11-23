type SearchResultPlaceholderProps = {
  lines: number;
};

const SearchResultPlaceholder: React.FC<SearchResultPlaceholderProps> = ({
  lines,
}) => {
  return (
    <div className="w-[100vw] h-[100vh] flex flex-col items-center gap-4 max-md:flex-col">
      <div className="animate-pulse bg-gray-300 rounded-lg mb-2 w-[20vw] h-[5vh] max-md:w-[80vw]" />
      <div className="w-full flex justify-evenly max-sm:flex-col max-sm:items-center max-sm:justify-evenly max-sm:gap-8 flex-wrap">
        {Array.from({ length: lines }).map((__, i) => (
          <div
            key={i}
            className="animate-pulse bg-gray-300 rounded-lg w-[20vw] h-[50vh] max-md:w-[80vw] max-sm:h-[50vh] max-md:w-[30vw]"
          />
        ))}
      </div>
    </div>
  );
};

export default SearchResultPlaceholder;
