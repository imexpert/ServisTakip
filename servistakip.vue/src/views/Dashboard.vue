<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-10 mb-5 mb-xl-10">
    <!--begin::Col-->
    <div class="col-md-6 col-lg-6 col-xl-6 col-xxl-6 mb-md-5 mb-xl-10">
      <FirmaOzet widget-classes="mb-5 mb-xxl-8" />
    </div>
    <!--end::Row-->
    <!--begin::Col-->
    <div class="col-md-6 col-lg-6 col-xl-6 col-xxl-6 mb-md-5 mb-xl-10">
      <Sozlesme cihazId="6" />
    </div>
    <!--end::Row-->
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import FirmaOzet from '@/components/dashboard-default-widgets/FirmaOzet.vue';
import Sozlesme from '@/components/dashboard-default-widgets/Sozlesme.vue';

export default defineComponent({
  name: 'main-dashboard',
  components: {
    FirmaOzet,
    Sozlesme
  },
});
</script>
