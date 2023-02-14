<template>
  <div class="row">
    <!--begin::Col-->
    <div class="col-md-6 col-lg-6 col-xl-6 col-xxl-6">
      <!--begin::List Widget 1-->
      <div class="card" :class="widgetClasses">
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
                <el-icon>
                  <Plus />
                </el-icon>&nbsp; Hızlı Servis Aç
              </el-button>
              <el-button type="primary" title="Önceki Cihaz" @click="servisAc()">
                <el-icon>
                  <Plus />
                </el-icon>&nbsp; Servis Aç
              </el-button>
            </el-button-group>
          </div>
          <div class="d-flex align-items-center me-5">
            <el-button-group>
              <el-button type="danger" title="Önceki Cihaz" @click="cihazListesi()">
                <el-icon>
                  <List />
                </el-icon>&nbsp; Cihaz Listesi
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
              <div class="scroll-y me-n7 pe-7" id="kt_modal_new_address_scroll" data-kt-scroll="true"
                data-kt-scroll-activate="{default: false, lg: true}" data-kt-scroll-max-height="auto"
                data-kt-scroll-dependencies="#kt_modal_new_address_header"
                data-kt-scroll-wrappers="#kt_modal_new_address_scroll" data-kt-scroll-offset="300px">
                <!--begin::Input group-->
                <div class="row mb-1">
                  <div class="col-md-4 fv-row">
                    <label class="required fs-5 fw-semobold mb-2">Cihaz No</label>
                    <el-select @change="onDeviceNoChange()" filterable remote clearable placeholder="Cihaz no giriniz"
                      reserve-keyword remote-show-suffix v-model="selectedDevice" :remote-method="remoteMethodCihazNo"
                      :loading="loading">
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
                      <el-option v-for="item in deviceList" :key="item.rowId" :label="item.deviceId"
                        :value="item.rowId">
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
                    <el-select @change="onCustomerChange()" filterable remote clearable
                      placeholder="Arama için en az 4 harf giriniz" reserve-keyword remote-show-suffix
                      v-model="selectedCustomer" :remote-method="remoteMethod" :loading="loading">
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
                      <el-option v-for="item in customerList" :key="item.rowId" :label="item.title" :value="item.rowId">
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
              <el-table :data="contracts" style="width: 100%" max-height="147"
                :default-sort="{ prop: 'startDate', order: 'descending' }">
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
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>-</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="#" fixed="right">
                  <template #default="scope">
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
                <el-select @change="onModelNameChange()" filterable remote clearable placeholder="Model adı giriniz"
                  reserve-keyword remote-show-suffix v-model="selectedModelName" :remote-method="remoteMethodModelName"
                  :loading="loading">
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
                <el-select @change="onSerialNoChange()" filterable remote clearable placeholder="Seri no giriniz"
                  reserve-keyword remote-show-suffix v-model="selectedSerialNo" :remote-method="remoteMethodSerialNo"
                  :loading="loading">
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
                <el-input disabled v-model="deviceBrand.name" style="font-size: 12px"> </el-input>
              </div>
              <div class="col-md-6 mt-2">
                <label class="fs-5 fw-semobold">Montaj Tarihi</label>
              </div>
              <div class="col-md-6 mt-2">
                <el-input disabled v-model="device.assemblyDateString" style="font-size: 12px"> </el-input>
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
                <input type="text" disabled
                  class="form-control form-control-sm form-control-solid border border-secondary" style="color: #a8abb2"
                  :style="{ backgroundColor: backgroundColor }" name="row-name" v-model="firmaOzet.deviceStatus" />
              </div>
              <div class="col-md-6 pt-2 mt-2">
                <label class="fs-5 fw-semobold mb-2">Bk. Durumu</label>
              </div>
              <div class="col-md-6 mt-2">
                <input type="text" disabled
                  class="form-control form-control-sm form-control-solid border border-secondary" style="color: #a8abb2"
                  name="row-name" :style="{ backgroundColor: maintenanceBackgroundColor }"
                  v-model="contractMaintenanceStatus" />
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
                  <el-button size="small" type="primary" circle title="Cihaz Seç"
                    @click="getMainPageCustomer(scope.row.rowId)">
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
      <el-form status-icon :rules="newServiceRules" ref="formServiceRef" :model="newService"
        @submit.prevent="servicAcSubmit()" label-width="120px" label-position="top">
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
                <el-date-picker v-model="newService.failureDate" format="DD.MM.YYYY HH:mm:ss" type="datetime"
                  placeholder="Select date and time" :shortcuts="shortcuts" />
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
                <el-input v-model="newService.phone" placeholder="Talebi bildiren telefon giriniz"
                  :formatter="(value) => `$ ${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')"
                  :parser="(value) => value.replace(/\$\s?|(,*)/g, '')" />
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
                  <el-option v-for="item in technicianUserList" :key="item.id" :label="item.firstname + item.lastname"
                    :value="item.id">
                    <div class="row">
                      <div class="col-md-9" style="font-size: 12px">
                        {{ item.firstname }} {{ item.lastname }}
                      </div>
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
                <el-date-picker v-model="newService.userAssignDate" format="DD.MM.YYYY HH:mm:ss" type="datetime"
                  placeholder="Select date and time" :shortcuts="shortcuts" />
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
import {
  defineComponent,
  ref
} from 'vue';
import {
  ErrorMessage,
  Field,
  Form
} from 'vee-validate';
import {
  useStore
} from 'vuex';
import {
  Actions
} from '@/store/enums/StoreEnums';
import {
  Plus,
  Search
} from '@element-plus/icons-vue';
import {
  object
} from 'yup/lib/locale';

