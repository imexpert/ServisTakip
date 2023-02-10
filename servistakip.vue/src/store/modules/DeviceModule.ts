import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";

@Module
export default class DeviceModule extends VuexModule {

  @Action
  [Actions.GET_DEVICE_BY_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceWithQuery?deviceId=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_SERIALNO_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceBySerialNoFilter?filter=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_MODEL_NAME_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceByModelNameFilter?filter=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }
}
