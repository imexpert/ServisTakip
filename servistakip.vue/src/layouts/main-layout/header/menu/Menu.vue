<template>
  <!--begin::Menu wrapper-->
  <div
    v-if="headerMenuDisplay"
    class="app-header-menu app-header-mobile-drawer align-items-stretch"
    data-kt-drawer="true"
    data-kt-drawer-name="app-header-menu"
    data-kt-drawer-activate="{default: true, lg: false}"
    data-kt-drawer-overlay="true"
    data-kt-drawer-width="225px"
    data-kt-drawer-direction="end"
    data-kt-drawer-toggle="#kt_app_header_menu_toggle"
    data-kt-swapper="true"
    data-kt-swapper-mode="{default: 'append', lg: 'prepend'}"
    data-kt-swapper-parent="{default: '#kt_app_body', lg: '#kt_app_header_wrapper'}"
  >
    <!--begin::Menu-->
    <div
      class="menu menu-rounded menu-column menu-lg-row my-5 my-lg-0 align-items-stretch fw-semibold px-2 px-lg-0"
      id="kt_app_header_menu"
      data-kt-menu="true"
    >
      <KTMenuPages></KTMenuPages>

      <div
        data-kt-menu-trigger="{default: 'click', lg: 'hover'}"
        data-kt-menu-placement="bottom-start"
        class="menu-item menu-lg-down-accordion menu-sub-lg-down-indention me-0 me-lg-2"
      >
        <!--begin:Menu link-->
        <span class="menu-link">
          <span class="menu-title">Help</span>
          <span class="menu-arrow d-lg-none"></span>
        </span>
        <!--end:Menu link-->
        <!--begin:Menu sub-->
        <div
          class="menu-sub menu-sub-lg-down-accordion menu-sub-lg-dropdown px-lg-2 py-lg-4 w-lg-200px"
        >
          <!--begin:Menu item-->
          <div class="menu-item">
            <!--begin:Menu link-->
            <a
              class="menu-link"
              href="?page=documentation/base/utilities"
              title="Check out over 200 in-house components, plugins and ready for use solutions"
              data-bs-toggle="tooltip"
              data-bs-trigger="hover"
              data-bs-dismiss="click"
              data-bs-placement="right"
            >
              <span class="menu-icon">
                <span class="svg-icon svg-icon-3">
                  <inline-svg src="media/icons/duotune/general/gen002.svg" />
                </span>
              </span>
              <span class="menu-title">Components</span>
            </a>
            <!--end:Menu link-->
          </div>
          <!--end:Menu item-->
          <!--begin:Menu item-->
          <div class="menu-item">
            <!--begin:Menu link-->
            <a
              class="menu-link"
              href="?page=documentation/getting-started"
              title="Check out the complete documentation"
              data-bs-toggle="tooltip"
              data-bs-trigger="hover"
              data-bs-dismiss="click"
              data-bs-placement="right"
            >
              <span class="menu-icon">
                <span class="svg-icon svg-icon-3">
                  <inline-svg src="media/icons/duotune/abstract/abs027.svg" />
                </span>
              </span>
              <span class="menu-title">Documentation</span>
            </a>
            <!--end:Menu link-->
          </div>
          <!--end:Menu item-->
          <!--begin:Menu item-->
          <div class="menu-item">
            <!--begin:Menu link-->
            <a
              class="menu-link"
              href="https://preview.keenthemes.com/metronic8/vue/docs/#/changelog"
            >
              <span class="menu-icon">
                <span class="svg-icon svg-icon-3">
                  <inline-svg src="media/icons/duotune/coding/cod003.svg" />
                </span>
              </span>
              <span class="menu-title">Changelog v{{ version }}</span>
            </a>
            <!--end:Menu link-->
          </div>
          <!--end:Menu item-->
        </div>
        <!--end:Menu sub-->
      </div>
      <!--end:Menu item-->
    </div>
    <!--end::Menu-->
  </div>
  <div v-else class="align-items-stretch"></div>
  <!--end::Menu wrapper-->
</template>

<script lang="ts">
import { defineComponent } from "vue";
import KTMenuPages from "@/layouts/main-layout/header/menu/MenuPages.vue";
import { version } from "@/core/helpers/documentation";
import { headerMenuDisplay } from "@/core/helpers/config";

export default defineComponent({
  name: "header-menu",
  components: {
    KTMenuPages,
  },
  setup() {
    return {
      version,
      headerMenuDisplay,
    };
  },
});
</script>
