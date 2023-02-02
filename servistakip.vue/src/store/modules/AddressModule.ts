import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";

@Module
export default class AddressModule extends VuexModule {

  @Action
  [Actions.ADD_ADDRESS](addressData) {
    return ApiService.post("Addresses/CreateAddress", addressData)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
      });
  }
}
