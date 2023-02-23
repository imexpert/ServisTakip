<template>
    <el-card class="box-card" shadow="hover">
        <template #header>
            <div class="card-header">
                <div class="row">
                    <div class="col-md-2">
                        <h4>Gönderilecek Teklifler</h4>
                    </div>
                    <div class="col-md-3">
                        (<span style="font-weight: 800; font-size: 14px"> Toplam Teklif Sayısı :&nbsp;</span>
                        <span style="color: red; font-weight: bold"> {{ toBeOfferedDeviceServiceList.length }}</span>)
                    </div>
                </div>
            </div>
        </template>
        <div>
            <el-table :data="toBeOfferedDeviceServiceList" style="width: 100%" max-height="150" height="150">
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
                                    <el-dropdown-item @click="parcaIslemDialogAc(scope.row.id)">
                                        <el-icon>
                                            <Expand />
                                        </el-icon>&nbsp; Y.Parça
                                    </el-dropdown-item>
                                    <el-dropdown-item>
                                        <el-icon>
                                            <CreditCard />
                                        </el-icon>&nbsp; Teklif Gönder
                                    </el-dropdown-item>
                                    <el-dropdown-item>
                                        <el-icon>
                                            <Document />
                                        </el-icon>&nbsp; Servis Kaydı
                                    </el-dropdown-item>
                                    <el-dropdown-item>
                                        <el-icon>
                                            <RemoveFilled />
                                        </el-icon>&nbsp; Sil
                                    </el-dropdown-item>
                                </el-dropdown-menu>
                            </template>
                        </el-dropdown>
                    </template>
                </el-table-column>
            </el-table>
        </div>
    </el-card>
    <!--begin::Row-->

    <el-dialog v-model="parcaIslemleriDialogVisible" title="Parça İşlemleri" width="50%" destroy-on-close align-top>
        <div class="row">
            <div class="col-md-3">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Cihaz No</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="serviceBootCode">
                        <el-input v-model="toBeOfferedDeviceServiceItem.deviceId" disabled></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
            </div>
            <div class="col-md-9">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Açılış Tarihi</span>
                    </label>
                    <!--end::Label-->

                    <el-form-item prop="failureDateString">
                        <el-input v-model="toBeOfferedDeviceServiceItem.device.address.customer.title" disabled></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
            </div>
            <div class="col-md-3">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Servis Kodu</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="bootDescription">
                        <el-input v-model="toBeOfferedDeviceServiceItem.serviceBootCode" disabled></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
            </div>
            <div class="col-md-3">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Teklif Konusu</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="userAssignDateString">
                        <el-select placeholder="Teklif konusu">
                            <el-option label="Parça Değişim" value="1" />
                            <el-option label="Toner Satış" value="2" />
                            <el-option label="Cihaz Satış" value="3" />
                            <el-option label="Sözleşme Teklifi" value="4" />
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
                        <span>İskonto Tutarı</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="phone">
                        <el-input v-model="deviceServiceItem.phone"></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
            </div>
        </div>
        <div class="row">
            <div class="col-md-5">
                <el-button-group>
                    <el-button type="danger" @click="parcaEkleDialogAc()">Parça Ekle</el-button>
                    <el-button type="primary">Parça Değişim İşlerine Gönder</el-button>
                    <el-button class="ml-2" type="primary"> Teklif Oluştur </el-button>
                </el-button-group>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <el-table :data="deviceServicePartList" style="width: 100%" max-height="150" height="150">
                    <el-table-column label="Ürün Kodu" width="90">
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
                    <el-table-column label="Adet">
                        <template #default="scope">
                            <div style="display: flex; align-items: center">
                                <span>{{ scope.row.numberOfProduct }}</span>
                            </div>
                        </template>
                    </el-table-column>
                    <el-table-column label="Fiyat" width="210">
                        <template #default="scope">
                            <div style="display: flex; align-items: center">
                                <span>{{ scope.row.unitPrice }}</span>
                            </div>
                        </template>
                    </el-table-column>
                    <el-table-column label="Toplam" width="180">
                        <template #default="scope">
                            <div style="display: flex; align-items: center">
                                <span>{{ scope.row.totalPrice }}</span>
                            </div>
                        </template>
                    </el-table-column>

                    <el-table-column label="Para Birimi" width="160">
                        <template #default="scope">
                            <div style="display: flex; align-items: center">
                                <span>{{ scope.row.currencyType }}</span>
                            </div>
                        </template>
                    </el-table-column>
                    <el-table-column label="Açıklama" width="120">
                        <template #default="scope">
                            <div style="display: flex; align-items: center">
                                <span>{{ scope.row.description }}</span>
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
                                        <el-dropdown-item @click="updateDeviceServicePart(scope.row.id)">
                                            <el-icon>
                                                <ArrowRight />
                                            </el-icon>&nbsp; Düzenle
                                        </el-dropdown-item>
                                        <el-dropdown-item @click="deleteDeviceServicePart(scope.row.id)">
                                            <el-icon>
                                                <ArrowLeft />
                                            </el-icon>&nbsp; Sil
                                        </el-dropdown-item>
                                    </el-dropdown-menu>
                                </template>
                            </el-dropdown>
                        </template>
                    </el-table-column>
                </el-table>
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
    </el-dialog>

    <el-dialog v-model="parcaEkleDialogVisible" title="Parça Ekle/Düzenle" width="40%" destroy-on-close align-top>
        <div class="row">
            <div class="col-md-6">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Ürün Kodu</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="serviceBootCode">
                        <el-input v-model="deviceServicePart.productCode"></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
            </div>
            <div class="col-md-6">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Ürün Adı</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="serviceBootCode">
                        <el-input v-model="deviceServicePart.productName"></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
            </div>
            <div class="col-md-4">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Adet</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="serviceBootCode">
                        <el-input v-model="deviceServicePart.numberOfProduct"></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
            </div>
            <div class="col-md-6">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Fiyat</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="serviceBootCode">
                        <el-input v-model="deviceServicePart.unitPrice"></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
            </div>
            <div class="col-md-4">
                <!--begin::Input group-->
                <div class="d-flex flex-column fv-row">
                    <!--begin::Label-->
                    <label class="d-flex align-items-center fs-6 fw-bold">
                        <span>Para Birimi</span>
                    </label>
                    <!--end::Label-->
                    <el-form-item prop="serviceBootCode">
                        <el-input v-model="deviceServicePart.currencyType"></el-input>
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
                    <el-form-item prop="serviceBootCode">
                        <el-input v-model="deviceServicePart.description"></el-input>
                    </el-form-item>
                </div>
                <!--end::Input group-->
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
    </el-dialog>
