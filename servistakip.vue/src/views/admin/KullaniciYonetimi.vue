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
          height="550"
          max-height="550px"
          :default-sort="{ prop: 'startDate', order: 'descending' }"
        >
          <el-table-column label="Resim" width="140" label-class-name="tableHeader">
            <template #default="scope">
              <div class="image-cropper">
                <img
                  v-if="scope.row.avatar == ''"
                  width="25"
                  alt="Logo"
                  src="/media/avatars/man.png"
                  class="circular--square"
                />
                <img
                  v-else
                  width="25"
                  alt="Logo"
                  :src="'data:image/jpeg;base64,' + scope.row.avatar"
                  class="circular--square"
                />
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
              <el-dropdown size="small" @click="kullaniciDialogAc()" split-button type="danger">
                Yeni Ekle
                <template #dropdown>
                  <el-dropdown-menu>
                    <el-dropdown-item @click="kullaniciDuzenleDialogAc(scope.row.id)">
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
                    <el-dropdown-item @click="kullaniciSifreDegistirDialogAc(scope.row.id)">
                      <el-icon><Refresh /></el-icon>
                      Şifre Değiştir
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

  <el-dialog v-model="userDialogVisible" title="Kullanıcı Ekle" width="40%" destroy-on-close center>
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
                  v-model:file-list="avatarList"
                  :limit="1"
                  :auto-upload="false"
                  :on-preview="handlePictureCardPreview"
                  :on-remove="handleRemove"
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

          <!-- Roller -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Roller</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="status">
                <el-select v-model="userItem.groupIds" placeholder="Rol seçiniz" multiple filterable clearable>
                  <el-option v-for="item in groupList" :key="item.id" :label="item.groupName" :value="item.id">
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

  <el-dialog v-model="updateUserDialogVisible" title="Kullanıcı Düzenle" width="40%" destroy-on-close center>
    <div class="row">
      <el-form
        status-icon
        :rules="updateUserRules"
        ref="formUserUpdateRef"
        :model="userItem"
        @submit.prevent="userUpdateSubmit()"
        label-width="120px"
        label-position="top"
      >
        <div class="row">
          <!-- Avatar -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Mevcut Avatar</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="avatar">
                <img
                  v-if="userItem.avatar"
                  height="150"
                  :src="'data:image/jpeg;base64,' + userItem.avatar"
                  class="mt-5"
                  alt="Preview Image"
                />
                <img v-else width="150" src="/media/avatars/man.png" class="mt-5" alt="Preview Image" />
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <!-- Avatar -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
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
                  v-model:file-list="avatarList"
                  :limit="1"
                  :auto-upload="false"
                  :on-preview="handlePictureCardPreview"
                  :on-remove="handleRemove"
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

          <!-- Roller -->
          <div class="col-md-12 col-lg-6 col-xl-6 col-xxl-6 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Roller</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="status">
                <el-select v-model="userItem.groupIds" placeholder="Rol seçiniz" multiple filterable clearable>
                  <el-option v-for="item in groupList" :key="item.id" :label="item.groupName" :value="item.id">
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
            <span v-if="!loading" class="indicator-label"> Düzenle </span>
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

  <el-dialog v-model="deleteUserDialogVisible" title="Şifre Değiştir" width="20%" destroy-on-close center>
    <div class="row">
      <el-form
        status-icon
        :rules="changePasswordUserRules"
        ref="formUserChangePasswordRef"
        :model="userPassword"
        @submit.prevent="userChangePasswordSubmit()"
        label-width="120px"
        label-position="top"
      >
        <div class="row">
          <!-- Mevcut Şifre -->
          <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Mevcut Şifre</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="currentPassword">
                <el-input type="password" v-model="userPassword.currentPassword" placeholder="Mevcut şifrenizi giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Yeni Şifre -->
          <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Yeni Şifre</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="password">
                <el-input type="password" v-model="userPassword.password" placeholder="Yeni şifrenizi giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>

          <!-- Mevcut Şifre -->
          <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                <span>Yeni Şifre (Tekrar)</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="passwordAgain">
                <el-input type="password" v-model="userPassword.passwordAgain" placeholder="Yeni şifrenizi tekrar giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
        </div>
        <!--begin::Actions-->
        <div class="text-center">
          <!--begin::Button-->
          <button :data-kt-indicator="loading ? 'on' : null" class="btn btn-lg btn-primary" type="submit">
            <span v-if="!loading" class="indicator-label"> Şifre Değiştir </span>
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
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { Actions } from '@/store/enums/StoreEnums';
import { showSuccessMessage, showErrorMessage } from '@/core/plugins/Utils';
import type { UploadProps, UploadFile, UploadUserFile, ElMessage, UploadInstance, UploadRawFile } from 'element-plus';
import { IGroupData } from '@/core/data/GroupData';
import { IUserPasswordData } from '@/core/data/UserPasswordData';

