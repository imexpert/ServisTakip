<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-2">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card" shadow="hover">
        <template #header>
          <div class="card-header">
            <div class="row">
              <div class="col-md-2">
                <h4>Alınan Servisler</h4>
              </div>
              <div class="col-md-3">
                (<span style="font-weight: 800; font-size: 14px;"> Toplam Servis Sayısı :</span> <span
                  style="color:red;font-weight: bold;"> {{ receivedDeviceServiceList.length }}</span>)
              </div>
            </div>
          </div>
        </template>
        <div>
          <el-table :data="receivedDeviceServiceList" style="width: 100%" max-height="150" height="150">
            <el-table-column label="C.No" width="90">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" width="170" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>

            <el-table-column label="Müşteri Unvan">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.customer.title }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Model" width="160">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.deviceModel.name }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Seri No" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.serialNumber }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Servis Kodu" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceBootCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açıklama">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.bootDescription }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="#" fixed="left" width="170">
              <template #default="scope">
                <el-dropdown size="small" type="danger">
                  <el-button type="primary">
                    İşlem Listesi<el-icon class="el-icon--right">
                      <arrow-down />
                    </el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item @click="teknisyenAtaAc(scope.row.deviceId)">
                        <el-icon>
                          <ArrowRight />
                        </el-icon>&nbsp; Teknisyen Ata
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon>
                          <RemoveFilled />
                        </el-icon>&nbsp; İptal Et
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </el-card>
    </div>
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card" shadow="hover">
        <template #header>
          <div class="card-header">
            <div class="row">
              <div class="col-md-2">
                <h4>Teknisyendeki İşler</h4>
              </div>
              <div class="col-md-3">
                (<span style="font-weight: 800; font-size: 14px;"> Toplam Servis Sayısı :</span> <span
                  style="color:red;font-weight: bold;"> {{ technicianAssignedDeviceServiceList.length }}</span>)
              </div>
            </div>
          </div>
        </template>
        <div>
          <el-table :data="technicianAssignedDeviceServiceList" style="width: 100%" max-height="150" height="150">
            <el-table-column label="C.No" width="90">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" width="170" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Müşteri Unvan">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.customer.title }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen Veriliş Tarihi" width="210">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.userAssignDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen" width="180">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.user.firstname }} {{ scope.row.user.lastname }}</span>
                </div>
              </template>
            </el-table-column>

            <el-table-column label="Model" width="160">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.deviceModel.name }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Seri No" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.serialNumber }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Servis Kodu" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceBootCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açıklama">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.bootDescription }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="#" fixed="left" width="170">
              <template #default="scope">
                <el-dropdown size="small" type="danger">
                  <el-button type="primary">
                    İşlem Listesi<el-icon class="el-icon--right">
                      <arrow-down />
                    </el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item>
                        <el-icon>
                          <ArrowRight />
                        </el-icon>&nbsp; Talebi Kapat
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon>
                          <ArrowLeft />
                        </el-icon>&nbsp; Geri
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon>
                          <RemoveFilled />
                        </el-icon>&nbsp; İptal Et
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon>
                          <DeleteFilled />
                        </el-icon>&nbsp; Sil
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon>
                          <Share />
                        </el-icon>&nbsp; Teknisyen Raporu
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </el-card>
    </div>
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card" shadow="hover">
        <template #header>
          <div class="card-header">
            <h4><span>Parça Değişim İşleri</span></h4>
          </div>
        </template>
        <div>
          <el-table :data="partsExchangeDeviceServiceList" style="width: 100%" max-height="150" height="150">
            <el-table-column label="C.No" width="90">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" width="170" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>

            <el-table-column label="Müşteri Unvan">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.customer.title }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Model" width="160">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.deviceModel.name }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Seri No" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.serialNumber }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Servis Kodu" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceBootCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açıklama">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.bootDescription }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="#" fixed="left" width="170">
              <template #default="scope">
                <el-dropdown size="small" type="danger">
                  <el-button type="primary">
                    İşlem Listesi<el-icon class="el-icon--right">
                      <arrow-down />
                    </el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item>
                        <el-icon>
                          <ArrowRight />
                        </el-icon>&nbsp; Teknisyen Ata
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon>
                          <Share />
                        </el-icon>&nbsp; Sipariş Fişi
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon>
                          <List />
                        </el-icon>&nbsp; Parça Listesi
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon>
                          <RemoveFilled />
                        </el-icon>&nbsp; İptal Et
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </el-card>
    </div>
  </div>

  <el-dialog v-model="teknisyenRaporDialogVisible" title="Teknisyen Raporu" width="40%" destroy-on-close center>
    <div class="row">
      <el-form status-icon :rules="teknisyenAtaRules" ref="formAssignTechnicianRef" :model="assignTechnicianModel"
        @submit.prevent="teknisyenAtaSubmit()" label-width="120px" label-position="top">
        <div class="row">
          <div class="col-md-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Teknisyen</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="userId">
                <el-select placeholder="Teknisyen" filterable clearable v-model="assignTechnicianModel.userId">
                  <el-option v-for="item in technicianUserList" :key="item.id" :label="item.firstname + item.lastname"
                    :value="item.id">
                    <div class="row">
                      <div class="col-md-9" style="font-size: 12px">
                        {{ item.firstname }} {{ item.lastname }}
                      </div>
                    </div>
                  </el-option>
                </el-select>
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
    </div>
  </el-dialog>
</template>

