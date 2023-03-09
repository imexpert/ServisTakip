import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";

@Module
export default class DeviceBrandModule extends VuexModule {
  @Action
  async [Actions.GET_DEVICEBRANDLIST](deviceTypeId) {
    return await ApiService.getWithParamUrl("DeviceBrands/GetDeviceBrandListByTypeId?deviceTypeId=" + deviceTypeId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }
}
