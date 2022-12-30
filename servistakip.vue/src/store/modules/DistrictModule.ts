import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";

@Module
export default class DistrictModule extends VuexModule {

  @Action
  async [Actions.GET_DISTRICT_LIST](cityId) {
    return await ApiService.getWithParamUrl("Districts/GetDistrictList?cityId=" + cityId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
      });
  }
}
