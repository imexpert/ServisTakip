<template>
  <!--begin::List Widget 1-->
  <div class="card" :class="widgetClasses">
    <!--begin::Header-->
    <div class="card-header border-0">
      <h3 class="card-title align-items-start flex-column">
        <span class="card-label fw-bold text-dark"></span>
      </h3>

      <div class="card-toolbar">
        <!--begin::Menu-->
        <button
          type="button"
          class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary"
          data-kt-menu-trigger="click"
          data-kt-menu-placement="bottom-end"
          data-kt-menu-flip="top-end"
        >
          <span class="svg-icon svg-icon-2">
            <inline-svg src="media/icons/duotune/general/gen024.svg" />
          </span>
        </button>
        <FirmaOzetDropdown></FirmaOzetDropdown>
        <!--end::Menu-->
      </div>
    </div>
    <!--end::Header-->

    <!--begin::Body-->
    <div class="card-body">
      <!--begin::Form-->
      <Form class="form" id="kt_modal_new_address_form">
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
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { ErrorMessage, Field, Form } from 'vee-validate';
import FirmaOzetDropdown from '@/components/dropdown/FirmaOzetDropdown.vue';

export default defineComponent({
  name: 'default-dashboard-widget-2',
  components: {
    FirmaOzetDropdown,
    ErrorMessage,
    Field,
    Form,
  },
  props: {
    widgetClasses: String,
  },
});
</script>
