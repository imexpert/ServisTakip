<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-2" v-loading="alinanServislerLoading">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12" style="height: 770px;" >
      <el-tabs type="border-card" style="height: 770px;">
        <el-tab-pane :label="alinanServislerLabel">
          <el-table
            :data="receivedDeviceServiceList"
            class="tableClass">
            <el-table-column label="C.No" label-class-name="tableHeader" width="80">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" label-class-name="tableHeader" width="170">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Müşteri Unvan" label-class-name="tableHeader" width="570">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.customer.title }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Model" label-class-name="tableHeader" width="160">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.deviceModel.name }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Seri No" label-class-name="tableHeader" width="140">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.serialNumber }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Servis Kodu" label-class-name="tableHeader" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceBootCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Departman" label-class-name="tableHeader" width="250">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.department }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açıklama" label-class-name="tableHeader" width="450">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.bootDescription }}</span>
                </div>
              </template>
            </el-table-column>

            <el-table-column label="#" fixed="left" label-class-name="tableHeader" width="170">
              <template #default="scope">
                <el-dropdown size="small" type="danger">
                  <el-button type="primary">
                    İşlem Listesi<el-icon class="el-icon--right">
                      <arrow-down />
                    </el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item @click="teknisyenAtaAc(scope.row.id)">
                        <el-icon> <ArrowRight /> </el-icon>&nbsp; Teknisyen Ata
                      </el-dropdown-item>
                      <el-dropdown-item @click="cancelDeviceService(scope.row.id)">
                        <el-icon> <RemoveFilled /> </el-icon>&nbsp; İptal Et
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </template>
            </el-table-column>
          </el-table></el-tab-pane>
        <el-tab-pane :label="teknisyendekiIslerLabel">
          <el-table :data="technicianAssignedDeviceServiceList" class="tableClass">
            <el-table-column label="C.No" label-class-name="tableHeader" width="90">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" label-class-name="tableHeader" width="170" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Müşteri Unvan" label-class-name="tableHeader" width="370">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.customer.title }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen Veriliş Tarihi" label-class-name="tableHeader" width="210">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.userAssignDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen" label-class-name="tableHeader" width="180">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.user.firstname }} {{ scope.row.user.lastname }}</span>
                </div>
              </template>
            </el-table-column>

            <el-table-column label="Model" label-class-name="tableHeader" width="160">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.deviceModel.name }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Seri No" label-class-name="tableHeader" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.serialNumber }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Servis Kodu" label-class-name="tableHeader" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceBootCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Departman" label-class-name="tableHeader" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.department }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açıklama" label-class-name="tableHeader" width="320">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.bootDescription }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="#" fixed="left" label-class-name="tableHeader" width="170">
              <template #default="scope">
                <el-dropdown size="small" type="danger">
                  <el-button type="primary">
                    İşlem Listesi<el-icon class="el-icon--right">
                      <arrow-down />
                    </el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item @click="kapatilacakIslereGonderSubmit(scope.row.id)">
                        <el-icon> <ArrowRight /> </el-icon>&nbsp; Talebi Kapat
                      </el-dropdown-item>
                      <el-dropdown-item @click="takeDeviceServiceBack(scope.row.id)">
                        <el-icon> <ArrowLeft /> </el-icon>&nbsp; Geri
                      </el-dropdown-item>
                      <el-dropdown-item @click="cancelDeviceService(scope.row.id)">
                        <el-icon> <RemoveFilled /> </el-icon>&nbsp; İptal Et
                      </el-dropdown-item>
                      <el-dropdown-item @click="deleteDeviceService(scope.row.id)">
                        <el-icon> <DeleteFilled /> </el-icon>&nbsp; Sil
                      </el-dropdown-item>
                      <el-dropdown-item @click="teknisyenRaporAc()">
                        <el-icon> <Share /> </el-icon>&nbsp; Teknisyen Raporu
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </template>
            </el-table-column>
          </el-table>
        </el-tab-pane>
        <el-tab-pane :label="parcaDegisimIslerLabel">
          <el-table :data="partsExchangeDeviceServiceList" class="tableClass">
            <el-table-column label="C.No" label-class-name="tableHeader" width="90">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" label-class-name="tableHeader" width="170" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>

            <el-table-column label="Müşteri Unvan" label-class-name="tableHeader" >
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.customer.title }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Model" label-class-name="tableHeader" width="160">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.deviceModel.name }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Seri No" label-class-name="tableHeader" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.serialNumber }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Servis Kodu" label-class-name="tableHeader" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceBootCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Departman" label-class-name="tableHeader" >
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.device.address.department }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açıklama" label-class-name="tableHeader" >
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.bootDescription }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="#" fixed="left" label-class-name="tableHeader" width="170">
              <template #default="scope">
                <el-dropdown size="small" type="danger">
                  <el-button type="primary">
                    İşlem Listesi<el-icon class="el-icon--right">
                      <arrow-down />
                    </el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item @click="teknisyenAtaAc(scope.row.id)">
                        <el-icon> <ArrowRight /> </el-icon>&nbsp; Teknisyen Ata
                      </el-dropdown-item>
                      <el-dropdown-item @click="getOrderReceipt(scope.row.id)">
                        <el-icon> <Share /> </el-icon>&nbsp; Sipariş Fişi
                      </el-dropdown-item>
                      <el-dropdown-item @click="parcaListesiDialogAc(scope.row.id)">
                        <el-icon> <List /> </el-icon>&nbsp; Parça Listesi
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
        </el-tab-pane>
      </el-tabs>
    </div>
  </div>

  <el-dialog v-model="teknisyenAtaDialogVisible" title="Teknisyen Atama" width="40%" destroy-on-close center>
    <div class="row">
      <el-form
        status-icon
        :rules="teknisyenAtaRules"
        ref="formAssignTechnicianRef"
        :model="assignTechnicianModel"
        @submit.prevent="teknisyenAtaSubmit()"
        label-width="120px"
        label-position="top"
      >
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
                  <el-option
                    v-for="item in technicianUserList"
                    :key="item.id"
                    :label="item.firstname + ' ' + item.lastname"
                    :value="item.id"
                  >
                    <div class="row">
                      <div class="col-md-9" style="font-size: 12px">{{ item.firstname }} {{ item.lastname }}</div>
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

  <el-dialog v-model="teknisyenRaporDialogVisible" title="Teknisyen Raporu" width="40%" destroy-on-close center>
    <div class="row">
      <el-form
        status-icon
        :rules="teknisyenAtaRules"
        ref="formAssignTechnicianRef"
        :model="assignTechnicianModel"
        @submit.prevent="teknisyenRaporSubmit()"
        label-width="120px"
        label-position="top"
      >
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
                  <el-option
                    v-for="item in technicianUserList"
                    :key="item.id"
                    :label="item.firstname + item.lastname"
                    :value="item.id"
                  >
                    <div class="row">
                      <div class="col-md-9" style="font-size: 12px">{{ item.firstname }} {{ item.lastname }}</div>
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

  <el-dialog
    v-model="raporDialogVisible"
    title="Teknisyen Raporu"
    width="50%"
    style="height: 700px"
    destroy-on-close
    center
  >
    <div class="row">
      <div class="col-md-12">
        <!-- <VuePdf :src="teknisyenRaporu" annotation-layer /> -->
        <PDFViewer :source="teknisyenRaporu" style="height: 600px" @download="handleDownload" />
        <!-- <pdf src="/sample.pdf" @error="error" style="overflow-y: auto; height: 500px"></pdf> -->
      </div>
    </div>
  </el-dialog>

  <el-dialog
    v-model="parcaListesiDialogVisible"
    title="Parça Listesi"
    width="50%"
    style="height: 400px"
    destroy-on-close
    center
  >
    <div class="row">
      <div class="col-md-12">
        <el-table :data="deviceServicePartList" border style="width: 100%" max-height="300" height="300">
          <el-table-column type="index" :index="indexMethod" />
          <el-table-column label="Ürün Kodu" width="100">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.productCode }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Ürün Adı" width="170" sortable>
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.productName }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Adet" width="70">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.numberOfProduct }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Fiyat" width="80">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.unitPrice }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Toplam" width="100">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.totalPrice }}</span>
              </div>
            </template>
          </el-table-column>

          <el-table-column label="Para Birimi" width="100">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.currencyType }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Açıklama">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.description }}</span>
              </div>
            </template>
          </el-table-column>
        </el-table>
      </div>
    </div>
  </el-dialog>

  <el-dialog
    v-model="orderReceiptDialogVisible"
    title="Sipariş Fişi"
    width="60%"
    style="height: 800px"
    destroy-on-close
    center
  >
    <el-form
      status-icon
      :rules="siparisFisGonderRules"
      ref="siparisFisGonderRef"
      :model="mailModel"
      @submit.prevent="siparisFisiGonderSubmit()"
      label-width="120px"
      label-position="top"
    >
      <div class="row">
        <div class="col-md-3 mt-2">
          <!--begin::Button-->
          <button :data-kt-indicator="loading ? 'on' : null" class="btn btn-lg btn-primary" type="submit">
            <span v-if="!loading" class="indicator-label"> Mail Gönder </span>
            <span v-if="loading" class="indicator-progress">
              Lütfen Bekleyiniz...
              <span class="spinner-border spinner-border-sm align-middle ms-2"></span>
            </span>
          </button>
        </div>
        <div class="col-md-3">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Mail Adresi</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="mailAddress">
              <el-input v-model="mailModel.mailAddress"></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-12 mt-5" v-loading="loading">
          <!-- <VuePdf :src="teknisyenRaporu" annotation-layer /> -->
          <PDFViewer :source="orderReceiptReport" style="height: 600px" @download="handleOrderReceiptDownload" />
          <!-- <pdf src="/sample.pdf" @error="error" style="overflow-y: auto; height: 500px"></pdf> -->
        </div>
      </div>
    </el-form>
  </el-dialog>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { ErrorMessage } from 'vee-validate';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { hideModal } from '@/core/helpers/dom';
