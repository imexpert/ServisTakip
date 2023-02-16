import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";

@Module
export default class DeviceServiceModule extends VuexModule {

  @Action
  [Actions.ADD_DEVICESERVICE](deviceService) {
    return ApiService.post("DeviceServices/AddDeviceService", deviceService)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
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
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.DELETE_DELETEDEVICESERVICE](id) {
    return ApiService.delete("DeviceServices/DeleteDeviceService?id="+ id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
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
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
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
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_RECEIVEDDEVICESERVICE]() {
    return ApiService.get("DeviceServices/GetReceivedDeviceServicesList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_TECHNICIANASSINEDDEVICESERVICE]() {
    return ApiService.get("DeviceServices/GetTechnicianAssignedDeviceServicesList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }
}
