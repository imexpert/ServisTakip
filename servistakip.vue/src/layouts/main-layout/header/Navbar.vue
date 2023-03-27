<template>
  <!--begin::Navbar-->
  <div class="app-navbar flex-shrink-0">
    <!--begin::User menu-->
    <div class="app-navbar-item ms-1 ms-lg-3" id="kt_header_user_menu_toggle">
      <!--begin::Menu wrapper-->
      <div
        class="cursor-pointer symbol symbol-35px symbol-md-40px"
        data-kt-menu-trigger="click"
        data-kt-menu-attach="parent"
        data-kt-menu-placement="bottom-end"
      >
        <img v-if="isManLogo" alt="Logo" src="media/avatars/man.png" />
        <img v-if="isWomanLogo" alt="Logo" src="media/avatars/woman.png" />
        <img v-if="isLogoExists" alt="Logo" :src="logoSrc" />
        <!-- <img src="media/avatars/300-1.jpg" alt="user" /> -->
      </div>
      <KTUserMenu />
      <!--end::Menu wrapper-->
    </div>
    <!--end::User menu-->
    <!--begin::Header menu toggle-->
    <div class="app-navbar-item d-lg-none ms-2 me-n3" title="Show header menu">
      <div class="btn btn-icon btn-active-color-primary w-35px h-35px" id="kt_app_header_menu_toggle">
        <span class="svg-icon svg-icon-1">
          <inline-svg src="media/icons/duotune/text/txt001.svg" />
        </span>
      </div>
    </div>
    <!--end::Header menu toggle-->
  </div>
  <!--end::Navbar-->
</template>

<script lang="ts">
import { defineComponent, computed, ref } from 'vue';
import KTSearch from '@/layouts/main-layout/search/Search.vue';
import KTNotificationMenu from '@/layouts/main-layout/menus/NotificationsMenu.vue';
import KTQuickLinksMenu from '@/layouts/main-layout/menus/QuickLinksMenu.vue';
import KTUserMenu from '@/layouts/main-layout/menus/UserAccountMenu.vue';
import KTThemeModeSwitcher from '@/layouts/main-layout/theme-mode/ThemeModeSwitcher.vue';
import { useStore } from 'vuex';
import JwtService from '@/core/services/JwtService';

export default defineComponent({
  name: 'header-navbar',
  components: {
    KTSearch,
    KTNotificationMenu,
    KTQuickLinksMenu,
    KTUserMenu,
    KTThemeModeSwitcher,
  },
  setup() {
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
      }
    } else {
      isLogoExists.value = true;
    }

    const themeMode = computed(() => {
      return store.getters.getThemeMode;
    });

    return {
      themeMode,
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
