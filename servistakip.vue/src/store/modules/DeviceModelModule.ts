import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import { showError } from "@/core/plugins/Utils";

@Module
export default class BootCodeModule extends VuexModule {
  @Action
  async [Actions.GET_DEVICEMODELBYBRANDIDLIST](deviceBrandId) {
    return await ApiService.getWithParamUrl("DeviceModels/GetDeviceModelListWithBrandId?deviceBrandId=" + deviceBrandId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  async [Actions.GET_DEVICEMODELLIST]() {
    return await ApiService.getWithParamUrl("DeviceModels/GetDeviceModelList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_MODEL_BY_NAME_FILTER](filter) {
    return ApiService.getWithParamUrl("DeviceModels/GetModelNameByFilter?filter=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}
