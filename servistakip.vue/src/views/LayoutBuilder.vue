<template>
  <!--begin::Layout Builder Notice-->
  <div class="card mb-10">
    <div class="card-body d-flex align-items-center py-8">
      <!--begin::Icon-->
      <div
        class="d-flex h-80px w-80px flex-shrink-0 flex-center position-relative"
      >
        <span class="svg-icon svg-icon-primary position-absolute opacity-15">
          <inline-svg
            src="media/icons/duotune/abstract/abs051.svg"
            class="h-80px w-80px"
          />
        </span>
        <span class="svg-icon svg-icon-3x svg-icon-primary position-absolute">
          <inline-svg src="media/icons/duotune/coding/cod009.svg" />
        </span>
      </div>
      <!--end::Icon-->

      <!--begin::Description-->
      <div class="ms-6">
        <p class="list-unstyled text-gray-600 fw-semobold fs-6 p-0 m-0">
          The layout builder is to assist your set and configure your preferred
          project layout specifications and preview it in real time and export
          the HTML template with its includable partials of this demo. The
          downloaded version does not include the assets folder since the layout
          builder's main purpose is to help to generate the final HTML code
          without hassle.
        </p>
      </div>
      <!--end::Description-->
    </div>
  </div>
  <!--end::Layout Builder Notice-->

  <div class="card mb-10">
    <!--begin::Header-->
    <div class="card-header card-header-stretch">
      <ul
        class="nav nav-stretch nav-line-tabs fw-semobold border-0"
        role="tablist"
        id="kt_layout_builder_tabs"
        ref="kt_layout_builder_tabs"
      >
        <li class="nav-item">
          <a
            class="nav-link"
            :class="{ active: tabIndex === 'main' }"
            data-bs-toggle="tab"
            @click="setActiveTab($event)"
            data-tab-index="main"
            href="#kt_builder_main"
            role="tab"
          >
            Main
          </a>
        </li>
        <li class="nav-item">
          <a
            class="nav-link"
            :class="{ active: tabIndex === 'layout' }"
            data-bs-toggle="tab"
            @click="setActiveTab($event)"
            data-tab-index="layout"
            href="#kt_builder_layout"
            role="tab"
          >
            Layout
          </a>
        </li>
        <li class="nav-item">
          <a
            class="nav-link"
            :class="{ active: tabIndex === 'sidebar' }"
            data-bs-toggle="tab"
            @click="setActiveTab($event)"
            data-tab-index="sidebar"
            href="#kt_builder_sidebar"
            role="tab"
          >
            Sidebar
          </a>
        </li>
        <li class="nav-item">
          <a
            class="nav-link"
            :class="{ active: tabIndex === 'header' }"
            data-bs-toggle="tab"
            @click="setActiveTab($event)"
            data-tab-index="header"
            href="#kt_builder_header"
            role="tab"
          >
            Header
          </a>
        </li>
      </ul>
    </div>
    <!--end::Header-->

    <!--begin::Form-->
    <form class="form" id="kt_layout_builder_form" @submit="submit($event)">
      <!--begin::Body-->
      <div class="card-body">
        <div class="tab-content pt-3" id="kt_tabs">
          <div
            class="tab-pane"
            :class="{ active: tabIndex === 'main' }"
            id="kt_builder_main"
          >
            <!--begin::Row-->
            <div class="row">
              <!--begin::Col-->
              <div class="col-lg-6 pe-lg-15">
                <!--begin::Form group-->
                <div class="form-group">
                  <!--begin::Heading-->
                  <div class="mb-6">
                    <h4 class="fw-bold text-dark">Theme Mode</h4>
                    <div class="fw-semibold text-muted fs-7 d-block lh-1">
                      Enjoy Dark &amp; Light modes.
                    </div>
                  </div>
                  <!--end::Heading-->
                  <!--begin::Options-->
                  <div
                    class="row"
                    data-kt-buttons="true"
                    data-kt-buttons-target=".form-check-image,.form-check-input"
                    data-kt-initialized="1"
                  >
                    <!--begin::Col-->
                    <div class="col-6">
                      <!--begin::Option-->
                      <label
                        class="form-check-image form-check-success"
                        :class="[themeMode === 'light' && 'active']"
                      >
                        <!--begin::Image-->
                        <div class="form-check-wrapper">
                          <img
                            src="media/misc/layout/light.png"
                            class="mw-100"
                            alt=""
                          />
                        </div>
                        <!--end::Image-->
                        <!--begin::Check-->
                        <div
                          class="form-check form-check-custom form-check-solid form-check-sm form-check-success"
                        >
                          <input
                            class="form-check-input"
                            type="radio"
                            :checked="themeMode === 'light' ? 'checked' : false"
                            value="light"
                            name="theme_mode"
                            @change="onThemeModeChange"
                          />
                          <!--begin::Label-->
                          <div class="form-check-label text-gray-700">
                            Light
                          </div>
                          <!--end::Label-->
                        </div>
                        <!--end::Check-->
                      </label>
                      <!--end::Option-->
                    </div>
                    <!--end::Col-->
                    <!--begin::Col-->
                    <div class="col-6">
                      <!--begin::Option-->
                      <label
                        class="form-check-image form-check-success"
                        :class="[themeMode === 'dark' && 'active']"
                      >
                        <!--begin::Image-->
                        <div class="form-check-wrapper">
                          <img
                            src="media/misc/layout/dark.png"
                            class="mw-100"
                            alt=""
                          />
                        </div>
                        <!--end::Image-->
                        <!--begin::Check-->
                        <div
                          class="form-check form-check-custom form-check-solid form-check-sm form-check-success"
                        >
                          <input
                            class="form-check-input"
                            type="radio"
                            :checked="themeMode === 'dark' ? 'checked' : false"
                            value="dark"
                            name="theme_mode"
                            @change="onThemeModeChange"
                          />
                          <!--begin::Label-->
                          <div class="form-check-label text-gray-700">Dark</div>
                          <!--end::Label-->
                        </div>
                        <!--end::Check-->
                      </label>
                      <!--end::Option-->
                    </div>
                    <!--end::Col-->
                  </div>
                  <!--end::Options-->
                </div>
                <!--end::Form group-->
              </div>
              <!--end::Col-->
            </div>
            <!--end::Row-->
            <!--begin::Separator-->
            <div class="separator separator-dashed my-6"></div>
            <!--end::Separator-->
            <!--begin::Form group-->
            <div class="form-group">
              <!--begin::Heading-->
              <div class="d-flex flex-column mb-4">
                <h4 class="fw-bold text-dark">Width Mode</h4>
                <div class="fs-7 fw-semibold text-muted">
                  Page width options
                </div>
              </div>
              <!--end::Heading-->
              <!--begin::Options-->
              <div class="d-flex">
                <!--begin::Check-->
                <div
                  class="form-check form-check-custom form-check-success form-check-solid form-check-sm me-7"
                >
                  <input
                    v-model="config.general.pageWidth"
                    class="form-check-input"
                    type="radio"
                    value="default"
                    id="kt_builder_page_width_default"
                  />
                  <!--begin::Label-->
                  <label
                    class="form-check-label text-gray-700 fw-bold text-nowrap"
                    for="kt_builder_page_width_default"
                    >Default</label
                  >
                  <!--end::Label-->
                </div>
                <!--end::Check-->
                <!--begin::Check-->
                <div
                  class="form-check form-check-custom form-check-success form-check-solid form-check-sm me-7"
                >
                  <input
                    v-model="config.general.pageWidth"
                    class="form-check-input"
                    type="radio"
                    value="fluid"
                    id="kt_builder_page_width_fluid"
                  />
                  <!--begin::Label-->
                  <label
                    class="form-check-label text-gray-700 fw-bold text-nowrap"
                    for="kt_builder_page_width_fluid"
                    >Fluid</label
                  >
                  <!--end::Label-->
                </div>
                <!--end::Check-->
                <!--begin::Check-->
                <div
                  class="form-check form-check-custom form-check-success form-check-solid form-check-sm me-7"
                >
                  <input
                    v-model="config.general.pageWidth"
                    class="form-check-input"
                    type="radio"
                    value="fixed"
                    id="kt_builder_page_width_fixed"
                  />
                  <!--begin::Label-->
                  <label
                    class="form-check-label text-gray-700 fw-bold text-nowrap"
                    for="kt_builder_page_width_fixed"
                    >Fixed</label
                  >
                  <!--end::Label-->
                </div>
                <!--end::Check-->
              </div>
              <!--end::Options-->
            </div>
            <!--end::Form group-->
            <!--begin::Separator-->
            <div class="separator separator-dashed my-6"></div>
            <!--end::Separator-->
            <!--begin::Form group-->
            <div class="form-group d-flex flex-stack">
              <!--begin::Heading-->
              <div class="d-flex flex-column">
                <h4 class="fw-bold text-dark">Menu Icon</h4>
                <div class="fs-7 fw-semibold text-muted">
                  Sidebar menu icon options
                </div>
              </div>
              <!--end::Heading-->
              <!--begin::Option-->
              <div class="d-flex justify-content-end">
                <!--begin::Check-->
                <div
                  class="form-check form-check-custom form-check-success form-check-solid me-7"
                  data-bs-toggle="tooltip"
                  data-kt-initialized="1"
                >
                  <input
                    v-model="config.sidebar.default.menu.iconType"
                    class="form-check-input w-20px h-20px"
                    type="radio"
                    value="svg"
                    id="kt_builder_icon_svg"
                  />
                  <!--begin::Label-->
                  <label
                    class="form-check-label text-gray-700 fw-bold text-nowrap"
                    for="kt_builder_icon_svg"
                    >SVG Duotone</label
                  >
                  <!--end::Label-->
                </div>
                <!--end::Check-->
                <!--begin::Check-->
                <div
                  class="form-check form-check-custom form-check-success form-check-solid me-7"
                  data-bs-toggle="tooltip"
                  data-kt-initialized="1"
                >
                  <input
                    v-model="config.sidebar.default.menu.iconType"
                    class="form-check-input w-20px h-20px"
                    type="radio"
                    value="font"
                    id="kt_builder_icon_font"
                  />
                  <!--begin::Label-->
                  <label
                    class="form-check-label text-gray-700 fw-bold text-nowrap"
                    for="kt_builder_icon_font"
                    >Font Icons</label
                  >
                  <!--end::Label-->
                </div>
                <!--end::Check-->
              </div>
              <!--end::Option-->
            </div>
            <!--end::Form group-->
            <!--begin::Separator-->
            <div class="separator separator-dashed my-6"></div>
            <!--end::Separator-->
          </div>

          <div
            class="tab-pane"
            :class="{ active: tabIndex === 'layout' }"
            id="kt_builder_layout"
          >
            <!--begin::Heading-->
            <div class="mb-6">
              <h4 class="fw-bold text-dark">Layouts</h4>
              <span class="fw-semibold text-muted fs-7 lh-1"
                >4 main layout options.</span
              >
            </div>
            <!--end::Heading-->
            <!--begin::Options-->
            <div
              class="row gy-5"
              data-kt-buttons="true"
              data-kt-buttons-target=".form-check-image:not(.disabled),.form-check-input:not([disabled])"
              data-kt-initialized="1"
            >
              <!--begin::Col-->
              <div class="col-lg-3">
                <!--begin::Option-->
                <label
                  :class="[layoutType === 'dark-sidebar' && 'active']"
                  class="form-check-image form-check-success"
                >
                  <!--begin::Image-->
                  <div class="form-check-wrapper">
                    <img
                      src="media/misc/layout/dark-sidebar.png"
                      class="mw-100"
                      alt=""
                    />
                  </div>
                  <!--end::Image-->
                  <!--begin::Check-->
                  <div
                    class="form-check form-check-custom form-check-success form-check-sm form-check-solid"
                  >
                    <input
                      v-model="layoutType"
                      class="form-check-input"
                      type="radio"
                      value="dark-sidebar"
                      name="layoutType"
                    />
                    <!--begin::Label-->
                    <div class="form-check-label text-gray-800">
                      Dark Sidebar
                    </div>
                    <!--end::Label-->
                  </div>
                  <!--end::Check-->
                </label>
                <!--end::Option-->
              </div>
              <!--end::Col-->
              <!--begin::Col-->
              <div class="col-lg-3">
                <!--begin::Option-->
                <label
                  :class="[layoutType === 'light-sidebar' && 'active']"
                  class="form-check-image form-check-success"
                >
                  <!--begin::Image-->
                  <div class="form-check-wrapper">
                    <img
                      src="media/misc/layout/light-sidebar.png"
                      class="mw-100"
                      alt=""
                    />
                  </div>
                  <!--end::Image-->
                  <!--begin::Check-->
                  <div
                    class="form-check form-check-custom form-check-success form-check-sm form-check-solid"
                  >
                    <input
                      v-model="layoutType"
                      class="form-check-input"
                      type="radio"
                      value="light-sidebar"
                      name="layoutType"
                    />
                    <!--begin::Label-->
                    <div class="form-check-label text-gray-800">
                      Light Sidebar
                    </div>
                    <!--end::Label-->
                  </div>
                  <!--end::Check-->
                </label>
                <!--end::Option-->
              </div>
              <!--end::Col-->
              <!--begin::Col-->
              <div class="col-lg-3">
                <!--begin::Option-->
                <label
                  :class="[layoutType === 'dark-header' && 'active']"
                  class="form-check-image form-check-success"
                >
                  <!--begin::Image-->
                  <div class="form-check-wrapper">
                    <img
                      src="media/misc/layout/dark-header.png"
                      class="mw-100"
                      alt=""
                    />
                  </div>
                  <!--end::Image-->
                  <!--begin::Check-->
                  <div
                    class="form-check form-check-custom form-check-success form-check-sm form-check-solid"
                  >
                    <input
                      v-model="layoutType"
                      class="form-check-input"
                      type="radio"
                      value="dark-header"
                      name="layoutType"
                    />
                    <!--begin::Label-->
                    <div class="form-check-label text-gray-800">
                      Dark Header
                    </div>
                    <!--end::Label-->
                  </div>
                  <!--end::Check-->
                </label>
                <!--end::Option-->
              </div>
              <!--end::Col-->
              <!--begin::Col-->
              <div class="col-lg-3">
                <!--begin::Option-->
                <label
                  :class="[layoutType === 'light-header' && 'active']"
                  class="form-check-image form-check-success"
                >
                  <!--begin::Image-->
                  <div class="form-check-wrapper">
                    <img
                      src="media/misc/layout/light-header.png"
                      class="mw-100"
                      alt=""
                    />
                  </div>
                  <!--end::Image-->
                  <!--begin::Check-->
                  <div
                    class="form-check form-check-custom form-check-success form-check-sm form-check-solid"
                  >
                    <input
                      v-model="layoutType"
                      class="form-check-input"
                      type="radio"
                      value="light-header"
                      name="layoutType"
                    />
                    <!--begin::Label-->
                    <div class="form-check-label text-gray-800">
                      Light Header
                    </div>
                    <!--end::Label-->
                  </div>
                  <!--end::Check-->
                </label>
                <!--end::Option-->
              </div>
              <!--end::Col-->
            </div>
            <!--end::Options-->
          </div>

          <div
            class="tab-pane"
            :class="{ active: tabIndex === 'sidebar' }"
            id="kt_builder_sidebar"
          >
            <!--begin::Form group-->
            <div class="form-group d-flex flex-stack">
              <!--begin::Heading-->
              <div class="d-flex flex-column">
                <h4 class="fw-bold text-dark">Minimize</h4>
                <div class="fs-7 fw-semibold text-muted">
                  Sidebar minimize mode
                </div>
              </div>
              <!--end::Heading-->
              <!--begin::Option-->
              <div class="d-flex justify-content-end">
                <!--begin::Check-->
                <div
                  class="form-check form-check-custom form-check-solid form-check-success form-switch"
                >
                  <input
                    v-model="config.sidebar.default.minimize.desktop.enabled"
                    class="form-check-input w-45px h-30px"
                    type="checkbox"
                    value="true"
                    id="kt_builder_sidebar_minimize_desktop_enabled"
                  />
                  <!--begin::Label-->
                  <label
                    class="form-check-label text-gray-700 fw-bold"
                    for="kt_builder_sidebar_minimize_desktop_enabled"
                    data-bs-toggle="tooltip"
                    data-kt-initialized="1"
                    >Minimize Toggle</label
                  >
                  <!--end::Label-->
                </div>
                <!--end::Check-->
                <!--begin::Check-->
                <div
                  class="form-check form-check-custom form-check-solid form-check-success form-switch ms-10"
                >
                  <input
                    v-model="config.sidebar.default.minimize.desktop.hoverable"
                    class="form-check-input w-45px h-30px"
                    type="checkbox"
                    value="true"
                    id="kt_builder_sidebar_minimize_desktop_hoverable"
                  />
                  <!--begin::Label-->
                  <label
                    class="form-check-label text-gray-700 fw-bold"
                    for="kt_builder_sidebar_minimize_desktop_hoverable"
                    data-bs-toggle="tooltip"
                    data-kt-initialized="1"
                    >Hoverable</label
                  >
                  <!--end::Label-->
                </div>
                <!--end::Check-->
                <!--begin::Check-->
                <div
                  class="form-check form-check-custom form-check-solid form-check-success form-switch ms-10"
                >
                  <input
                    v-model="config.sidebar.default.minimize.desktop.default"
                    class="form-check-input w-45px h-30px"
                    type="checkbox"
                    value="true"
                    id="kt_builder_sidebar_minimize_desktop_default"
                  />
                  <!--begin::Label-->
                  <label
                    class="form-check-label text-gray-700 fw-bold"
                    for="kt_builder_sidebar_minimize_desktop_default"
                    data-bs-toggle="tooltip"
                    data-kt-initialized="1"
                    >Default Minimized</label
                  >
                  <!--end::Label-->
                </div>
                <!--end::Check-->
              </div>
              <!--end::Option-->
            </div>
            <!--end::Form group-->
          </div>

          <div
            class="tab-pane"
            :class="{ active: tabIndex === 'header' }"
            id="kt_builder_header"
          >
            <div
              class="tab-pane active show"
              id="kt_builder_header"
              role="tabpanel"
            >
              <!--begin::Form group-->
              <div class="form-group d-flex flex-stack">
                <!--begin::Heading-->
                <div class="d-flex flex-column">
                  <h4 class="fw-bold text-dark">Fixed</h4>
                  <div class="fs-7 fw-semibold text-muted">
                    Fixed toolbar mode
                  </div>
                </div>
                <!--end::Heading-->
                <!--begin::Option-->
                <div class="d-flex justify-content-end">
                  <!--begin::Check-->
                  <div
                    class="form-check form-check-custom form-check-solid form-check-success form-switch me-10"
                  >
                    <input
                      v-model="config.header.default.fixed.desktop"
                      class="form-check-input w-45px h-30px"
                      type="checkbox"
                      value="true"
                      id="kt_builder_header_fixed_desktop"
                    />
                    <!--begin::Label-->
                    <label
                      class="form-check-label text-gray-700 fw-bold"
                      for="kt_builder_header_fixed_desktop"
                      >Desktop Mode</label
                    >
                    <!--end::Label-->
                  </div>
                  <!--end::Check-->
                  <!--begin::Check-->
                  <div
                    class="form-check form-check-custom form-check-solid form-check-success form-switch"
                  >
                    <input
                      v-model="config.header.default.fixed.mobile"
                      class="form-check-input w-45px h-30px"
                      type="checkbox"
                      value="true"
                      id="kt_builder_header_fixed_mobile"
                    />
                    <!--begin::Label-->
                    <label
                      class="form-check-label text-gray-700 fw-bold"
                      for="kt_builder_header_fixed_mobile"
                      >Mobile Mode</label
                    >
                    <!--end::Label-->
                  </div>
                  <!--end::Check-->
                </div>
                <!--end::Option-->
              </div>
              <!--end::Form group-->
              <!--begin::Separator-->
              <div class="separator separator-dashed my-6"></div>
              <!--end::Separator-->
              <!--begin::Form group-->
              <div class="form-group d-flex flex-stack">
                <!--begin::Heading-->
                <div class="d-flex flex-column">
                  <h4 class="fw-bold text-dark">Page Title</h4>
                  <div class="fs-7 fw-semibold text-muted">
                    Page title layout options
                  </div>
                </div>
                <!--end::Heading-->
                <!--begin::Option-->
                <div class="d-flex justify-content-end">
                  <!--begin::Check-->
                  <div
                    class="form-check form-check-custom form-check-solid form-check-success form-check-sm me-10"
                  >
                    <input
                      v-model="config.pageTitle.direction"
                      class="form-check-input"
                      type="radio"
                      value="column"
                      id="kt_builder_page_title_direction_column"
                    />
                    <!--begin::Label-->
                    <label
                      class="form-check-label text-gray-700 fw-bold"
                      for="kt_builder_page_title_direction_column"
                      data-bs-toggle="tooltip"
                      data-kt-initialized="1"
                      >Column</label
                    >
                    <!--end::Label-->
                  </div>
                  <!--end::Check-->
                  <!--begin::Check-->
                  <div
                    class="form-check form-check-custom form-check-solid form-check-success"
                  >
                    <input
                      v-model="config.pageTitle.direction"
                      class="form-check-input"
                      type="radio"
                      value="row"
                      id="kt_builder_page_title_direction_row"
                    />
                    <!--begin::Label-->
                    <label
                      class="form-check-label text-gray-700 fw-bold"
                      for="kt_builder_page_title_direction_row"
                      data-bs-toggle="tooltip"
                      data-kt-initialized="1"
                      >Row</label
                    >
                    <!--end::Label-->
                  </div>
                  <!--end::Check-->
                </div>
                <!--end::Option-->
              </div>
              <!--end::Form group-->
            </div>
          </div>
        </div>
      </div>
      <!--end::Body-->

      <!--begin::Footer-->
      <div class="card-footer py-6">
        <div class="row">
          <div class="col-lg-9">
            <button
              type="submit"
              id="kt_layout_builder_preview"
              class="btn btn-primary me-2"
            >
              <span class="indicator-label"> Preview </span>
              <span class="indicator-progress">
                Please wait...
                <span
                  class="spinner-border spinner-border-sm align-middle ms-2"
                ></span>
              </span>
            </button>

            <button
              @click="reset($event)"
              type="button"
              id="kt_layout_builder_reset"
              class="btn btn-active-light btn-color-muted fw-semobold"
            >
              Reset
            </button>
          </div>
        </div>
      </div>
      <!--end::Footer-->
    </form>
    <!--end::Form-->
  </div>

  <!--begin::Card-->
  <div class="card">
    <!--begin::Card Body-->
    <div class="card-body p-10 p-lg-15">
      <!--begin::Heading-->
      <h1 class="anchor fw-bold mb-5" id="overview">Generated configuration</h1>
      <!--end::Heading-->
      <div class="py-5">
        This config is used as a <b>{{ themeName }}</b> layout config, you can
        update default values inside file
        <code>src/core/config/DefaultLayoutConfig.ts</code>
      </div>
      <CodeHighlighter lang="json">{{ config }}</CodeHighlighter>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import { config } from "@/core/helpers/config";
