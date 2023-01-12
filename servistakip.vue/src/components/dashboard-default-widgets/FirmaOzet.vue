<template>
  <!--begin::List Widget 1-->
  <div class="card" :class="widgetClasses">
    <div class="card-header">
      <div class="d-flex align-items-center me-5">
        <el-dropdown split-button type="primary">
          İşlemler
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item @click="routeCustomerPage">Yeni Müşteri Ekle</el-dropdown-item>
              <el-dropdown-item>Müşteri Düzenle</el-dropdown-item>
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
          <div
            class="scroll-y me-n7 pe-7"
            id="kt_modal_new_address_scroll"
            data-kt-scroll="true"
            data-kt-scroll-activate="{default: false, lg: true}"
            data-kt-scroll-max-height="auto"
            data-kt-scroll-dependencies="#kt_modal_new_address_header"
            data-kt-scroll-wrappers="#kt_modal_new_address_scroll"
            data-kt-scroll-offset="300px"
          >
            <!--begin::Input group-->
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="required fs-5 fw-semobold mb-2">Cihaz No</label>
                <Field type="text" class="form-control form-control-sm" placeholder="" name="cihazno" />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="cihazno" />
                  </div>
                </div>
              </div>

              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Cari Kod</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="carikod"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="carikod" />
                  </div>
                </div>
              </div>

              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Sektör</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="sektor"
                />
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
                <Field type="text" class="form-control form-control-sm" placeholder="" name="unvan" />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="unvan" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Bölge</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="bolge"
                />
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
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">İlçe</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Semt</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
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
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Yetkili Görevi</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Yetkili E-Mail</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
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
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Cep Tel</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Dahili</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
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

  <el-dialog
    :before-close="handleClose"
    v-model="centerDialogVisible"
    title="Müşteri Ekleme / Güncelleme"
    width="40%"
    destroy-on-close
    center
  >
    <el-form
      id="kt_modal_new_target_form"
      @submit.prevent="submit()"
      :model="customerData"
      ref="formRef"
      status-icon
      :rules="rules"
      class="form"
    >
      <!--begin::Input group-->
      <div class="d-flex flex-column mb-1 fv-row">
        <!--begin::Label-->
        <label class="d-flex align-items-center fs-6 fw-bold mb-2">
          <span class="required">Unvan</span>
          <i
            class="fas fa-exclamation-circle ms-2 fs-7"
            data-bs-toggle="tooltip"
            title="Müşteri unvan bilgisini giriniz"
          ></i>
        </label>
        <!--end::Label-->

        <el-form-item prop="title">
          <el-input v-model="customerData.title" placeholder="Müşteri Unvanını giriniz" name="title"></el-input>
        </el-form-item>
      </div>
      <!--end::Input group-->

      <div class="row">
        <div class="col-md-6">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-1 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span class="required">Müşteri Sektörü</span>
              <i
                class="fas fa-exclamation-circle ms-2 fs-7"
                data-bs-toggle="tooltip"
                title="Müşterinin faaliyet gösterdiği sektörü seçiniz"
              ></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="sectorId">
              <el-select placeholder="Müşteri sektörü seçiniz" filterable clearable v-model="customerData.sectorId">
                <el-option
                  v-for="item in sectorList"
                  style="height: 30px"
                  :value="item.id"
                  :key="item.id"
                  :label="item.name"
                />
              </el-select>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-3 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span>Muhasebe Kodu</span>
              <i
                class="fas fa-exclamation-circle ms-2 fs-7"
                data-bs-toggle="tooltip"
                title="Müşteri unvan bilgisini giriniz"
              ></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="title">
              <el-input v-model="customerData.title" placeholder="Muhasebe kodunu giriniz" name="title"></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
      </div>

      <div class="row">
        <div class="col-md-4">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-1 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span class="required">Şehir</span>
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip" title="Şehir seçiniz"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="cityId">
              <el-select
                placeholder="Şehir seçiniz"
                @change="onCityChange()"
                filterable
                clearable
                v-model="customerData.cityId"
              >
                <el-option v-for="item in cityList" :key="item.id" :label="item.name" :value="item.id" />
              </el-select>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-4">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-1 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span class="required">İlçe</span>
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip" title="İlçe seçiniz"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="districtId">
              <el-select
                placeholder="İlçe seçiniz"
                @change="onDistrictChange()"
                filterable
                clearable
                :options="districtList"
                v-model="customerData.districtId"
              >
                <el-option v-for="item in districtList" :key="item.id" :label="item.name" :value="item.id" />
              </el-select>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-4">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-1 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span class="required">Semt</span>
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip" title="Semt seçiniz"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="querterId">
              <el-select
                placeholder="Semt seçiniz"
                filterable
                clearable
                :options="querterList"
                v-model="customerData.querterId"
              >
                <el-option v-for="item in querterList" :key="item.id" :label="item.name" :value="item.id" />
              </el-select>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-8 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span class="required">Açık Adres</span>
              <i
                class="fas fa-exclamation-circle ms-2 fs-7"
                data-bs-toggle="tooltip"
                title="Açık adres bilgisini giriniz"
              ></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="title">
              <el-input
                style="width: 100%"
                v-model="customerData.title"
                placeholder="Açık adres giriniz"
                name="title"
              ></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
      </div>
      <!--begin::Actions-->
      <div class="text-center">
        <!--begin::Button-->
        <button :data-kt-indicator="loading ? 'on' : null" class="btn btn-lg btn-primary" type="submit">
          <span v-if="!loading" class="indicator-label"> Kaydet </span>
          <span v-if="loading" class="indicator-progress">
            Lütfen Bekleyiniz...
            <span class="spinner-border spinner-border-sm align-middle ms-2"></span>
          </span>
        </button>
        <!--end::Button-->
      </div>
      <!--end::Actions-->
    </el-form>
  </el-dialog>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { hideModal } from '@/core/helpers/dom';
