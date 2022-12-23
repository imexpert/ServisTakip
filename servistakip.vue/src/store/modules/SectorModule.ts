import ApiService from "@/core/services/ApiService";
import JwtService from "@/core/services/JwtService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, Mutation, VuexModule } from "vuex-module-decorators";

@Module
export default class SectorModule extends VuexModule {

  @Action
  [Actions.GET_SECTOR_LIST]() {
    return ApiService.get("Sectors/GetSectorList")
      .then(({ data }) => {
        console.log(data);
        if (data.isSuccess) {
          console.log(data.data);
          this.context.commit(Mutations.SET_AUTH, data.data);
        }

        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.SET_ERROR, response.data.errors);
      });
  }
}
