<template>
  <el-table :data="toSentOfferedDeviceServiceList" class="tableClass">
        <el-table-column label="C.No" label-class-name="tableHeader" width="90">
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
                  <el-dropdown-item @click="getOfferReport(scope.row.id)">
                    <el-icon> <Expand /> </el-icon>&nbsp; Teklif Görüntüle
                  </el-dropdown-item>
                  <el-dropdown-item @click="approveTeklifSubmit(scope.row.id)">
                    <el-icon><Check /></el-icon>&nbsp; Teklif Onayla
                  </el-dropdown-item>
                  <el-dropdown-item>
                    <el-icon><Close /></el-icon>&nbsp; Teklif İptal
                  </el-dropdown-item>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
          </template>
        </el-table-column>
      </el-table>

  <el-dialog
    v-model="raporDialogVisible"
    title="Teklif Raporu"
    width="60%"
    style="height: 800px"
    destroy-on-close
    center
  >
    <div class="row">
      <div class="col-md-12">
        <el-button type="primary" @click="teklifGonderSubmit()">
          <el-icon> <Check /> </el-icon>&nbsp; Teklifi Yeniden Gönder
        </el-button>
      </div>
      <div class="col-md-12 mt-5">
        <!-- <VuePdf :src="teknisyenRaporu" annotation-layer /> -->
        <PDFViewer :source="teklifRaporu" style="height: 600px" @download="handleDownload" />
        <!-- <pdf src="/sample.pdf" @error="error" style="overflow-y: auto; height: 500px"></pdf> -->
      </div>
    </div>
  </el-dialog>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { ErrorMessage } from 'vee-validate';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import PDFViewer from 'pdf-viewer-vue';
import { IDeviceServiceData } from '@/core/data/DeviceServiceData';
import { IDeviceServicePartData } from '@/core/data/DeviceServicePartData';
import { ICompanyData } from '@/core/data/CompanyData';
import { IOfferSubjectCodeData } from '@/core/data/OfferSubjectCode';
import { IOfferData } from '@/core/data/OfferData';

interface ICustomInfo {
  deviceId?: string;
  serviceCode?: string;
  serviceFailureDate?: string;
  customerTitle?: string;
}

export default defineComponent({
  name: 'ComponentOfferToSend',
  components: {
    ErrorMessage,
    PDFViewer,
  },
  setup() {
    const store = useStore();
    const loading = ref<boolean>(false);
    var customInfo = ref<ICustomInfo>({
      deviceId: '',
      serviceCode: '',
      serviceFailureDate: '',
      customerTitle: '',
    });
    var mode = ref<boolean>(false);
    var parcaIslemleriDialogVisible = ref<boolean>(false);
    var teklifFormDialogVisible = ref<boolean>(false);
    var parcaEkleDuzenleDialogVisible = ref<boolean>(false);
    var raporDialogVisible = ref<boolean>(false);
    var toSentOfferedDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
    var deviceServicePartList = ref<Array<IDeviceServicePartData>>([]);
    var teklifRaporu = ref<string>('');
    var deviceServicePart = ref<IDeviceServicePartData>({
      currencyType: '',
      description: '',
      numberOfProduct: '',
      productCode: '',
      productName: '',
      totalPrice: '',
      unitPrice: '',
    });
    var company = ref<ICompanyData>({});
    var offerSubjectCodeList = ref<Array<IOfferSubjectCodeData>>([]);
    var offerItem = ref<IOfferData>({
      address: '',
      authorizeFullname: '',
      authorizeMail: '',
      deviceServiceId: '',
      fax: '',
      id: '0',
      offerAuthorizeFullname: '',
      offerCompanyTitle: '',
      offerDate: '',
      offerPhone: '',
      offerSendEmail: '',
      offerStatus: '',
      offerSubjectCodeId: '',
      phone: '',
      title: '',
      discountRate: '',
    });

    var toBeOfferedDeviceServiceItem = ref<IDeviceServiceData>();
    var deviceServiceItem = ref<IDeviceServiceData>();
    var selectedDeviceServiceId = ref<string>('');

    const teklifFormuRef = ref<null | HTMLFormElement>(null);

    async function getSentOfferedDeviceServiceList() {
      await store
        .dispatch(Actions.GET_SENTOFFEREDDEVICESERVICE)
        .then(result => {
          if (result.isSuccess) {
            console.log(result.data);
            toSentOfferedDeviceServiceList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function teklifFormDialogAc() {
      await getOfferNotSend();
      teklifFormDialogVisible.value = true;
    }

    async function getOfferNotSend() {
      await store
        .dispatch(Actions.GET_OFFERNOTSEND, selectedDeviceServiceId.value)
        .then(result => {
          if (result.isSuccess) {
            offerItem.value = result.data;
            mode.value = result.data.id > 0;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getOfferReport(deviceServiceId) {
      await store
        .dispatch(Actions.GET_OFFERREPORT, deviceServiceId)
        .then(result => {
          if (result.isSuccess) {
            selectedDeviceServiceId.value = deviceServiceId;
            raporDialogVisible.value = true;
            teklifRaporu.value = 'data:application/pdf;base64,' + result.data.report;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    const teklifGonderSubmit = () => {
      Swal.fire({
        title: 'Teklif Gönderme Onayı',
        html: 'İlgili teklif müşteriye yeniden gönderilecek.<br>Devam etmek istiyor musunuz ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Gönder',
        denyButtonText: `Vazgeç`,
      }).then(async result => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          offerItem.value.deviceServiceId = selectedDeviceServiceId.value;
          console.log(offerItem.value);
          await store
            .dispatch(Actions.UPDATE_SENDOFFERAGAIN, offerItem)
            .then(async result => {
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Teklif başarıyla müşteriye yeniden gönderildi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  raporDialogVisible.value = false;
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
    };

    const approveTeklifSubmit = selectedId => {
      Swal.fire({
        title: 'Teklif Onayı',
        html: 'Teklif onaylanacak ve parça değişim işlerine atanacaktır.<br>Devam etmek istiyor musunuz ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Gönder',
        denyButtonText: `Vazgeç`,
      }).then(async result => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          offerItem.value.deviceServiceId = selectedId;
          console.log(offerItem.value);
          await store
            .dispatch(Actions.UPDATE_APPROVEDEVICESERVICEOFFER, offerItem)
            .then(async result => {
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Teklif başarıyla onaylandı.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  raporDialogVisible.value = false;
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
    };

    const handleDownload = value => {
      var a = document.createElement('a'); //Create <a>
      a.href = value.src;
      a.download = 'TeklifRaporu.pdf'; //File name Here
      a.click(); //Downloaded file
      console.log(value);
    };

    return {
      loading,
      toSentOfferedDeviceServiceList,
      parcaIslemleriDialogVisible,
      deviceServicePartList,
      parcaEkleDuzenleDialogVisible,
      deviceServicePart,
      toBeOfferedDeviceServiceItem,
      deviceServiceItem,
      customInfo,
      teklifFormDialogVisible,
      teklifFormuRef,
      company,
      offerSubjectCodeList,
      offerItem,
      raporDialogVisible,
      teklifRaporu,
      getSentOfferedDeviceServiceList,
      teklifFormDialogAc,
      handleDownload,
      getOfferReport,
      teklifGonderSubmit,
      approveTeklifSubmit,
    };
  },
});
</script>
