import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import Swal from 'sweetalert2/dist/sweetalert2.js';

@Module
export default class DeviceModule extends VuexModule {

  @Action
  [Actions.ADD_DEVICE](device) {
    return ApiService.post("Devices/AddDevice", device)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        console.log(response)
        debugger;
        if(response.status == 401){
          this.context.commit(Mutations.PURGE_AUTH);
          router.push({ name: 'sign-in' });
        } else {
          Swal.fire({
            title:'Hata',
            text: 'İşlem sırasında hata oluştu',
            icon: 'error',
            buttonsStyling: false,
            confirmButtonText: 'Tamam',
            customClass: {
              confirmButton: 'btn btn-primary',
            },
          }).then(() => {
            
          });
        }
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceWithQuery?deviceId=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_SERIALNO_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceBySerialNoFilter?filter=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_DEVICE_BY_MODEL_NAME_FILTER](filter) {
    return ApiService.getWithParamUrl("Devices/GetDeviceByModelNameFilter?filter=" + filter)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }
}
