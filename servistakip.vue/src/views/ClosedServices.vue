<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-2">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-tabs type="border-card" style="height: 770px">
        <el-tab-pane :label="kapatilacakServislerLabel">
          <KapatilacakIsler ref="kapatilacakIslerRef"/>
        </el-tab-pane>
        <el-tab-pane :label="gonderilecekTekliflerLabel">
          <GonderilecekTeklifler ref="gonderilecekTekliflerRef" />
        </el-tab-pane>
        <el-tab-pane :label="gonderilenTekliflerLabel">
          <GonderilenTeklifler ref="gonderilenTekliflerRef" />
        </el-tab-pane>
      </el-tabs>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue';
import { ErrorMessage } from 'vee-validate';
import KapatilacakIsler from '@/components/partial/KapatilacakIsler.vue';
import GonderilecekTeklifler from   '@/components/partial/GonderilecekTeklifler.vue';
import GonderilenTeklifler from   '@/components/partial/GonderilenTeklifler.vue';

export default defineComponent({
  components: {
    ErrorMessage,
    KapatilacakIsler,
    GonderilecekTeklifler,
    GonderilenTeklifler
  },
  setup() {
    const kapatilacakIslerRef = ref<null | HTMLFormElement>(null);
    const gonderilecekTekliflerRef = ref<null | HTMLFormElement>(null);
    const gonderilenTekliflerRef = ref<null | HTMLFormElement>(null);

    const kapatilacakServislerLabel = ref<string>('Kapatılacak İşler');
    const gonderilecekTekliflerLabel = ref<string>('Gönderilecek Teklifler');
    const gonderilenTekliflerLabel = ref<string>('Gönderilen Teklifler');

    onMounted(async () => {
      await kapatilacakIslerRef.value?.getirKapatilacakIslerList();
      await gonderilecekTekliflerRef.value?.getToBeOfferedDeviceServiceList();
      await gonderilenTekliflerRef.value?.getSentOfferedDeviceServiceList();
    });

    return {
      kapatilacakIslerRef,
      gonderilecekTekliflerRef,
      gonderilenTekliflerRef,
      kapatilacakServislerLabel,
      gonderilecekTekliflerLabel,
      gonderilenTekliflerLabel
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

  .sort-caret{
    color: red;
  }

  .tableClass{
    border: 2px solid var(--el-border-color);
    width: 100%; 
    font-size: 13px; 
    color: black;
  }
</style>
