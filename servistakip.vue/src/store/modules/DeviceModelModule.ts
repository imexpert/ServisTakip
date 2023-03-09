import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import utils from '@/core/plugins/Utils'

@Module
export default class BootCodeModule extends VuexModule {
  @Action
  async [Actions.GET_DEVICEMODELLIST](deviceBrandId) {
    return await ApiService.getWithParamUrl("DeviceModels/GetDeviceModelListWithBrandId?deviceBrandId=" + deviceBrandId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }
}
