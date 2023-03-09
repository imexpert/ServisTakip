import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import utils from '@/core/plugins/Utils'

@Module
export default class CustomerModule extends VuexModule {

  @Action
  [Actions.ADD_CUSTOMER](customerData) {
    return ApiService.post("Customers/CreateCustomer", customerData)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_LASTTRADED_CUSTOMER]() {
    return ApiService.get("Customers/GetLastTradedCustomer")
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_MAIN_PAGE_CUSTOMER](rowId) {
    return ApiService.getWithParamUrl("Customers/GetMainPageCustomer?rowId=" + rowId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_CUSTOMER](customerId) {
    return ApiService.getWithParamUrl("Customers/GetCustomerById?customerId=" + customerId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_CUSTOMER_BY_FILTER](filter) {
    return ApiService.getWithParamUrl("Customers/GetCustomerWithQuery?filter=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }
}
