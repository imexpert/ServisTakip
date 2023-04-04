<template>
  <!--begin::Menu-->
  <div
    class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-semobold py-4 fs-6 w-275px"
    data-kt-menu="true"
  >
    <!--begin::Menu item-->
    <div class="menu-item px-3">
      <div class="menu-content d-flex align-items-center px-3">
        <!--begin::Avatar-->
        <div class="symbol symbol-50px me-5">
          <img v-if="isManLogo" alt="Logo" src="media/avatars/man.png" />
          <img v-if="isWomanLogo" alt="Logo" src="media/avatars/woman.png" />
          <img v-if="isLogoExists" alt="Logo" :src="logoSrc" />
        </div>
        <!--end::Avatar-->

        <!--begin::Username-->
        <div class="d-flex flex-column">
          <div class="fw-bold d-flex align-items-center fs-5">
            {{ fullName }}
            <span v-if="isAdmin == 'true'" class="badge badge-light-success fw-bold fs-8 px-2 py-1 ms-2">admin</span>
            <!-- <span class="badge badge-light-success fw-bold fs-8 px-2 py-1 ms-2"></span> -->
          </div>
          <a href="#" class="fw-semobold text-muted text-hover-primary fs-7">{{ email }}</a>
        </div>
        <!--end::Username-->
      </div>
    </div>
    <!--end::Menu item-->

    <!--begin::Menu separator-->
    <div class="separator my-2"></div>
    <!--end::Menu separator-->

    <!--begin::Menu item-->
    <div class="menu-item px-5">
      <router-link to="/pages/profile/overview" class="menu-link px-5"> Profilim </router-link>
    </div>
    <!--end::Menu item-->

    <!--begin::Menu item-->
    <div class="menu-item px-5">
      <router-link to="/pages/profile/overview" class="menu-link px-5">
        <span class="menu-text">Üzerimdeki İşler</span>
        <span class="menu-badge">
          <span class="badge badge-light-danger badge-circle fw-bold fs-7">3</span>
        </span>
      </router-link>
    </div>
    <!--end::Menu item-->

    <!--begin::Menu item-->
    <div class="menu-item px-5">
      <router-link to="/pages/profile/overview" class="menu-link px-5"> Mesajlarım </router-link>
    </div>
    <!--end::Menu item-->

    <!--begin::Menu separator-->
    <div class="separator my-2"></div>
    <!--end::Menu separator-->

    <!--begin::Menu item-->
    <div class="menu-item px-5">
      <a @click="signOut()" class="menu-link px-5"> Çıkış Yap </a>
    </div>
    <!--end::Menu item-->
  </div>
  <!--end::Menu-->
</template>

<script lang="ts">
import { defineComponent, computed, ref } from 'vue';
import { useI18n } from 'vue-i18n';
import { useStore } from 'vuex';
import { useRouter } from 'vue-router';
import { Actions } from '@/store/enums/StoreEnums';
import JwtService from '@/core/services/JwtService';

export default defineComponent({
  name: 'kt-user-menu',
  components: {},
  setup() {
    const router = useRouter();
    const i18n = useI18n();
    const store = useStore();

    const logoSrc = ref<string>('');

    const isLogoExists = ref<boolean>(false);
    const isManLogo = ref<boolean>(false);
    const isWomanLogo = ref<boolean>(false);

    const fullName = JwtService.getFullName();
    const email = JwtService.getEmail();
    const isAdmin = JwtService.isAdmin();
    const gender = JwtService.getGender();
    const avatar = JwtService.getAvatar();

    if (avatar == null || avatar == '') {
      isLogoExists.value = false;
      if (gender == '1') {
        isManLogo.value = true;
        isWomanLogo.value = false;
      } else if (gender == '2') {
        isManLogo.value = false;
        isWomanLogo.value = true;
      } else {
        isManLogo.value = true;
        isWomanLogo.value = false;
      }
    } else {
      isLogoExists.value = true;
    }

    console.log(isAdmin);

    const countries = {
      en: {
        flag: 'media/flags/united-states.svg',
        name: 'English',
      },
      es: {
        flag: 'media/flags/spain.svg',
        name: 'Spanish',
      },
      de: {
        flag: 'media/flags/germany.svg',
        name: 'German',
      },
      ja: {
        flag: 'media/flags/japan.svg',
        name: 'Japanese',
      },
      fr: {
        flag: 'media/flags/france.svg',
        name: 'French',
      },
    };

    const signOut = () => {
      store.dispatch(Actions.LOGOUT).then(() => router.push({ name: 'sign-in' }));
    };

    const setLang = lang => {
      localStorage.setItem('lang', lang);
      i18n.locale.value = lang;
    };

    const currentLanguage = lang => {
      return i18n.locale.value === lang;
    };

    const currentLangugeLocale = computed(() => {
      return countries[i18n.locale.value];
    });

    return {
      signOut,
      setLang,
      currentLanguage,
      currentLangugeLocale,
      countries,
      store,
      fullName,
      email,
      isAdmin,
      avatar,
      gender,
      isLogoExists,
      isManLogo,
      isWomanLogo,
      logoSrc,
    };
  },
});
</script>