import PDFViewer from 'pdf-viewer-vue';
import { IDeviceServiceData } from '@/core/data/DeviceServiceData';
import { IUserData } from '@/core/data/UserData';
import { IAssignTechnicianData } from '@/core/data/AssignTechnicianData';
import { IDeviceServicePartData } from '@/core/data/DeviceServicePartData';

interface IMailModel {
  mailAddress: string;
  deviceServiceId: string;
}
export default defineComponent({
  components: {
    ErrorMessage,
    PDFViewer,
  },
  setup() {
    const store = useStore();
    var teknisyenAtaDialogVisible = ref<boolean>(false);
    var parcaListesiDialogVisible = ref<boolean>(false);
    var teknisyenRaporDialogVisible = ref<boolean>(false);
    var raporDialogVisible = ref<boolean>(false);
    var orderReceiptDialogVisible = ref<boolean>(false);
    var teknisyenRaporu = ref<string>('');
    var orderReceiptReport = ref<string>('');
    const loading = ref<boolean>(false);
    const alinanServislerLoading = ref<boolean>(false);
    var selectedDeviceServiceId = ref<string>('');
    var orderReceiptMailAddress = ref<string>('');
    var mailModel = ref<IMailModel>({
      mailAddress: '',
      deviceServiceId: '',
    });
    var deviceServicePartList = ref<Array<IDeviceServicePartData>>([]);

    var receivedDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var technicianAssignedDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var partsExchangeDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var technicianUserList = ref<Array<IUserData>>([]);

    const formAssignTechnicianRef = ref<null | HTMLFormElement>(null);
    const siparisFisGonderRef = ref<null | HTMLFormElement>(null);

    var assignTechnicianModel = ref<IAssignTechnicianData>({
      id: '',
      userId: '',
      cancelDescription: '',
    });

    const teknisyenAtaRules = ref({
      userId: [
        {
          required: true,
          message: 'Teknisyen seçilmedi.',
          trigger: 'blur',
        },
      ],
    });

    const siparisFisGonderRules = ref({
      mailAddress: [
        {
          required: true,
          message: 'Mail adresi girilmedi.',
          trigger: 'blur',
        },
      ],
    });

    const alinanServislerLabel = ref<string>('Alınan Servisler');
    const teknisyendekiIslerLabel = ref<string>('Teknisyendeki İşler');
    const parcaDegisimIslerLabel = ref<string>('Parça Değişim İşleri');

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
                  teknisyenAtaDialogVisible.value = false;
                  await getReceivedDeviceServiceList();
                  await getTechnicianAssignedDeviceServiceList();
                  await getPartsExchangeDeviceServiceList();
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

    const kapatilacakIslereGonderSubmit = async id => {
      loading.value = true;
      assignTechnicianModel.value.id = id;
      await store
        .dispatch(Actions.UPDATE_SENDDEVICESERVICETOCLOSE, assignTechnicianModel)
        .then(result => {
          loading.value = false;
          console.clear();
          console.log(result);
          if (result.isSuccess) {
            Swal.fire({
              text: 'Servis başarıyla kapatılacak işlere gönderildi.',
              icon: 'success',
              buttonsStyling: false,
              confirmButtonText: 'Tamam',
              customClass: {
                confirmButton: 'btn btn-primary',
              },
            }).then(async () => {
              await getTechnicianAssignedDeviceServiceList();
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
    };

    const teknisyenRaporSubmit = () => {
      if (!formAssignTechnicianRef.value) {
        return;
      }

      formAssignTechnicianRef.value.validate(async valid => {
        if (valid) {
          loading.value = true;
          assignTechnicianModel.value.id = selectedDeviceServiceId.value;
          await store
            .dispatch(Actions.GET_TECHNICIANDEVICESERVICEREPORT, assignTechnicianModel.value.userId)
            .then(result => {
              loading.value = false;
              console.clear();
              console.log(result);
              if (result.isSuccess) {
                teknisyenRaporDialogVisible.value = false;
                raporDialogVisible.value = true;
                teknisyenRaporu.value = 'data:application/pdf;base64,' + result.data.report;
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

    const handleDownload = value => {
      var a = document.createElement('a'); //Create <a>
      a.href = value.src;
      a.download = 'TeknisyenRaporu.pdf'; //File name Here
      a.click(); //Downloaded file
      console.log(value);
    };

    const handleOrderReceiptDownload = value => {
      var a = document.createElement('a'); //Create <a>
      a.href = value.src;
      a.download = 'SiparisFisi.pdf'; //File name Here
      a.click(); //Downloaded file
      console.log(value);
    };

    async function teknisyenAtaAc(deviceServiceId) {
      selectedDeviceServiceId.value = deviceServiceId;
      await getTechnicianList();
      teknisyenAtaDialogVisible.value = true;
    }

    async function teknisyenRaporAc() {
      await getTechnicianList();
      teknisyenRaporDialogVisible.value = true;
    }

    async function getTechnicianList() {
      await store
        .dispatch(Actions.GET_TECHNICIAN_LIST)
        .then(result => {
          if (result.isSuccess) {
            technicianUserList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getOrderReceipt(deviceServiceId) {
      orderReceiptDialogVisible.value = true;
      loading.value = true;
      mailModel.value.deviceServiceId = deviceServiceId;
      await store
        .dispatch(Actions.GET_ORDERRECEIPT, deviceServiceId)
        .then(result => {
          if (result.isSuccess) {
            loading.value = false;
            orderReceiptReport.value = 'data:application/pdf;base64,' + result.data.report;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getReceivedDeviceServiceList() {
      alinanServislerLoading.value = true;
      await store
        .dispatch(Actions.GET_RECEIVEDDEVICESERVICE)
        .then(result => {
          if (result.isSuccess) {
            receivedDeviceServiceList.value = result.data;
            alinanServislerLabel.value = alinanServislerLabel.value + " ("+ receivedDeviceServiceList.value.length+")"
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
        alinanServislerLoading.value = false;
    }

    async function getTechnicianAssignedDeviceServiceList() {
      await store
        .dispatch(Actions.GET_TECHNICIANASSINEDDEVICESERVICE)
        .then(result => {
          if (result.isSuccess) {
            technicianAssignedDeviceServiceList.value = result.data;
            teknisyendekiIslerLabel.value = teknisyendekiIslerLabel.value + " ("+ technicianAssignedDeviceServiceList.value.length+")"
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getPartsExchangeDeviceServiceList() {
      await store
        .dispatch(Actions.GET_PARTSEXCHANGEDEVICESERVICELIST)
        .then(result => {
          if (result.isSuccess) {
            partsExchangeDeviceServiceList.value = result.data;
            parcaDegisimIslerLabel.value = parcaDegisimIslerLabel.value + " ("+ partsExchangeDeviceServiceList.value.length+")"
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function takeDeviceServiceBack(id) {
      assignTechnicianModel.value.id = id;
      await store
        .dispatch(Actions.UPDATE_TAKEDEVICESERVICEBACK, assignTechnicianModel)
        .then(async result => {
          if (result.isSuccess) {
            Swal.fire({
              text: 'Servis başarıyla geri alındı.',
              icon: 'success',
              buttonsStyling: false,
              confirmButtonText: 'Tamam',
              customClass: {
                confirmButton: 'btn btn-primary',
              },
            }).then(async () => {
              teknisyenAtaDialogVisible.value = false;
              await getReceivedDeviceServiceList();
              await getTechnicianAssignedDeviceServiceList();
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
                  teknisyenAtaDialogVisible.value = false;
                  await getReceivedDeviceServiceList();
                  await getTechnicianAssignedDeviceServiceList();
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

    async function deleteDeviceService(id) {
      Swal.fire({
        title: 'Servis kaydı silinecek !!!',
        text: 'Devam etmek istiyor musunuz ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Sil',
        denyButtonText: `Vazgeç`,
      }).then(async result => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          await store
            .dispatch(Actions.DELETE_DELETEDEVICESERVICE, id)
            .then(async result => {
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Servis başarıyla silindi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  await getReceivedDeviceServiceList();
                  await getTechnicianAssignedDeviceServiceList();
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
        } else if (result.isDenied) {
        }
      });
    }

    async function getdeviceServicePartList(deviceServiceId) {
      await store
        .dispatch(Actions.GET_DEVICESERVICEPARTLIST, deviceServiceId)
        .then(result => {
          if (result.isSuccess) {
            deviceServicePartList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function parcaListesiDialogAc(deviceServiceId) {
      await getdeviceServicePartList(deviceServiceId);
      parcaListesiDialogVisible.value = true;
    }

    const indexMethod = (index: number) => {
      return index + 1;
    };

    const siparisFisiGonderSubmit = () => {
      if (!siparisFisGonderRef.value) {
        return;
      }

      siparisFisGonderRef.value.validate(async valid => {
        if (valid) {
          loading.value = true;
          await store
            .dispatch(Actions.SEND_ORDERRECEIPT, mailModel.value)
            .then(result => {
              loading.value = false;
              console.clear();
              console.log(result);
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Sipariş fişi başarıyla gönderildi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  orderReceiptDialogVisible.value = false;
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

    onMounted(async () => {
      await getReceivedDeviceServiceList();
      await getTechnicianAssignedDeviceServiceList();
      await getPartsExchangeDeviceServiceList();

      
    });

    return {
      store,
      receivedDeviceServiceList,
      technicianAssignedDeviceServiceList,
      partsExchangeDeviceServiceList,
      teknisyenAtaDialogVisible,
      teknisyenRaporDialogVisible,
      raporDialogVisible,
      teknisyenAtaRules,
      assignTechnicianModel,
      formAssignTechnicianRef,
      loading,
      selectedDeviceServiceId,
      technicianUserList,
      teknisyenRaporu,
      parcaListesiDialogVisible,
      deviceServicePartList,
      orderReceiptDialogVisible,
      orderReceiptMailAddress,
      orderReceiptReport,
      mailModel,
      siparisFisGonderRules,
      siparisFisGonderRef,
      alinanServislerLabel,
      alinanServislerLoading,
      teknisyendekiIslerLabel,
      parcaDegisimIslerLabel,
      teknisyenAtaSubmit,
      getTechnicianList,
      teknisyenAtaAc,
      getReceivedDeviceServiceList,
      getTechnicianAssignedDeviceServiceList,
      takeDeviceServiceBack,
      cancelDeviceService,
      deleteDeviceService,
      teknisyenRaporAc,
      teknisyenRaporSubmit,
      handleDownload,
      kapatilacakIslereGonderSubmit,
      getPartsExchangeDeviceServiceList,
      parcaListesiDialogAc,
      indexMethod,
      handleOrderReceiptDownload,
      getOrderReceipt,
      siparisFisiGonderSubmit,
    };
  },
});
</script>