<script lang="ts">
import {
  defineComponent,
  onMounted,
  onActivated,
  ref
} from 'vue';
import {
  useStore
} from 'vuex';
import {
  Actions
} from '@/store/enums/StoreEnums';
import {
  ErrorMessage
} from 'vee-validate';
import {
  ElMessageBox
} from 'element-plus';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import {
  hideModal
} from '@/core/helpers/dom';

interface ReceivedServiceData {
  linkedDeviceServiceId: string;
  deviceId: string;
  userId: string;
  userAssignDateString: string;
  name: string;
  phone: string;
  failureDateString: string;
  resultDateString: string;
  serviceBootCode: string;
  bootDescription: string;
  serviceResultCode: string;
  resultDescription: string;
  wBCount: string;
  colorCount: string;
  user: UserData;
  device: DeviceData;
}

interface UserData {
  id:string;
  firstname: string;
  lastname: string;
  email: string;
}

interface DeviceData {
  addressId: string;
  deviceModelId: string;
  serialNumber: string;
  assemblyDateString: string;
  description: string;
  status: string;
  address: AddressData;
  deviceModel: DeviceModelData;
}

interface AddressData {
  customerId: string;
  quarterId: string;
  serialNumber: string;
  addressTitle: string;
  accountCode: string;
  netAddress: string;
  authorizedName: string;
  authorizedTask: string;
  authorizedPhone: string;
  authorizedEmail: string;
  description: string;
  customer: CustomerData;
  querter: QuerterData;
  deviceModel: DeviceModelData;
}

interface CustomerData {
  sectorId: string;
  title: string;
  sector: string;
}

interface SectorData {
  Name: string;
}

interface QuerterData {
  name: string;
  quarterId: string;
  serialNumber: string;
  addressTitle: string;
  accountCode: string;
  netAddress: string;
  authorizedName: string;
  authorizedTask: string;
  authorizedPhone: string;
  authorizedEmail: string;
  description: string;
  district: DistrictData;
}

interface DistrictData {
  name: string;
  city: CityData;
}

interface CityData {
  name: string;
}

interface DeviceModelData {
  name: string;
  deviceBrandId: string;
  deviceBrand: DeviceBrandData;
}

interface DeviceBrandData {
  name: string;
  deviceType: DeviceTypeData;
}

interface DeviceTypeData {
  name: string;
}

interface AssignTechnicianData {
  id: string;
  userId: string;
}

export default defineComponent({
  components: {
    ErrorMessage,
  },
  setup() {
    const store = useStore();
    var teknisyenRaporDialogVisible = ref<boolean>(false);
    const loading = ref<boolean>(false);
    var selectedDeviceServiceId = ref<string>('');

    var receivedDeviceServiceList = ref<Array<ReceivedServiceData>>([]);
    var technicianAssignedDeviceServiceList = ref<Array<ReceivedServiceData>>([]);
    var partsExchangeDeviceServiceList = ref<Array<ReceivedServiceData>>([]);
    var technicianUserList = ref<Array<UserData>>([]);

    const formAssignTechnicianRef = ref<null | HTMLFormElement>(null);

    var assignTechnicianModel = ref<AssignTechnicianData>({
      id: '',
      userId: ''
    });

    const teknisyenAtaRules = ref({
      userId: [
        {
          required: true,
          message: 'Teknisyen seçilmedi.',
          trigger: 'blur',
        },
      ]
    });

    const teknisyenAtaSubmit = () => {
      if (!formAssignTechnicianRef.value) {
        return;
      }

      formAssignTechnicianRef.value.validate(async valid => {
        if (valid) {
          loading.value = true;
          assignTechnicianModel.value.id = selectedDeviceServiceId.value;
          await store
            .dispatch(Actions.UPDATE_ASSIGNTECHNICIANDEVICESERVICE, assignTechnicianModel.value)
            .then(result => {
              loading.value = false;
              console.clear();
              console.log(result)
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Servis başarıyla teknisyene atandı eklendi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  await getReceivedDeviceServiceList();
                  await getTechnicianAssignedDeviceServiceList();
                  hideModal(formAssignTechnicianRef.value);
                });
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
        }
      });
    };

    async function teknisyenAtaAc(deviceServiceId) {
      selectedDeviceServiceId.value = deviceServiceId;
      await getTechnicianList();
    };

    async function getTechnicianList() {
      await store
        .dispatch(Actions.GET_TECHNICIAN_LIST)
        .then(result => {
          if (result.isSuccess) {
            teknisyenRaporDialogVisible.value = true;
            technicianUserList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    };

    async function getReceivedDeviceServiceList() {
      await store
        .dispatch(Actions.GET_RECEIVEDDEVICESERVICE)
        .then(result => {
          if (result.isSuccess) {
            receivedDeviceServiceList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    };

    async function getTechnicianAssignedDeviceServiceList() {
      await store
        .dispatch(Actions.GET_TECHNICIANASSINEDDEVICESERVICE)
        .then(result => {
          if (result.isSuccess) {
            technicianAssignedDeviceServiceList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    };

    onMounted(async () => {
      await getReceivedDeviceServiceList();
      await getTechnicianAssignedDeviceServiceList();
    });

    return {
      store,
      receivedDeviceServiceList,
      technicianAssignedDeviceServiceList,
      partsExchangeDeviceServiceList,
      teknisyenRaporDialogVisible,
      teknisyenAtaRules,
      assignTechnicianModel,
      formAssignTechnicianRef,
      loading,
      selectedDeviceServiceId,
      technicianUserList,
      teknisyenAtaSubmit,
      getTechnicianList,
      teknisyenAtaAc,
      getReceivedDeviceServiceList,
      getTechnicianAssignedDeviceServiceList
    };
  },
});
</script>
