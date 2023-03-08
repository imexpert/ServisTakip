import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";

@Module
export default class BootCodeModule extends VuexModule {

  async [Actions.GET_DEVICEMODELLIST](deviceBrandId) {
    return await ApiService.getWithParamUrl("DeviceModels/GetDeviceModelListWithBrandId?deviceBrandId=" + deviceBrandId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }
}
