<template>
  <div class="row" v-loading="loading">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12 mb-2">
      <el-card class="box-card">
        <template #header>
          <div class="card-header">
            <div class="row">
              <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
                <span class="mx-1" style="color: red; font-size: large"> SÖZLEŞME BASIM RAPORU </span>
              </div>
            </div>
          </div>
        </template>
        <div class="modal-body">
          <el-form
            status-icon
            :rules="newSorgulaRules"
            ref="formSorgulaRef"
            :model="filter"
            @submit.prevent="sorgulaSubmit()"
            label-width="120px"
            label-position="top"
          >
            <div class="row mb-3">
              <div class="col-md-12 col-lg-12 col-xl-4 col-xxl-4 col-sm-12 mb-2">
                <label class="required fs-5 fw-semobold mb-2">Firma Unvan</label>
                <el-select
                  filterable
                  class="arama"
                  remote
                  clearable
                  placeholder="Arama için en az 4 harf giriniz"
                  reserve-keyword
                  remote-show-suffix
                  v-model="filter.customerId"
                  :remote-method="remoteMusteriAramaMethod"
                  :loading="loading"
                >
                  <li class="el-select-dropdown__item">
                    <div class="row">
                      <div class="col-md-6">
                        <span style="font-weight: 900"> Unvan </span>
                      </div>
                      <div class="col-md-2">
                        <span style="font-weight: 900"> Semt </span>
                      </div>
                      <div class="col-md-3">
                        <span style="font-weight: 900"> Model </span>
                      </div>
                      <div class="col-md-1">
                        <span style="font-weight: 900"> Seri No </span>
                      </div>
                    </div>
                  </li>
                  <el-option v-for="item in customerInfoList" :key="item.id" :label="item.title" :value="item.id">
                    <div class="row">
                      <div class="col-md-6" style="font-size: 12px">
                        {{ item.title }}
                      </div>
                      <div class="col-md-2" style="font-size: 12px">
                        {{ item.querter }}
                      </div>
                      <div class="col-md-3" style="font-size: 12px">
                        {{ item.model }}
                      </div>
                      <div class="col-md-1" style="font-size: 12px">
                        {{ item.serialNo }}
                      </div>
                    </div>
                  </el-option>
                </el-select>
              </div>
              <!-- Şehir -->
              <div class="col-md-12 col-lg-2 col-xl-2 col-xxl-2 col-sm-12">
                <!--begin::Input group-->
                <div class="d-flex flex-column mb-1 fv-row">
                  <!--begin::Label-->
                  <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                    <span>Şehir</span>
                  </label>
                  <!--end::Label-->
                  <el-form-item prop="selectedSehir">
                    <el-select
                      placeholder="Şehir seçiniz"
                      @change="onSehirChange()"
                      filterable
                      clearable
                      v-model="filter.sehirId"
                    >
                      <el-option v-for="item in sehirList" :key="item.id" :label="item.name" :value="item.id">
                      </el-option>
                    </el-select>
                  </el-form-item>
                </div>
                <!--end::Input group-->
              </div>

              <!-- İlçe -->
              <div class="col-md-12 col-lg-2 col-xl-2 col-xxl-2 col-sm-12">
                <!--begin::Input group-->
                <div class="d-flex flex-column mb-1 fv-row">
                  <!--begin::Label-->
                  <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                    <span>İlçe</span>
                  </label>
                  <!--end::Label-->
                  <el-form-item prop="selectedIlce">
                    <el-select
                      @change="onIlceChange()"
                      placeholder="İlçe seçiniz"
                      filterable
                      clearable
                      v-model="filter.ilceId"
                    >
                      <el-option v-for="item in ilceList" :key="item.id" :label="item.name" :value="item.id">
                      </el-option>
                    </el-select>
                  </el-form-item>
                </div>
                <!--end::Input group-->
              </div>

              <!-- Semt -->
              <div class="col-md-12 col-lg-2 col-xl-2 col-xxl-2 col-sm-12">
                <!--begin::Input group-->
                <div class="d-flex flex-column mb-1 fv-row">
                  <!--begin::Label-->
                  <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                    <span>Semt</span>
                  </label>
                  <!--end::Label-->
                  <el-form-item prop="quarterId">
                    <el-select placeholder="Semt seçiniz" filterable clearable v-model="filter.semtId">
                      <el-option v-for="item in semtList" :key="item.id" :label="item.name" :value="item.id">
                      </el-option>
                    </el-select>
                  </el-form-item>
                </div>
                <!--end::Input group-->
              </div>
            </div>
            <div class="row mb-3">
              <!-- Model -->
              <div class="col-md-12 col-lg-2 col-xl-2 col-xxl-2 col-sm-12">
                <!--begin::Input group-->
                <div class="d-flex flex-column mb-1 fv-row">
                  <!--begin::Label-->
                  <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                    <span>Model</span>
                  </label>
                  <!--end::Label-->
                  <el-form-item prop="model">
                    <el-select
                      filterable
                      class="arama"
                      remote
                      clearable
                      placeholder="Model adı giriniz"
                      reserve-keyword
                      remote-show-suffix
                      v-model="filter.model"
                      :remote-method="remoteMethodModelName"
                      :loading="loading"
                    >
                      <li class="el-select-dropdown__item">
                        <div class="row">
                          <div class="col-md-7">
                            <span style="font-weight: 900"> Unvan </span>
                          </div>
                        </div>
                      </li>
                      <el-option v-for="item in deviceModelList" :key="item.id" :label="item.name" :value="item.id">
                        <div class="row">
                          <div class="col-md-7" style="font-size: 12px">
                            {{ item.name }}
                          </div>
                        </div>
                      </el-option>
                    </el-select>
                  </el-form-item>
                </div>
                <!--end::Input group-->
              </div>

              <!-- Seri No -->
              <div class="col-md-12 col-lg-2 col-xl-2 col-xxl-2 col-sm-12">
                <!--begin::Input group-->
                <div class="d-flex flex-column mb-1 fv-row">
                  <!--begin::Label-->
                  <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                    <span>Seri No</span>
                  </label>
                  <!--end::Label-->
                  <el-form-item prop="serialNo">
                    <el-input v-model="filter.serialNo" class="input-with-select"> </el-input>
                  </el-form-item>
                </div>
                <!--end::Input group-->
              </div>

              <!-- Başlangıç Tarihi -->
              <div class="col-md-12 col-lg-6 col-xl-2 col-xxl-2 col-sm-12">
                <!--begin::Input group-->
                <div class="d-flex flex-column mb-1 fv-row">
                  <!--begin::Label-->
                  <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                    <span>Başlangıç Tarihi</span>
                  </label>
                  <!--end::Label-->
                  <el-form-item prop="baslangicTarihi">
                    <el-date-picker
                      v-model="filter.baslangicTarihi"
                      format="DD.MM.YYYY"
                      type="datetime"
                      placeholder="Başlangıç tarihini seçiniz"
                      :shortcuts="shortcuts"
                    />
                  </el-form-item>
                </div>
                <!--end::Input group-->
              </div>

              <!-- Bitiş Tarihi -->
              <div class="col-md-12 col-lg-6 col-xl-2 col-xxl-2 col-sm-12">
                <!--begin::Input group-->
                <div class="d-flex flex-column mb-1 fv-row">
                  <!--begin::Label-->
                  <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                    <span>Bitiş Tarihi</span>
                  </label>
                  <!--end::Label-->
                  <el-form-item prop="quarterId">
                    <el-date-picker
                      v-model="filter.bitisTarihi"
                      format="DD.MM.YYYY HH:mm:ss"
                      type="datetime"
                      placeholder="Bitiş tarihini seçiniz"
                      :shortcuts="shortcuts"
                    />
                  </el-form-item>
                </div>
                <!--end::Input group-->
              </div>
            </div>
            <div class="row mb-3">
              <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
                <!--begin::Input group-->
                <div class="d-flex flex-column mb-1 fv-row">
                  <!--begin::Label-->
                  <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                    <span>Sözleşme Kodları</span>
                  </label>
                  <!--end::Label-->
                  <el-form-item prop="quarterId">
                    <el-checkbox-group v-model="filter.sozlesmeKodlari">
                      <el-checkbox
                        border
                        :title="soz.name"
                        class="p-2 m-2"
                        v-for="soz in sozlesmeKodList"
                        :key="soz.code"
                        :value="soz.code"
                        :label="soz.code"
                        >{{ soz.code }}</el-checkbox
                      >
                    </el-checkbox-group>
                  </el-form-item>
                </div>
                <!--end::Input group-->
              </div>
            </div>
            <div class="row mb-3">
              <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
                <button :data-kt-indicator="loading ? 'on' : null" class="btn btn-lg btn-primary" type="submit">
                  Sorgula
                </button>
              </div>
            </div>
          </el-form>
          <div class="row mb-3">
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
              <el-table
                :data="sozlesmeList"
                style="width: 100%; font-size: 12px"
                height="330"
                max-height="330px"
                :default-sort="{ prop: 'startDate', order: 'descending' }"
              >
                <el-table-column type="index" width="50" />
                <el-table-column label="Firma Unvan" width="440" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.address.customer.title }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Şehir" width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.address.querter.district.city.name }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="İlçe" width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.address.querter.district.name }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Semt" width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.address.querter.name }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Tip Adı" width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.deviceModel.deviceBrand.deviceType.name }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Marka Adı" width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.deviceModel.deviceBrand.name }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Model Adı" width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.deviceModel.name }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Seri No" width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.serialNumber }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Montaj T." width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.device.assemblyDateString }}</span>
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
                <el-table-column label="Başlangıç T." width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.startDateString }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Bitiş T." width="140" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.endDateString }}</span>
                    </div>
                  </template>
                </el-table-column>
              </el-table>
            </div>
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12 mt-5">
              <el-pagination
                v-model:current-page="filter.currentPage"
                background
                :page-sizes="[10, 20, 50, 100]"
                layout="total, sizes, prev, pager, next, jumper"
                :total="totalCount"
                @size-change="handleSizeChange"
                @current-change="handleCurrentChange"
              />
            </div>
          </div>
        </div>
      </el-card>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { useRouter } from 'vue-router';