</template>
  
<script lang="ts">
import { defineComponent, onMounted, onActivated,onUpdated, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { ErrorMessage } from 'vee-validate';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { hideModal } from '@/core/helpers/dom';
import PDFViewer from 'pdf-viewer-vue';
import { IDeviceServiceData } from '@/core/data/DeviceServiceData';
import { IDeviceServicePartData } from '@/core/data/DeviceServicePartData';

export default defineComponent({
    name: 'ComponentOfferToSend',
    components: {
        ErrorMessage,
        PDFViewer,
    },
    setup() {
        const store = useStore();
        const loading = ref<boolean>(false);
        var parcaIslemleriDialogVisible = ref<boolean>(false);
        var parcaEkleDialogVisible = ref<boolean>(false);
        var toBeOfferedDeviceServiceList = ref<Array<IDeviceServiceData>>([]);
        var deviceServicePartList = ref<Array<IDeviceServicePartData>>([]);
        var deviceServicePart = ref<IDeviceServicePartData>();
        var toBeOfferedDeviceServiceItem = ref<IDeviceServiceData>({});
        var deviceServiceItem = ref<IDeviceServiceData>({});
        var selectedDeviceServiceId = ref<string>('');

        async function parcaEkleDialogAc() {
            parcaEkleDialogVisible.value = true;
        }

        async function parcaDuzenleDialogAc(id) {

        }

        async function updateDeviceServicePart(id) {
            
        }

        async function deleteDeviceServicePart(id) {
            
        }

        async function getToBeOfferedDeviceServiceList() {
            alert("offer")
            await store
                .dispatch(Actions.GET_TOBEOFFEREDDEVICESERVICE)
                .then(result => {
                    if (result.isSuccess) {
                        toBeOfferedDeviceServiceList.value = result.data;
                    }
                })
                .catch(() => {
                    const [error] = Object.keys(store.getters.getErrors);
                });
        }

        async function parcaIslemDialogAc(selectedId) {
            await store
                .dispatch(Actions.GET_DEVICESERVICEWITHID, selectedId)
                .then(async result => {
                    if (result.isSuccess) {
                        selectedDeviceServiceId.value = selectedId;
                        toBeOfferedDeviceServiceItem.value = result.data;
                        parcaIslemleriDialogVisible.value = true;
                    }
                })
                .catch(() => {
                    const [error] = Object.keys(store.getters.getErrors);
                });
        }

        return {
            loading,
            toBeOfferedDeviceServiceList,
            parcaIslemleriDialogVisible,
            deviceServicePartList,
            parcaEkleDialogVisible,
            deviceServicePart,
            toBeOfferedDeviceServiceItem,
            deviceServiceItem,
            getToBeOfferedDeviceServiceList,
            updateDeviceServicePart,
            deleteDeviceServicePart,
            parcaEkleDialogAc,
            parcaDuzenleDialogAc,
            parcaIslemDialogAc
        };
    },
});
</script>
  