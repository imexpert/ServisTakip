import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";

@Module
export default class QuerterModule extends VuexModule {

  @Action
  async [Actions.GET_QUERTER_LIST](districtId) {
    return await ApiService.getWithParamUrl("Querters/GetQuerterList?districtId=" + districtId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
      });
  }
}
