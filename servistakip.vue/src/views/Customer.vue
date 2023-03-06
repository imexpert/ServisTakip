<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-10 mb-5 mb-xl-10">
    <!--begin::Col-->
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-5 mb-xl-10">
      <el-tabs type="border-card" class="demo-tabs">
        <el-tab-pane label="Müşteri İşlemleri">
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
                  <el-option v-for="item in sectorList" style="height: 30px" :value="item.id" :key="item.id"
                    :label="item.name" />
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
                <el-icon>
                  <Edit />
                </el-icon>&nbsp; Güncelle
              </el-button>
            </div>
          </div>
        </el-tab-pane>
        <el-tab-pane label="Adres İşlemleri">
          <div class="row">
            <div class="col-md-2">
              <el-button type="success" round @click="addCustomerAddress">
                <el-icon>
                  <Plus />
                </el-icon>&nbsp;Yeni Adres Ekle</el-button>
            </div>
            <div class="col-md-12 mt-2">
              <el-table :data="customer.addresses" style="width: 100%">
                <el-table-column prop="addressTitle" label="Adres Başlığı" width="150px" />
                <el-table-column prop="accountCode" label="Muhasebe Kodu" width="150px" />
                <el-table-column prop="querter.district.city.name" label="Şehir" width="150px" />
                <el-table-column prop="querter.district.name" label="İlçe" width="150px" />
                <el-table-column prop="querter.name" label="Semt" width="200px" />
                <el-table-column prop="netAddress" label="Açık Adres" />
                <el-table-column fixed="right" label="İşlemler" width="200px">
                  <template #default>
                    <el-button link type="primary" size="small">Sil</el-button>
                    <el-button link type="primary" size="small">Düzenle</el-button>
                  </template>
                </el-table-column>
              </el-table>
            </div>
          </div>
        </el-tab-pane>
        <el-tab-pane label="Cihaz İşlemleri">
          <div class="row">
            <div class="col-md-2">
              <el-button type="success" round @click="addCustomerAddress">
                <el-icon>
                  <Plus />
                </el-icon>&nbsp;Yeni Cihaz Ekle</el-button>
            </div>
          
              <el-select placeholder="Adres seçiniz" @change="onAdressChange()" filterable clearable
                v-model="customerAdress.id">
                <el-option v-for="item in customer.addresses" :key="item.id" :label="item.addressTitle" :value="item.id" />
              </el-select>
        
            <div class="col-md-12 mt-2">
              <el-table :data="deviceList" style="width: 100%">
                <el-table-column prop="deviceModelId" label="Cihaz Model Id" width="150px" />
                <el-table-column prop="serialNumber" label="Seri Numarası" width="150px" />
                <el-table-column prop="assemlyDate" label="Kurulum Tarihi" width="150px" />
                <el-table-column prop="description" label="Açıklama" width="150px" />
                <el-table-column prop="status" label="Durum" width="200px" />
                <el-table-column fixed="right" label="İşlemler" width="200px">
                  <template #default>
                    <el-button link type="primary" size="small">Sil</el-button>
                    <el-button link type="primary" size="small">Düzenle</el-button>
                  </template>
                </el-table-column>
              </el-table>
            </div>
          </div>
        </el-tab-pane>
      </el-tabs>
    </div>
  </div>
  <!--end::Row-->

  <el-dialog :before-close="handleClose" v-model="centerDialogVisible" title="Adres Ekleme / Güncelleme" width="40%"
    destroy-on-close center>
    <el-form id="kt_modal_new_target_form" @submit.prevent="submit()" :model="customerAdress" ref="formRef" status-icon
      :rules="customerAddressRules" class="form">
      <div class="row">
        <div class="col-md-6">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-1 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span class="required">Adres Başlığı</span>
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip"
                title="Adres başlık bilgisini giriniz"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="addressTitle">
              <el-input v-model="customerAdress.addressTitle" placeholder="Adres başlığını giriniz"
                name="addressTitle"></el-input>
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
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip"
                title="Muhasebe kodunu giriniz"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="accountCode">
              <el-input v-model="customerAdress.accountCode" placeholder="Muhasebe kodunu giriniz"
                name="accountCode"></el-input>
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
              <el-select placeholder="Şehir seçiniz" @change="onCityChange()" filterable clearable
                v-model="customerAdress.cityId">
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
              <el-select placeholder="İlçe seçiniz" @change="onDistrictChange()" filterable clearable
                :options="districtList" v-model="customerAdress.districtId">
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

            <el-form-item prop="quarterId">
              <el-select placeholder="Semt seçiniz" filterable clearable :options="querterList"
                v-model="customerAdress.quarterId">
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
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip"
                title="Açık adres bilgisini giriniz"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="netAddress">
              <el-input style="width: 100%" v-model="customerAdress.netAddress" placeholder="Açık adres giriniz"
                name="netAddress"></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-1 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span>Yetkili Ad Soyad</span>
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip"
                title="Gerektiğinde iletişim kurulacak yetkili personel ad soyad"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="authorizedName">
              <el-input v-model="customerAdress.authorizedName" placeholder="Yetkili ad soyad bilgisini giriniz"
                name="authorizedName"></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-3 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span>Yetkili Görev</span>
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip"
                title="Gerektiğinde iletişim kurulacak yetkili personel görev"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="authorizedTask">
              <el-input v-model="customerAdress.authorizedTask" placeholder="Yetkili görev bilgisini giriniz"
                name="authorizedTask"></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-1 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span>Yetkili Telefon</span>
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip"
                title="Gerektiğinde iletişim kurulacak yetkili personel telefon"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="authorizedPhone">
              <el-input v-model="customerAdress.authorizedPhone" placeholder="Yetkili telefon bilgisini giriniz"
                name="authorizedPhone"></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6">
          <!--begin::Input group-->
          <div class="d-flex flex-column mb-3 fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold mb-2">
              <span>Yetkili E-Mail</span>
              <i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip"
                title="Gerektiğinde iletişim kurulacak yetkili personel e-mail"></i>
            </label>
            <!--end::Label-->

            <el-form-item prop="authorizedEmail">
              <el-input v-model="customerAdress.authorizedEmail" placeholder="Yetkili e-mail bilgisini giriniz"
                name="authorizedEmail"></el-input>
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
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { ErrorMessage } from 'vee-validate';
import { ElMessageBox } from 'element-plus';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { hideModal } from '@/core/helpers/dom';

