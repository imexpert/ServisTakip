<template>
  <div class="row">
    <!--begin::Col-->
    <div class="col-md-6 col-lg-6 col-xl-6 col-xxl-6">
      <!--begin::List Widget 1-->
      <div class="card">
        <div class="card-header">
          <div class="d-flex align-items-center me-5">
            <el-dropdown split-button type="primary">
              İşlemler
              <template #dropdown>
                <el-dropdown-menu>
                  <el-dropdown-item @click="routeAddCustomer">Yeni Müşteri Ekle</el-dropdown-item>
                  <el-dropdown-item @click="routeUpdateCustomer">Müşteri Düzenle</el-dropdown-item>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
          </div>
          <div class="d-flex align-items-center me-5">
            <el-button-group>
              <el-button type="primary" title="Önceki Cihaz" @click="cihazListesi()">
                <el-icon> <Plus /> </el-icon>&nbsp; Hızlı Servis Aç
              </el-button>
              <el-button type="primary" title="Önceki Cihaz" @click="servisAc()">
                <el-icon> <Plus /> </el-icon>&nbsp; Servis Aç
              </el-button>
            </el-button-group>
          </div>
          <div class="d-flex align-items-center me-5">
            <el-button-group>
              <el-button type="danger" title="Önceki Cihaz" @click="cihazListesi()">
                <el-icon> <List /> </el-icon>&nbsp; Cihaz Listesi
              </el-button>
            </el-button-group>
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
                    <el-select
                      @change="onDeviceNoChange()"
                      filterable
                      remote
                      clearable
                      placeholder="Cihaz no giriniz"
                      reserve-keyword
                      remote-show-suffix
                      v-model="selectedDevice"
                      :remote-method="remoteMethodCihazNo"
                      :loading="loading"
                    >
                      <li class="el-select-dropdown__item">
                        <div class="row">
                          <div class="col-md-6">
                            <span style="font-weight: 900"> Unvan </span>
                          </div>
                          <div class="col-md-2">
                            <span style="font-weight: 900"> Semt </span>
                          </div>
                          <div class="col-md-3">
                            <span style="font-weight: 900"> Model </span>
                          </div>
                          <div class="col-md-1">
                            <span style="font-weight: 900"> Seri No </span>
                          </div>
                        </div>
                      </li>
                      <el-option v-for="item in deviceList" :key="item.rowId" :label="item.id" :value="item.rowId">
                        <div class="row">
                          <div class="col-md-6" style="font-size: 12px">
                            {{ item.address.customer.title }}
                          </div>
                          <div class="col-md-2" style="font-size: 12px">
                            {{ item.address.querter.name }}
                          </div>
                          <div class="col-md-3" style="font-size: 12px">
                            {{ item.deviceModel.name }}
                          </div>
                          <div class="col-md-1" style="font-size: 12px">
                            {{ item.serialNumber }}
                          </div>
                        </div>
                      </el-option>
                    </el-select>
                  </div>

                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">Cari Kod</label>
                    <el-input readonly disabled v-model="firmaOzet.accountCode" class="input-with-select"> </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="carikod" />
                      </div>
                    </div>
                  </div>

                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">Sektör</label>
                    <el-input readonly disabled v-model="firmaOzet.customerSector" class="input-with-select">
                    </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="sektor" />
                      </div>
                    </div>
                  </div>
                </div>
                <div class="row mb-1">
                  <div class="col-md-12 fv-row">
                    <label class="required fs-5 fw-semobold mb-2">Firma Unvan</label>
                    <el-select
                      @change="onCustomerChange()"
                      filterable
                      remote
                      clearable
                      placeholder="Arama için en az 4 harf giriniz"
                      reserve-keyword
                      remote-show-suffix
                      v-model="selectedCustomer"
                      :remote-method="remoteMethod"
                      :loading="loading"
                    >
                      <li class="el-select-dropdown__item">
                        <div class="row">
                          <div class="col-md-6">
                            <span style="font-weight: 900"> Unvan </span>
                          </div>
                          <div class="col-md-2">
                            <span style="font-weight: 900"> Semt </span>
                          </div>
                          <div class="col-md-3">
                            <span style="font-weight: 900"> Model </span>
                          </div>
                          <div class="col-md-1">
                            <span style="font-weight: 900"> Seri No </span>
                          </div>
                        </div>
                      </li>
                      <el-option
                        v-for="item in customerInfoList"
                        :key="item.rowId"
                        :label="item.title"
                        :value="item.rowId"
                      >
                        <div class="row">
                          <div class="col-md-6" style="font-size: 12px">
                            {{ item.title }}
                          </div>
                          <div class="col-md-2" style="font-size: 12px">
                            {{ item.querter }}
                          </div>
                          <div class="col-md-3" style="font-size: 12px">
                            {{ item.model }}
                          </div>
                          <div class="col-md-1" style="font-size: 12px">
                            {{ item.serialNo }}
                          </div>
                        </div>
                      </el-option>
                    </el-select>
                  </div>
                </div>
                <div class="row mb-1">
                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">Şehir</label>
                    <el-input readonly disabled v-model="firmaOzet.cityName" class="input-with-select"> </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="departman" />
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">İlçe</label>
                    <el-input readonly disabled v-model="firmaOzet.districtName" class="input-with-select"> </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="departman" />
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">Semt</label>
                    <el-input readonly disabled v-model="firmaOzet.quarterName" class="input-with-select"> </el-input>
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
                    <el-input readonly disabled v-model="firmaOzet.authorizedName" class="input-with-select">
                    </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="departman" />
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">Yetkili Görevi</label>
                    <el-input readonly disabled v-model="firmaOzet.authorizedTask" class="input-with-select">
                    </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="departman" />
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">Yetkili E-Mail</label>
                    <el-input readonly disabled v-model="firmaOzet.authorizedEmail" class="input-with-select">
                    </el-input>
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
                    <el-input readonly disabled v-model="firmaOzet.authorizedPhone" class="input-with-select">
                    </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="departman" />
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 fv-row">
                    <label class="fs-5 fw-semobold mb-2">Bölge</label>
                    <el-input readonly disabled v-model="firmaOzet.regionCode" class="input-with-select"> </el-input>
                    <div class="fv-plugins-message-container">
                      <div class="fv-help-block">
                        <ErrorMessage name="bolge" />
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
    </div>
    <!--begin::Col-->
    <div class="col-md-6 col-lg-6 col-xl-6 col-xxl-6">
      <div class="row">
        <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-5">
          <el-card class="box-card" style="height: 258px">
            <template #header>
              <div class="card-header">
                <div class="row">
                  <div class="col-md-9">
                    <span style="color: #f56c6c; font-size: 13pt; font-weight: 700">Sözleşmeler</span>
                  </div>
                  <div class="col-md-3" style="text-align: right">
                    <el-dropdown split-button type="success">
                      Tam Ekran
                      <template #dropdown>
                        <el-dropdown-menu>
                          <el-dropdown-item>Yeni Ekle</el-dropdown-item>
                          <el-dropdown-item>Aktar - Excel</el-dropdown-item>
                        </el-dropdown-menu>
                      </template>
                    </el-dropdown>
                  </div>
                </div>
              </div>
            </template>
            <div class="text item">
              <el-table
                :data="contracts"
                style="width: 100%"
                max-height="147"
                :default-sort="{ prop: 'startDate', order: 'descending' }"
              >
                <el-table-column label="Başlangıç Tarihi" width="160" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.startDateString }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Bitiş Tarihi" width="150" sortable>
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.endDateString }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Sözleşme Kodu" width="160">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.contractCode }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Bakım Periyodu" width="160">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.maintenancePeriod }} Aylık</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Fiyat" width="120">
                  <template>
                    <div style="display: flex; align-items: center">
                      <span>-</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="#" fixed="right">
                  <template>
                    <el-button size="small" type="primary" circle>
                      <el-icon>
                        <Edit />
                      </el-icon>
                    </el-button>
                    <el-button size="small" type="danger" circle>
                      <el-icon>
                        <Delete />
                      </el-icon>
                    </el-button>
                  </template>
                </el-table-column>
              </el-table>
            </div>
          </el-card>
        </div>
        <div class="col-md-5 col-lg-5 col-xl-5 col-xxl-5">
          <el-card class="box-card">
            <div class="row align-items-center">
              <div class="col-md-6 mx-auto">
                <label class="fs-5 fw-semobold">Model</label>
              </div>
              <div class="col-md-6">
                <el-select
                  @change="onModelNameChange()"
                  filterable
                  remote
                  clearable
                  placeholder="Model adı giriniz"
                  reserve-keyword
                  remote-show-suffix
                  v-model="selectedModelName"
                  :remote-method="remoteMethodModelName"
                  :loading="loading"
                >
                  <li class="el-select-dropdown__item">
                    <div class="row">
                      <div class="col-md-6">
                        <span style="font-weight: 900"> Unvan </span>
                      </div>
                      <div class="col-md-2">
                        <span style="font-weight: 900"> Semt </span>
                      </div>
                      <div class="col-md-3">
                        <span style="font-weight: 900"> Model </span>
                      </div>
                      <div class="col-md-1">
                        <span style="font-weight: 900"> Seri No </span>
                      </div>
                    </div>
                  </li>
                  <el-option v-for="item in modelList" :key="item.rowId" :label="item.model" :value="item.rowId">
                    <div class="row">
                      <div class="col-md-6" style="font-size: 12px">
                        {{ item.title }}
                      </div>
                      <div class="col-md-2" style="font-size: 12px">
                        {{ item.querter }}
                      </div>
                      <div class="col-md-3" style="font-size: 12px">
                        {{ item.model }}
                      </div>
                      <div class="col-md-1" style="font-size: 12px">
                        {{ item.serialNo }}
                      </div>
                    </div>
                  </el-option>
                </el-select>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold">Seri No</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-select
                  @change="onSerialNoChange()"
                  filterable
                  remote
                  clearable
                  placeholder="Seri no giriniz"
                  reserve-keyword
                  remote-show-suffix
                  v-model="selectedSerialNo"
                  :remote-method="remoteMethodSerialNo"
                  :loading="loading"
                >
                  <li class="el-select-dropdown__item">
                    <div class="row">
                      <div class="col-md-6">
                        <span style="font-weight: 900"> Unvan </span>
                      </div>
                      <div class="col-md-2">
                        <span style="font-weight: 900"> Semt </span>
                      </div>
                      <div class="col-md-3">
                        <span style="font-weight: 900"> Model </span>
                      </div>
                      <div class="col-md-1">
                        <span style="font-weight: 900"> Seri No </span>
                      </div>
                    </div>
                  </li>
                  <el-option v-for="item in seriNoList" :key="item.rowId" :label="item.serialNo" :value="item.rowId">
                    <div class="row">
                      <div class="col-md-6" style="font-size: 12px">
                        {{ item.title }}
                      </div>
                      <div class="col-md-2" style="font-size: 12px">
                        {{ item.querter }}
                      </div>
                      <div class="col-md-3" style="font-size: 12px">
                        {{ item.model }}
                      </div>
                      <div class="col-md-1" style="font-size: 12px">
                        {{ item.serialNo }}
                      </div>
                    </div>
                  </el-option>
                </el-select>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold">Marka</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled v-model="firmaOzet.device.deviceModel.deviceBrand.name" style="font-size: 12px">
                </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold">Montaj Tarihi</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled v-model="firmaOzet.device.assemblyDateString" style="font-size: 12px"> </el-input>
              </div>
            </div>
          </el-card>
        </div>
        <div class="col-md-4 col-lg-4 col-xl-4 col-xxl-4">
          <el-card class="box-card">
            <div class="row">
              <div class="col-md-6 pt-2">
                <label class="fs-5 fw-semobold">Söz. Tipi</label>
              </div>
              <div class="col-md-6 pt-2">
                <el-input disabled v-model="firmaOzet.contractType"></el-input>
              </div>
              <div class="col-md-6 pt-2 mt-2">
                <label class="fs-5 fw-semobold mb-2">Cihaz Durumu</label>
              </div>
              <div class="col-md-6 mt-2">
                <input
                  type="text"
                  disabled
                  class="form-control form-control-sm form-control-solid border border-secondary"
                  style="color: #a8abb2"
                  :style="{ backgroundColor: firmaOzet.backgroundColor }"
                  name="row-name"
                  v-model="firmaOzet.deviceStatus"
                />
              </div>
              <div class="col-md-6 pt-2 mt-2">
                <label class="fs-5 fw-semobold mb-2">Bk. Durumu</label>
              </div>
              <div class="col-md-6 mt-2">
                <input
                  type="text"
                  disabled
                  class="form-control form-control-sm form-control-solid border border-secondary"
                  style="color: #a8abb2"
                  name="row-name"
                  :style="{ backgroundColor: firmaOzet.maintenanceBackgroundColor }"
                  v-model="firmaOzet.contractMaintenanceStatus"
                />
              </div>
            </div>
          </el-card>
        </div>

        <div class="col-md-3 col-lg-3 col-xl-3 col-xxl-3">
          <el-card class="box-card">
            <div class="row">
              <div class="col-md-6">
                <label class="fs-5 fw-semobold mb-2">S/B Sayaç</label>
              </div>
              <div class="col-md-6">
                <el-input disabled v-model="firmaOzet.wbCount"> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold mb-2">R.Sayaç</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled v-model="firmaOzet.colorCount"> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold mb-2">T.Sayaç</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled v-model="firmaOzet.totalCount"> </el-input>
              </div>
            </div>
          </el-card>
        </div>
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col-md-8 col-lg-8 col-xl-8 col-xxl-8">
      <el-card class="box-card">
        <template #header>
          <div class="card-header">
            <div class="row">
              <div class="col-md-9">
                <span style="color: #f56c6c; font-size: 14pt; font-weight: 700">Açılan Servis Kayıtları</span>
              </div>
              <div class="col-md-3" style="text-align: right">
                <el-dropdown split-button type="success">
                  Tam Ekran
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item>Yeni Ekle</el-dropdown-item>
                      <el-dropdown-item>Aktar - Excel</el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </div>
            </div>
          </div>
        </template>
        <div class="text item">
          <el-table :data="deviceServices" height="200" max-height="200" style="width: 100%; font-size: 12px">
            <el-table-column label="Açılış Tarihi" width="145" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Tek.Ver.Tarihi" width="145" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.userAssignDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Kapanış Tarihi" width="145">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.resultDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="S/B" width="80">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.wbCount }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Renkli" width="80">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.colorCount }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Ser.Kod" width="80">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceBootCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Tes.Kodu" width="80">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.detectionCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Son.Kodu" width="90">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceResultCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.user.firstname }} {{ scope.row.user.lastname }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Dr" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.dr }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Dv" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.dv }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Bc" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.bc }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Fs" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.fs }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Pa" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.pa }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Bk" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.bk }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Ak" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.ak }}</span>
                </div>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </el-card>
    </div>
    <div class="col-md-4 col-lg-4 col-xl-4 col-xxl-4">
      <el-card class="box-card">
        <div class="text item">
          <el-tabs tab-position="left" style="height: 268px" class="demo-tabs">
            <el-tab-pane label="Orjinal Toner">User</el-tab-pane>
            <el-tab-pane label="Muadil Toner">Config</el-tab-pane>
            <el-tab-pane label="Main Kit">Role</el-tab-pane>
            <el-tab-pane label="Cihaz">Task</el-tab-pane>
            <el-tab-pane label="K.Paneli">Task</el-tab-pane>
            <el-tab-pane label="K.Kılavuzu">Task</el-tab-pane>
            <el-tab-pane label="Teknik Bilgi">Task</el-tab-pane>
            <el-tab-pane label="Aksesuar">Task</el-tab-pane>
          </el-tabs>
        </div>
      </el-card>
    </div>
  </div>

  <el-dialog v-model="centerDialogVisible" title="Cihaz Listesi" width="50%" destroy-on-close center>
    <div class="row">
      <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-5">
        <el-card class="box-card" style="height: 300px">
          <div class="text item">
            <el-table :data="customerDeviceList" style="width: 100%" max-height="300">
              <el-table-column label="Cihaz No" width="160" sortable>
                <template #default="scope">
                  <div style="display: flex; align-items: center">
                    <span>{{ scope.row.id }}</span>
                  </div>
                </template>
              </el-table-column>
              <el-table-column label="Marka" width="160" sortable>
                <template #default="scope">
                  <div style="display: flex; align-items: center">
                    <span>{{ scope.row.deviceModel.deviceBrand.name }}</span>
                  </div>
                </template>
              </el-table-column>
              <el-table-column label="Model" width="160" sortable>
                <template #default="scope">
                  <div style="display: flex; align-items: center">
                    <span>{{ scope.row.deviceModel.name }}</span>
                  </div>
                </template>
              </el-table-column>
              <el-table-column label="Seri No" width="160" sortable>
                <template #default="scope">
                  <div style="display: flex; align-items: center">
                    <span>{{ scope.row.serialNumber }}</span>
                  </div>
                </template>
              </el-table-column>
              <el-table-column label="Cihaz Durumu" width="150" sortable>
                <template #default="scope">
                  <div style="display: flex; align-items: center">
                    <span>{{ scope.row.status ? 'Aktif' : 'Pasif' }}</span>
                  </div>
                </template>
              </el-table-column>
              <el-table-column label="#" fixed="left">
                <template #default="scope">
                  <el-button
                    size="small"
                    type="primary"
                    circle
                    title="Cihaz Seç"
                    @click="getMainPageCustomer(scope.row.rowId)"
                  >
                    <el-icon><Select /></el-icon>
                  </el-button>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </el-card>
      </div>
    </div>
  </el-dialog>

  <el-dialog v-model="servisAcDialogVisible" title="Yeni Servis" width="40%" destroy-on-close center>
    <div class="row">
      <el-form
        status-icon
        :rules="newServiceRules"
        ref="formServiceRef"
        :model="newService"
        @submit.prevent="servicAcSubmit()"
        label-width="120px"
        label-position="top"
      >
        <div class="row">
          <div class="col-md-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Firma Unvan</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="customerTitle">
                <el-input v-model="firmaOzet.customerTitle" disabled></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Servis Açılış Tarihi</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="failureDate">
                <el-date-picker
                  v-model="newService.failureDate"
                  format="DD.MM.YYYY HH:mm:ss"
                  type="datetime"
                  placeholder="Select date and time"
                  :shortcuts="shortcuts"
                />
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Servis Açılış Kodu</span>
              </label>
              <!--end::Label-->
              <el-form-item prop="serviceBootCode">
                <el-select placeholder="Servis Kodu" filterable clearable v-model="newService.serviceBootCode">
                  <el-option v-for="item in bootCodeList" :key="item.code" :label="item.name" :value="item.code">
                    <div class="row">
                      <div class="col-md-3" style="font-size: 12px">
                        {{ item.code }}
                      </div>
                      <div class="col-md-9" style="font-size: 12px">
                        {{ item.name }}
                      </div>
                    </div>
                  </el-option>
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-12">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Açıklama</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="bootDescription">
                <el-input v-model="newService.bootDescription" placeholder="Servis açıklamasını giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Talep Bildiren</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="name">
                <el-input v-model="newService.name" placeholder="Talebi bildiren ad giriniz"></el-input>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span class="required">Telefon</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="phone">
                <el-input
                  v-model="newService.phone"
                  :formatter="
                    value => value.replace(/\D/g, '').replace(/^(\d{3})(\d{3})(\d{2})(\d{2}).*/, '+90-($1)-$2-$3-$4')
                  "
                  placeholder="Talebi bildiren telefon giriniz"
                />
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Teknisyen</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="technicianName">
                <el-select placeholder="Teknisyen" filterable clearable v-model="newService.userId">
                  <el-option
                    v-for="item in technicianUserList"
                    :key="item.id"
                    :label="item.firstname + item.lastname"
                    :value="item.id"
                  >
                    <div class="row">
                      <div class="col-md-9" style="font-size: 12px">{{ item.firstname }} {{ item.lastname }}</div>
                    </div>
                  </el-option>
                </el-select>
              </el-form-item>
            </div>
            <!--end::Input group-->
          </div>
          <div class="col-md-6">
            <!--begin::Input group-->
            <div class="d-flex flex-column mb-1 fv-row">
              <!--begin::Label-->
              <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                <span>Teknisyen Atanma Tarihi</span>
              </label>
              <!--end::Label-->

              <el-form-item prop="userAssignDate">
                <el-date-picker
                  v-model="newService.userAssignDate"
                  format="DD.MM.YYYY HH:mm:ss"
                  type="datetime"
                  placeholder="Select date and time"
                  :shortcuts="shortcuts"
                />
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
import { defineComponent, onMounted, ref } from 'vue';
import { ErrorMessage, Field, Form } from 'vee-validate';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { Plus, Search } from '@element-plus/icons-vue';
import { useRoute, useRouter } from 'vue-router';

