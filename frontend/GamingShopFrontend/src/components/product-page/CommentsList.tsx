import React from "react";
import ProductCardPlaceholder from "../placeholders/ProductCardPlaceholder";
import Heading from "../Headings/Heading";

interface CommentsListProps {
  loading: boolean;
  error: any;
  reviews: any[];
  viewFn: (d: any) => React.ReactNode;
}

const CommentsList: React.FC<CommentsListProps> = ({
  loading,
  error,
  reviews,
  viewFn,
}) => {
  if (error) {
    return (
      <div className="flex flex-col items-center">
        <Heading level={2} className="text-red text-2xl">
          {error}
        </Heading>
      </div>
    );
  }
  if (loading) {
    return (
      <div className="flex flex-col items-center">
        <ProductCardPlaceholder lines={4} height={200} />
      </div>
    );
  }
  return (
    <div className="flex flex-col gap-4">
      {reviews ? reviews.map((item: any) => viewFn(item)) : null}
    </div>
  );
};

export default CommentsList;
