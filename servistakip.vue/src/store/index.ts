import { createStore } from "vuex";
import { config } from "vuex-module-decorators";

import AuthModule from "@/store/modules/AuthModule";
import SectorModule from "@/store/modules/SectorModule";
import CustomerModule from "@/store/modules/CustomerModule";
import AddressModule from "@/store/modules/AddressModule";
import CityModule from "@/store/modules/CityModule";
import DistrictModule from "@/store/modules/DistrictModule";
import QuerterModule from "@/store/modules/QuerterModule";
import BodyModule from "@/store/modules/BodyModule";
import BreadcrumbsModule from "@/store/modules/BreadcrumbsModule";
import ConfigModule from "@/store/modules/ConfigModule";
import ThemeModeModule from "@/store/modules/ThemeModeModule";

config.rawError = true;

const store = createStore({
  modules: {
    AuthModule,
    SectorModule,
    CustomerModule,
    CityModule,
    DistrictModule,
    QuerterModule,
    BodyModule,
    BreadcrumbsModule,
    ConfigModule,
    ThemeModeModule,
    AddressModule
  },
  mutations: {
    setCustomerId(state, id) {
      state.customerId = id
    }
  },
  getters: {
    getCustomerId: (state) => () => {
      return state.customerId;
    }
  }
});

export default store;
