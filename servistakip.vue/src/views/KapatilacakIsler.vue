<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-2">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-tabs type="border-card" style="height: 770px">
        <KapatilacakServisler ref="kapatilacakServislerRef" />
        <GonderilecekTeklifler ref="gonderilecekTekliflerRef" />
        <GonderilenTeklifler ref="gonderilenTekliflerRef" />
      </el-tabs>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue';
import KapatilacakServisler from '@/components/partial/KapatilacakServisler.vue';
import GonderilecekTeklifler from '@/components/partial/GonderilecekTeklifler.vue';
import GonderilenTeklifler from '@/components/partial/GonderilenTeklifler.vue';

export default defineComponent({
  components: {
    KapatilacakServisler,
    GonderilecekTeklifler,
    GonderilenTeklifler,
  },
  setup() {
    const kapatilacakServislerRef = ref<null | HTMLFormElement>(null);
    const gonderilecekTekliflerRef = ref<null | HTMLFormElement>(null);
    const gonderilenTekliflerRef = ref<null | HTMLFormElement>(null);

    onMounted(async () => {
      await kapatilacakServislerRef.value?.getirKapatilacakIslerList();
      await gonderilecekTekliflerRef.value?.getToBeOfferedDeviceServiceList();
      await gonderilenTekliflerRef.value?.getSentOfferedDeviceServiceList();
    });

    return {
      kapatilacakServislerRef,
      gonderilecekTekliflerRef,
      gonderilenTekliflerRef,
    };
  },
});
</script>

<style>
.tableHeader {
  color: black;
  font-size: 15px;
  border-bottom: 2px solid black;
}

.sort-caret {
  color: red;
}

.tableClass {
  border: 2px solid var(--el-border-color);
  width: 100%;
  font-size: 13px;
  color: black;
}
</style>
