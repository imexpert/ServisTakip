import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import utils from '@/core/plugins/Utils'

@Module
export default class QuerterModule extends VuexModule {

  @Action
  async [Actions.GET_QUERTER_LIST](districtId) {
    return await ApiService.getWithParamUrl("Querters/GetQuerterList?districtId=" + districtId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }
}
