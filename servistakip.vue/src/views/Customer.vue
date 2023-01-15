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
            <div class="accordion-body">
              <div class="row mt-2">
                <div class="col-md-6 fv-row">
                  <label class="required fs-5 fw-semobold mb-2">Müşteri Unvanı</label>
                  <el-input readonly v-model="customer.title" class="input-with-select"> </el-input>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="cihazno" />
                    </div>
                  </div>
                </div>
                <div class="col-md-6 fv-row">
                  <label class="required fs-5 fw-semobold mb-2">Müşteri Sektörü</label>
                  <el-form-item prop="sectorId">
                    <el-select placeholder="Müşteri sektörü seçiniz" filterable clearable v-model="customer.sectorId">
                      <el-option
                        v-for="item in sectorList"
                        style="height: 30px"
                        :value="item.id"
                        :key="item.id"
                        :label="item.name"
                      />
                    </el-select>
                  </el-form-item>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="cihazno" />
                    </div>
                  </div>
                </div>
                <div class="col-md-12">
                  <el-button type="primary">
                    <el-icon> <Edit /> </el-icon>&nbsp; Güncelle
                  </el-button>
                </div>
              </div>
            </div>
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
            <div class="accordion-body">
              <div class="row">
                <div class="col-md-2">
                  <el-button type="success" round>
                    <el-icon> <Plus /> </el-icon>&nbsp;Yeni Adres Ekle</el-button
                  >
                </div>
                <div class="col-md-12 mt-2">
                  <el-table :data="customer.addresses" style="width: 100%">
                    <el-table-column prop="addressTitle" label="Adres Başlığı" />
                    <el-table-column prop="cityName" label="Şehir" />
                    <el-table-column prop="districtName" label="İlçe" />
                    <el-table-column prop="quarterName" label="Semt" />
                    <el-table-column prop="netAddress" label="Açık Adres" />
                    <el-table-column fixed="right" label="İşlemler">
                      <template #default>
                        <el-button link type="primary" size="small">Sil</el-button>
                        <el-button link type="primary" size="small">Düzenle</el-button>
                      </template>
                    </el-table-column>
                  </el-table>
                </div>
              </div>
            </div>
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
    </div>
    <!--end::Accordion-->
  </div>
  <!--end::Row-->
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';

interface SectorData {
  id: string;
  name: string;
}

export default defineComponent({
  components: {},
  setup() {
    var sectorList = ref<Array<SectorData>>([]);
    const store = useStore();
    return {
      sectorList,
      store,
    };
  },
  data() {
    return {
      customer: {
        id: '',
        title: '',
        sectorId: 0,
        addresses: [],
      },
    };
  },
  async created() {
    await this.getCustomer();
    await this.getSectorList();
  },
  methods: {
    async getCustomer() {
      if (this.store.state.customerId == undefined) {
        this.$router.push({
          name: 'dashboard',
          path: '/dashboard',
        });
      }

      await this.store
        .dispatch(Actions.GET_CUSTOMER, this.store.state.customerId)
        .then(result => {
          if (result.isSuccess) {
            this.customer = result.data;
            console.log(result.data);
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async getSectorList() {
      await this.store
        .dispatch(Actions.GET_SECTOR_LIST)
        .then(result => {
          if (result.isSuccess) {
            this.sectorList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
  },
});
</script>
