import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import utils from '@/core/plugins/Utils'

@Module
export default class DetectionCodeModule extends VuexModule {

  @Action
  async [Actions.GET_DETECTIONCODE_LIST]() {
    return await ApiService.get("DetectionCodes/GetDetectionCodeList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }
}
