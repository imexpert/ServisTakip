<template>
  <!-- begin::Scrolltop -->
  <div
    v-if="scrolltopDispaly"
    id="kt_scrolltop"
    ref="kt_scrolltop"
    class="scrolltop"
    data-kt-scrolltop="true"
  >
    <span class="svg-icon">
      <inline-svg src="media/icons/duotune/arrows/arr066.svg" />
    </span>
  </div>
  <!-- end::Scrolltop -->
</template>

<script lang="ts">
import { defineComponent, onMounted } from "vue";
import { ScrollTopComponent } from "@/assets/ts/components/_ScrollTopComponent";
import { scrolltopDispaly } from "@/core/helpers/config";

export default defineComponent({
  name: "KTScrollTop",
  components: {},
  setup() {
    onMounted(() => {
      ScrollTopComponent.reinitialization();
    });

    return {
      scrolltopDispaly,
    };
  },
});
</script>