export default defineComponent({
  components: {},
  setup() {
    const store = useStore();

    const loading = ref<Boolean>(false);

    const dialogImageUrl = ref('');
    const dialogVisible = ref(false);
    const disabled = ref(false);
    const avatarList = ref<UploadUserFile[]>();
    const avatar = ref<UploadUserFile>();

    const userDialogVisible = ref<boolean>(false);
    const updateUserDialogVisible = ref<boolean>(false);
    const deleteUserDialogVisible = ref<boolean>(false);
    const userList = ref<Array<IUserData>>();
    const groupList = ref<Array<IGroupData>>();
    var userItem = ref<IUserTempData>({
      id: null,
      avatar: null,
      email: '',
      firstname: '',
      lastname: '',
      gender: 1,
      status: true,
      password: null,
      groups: [],
      groupIds: null,
    });

    var userPassword = ref<IUserPasswordData>({
      id: null,
      currentPassword: null,
      password: null,
      passwordAgain: null,
    });

    const formUserRef = ref<null | HTMLFormElement>(null);
    const formUserUpdateRef = ref<null | HTMLFormElement>(null);
    const formUserChangePasswordRef = ref<null | HTMLFormElement>(null);

    function clearForm() {
      userItem.value.id = null;
      userItem.value.avatar = null;
      userItem.value.email = null;
      userItem.value.firstname = null;
      userItem.value.lastname = null;
      userItem.value.gender = null;
      userItem.value.status = null;
      userItem.value.password = null;
      avatarList.value = [];
    }

    function clearPasswordForm() {
      userPassword.value.id = null;
      userPassword.value.password = null;
      userPassword.value.currentPassword = null;
      userPassword.value.passwordAgain = null;
    }

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

    const updateUserRules = ref({
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
      gender: [
        {
          required: true,
          message: 'Cinsiyet bilgisi seçilmedi.',
          trigger: 'blur',
        },
      ],
    });

    const changePasswordUserRules = ref({
      currentPassword: [
        {
          required: true,
          message: 'Mevcut şifre girilmedi.',
          trigger: 'blur',
        },
      ],
      password: [
        {
          required: true,
          message: 'Yeni şifre girilmedi.',
          trigger: 'blur',
        },
      ],
      passwordAgain: [
        {
          required: true,
          message: 'Yeni şifre bilgisi tekrar girilmeli.',
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

    async function getirGrupListe() {
      await store
        .dispatch(Actions.GET_GROUP_LIST)
        .then(async result => {
          if (result.isSuccess) {
            console.log(result.data);
            groupList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getirKullanici(id) {
      await store
        .dispatch(Actions.GET_USER, id)
        .then(async result => {
          if (result.isSuccess) {
            userItem.value = result.data;
            console.log(userItem.value);
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function kullaniciSifreDegistirDialogAc(id) {
      clearPasswordForm();
      userPassword.value.id = id;
      deleteUserDialogVisible.value = true;
    }

    async function kullaniciDialogAc() {
      clearForm();
      userDialogVisible.value = true;
    }

    async function kullaniciDuzenleDialogAc(id) {
      clearForm();
      updateUserDialogVisible.value = true;
      await getirKullanici(id);
    }

    async function kullaniciSil(id) {
      Swal.fire({
        title: 'Kullanıcı silinecek !!!',
        text: 'Devam etmek istiyor musunuz ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Sil',
        denyButtonText: `Vazgeç`,
      }).then(async result => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          await store
            .dispatch(Actions.DELETE_USER, id)
            .then(async result => {
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Kullanıcı başarıyla silindi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  await getirKullaniciListe();
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

    const userSubmit = () => {
      if (!formUserRef.value) {
        return;
      }

      formUserRef.value.validate(async valid => {
        if (valid) {
          const formData = new FormData();
          formData.append('firstname', userItem.value.firstname);
          formData.append('lastname', userItem.value.lastname);
          formData.append('email', userItem.value.email);
          formData.append('password', userItem.value.password);
          formData.append('gender', userItem.value.gender.toString());
          formData.append('status', userItem.value.status.toString());
          formData.append('file', avatarList.value[0].raw);
          formData.append('groups', userItem.value.groupIds.join());

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
        }
      });
    };

    const userUpdateSubmit = () => {
      if (!formUserUpdateRef.value) {
        return;
      }

      formUserUpdateRef.value.validate(async valid => {
        if (valid) {
          const formData = new FormData();
          formData.append('id', userItem.value.id.toString());
          formData.append('firstname', userItem.value.firstname);
          formData.append('lastname', userItem.value.lastname);
          formData.append('email', userItem.value.email);
          formData.append('gender', userItem.value.gender.toString());
          formData.append('status', userItem.value.status.toString());
          formData.append('groups', userItem.value.groupIds.join());

          if (avatarList.value?.length > 0) formData.append('file', avatarList.value[0].raw);

          store
            .dispatch(Actions.UPDATE_USER, formData)
            .then(result => {
              if (result.isSuccess) {
                showSuccessMessage('Kullanıcı başarıyla güncellendi.').then(async () => {
                  await getirKullaniciListe();
                  updateUserDialogVisible.value = false;
                });
              } else {
                showErrorMessage(result.message).then(() => {});
              }
            })
            .catch(({ response }) => {});
        }
      });
    };

    const userChangePasswordSubmit = () => {
      if (!formUserChangePasswordRef.value) {
        return;
      }

      formUserChangePasswordRef.value.validate(async valid => {
        if (valid) {
          store
            .dispatch(Actions.CHANGE_USER_PASSWORD, userPassword.value)
            .then(result => {
              if (result.isSuccess) {
                showSuccessMessage('Kullanıcı şifresi başarıyla güncellendi.').then(async () => {
                  deleteUserDialogVisible.value = false;
                });
              } else {
                showErrorMessage(result.message).then(() => {});
              }
            })
            .catch(({ response }) => {});
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

    onMounted(async () => {
      await getirKullaniciListe();
      await getirGrupListe();
    });

    return {
      kullaniciDialogAc,
      kullaniciSil,
      userSubmit,
      handlePictureCardPreview,
      handleRemove,
      kullaniciDuzenleDialogAc,
      userUpdateSubmit,
      userChangePasswordSubmit,
      kullaniciSifreDegistirDialogAc,
      changePasswordUserRules,
      userPassword,
      formUserChangePasswordRef,
      deleteUserDialogVisible,
      updateUserRules,
      formUserUpdateRef,
      updateUserDialogVisible,
      avatarList,
      loading,
      dialogImageUrl,
      disabled,
      dialogVisible,
      formUserRef,
      newUserRules,
      userList,
      userItem,
      userDialogVisible,
      groupList,
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

.circular--square {
  border-top-left-radius: 50% 50%;
  border-top-right-radius: 50% 50%;
  border-bottom-right-radius: 50% 50%;
  border-bottom-left-radius: 50% 50%;
}
</style>
