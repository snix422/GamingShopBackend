import { signOut } from "firebase/auth";
import { toast } from "react-hot-toast";
import { auth } from "../firebase/firebase";

export const logout = async () => {
  const toastId = toast.loading("Wylogowywanie...");
  try {
    await signOut(auth);
    toast.success("Pomyślnie wylogowano", { id: toastId });
  } catch (error) {
    toast.error("Wystąpił problem podczas wylogowywania", { id: toastId });
  }
};
