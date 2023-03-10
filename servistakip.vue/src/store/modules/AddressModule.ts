import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import { showError } from "@/core/plugins/Utils";


@Module
export default class AddressModule extends VuexModule {

  @Action
  [Actions.ADD_ADDRESS](addressData) {
    return ApiService.post("Addresses/CreateAddress", addressData)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_ADDRESSLISTBYCUSTOMERID](customerId) {
    return ApiService.getWithParamUrl("Addresses/GetAddressListByCustomerId?customerId=" + customerId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}
