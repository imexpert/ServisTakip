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
                      <el-dropdown-item @click="returnDeviceServiceToTechnician(scope.row.id)">
                        <el-icon> <ArrowLeft /> </el-icon>&nbsp; Teknisyene Gönder
                      </el-dropdown-item>
                      <el-dropdown-item @click="cancelDeviceService(scope.row.id)">
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
      <OffersToSend ref="offerToSendRef"></OffersToSend>
    </div>
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <OffersSent ref="offersSentRef"></OffersSent>
    </div>
  </div>

  <el-dialog v-model="talepSonlandirDialogVisible" title="Talep Sonlandırma" width="50%" destroy-on-close align-top>
    <div class="row">
      <el-form
        status-icon
        :rules="talepSonlandirRules"
        ref="talepSonlandirRef"
        :model="deviceServiceItem"
        @submit.prevent="talepSonlandirSubmit()"
        label-width="120px"
        label-position="top"
      >
        <div class="row">
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Servis Kodu</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="serviceBootCode">
                <el-input v-model="deviceServiceItem.serviceBootCode" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Açılış Tarihi</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="failureDateString">
                <el-input v-model="deviceServiceItem.failureDateString" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Açıklama</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="bootDescription">
                <el-input v-model="deviceServiceItem.bootDescription" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Teknisyen Veriliş Tarihi</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="userAssignDateString">
                <el-input v-model="deviceServiceItem.userAssignDateString" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Telefon</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="phone">
                <el-input v-model="deviceServiceItem.phone" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Teknisyen</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="fullname">
                <el-input v-model="technicianItem.fullname" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span class="required">Talep Bildiren</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="name">
                <el-input v-model="deviceServiceItem.name" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
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
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Tespit Açıklama</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="detectionDescription">
                <el-input v-model="deviceServiceItem.detectionDescription"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span class="required">Sonuç Kodu</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="serviceResultCode">
                <el-select placeholder="Sonuç Kodu" filterable clearable v-model="deviceServiceItem.serviceResultCode">
                  <el-option v-for="item in resultCodeList" :key="item.code" :label="item.name" :value="item.code">
                    <div class="row">
                      <div class="col-md-9" style="font-size: 12px">{{ item.code }} {{ item.name }}</div>
                    </div>
                  </el-option>
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span class="required">Kapanış Tarihi</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="resultDate">
                <el-date-picker
                  v-model="deviceServiceItem.resultDate"
                  format="DD.MM.YYYY HH:mm:ss"
                  type="datetime"
                  placeholder="Select date and time"
                  :shortcuts="shortcuts"
                />
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Kapanış Açıklama</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="resultDescription">
                <el-input v-model="deviceServiceItem.resultDescription"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>S/B Sayaç</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="wBCount">
                <el-input v-model="deviceServiceItem.wBCount"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Renkli Sayaç</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="colorCount">
                <el-input v-model="deviceServiceItem.colorCount"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
        </div>
        <div class="row">
          <div class="col-md-3">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Toner Tipi</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="tonerType">
                <el-select v-model="deviceServiceItem.tonerType" placeholder="Toner Tipi">
                  <el-option label="Orjinal" value="1" />
                  <el-option label="Muadil" value="2" />
                  <el-option label="Dolum" value="3" />
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-2">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Siyah Adet</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="blackCount">
                <el-input v-model="deviceServiceItem.blackCount"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-2">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Mavi Adet</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="blueCount">
                <el-input v-model="deviceServiceItem.blueCount"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-2">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Sarı Adet</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="yellowCount">
                <el-input v-model="deviceServiceItem.yellowCount"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-2">
            <!--begin::Input group-->
            <div class="d-flex flex-column fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold">
                <span>Kırmızı Adet</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="redCount">
                <el-input v-model="deviceServiceItem.redCount"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
        </div>
        <div class="row">
          <div class="col-md-1">
            <el-checkbox label="Dr" v-model="deviceServiceItem.dr" />
          </div>
          <div class="col-md-1">
            <el-checkbox label="Bc" v-model="deviceServiceItem.bc" />
          </div>
          <div class="col-md-1">
            <el-checkbox label="Pa" v-model="deviceServiceItem.pa" />
          </div>
          <div class="col-md-1">
            <el-checkbox label="Bk" v-model="deviceServiceItem.bk" />
          </div>
          <div class="col-md-1">
            <el-checkbox label="Dv" v-model="deviceServiceItem.dv" />
          </div>
          <div class="col-md-1">
            <el-checkbox label="Fs" v-model="deviceServiceItem.fs" />
          </div>
          <div class="col-md-1">
            <el-checkbox label="Ak" v-model="deviceServiceItem.ak" />
          </div>
        </div>
        <!--begin::Actions-->
        <div class="text-center mt-2">
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
import { IResultCodeData } from '@/core/data/ResultCodeData';
import OffersToSend from '@/components/offers/OffersToSend.vue';
import OffersSent from '@/components/offers/OffersSent.vue';

