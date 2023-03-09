import { Mutations } from "@/store/enums/StoreEnums";
import router from "@/router";
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { useStore } from 'vuex';
import { defineComponent, onMounted, ref } from 'vue';

export default defineComponent({
  setup() {
    const store = useStore();

    export function showError(response) {
      if (response.status == 401) {
        Swal.fire({
          title: 'Uyarı',
          html: 'Oturum süreniz dolmuştur.<br>Lütfen yeniden giriş yapınız.',
          icon: 'warning',
          buttonsStyling: false,
          confirmButtonText: 'Tamam',
          customClass: {
            confirmButton: 'btn btn-primary',
          },
        }).then(() => {
          store.commit(Mutations.PURGE_AUTH);
          router.push({ name: 'sign-in' });
        });
      } else {
        Swal.fire({
          title: 'Hata',
          text: 'İşlem sırasında hata oluştu',
          icon: 'error',
          buttonsStyling: false,
          confirmButtonText: 'Tamam',
          customClass: {
            confirmButton: 'btn btn-primary',
          },
        }).then(() => {

        });
      };
    }

    return {
      showError
    }
  }
})
