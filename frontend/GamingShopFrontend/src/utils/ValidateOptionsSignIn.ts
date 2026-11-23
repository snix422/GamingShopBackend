export const ValidateOptionsSignIn = {
  email: {
    required: "E-mail jest wymagany",
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
};
