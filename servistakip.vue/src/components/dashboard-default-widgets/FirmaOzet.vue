<template>
  <!--begin::List Widget 1-->
  <div class="card" :class="widgetClasses">
    <div class="card-header">
      <div class="d-flex align-items-center me-5">
        <!--begin::Input group-->
        <div class="d-flex align-items-center flex-shrink-0">
          <!--begin::Label-->
          <span class="fs-7 text-gray-700 fw-bold pe-3 d-none d-md-block">İşlemler:</span>
          <!--end::Label-->
          <!--begin::Actions-->
          <div class="d-flex flex-shrink-0">
            <!--begin::Button-->
            <div>
              <button
                class="btn btn-sm btn-icon btn-active-color-success"
                title="Yeni Müşteri Ekle"
                data-bs-toggle="modal"
                data-bs-target="#kt_modal_new_customer"
              >
                <!--begin::Svg Icon | path: icons/duotune/general/gen035.svg-->
                <span class="svg-icon svg-icon-2x">
                  <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <rect opacity="0.3" x="2" y="2" width="20" height="20" rx="5" fill="currentColor"></rect>
                    <rect
                      x="10.8891"
                      y="17.8033"
                      width="12"
                      height="2"
                      rx="1"
                      transform="rotate(-90 10.8891 17.8033)"
                      fill="currentColor"
                    ></rect>
                    <rect x="6.01041" y="10.9247" width="12" height="2" rx="1" fill="currentColor"></rect>
                  </svg>
                </span>
                <!--end::Svg Icon-->
              </button>
            </div>
            <!--end::Button-->
          </div>
          <!--end::Actions-->
        </div>
        <!--end::Input group-->
      </div>
    </div>
    <!--begin::Body-->
    <div class="card-body">
      <!--begin::Form-->
      <Form class="form" id="customerInfoForm">
        <!--begin::Modal body-->
        <div class="modal-body">
          <!--begin::Scroll-->
          <div
            class="scroll-y me-n7 pe-7"
            id="kt_modal_new_address_scroll"
            data-kt-scroll="true"
            data-kt-scroll-activate="{default: false, lg: true}"
            data-kt-scroll-max-height="auto"
            data-kt-scroll-dependencies="#kt_modal_new_address_header"
            data-kt-scroll-wrappers="#kt_modal_new_address_scroll"
            data-kt-scroll-offset="300px"
          >
            <!--begin::Input group-->
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="required fs-5 fw-semobold mb-2">Cihaz No</label>
                <Field type="text" class="form-control form-control-sm" placeholder="" name="cihazno" />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="cihazno" />
                  </div>
                </div>
              </div>

              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Cari Kod</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="carikod"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="carikod" />
                  </div>
                </div>
              </div>

              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Sektör</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="sektor"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="sektor" />
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-1">
              <div class="col-md-8 fv-row">
                <label class="required fs-5 fw-semobold mb-2">Firma Unvan</label>
                <Field type="text" class="form-control form-control-sm" placeholder="" name="unvan" />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="unvan" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Bölge</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="bolge"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="bolge" />
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Şehir</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">İlçe</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Semt</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Yetkili Ad Soyad</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Yetkili Görevi</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Yetkili E-Mail</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-1">
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Tel</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Cep Tel</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
              <div class="col-md-4 fv-row">
                <label class="fs-5 fw-semobold mb-2">Dahili</label>
                <Field
                  type="text"
                  disabled
                  class="form-control form-control-solid form-control-sm"
                  placeholder=""
                  name="departman"
                />
                <div class="fv-plugins-message-container">
                  <div class="fv-help-block">
                    <ErrorMessage name="departman" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Form>
    </div>
    <!--end::Body-->
  </div>
  <!--end::List Widget 1-->

  <div class="modal fade" tabindex="-1" id="kt_modal_new_customer" ref="kt_modal_new_customerRef">
    <div class="modal-dialog modal-dialog-centered mw-650px">
      <div class="modal-content rounded">
        <div class="modal-header pb-0 border-0 justify-content-center">
          <h5 class="modal-title">YENİ MÜŞTERİ EKLEME</h5>

          <!--begin::Close-->
          <div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
            <span class="svg-icon svg-icon-2x"></span>
          </div>
          <!--end::Close-->
        </div>

        <div class="modal-body scroll-y px-10 px-lg-15 pt-0 pb-15 mt-5">
          <Form
            class="form w-100"
            id="kt_login_signin_form"
            :model="customerData"
            :rules="rules"
            ref="formRef"
            @submit="submit"
          >
            <!--begin::Input group-->
            <div class="fv-row mb-10">
              <!--begin::Label-->
              <label class="form-label fs-6 fw-bolder text-dark">Müşteri Unvanı</label>
              <!--end::Label-->

              <!--begin::Input-->
              <Field class="form-control form-control-lg" type="text" name="title" autocomplete="off" />
              <!--end::Input-->
              <div class="fv-plugins-message-container">
                <div class="fv-help-block">
                  <ErrorMessage name="title" />
                </div>
              </div>
            </div>
            <!--end::Input group-->

            <!--begin::Input group-->
            <div class="fv-row mb-10">
              <!--begin::Label-->
              <label class="form-label fs-6 fw-bolder text-dark">Müşteri Sektörü</label>
              <!--end::Label-->

              <!--begin::Input-->
              <SectorDropdown v-model:sector.sync="customerData.sector" />
              <!--end::Input-->
              <div class="fv-plugins-message-container">
                <div class="fv-help-block">
                  <ErrorMessage name="sector" />
                </div>
              </div>
            </div>
            <!--end::Input group-->

            <!--begin::Actions-->
            <div class="text-center">
              <!--begin::Submit button-->
              <button type="submit" ref="submitButton" id="kt_sign_in_submit" class="btn btn-lg btn-primary w-100 mb-5">
                <span class="indicator-label"> Kaydet </span>

                <span class="indicator-progress">
                  Please wait...
                  <span class="spinner-border spinner-border-sm align-middle ms-2"></span>
                </span>
              </button>
              <!--end::Submit button-->
            </div>
            <!--end::Actions-->
          </Form>

          <!--end:Form-->
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { ErrorMessage, Field, Form } from 'vee-validate';
import FirmaOzetDropdown from '@/components/dropdown/FirmaOzetDropdown.vue';
import SectorDropdown from '@/components/dropdown/SectorDropdown.vue';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { useStore } from 'vuex';
import { useRouter } from 'vue-router';

interface NewCustomerData {
  title: string;
  sector: string;
}

import * as Yup from 'yup';

export default defineComponent({
  name: 'default-dashboard-widget-2',
  components: {
    FirmaOzetDropdown,
    SectorDropdown,
    ErrorMessage,
    Field,
    Form,
  },
  setup() {
    const store = useStore();
    const router = useRouter();

    const formRef = ref<null | HTMLFormElement>(null);

    const customerData = ref<NewCustomerData>({
      title: '',
      sector: '1',
    });

    const rules = ref({
      title: [
        {
          required: true,
          message: 'Müşteri unvanı boş geçilemez',
          trigger: 'blur',
        },
      ],
      sector: [
        {
          required: true,
          message: 'Müşteri sektörü boş geçilemez',
          trigger: 'blur',
        },
      ],
    });

    const submitButton = ref<HTMLButtonElement | null>(null);

    const submit = () => {
      if (!formRef.value) {
        alert('sdf');
        return;
      }

      console.log(customerData);
      formRef.value.validate(valid => {
        if (valid) {
        }
      });
    };

    return {
      submit,
      submitButton,
      customerData,
      rules,
    };
  },
  props: {
    widgetClasses: String,
  },
});
</script>
