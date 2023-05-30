import { createRouter, createWebHistory, RouteRecordRaw, useRoute } from "vue-router";
import store from "@/store";
import { Actions } from "@/store/enums/StoreEnums";
import JwtService from '@/core/services/JwtService';

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    redirect: "/anaSayfa",
    component: () => import("@/layouts/main-layout/MainLayout.vue"),
    children: [
      {
        path: "/anaSayfa",
        name: "anaSayfa",
        component: () => import("@/views/AnaSayfa.vue"),
      },
      {
        path: "/customer",
        name: "customer",
        component: () => import("@/views/Customer.vue"),
      },
      {
        path: "/alinanServisler",
        name: "AlinanServisler",
        component: () => import("@/views/AlinanServisler.vue"),
      },
      {
        path: "/kapatilacakIsler",
        name: "KapatilacakIsler",
        component: () => import("@/views/KapatilacakIsler.vue"),
      },
      {
        path: "/sozlesmeBasim",
        name: "sozlesmeBasim",
        component: () => import("@/views/reports/SozlesmeBasim.vue"),
      },
      {
        path: "/musteriRaporu",
        name: "musteriRaporu",
        component: () => import("@/views/reports/MusteriRaporu.vue"),
      },
      {
        path: "/bakimRaporu",
        name: "bakimRaporu",
        component: () => import("@/views/reports/BakimRaporu.vue"),
      },
      {
        path: "/admin/kullaniciYonetimi",
        name: "kullaniciYonetimi",
        component: () => import("@/views/admin/KullaniciYonetimi.vue"),
      },
    ],
  },
  {
    path: "/",
    component: () => import("@/components/page-layouts/Auth.vue"),
    children: [
      {
        path: "/sign-in",
        name: "sign-in",
        component: () =>
          import("@/views/authentication/SignIn.vue"),
      },
    ],
  },
  {
    path: "/:pathMatch(.*)*",
    redirect: "/404",
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach(() => {
  var route = useRoute();

  var currentUrl = window.location.pathname;
  console.log(window.location.href);
  store.dispatch(Actions.VERIFY_AUTH);

  // Scroll page to top on every route change
  setTimeout(() => {
    window.scrollTo(0, 0);
  }, 100);
});

router.afterEach(() => {
  // store.dispatch(Actions.VERIFY_ADMIN);
})

export default router;
