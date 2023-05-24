<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-2">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-card class="box-card">
        <template #header>
          <div class="card-header">
            <span style="font-weight: bold; font-size: 16px; color: red">Kullanıcı Listesi</span>
          </div>
        </template>
        <el-table
          :data="userList"
          class="tableClass"
          height="150"
          max-height="150px"
          :default-sort="{ prop: 'startDate', order: 'descending' }"
        >
          <el-table-column label="Resim" width="140" label-class-name="tableHeader">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <img v-if="scope.row.avatar == ''" width="25" alt="Logo" src="/media/avatars/man.png" />
                <!-- <span>{{ scope.row.avatar }}</span> -->
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Ad" width="140" label-class-name="tableHeader">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.firstname }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Soyad" width="140" label-class-name="tableHeader">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.lastname }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Cinsiyet" width="160" label-class-name="tableHeader">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.gender == 1 ? 'Erkek' : 'Kadın' }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Durum" width="160" label-class-name="tableHeader">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.status == true ? 'Aktif' : 'Pasif' }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="E-Mail" width="200" label-class-name="tableHeader">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.email }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Son Giriş" width="160" label-class-name="tableHeader">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.lastLoginString }} </span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="Roller" width="220" label-class-name="tableHeader">
            <template #default="scope">
              <div style="display: flex; align-items: center">
                <span>{{ scope.row.groups }}</span>
              </div>
            </template>
          </el-table-column>
          <el-table-column label="#" fixed="left" width="140" label-class-name="tableHeader">
            <template #default="scope">
              <el-dropdown size="small" @click="kKullaniciDialogAc()" split-button type="danger">
                Yeni Ekle
                <template #dropdown>
                  <el-dropdown-menu>
                    <el-dropdown-item @click="kKullaniciDialogAc(scope.row.id)">
                      <el-icon>
                        <Edit></Edit>
                      </el-icon>
                      Düzenle
                    </el-dropdown-item>
                    <el-dropdown-item @click="kullaniciSil(scope.row.id)">
                      <el-icon>
                        <el-icon>
                          <Delete />
                        </el-icon>
                      </el-icon>
                      Sil
                    </el-dropdown-item>
                    <el-dropdown-item divided @click="kullaniciSil(scope.row.id)">
                      <el-icon>
                        <el-icon><SwitchButton /></el-icon>
                      </el-icon>
                      Oturumunu Kapat
                    </el-dropdown-item>
                  </el-dropdown-menu>
                </template>
              </el-dropdown>
            </template>
          </el-table-column>
        </el-table>
      </el-card>
    </div>
  </div>

  <el-dialog v-model="userDialogVisible" title="Kullanıcı Ekle / Düzenle" width="40%" destroy-on-close center>
    <div class="row">
      <el-form
        status-icon
        :rules="newUserRules"
        ref="formUserRef"
        :model="userItem"
        @submit.prevent="userSubmit()"
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
                  <el-option label="TL" value="TL" />
                  <el-option label="USD" value="USD" />
                  <el-option label="EURO" value="EURO" />
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
import { IUserData } from '@/core/data/UserData';
import { defineComponent, onMounted, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';

export default defineComponent({
  components: {},
  setup() {
    const store = useStore();

    const userDialogVisible = ref<boolean>(false);
    const userList = ref<Array<IUserData>>();
    const userItem = ref<IUserData>();
      var selectUserMode = ref<string>('I');

    const formUserRef = ref<null | HTMLFormElement>(null);

    const newUserRules = ref({
      firstname: [
        {
          required: true,
          message: 'Ad bilgisi girilmedi.',
          trigger: 'blur',
        },
      ],
      lastname: [
        {
          required: true,
          message: 'Soyad bilgisi girilmedi.',
          trigger: 'blur',
        },
      ],
      email: [
        {
          required: true,
          message: 'EMail bilgisi girilmedi.',
          trigger: 'blur',
        },
      ],
      password: [
        {
          required: true,
          message: 'Şifre bilgisi girilmedi.',
          trigger: 'blur',
        },
      ],
      gender: [
        {
          required: true,
          message: 'Cinsiyet bilgisi seçilmedi.',
          trigger: 'blur',
        },
      ],
    });

    async function getirKullaniciListe() {
      await store
        .dispatch(Actions.GET_USER_LIST)
        .then(async result => {
          if (result.isSuccess) {
            userList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function kKullaniciDialogAc(id = 0) {}

    async function kullaniciSil(id) {}

    const userSubmit = () => {
      if (!formUserRef.value) {
        return;
      }

      formUserRef.value.validate(valid => {
        if (valid) {
          if (selectUserMode.value == 'I') {
            store
              .dispatch(Actions.ADD_CONTRACT, newContract.value)
              .then(result => {
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

    onMounted(async () => {
      await getirKullaniciListe();
    });

    return {
      kKullaniciDialogAc,
      kullaniciSil,
      userSubmit,
      formUserRef,
      newUserRules,
      userList,
      userItem,
      userDialogVisible,
    };
  },
});
</script>
