import { environment as ENV } from 'environments/environment.prod';

export const API_ROUTES = {
  AUTH: {
    SIGNUP: `${ENV.uri}auth/sign-up`,
    SIGNIN: `${ENV.uri}auth/sign-in`,
    SENDRECOVERYLIKN: `${ENV.uri}auth/send-recovery-link`,
  },
  USER: {
    list: `${ENV.uri}user/list`,
  },
};
