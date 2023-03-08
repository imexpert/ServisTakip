<template>
  <div class="row">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-6 col-sm-12 mb-2" v-loading="anaSayfaLoading">
      <el-card class="box-card">
        <template #header>
          <div class="card-header">
            <div class="d-flex align-content-center flex-wrap">
              <div class="p-2">
                <el-dropdown trigger="click">
                  <el-button type="danger">
                    Müşteri İşlemleri<el-icon class="el-icon--right"><arrow-down /></el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item>
                        <el-icon>
                          <Plus></Plus>
                        </el-icon>Yeni Ekle
                      </el-dropdown-item>
                      <el-dropdown-item><el-icon>
                          <Edit></Edit>
                        </el-icon>Düzenle
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </div>
              <div class="p-2">
                <el-dropdown trigger="click">
                  <el-button type="danger">
                    Cihaz İşlemleri<el-icon class="el-icon--right"><arrow-down /></el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item @click="servisAc()"><el-icon>
                          <Plus></Plus>
                        </el-icon>Servis Aç
                      </el-dropdown-item>
                      <el-dropdown-item><el-icon>
                          <Edit></Edit>
                        </el-icon>Hızlı Servis
                      </el-dropdown-item>
                      <el-dropdown-item @click="cihazListesi()"><el-icon>
                          <List />
                        </el-icon>Cihaz Listesi
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </div>
            </div>
          </div>
        </template>
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
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row">
                  <label class="required fs-5 fw-semobold mb-2">Cihaz No</label>
                  <el-select @change="onDeviceNoChange()" filterable remote clearable placeholder="Cihaz no giriniz"
                    reserve-keyword remote-show-suffix v-model="selectedDevice" :remote-method="remoteMethodCihazNo"
                    :loading="loading">
                    <li class="el-select-dropdown__item">
                      <div class="row">
                        <div class="col-md-7">
                          <span style="font-weight: 900"> Unvan </span>
                        </div>
                        <!-- <div class="col-md-2">
                          <span style="font-weight: 900"> Semt </span>
                        </div> -->
                        <div class="col-md-3">
                          <span style="font-weight: 900"> Model </span>
                        </div>
                        <div class="col-md-2">
                          <span style="font-weight: 900"> Seri No </span>
                        </div>
                      </div>
                    </li>
                    <el-option v-for="item in deviceInfoList" :key="item.rowId" :label="item.id" :value="item.rowId">
                      <div class="row">
                        <div class="col-md-7" style="font-size: 12px">
                          {{ item.title }}
                        </div>
                        <!-- <div class="col-md-2" style="font-size: 12px">
                          {{ item.querter }}
                        </div> -->
                        <div class="col-md-3" style="font-size: 12px">
                          {{ item.model }}
                        </div>
                        <div class="col-md-2" style="font-size: 12px">
                          {{ item.serialNo }}
                        </div>
                      </div>
                    </el-option>
                  </el-select>
                </div>

                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-6 fv-row">
                  <label class="fs-5 fw-semobold mb-2">Cari Kod</label>
                  <el-input readonly disabled v-model="firmaOzet.accountCode" class="input-with-select"> </el-input>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="carikod" />
                    </div>
                  </div>
                </div>

                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-6 fv-row">
                  <label class="fs-5 fw-semobold mb-2">Sektör</label>
                  <el-input readonly disabled v-model="firmaOzet.customerSector" class="input-with-select"> </el-input>
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
                    <el-option v-for="item in customerInfoList" :key="item.rowId" :label="item.title" :value="item.rowId">
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
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
                  <label class="fs-5 fw-semobold mb-2">Şehir</label>
                  <el-input readonly disabled v-model="firmaOzet.cityName" class="input-with-select"> </el-input>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="departman" />
                    </div>
                  </div>
                </div>
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
                  <label class="fs-5 fw-semobold mb-2">İlçe</label>
                  <el-input readonly disabled v-model="firmaOzet.districtName" class="input-with-select"> </el-input>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="departman" />
                    </div>
                  </div>
                </div>
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
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
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
                  <label class="fs-5 fw-semobold mb-2">Yetkili Ad Soyad</label>
                  <el-input readonly disabled v-model="firmaOzet.authorizedName" class="input-with-select"> </el-input>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="departman" />
                    </div>
                  </div>
                </div>
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
                  <label class="fs-5 fw-semobold mb-2">Yetkili Görevi</label>
                  <el-input readonly disabled v-model="firmaOzet.authorizedTask" class="input-with-select"> </el-input>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="departman" />
                    </div>
                  </div>
                </div>
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
                  <label class="fs-5 fw-semobold mb-2">Yetkili E-Mail</label>
                  <el-input readonly disabled v-model="firmaOzet.authorizedEmail" class="input-with-select"> </el-input>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="departman" />
                    </div>
                  </div>
                </div>
              </div>
              <div class="row mb-1">
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
                  <label class="fs-5 fw-semobold mb-2">Tel</label>
                  <el-input readonly disabled v-model="firmaOzet.authorizedPhone" class="input-with-select"> </el-input>
                  <div class="fv-plugins-message-container">
                    <div class="fv-help-block">
                      <ErrorMessage name="departman" />
                    </div>
                  </div>
                </div>
                <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
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
      </el-card>
    </div>
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-6 col-sm-12 mb-1" v-loading="anaSayfaLoading">
      <el-card class="box-card">
        <div class="row mb-2">
          <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-1">
            <el-table :data="contracts" style="width: 100%" height="150" max-height="150px"
              :default-sort="{ prop: 'startDate', order: 'descending' }">
              <template #empty>
                <div class="row">
                  <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-1">
                    <el-button type="danger"><el-icon>
                        <Plus></Plus>
                      </el-icon>Yeni Ekle
                    </el-button>
                  </div>
                </div>
              </template>
              <el-table-column label="Başlangıç T." width="140" sortable>
                <template #default="scope">
                  <div style="display: flex; align-items: center">
                    <span>{{ scope.row.startDateString }}</span>
                  </div>
                </template>
              </el-table-column>
              <el-table-column label="Bitiş T." width="140" sortable>
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
              <el-table-column label="#" fixed="left" width="140">
                <el-dropdown size="small" split-button type="danger">
                  Yeni Ekle
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item><el-icon>
                          <Edit></Edit>
                        </el-icon>
                        Düzenle</el-dropdown-item>
                      <el-dropdown-item><el-icon><el-icon>
                            <Delete />
                          </el-icon></el-icon>
                        Sil</el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </el-table-column>
            </el-table>
          </div>
          <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mt-3">
            <el-divider />
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row">
            <label class="required fs-5 fw-semobold mb-2">Model</label>
            <el-select @change="onModelNameChange()" filterable remote clearable placeholder="Model adı giriniz"
              reserve-keyword remote-show-suffix v-model="selectedModelName" :remote-method="remoteMethodModelName"
              :loading="loading">
              <li class="el-select-dropdown__item">
                <div class="row">
                  <div class="col-md-7">
                    <span style="font-weight: 900"> Unvan </span>
                  </div>
                  <!-- <div class="col-md-2">
                    <span style="font-weight: 900"> Semt </span>
                  </div> -->
                  <div class="col-md-3">
                    <span style="font-weight: 900"> Model </span>
                  </div>
                  <div class="col-md-2">
                    <span style="font-weight: 900"> Seri No </span>
                  </div>
                </div>
              </li>
              <el-option v-for="item in modelList" :key="item.rowId" :label="item.model" :value="item.rowId">
                <div class="row">
                  <div class="col-md-7" style="font-size: 12px">
                    {{ item.title }}
                  </div>
                  <!-- <div class="col-md-2" style="font-size: 12px">
                    {{ item.querter }}
                  </div> -->
                  <div class="col-md-3" style="font-size: 12px">
                    {{ item.model }}
                  </div>
                  <div class="col-md-2" style="font-size: 12px">
                    {{ item.serialNo }}
                  </div>
                </div>
              </el-option>
            </el-select>
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row">
            <label class="required fs-5 fw-semobold mb-2">Seri No</label>
            <el-select @change="onSerialNoChange()" filterable remote clearable placeholder="Seri no giriniz"
              reserve-keyword remote-show-suffix v-model="selectedSerialNo" :remote-method="remoteMethodSerialNo"
              :loading="loading">
              <li class="el-select-dropdown__item">
                <div class="row">
                  <div class="col-md-7">
                    <span style="font-weight: 900"> Unvan </span>
                  </div>
                  <!-- <div class="col-md-2">
                    <span style="font-weight: 900"> Semt </span>
                  </div> -->
                  <div class="col-md-3">
                    <span style="font-weight: 900"> Model </span>
                  </div>
                  <div class="col-md-2">
                    <span style="font-weight: 900"> Seri No </span>
                  </div>
                </div>
              </li>
              <el-option v-for="item in seriNoList" :key="item.rowId" :label="item.serialNo" :value="item.rowId">
                <div class="row">
                  <div class="col-md-7" style="font-size: 12px">
                    {{ item.title }}
                  </div>
                  <!-- <div class="col-md-2" style="font-size: 12px">
                    {{ item.querter }}
                  </div> -->
                  <div class="col-md-3" style="font-size: 12px">
                    {{ item.model }}
                  </div>
                  <div class="col-md-2" style="font-size: 12px">
                    {{ item.serialNo }}
                  </div>
                </div>
              </el-option>
            </el-select>
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row">
            <label class="fs-5 fw-semobold mb-2">Marka</label>
            <el-input disabled style="font-size: 12px" v-model="deviceBrand.name"> </el-input>
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Montaj Tarihi</label>
            <el-input disabled style="font-size: 12px" v-model="device.assemblyDateString"> </el-input>
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Sözleşme Tipi</label>
            <el-input disabled style="font-size: 12px" v-model="firmaOzet.contractType"> </el-input>
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Cihaz Durumu</label>
            <input type="text" disabled class="form-control form-control-sm form-control-solid border border-secondary"
              style="color: #a8abb2" :style="{ backgroundColor: backgroundColor }" name="row-name"
              v-model="deviceStatus" />
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Bakım Durumu</label>
            <input type="text" disabled class="form-control form-control-sm form-control-solid border border-secondary"
              style="color: #a8abb2" :style="{ backgroundColor: maintenanceBackgroundColor }" name="row-name"
              v-model="contractMaintenanceStatus" />
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">S/B Sayaç</label>
            <el-input disabled style="font-size: 12px" v-model="firmaOzet.wbCount"> </el-input>
          </div>
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Renkli Sayaç</label>
            <el-input disabled style="font-size: 12px" v-model="firmaOzet.colorCount"> </el-input>
          </div>
        </div>
      </el-card>
    </div>
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-8 col-sm-12 mb-1" v-loading="anaSayfaLoading">
      <el-card class="box-card">
        <div class="text item">
          <el-table :data="deviceServices" height="268" max-height="268" style="width: 100%; font-size: 12px">
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
                  <span v-if="scope.row.dr">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Dv" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.dv">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Bc" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.bc">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Fs" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.fs">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Pa" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.pa">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Bk" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.bk">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Ak" width="40">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.ak">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="#" fixed="left" width="70">
              <template #default="scope">
                <el-button type="danger" @click="getDeviceService(scope.row.id)">
                  <el-icon title="Detay Görüntüle">
                    <Search />
                  </el-icon>
                </el-button>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </el-card>
    </div>
    <div class="col-md-12 col-lg-12 col-xl-4 col-xxl-4">
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

    <el-dialog v-model="cihazListesiDialogVisible" title="Cihaz Listesi" width="50%" destroy-on-close center>
      <div class="row">
        <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-5">
          <el-card class="box-card" style="height: 300px">
            <div class="text item">
              <el-table :data="deviceList" style="width: 100%" max-height="300">
                <el-table-column label="Cihaz No" width="160">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.id }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Marka" width="160">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.deviceModel.deviceBrand.name }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Model" width="160">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.deviceModel.name }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Seri No" width="160">
                  <template #default="scope">
                    <div style="display: flex; align-items: center">
                      <span>{{ scope.row.serialNumber }}</span>
                    </div>
                  </template>
                </el-table-column>
                <el-table-column label="Cihaz Durumu" width="140">
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
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
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
            <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
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
            <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
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
                  <el-input v-model="newService.phone" :formatter="
                    value => value.replace(/\D/g, '').replace(/^(\d{3})(\d{3})(\d{2})(\d{2}).*/, '+90-($1)-$2-$3-$4')
                  " placeholder="Talebi bildiren telefon giriniz" />
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
                  <span>Teknisyen Atanma T.</span>
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

    <el-dialog v-model="talepDialogVisible" title="Talep Detay" width="50%" destroy-on-close align-top>
      <div class="row" v-loading="talepDetayLoading">
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Servis Kodu</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="serviceBootCode">
              <el-input v-model="deviceServiceItem.serviceBootCode" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Açılış Tarihi</span>
            </label>
            <!--end::Label-->

            <el-form-item prop="failureDateString">
              <el-input v-model="deviceServiceItem.failureDateString" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-12 col-lg-12 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Açıklama</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="bootDescription">
              <el-input v-model="deviceServiceItem.bootDescription" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Teknisyen</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="fullname">
              <el-input v-model="deviceServiceItem.user.fullname" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Teknisyen Veriliş Tarihi</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="userAssignDateString">
              <el-input v-model="deviceServiceItem.userAssignDateString" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Telefon</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="phone">
              <el-input v-model="deviceServiceItem.phone" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span class="required">Talep Bildiren</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="name">
              <el-input v-model="deviceServiceItem.name" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span class="required">Tespit Kodu</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="detectionCode">
              <el-input v-model="deviceServiceItem.detectionCode" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Tespit Açıklama</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="detectionDescription">
              <el-input v-model="deviceServiceItem.detectionDescription" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span class="required">Sonuç Kodu</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="serviceResultCode">
              <el-input v-model="deviceServiceItem.serviceResultCode" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span class="required">Kapanış Tarihi</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="resultDate">
              <el-input v-model="deviceServiceItem.resultDateString" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Kapanış Açıklama</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="resultDescription">
              <el-input v-model="deviceServiceItem.resultDescription" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>S/B Sayaç</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="wBCount">
              <el-input v-model="deviceServiceItem.wbCount" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-6 col-lg-6 col-xl-4 col-xxl-4 col-sm-12 mr-auto">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Renkli Sayaç</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="colorCount">
              <el-input v-model="deviceServiceItem.colorCount" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
      </div>
      <div class="row" v-loading="talepDetayLoading">
        <div class="col-md-4 col-lg-4 col-xl-4 col-xxl-4 col-sm-12">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Toner Tipi</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="tonerType">
              <el-select v-model="deviceServiceItem.tonerType" placeholder="Toner Tipi" disabled>
                <el-option label="Orjinal" value="1" />
                <el-option label="Muadil" value="2" />
                <el-option label="Dolum" value="3" />
              </el-select>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-2">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Siyah</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="blackCount">
              <el-input v-model="deviceServiceItem.blackCount" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-2">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Mavi</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="blueCount">
              <el-input v-model="deviceServiceItem.blueCount" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-2">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Sarı</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="yellowCount">
              <el-input v-model="deviceServiceItem.yellowCount" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-2">
          <!--begin::Input group-->
          <div class="d-flex flex-column fv-row">
            <!--begin::Label-->
            <label class="d-flex align-items-center fs-6 fw-bold">
              <span>Kırmızı</span>
            </label>
            <!--end::Label-->
            <el-form-item prop="redCount">
              <el-input v-model="deviceServiceItem.redCount" disabled></el-input>
            </el-form-item>
          </div>
          <!--end::Input group-->
        </div>
        <div class="col-md-1">
          <el-checkbox label="Dr" v-model="deviceServiceItem.dr" disabled />
        </div>
        <div class="col-md-1">
          <el-checkbox label="Bc" v-model="deviceServiceItem.bc" disabled />
        </div>
        <div class="col-md-1">
          <el-checkbox label="Pa" v-model="deviceServiceItem.pa" disabled />
        </div>
        <div class="col-md-1">
          <el-checkbox label="Bk" v-model="deviceServiceItem.bk" disabled />
        </div>
        <div class="col-md-1">
          <el-checkbox label="Dv" v-model="deviceServiceItem.dv" disabled />
        </div>
        <div class="col-md-1">
          <el-checkbox label="Fs" v-model="deviceServiceItem.fs" disabled />
        </div>
        <div class="col-md-1">
          <el-checkbox label="Ak" v-model="deviceServiceItem.ak" disabled />
        </div>
      </div>
    </el-dialog>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue';
