export const ROUTER_PATHS ={
  AUTH:{
    DEFAULT : 'auth',
    LOGIN : 'login',
  },
  PANEL:{
    DEFAULT: '/general/blank-page',
    USER: 'user',
    FORM: '/form-elements/basic-elements'
  }
}

export const INTERNAL_PATHS = {

  /***
   * AUTHENTICATION
   */

  AUTH_DEFAULT: `${ROUTER_PATHS.AUTH.DEFAULT}`,
  AUTH_LOGIN : `${ROUTER_PATHS.AUTH.LOGIN}`,



  /**
   * PANEL
   */

  PANEL_DEFAULT: `${ROUTER_PATHS.PANEL.DEFAULT}`,

  PANEL_USER_LIST: `${ROUTER_PATHS.PANEL.USER}`,


}

export const INTERNAL_ROUTES = {
      AUTH_LOGIN : `/${INTERNAL_PATHS.AUTH_DEFAULT}/${INTERNAL_PATHS.AUTH_LOGIN}`,
      PAGE_DEFAULT: `/${INTERNAL_PATHS.PANEL_DEFAULT}`,
      PANEL_USER_LIST: `/${INTERNAL_PATHS.PANEL_DEFAULT}/${INTERNAL_PATHS.PANEL_USER_LIST}`
}


