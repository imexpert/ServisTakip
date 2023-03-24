import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { showError } from "@/core/plugins/Utils";

@Module
export default class DeviceModule extends VuexModule {

  @Action
  [Actions.ADD_DEVICE](device) {
    return ApiService.post("Devices/AddDevice", device)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.UPDATE_DEVICE](device) {
    return ApiService.put("Devices/UpdateDevice", device)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_ID](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceById?deviceId=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceWithQuery?deviceId=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_SERIALNO_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceBySerialNoFilter?filter=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_MODEL_NAME_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceByModelNameFilter?filter=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}

