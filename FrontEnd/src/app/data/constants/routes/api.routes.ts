import { environment as ENV} from "environments/environment.prod";

export const API_ROUTES = {
  AUTH:{
    SIGNUP: `${ENV.uri}account/sign-up`,
    SIGNIN: `${ENV.uri}account/sign-in`,
    SENDRECOVERYLIKN: `${ENV.uri}account/send-recovery-link`
  },
  USER:{
    list: `${ENV.uri}user/list`
  }
}
