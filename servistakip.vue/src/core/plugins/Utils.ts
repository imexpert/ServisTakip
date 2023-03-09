import { Actions, Mutations } from "@/store/enums/StoreEnums";
import router from "@/router";
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { useStore } from 'vuex';

const store = useStore();

const showError = async (response) => {
    if(response.status == 401){
        store.commit(Mutations.PURGE_AUTH);
    }
    Swal.fire({
        title:'Hata',
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

  export default {
    showError
  };