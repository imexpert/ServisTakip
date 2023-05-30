import ApiService from "@/core/services/ApiService";
import { Actions } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import { showError } from "@/core/plugins/Utils";

@Module
export default class ContractCodeModule extends VuexModule {

  @Action
  async [Actions.GET_CONTRACTCODE_LIST]() {
    return await ApiService.get("ContractCodes/GetContractCodeList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}
