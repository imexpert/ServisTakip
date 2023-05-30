import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";

@Module
export default class DeviceServicePartModule extends VuexModule {

  @Action
  [Actions.ADD_DEVICESERVICEPART](deviceServicePart) {
    console.log(deviceServicePart);
    return ApiService.post("DeviceServiceParts/CreateDeviceServicePart", deviceServicePart)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.UPDATE_DEVICESERVICEPART](deviceServicePart) {
    return ApiService.put("DeviceServiceParts/UpdateDeviceServicePart", deviceServicePart)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.DELETE_DEVICESERVICEPART](id) {
    return ApiService.delete("DeviceServiceParts/DeleteDeviceServicePart?id=" + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_DEVICESERVICEPARTLIST](deviceServiceId) {
    return ApiService.getWithParamUrl("DeviceServiceParts/GetDeviceServicePartList?deviceServiceId=" + deviceServiceId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_DEVICESERVICEPART](id) {
    return ApiService.getWithParamUrl("DeviceServiceParts/GetDeviceServicePart?id=" + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }
}
