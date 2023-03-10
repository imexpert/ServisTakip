import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import { showError } from "@/core/plugins/Utils";

@Module
export default class OfferSubjectModule extends VuexModule {

  @Action
  async [Actions.GET_OFFERSUBJECTCODE_LIST]() {
    return await ApiService.get("OfferSubjectCodes/GetOfferSubjectCodeList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}