import { ErrorMessage, Field, Form } from 'vee-validate';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import SectorDropdown from '@/components/dropdown/SectorDropdown.vue';
import CityDropdown from '@/components/dropdown/CityDropdown.vue';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { ElMessageBox } from 'element-plus';

interface NewCustomerData {
  title: string;
  sectorId: string;
  cityId: String;
  districtId: String;
  querterId: String;
}

interface CityData {
  id: string;
  name: string;
}

interface DistrictData {
  id: string;
  name: string;
}

interface QuarterData {
  id: string;
  name: string;
}

export default defineComponent({
  name: 'default-dashboard-widget-2',
  components: {
    SectorDropdown,
    CityDropdown,
    ErrorMessage,
    Field,
    Form,
  },
  setup() {
    const centerDialogVisible = ref(false);

    const store = useStore();

    const formRef = ref<null | HTMLFormElement>(null);
    const loading = ref<boolean>(false);
    const kt_modal_new_customerRef = ref<null | HTMLElement>(null);

    var sectorList = [
      {
        id: 0,
        name: '',
      },
    ];

    var cityList = ref<Array<CityData>>([]);
    var districtList = ref<Array<DistrictData>>([]);
    var querterList = ref<Array<QuarterData>>([]);

    const customerData = ref<NewCustomerData>({
      title: '',
      sectorId: '',
      cityId: '',
      districtId: '',
      querterId: '',
    });

    const rules = ref({
      title: [
        {
          required: true,
          message: 'Müşteri unvanı boş geçilemez',
          trigger: 'blur',
        },
      ],
      sectorId: [
        {
          required: true,
          message: 'Müşteri sektörü boş geçilemez',
          trigger: 'blur',
        },
      ],
    });

    const submit = () => {
      if (!formRef.value) {
        return;
      }
      console.log(customerData);
      formRef.value.validate(valid => {
        if (valid) {
          loading.value = true;

          store
            .dispatch(Actions.ADD_CUSTOMER, customerData.value)
            .then(result => {
              loading.value = false;

              if (result.isSuccess) {
                Swal.fire({
                  text: 'Müşteri başarıyla eklendi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(() => {
                  hideModal(kt_modal_new_customerRef.value);
                });
              } else {
                Swal.fire({
                  title: 'Hata',
                  text: result.message,
                  icon: 'error',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam !',
                  customClass: {
                    confirmButton: 'btn fw-bold btn-light-danger',
                  },
                });
              }
            })
            .catch(() => {
              const [error] = Object.keys(store.getters.getErrors);
            });
        }
      });
    };
    return {
      loading,
      customerData,
      submit,
      rules,
      formRef,
      kt_modal_new_customerRef,
      sectorList,
      cityList,
      districtList,
      querterList,
      store,
      centerDialogVisible,
    };
  },
  props: {
    widgetClasses: String,
  },
  methods: {
    routeCustomerPage() {
      this.$router.push({
        name: 'customer',
        path: '/customer',
        params: {
            customerId: '5',
        },
      });
    },
    async addCustomer() {
      await this.getSectorList();
      await this.getCityList();
      this.centerDialogVisible = true;
    },
    handleClose() {
      ElMessageBox.confirm('İşlemi iptal etmek istiyor musunuz ?', 'Dikkat', {
        distinguishCancelAndClose: true,
        confirmButtonText: 'İptal Et',
        cancelButtonText: 'Vazgeç',
      })
        .then(() => {
          this.centerDialogVisible = false;
        })
        .catch(() => {
          // catch error
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
    async getCityList() {
      await this.store
        .dispatch(Actions.GET_CITY_LIST)
        .then(result => {
          if (result.isSuccess) {
            this.cityList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async onCityChange() {
      if (this.customerData.cityId == '') {
        this.customerData.districtId = '';
        this.customerData.querterId = '';
        this.querterList = [];
        this.districtList = [];
        return;
      }

      await this.store
        .dispatch(Actions.GET_DISTRICT_LIST, this.customerData.cityId)
        .then(result => {
          if (result.isSuccess) {
            this.customerData.districtId = '';
            this.customerData.querterId = '';

            this.querterList = [];
            this.districtList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async onDistrictChange() {
      if (this.customerData.districtId == '') {
        this.customerData.querterId = '';
        this.querterList = [];
        return;
      }

      await this.store
        .dispatch(Actions.GET_QUERTER_LIST, this.customerData.districtId)
        .then(result => {
          if (result.isSuccess) {
            this.customerData.querterId = '';
            this.querterList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
  },
});
</script>
