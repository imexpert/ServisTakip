<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-2">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card" shadow="hover">
        <template #header>
          <div class="card-header">
            <h4><span>Alınan Servisler</span></h4>
          </div>
        </template>
        <div>
          <el-table :data="receivedDeviceServiceList" style="width: 100%" max-height="150" height="150">
            <el-table-column label="C.No" width="90" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" width="150" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>

            <el-table-column label="Müşteri Unvan" width="360">
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
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card" shadow="hover">
        <template #header>
          <div class="card-header">
            <h4><span>Teknisyendeki İşler</span></h4>
          </div>
        </template>
        <div>
          <el-table :data="technicianAssignedDeviceServiceList" style="width: 100%" max-height="150" height="150">
            <el-table-column label="C.No" width="90" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" width="180" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen Veriliş Tarihi" width="210" sortable>
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
            <el-table-column label="Müşteri Unvan" width="360">
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
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card" shadow="hover">
        <template #header>
          <div class="card-header">
            <h4><span>Parça Değişim İşleri</span></h4>
          </div>
        </template>
        <div>
          <el-table :data="technicianAssignedDeviceServiceList" style="width: 100%" max-height="150" height="150">
            <el-table-column label="C.No" width="90" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.deviceId }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açılış Tarihi" width="180" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen Veriliş Tarihi" width="210" sortable>
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
            <el-table-column label="Müşteri Unvan" width="360">
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
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { ErrorMessage } from 'vee-validate';
import { ElMessageBox } from 'element-plus';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { hideModal } from '@/core/helpers/dom';

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

interface TechnicianAssignedServiceData {}
export default defineComponent({
  components: {
    ErrorMessage,
  },
  setup() {
    const store = useStore();

    var receivedDeviceServiceList = ref<Array<ReceivedServiceData>>([]);
    var technicianAssignedDeviceServiceList = ref<Array<TechnicianAssignedServiceData>>([]);

    return {
      store,
      receivedDeviceServiceList,
      technicianAssignedDeviceServiceList,
    };
  },
  data() {
    return {
      customer: {
        id: '',
        title: '',
        sectorId: 0,
        addresses: [],
      },
    };
  },
  async created() {
    await this.getReceivedDeviceServiceList();
    await this.getTechnicianAssignedDeviceServiceList();
  },
  methods: {
    async getReceivedDeviceServiceList() {
      await this.store
        .dispatch(Actions.GET_RECEIVEDDEVICESERVICE)
        .then(result => {
          if (result.isSuccess) {
            console.log(result.data);
            this.receivedDeviceServiceList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async getTechnicianAssignedDeviceServiceList() {
      await this.store
        .dispatch(Actions.GET_TECHNICIANASSINEDDEVICESERVICE)
        .then(result => {
          if (result.isSuccess) {
            console.log(result.data);
            this.technicianAssignedDeviceServiceList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
  },
});
</script>