import { ErrorMessage, Field, Form } from 'vee-validate';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { Plus, Search } from '@element-plus/icons-vue';
import { useRouter } from 'vue-router';

import Swal from 'sweetalert2/dist/sweetalert2.js';
import { IFirmaOzetData } from '@/core/data/FirmaOzetData';
import { IDeviceServiceData } from '@/core/data/DeviceServiceData';
import { IUserData } from '@/core/data/UserData';
import { IBootCodeData } from '@/core/data/BootCodeData';
import { IDeviceData } from '@/core/data/DeviceData';
import { ICustomerListData } from '@/core/data/CustomerListData';
import { IDeviceBrandData } from '@/core/data/DeviceBrandData';
import { IContractData } from '@/core/data/ContractData';
import { ICustomerData } from '@/core/data/CustomerData';
import { IDeviceModelData } from '@/core/data/DeviceModelData';

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
    const cihazListesiDialogVisible = ref(false);
    const servisAcDialogVisible = ref(false);
    const talepDialogVisible = ref(false);
    const store = useStore();
    const anaSayfaLoading = ref<boolean>(false);
    const servisAcLoading = ref<boolean>(false);
    const talepDetayLoading = ref<boolean>(false);
    const loading = ref<boolean>(false);
    const router = useRouter();

    var firmaOzet = ref<IFirmaOzetData>({
      device: null,
      deviceBrand: null,
      deviceId: '',
      deviceModel: null,
      accountCode: '',
      authorizedEmail: '',
      authorizedName: '',
      authorizedPhone: '',
      authorizedTask: '',
      backgroundColor: '',
      cityName: '',
      colorCount: '',
      contractMaintenanceStatus: '',
      contractType: '',
      customerId: '',
      customerSector: '',
      customerSectorId: '',
      customerTitle: '',
      deviceStatus: '',
      districtName: '',
      maintenanceBackgroundColor: '',
      maintenanceStatus: '',
      quarterName: '',
      regionCode: '',
      totalCount: '',
      wbCount: '',
    });

    var device = ref<IDeviceData>({
      address: null,
      addressId: '',
      assemblyDateString: '',
      description: '',
      deviceModel: null,
      deviceModelId: '',
      id: '',
      rowId: '',
      serialNumber: '',
      status: false,
    });

    var deviceBrand = ref<IDeviceBrandData>({
      name: '',
      companyId: '',
      deviceType: null,
    });

    var deviceModel = ref<IDeviceModelData>({
      deviceBrand: null,
      deviceBrandId: '',
      name: '',
    });

    var deviceStatus = ref<string>('');

    var backgroundColor = ref<string>('#ABEBC6');

    var maintenanceBackgroundColor = ref<string>('#ABEBC6');

    var contractMaintenanceStatus = ref<string>('');

    var deviceServiceItem = ref<IDeviceServiceData>({
      ak: false,
      bc: false,
      bk: false,
      blackCount: '',
      blueCount: '',
      bootDescription: '',
      colorCount: '',
      detectionCode: '',
      detectionDescription: '',
      device: null,
      deviceId: '',
      dr: false,
      dv: false,
      failureDate: '',
      failureDateString: '',
      fs: false,
      id: '',
      linkedDeviceServiceId: '',
      name: '',
      pa: false,
      phone: '',
      redCount: '',
      resultDate: '',
      resultDateString: '',
      resultDescription: '',
      serviceBootCode: '',
      serviceResultCode: '',
      tonerType: '',
      user: {
        email:'',
        firstname:'',
        fullname:'',
        id:'',
        lastname:''
      },
      userAssignDate: '',
      userAssignDateString: '',
      userId: '',
      wbCount: '',
      yellowCount: '',
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
      ak: false,
      bc: false,
      bk: false,
      blackCount: '',
      blueCount: '',
      bootDescription: '',
      colorCount: '',
      detectionCode: '',
      detectionDescription: '',
      device: null,
      deviceId: '',
      dr: false,
      dv: false,
      failureDate: '',
      failureDateString: '',
      fs: false,
      id: '',
      linkedDeviceServiceId: '',
      name: '',
      pa: false,
      phone: '',
      redCount: '',
      resultDate: '',
      resultDateString: '',
      resultDescription: '',
      serviceBootCode: '',
      serviceResultCode: '',
      tonerType: '',
      user: {
        email:'',
        firstname:'',
        fullname:'',
        id:'',
        lastname:''
      },
      userAssignDate: '',
      userAssignDateString: '',
      userId: '',
      wbCount: '',
      yellowCount: '',
    });

    var selectedDevice = ref<string>('');
    var selectedCustomer = ref<string>('');
    var selectedSerialNo = ref<string>();
    var selectedModelName = ref<string>();

    var technicianUserList = ref<Array<IUserData>>([]);
    var customerList = ref<Array<ICustomerData>>([]);
    var deviceList = ref<Array<IDeviceData>>([]);
    var deviceServices = ref<Array<IDeviceServiceData>>([]);

    var contracts = ref<Array<IContractData>>([]);

    var bootCodeList = ref<Array<IBootCodeData>>([]);

    var sectorList = [
      {
        id: 0,
        name: '',
      },
    ];

    var customerInfoList = ref<Array<ICustomerListData>>([]);
    var deviceInfoList = ref<Array<ICustomerListData>>([]);
    var deviceServices = ref<Array<IDeviceServiceData>>([]);
    var modelList = ref<Array<ICustomerListData>>([]);
    var seriNoList = ref<Array<ICustomerListData>>([]);

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
                  servisAcDialogVisible.value = false;
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
              customerInfoList.value = result.data;
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
      } else {
        customerInfoList.value = [];
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
              deviceInfoList.value = result.data;
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

      deviceInfoList.value = [];

      deviceBrand.value = {
        deviceType: null,
        companyId: '',
        name: '',
      };

      deviceServices.value = [];
    }

    function clearSevicAcModal() {
      newService.value = {
        ak: false,
      bc: false,
      bk: false,
      blackCount: '',
      blueCount: '',
      bootDescription: '',
      colorCount: '',
      detectionCode: '',
      detectionDescription: '',
      device: null,
      deviceId: '',
      dr: false,
      dv: false,
      failureDate: '',
      failureDateString: '',
      fs: false,
      id: '',
      linkedDeviceServiceId: '',
      name: '',
      pa: false,
      phone: '',
      redCount: '',
      resultDate: '',
      resultDateString: '',
      resultDescription: '',
      serviceBootCode: '',
      serviceResultCode: '',
      tonerType: '',
      user: {
        email:'',
        firstname:'',
        fullname:'',
        id:'',
        lastname:''
      },
      userAssignDate: '',
      userAssignDateString: '',
      userId: '',
      wbCount: '',
      yellowCount: '',
      };
    }

    function clearTalepDetayModal() {
      deviceServiceItem.value = {
        ak: false,
      bc: false,
      bk: false,
      blackCount: '',
      blueCount: '',
      bootDescription: '',
      colorCount: '',
      detectionCode: '',
      detectionDescription: '',
      device: null,
      deviceId: '',
      dr: false,
      dv: false,
      failureDate: '',
      failureDateString: '',
      fs: false,
      id: '',
      linkedDeviceServiceId: '',
      name: '',
      pa: false,
      phone: '',
      redCount: '',
      resultDate: '',
      resultDateString: '',
      resultDescription: '',
      serviceBootCode: '',
      serviceResultCode: '',
      tonerType: '',
      user: {
        email:'',
        firstname:'',
        fullname:'',
        id:'',
        lastname:''
      },
      userAssignDate: '',
      userAssignDateString: '',
      userId: '',
      wbCount: '',
      yellowCount: '',
      };
    }

    async function getBootCodeList() {
      await store
        .dispatch(Actions.GET_BOOTCODE_LIST)
        .then(result => {
          if (result.isSuccess) {
            bootCodeList.value = result.data;
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
            technicianUserList.value = result.data;
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

      await getMainPageCustomer(selectedCustomer.value);
    }

    async function onDeviceNoChange() {
      console.clear();
      clearPage();
      console.log(selectedDevice);

      if (!selectedDevice) {
        selectedCustomer.value = '';
        return;
      }

      await getMainPageCustomer(selectedDevice.value);
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

      await getMainPageCustomer(selectedSerialNo.value);
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

      await getMainPageCustomer(selectedModelName.value);
    }

    async function getMainPageCustomer(rowId) {
      anaSayfaLoading.value = true;
      cihazListesiDialogVisible.value = false;
      await store
        .dispatch(Actions.GET_MAIN_PAGE_CUSTOMER, rowId)
        .then(result => {
          anaSayfaLoading.value = false;
          if (result.isSuccess) {
            console.clear();
            console.log(result.data);
            firmaOzet.value = result.data;
            console.clear();
            console.log(firmaOzet.value);
            contracts.value = result.data.contracts;
            device.value = result.data.device;
            deviceBrand.value = result.data.device?.deviceModel?.deviceBrand;
            deviceModel.value = result.data.device?.deviceModel;
            deviceStatus.value = device.value.status == true ? 'Aktif' : 'Pasif';
            contractMaintenanceStatus.value = result.maintenanceStatus ? 'Bakım Yapıldı' : 'Bakım Yapılmadı';
            maintenanceBackgroundColor.value = result.maintenanceStatus ? '#ABEBC6' : '#F5B7B1';
            deviceList.value = result.data.devices;
            selectedDevice.value = result.data.deviceId;
            selectedCustomer.value = result.data.customerTitle;
            selectedSerialNo.value = device.value.serialNumber;
            selectedModelName.value = deviceModel.value.name;
            deviceServices.value = result.data.deviceServices;
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

    async function getDeviceService(id) {
      clearTalepDetayModal();
      talepDialogVisible.value = true;
      talepDetayLoading.value = true;

      await store
        .dispatch(Actions.GET_DEVICESERVICEWITHID, id)
        .then(result => {
          if (result.isSuccess) {
            talepDetayLoading.value = false;
            deviceServiceItem.value = result.data;
          }
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
      anaSayfaLoading.value = true;
      await store
        .dispatch(Actions.GET_LASTTRADED_CUSTOMER)
        .then(result => {
          anaSayfaLoading.value = false;
          if (result.isSuccess) {
            firmaOzet.value = result.data;
            console.clear();
            console.log(firmaOzet.value);
            contracts.value = result.data.contracts;
            device.value = result.data.device;
            deviceBrand.value = result.data.device?.deviceModel?.deviceBrand;
            deviceModel.value = result.data.device?.deviceModel;
            deviceStatus.value = device.value.status == true ? 'Aktif' : 'Pasif';
            contractMaintenanceStatus.value = result.data.maintenanceStatus ? 'Bakım Yapıldı' : 'Bakım Yapılmadı';
            maintenanceBackgroundColor.value = result.data.maintenanceStatus ? '#ABEBC6' : '#F5B7B1';
            deviceList.value = result.data.devices;
            selectedDevice.value = result.data.deviceId;

            selectedDevice.value = result.data.deviceId;
            selectedCustomer.value = result.data.customerTitle;
            selectedSerialNo.value = device.value.serialNumber;
            selectedModelName.value = deviceModel.value.name;

            deviceServices.value = result.data.deviceServices;
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

    async function cihazListesi() {
      cihazListesiDialogVisible.value = true;
    }

    async function servisAc() {
      clearSevicAcModal();

      servisAcDialogVisible.value = true;
      servisAcLoading.value = true;

      await getBootCodeList();
      await getTechnicianList();

      servisAcLoading.value = false;
    }

    async function talepDetayAc() {
      talepDialogVisible.value = true;
    }

    onMounted(async () => {
      await getLastTradedCustomer();
    });

    return {
      loading,
      sectorList,
      store,
      cihazListesiDialogVisible,
      customerList,
      selectedCustomer,
      deviceList,
      selectedDevice,
      selectedSerialNo,
      selectedModelName,
      modelList,
      seriNoList,
      servisAcDialogVisible,
      newService,
      bootCodeList,
      shortcuts,
      technicianUserList,
      newServiceRules,
      formServiceRef,
      firmaOzet,
      device,
      deviceBrand,
      contracts,
      customerInfoList,
      deviceInfoList,
      deviceServices,
      anaSayfaLoading,
      deviceStatus,
      backgroundColor,
      contractMaintenanceStatus,
      maintenanceBackgroundColor,
      servisAcLoading,
      talepDialogVisible,
      deviceServiceItem,
      talepDetayLoading,
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
      talepDetayAc,
      getDeviceService
    };
  },
});
</script>
<style>
.flex-grow {
  flex-grow: 1;
}
</style>
