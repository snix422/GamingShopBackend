import { SignUpType } from "../types/SignUpFormType";

export const validateOptionsSignUp = {
  email: {
    required: "Email jest wymagany",
    pattern: {
      value: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i,
      message: "Zły format e-maila",
    },
  },
  password: {
    required: "Hasło jest wymagane",
    minLength: {
      value: 8,
      message: "Hasło musi posiadać min. 8 znaków",
    },
  },
  confirmPassword: {
    required: "Pole potwierdź hasło jest wymagane",
    validate: (value: string, formValues: SignUpType) =>
      value === formValues.password || "Hasła nie są takie same",
  },
  phone: {
    required: "Telefon jest wymagany",
    pattern: {
      value: /^[0-9]{9,15}$/,
      message: "Telefon musi posiadać tylko cyfry",
    },
  },
  name: {
    required: "Imię jest wymagane",
    minLength: {
      value: 2,
      message: "Imię musi posiadać min. 2 znaków",
    },
  },
  surname: {
    required: "Nazwisko jest wymagane",
    minLength: {
      value: 2,
      message: "Nazwisko musi posiadać min. 2 znaków",
    },
  },
};
