import { Mutations } from "@/store/enums/StoreEnums";
import router from "@/router";
import Swal from 'sweetalert2/dist/sweetalert2.js';
import store from "@/store";
import { createApp } from "vue";

export const showError = (response: any): void => {
  if (response.status == 401) {
    store.commit(Mutations.PURGE_AUTH);
    router.push({ name: 'sign-in' });
  } else {
    Swal.fire({
      title: 'Hata',
      html: "İşlem sırasında hata oluştu",
      icon: 'error',
      buttonsStyling: false,
      confirmButtonText: 'Tamam',
      customClass: {
        confirmButton: 'btn btn-primary',
      },
    })
    .then(() => {
    });
  };
  return;
};

export const showSuccessMessage = (message: string): Swal => {
  return Swal.fire({
    title: 'Başarılı',
    html: message,
    icon: 'success',
    buttonsStyling: false,
    confirmButtonText: 'Tamam',
    customClass: {
      confirmButton: 'btn btn-primary',
    },
  });
}

export const showErrorMessage = (message: string): Swal => {
  Swal.fire({
    title: 'Hata',
    html: message,
    icon: 'error',
    buttonsStyling: false,
    confirmButtonText: 'Tamam',
    customClass: {
      confirmButton: 'btn btn-primary',
    },
  })
}

export const showWarningMessage = (message: string): Swal => {
  Swal.fire({
    title: 'Uyarı',
    html: message,
    icon: 'warning',
    buttonsStyling: false,
    confirmButtonText: 'Tamam',
    customClass: {
      confirmButton: 'btn btn-primary',
    },
  })
}