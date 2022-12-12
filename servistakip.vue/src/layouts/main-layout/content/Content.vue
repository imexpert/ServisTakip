<template>
  <div id="kt_app_content" class="app-content flex-column-fluid">
    <!--begin::Content container-->
    <div
      id="kt_app_content_container"
      class="app-container"
      :class="{
        'container-fluid': contentWidthFluid,
        'container-xxl': !contentWidthFluid,
      }"
    >
      <router-view></router-view>
    </div>
    <!--end::Content container-->
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { contentWidthFluid } from "@/core/helpers/config";

export default defineComponent({
  name: "default-layout-content",
  components: {},
  setup() {
    return {
      contentWidthFluid,
    };
  },
});
</script>
