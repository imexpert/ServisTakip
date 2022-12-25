import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";

@Module
export default class SectorModule extends VuexModule {

  @Action
  [Actions.GET_SECTOR_LIST]() {
    return ApiService.get("Sectors/GetSectorList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.SET_ERROR, response.data.errors);
      });
  }
}
