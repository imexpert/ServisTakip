import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import utils from '@/core/plugins/Utils'

@Module
export default class DeviceServiceModule extends VuexModule {

  @Action
  [Actions.ADD_DEVICESERVICE](deviceService) {
    return ApiService.post("DeviceServices/AddDeviceService", deviceService)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_ASSIGNTECHNICIANDEVICESERVICE](deviceService) {
    console.log(deviceService);
    return ApiService.put("DeviceServices/AssignTechnicianDeviceService", deviceService)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_RETURNDEVICESERVICETOTECHNICIAN](deviceService) {
    console.log(deviceService);
    return ApiService.put("DeviceServices/ReturnDeviceServiceToTechnician", deviceService.value)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_CLOSEDEVICESERVICE](deviceService) {
    console.log(deviceService);
    return ApiService.put("DeviceServices/CloseDeviceServices", deviceService)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_SENDDEVICESERVICETOCLOSE](deviceService) {
    console.log(deviceService);
    return ApiService.put("DeviceServices/SendDeviceServiceToClose", deviceService.value)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.DELETE_DELETEDEVICESERVICE](id) {
    return ApiService.delete("DeviceServices/DeleteDeviceService?id=" + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_APPROVEDEVICESERVICEOFFER](deviceService) {
    console.log(deviceService);
    return ApiService.put("DeviceServices/ApproveDeviceServiceOffer", deviceService.value)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_CANCELDEVICESERVICE](deviceService) {
    console.log(deviceService);
    return ApiService.put("DeviceServices/CancelDeviceService", deviceService.value)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_TAKEDEVICESERVICEBACK](deviceService) {
    console.log(deviceService.value);
    return ApiService.put("DeviceServices/TakeDeviceServiceBack", deviceService.value)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_RECEIVEDDEVICESERVICE]() {
    return ApiService.get("DeviceServices/GetReceivedDeviceServicesList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_TOBEOFFEREDDEVICESERVICE]() {
    return ApiService.get("DeviceServices/GetToBeOfferedDeviceServicesList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_SENTOFFEREDDEVICESERVICE]() {
    return ApiService.get("DeviceServices/GetSentOfferedDeviceServicesList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_PARTSEXCHANGEDEVICESERVICELIST]() {
    return ApiService.get("DeviceServices/GetPartsExchangeDeviceServicesList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_DEVICESERVICEWITHID](id) {
    return ApiService.getWithParamUrl("DeviceServices/GetDeviceServiceWithId?id=" + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_CLOSEDDEVICESERVICE]() {
    return ApiService.get("DeviceServices/GetClosedDeviceServicesList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_TECHNICIANASSINEDDEVICESERVICE]() {
    return ApiService.get("DeviceServices/GetTechnicianAssignedDeviceServicesList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_TECHNICIANDEVICESERVICEREPORT](userId) {
    return ApiService.getWithParamUrl("DeviceServices/GetTechnicianDeviceServiceReport?userId=" + userId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }
}
