import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";
import utils from '@/core/plugins/Utils'

@Module
export default class OfferModule extends VuexModule {

  @Action
  async [Actions.GET_OFFERNOTSEND](deviceServiceId) {
    return await ApiService.getWithParamUrl("Offers/GetNoSendOffer?deviceServiceId=" + deviceServiceId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  async [Actions.GET_ORDERRECEIPT](deviceServiceId) {
    return await ApiService.getWithParamUrl("Offers/GetOrderReceiptReport?deviceServiceId=" + deviceServiceId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.ADD_OFFER](offer) {
    return ApiService.post("Offers/CreateOffer", offer)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.SEND_ORDERRECEIPT](mailModel) {
    return ApiService.post("Offers/SendOrderReceiptReport", mailModel)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_OFFER](offer) {
    return ApiService.put("Offers/UpdateOffer", offer)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_SENDOFFER](offer) {
    console.clear();
    console.log(offer);
    return ApiService.put("Offers/SendOffer", offer.value)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.UPDATE_SENDOFFERAGAIN](offer) {
    console.clear();
    console.log(offer);
    return ApiService.put("Offers/SendOfferAgain", offer.value)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.DELETE_OFFER](id) {
    return ApiService.delete("Offers/DeleteOffer?id=" + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }

  @Action
  [Actions.GET_OFFERREPORT](deviceServiceId) {
    return ApiService.getWithParamUrl("Offers/GetOfferReport?deviceServiceId=" + deviceServiceId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        utils.showError(response);
      });
  }
}
