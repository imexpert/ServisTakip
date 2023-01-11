<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-10 mb-5 mb-xl-10">
    <!--begin::Col-->
    <div class="col-md-6 col-lg-6 col-xl-6 col-xxl-6 mb-md-5 mb-xl-10"></div>
    <!--end::Row-->
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  props: ['customerId'],
  components: {},
  created() {
    console.log(this.customerId);
  },
});
</script>