import Swal from 'sweetalert2/dist/sweetalert2.js';
import { hideModal } from '@/core/helpers/dom';
import { IFirmaOzetData } from '@/core/data/FirmaOzetData';
import { IDeviceServiceData } from '@/core/data/DeviceServiceData';
import { IUserData } from '@/core/data/UserData';
import { IBootCodeData } from '@/core/data/BootCodeData';
import { IDeviceData } from '@/core/data/DeviceData';
import { ICustomerListData } from '@/core/data/CustomerListData';
import { IDeviceBrandData } from '@/core/data/DeviceBrandData';
import { IDeviceModelData } from '@/core/data/DeviceModelData';
import { IContractData } from '@/core/data/ContractData';
import { ICustomerData } from '@/core/data/CustomerData';

export default defineComponent({
  name: 'default-dashboard-widget-2',
  components: {
    ErrorMessage,
    Field,
    Form,
    Search,
    Plus,
  },
  setup() {
    const centerDialogVisible = ref(false);
    const servisAcDialogVisible = ref(false);
    const store = useStore();
    const loading = ref<boolean>(false);
    const router = useRouter();

    var firmaOzet = ref<IFirmaOzetData>({
      customerId: '',
      customerTitle: '',
      customerSectorId: '',
      customerSector: '',
      accountCode: '',
      authorizedName: '',
      authorizedPhone: '',
      authorizedTask: '',
      cityName: '',
      authorizedEmail: '',
      deviceId: '',
      districtName: '',
      quarterName: '',
      regionCode: '',
      contractType: '',
      wbCount: '',
      colorCount: '',
      totalCount: '',
      deviceStatus: '',
      maintenanceStatus: '-',
      deviceModel: null,
      deviceBrand: null,
      device: null,
    });

    const shortcuts = [
      {
        text: 'Bugün',
        value: new Date(),
      },
      {
        text: 'Dün',
        value: () => {
          const date = new Date();
          date.setTime(date.getTime() - 3600 * 1000 * 24);
          return date;
        },
      },
    ];

    var newService = ref<IDeviceServiceData>({
      deviceId: firmaOzet.value.deviceId,
      failureDate: '',
      serviceBootCode: '',
      bootDescription: '',
      name: '',
      phone: '',
      userId: '',
      userAssignDate: '',
    });

    var selectedDevice = ref<string>('');
    var selectedCustomer = ref<string>('');
    var technicianUserList = ref<Array<IUserData>>([]);
    var customerList = ref<Array<ICustomerData>>([]);
    var deviceList = ref<Array<IDeviceData>>([]);
    var deviceServices = ref<Array<IDeviceServiceData>>([]);

    var contracts = ref<Array<IContractData>>([]);
    var device = ref<IDeviceData>();

    var bootCodeList = ref<Array<IBootCodeData>>([]);

    var sectorList = [
      {
        id: 0,
        name: '',
      },
    ];

    var customerInfoList = ref<Array<ICustomerListData>>([]);
    var customerDeviceList = ref<Array<IDeviceData>>([]);
    var deviceServices = ref<Array<IDeviceServiceData>>([]);
    var modelList = ref<Array<ICustomerListData>>([]);
    var seriNoList = ref<Array<ICustomerListData>>([]);
    var deviceBrand = ref<IDeviceBrandData>();
    var selectedSerialNo = ref<string>();
    var selectedModelName = ref<string>();

    const formServiceRef = ref<null | HTMLFormElement>(null);

    const newServiceRules = ref({
      failureDate: [
        {
          required: true,
          message: 'Servis açılış girilmedi.',
          trigger: 'blur',
        },
      ],
      serviceBootCode: [
        {
          required: true,
          message: 'Servis açılış kodu seçilmedi.',
          trigger: 'blur',
        },
      ],
      name: [
        {
          required: true,
          message: 'Talep bildiren girilmedi.',
          trigger: 'blur',
        },
      ],
      phone: [
        {
          required: true,
          message: 'Talep bildiren telefon bilgisi girilmedi.',
          trigger: 'blur',
        },
      ],
    });

    const servicAcSubmit = () => {
      if (!formServiceRef.value) {
        return;
      }

      formServiceRef.value.validate(valid => {
        if (valid) {
          loading.value = true;

          newService.value.deviceId = firmaOzet.value.deviceId;

          store
            .dispatch(Actions.ADD_DEVICESERVICE, newService.value)
            .then(result => {
              loading.value = false;
              console.clear();
              console.log(result);
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Servis başarıyla eklendi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(() => {
                  hideModal(formServiceRef.value);
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
        }
      });
    };

    const remoteMethod = async (query: string) => {
      if (query && query.length > 3) {
        loading.value = true;
        await store
          .dispatch(Actions.GET_CUSTOMER_BY_FILTER, query)
          .then(result => {
            console.clear();
            console.log(result.data);
            loading.value = false;

            if (result.isSuccess) {
              customerList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      } else {
        customerList.value = [];
      }
    };

    const remoteMethodCihazNo = async (query: string) => {
      if (query) {
        loading.value = true;
        await store
          .dispatch(Actions.GET_DEVICE_BY_FILTER, query)
          .then(result => {
            console.clear();
            console.log(result.data);
            loading.value = false;
            if (result.isSuccess) {
              deviceList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      } else {
        customerList.value = [];
      }
    };

    const remoteMethodSerialNo = async (query: string) => {
      if (query && query.length > 3) {
        loading.value = true;
        await store
          .dispatch(Actions.GET_DEVICE_BY_SERIALNO_FILTER, query)
          .then(result => {
            console.clear();
            console.log(result.data);
            loading.value = false;
            if (result.isSuccess) {
              seriNoList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      } else {
        seriNoList.value = [];
      }
    };

    const remoteMethodModelName = async (query: string) => {
      if (query && query.length > 3) {
        loading.value = true;
        await store
          .dispatch(Actions.GET_DEVICE_BY_MODEL_NAME_FILTER, query)
          .then(result => {
            console.clear();
            console.log(result.data);
            loading.value = false;
            if (result.isSuccess) {
              modelList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      } else {
        modelList.value = [];
      }
    };

    function clearPage() {
      firmaOzet.value = {
        customerId: '',
        customerTitle: '',
        customerSectorId: '',
        customerSector: '',
        accountCode: '',
        authorizedName: '',
        authorizedPhone: '',
        authorizedTask: '',
        cityName: '',
        authorizedEmail: '',
        deviceId: '',
        districtName: '',
        quarterName: '',
        regionCode: '',
        contractType: '',
        wbCount: '',
        colorCount: '',
        totalCount: '',
        deviceStatus: '',
        maintenanceStatus: '-',
        deviceBrand: null,
        deviceModel: null,
        device: null,
      };

      contracts.value = [];

      customerDeviceList.value = [];

      deviceBrand.value = {
        deviceType: null,
        companyId: '',
        name: '',
      };

      deviceServices.value = [];
    }
    async function getBootCodeList() {
      await store
        .dispatch(Actions.GET_BOOTCODE_LIST)
        .then(result => {
          if (result.isSuccess) {
            servisAcDialogVisible.value = true;
            bootCodeList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }
    async function getTechnicianList() {
      await store
        .dispatch(Actions.GET_TECHNICIAN_LIST)
        .then(result => {
          if (result.isSuccess) {
            console.clear();
            console.log(result.data);
            technicianUserList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }
    async function onCustomerChange() {
      console.clear();
      clearPage();
      console.log(selectedCustomer);

      if (!selectedCustomer) {
        customerList.value = [];
        selectedDevice.value = '';
        return;
      }

      await getMainPageCustomer(selectedCustomer);
    }
    async function onDeviceNoChange() {
      console.clear();
      clearPage();
      console.log(selectedDevice);

      if (!selectedDevice) {
        deviceList.value = [];
        selectedCustomer.value = '';
        return;
      }

      await getMainPageCustomer(selectedDevice);
    }
    async function onSerialNoChange() {
      console.clear();
      clearPage();
      console.log(selectedSerialNo);

      if (!selectedSerialNo) {
        seriNoList.value = [];
        selectedCustomer.value = '';
        selectedDevice.value = '';
        selectedModelName.value = '';
        return;
      }

      await getMainPageCustomer(selectedSerialNo);
    }
    async function onModelNameChange() {
      console.clear();
      clearPage();
      console.log(selectedModelName);

      if (!selectedModelName) {
        modelList.value = [];
        selectedCustomer.value = '';
        selectedDevice.value = '';
        selectedSerialNo.value = '';
        return;
      }

      await getMainPageCustomer(selectedModelName);
    }
    async function getMainPageCustomer(rowId) {
      await store
        .dispatch(Actions.GET_MAIN_PAGE_CUSTOMER, rowId)
        .then(result => {
          centerDialogVisible.value = false;
          console.clear();
          console.log(result.data);
          firmaOzet.value = result.data;
          firmaOzet.value.deviceStatus = result.data.deviceDto.status ? 'Aktif' : 'Pasif';
          contracts.value = result.data.contracts;
          device.value = result.data.deviceDto;
          deviceServices.value = result.data.deviceServices;
          customerDeviceList.value = result.data.devices;
          // selectedDevice = result.data.deviceId;
          // selectedCustomer = result.data.customerTitle;
          // selectedModelName = result.data.deviceDto.deviceModel.name;
          // selectedSerialNo = result.data.deviceDto.serialNumber;
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }
    function routeAddCustomer() {
      router.push({
        name: 'customer',
        path: '/customer',
      });
    }
    function routeUpdateCustomer() {
      store.commit('setCustomerId', firmaOzet.value.customerId);

      router.push({
        name: 'customer',
        path: '/customer',
      });
    }

    async function getLastTradedCustomer() {
      await store
        .dispatch(Actions.GET_LASTTRADED_CUSTOMER)
        .then(result => {
          if (result.isSuccess) {
            alert('sdf');
            console.log(result.data);
            firmaOzet = result.data;
            contracts = result.data.contracts;
            device = result.data.deviceDto;
            deviceBrand.value = result.data.deviceDto.deviceModel.deviceBrand;
            selectedCustomer = result.data.customerTitle;
            selectedDevice = result.data.deviceId;
            deviceServices = result.data.deviceServices;
            selectedModelName = result.data.deviceDto.deviceModel.name;
            selectedSerialNo = result.data.deviceDto.serialNumber;
            firmaOzet.value.deviceStatus = result.data.deviceDto.status ? 'Aktif' : 'Pasif';
            firmaOzet.value.backgroundColor = result.data.deviceDto.status ? '#ABEBC6' : '#F5B7B1';
            firmaOzet.value.maintenanceBackgroundColor = result.maintenanceStatus ? '#ABEBC6' : '#F5B7B1';
            firmaOzet.value.contractMaintenanceStatus = result.maintenanceStatus ? 'Bakım Yapıldı' : 'Bakım Yapılmadı';
            customerDeviceList = result.data.devices;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function cihazListesi() {
      centerDialogVisible.value = true;
    }

    async function servisAc() {
      await getBootCodeList();
      await getTechnicianList();
    }

    onMounted(async () => {
      alert('234');
      await getLastTradedCustomer();
    });

    return {
      loading,
      sectorList,
      store,
      centerDialogVisible,
      customerList,
      selectedCustomer,
      deviceList,
      selectedDevice,
      selectedSerialNo,
      selectedModelName,
      modelList,
      seriNoList,
      customerDeviceList,
      servisAcDialogVisible,
      newService,
      bootCodeList,
      shortcuts,
      technicianUserList,
      newServiceRules,
      formServiceRef,
      firmaOzet,
      deviceBrand,
      contracts,
      customerInfoList,
      deviceServices,
      remoteMethodSerialNo,
      remoteMethodModelName,
      onSerialNoChange,
      onModelNameChange,
      servicAcSubmit,
      remoteMethod,
      remoteMethodCihazNo,
      routeAddCustomer,
      routeUpdateCustomer,
      cihazListesi,
      servisAc,
      onDeviceNoChange,
      onCustomerChange,
      getMainPageCustomer,
    };
  },
});
</script>
