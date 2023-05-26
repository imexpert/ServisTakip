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
                <img v-else width="25" alt="Logo" :src="'data:image/jpeg;base64,' + scope.row.avatar" />
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
          <!-- Avatar -->
          <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Avatar Seçiniz</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="startDate">
                <el-upload
                  list-type="picture-card"
                  ref="uploadRef"
                  v-model:file-list="avatarList"
                  :limit="1"
                  :auto-upload="false"
                  :on-preview="handlePictureCardPreview"
                  :on-remove="handleRemove"
                  :on-change="handleChange"
                >
                  <el-icon><Plus /></el-icon>
                </el-upload>
                <el-dialog v-model="dialogVisible" width="250px">
                  <img width="200" :src="dialogImageUrl" alt="Preview Image" />
                </el-dialog>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <!-- Ad -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Ad</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="firstname">
                <el-input v-model="userItem.firstname" placeholder="Ad bilgisi giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Soyad -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Soyad</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="lastname">
                <el-input v-model="userItem.lastname" placeholder="Soyad bilgisi giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- E-Mail -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Email</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="email">
                <el-input v-model="userItem.email" placeholder="Email bilgisi giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Şifre -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Şifre</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="email">
                <el-input v-model="userItem.password" type="password" placeholder="Şifre bilgisi giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Cinsiyet -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Cinsiyet</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="gender">
                <el-select v-model="userItem.gender" placeholder="Cinsiyet">
                  <el-option label="Erkek" :value="1" />
                  <el-option label="Kadım" :value="2" />
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Durum -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Durum</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="status">
                <el-select v-model="userItem.status" placeholder="Durum">
                  <el-option label="Aktif" :value="true" />
                  <el-option label="Pasif" :value="false" />
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
import { IUserTempData } from '@/core/data/UserTempData';
import { IUserData } from '@/core/data/UserData';
import { defineComponent, onMounted, ref } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { showSuccessMessage, showErrorMessage } from '@/core/plugins/Utils';
import type { UploadProps, UploadFile, UploadUserFile, ElMessage, UploadInstance, UploadRawFile } from 'element-plus';
import { IUserModel } from '@/core/data/UserModel';

export default defineComponent({
  components: {},
  setup() {
    const store = useStore();

    const loading = ref<Boolean>(false);

    const dialogImageUrl = ref('');
    const dialogVisible = ref(false);
    const disabled = ref(false);
    const avatarList = ref<UploadUserFile[]>();
    const uploadRef = ref<UploadInstance>();

    const userDialogVisible = ref<boolean>(false);
    const userList = ref<Array<IUserData>>();
    const userItem = ref<IUserTempData>({
      email: '',
      firstname: '',
      lastname: '',
      gender: 1,
      status: true,
      password: null,
    });
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

    async function getirKullanici(id) {
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

    async function kKullaniciDialogAc(id = 0) {
      userDialogVisible.value = true;

      if (id > 0) {
        selectUserMode.value = 'U';
        await getirKullanici(id);
      } else {
        selectUserMode.value = 'I';
      }
    }

    async function kullaniciSil(id) {}

    const handleChange = (file: UploadFile) => {
      console.log(file);
    };

    const userSubmit = () => {
      if (!formUserRef.value) {
        return;
      }

      formUserRef.value.validate(async valid => {
        if (valid) {
          if (selectUserMode.value == 'I') {
            const formData = new FormData();
            formData.append('firstname', userItem.value.firstname);
            formData.append('lastname', userItem.value.lastname);
            formData.append('email', userItem.value.email);
            formData.append('password', userItem.value.password);
            formData.append('gender', userItem.value.gender.toString());
            formData.append('status', userItem.value.status.toString());
            formData.append('file', avatarList.value[0].raw);

            store
              .dispatch(Actions.ADD_USER, formData)
              .then(result => {
                if (result.isSuccess) {
                  showSuccessMessage('Kullanıcı başarıyla eklendi.').then(async () => {
                    await getirKullaniciListe();
                    userDialogVisible.value = false;
                  });
                } else {
                  showErrorMessage(result.message).then(() => {});
                }
              })
              .catch(({ response }) => {});
          } else {
          }
        }
      });
    };

    const handleRemove: UploadProps['onRemove'] = (uploadFile, uploadFiles) => {
      console.log(uploadFile, uploadFiles);
    };

    const handlePictureCardPreview = (file: UploadFile) => {
      dialogImageUrl.value = file.url!;
      dialogVisible.value = true;
      console.log(file);
    };

    const handleSuccess = (file: UploadFile) => {
      console.log(file);
    };

    onMounted(async () => {
      await getirKullaniciListe();
    });

    return {
      kKullaniciDialogAc,
      kullaniciSil,
      userSubmit,
      handleSuccess,
      handlePictureCardPreview,
      handleRemove,
      handleChange,
      avatarList,
      uploadRef,
      loading,
      dialogImageUrl,
      disabled,
      dialogVisible,
      formUserRef,
      newUserRules,
      userList,
      userItem,
      userDialogVisible,
    };
  },
});
</script>
<style scoped>
.avatar-uploader .avatar {
  width: 178px;
  height: 178px;
  display: block;
}
</style>

<style>
.avatar-uploader .el-upload {
  border: 1px dashed var(--el-border-color);
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
  transition: var(--el-transition-duration-fast);
}

.avatar-uploader .el-upload:hover {
  border-color: var(--el-color-primary);
}

.el-icon.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  width: 178px;
  height: 178px;
  text-align: center;
}
</style>
