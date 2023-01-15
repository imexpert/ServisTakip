import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";

@Module
export default class CustomerModule extends VuexModule {

  @Action
  [Actions.ADD_CUSTOMER](customerData) {
    return ApiService.post("Customers/CreateCustomer", customerData)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.SET_ERROR, response.data.errors);
      });
  }

  @Action
  [Actions.GET_LASTTRADED_CUSTOMER]() {
    return ApiService.get("Customers/GetLastTradedCustomer")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.SET_ERROR, response.data.errors);
      });
  }

  @Action
  [Actions.GET_CUSTOMER](customerId) {
    return ApiService.getWithParamUrl("Customers/GetCustomerById?customerId=" + customerId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.SET_ERROR, response.data.errors);
      });
  }
}
