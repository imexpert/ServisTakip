<template>
  <el-table
    :data="contracts"
    class="tableClass"
    height="150"
    max-height="150px"
    :default-sort="{ prop: 'startDate', order: 'descending' }"
  >
    <template #empty v-if="deviceId != null">
      <div class="row">
        <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-1">
          <el-button type="danger">
            <el-icon> <Plus></Plus> </el-icon>Yeni Ekle
          </el-button>
        </div>
      </div>
    </template>
    <el-table-column label="Başlangıç T." width="140" label-class-name="tableHeader">
      <template #default="scope">
        <div style="display: flex; align-items: center">
          <span>{{ scope.row.startDateString }}</span>
        </div>
      </template>
    </el-table-column>
    <el-table-column label="Bitiş T." width="140" label-class-name="tableHeader">
      <template #default="scope">
        <div style="display: flex; align-items: center">
          <span>{{ scope.row.endDateString }}</span>
        </div>
      </template>
    </el-table-column>
    <el-table-column label="Sözleşme Kodu" width="160" label-class-name="tableHeader">
      <template #default="scope">
        <div style="display: flex; align-items: center">
          <span>{{ scope.row.contractCode }}</span>
        </div>
      </template>
    </el-table-column>
    <el-table-column label="Bakım Periyodu" width="160" label-class-name="tableHeader">
      <template #default="scope">
        <div style="display: flex; align-items: center">
          <span>{{ scope.row.maintenancePeriod }} Aylık</span>
        </div>
      </template>
    </el-table-column>
    <el-table-column label="Fiyat" width="120" label-class-name="tableHeader">
      <template #default="scope">
        <div style="display: flex; align-items: center">
          <span
            >{{ scope.row.price }}
            {{
              scope.row.currencyType == 1
                ? 'TL'
                : scope.row.currencyType == 2
                ? 'USD'
                : scope.row.currencyType == 3
                ? 'EURO'
                : ''
            }}
          </span>
        </div>
      </template>
    </el-table-column>
    <el-table-column label="#" fixed="left" width="140" label-class-name="tableHeader">
      <template #default="scope">
        <el-dropdown size="small" @click="sozlemeDialogAc()" split-button type="danger">
          Yeni Ekle
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item @click="sozlemeDialogAc(scope.row.id)">
                <el-icon>
                  <Edit></Edit>
                </el-icon>
                Düzenle
              </el-dropdown-item>
              <el-dropdown-item @click="deleteConract(scope.row.id)">
                <el-icon>
                  <el-icon>
                    <Delete />
                  </el-icon>
                </el-icon>
                Sil
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </template>
    </el-table-column>
  </el-table>

  <el-dialog v-model="sozlesmeDialogVisible" title="Sözleşme Ekle / Düzenle" width="40%" destroy-on-close center>
    <div class="row" v-loading="sozlesmeLoading">
      <el-form
        status-icon
        :rules="newContractRules"
        ref="formContractRef"
        :model="newContract"
        @submit.prevent="contractSubmit()"
        label-width="120px"
        label-position="top"
      >
        <div class="row">
          <!-- Sözleşme Başlangıç Tarihi -->
          <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Başlangıç Tarihi</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="startDate">
                <el-date-picker
                  v-model="newContract.startDate"
                  format="DD.MM.YYYY"
                  type="datetime"
                  placeholder="Sözleşme başlangıç tarihini seçiniz"
                  :shortcuts="shortcuts"
                />
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Sözleşme Bitiş Tarihi -->
          <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Bitiş Tarihi</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="endDate">
                <el-date-picker
                  v-model="newContract.endDate"
                  format="DD.MM.YYYY"
                  type="datetime"
                  placeholder="Sözleşme başlangıç tarihini seçiniz"
                  :shortcuts="shortcuts"
                />
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Sözleşme Kodu -->
          <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Sözleşme Kodu</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="contractCode">
                <el-select placeholder="Sözleşme Kodu" filterable clearable v-model="newContract.contractCode">
                  <el-option v-for="item in contractCodeList" :key="item.code" :label="item.name" :value="item.code">
                    <div class="row">
                      <div class="col-md-3" style="font-size: 12px">
                        {{ item.code }}
                      </div>
                      <div class="col-md-9" style="font-size: 12px">
                        {{ item.name }}
                      </div>
                    </div>
                  </el-option>
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Bakım Periyodu -->
          <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Bakım Periyodu</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="maintenancePeriod">
                <el-select
                  placeholder="Cihaz bakım periyodu seçiniz"
                  filterable
                  clearable
                  v-model="newContract.maintenancePeriod"
                >
                  <el-option label="1 Aylık" :value="1"></el-option>
                  <el-option label="2 Aylık" :value="2"></el-option>
                  <el-option label="3 Aylık" :value="3"></el-option>
                  <el-option label="4 Aylık" :value="4"></el-option>
                  <el-option label="5 Aylık" :value="5"></el-option>
                  <el-option label="6 Aylık" :value="6"></el-option>
                  <el-option label="7 Aylık" :value="7"></el-option>
                  <el-option label="8 Aylık" :value="8"></el-option>
                  <el-option label="9 Aylık" :value="9"></el-option>
                  <el-option label="10 Aylık" :value="10"></el-option>
                  <el-option label="11 Aylık" :value="11"></el-option>
                  <el-option label="12 Aylık" :value="12"></el-option>
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Sözleşme Ücreti -->
          <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Sözleşme Ücreti</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="price">
                <input
                  type="number"
                  class="form-control form-control-sm border border-secondary"
                  v-model="newContract.price"
                  step="0.01"
                />
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Ücret Tipi -->
          <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Ücret Tipi</span>
              </label>
              <!--end::Label-->
              <!--end::Label-->
              <el-form-item prop="currencyType">
                <el-select placeholder="Para birimi seçin" v-model="newContract.currencyType">
                  <el-option label="TL" :value="1" />
                  <el-option label="USD" :value="2" />
                  <el-option label="EURO" :value="3" />
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
        </div>
        <!--begin::Actions-->
        <div class="text-center">
          <!--begin::Button-->
          <button :data-kt-indicator="sozlesmeLoading ? 'on' : null" class="btn btn-lg btn-primary" type="submit">
            <span v-if="!sozlesmeLoading" class="indicator-label"> Kaydet </span>
            <span v-if="sozlesmeLoading" class="indicator-progress">
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
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { IContractCodeData } from '@/core/data/ContractCodeData';
import { IContractData } from '@/core/data/ContractData';
import { showErrorMessage, showSuccessMessage } from '@/core/plugins/Utils';
import { Actions } from '@/store/enums/StoreEnums';
import { defineComponent, ref, computed, watch, watchEffect } from 'vue';
import { useStore } from 'vuex';

