<template>
  <router-view />
</template>

<script lang="ts">
import { defineComponent, nextTick, onMounted } from "vue";
import { useStore } from "vuex";
import { Mutations, Actions } from "@/store/enums/StoreEnums";
import { themeMode } from "@/core/helpers/config";
import { initializeComponents } from "@/core/plugins/keenthemes";

export default defineComponent({
  name: "app",
  setup() {
    const store = useStore();

    onMounted(() => {
      /**
       * Overrides the layout config using saved data from localStorage
       * remove this to use static config (@/core/config/DefaultLayoutConfig.ts)
       */
      store.commit(Mutations.OVERRIDE_LAYOUT_CONFIG);

      /**
       *  Sets a mode from configuration
       */
      store.dispatch(Actions.SET_THEME_MODE_ACTION, themeMode.value);

      nextTick(() => {
        initializeComponents();

        store.dispatch(Actions.REMOVE_BODY_CLASSNAME, "page-loading");
      });
    });
  },
});
</script>

<style lang="scss">
@import "~bootstrap-icons/font/bootstrap-icons.css";
@import "~apexcharts/dist/apexcharts.css";
@import "~quill/dist/quill.snow.css";
@import "~animate.css";
@import "~sweetalert2/dist/sweetalert2.css";
@import "~nouislider/distribute/nouislider.css";
@import "~@fortawesome/fontawesome-free/css/all.min.css";
@import "~socicon/css/socicon.css";
@import "~line-awesome/dist/line-awesome/css/line-awesome.css";
@import "~dropzone/dist/dropzone.css";
@import "~@vueform/multiselect/themes/default.css";
@import "~prism-themes/themes/prism-shades-of-purple.css";
@import "~element-plus/dist/index.css";

// Main demo style scss
@import "assets/sass/plugins";
@import "assets/sass/style";

//RTL version styles
//@import "assets/css/style.rtl.css";

#app {
  display: contents;
}
</style>