import Swal from 'sweetalert2/dist/sweetalert2.js';
import { ICustomerListData } from '@/core/data/CustomerListData';
import loading from 'element-plus/es/components/loading';
import { ICityData } from '@/core/data/CityData';
import { IDistrictData } from '@/core/data/DistrictData';
import { IQuerterData } from '@/core/data/QuerterData';
import { IDeviceModelData } from '@/core/data/DeviceModelData';
import { IContractCodeData } from '@/core/data/ContractCodeData';
import { IContractData } from '@/core/data/ContractData';

interface ISozlesmeBasimRaporFilter {
  customerId: string | null;
  sehirId: string | null;
  ilceId: string | null;
  semtId: string | null;
  model: string | null;
  serialNo: string | null;
  sozlesmeKodlari: Array<string> | null;
  baslangicTarihi: Date | null;
  bitisTarihi: Date | null;
  currentPage: number | null;
  pageSize: number | null;
  rowCount: number | null;
}

export default defineComponent({
  name: 'sozlesmeBasimRapor',

  setup() {
    const store = useStore();
    const router = useRouter();

    const loading = ref<boolean>(false);

    var totalCount = ref<number>(0);
    var customerInfoList = ref<Array<ICustomerListData>>([]);
    var sehirList = ref<Array<ICityData>>([]);
    var ilceList = ref<Array<IDistrictData>>([]);
    var semtList = ref<Array<IQuerterData>>([]);
    var deviceModelList = ref<Array<IDeviceModelData>>([]);
    var sozlesmeKodList = ref<Array<IContractCodeData>>([]);
    var sozlesmeList = ref<Array<IContractData>>([]);

    const formSorgulaRef = ref<null | HTMLFormElement>(null);

    const newSorgulaRules = ref({});

    const shortcuts = [
      {
        text: 'Bugün',
        value: new Date(),
      },
      {
        text: 'Dün',
        value: () => {
          const date = new Date();
          date.setTime(date.getTime() - 3600 * 1000 * 24);
          return date;
        },
      },
    ];

    var filter = ref<ISozlesmeBasimRaporFilter>({
      customerId: null,
      ilceId: null,
      sehirId: null,
      semtId: null,
      model: null,
      serialNo: null,
      sozlesmeKodlari: [],
      baslangicTarihi: null,
      bitisTarihi: null,
      currentPage: 1,
      pageSize: 10,
      rowCount: 0,
    });

    async function getSehirList() {
      await store
        .dispatch(Actions.GET_CITY_LIST)
        .then(result => {
          if (result.isSuccess) {
            sehirList.value = result.data;
            loading.value = false;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getSozlesmeKodList() {
      await store
        .dispatch(Actions.GET_CONTRACTCODE_LIST)
        .then(result => {
          if (result.isSuccess) {
            console.log(result.data);
            sozlesmeKodList.value = result.data;
            loading.value = false;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getDeviceModelList() {
      await store
        .dispatch(Actions.GET_DEVICEMODELLIST)
        .then(result => {
          if (result.isSuccess) {
            deviceModelList.value = result.data;
            loading.value = false;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    const remoteMusteriAramaMethod = async (query: string) => {
      if (query && query.length > 3) {
        loading.value = true;
        await store
          .dispatch(Actions.GET_CUSTOMER_BY_FILTER, query)
          .then(result => {
            loading.value = false;

            if (result.isSuccess) {
              customerInfoList.value = result.data;
            } else {
              Swal.fire({
                title: 'Hata',
                text: result.message,
                icon: 'error',
                buttonsStyling: false,
                confirmButtonText: 'Tamam !',
                customClass: {
                  confirmButton: 'btn fw-bold btn-danger',
                },
              });
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      } else {
        customerInfoList.value = [];
      }
    };

    const remoteMethodModelName = async (query: string) => {
      if (query && query.length > 2) {
        loading.value = true;
        await store
          .dispatch(Actions.GET_MODEL_BY_NAME_FILTER, query)
          .then(result => {
            loading.value = false;
            if (result.isSuccess) {
              deviceModelList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      } else {
        deviceModelList.value = [];
      }
    };

    async function onSehirChange() {
      filter.value.ilceId = null;
      filter.value.semtId = '';
      semtList.value = [];
      ilceList.value = [];

      loading.value = true;

      if (filter.value.sehirId) {
        await store
          .dispatch(Actions.GET_DISTRICT_LIST, filter.value.sehirId)
          .then(result => {
            if (result.isSuccess) {
              ilceList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      }

      loading.value = false;
    }

    async function onIlceChange() {
      filter.value.semtId = '';
      semtList.value = [];

      loading.value = true;

      if (filter.value.ilceId) {
        await store
          .dispatch(Actions.GET_QUERTER_LIST, filter.value.ilceId)
          .then(result => {
            if (result.isSuccess) {
              semtList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      }

      loading.value = false;
    }

    const handleCurrentChange = async (val: number) => {
      filter.value.currentPage = val;
      await getSozlesmeBasimList();
    };

    const handleSizeChange = async (val: number) => {
      filter.value.pageSize = val;
      await getSozlesmeBasimList();
    };

    const sorgulaSubmit = () => {
      if (!formSorgulaRef.value) {
        return;
      }

      formSorgulaRef.value.validate(async valid => {
        if (valid) {
          loading.value = true;

          filter.value.currentPage = 1;
          filter.value.pageSize = 10;
          await getSozlesmeBasimList();

          loading.value = false;
        }
      });
    };

    async function getSozlesmeBasimList() {
      await store
        .dispatch(Actions.GET_SOZLESMEBASIM, filter.value)
        .then(result => {
          loading.value = false;
          if (result.isSuccess) {
            totalCount.value = result.pageCount;
            sozlesmeList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    onMounted(async () => {
      loading.value = true;
      await getSehirList();
      await getDeviceModelList();
      await getSozlesmeKodList();
      loading.value = false;
    });

    return {
      filter,
      loading,
      customerInfoList,
      semtList,
      ilceList,
      sehirList,
      deviceModelList,
      sozlesmeKodList,
      shortcuts,
      sozlesmeList,
      formSorgulaRef,
      newSorgulaRules,
      totalCount,
      remoteMusteriAramaMethod,
      remoteMethodModelName,
      onIlceChange,
      onSehirChange,
      sorgulaSubmit,
      handleSizeChange,
      handleCurrentChange,
    };
  },
});
</script>
<style>
.arama {
  border: 1px solid #ebd72a;
  border-radius: 5px;
}
</style>
