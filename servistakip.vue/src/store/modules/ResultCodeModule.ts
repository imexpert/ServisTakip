import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import utils from '@/core/plugins/Utils'

@Module
export default class ResultCodeModule extends VuexModule {

  @Action
  async [Actions.GET_RESULTCODE_LIST]() {
    return await ApiService.get("ResultCodes/GetResultCodeList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }
}