export default defineComponent({
  components: {
    ErrorMessage,
    PDFViewer,
    OffersToSend,
    OffersSent
  },
  setup() {
    const store = useStore();
    var talepSonlandirDialogVisible = ref<boolean>(false);
    var parcaIslemleriDialogVisible = ref<boolean>(false);
    var raporDialogVisible = ref<boolean>(false);
    var teknisyenRaporu = ref<string>('');
    const loading = ref<boolean>(false);
    var selectedDeviceServiceId = ref<string>('');
    var deviceServiceItem = ref<IDeviceServiceData>({});
    var closedDeviceServiceList = ref<Array<IDeviceServiceData>>([]);

    var toBeOfferedDeviceServiceItem = ref<IDeviceServiceData>({});
    var technicianItem = ref<IUserData>({
      id: '',
      email: '',
      firstname: '',
      lastname: '',
      fullname: '',
    });
    var technicianAssignedDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var partsExchangeDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var technicianUserList = ref<Array<IUserData>>([]);
    var detectionCodeList = ref<Array<IDetectionCodeData>>([]);
    var resultCodeList = ref<Array<IResultCodeData>>([]);

    var assignTechnicianModel = ref<IAssignTechnicianData>({
      id: '',
      userId: '',
      cancelDescription: '',
    });

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

    const talepSonlandirRef = ref<null | HTMLFormElement>(null);
    const offerToSendRef = ref<null | HTMLFormElement>(null);

    var closedServiceModel = ref<IDeviceServiceData>();

    const talepSonlandirRules = ref({
      detectionCode: [
        {
          required: true,
          message: 'Tespit kodu seçilmedi.',
          trigger: 'blur',
        },
      ],
      serviceResultCode: [
        {
          required: true,
          message: 'Sonuç kodu seçilmedi.',
          trigger: 'blur',
        },
      ],
      resultDate: [
        {
          required: true,
          message: 'Sonuç tarihi girilmedi.',
          trigger: 'blur',
        },
      ],
    });

    async function getClosedService(selectedId) {
      await store
        .dispatch(Actions.GET_DEVICESERVICEWITHID, selectedId)
        .then(async result => {
          if (result.isSuccess) {
            selectedDeviceServiceId.value = selectedId;
            await getDetectionCodeList();
            await getResultCodeList();
            deviceServiceItem.value = result.data;
            technicianItem.value = result.data.user;
            talepSonlandirDialogVisible.value = true;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getToBeOfferedDeviceService(selectedId) {}

    const talepSonlandirSubmit = () => {
      if (!talepSonlandirRef.value) {
        return;
      }

      talepSonlandirRef.value.validate(async valid => {
        if (valid) {
          loading.value = true;

          deviceServiceItem.value.id = selectedDeviceServiceId.value;

          await store
            .dispatch(Actions.UPDATE_CLOSEDEVICESERVICE, deviceServiceItem.value)
            .then(result => {
              loading.value = false;
              console.clear();
              console.log(result);
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Servis başarıyla kapatıldı.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  talepSonlandirDialogVisible.value = false;
                  await getclosedDeviceServiceList();
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

    async function returnDeviceServiceToTechnician(id) {
      assignTechnicianModel.value.id = id;
      await store
        .dispatch(Actions.UPDATE_RETURNDEVICESERVICETOTECHNICIAN, assignTechnicianModel)
        .then(async result => {
          if (result.isSuccess) {
            Swal.fire({
              text: 'Servis başarıyla teknisyene geri gönderildi.',
              icon: 'success',
              buttonsStyling: false,
              confirmButtonText: 'Tamam',
              customClass: {
                confirmButton: 'btn btn-primary',
              },
            }).then(async () => {
              talepSonlandirDialogVisible.value = false;
              await getclosedDeviceServiceList();
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

    async function cancelDeviceService(id) {
      var description = '';
      Swal.fire({
        input: 'textarea',
        title: 'Talep iptal açıklaması giriniz',
        inputAttributes: {
          'aria-label': 'Type your message here',
        },
        showCancelButton: true,
        cancelButtonText: 'Vazgeç',
        confirmButtonText: 'İptal Et',
        inputValidator: value => {
          if (!value) {
            return 'Açıklama girmediniz';
          }

          description = value;
        },
      }).then(async confirm => {
        if (confirm.value) {
          assignTechnicianModel.value.id = id;
          assignTechnicianModel.value.cancelDescription = description;
          await store
            .dispatch(Actions.UPDATE_CANCELDEVICESERVICE, assignTechnicianModel)
            .then(async result => {
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Servis başarıyla iptal edildi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  await getclosedDeviceServiceList();
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
    }

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

    async function getResultCodeList() {
      await store
        .dispatch(Actions.GET_RESULTCODE_LIST)
        .then(result => {
          if (result.isSuccess) {
            resultCodeList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    onMounted(async () => {
      await getclosedDeviceServiceList();
      await offerToSendRef.value?.getToBeOfferedDeviceServiceList();
    });

    return {
      store,
      closedDeviceServiceList,
      technicianAssignedDeviceServiceList,
      partsExchangeDeviceServiceList,
      talepSonlandirDialogVisible,
      parcaIslemleriDialogVisible,
      raporDialogVisible,
      talepSonlandirRules,
      closedServiceModel,
      talepSonlandirRef,
      loading,
      selectedDeviceServiceId,
      technicianUserList,
      teknisyenRaporu,
      detectionCodeList,
      technicianItem,
      resultCodeList,
      shortcuts,
      deviceServiceItem,
      offerToSendRef,
      talepSonlandirSubmit,
      getclosedDeviceServiceList,
      getClosedService,
      returnDeviceServiceToTechnician,
      cancelDeviceService,
      getToBeOfferedDeviceService,
      toBeOfferedDeviceServiceItem,
    };
  },
});
</script>