interface SectorData {
  id: string;
  name: string;
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

interface CustomerAddressData {
  id: string,
  customerId:string,
  quarterId: string,
  districtId: string,
  cityId: string,
  addressTitle: string,
  accountCode: string,
  netAddress: string,
  authorizedName: string,
  authorizedTask: string,
  authorizedPhone: string,
  authorizedEmail: string,
  description: string,
}
interface DeviceData {
  addressId: string;
  deviceModelId: string;
  serialNumber: string;
  assemblyDateString: string;
  description: string;
  status: string;
}
interface CustomerData {
  sectorId: string;
  title: string;
  sector: string;
}
export default defineComponent({
  components: {
    ErrorMessage
  },
  setup() {
    const store = useStore();

    var sectorList = ref<Array<SectorData>>([]);
    var deviceList = ref<Array<DeviceData>>([]);
    var customerAdress = ref<CustomerAddressData>({
      id: '',
      customerId: store.state.customerId,
      quarterId: '',
      districtId: '',
      cityId: '',
      addressTitle: '',
      accountCode: '',
      netAddress: '',
      authorizedName: '',
      authorizedTask: '',
      authorizedPhone: '',
      authorizedEmail: '',
      description: '',
    });

    const loading = ref<boolean>(false);

    const centerDialogVisible = ref(false);
    const formRef = ref<null | HTMLFormElement>(null);

    

    var cityList = ref<Array<CityData>>([]);
    var districtList = ref<Array<DistrictData>>([]);
    var querterList = ref<Array<QuarterData>>([]);

    const customerAddressRules = ref({
      addressTitle: [
        {
          required: true,
          message: 'Adres başlığı girilmedi.',
          trigger: 'blur',
        },
      ],
      cityId: [
        {
          required: true,
          message: 'Şehir seçilmedi.',
          trigger: 'blur',
        },
      ],
      districtId: [
        {
          required: true,
          message: 'İlçe seçilmedi.',
          trigger: 'blur',
        },
      ],
      quarterId: [
        {
          required: true,
          message: 'Semt seçilmedi.',
          trigger: 'blur',
        },
      ],
      netAddress: [
        {
          required: true,
          message: 'Açık adres girilmedi.',
          trigger: 'blur',
        },
      ],
    });

    const kt_modal_new_customerRef = ref<null | HTMLElement>(null);

    const submit = () => {
      if (!formRef.value) {
        return;
      }
      console.log(customerAdress.value);
      formRef.value.validate(valid => {
        if (valid) {
          loading.value = true;

          store
            .dispatch(Actions.ADD_ADDRESS, customerAdress.value)
            .then(result => {
              loading.value = false;

              if (result.isSuccess) {
                Swal.fire({
                  text: 'Adres başarıyla eklendi.',
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
      sectorList,
      store,
      centerDialogVisible,
      customerAdress,
      customerAddressRules,
      cityList,
      districtList,
      querterList,
      submit,
      loading,
      formRef,
      kt_modal_new_customerRef,
      deviceList
    };
  },
  data() {
    return {
      customer: {
        id: '',
        title: '',
        sectorId: 0,
        addresses: []
      },
      device: {
        id: '',
        title: '',
        sectorId: 0,
        addresses: []
      },
    };
  },
  async created() {
    await this.getCustomer();
    await this.getAdresses();
    //await this.getDevices(addressId);
    await this.getSectorList();
  },
  methods: {
    async addCustomerAddress() {
      await this.getCityList();
      this.centerDialogVisible = true;
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
    async onAdressChange() {
      
        console.log(this.customerAdress);
        await this.getDevices(this.customerAdress.id);

      
    },
    async onCityChange() {
      if (this.customerAdress?.cityId == '') {
        this.customerAdress.districtId = '';
        this.customerAdress.quarterId = '';
        this.querterList = [];
        this.districtList = [];
        return;
      }

      this.customerAdress.districtId = '';
      this.customerAdress.quarterId = '';

      await this.store
        .dispatch(Actions.GET_DISTRICT_LIST, this.customerAdress?.cityId)
        .then(result => {
          if (result.isSuccess) {


            this.querterList = [];
            this.districtList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async onDistrictChange() {
      if (this.customerAdress.districtId == '') {
        this.customerAdress.quarterId = '';
        this.querterList = [];
        return;
      }

      await this.store
        .dispatch(Actions.GET_QUERTER_LIST, this.customerAdress.districtId)
        .then(result => {
          if (result.isSuccess) {
            this.customerAdress.quarterId = '';
            this.querterList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async getCustomer() {
      if (this.store.state.customerId == undefined) {
        this.$router.push({
          name: 'dashboard',
          path: '/dashboard',
        });
      }
      console.log("getcustomer");
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
          console.log("hata customer"+this.store.getters.getErrors);
        });
    },
    async getAdresses() {
      if (this.store.state.customerId == undefined) {
        this.$router.push({
          name: 'dashboard',
          path: '/dashboard',
        });
      }

      await this.store
        .dispatch(Actions.GET_ADRESSES_BYCID, this.store.state.customerId)
        .then(result => {
          if (result.isSuccess) {
            this.customer.addresses = result.data;
            console.log("----------------------------"+JSON.stringify(result.data) +"----------------------------");
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async getDevices(addressId) {
      if (this.store.state.customerId == undefined) {
        this.$router.push({
          name: 'dashboard',
          path: '/dashboard',
        });
      }

      await this.store
        .dispatch(Actions.GET_DEVICES_BYAID, addressId)
        .then(result => {
          if (result.isSuccess) {
            this.deviceList = result.data;
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
  },
});
</script>
