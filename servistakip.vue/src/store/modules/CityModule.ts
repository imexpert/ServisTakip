import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";

@Module
export default class CityModule extends VuexModule {

  @Action
  [Actions.GET_CITY_LIST]() {
    return ApiService.get("Cities/GetCityList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
      });
  }
}
