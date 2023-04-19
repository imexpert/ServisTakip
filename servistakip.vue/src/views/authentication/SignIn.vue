<template>
  <!--begin::Wrapper-->
  <div class="w-lg-500px bg-white rounded shadow-sm p-10 p-lg-15 mx-auto" v-loading="loading">
    <el-form
      status-icon
      :rules="loginRules"
      ref="formLoginRef"
      :model="loginModel"
      @submit.prevent="loginSubmit()"
      label-width="120px"
      label-position="top"
    >
      <!--begin::Heading-->
      <div class="text-center mb-10">
        <!--begin::Title-->
        <h1 class="text-dark mb-3">Servis Takip Sistemi</h1>
        <!--end::Title-->
      </div>
      <!--begin::Heading-->

      <!--begin::Input group-->
      <div class="fv-row mb-10">
        <!--begin::Label-->
        <label class="form-label fs-6 fw-bolder text-dark">E-Mail</label>
        <!--end::Label-->
        <el-form-item prop="email">
          <el-input
            class="w-150 m-2"
            size="large"
            v-model="loginModel.email"
            autocomplete="off"
            placeholder="E-Mail adresinizi giriniz"
          />
        </el-form-item>
      </div>
      <!--end::Input group-->

      <!--begin::Input group-->
      <div class="fv-row mb-10">
        <!--begin::Wrapper-->
        <div class="d-flex flex-stack mb-2">
          <!--begin::Label-->
          <label class="form-label fw-bolder text-dark fs-6 mb-0">Şifre</label>
          <!--end::Label-->

          <!--begin::Link-->
          <router-link to="/password-reset" class="link-primary fs-6 fw-bolder"> Şifremi Unuttum </router-link>
          <!--end::Link-->
        </div>
        <!--end::Wrapper-->

        <el-form-item prop="password">
          <!--begin::Input-->
          <el-input
            v-model="loginModel.password"
            type="password"
            class="w-150"
            size="large"
            placeholder="Şifrenizi giriniz"
            autocomplete="off"
            show-password
          />
          <!--end::Input-->
        </el-form-item>
      </div>
      <!--end::Input group-->

      <!--begin::Actions-->
      <div class="text-center">
        <!--begin::Button-->
        <button :data-kt-indicator="loading ? 'on' : null" class="btn btn-lg btn-primary w-100" type="submit">
          <span v-if="!loading" class="indicator-label"> Giriş </span>
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
  <!--end::Wrapper-->
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { Search } from '@element-plus/icons-vue';
import { ErrorMessage, Field, Form } from 'vee-validate';
import { Actions } from '@/store/enums/StoreEnums';
import { useStore } from 'vuex';
import { useRouter } from 'vue-router';
import Swal from 'sweetalert2/dist/sweetalert2.min.js';

interface ILoginModel {
  email: string;
  password: string;
}

import * as Yup from 'yup';

export default defineComponent({
  name: 'sign-in',
  components: {
    Field,
    Form,
    ErrorMessage,
    Search,
  },
  setup() {
    const store = useStore();
    const router = useRouter();

    const loading = ref<boolean>(false);

    var loginModel = ref<ILoginModel>({
      email: '',
      password: '',
    });

    const submitButton = ref<HTMLButtonElement | null>(null);

    const formLoginRef = ref<null | HTMLFormElement>(null);

    const loginRules = ref({
      email: [
        {
          required: true,
          message: 'Mail adresi girilmedi.',
          trigger: 'blur',
        },
      ],
      password: [
        {
          required: true,
          message: 'Şifre girilmedi.',
          trigger: 'blur',
        },
      ],
    });

    //Create form validation object
    const login = Yup.object().shape({
      email: Yup.string().email().required().label('Email'),
      password: Yup.string().min(4).required().label('Password'),
    });

    const loginSubmit = () => {
      if (!formLoginRef.value) {
        return;
      }

      formLoginRef.value.validate(async valid => {
        if (valid) {
          loading.value = true;

          await store
            .dispatch(Actions.LOGIN, loginModel.value)
            .then(result => {
              loading.value = false;
              if (result == null) {
                Swal.fire({
                  title: 'Hata',
                  html: 'Login işlemi sırasında hata oluştu.<br>Lütfen tekrar deneyiniz...',
                  icon: 'error',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam !',
                  customClass: {
                    confirmButton: 'btn fw-bold btn-danger',
                  },
                });
              } else {
                if (result.isSuccess) {
                  // Go to page after successfully login
                  router.push({ name: 'anaSayfa' });
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
              }
            })
            .catch(() => {
              const [error] = Object.keys(store.getters.getErrors);
            });
        }
      });
    };

    return {
      loginSubmit,
      login,
      submitButton,
      loginRules,
      loginModel,
      loading,
      formLoginRef,
    };
  },
});
</script>
