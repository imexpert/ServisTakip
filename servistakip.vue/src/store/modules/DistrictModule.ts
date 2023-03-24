import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import { showError } from "@/core/plugins/Utils";

@Module
export default class DistrictModule extends VuexModule {

  @Action
  async [Actions.GET_DISTRICT_LIST](cityId) {
    return await ApiService.getWithParamUrl("Districts/GetDistrictList?cityId=" + cityId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}
