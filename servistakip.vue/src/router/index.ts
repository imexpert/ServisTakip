import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import store from "@/store";
import { Actions } from "@/store/enums/StoreEnums";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    redirect: "/dashboard",
    component: () => import("@/layouts/main-layout/MainLayout.vue"),
    children: [
      {
        path: "/dashboard",
        name: "dashboard",
        component: () => import("@/views/Dashboard.vue"),
      },
      {
        path: "/customer",
        name: "customer",
        component: () => import("@/views/Customer.vue"),
      },
      {
        path: "/receivedServices",
        name: "ReceivedServices",
        component: () => import("@/views/ReceivedServices.vue"),
      },
      {
        path: "/closedServices",
        name: "closedServices",
        component: () => import("@/views/ClosedServices.vue"),
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
  history: createWebHashHistory(),
  routes,
});

router.beforeEach(() => {
  store.dispatch(Actions.VERIFY_AUTH);

  // Scroll page to top on every route change
  setTimeout(() => {
    window.scrollTo(0, 0);
  }, 100);
});

export default router;
