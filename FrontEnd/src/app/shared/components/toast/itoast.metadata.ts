import { TOAST_TYPE } from "./toast.enum";

export interface IToast {
  id?: number;
  title: string;
  description: string;
  type?: TOAST_TYPE;
  isShow?:boolean;
  time?: number;
  userDefaultImage?:boolean;
  resourse?: string;
}