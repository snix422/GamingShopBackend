import { useReviews } from "../../hooks/useReviews";
import CommentsList from "./CommentsList";
import CommentItem from "./CommentItem";
import Heading from "../Headings/Heading";
import AddCommentForm from "./AddCommentForm";
import { SubmitHandler, useForm } from "react-hook-form";
import { ReviewProduct } from "../../types/ReviewProduct";
import useAuth from "../../hooks/useAuth";
import useFetchUsers from "../../hooks/useFetchUsers";
import { useEffect, useState } from "react";
import React from "react";
import toast from "react-hot-toast";

interface CommentSectionProps {
  productId: number;
}

export interface ReviewFormType {
  review: string;
}

const CommentSection: React.FC<CommentSectionProps> = ({ productId }) => {
  const {
    isLoading,
    error,
    reviews,
    addReview,
    addReviewLoading,
    addReviewError,
  } = useReviews(productId);
  const { users } = useFetchUsers();
  const { user } = useAuth();
  const [optimisticReviews, setOptimisticReviews] = useState<any[]>(reviews);

  const formValidation = {
    review: {
      required: "Musisz wpisać treść aby dodać opinię",
      minLength: {
        value: 5,
        message: "Wymagane jest min. 5 znaków aby dodać opinię",
      },
    },
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm<ReviewFormType>();

  useEffect(() => {
    if (!isLoading) {
      setOptimisticReviews(reviews);
    }
  }, [isLoading, reviews]);

  let buttonText = "Dodaj komentarz";
  if (addReviewLoading) {
    buttonText = "Dodawanie...";
  } else if (addReviewError) {
    buttonText = "Spróbuj ponownie";
  }

  const onSubmit: SubmitHandler<ReviewFormType> = (
    formData: ReviewFormType,
  ) => {
    if (!user) {
      toast.error("Nie można dodać komentarza, nie znamy autora");
      return;
    }
    const newReview: ReviewProduct = {
      author: user.email,
      review: formData.review,
      productId: Number(productId),
    };
    setOptimisticReviews((prev: ReviewProduct[]) => [...prev, newReview]);
    addReview(newReview, {
      onSuccess: () => {
        reset();
      },
      onError: () => {
        setOptimisticReviews((prev: ReviewProduct[]) =>
          prev.filter((p) => p !== newReview),
        );
      },
    });
  };

  return (
    <div className="flex flex-col items-center w-[100%] gap-4">
      <Heading level={1} className="text-2xl">
        Opinie
      </Heading>
      {user ? (
        <AddCommentForm
          onSubmit={handleSubmit(onSubmit)}
          register={register}
          errors={errors}
          addReviewLoading={addReviewLoading}
          addReviewError={addReviewError}
          buttonText={buttonText}
          formValidation={formValidation}
        />
      ) : (
        <Heading level={2} className="text-xl underline">
          Aby dodać opinię musisz być zalogowany
        </Heading>
      )}

      <CommentsList
        loading={isLoading}
        error={error}
        reviews={optimisticReviews}
        viewFn={(d: any) => <CommentItem key={d.id} data={d} />}
      />
    </div>
  );
};

export default CommentSection;
