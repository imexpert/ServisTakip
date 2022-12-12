<template>
  <div
    class="d-flex flex-column flex-column-fluid bgi-position-y-bottom position-x-center bgi-no-repeat bgi-size-contain bgi-attachment-fixed"
    :style="{ backgroundImage: 'url(' + getIllustrationsPath('14.png') + ')' }"
  >
    <!--begin::Content-->
    <div class="d-flex flex-center flex-column flex-column-fluid p-10 pb-lg-20">
      <!--begin::Logo-->
      <a href="#" v-if="themeMode === 'dark'" class="mb-12">
        <img
          alt="Logo"
          src="media/logos/default-dark.svg"
          class="h-45px app-sidebar-logo-default"
        />
      </a>
      <a href="#" v-if="themeMode === 'light'" class="mb-12">
        <img
          alt="Logo"
          src="media/logos/default.svg"
          class="theme-dark-show h-45px"
        />
      </a>
      <!--end::Logo-->

      <router-view></router-view>
    </div>
    <!--end::Content-->

    <!--begin::Footer-->
    <div class="d-flex flex-center flex-column-auto p-10">
      <!--begin::Links-->
      <div class="d-flex align-items-center fw-semobold fs-6">
        <a href="#" class="text-muted text-hover-primary px-2">About</a>

        <a href="#" class="text-muted text-hover-primary px-2">Contact</a>

        <a href="#" class="text-muted text-hover-primary px-2">Contact Us</a>
      </div>
      <!--end::Links-->
    </div>
    <!--end::Footer-->
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, onUnmounted, computed } from "vue";
import { useStore } from "vuex";
import { Actions } from "@/store/enums/StoreEnums";
import { getIllustrationsPath } from "@/core/helpers/assets";

export default defineComponent({
  name: "auth-page-layout",
  components: {},
  setup() {
    const store = useStore();

    const themeMode = computed(() => {
      return store.getters.getThemeMode;
    });

    onMounted(() => {
      store.dispatch(Actions.ADD_BODY_CLASSNAME, "bg-body");
    });

    onUnmounted(() => {
      store.dispatch(Actions.REMOVE_BODY_CLASSNAME, "bg-body");
    });

    return {
      getIllustrationsPath,
      themeMode,
    };
  },
});
</script>
