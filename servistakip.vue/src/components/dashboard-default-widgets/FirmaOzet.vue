<template>
  <!--begin::List Widget 1-->
  <div class="card" :class="widgetClasses">
    <div class="card-header">
      <div class="d-flex align-items-center me-5">
        <el-dropdown split-button type="primary">
          İşlemler
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item @click="routeAddCustomer">Yeni Müşteri Ekle</el-dropdown-item>
              <el-dropdown-item @click="routeUpdateCustomer">Müşteri Düzenle</el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </div>
    </div>
    <!--begin::Body-->
    <div class="card-body">
      <!--begin::Form-->
      <Form class="form" id="customerInfoForm">
        <!--begin::Modal body-->
        <div class="modal-body">
          <!--begin::Scroll-->
          <div class="scroll-y me-n7 pe-7" id="kt_modal_new_address_scroll" data-kt-scroll="true"
            data-kt-scroll-activate="{default: false, lg: true}" data-kt-scroll-max-height="auto"
            data-kt-scroll-dependencies="#kt_modal_new_address_header"
            data-kt-scroll-wrappers="#kt_modal_new_address_scroll" data-kt-scroll-offset="300px">
            <!--begin::Input group-->
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="required fs-5 fw-semobold mb-2">Cihaz No</label>
                <el-input readonly v-model="firmaOzet.deviceId" class="input-with-select">
                  <template #append>
                    <el-button>
                      <el-icon>
                        <Search />
                      </el-icon>
                    </el-button>
                  </template>
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="cihazno" />
                  </div>
                </div>
              </div>

              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Cari Kod</label>
                <el-input readonly disabled v-model="firmaOzet.accountCode" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="carikod" />
                  </div>
                </div>
              </div>

              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Sektör</label>
                <el-input readonly disabled v-model="firmaOzet.customerSector" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="sektor" />
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-1">
              <div class="col-md-8 fv-row">
                <label class="required fs-5 fw-semobold mb-2">Firma Unvan</label>
                <el-input readonly v-model="firmaOzet.customerTitle" class="input-with-select">
                  <template #append>
                    <el-button>
                      <el-icon>
                        <Search />
                      </el-icon>
                    </el-button>
                  </template>
                </el-input>
                <!-- <Field
                  type="text"
                  class="form-control form-control-sm"
                  placeholder=""
                  name="unvan"
                  v-model="firmaOzet.customerTitle"
                /> -->
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="unvan" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Bölge</label>
                <el-input readonly disabled v-model="firmaOzet.regionCode" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="bolge" />
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Şehir</label>
                <el-input readonly disabled v-model="firmaOzet.cityName" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">İlçe</label>
                <el-input readonly disabled v-model="firmaOzet.districtName" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Semt</label>
                <el-input readonly disabled v-model="firmaOzet.quarterName" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Yetkili Ad Soyad</label>
                <el-input readonly disabled v-model="firmaOzet.authorizedName" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Yetkili Görevi</label>
                <el-input readonly disabled v-model="firmaOzet.authorizedTask" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Yetkili E-Mail</label>
                <el-input readonly disabled v-model="firmaOzet.authorizedEmail" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Tel</label>
                <el-input readonly disabled v-model="firmaOzet.authorizedPhone" class="input-with-select">
                </el-input>
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Form>
    </div>
    <!--end::Body-->
  </div>
  <!--end::List Widget 1-->


</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { ErrorMessage, Field, Form } from 'vee-validate';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { Search } from '@element-plus/icons-vue';

interface FirmaOzetData {
  customerId: string;
  customerTitle: string;
}

export default defineComponent({
  name: 'default-dashboard-widget-2',
  components: {
    ErrorMessage,
    Field,
    Form,
    Search,
  },
  setup() {
    const centerDialogVisible = ref(false);
    const store = useStore();
    const loading = ref<boolean>(false);

    var sectorList = [
      {
        id: 0,
        name: '',
      },
    ];

    return {
      loading,
      sectorList,
      store,
      centerDialogVisible,
    };
  },
  props: {
    widgetClasses: String,
  },
  data() {
    return {
      firmaOzet: {
        customerId: '',
        customerTitle: '',
        customerSectorId: 0,
        customerSector:'',
        accountCode:'',
        authorizedName:'',
        authorizedPhone:'',
        authorizedTask:'',
        cityName:'',
        authorizedEmail:'',
        deviceId:'',
        districtName:'',
        quarterName:'',
        regionCode:'',
      },
    };
  },
  async created() {
    await this.getLastTradedCustomer();
  },
  methods: {
    routeAddCustomer() {
      this.$router.push({
        name: 'customer',
        path: '/customer',
      });
    },
    routeUpdateCustomer() {
      this.store.commit('setCustomerId', this.firmaOzet.customerId);

      this.$router.push({
        name: 'customer',
        path: '/customer',
      });
    },
    async getLastTradedCustomer() {
      await this.store
        .dispatch(Actions.GET_LASTTRADED_CUSTOMER)
        .then(result => {
          if (result.isSuccess) {
            this.firmaOzet = result.data;
            console.log(result.data);
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
  },
});
</script>
