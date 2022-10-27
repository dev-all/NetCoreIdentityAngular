import { environment as ENV} from "environments/environment.prod";

export const API_ROUTES = {
  AUTH:{
    SIGNUP: `${ENV.uri}account/sign-up`,
    SIGNIN: `${ENV.uri}account/sign-in`,
<<<<<<< HEAD
    SENDRECOVERYLIKN: `${ENV.uri}account/send-recovery-link`    
=======
    SENDRECOVERYLIKN: `${ENV.uri}account/send-recovery-link`
>>>>>>> 6c16ad5145eb1972915eb1cc686f6f5b4cfc8da8
  },
  USER:{
    list: `${ENV.uri}user/list`
  }
}
