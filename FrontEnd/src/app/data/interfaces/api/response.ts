export interface Response {
  status: number;
  timestamp: string;
  aux: string | null;
  message: string | null;
  typemessage: string | null;
  data: any | null;
}
// error : boolean;
// msg: string;
// data: any;