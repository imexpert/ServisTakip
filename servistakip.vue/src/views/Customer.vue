<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-10 mb-5 mb-xl-10">
    <!--begin::Col-->
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-5 mb-xl-10">
      <!--begin::Accordion-->
<div class="accordion" id="kt_accordion_1">
  <div class="accordion-item">
    <h2 class="accordion-header" id="kt_accordion_1_header_1">
      <button
        class="accordion-button fs-4 fw-bold"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#kt_accordion_1_body_1"
        aria-expanded="true"
        aria-controls="kt_accordion_1_body_1"
      >
        Müşteri İşlemleri
      </button>
    </h2>
    <div
      id="kt_accordion_1_body_1"
      class="accordion-collapse collapse show"
      aria-labelledby="kt_accordion_1_header_1"
      data-bs-parent="#kt_accordion_1"
    >
      <div class="accordion-body">...</div>
    </div>
  </div>

  <div class="accordion-item">
    <h2 class="accordion-header" id="kt_accordion_1_header_2">
      <button
        class="accordion-button fs-4 fw-bold collapsed"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#kt_accordion_1_body_2"
        aria-expanded="false"
        aria-controls="kt_accordion_1_body_2"
      >
        Müşteri Adres İşlemleri
      </button>
    </h2>
    <div
      id="kt_accordion_1_body_2"
      class="accordion-collapse collapse"
      aria-labelledby="kt_accordion_1_header_2"
      data-bs-parent="#kt_accordion_1"
    >
      <div class="accordion-body">...</div>
    </div>
  </div>

  <div class="accordion-item">
    <h2 class="accordion-header" id="kt_accordion_1_header_3">
      <button
        class="accordion-button fs-4 fw-bold collapsed"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#kt_accordion_1_body_3"
        aria-expanded="false"
        aria-controls="kt_accordion_1_body_3"
      >
        Cihaz İşlemleri
      </button>
    </h2>
    <div
      id="kt_accordion_1_body_3"
      class="accordion-collapse collapse"
      aria-labelledby="kt_accordion_1_header_3"
      data-bs-parent="#kt_accordion_1"
    >
      <div class="accordion-body">...</div>
    </div>
  </div>
</div>
<!--end::Accordion-->
    </div>
    <!--end::Row-->
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  components: {},
  created() {
    console.log(this.$route.params.customerId);
  },
  methods:{
    async getCustomer() {
      
    }
  }
});
</script>
