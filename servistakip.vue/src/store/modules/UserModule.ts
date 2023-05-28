import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import { showError } from "@/core/plugins/Utils";

@Module
export default class UserModule extends VuexModule {

  @Action
  async [Actions.GET_TECHNICIAN_LIST]() {
    return await ApiService.get("Users/GetTechnicianUserList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  async [Actions.GET_USER_LIST]() {
    return await ApiService.get("Users/GetUserList")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  async [Actions.GET_USER](id) {
    return await ApiService.getWithParamUrl("Users/GetUser?id=" + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  async [Actions.ADD_USER](user) {
    ApiService.vueInstance.axios.defaults.headers['Content-Type'] = 'multipart/form-data';
    return await ApiService.post("Users/AddUser", user)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  async [Actions.UPDATE_USER](user) {
    ApiService.vueInstance.axios.defaults.headers['Content-Type'] = 'multipart/form-data';
    return await ApiService.put("Users/UpdateUser", user)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  async [Actions.DELETE_USER](id) {
    return await ApiService.delete("Users/DeleteUser?id= " + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}
