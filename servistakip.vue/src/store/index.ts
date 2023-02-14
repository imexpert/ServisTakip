import { createStore } from "vuex";
import { config } from "vuex-module-decorators";

import AuthModule from "@/store/modules/AuthModule";
import SectorModule from "@/store/modules/SectorModule";
import UserModule from "@/store/modules/UserModule";
import DeviceServiceModule from "@/store/modules/DeviceServiceModule";
import CustomerModule from "@/store/modules/CustomerModule";
import DeviceModule from "@/store/modules/DeviceModule";
import AddressModule from "@/store/modules/AddressModule";
import CityModule from "@/store/modules/CityModule";
import DistrictModule from "@/store/modules/DistrictModule";
import QuerterModule from "@/store/modules/QuerterModule";
import BodyModule from "@/store/modules/BodyModule";
import BreadcrumbsModule from "@/store/modules/BreadcrumbsModule";
import ConfigModule from "@/store/modules/ConfigModule";
import ThemeModeModule from "@/store/modules/ThemeModeModule";
import BootCodeModule from "@/store/modules/BootCodeModule";

config.rawError = true;

const store = createStore({
  modules: {
    AuthModule,
    SectorModule,
    CustomerModule,
    DeviceModule,
    CityModule,
    DistrictModule,
    QuerterModule,
    BodyModule,
    BreadcrumbsModule,
    ConfigModule,
    ThemeModeModule,
    AddressModule,
    BootCodeModule,
    UserModule,
    DeviceServiceModule
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
