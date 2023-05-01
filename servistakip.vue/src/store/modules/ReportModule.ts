import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import { showError } from "@/core/plugins/Utils";

@Module
export default class ReportModule extends VuexModule {

  @Action
  [Actions.GET_SOZLESMEBASIM](filter) {
    return ApiService.post("Reports/SozlesmeBasimRapor", filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_MUSTERIRAPOR](filter) {
    return ApiService.post("Reports/MusteriRapor", filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_MUSTERIRAPORFILE](filter) {
    return ApiService.post("Reports/MusteriRaporFile", filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}
