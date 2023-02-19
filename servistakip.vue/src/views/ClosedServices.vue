<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-2">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card" shadow="hover">
        <template #header>
          <div class="card-header">
            <div class="row">
              <div class="col-md-2">
                <h4>Kapatılacak İşler</h4>
              </div>
              <div class="col-md-3">
                (<span style="font-weight: 800; font-size: 14px"> Toplam Servis Sayısı :&nbsp;</span>
                <span style="color: red; font-weight: bold"> {{ closedDeviceServiceList.length }}</span
                >)
              </div>
            </div>
          </div>
        </template>
        <div>
          <el-table :data="closedDeviceServiceList" style="width: 100%" max-height="150" height="150">
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
                      <el-dropdown-item @click="getClosedService(scope.row.id)">
                        <el-icon> <ArrowRight /> </el-icon>&nbsp; Talep Sonlandır
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon> <ArrowLeft /> </el-icon>&nbsp; Teknisyene Gönder
                      </el-dropdown-item>
                      <el-dropdown-item>
                        <el-icon> <RemoveFilled /> </el-icon>&nbsp; İptal Et
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
                <h4>Gönderilecek Teklifler</h4>
              </div>
              <div class="col-md-3">
                (<span style="font-weight: 800; font-size: 14px"> Toplam Teklif Sayısı :&nbsp;</span>
                <span style="color: red; font-weight: bold"> {{ technicianAssignedDeviceServiceList.length }}</span
                >)
              </div>
            </div>
          </div>
        </template>
        <div></div>
      </el-card>
    </div>
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card" shadow="hover">
        <template #header>
          <div class="card-header">
            <h4><span>Gönderilen Teklifler</span></h4>
          </div>
        </template>
        <div></div>
      </el-card>
    </div>
  </div>

  <el-dialog v-model="talepSonlandirDialogVisible" title="Talep Sonlandırma" width="40%" destroy-on-close center>
    <div class="row">
      <el-form
        status-icon
        :rules="talepSonlandirRules"
        ref="talepSonlandirRef"
        :model="closedServiceModel"
        @submit.prevent="talepSonlandirSubmit()"
        label-width="120px"
        label-position="top"
      >
        <div class="row">
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Servis Kodu</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="serviceBootCode">
                <el-input v-model="deviceServiceItem.serviceBootCode" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Açılış Tarihi</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="failureDate">
                <el-input v-model="deviceServiceItem.failureDateString" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Tespit Kodu</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="detectionCode">
                <el-select placeholder="Tespit Kodu" filterable clearable v-model="deviceServiceItem.detectionCode">
                  <el-option v-for="item in detectionCodeList" :key="item.code" :label="item.name" :value="item.code">
                    <div class="row">
                      <div class="col-md-9" style="font-size: 12px">{{ item.code }} {{ item.name }}</div>
                    </div>
                  </el-option>
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Tespit Açıklama</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="detectionDescription">
                <el-input v-model="deviceServiceItem.detectionDescription"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Açıklama</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="bootDescription">
                <el-input v-model="deviceServiceItem.bootDescription" disabled></el-input>
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
import { defineComponent, onMounted, onActivated, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { ErrorMessage } from 'vee-validate';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { hideModal } from '@/core/helpers/dom';
import PDFViewer from 'pdf-viewer-vue';
import { IAssignTechnicianData } from '@/core/data/AssignTechnicianData';
import { IDeviceServiceData } from '@/core/data/DeviceServiceData';
import { IUserData } from '@/core/data/UserData';
import { IDetectionCodeData } from '@/core/data/DetectionCodeData';

export default defineComponent({
  components: {
    ErrorMessage,
    PDFViewer,
  },
  setup() {
    const store = useStore();
    var talepSonlandirDialogVisible = ref<boolean>(false);
    var teknisyenRaporDialogVisible = ref<boolean>(false);
    var raporDialogVisible = ref<boolean>(false);
    var teknisyenRaporu = ref<string>('');
    const loading = ref<boolean>(false);
    var selectedDeviceServiceId = ref<string>('');

    var closedDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var deviceServiceItem = ref<IDeviceServiceData>({});
    var technicianAssignedDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var partsExchangeDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var technicianUserList = ref<Array<IUserData>>([]);
    var detectionCodeList = ref<Array<IDetectionCodeData>>([]);

    const talepSonlandirRef = ref<null | HTMLFormElement>(null);

    var closedServiceModel = ref<IDeviceServiceData>();

    const talepSonlandirRules = ref({
      userId: [
        {
          required: true,
          message: 'Teknisyen seçilmedi.',
          trigger: 'blur',
        },
      ],
    });

    async function getClosedService(selectedId) {
      var d = closedDeviceServiceList.value.find(s => s.id === selectedId);
      deviceServiceItem.value.serviceBootCode = d?.serviceBootCode;
      deviceServiceItem.value.failureDateString = d?.failureDateString;
      deviceServiceItem.value.bootDescription = d?.bootDescription;
      talepSonlandirDialogVisible.value = true;

      await getDetectionCodeList();
    }

    const talepSonlandirSubmit = () => {
      if (!talepSonlandirRef.value) {
        return;
      }

      talepSonlandirRef.value.validate(async valid => {
        if (valid) {
          loading.value = true;

          await store
            .dispatch(Actions.UPDATE_ASSIGNTECHNICIANDEVICESERVICE, closedServiceModel.value)
            .then(result => {
              loading.value = false;
              console.clear();
              console.log(result);
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
                  talepSonlandirDialogVisible.value = false;
                  await getclosedDeviceServiceList();
                  hideModal(talepSonlandirRef.value);
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

    async function getclosedDeviceServiceList() {
      await store
        .dispatch(Actions.GET_CLOSEDDEVICESERVICE)
        .then(result => {
          if (result.isSuccess) {
            closedDeviceServiceList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getDetectionCodeList() {
      await store
        .dispatch(Actions.GET_DETECTIONCODE_LIST)
        .then(result => {
          if (result.isSuccess) {
            detectionCodeList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    onMounted(async () => {
      await getclosedDeviceServiceList();
    });

    return {
      store,
      closedDeviceServiceList,
      technicianAssignedDeviceServiceList,
      partsExchangeDeviceServiceList,
      talepSonlandirDialogVisible,
      teknisyenRaporDialogVisible,
      raporDialogVisible,
      talepSonlandirRules,
      closedServiceModel,
      talepSonlandirRef,
      loading,
      selectedDeviceServiceId,
      technicianUserList,
      teknisyenRaporu,
      deviceServiceItem,
      detectionCodeList,
      talepSonlandirSubmit,
      getclosedDeviceServiceList,
      getClosedService,
    };
  },
});
</script>
