<template>
  <div class="row">
    <!--begin::Col-->
    <div class="col-md-6 col-lg-6 col-xl-6 col-xxl-6">
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
                    <el-input readonly disabled v-model="firmaOzet.accountCode" class="input-with-select"> </el-input>
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
                    <el-input readonly disabled v-model="firmaOzet.regionCode" class="input-with-select"> </el-input>
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
                    <el-input readonly disabled v-model="firmaOzet.cityName" class="input-with-select"> </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="departman" />
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">İlçe</label>
                    <el-input readonly disabled v-model="firmaOzet.districtName" class="input-with-select"> </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="departman" />
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">Semt</label>
                    <el-input readonly disabled v-model="firmaOzet.quarterName" class="input-with-select"> </el-input>
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
    </div>
    <!--begin::Col-->
    <div class="col-md-6 col-lg-6 col-xl-6 col-xxl-6">
      <div class="row">
        <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-5">
          <el-card class="box-card" style="height: 258px">
            <template #header>
              <div class="card-header">
                <div class="row">
                  <div class="col-md-9">
                    <span style="color: #f56c6c; font-size: 13pt; font-weight: 700">Sözleşmeler</span>
                  </div>
                  <div class="col-md-3" style="text-align: right">
                    <el-dropdown split-button type="success">
                      Tam Ekran
                      <template #dropdown>
                        <el-dropdown-menu>
                          <el-dropdown-item>Yeni Ekle</el-dropdown-item>
                          <el-dropdown-item>Aktar - Excel</el-dropdown-item>
                        </el-dropdown-menu>
                      </template>
                    </el-dropdown>
                  </div>
                </div>
              </div>
            </template>
            <div class="text item">
              <el-table
                :data="contracts"
                style="width: 100%"
                max-height="147"
                :default-sort="{ prop: 'startDate', order: 'descending' }"
              >
                <el-table-column label="Başlangıç Tarihi" width="160" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.startDateString }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Bitiş Tarihi" width="150" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.endDateString }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Sözleşme Kodu" width="160">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.contractCode }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Bakım Periyodu" width="160">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.maintenancePeriod }} Aylık</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Fiyat" width="120">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>-</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="#" fixed="right">
                  <template #default="scope">
                    <el-button size="small" type="primary" circle>
                      <el-icon>
                        <Edit />
                      </el-icon>
                    </el-button>
                    <el-button size="small" type="danger" circle>
                      <el-icon>
                        <Delete />
                      </el-icon>
                    </el-button>
                  </template>
                </el-table-column>
              </el-table>
            </div>
          </el-card>
        </div>
        <div class="col-md-4 col-lg-4 col-xl-4 col-xxl-4">
          <el-card class="box-card">
            <div class="row align-items-center">
              <div class="col-md-6 mx-auto">
                <label class="fs-5 fw-semobold">Model</label>
              </div>
              <div class="col-md-6">
                <el-input v-model="deviceModel.name"> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold">Seri No</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input v-model="device.serialNumber"> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold">Marka</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled v-model="deviceBrand.name"> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold">Montaj Tarihi</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled v-model="device.assemblyDateString"> </el-input>
              </div>
            </div>
          </el-card>
        </div>
        <div class="col-md-4 col-lg-4 col-xl-4 col-xxl-4">
          <el-card class="box-card">
            <div class="row">
              <div class="col-md-6">
                <label class="fs-5 fw-semobold mb-2">Söz. Tipi</label>
              </div>
              <div class="col-md-6">
                <el-input disabled> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold mb-2">Cihaz Durumu</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold mb-2">Bk. Durumu</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled> </el-input>
              </div>
            </div>
          </el-card>
        </div>

        <div class="col-md-4 col-lg-4 col-xl-4 col-xxl-4">
          <el-card class="box-card">
            <div class="row">
              <div class="col-md-6">
                <label class="fs-5 fw-semobold mb-2">S/B Sayaç</label>
              </div>
              <div class="col-md-6">
                <el-input disabled> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold mb-2">Renkli Sayaç</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold mb-2">Toplam Sayaç</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled> </el-input>
              </div>
            </div>
          </el-card>
        </div>
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col-md-8 col-lg-8 col-xl-8 col-xxl-8">
      <el-card class="box-card">
        <template #header>
          <div class="card-header">
            <div class="row">
              <div class="col-md-9">
                <span style="color: #f56c6c; font-size: 14pt; font-weight: 700">Açılan Servis Kayıtları</span>
              </div>
              <div class="col-md-3" style="text-align: right">
                <el-dropdown split-button type="success">
                  Tam Ekran
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item>Yeni Ekle</el-dropdown-item>
                      <el-dropdown-item>Aktar - Excel</el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </div>
            </div>
          </div>
        </template>
        <div class="text item">
          <el-table :data="contracts" style="width: 100%" :default-sort="{ prop: 'startDate', order: 'descending' }">
            <el-table-column label="Açılış Tarihi" width="160" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.startDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Tek.Ver.Tarihi" width="150" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.endDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Kapanış Tarihi" width="160">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.contractCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="S/B" width="160">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.maintenancePeriod }} Aylık</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Renkli" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>-</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Ser.Kod" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>-</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Tes.Kodu" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>-</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Son.Kodu" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>-</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>-</span>
                </div>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </el-card>
    </div>
    <div class="col-md-4 col-lg-4 col-xl-4 col-xxl-4">
      <el-card class="box-card">
        <div class="text item">
          <el-tabs tab-position="left" style="height: 268px" class="demo-tabs">
            <el-tab-pane label="Orjinal Toner">User</el-tab-pane>
            <el-tab-pane label="Muadil Toner">Config</el-tab-pane>
            <el-tab-pane label="Main Kit">Role</el-tab-pane>
            <el-tab-pane label="Cihaz">Task</el-tab-pane>
            <el-tab-pane label="K.Paneli">Task</el-tab-pane>
            <el-tab-pane label="K.Kılavuzu">Task</el-tab-pane>
            <el-tab-pane label="Teknik Bilgi">Task</el-tab-pane>
            <el-tab-pane label="Aksesuar">Task</el-tab-pane>
          </el-tabs>
        </div>
      </el-card>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { ErrorMessage, Field, Form } from 'vee-validate';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { Search } from '@element-plus/icons-vue';
import { object } from 'yup/lib/locale';

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
        customerSector: '',
        accountCode: '',
        authorizedName: '',
        authorizedPhone: '',
        authorizedTask: '',
        cityName: '',
        authorizedEmail: '',
        deviceId: '',
        districtName: '',
        quarterName: '',
        regionCode: '',
      },
      device: {
        addressId: '',
        assemblyDate: '',
        description: '',
        deviceModelId: '',
        serialNumber: '',
        status: false,
        assemblyDateString: '',
      },
      deviceModel: {
        colorType: '',
        companyId: '',
        deviceBrandId: '',
        isScannerExist: '',
        name: '',
        paperType: '',
        status: false,
      },
      deviceBrand: {
        companyId: '',
        name: '',
        status: false,
      },
      contracts: [],
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
            this.contracts = result.data.contracts;
            this.device = result.data.deviceDto;
            this.deviceModel = result.data.deviceDto.deviceModel;
            this.deviceBrand = result.data.deviceDto.deviceModel.deviceBrand;
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
<style>
.demo-tabs > .el-tabs__content {
  padding: 32px;
  color: #6b778c;
  font-size: 32px;
  font-weight: 600;
}

.el-tabs--right .el-tabs__content,
.el-tabs--left .el-tabs__content {
  height: 100%;
}
</style>
