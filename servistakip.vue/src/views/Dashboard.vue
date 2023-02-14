<template>
  <FirmaOzet widget-classes="mb-5 mb-xxl-8" />
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import FirmaOzet from '@/components/dashboard-default-widgets/FirmaOzet.vue';
import Sozlesme from '@/components/dashboard-default-widgets/Sozlesme.vue';

export default defineComponent({
  name: 'main-dashboard',
  components: {
    FirmaOzet,
    Sozlesme,
  },
});
</script>