export default defineComponent({
  name: 'SozlesmeListesi',
  props: ['deviceId'],
  setup(props) {
    const store = useStore();

    var contracts = ref<Array<IContractData>>([]);
    var contractCodeList = ref<Array<IContractCodeData>>([]);
    var selectContractMode = ref<string>('I');
    var sozlesmeLoading = ref<boolean>(false);

    const formContractRef = ref<null | HTMLFormElement>(null);

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

    const newContractRules = ref({
      startDate: [
        {
          required: true,
          message: 'Başlangıç tarihi seçilmedi.',
          trigger: 'blur',
        },
      ],
      endDate: [
        {
          required: true,
          message: 'Bitiş tarihi seçilmedi.',
          trigger: 'blur',
        },
      ],
      contractCode: [
        {
          required: true,
          message: 'Sözleşme kodu seçilmedi.',
          trigger: 'blur',
        },
      ],
      maintenancePeriod: [
        {
          required: true,
          message: 'Bakım periyodu seçilmedi.',
          trigger: 'blur',
        },
      ],
    });

    const sozlesmeDialogVisible = ref(false);

    var newContract = ref<IContractData>({
      device: null,
      contractCode: '',
      currencyType: 'TL',
      deviceId: null,
      endDate: '',
      endDateString: '',
      maintenancePeriod: '',
      price: '1234',
      startDate: '',
      startDateString: '',
      status: false,
    });

    async function getContractCodeList() {
      await store
        .dispatch(Actions.GET_CONTRACTCODE_LIST)
        .then(result => {
          if (result.isSuccess) {
            contractCodeList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getContractById(id) {
      await store
        .dispatch(Actions.GET_CONTRACTBYID, id)
        .then(async result => {
          if (result.isSuccess) {
            newContract.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    function clearForm() {
      newContract.value.contractCode = null;
      newContract.value.currencyType = null;
      newContract.value.deviceId = null;
      newContract.value.endDate = null;
      newContract.value.maintenancePeriod = null;
      newContract.value.price = null;
      newContract.value.startDate = null;
    }
    async function sozlemeDialogAc(id = 0) {
      clearForm();

      sozlesmeDialogVisible.value = true;

      await getContractCodeList();

      if (id > 0) {
        selectContractMode.value = 'U';
        await getContractById(id);
      } else {
        selectContractMode.value = 'I';
      }
    }

    const contractSubmit = () => {
      if (!formContractRef.value) {
        return;
      }

      formContractRef.value.validate(valid => {
        if (valid) {
          sozlesmeLoading.value = true;
          console.log(newContract.value);

          newContract.value.deviceId = props.deviceId;

          if (selectContractMode.value == 'I') {
            store
              .dispatch(Actions.ADD_CONTRACT, newContract.value)
              .then(result => {
                sozlesmeLoading.value = false;
                if (result.isSuccess) {
                  showSuccessMessage('Sözleşme başarıyla eklendi.').then(async () => {
                    await getContractList();
                    sozlesmeLoading.value = false;
                    sozlesmeDialogVisible.value = false;
                  });
                } else {
                  showErrorMessage(result.message).then(() => {
                    sozlesmeLoading.value = false;
                    sozlesmeDialogVisible.value = false;
                  });
                }
              })
              .catch(({ response }) => {});
          } else {
            store
              .dispatch(Actions.UPDATE_CONTRACT, newContract.value)
              .then(result => {
                sozlesmeLoading.value = false;
                if (result.isSuccess) {
                  showSuccessMessage('Sözleşme başarıyla güncellendi.').then(async () => {
                    await getContractList();
                    sozlesmeLoading.value = false;
                    sozlesmeDialogVisible.value = false;
                  });
                } else {
                  showErrorMessage(result.message).then(() => {
                    sozlesmeLoading.value = false;
                    sozlesmeDialogVisible.value = false;
                  });
                }
              })
              .catch(({ response }) => {});
          }

          sozlesmeLoading.value = false;
        }
      });
    };

    async function deleteConract(id) {
      Swal.fire({
        title: 'Sözleşme kaydı silinecek !!!',
        text: 'Devam etmek istiyor musunuz ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Sil',
        denyButtonText: `Vazgeç`,
      }).then(async result => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          await store
            .dispatch(Actions.DELETE_CONTRACT, id)
            .then(async result => {
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Sözleşme başarıyla silindi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  await getContractList();
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

    async function getContractList() {
      contracts.value = [];

      sozlesmeLoading.value = true;
      if (props.deviceId) {
        await store
          .dispatch(Actions.GET_CONTRACTLIST, props.deviceId)
          .then(result => {
            if (result.isSuccess) {
              contracts.value = result.data;
              sozlesmeLoading.value = false;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      }
    }

    watchEffect(async () => await getContractList());

    return {
      sozlemeDialogAc,
      contractSubmit,
      deleteConract,
      getContractList,
      contracts,
      sozlesmeDialogVisible,
      contractCodeList,
      selectContractMode,
      sozlesmeLoading,
      newContractRules,
      newContract,
      shortcuts,
      formContractRef,
    };
  },
});
</script>