interface FirmaOzetData {
  customerId: string;
  customerTitle: string;
}

interface ModelData {
  name: string;
  deviceBrand: BrandData;
}

interface BrandData {
  name: string;
}

interface DeviceData {
  id: string;
  addressId: string;
  deviceModelId: string;
  serialNumber: string;
  assemblyDate: string;
  assemblyDateString: string;
  description: string;
  status: string;
  deviceModel: ModelData;
  rowId: string;
}

interface CustomerListItem {
  id: string;
  addressId: string;
  deviceId: string;
  title: string;
  sector: string;
  address: string;
  model: string;
  serialNo: string;
  rowId: string;
  querter: string;
}

interface NewDeviceServiceData {
  failureDate: string;
  serviceBootCode: string;
  bootDescription: string;
  name: string;
  phone: string;
  userId: string;
  userAssignDate: string;
}

interface BootCodeData {
  id: string;
  code: string;
  name: string;
}

interface UserData {
  id: string;
  firstname: string;
  lastname: string;
  email: string;
}

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

    const shortcuts = [{
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

    var newService = ref<NewDeviceServiceData>({
      failureDate: '',
      serviceBootCode: '',
      bootDescription: '',
      name: '',
      phone: '',
      userId: '',
      userAssignDate: '',
    });

    var technicianUserList = ref<Array<UserData>>([]);

    var bootCodeList = ref<Array<BootCodeData>>([]);

    var sectorList = [{
      id: 0,
      name: '',
    },];

    var customerList = ref<Array<CustomerListItem>>([]);
    var customerDeviceList = ref<Array<DeviceData>>([]);
    var deviceList = ref<Array<CustomerListItem>>([]);
    var modelList = ref<Array<CustomerListItem>>([]);
    var seriNoList = ref<Array<CustomerListItem>>([]);
    var selectedCustomer = ref<string>();
    var selectedDevice = ref<string>();
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
      ]
    });

    const servicAcSubmit = () => {
      if (!formServiceRef.value) {
        return;
      }
      console.log(newServiceRules.value);
      formServiceRef.value.validate(valid => {
        if (valid) {
          loading.value = true;


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

    return {
      loading,
      sectorList,
      store,
      centerDialogVisible,
      remoteMethod,
      customerList,
      selectedCustomer,
      remoteMethodCihazNo,
      deviceList,
      selectedDevice,
      selectedSerialNo,
      selectedModelName,
      remoteMethodSerialNo,
      remoteMethodModelName,
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
      servicAcSubmit
    };
  },
  props: {
    widgetClasses: String,
  },
  data() {
    return {
      firmaOzet: {
        customerId: '',
        customerTitle: '',
        customerSectorId: 0,
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
      },
      device: {
        addressId: '',
        assemblyDate: '',
        description: '',
        deviceModelId: '',
        serialNumber: '',
        status: false,
        assemblyDateString: '',
      },
      deviceModel: {
        colorType: '',
        companyId: '',
        deviceBrandId: '',
        isScannerExist: '',
        name: '',
        paperType: '',
        status: false,
      },
      deviceBrand: {
        companyId: '',
        name: '',
        status: false,
      },
      deviceServices: [],
      contracts: [],
      backgroundColor: '#ABEBC6',
      maintenanceBackgroundColor: '#ABEBC6',
      contractMaintenanceStatus: '-',
    };
  },
  async created() {
    await this.getLastTradedCustomer();
  },
  methods: {
    clearPage() {
      this.firmaOzet = {
        customerId: '',
        customerTitle: '',
        customerSectorId: 0,
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
        maintenanceStatus: '',
      };

      this.contracts = [];

      this.customerDeviceList = [];

      this.deviceBrand = {
        companyId: '',
        name: '',
        status: false,
      };

      this.deviceModel = {
        colorType: '',
        companyId: '',
        deviceBrandId: '',
        isScannerExist: '',
        name: '',
        paperType: '',
        status: false,
      };

      this.device = {
        addressId: '',
        assemblyDate: '',
        description: '',
        deviceModelId: '',
        serialNumber: '',
        status: false,
        assemblyDateString: '',
      };

      this.deviceServices = [];

      //   this.selectedCustomer = '';
      //   this.selectedDevice = '';
    },
    async getBootCodeList() {
      await this.store
        .dispatch(Actions.GET_BOOTCODE_LIST)
        .then(result => {
          if (result.isSuccess) {
            this.servisAcDialogVisible = true;
            this.bootCodeList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async getTechnicianList() {
      await this.store
        .dispatch(Actions.GET_TECHNICIAN_LIST)
        .then(result => {
          if (result.isSuccess) {
            console.clear();
            console.log(result.data);
            this.technicianUserList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    async onCustomerChange() {
      console.clear();
      this.clearPage();
      console.log(this.selectedCustomer);

      if (!this.selectedCustomer) {
        this.customerList = [];
        this.selectedDevice = '';
        return;
      }

      await this.getMainPageCustomer(this.selectedCustomer);
    },
    async onDeviceNoChange() {
      console.clear();
      this.clearPage();
      console.log(this.selectedDevice);

      if (!this.selectedDevice) {
        this.deviceList = [];
        this.selectedCustomer = '';
        return;
      }

      await this.getMainPageCustomer(this.selectedDevice);
    },
    async onSerialNoChange() {
      console.clear();
      this.clearPage();
      console.log(this.selectedSerialNo);

      if (!this.selectedSerialNo) {
        this.seriNoList = [];
        this.selectedCustomer = '';
        this.selectedDevice = '';
        this.selectedModelName = '';
        return;
      }

      await this.getMainPageCustomer(this.selectedSerialNo);
    },
    async onModelNameChange() {
      console.clear();
      this.clearPage();
      console.log(this.selectedModelName);

      if (!this.selectedModelName) {
        this.modelList = [];
        this.selectedCustomer = '';
        this.selectedDevice = '';
        this.selectedSerialNo = '';
        return;
      }

      await this.getMainPageCustomer(this.selectedModelName);
    },
    async getMainPageCustomer(rowId) {
      await this.store
        .dispatch(Actions.GET_MAIN_PAGE_CUSTOMER, rowId)
        .then(result => {
          this.centerDialogVisible = false;
          console.clear();
          console.log(result.data);
          this.firmaOzet = result.data;
          this.contracts = result.data.contracts;
          this.device = result.data.deviceDto;
          this.deviceModel = result.data.deviceDto.deviceModel;
          this.deviceBrand = result.data.deviceDto.deviceModel.deviceBrand;
          this.selectedDevice = result.data.deviceId;
          this.selectedCustomer = result.data.customerTitle;
          this.selectedModelName = result.data.deviceDto.deviceModel.name;
          this.selectedSerialNo = result.data.deviceDto.serialNumber;
          this.deviceServices = result.data.deviceServices;
          this.firmaOzet.deviceStatus = result.data.deviceDto.status ? 'Aktif' : 'Pasif';
          this.backgroundColor = result.data.deviceDto.status ? '#ABEBC6' : '#F5B7B1';
          this.maintenanceBackgroundColor = result.maintenanceStatus ? '#ABEBC6' : '#F5B7B1';
          this.contractMaintenanceStatus = result.maintenanceStatus ? 'Bakım Yapıldı' : 'Bakım Yapılmadı';

          this.customerDeviceList = result.data.devices;
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
    routeAddCustomer() {
      this.$router.push({
        name: 'customer',
        path: '/customer',
      });
    },
    routeUpdateCustomer() {
      this.store.commit('setCustomerId', this.firmaOzet.customerId);

      this.$router.push({
        name: 'customer',
        path: '/customer',
      });
    },
    async getLastTradedCustomer() {
      await this.store
        .dispatch(Actions.GET_LASTTRADED_CUSTOMER)
        .then(result => {
          if (result.isSuccess) {
            this.firmaOzet = result.data;
            this.contracts = result.data.contracts;
            this.device = result.data.deviceDto;
            this.deviceModel = result.data.deviceDto.deviceModel;
            this.deviceBrand = result.data.deviceDto.deviceModel.deviceBrand;
            this.selectedCustomer = result.data.customerTitle;
            this.selectedDevice = result.data.deviceId;
            this.deviceServices = result.data.deviceServices;
            this.selectedModelName = result.data.deviceDto.deviceModel.name;
            this.selectedSerialNo = result.data.deviceDto.serialNumber;
            this.firmaOzet.deviceStatus = result.data.deviceDto.status ? 'Aktif' : 'Pasif';
            this.backgroundColor = result.data.deviceDto.status ? '#ABEBC6' : '#F5B7B1';
            this.maintenanceBackgroundColor = result.maintenanceStatus ? '#ABEBC6' : '#F5B7B1';
            this.contractMaintenanceStatus = result.maintenanceStatus ? 'Bakım Yapıldı' : 'Bakım Yapılmadı';

            this.customerDeviceList = result.data.devices;
            console.log(result.data);
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },

    async cihazListesi() {
      this.centerDialogVisible = true;
    },

    async servisAc() {
      await this.getBootCodeList();
      await this.getTechnicianList()
    },
  },
});
</script>

<style>
.demo-tabs>.el-tabs__content {
  padding: 32px;
  color: #6b778c;
  font-size: 32px;
  font-weight: 600;
}

.el-tabs--right .el-tabs__content,
.el-tabs--left .el-tabs__content {
  height: 100%;
}
</style>
