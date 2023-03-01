import ApiService from "@/core/services/ApiService";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import { Module, Action, VuexModule } from "vuex-module-decorators";
import router from "@/router";

@Module
export default class OfferModule extends VuexModule {

  @Action
  async [Actions.GET_OFFERNOTSEND](deviceServiceId) {
    return await ApiService.getWithParamUrl("Offers/GetNoSendOffer?deviceServiceId=" + deviceServiceId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.ADD_OFFER](offer) {
    return ApiService.post("Offers/CreateOffer", offer)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.UPDATE_OFFER](offer) {
    return ApiService.put("Offers/UpdateOffer", offer)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
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
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.DELETE_OFFER](id) {
    return ApiService.delete("Offers/DeleteOffer?id=" + id)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }

  @Action
  [Actions.GET_OFFERREPORT](deviceServiceId) {
    return ApiService.getWithParamUrl("Offers/GetOfferReport?deviceServiceId=" + deviceServiceId)
      .then(({ data }) => {
        return data;
      })
      .catch(({ response }) => {
        this.context.commit(Mutations.PURGE_AUTH);
        router.push({ name: 'sign-in' });
      });
  }
}