import CodeHighlighter from "@/components/highlighters/CodeHighlighter.vue";
import { themeName } from "@/core/helpers/documentation";
import { themeMode, layout } from "@/core/helpers/config";
import { useStore } from "vuex";
import { Actions, Mutations } from "@/store/enums/StoreEnums";

export default defineComponent({
  name: "layout-builder",
  components: {
    CodeHighlighter,
  },
  setup() {
    const store = useStore();
    const tabIndex = ref("main");
    const layoutType = ref(layout.value);

    onMounted(() => {
      // set the tab from previous
      tabIndex.value = localStorage.getItem("builderTab") || "main";
    });

    /**
     * Reset config
     * @param event
     */
    const reset = (event) => {
      event.preventDefault();
      // remove existing saved config
      localStorage.removeItem("config");
      window.location.reload();
    };

    /**
     * Set active tab when the tab get clicked
     * @param event
     */
    const setActiveTab = (event) => {
      tabIndex.value = event.target.getAttribute("data-tab-index");
      // keep active tab
      localStorage.setItem("builderTab", tabIndex.value);
    };

    const onThemeModeChange = (e) => {
      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "general.mode",
        value: e.target.value,
      });
      store.dispatch(Actions.SET_THEME_MODE_ACTION, e.target.value);

      // save new config to localStorage
      localStorage.setItem("config", JSON.stringify(config.value));
    };

    /**
     * Submit form
     * @param event
     */
    const submit = (event) => {
      event.preventDefault();
      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "general.layout",
        value: layoutType,
      });
      // save new config to localStorage
      localStorage.setItem("config", JSON.stringify(config.value));
      window.location.reload();
    };

    return {
      tabIndex,
      config,
      reset,
      setActiveTab,
      submit,
      themeMode,
      themeName,
      layout,
      layoutType,
      onThemeModeChange,
    };
  },
});
</script>
