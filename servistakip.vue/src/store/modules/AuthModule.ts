import ApiService from "@/core/services/ApiService";
import JwtService from "@/core/services/JwtService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, Mutation, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import { showError, showErrorMessage } from "@/core/plugins/Utils";
import store from "@/store";

export interface User {
  firstname: string;
  surname: string;
  email: string;
  api_token: string;
}

export interface UserAuthInfo {
  errors: unknown;
  user: User;
  isAuthenticated: boolean;
}

@Module
export default class AuthModule extends VuexModule implements UserAuthInfo {
  errors = {};
  user = {} as User;
  isAuthenticated = !!JwtService.getToken();

  /**
   * Get current user object
   * @returns User
   */
  get currentUser(): User {
    return this.user;
  }

  /**
   * Verify user authentication
   * @returns boolean
   */
  get isUserAuthenticated(): boolean {
    return this.isAuthenticated;
  }

  /**
   * Get authentification errors
   * @returns array
   */
  get getErrors() {
    return this.errors;
  }

  @Mutation
  [Mutations.SET_ERROR](error) {
    this.errors = { ...error };
  }

  @Mutation
  [Mutations.SET_AUTH](user) {
    this.isAuthenticated = true;
    this.user = user;
    this.errors = {};
    JwtService.saveToken(user.token);
  }

  @Mutation
  [Mutations.SET_USER](user) {
    this.user = user;
  }

  @Mutation
  [Mutations.PURGE_AUTH]() {
    this.isAuthenticated = false;
    this.user = {} as User;
    this.errors = [];
    JwtService.destroyToken();
  }

  @Action
  [Actions.LOGIN](credentials) {
    return ApiService.post("Auth/login", credentials)
      .then(({ data }) => {
        console.log(data);
        if (data.isSuccess) {
          console.log(data.data);
          this.context.commit(Mutations.SET_AUTH, data.data);
        }

        return data;
      })
      .catch(({ response }) => {
        showErrorMessage("Giriş yapma sırasında hata oluştu.");
      });
  }

  @Action
  [Actions.LOGOUT]() {
    this.context.commit(Mutations.PURGE_AUTH);
    router.push({ name: 'sign-in' });
  }

  @Mutation
  [Mutations.SIGNOUT]() {
    console.log("SIGNOUT")
    this.context.commit(Mutations.PURGE_AUTH);
    router.push({ name: 'sign-in' });
  }

  @Action
  [Actions.REGISTER](credentials) {
    return ApiService.post("register", credentials)
      .then(({ data }) => {
        this.context.commit(Mutations.SET_AUTH, data);
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.FORGOT_PASSWORD](payload) {
    return ApiService.post("forgot_password", payload)
      .then(() => {
        this.context.commit(Mutations.SET_ERROR, {});
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.VERIFY_AUTH]() {
    if (JwtService.getToken()) {
      ApiService.setHeader();
      ApiService.get("Auth/VerifyToken")
        .then(({ data }) => {

        })
        .catch(({ response }) => {
          store.commit(Mutations.PURGE_AUTH);
          router.push({ name: 'sign-in' });
        });
    } else {
      this.context.commit(Mutations.PURGE_AUTH);
    }
  }
}
