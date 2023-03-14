enum Actions {
  // action types
  GET_COMPANY = "getCompany",

  ADD_BODY_CLASSNAME = "addBodyClassName",
  REMOVE_BODY_CLASSNAME = "removeBodyClassName",
  ADD_BODY_ATTRIBUTE = "addBodyAttribute",
  REMOVE_BODY_ATTRIBUTE = "removeBodyAttribute",
  ADD_CLASSNAME = "addClassName",
  VERIFY_AUTH = "verifyAuth",
  LOGIN = "login",
  LOGOUT = "logout",
  REGISTER = "register",
  UPDATE_USER = "updateUser",
  FORGOT_PASSWORD = "forgotPassword",
  SET_BREADCRUMB_ACTION = "setBreadcrumbAction",
  SET_THEME_MODE_ACTION = "setThemeModeAction",
  GET_SECTOR_LIST = "getsectorlist",
  GET_CONTRACTCODE_LIST = "getContractCodelist",
  GET_OFFERSUBJECTCODE_LIST = "getOfferSubjectCodelist",
  GET_CITY_LIST = "getCitylist",
  GET_DISTRICT_LIST = "getDistrictlist",
  GET_QUERTER_LIST = "getQuerterlist",
  ADD_CUSTOMER = "addCustomer",
  UPDATE_CUSTOMER = "updateCustomer",
  ADD_ADDRESS = "addAddress",
  UPDATE_ADDRESS = "updateAddress",
  DELETE_ADDRESS = "deleteAddress",
  GET_ADDRESSLISTBYCUSTOMERID = "getAddressListByCustomerId",
  GET_ADDRESSBYID = "getAddressById",
  GET_CUSTOMER = "getCustomer",
  GET_LASTTRADED_CUSTOMER = "getLastTradedCustomer",
  GET_CUSTOMER_BY_FILTER = "getCustomerByFilter",
  ADD_DEVICE = "addDevice",
  UPDATE_DEVICE = "updateDevice",
  GET_DEVICE_BY_FILTER = "getDeviceByFilter",
  GET_DEVICE_BY_ID = "getDeviceById",
  GET_DEVICE_BY_SERIALNO_FILTER = "getDeviceBySerialNoFilter",
  GET_DEVICE_BY_MODEL_NAME_FILTER = "getDeviceByModelNameFilter",
  GET_MAIN_PAGE_CUSTOMER = "getMainPageCustomer",

  GET_BOOTCODE_LIST = "getBootCodelist",
  GET_DETECTIONCODE_LIST = "getDetectionCodelist",
  GET_RESULTCODE_LIST = "getResultCodelist",

  GET_TECHNICIAN_LIST = "getTechnicianlist",

  ADD_DEVICESERVICE = "addDeviceService",
  GET_RECEIVEDDEVICESERVICE = "getReceivedDeviceService",
  GET_PARTSEXCHANGEDEVICESERVICELIST = "getPartsExchangeDeviceServiceList",
  GET_DEVICESERVICEWITHID = "getDeviceServiceWithId",
  GET_TECHNICIANASSINEDDEVICESERVICE = "getTechnicianAssignedDeviceService",
  GET_CLOSEDDEVICESERVICE = "getClosedDeviceService",
  GET_TOBEOFFEREDDEVICESERVICE = "getToBeOfferedDeviceService",
  GET_SENTOFFEREDDEVICESERVICE = "getSentOfferedDeviceService",
  UPDATE_ASSIGNTECHNICIANDEVICESERVICE = "updateAssignTechnicianDeviceService",
  UPDATE_RETURNDEVICESERVICETOTECHNICIAN = "updateReturnDeviceServiceTechnician",
  UPDATE_CLOSEDEVICESERVICE = "updateCloseDeviceService",
  UPDATE_TAKEDEVICESERVICEBACK = "updateTakeDeviceServiceBack",
  UPDATE_CANCELDEVICESERVICE = "updateCancelDeviceService",
  UPDATE_SENDDEVICESERVICETOCLOSE = "updateSendDeviceServiceToClose",
  DELETE_DELETEDEVICESERVICE = "deleteDeleteDeviceService",
  UPDATE_APPROVEDEVICESERVICEOFFER = "updateApproveDeviceServiceOffer",
  GET_TECHNICIANDEVICESERVICEREPORT = "getTechnicianDeviceServiceReport",

  ADD_DEVICESERVICEPART = "addDeviceServicePart",
  UPDATE_DEVICESERVICEPART = "updateDeviceServicePart",
  DELETE_DEVICESERVICEPART = "deleteDeviceServicePart",
  GET_DEVICESERVICEPARTLIST = "getDeviceServicePartList",
  GET_DEVICESERVICEPART = "getDeviceServicePart",

  GET_OFFERNOTSEND = "getOfferNotSend",
  GET_ORDERRECEIPT = "getOrderReceipt",
  ADD_OFFER = "addOffer",
  SEND_ORDERRECEIPT = "sendOrderReceipt",
  UPDATE_OFFER = "updateOffer",
  DELETE_OFFER = "deleteOffer",
  UPDATE_SENDOFFER = "updateSendOffer",
  UPDATE_SENDOFFERAGAIN = "updateSendOfferAgain",
  GET_OFFERREPORT = "getOfferReport",

  GET_DEVICETYPELIST = "getDeviceTypeList",
  GET_DEVICEBRANDLIST = "getDeviceBrandList",
  GET_DEVICEMODELLIST = "getDeviceModelList"
}

enum Mutations {
  // mutation types
  SET_CLASSNAME_BY_POSITION = "appendBreadcrumb",
  PURGE_AUTH = "logOut",
  SIGNOUT = "signout",
  SET_AUTH = "setAuth",
  SET_USER = "setUser",
  SET_PASSWORD = "setPassword",
  SET_ERROR = "setError",
  SET_BREADCRUMB_MUTATION = "setBreadcrumbMutation",
  SET_LAYOUT_CONFIG_PROPERTY = "setLayoutConfigProperty",
  RESET_LAYOUT_CONFIG = "resetLayoutConfig",
  OVERRIDE_LAYOUT_CONFIG = "overrideLayoutConfig",
  OVERRIDE_PAGE_LAYOUT_CONFIG = "overridePageLayoutConfig",
  SET_THEME_MODE_MUTATION = "setThemeModeMutation",
}

export { Actions, Mutations };
