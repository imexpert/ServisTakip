import { createApp } from "vue";
import App from "./App.vue";

/*
TIP: To get started with clean router change path to @/router/clean.ts.
 */
import router from "./router";
import store from "./store";
import ElementPlus from "element-plus";
import i18n from "@/core/plugins/i18n";
import loading from 'vue3-loading-screen'
// if you're using CDN, please remove this line.
import * as ElementPlusIconsVue from '@element-plus/icons-vue'
import VuePdf from 'vue3-pdfjs'

//imports for app initialization
import ApiService from "@/core/services/ApiService";
import SignalRService from "@/core/plugins/signalR";
import { initApexCharts } from "@/core/plugins/apexcharts";
import { initInlineSvg } from "@/core/plugins/inline-svg";
import { initVeeValidate } from "@/core/plugins/vee-validate";

import "@/core/plugins/prismjs";

const app = createApp(App);

for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
}


app.use(store);
app.use(router);
app.use(ElementPlus);
app.use(loading, /*{...}*/)
app.use(VuePdf)

SignalRService.init();
SignalRService.connect();
SignalRService.create();

ApiService.init(app);
initApexCharts(app);
initInlineSvg(app);
initVeeValidate();

app.use(i18n);

app.mount("#app");
