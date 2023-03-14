import ApiService from '@/core/services/ApiService';
import { Actions, Mutations } from '@/store/enums/StoreEnums';
import { Module, Action, VuexModule } from 'vuex-module-decorators';
import router from '@/router';
import { showError } from '@/core/plugins/Utils';

@Module
export default class ContractModule extends VuexModule {
  @Action
  [Actions.ADD_CONTRACT](contract) {
    return ApiService.post('Contracts/CreateContract', contract)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.UPDATE_CONTRACT](contract) {
    return ApiService.put('Contracts/UpdateContract', contract)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.DELETE_CONTRACT](id) {
    return ApiService.delete('Contracts/DeleteContract?id=' + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_CONTRACTLIST](deviceId) {
    return ApiService.getWithParamUrl('Contracts/GetContractList?deviceId=' + deviceId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }

  @Action
  [Actions.GET_CONTRACTBYID](id) {
    return ApiService.getWithParamUrl('Contracts/GetContractById?id=' + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        showError(response);
      });
  }
}
