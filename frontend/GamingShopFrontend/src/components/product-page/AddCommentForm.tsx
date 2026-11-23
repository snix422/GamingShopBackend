import { FieldErrors, UseFormRegister } from "react-hook-form";
import { ReviewFormType } from "./CommentSection";
import { Alert } from "@mui/material";
import React from "react";

interface ValidationRule {
  required?: string;
  minLength?: {
    value: number;
    message: string;
  };
  maxLength?: {
    value: number;
    message: string;
  };
  pattern?: {
    value: RegExp;
    message: string;
  };
}

interface FormValidation {
  [key: string]: ValidationRule;
}

interface AddCommentFormProps {
  onSubmit: (e?: React.BaseSyntheticEvent) => void;
  register: UseFormRegister<ReviewFormType>;
  errors: FieldErrors<ReviewFormType>;
  addReviewLoading: boolean;
  addReviewError: Error | null;
  buttonText: string;
  formValidation: FormValidation;
}

const AddCommentForm: React.FC<AddCommentFormProps> = ({
  onSubmit,
  register,
  errors,
  addReviewError,
  addReviewLoading,
  buttonText,
  formValidation,
}) => {
  return (
    <form
      onSubmit={onSubmit}
      className="flex flex-col items-center gap-4 w-[100%]"
    >
      <input
        {...register("review", formValidation.review)}
        className="w-[30%] max-lg:w-[50%] max-sm:w-[80%] px-4 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent shadow-md"
        type="textarea"
        placeholder="Dodaj komentarz..."
      />
      {errors.review?.message ? (
        <Alert severity="error">{errors.review.message}</Alert>
      ) : null}
      <button
        type="submit"
        className="bg-blue-500 text-white font-semibold py-2 px-4 rounded-lg hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 shadow-lg transition duration-300 ease-in-out"
      >
        {buttonText}
      </button>
    </form>
  );
};

export default AddCommentForm;
