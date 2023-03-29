<template>
  <div class="row">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-6 col-sm-12 mb-2" v-loading="anaSayfaLoading">
      <el-card class="box-card">
        <template #header>
          <div class="card-header">
            <div class="d-flex align-content-center flex-wrap">
              <div class="p-2">
                <el-dropdown trigger="click" @command="handleCustomerMenuCommand">
                  <el-button type="danger">
                    Müşteri İşlemleri<el-icon class="el-icon--right">
                      <arrow-down />
                    </el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu class="dropdownMenu">
                      <el-dropdown-item command="MI">
                        <el-icon> <Plus></Plus> </el-icon>Yeni Ekle
                      </el-dropdown-item>
                      <el-dropdown-item command="MU" :disabled="firmaOzet.customerId == null">
                        <el-icon> <Edit></Edit> </el-icon>Düzenle
                      </el-dropdown-item>
                      <el-dropdown-item command="MD" :disabled="firmaOzet.customerId == null">
                        <el-icon> <Delete></Delete> </el-icon>Sil
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </div>
              <div class="p-2">
                <el-dropdown trigger="click" @command="handleDeviceMenuCommand">
                  <el-button type="danger">
                    Cihaz İşlemleri<el-icon class="el-icon--right">
                      <arrow-down />
                    </el-icon>
                  </el-button>
                  <template #dropdown>
                    <el-dropdown-menu class="dropdownMenu">
                      <el-dropdown-item command="CI" :disabled="firmaOzet.addressId == null">
                        <el-icon> <Plus></Plus> </el-icon>Cihaz Ekle
                      </el-dropdown-item>
                      <el-dropdown-item command="CU" :disabled="firmaOzet.deviceId == null">
                        <el-icon> <Edit></Edit> </el-icon>Cihaz Düzenle
                      </el-dropdown-item>
                      <el-dropdown-item command="S" divided :disabled="firmaOzet.deviceId == null">
                        <el-icon> <Plus></Plus> </el-icon>Servis Aç
                      </el-dropdown-item>
                      <el-dropdown-item command="HS" :disabled="firmaOzet.deviceId == null">
                        <el-icon> <Edit></Edit> </el-icon>Hızlı Servis
                      </el-dropdown-item>
                      <el-dropdown-item command="CL" :disabled="firmaOzet.deviceId == null">
                        <el-icon> <List /> </el-icon>Cihaz Listesi
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </div>
            </div>
          </div>
        </template>
        <!--begin::Modal body-->
        <div class="modal-body">
          <div class="row mb-1">
            <!-- Cihaz No -->
            <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row">
              <label class="required fs-5 fw-semobold mb-2">Cihaz No</label>
              <el-select
                @change="onDeviceNoChange()"
                class="arama"
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
                <el-option
                  class="aramaDropdownMenu"
                  style="font-weight: 900"
                  v-for="item in deviceInfoList"
                  :key="item.rowId"
                  :label="item.id"
                  :value="item.rowId"
                >
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

            <!-- Cari Kod -->
            <div class="col-md-4 col-lg-4 col-xl-4 col-sm-6 fv-row">
              <label class="fs-5 fw-semobold mb-2">Cari Kod</label>
              <el-input readonly disabled v-model="firmaOzet.accountCode" class="input-with-select"> </el-input>
              <div class="fv-plugins-message-container">
                <div class="fv-help-block">
                  <ErrorMessage name="carikod" />
                </div>
              </div>
            </div>

            <!-- Sektör -->
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
            <div class="col-md-10 fv-row">
              <label class="required fs-5 fw-semobold mb-2">Firma Unvan</label>
              <el-select
                @change="onCustomerChange()"
                filterable
                class="arama"
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
                  <div class="row" style="width: 100%">
                    <div class="col-md-4">
                      <span style="font-weight: 900"> Unvan </span>
                    </div>
                    <div class="col-md-2">
                      <span style="font-weight: 900"> Departman </span>
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
                  class="aramaDropdownMenu"
                  v-for="item in customerInfoList"
                  :key="item.rowId"
                  :label="item.title"
                  :value="item.rowId"
                >
                  <div class="row" style="width: 100%">
                    <div class="col-md-4" style="font-size: 12px">
                      {{ item.title }}
                    </div>
                    <div class="col-md-2" style="font-size: 12px">
                      {{ item.department }}
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
            <div class="col-md-2 col-lg-2 col-xl-2 col-sm-2 fv-row">
              <label class="fs-5 fw-semobold mb-2">Bölge</label>
              <el-input readonly disabled v-model="firmaOzet.regionCode" class="input-with-select"> </el-input>
              <div class="fv-plugins-message-container">
                <div class="fv-help-block">
                  <ErrorMessage name="bolge" />
                </div>
              </div>
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
              <label class="fs-5 fw-semobold mb-2">Tel (İş)</label>
              <el-input readonly disabled v-model="firmaOzet.authorizedWorkPhone" class="input-with-select"> </el-input>
              <div class="fv-plugins-message-container">
                <div class="fv-help-block">
                  <ErrorMessage name="departman" />
                </div>
              </div>
            </div>

            <div class="col-md-4 col-lg-4 col-xl-4 col-sm-4 fv-row">
              <label class="fs-5 fw-semobold mb-2">Departman</label>
              <el-input readonly disabled v-model="firmaOzet.department" class="input-with-select"> </el-input>
              <div class="fv-plugins-message-container">
                <div class="fv-help-block">
                  <ErrorMessage name="bolge" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </el-card>
    </div>
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-6 col-sm-12 mb-1" v-loading="anaSayfaLoading">
      <el-card class="box-card">
        <div class="row mb-2">
          <!-- Sözleşmeler -->
          <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-1">
            <SozlesmeListesi v-if="firmaOzet.deviceId" :deviceId="firmaOzet.deviceId" />
          </div>

          <!-- Divider -->
          <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mt-3">
            <el-divider />
          </div>

          <!-- Model -->
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row">
            <label class="required fs-5 fw-semobold mb-2">Model</label>
            <el-select
              @change="onModelNameChange()"
              filterable
              class="arama"
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
                    <span style="font-weight: 900"> Departman </span>
                  </div>
                  <div class="col-md-2">
                    <span style="font-weight: 900"> Model </span>
                  </div>
                  <div class="col-md-2">
                    <span style="font-weight: 900"> Seri No </span>
                  </div>
                </div>
              </li>
              <el-option
                class="aramaDropdownMenu"
                v-for="item in modelList"
                :key="item.rowId"
                :label="item.model"
                :value="item.rowId"
              >
                <div class="row">
                  <div class="col-md-6" style="font-size: 12px">
                    {{ item.title }}
                  </div>
                  <div class="col-md-2" style="font-size: 12px">
                    {{ item.department }}
                  </div>
                  <div class="col-md-2" style="font-size: 12px">
                    {{ item.model }}
                  </div>
                  <div class="col-md-2" style="font-size: 12px">
                    {{ item.serialNo }}
                  </div>
                </div>
              </el-option>
            </el-select>
          </div>

          <!-- Seri No -->
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row">
            <label class="required fs-5 fw-semobold mb-2">Seri No</label>
            <el-select
              @change="onSerialNoChange()"
              filterable
              class="arama"
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
                    <span style="font-weight: 900"> Departman </span>
                  </div>
                  <div class="col-md-2">
                    <span style="font-weight: 900"> Model </span>
                  </div>
                  <div class="col-md-2">
                    <span style="font-weight: 900"> Seri No </span>
                  </div>
                </div>
              </li>
              <el-option
                class="aramaDropdownMenu"
                v-for="item in seriNoList"
                :key="item.rowId"
                :label="item.serialNo"
                :value="item.rowId"
              >
                <div class="row">
                  <div class="col-md-6" style="font-size: 12px">
                    {{ item.title }}
                  </div>
                  <div class="col-md-2" style="font-size: 12px">
                    {{ item.department }}
                  </div>
                  <div class="col-md-2" style="font-size: 12px">
                    {{ item.model }}
                  </div>
                  <div class="col-md-2" style="font-size: 12px">
                    {{ item.serialNo }}
                  </div>
                </div>
              </el-option>
            </el-select>
          </div>

          <!-- Marka -->
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row">
            <label class="fs-5 fw-semobold mb-2">Marka</label>
            <el-input disabled style="font-size: 12px" v-model="deviceBrand.name"> </el-input>
          </div>

          <!-- Montaj Tarihi -->
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Montaj Tarihi</label>
            <el-input disabled style="font-size: 12px" v-model="device.assemblyDateString"> </el-input>
          </div>

          <!-- Sözleşme Tipi -->
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Sözleşme Tipi</label>
            <el-input disabled style="font-size: 12px" v-model="firmaOzet.contractType"> </el-input>
          </div>

          <!-- Cihaz Durumu -->
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Cihaz Durumu</label>
            <input
              type="text"
              disabled
              class="form-control form-control-sm form-control-solid border border-secondary"
              style="color: #a8abb2"
              :style="{ backgroundColor: backgroundColor }"
              name="row-name"
              v-model="deviceStatus"
            />
          </div>

          <!-- Bakım Durumu -->
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">Bakım Durumu</label>
            <input
              type="text"
              disabled
              class="form-control form-control-sm form-control-solid border border-secondary"
              style="color: #a8abb2"
              :style="{ backgroundColor: maintenanceBackgroundColor }"
              name="row-name"
              v-model="contractMaintenanceStatus"
            />
          </div>

          <!-- SB Sayaç -->
          <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 fv-row mt-2">
            <label class="fs-5 fw-semobold mb-2">S/B Sayaç</label>
            <el-input disabled style="font-size: 12px" v-model="firmaOzet.wbCount"> </el-input>
          </div>

          <!-- Renkli Sayaç -->
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
          <el-table :data="deviceServices" height="268" max-height="268" class="tableClass">
            <el-table-column label="Açılış Tarihi" width="150" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.failureDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Tek.Ver.Tarihi" width="150" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.userAssignDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Kapanış Tarihi" width="150" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.resultDateString }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="S/B" width="80" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.wbCount }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Renkli" width="80" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.colorCount }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Ser.Kod" width="90" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceBootCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Tes.Kodu" width="100" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.detectionCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Son.Kodu" width="100" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.serviceResultCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Teknisyen" width="150" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.user.firstname }} {{ scope.row.user.lastname }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Dr" width="50" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.dr">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Dv" width="50" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.dv">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Bc" width="50" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.bc">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Fs" width="50" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.fs">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Pa" width="50" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.pa">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Bk" width="50" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.bk">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Ak" width="50" label-class-name="tableHeader">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span v-if="scope.row.ak">1</span>
                  <span v-else>0</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="#" fixed="left" width="70" label-class-name="tableHeader">
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
            <!-- Müşteri Unvan -->
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

            <!-- Arıza Tarihi -->
            <div class="col-md-12 col-lg-12 col-xl-6 col-xxl-6 col-sm-12">
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
                    placeholder="Servis açılış tarihini seçiniz"
                    :shortcuts="shortcuts"
                  />
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Servis Açılış Kodu -->
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

            <!-- Açılış Açıklama -->
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

            <!-- Ad -->
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

            <!-- Telefon -->
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

            <!-- Teknisyen -->
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

            <!-- Teknisyen Atama Tarihi -->
            <div class="col-md-6">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Teknisyen Atanma T.</span>
                </label>
                <!--end::Label-->

                <el-form-item prop="userAssignDate">
                  <el-date-picker
                    v-model="newService.userAssignDate"
                    format="DD.MM.YYYY HH:mm:ss"
                    type="datetime"
                    placeholder="Teknisyen atama tarihini seçiniz"
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

    <el-dialog v-model="cihazDialogVisible" title="Cihaz Ekle / Düzenle" width="40%" destroy-on-close center>
      <div class="row" v-loading="createDeviceLoading">
        <el-form
          status-icon
          :rules="newDeviceRules"
          ref="formDeviceRef"
          :model="newDevice"
          @submit.prevent="deviceSubmit()"
          label-width="120px"
          label-position="top"
        >
          <div class="row">
            <!-- Firma Unvan -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Firma Unvanı</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="customerTitle">
                  <el-input v-model="firmaOzet.customerTitle" disabled></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Adres Başlık -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Adres</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="addressId">
                  <el-select placeholder="Adres seçiniz" filterable clearable v-model="newDevice.addressId">
                    <li class="el-select-dropdown__item">
                      <div class="row">
                        <div class="col-md-3" style="font-size: 12px">Adres Başlığı</div>
                        <div class="col-md-3" style="font-size: 12px">Şehir</div>
                        <div class="col-md-3" style="font-size: 12px">İlçe</div>
                        <div class="col-md-3" style="font-size: 12px">Semt</div>
                      </div>
                    </li>
                    <el-option v-for="item in addressList" :key="item.id" :label="item.addressTitle" :value="item.id">
                      <div class="row">
                        <div class="col-md-3" style="font-size: 12px">
                          {{ item.addressTitle }}
                        </div>
                        <div class="col-md-3" style="font-size: 12px">
                          {{ item.district.city.name }}
                        </div>
                        <div class="col-md-3" style="font-size: 12px">
                          {{ item.district.name }}
                        </div>
                        <div class="col-md-3" style="font-size: 12px">
                          {{ item.querterName }}
                        </div>
                      </div>
                    </el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Cihaz Tip -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Tip</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="selectedDeviceType">
                  <el-select
                    placeholder="Cihaz tip seçiniz"
                    @change="onDeviceTypeChange()"
                    filterable
                    clearable
                    v-model="selectedDeviceType"
                  >
                    <el-option v-for="item in deviceTypeList" :key="item.id" :label="item.name" :value="item.id">
                    </el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Cihaz Marka -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Marka</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="selectedDeviceBrand">
                  <el-select
                    @change="onDeviceBrandChange()"
                    placeholder="Cihaz marka seçiniz"
                    filterable
                    clearable
                    v-model="selectedDeviceBrand"
                  >
                    <el-option v-for="item in deviceBrandList" :key="item.id" :label="item.name" :value="item.id">
                    </el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Cihaz Model -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Model</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="deviceModelId">
                  <el-select placeholder="Cihaz model seçiniz" filterable clearable v-model="newDevice.deviceModelId">
                    <el-option v-for="item in deviceModelList" :key="item.id" :label="item.name" :value="item.id">
                    </el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Seri No -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Seri No</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="serialNumber">
                  <el-input v-model="newDevice.serialNumber" placeholder="Cihaz seri no giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Montaj Tarihi -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Montaj Tarihi</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="assemblyDate">
                  <el-date-picker
                    v-model="newDevice.assemblyDate"
                    format="DD.MM.YYYY"
                    type="datetime"
                    placeholder="Montaj tarihi seçiniz"
                    :shortcuts="shortcuts"
                  />
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Cihaz Durumu -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Cihaz Durumu</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="status">
                  <el-select placeholder="Cihaz durumunu seçiniz" filterable clearable v-model="newDevice.status">
                    <el-option label="Aktif" :value="true"></el-option>
                    <el-option label="Pasif" :value="false"></el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Açıklama -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-6 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Cihaz Açıklaması</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="description">
                  <el-input v-model="newDevice.description" placeholder="Cihaz açıklaması giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Bakım Periyodu -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-6 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Bakım Periyodu</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="maintenancePeriod">
                  <el-select
                    placeholder="Cihaz bakım periyodu seçiniz"
                    filterable
                    clearable
                    v-model="newDevice.maintenancePeriod"
                  >
                    <el-option label="1 Aylık" value="1"></el-option>
                    <el-option label="2 Aylık" value="2"></el-option>
                    <el-option label="3 Aylık" value="3"></el-option>
                    <el-option label="4 Aylık" value="4"></el-option>
                    <el-option label="5 Aylık" value="5"></el-option>
                    <el-option label="6 Aylık" value="6"></el-option>
                    <el-option label="7 Aylık" value="7"></el-option>
                    <el-option label="8 Aylık" value="8"></el-option>
                    <el-option label="9 Aylık" value="9"></el-option>
                    <el-option label="10 Aylık" value="10"></el-option>
                    <el-option label="11 Aylık" value="11"></el-option>
                    <el-option label="12 Aylık" value="12"></el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>
          </div>
          <!--begin::Actions-->
          <div class="text-center">
            <!--begin::Button-->
            <button
              v-if="selectMode == 'I'"
              :data-kt-indicator="createDeviceLoading ? 'on' : null"
              class="btn btn-lg btn-primary"
              type="submit"
            >
              <span v-if="!createDeviceLoading" class="indicator-label"> Kaydet </span>
              <span v-if="createDeviceLoading" class="indicator-progress">
                Lütfen Bekleyiniz...
                <span class="spinner-border spinner-border-sm align-middle ms-2"></span>
              </span>
            </button>
            <button
              v-else
              :data-kt-indicator="createDeviceLoading ? 'on' : null"
              class="btn btn-lg btn-primary"
              type="submit"
            >
              <span v-if="!createDeviceLoading" class="indicator-label"> Güncelle </span>
              <span v-if="createDeviceLoading" class="indicator-progress">
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

    <el-dialog v-model="musteriDialogVisible" title="Müşteri İşlemleri" width="60%" destroy-on-close center>
      <div class="row" v-loading="musteriLoading">
        <el-form
          status-icon
          :rules="newCustomerRules"
          ref="formCustomerRef"
          :model="newCustomer"
          @submit.prevent="customerSubmit()"
          label-width="120px"
          label-position="top"
        >
          <div class="row">
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-6 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Unvan</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="title">
                  <el-input v-model="newCustomer.title" placeholder="Müşteri unvanını giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-2 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Sektör</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="sectorId">
                  <el-select
                    placeholder="Sektör seçiniz"
                    @change="onDeviceTypeChange()"
                    filterable
                    clearable
                    v-model="newCustomer.sectorId"
                  >
                    <el-option v-for="item in sectorList" :key="item.id" :label="item.name" :value="item.id">
                    </el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-2 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Müşteri Durumu</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="status">
                  <el-select placeholder="Cihaz durumunu seçiniz" filterable clearable v-model="newCustomer.status">
                    <el-option label="Aktif" :value="true"></el-option>
                    <el-option label="Pasif" :value="false"></el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-2 col-sm-12">
              <!--begin::Actions-->
              <div class="text-center mt-8">
                <!--begin::Button-->
                <button
                  v-if="selectMode == 'I'"
                  :data-kt-indicator="loading ? 'on' : null"
                  class="btn btn-lg btn-primary btn-sm"
                  type="submit"
                >
                  <span v-if="!loading" class="indicator-label"> Kaydet </span>
                  <span v-if="loading" class="indicator-progress">
                    Lütfen Bekleyiniz...
                    <span class="spinner-border spinner-border-sm align-middle ms-2"></span>
                  </span>
                </button>
                <button
                  v-else
                  :data-kt-indicator="loading ? 'on' : null"
                  class="btn btn-lg btn-primary btn-sm"
                  type="submit"
                >
                  <span v-if="!loading" class="indicator-label"> Güncelle </span>
                  <span v-if="loading" class="indicator-progress">
                    Lütfen Bekleyiniz...
                    <span class="spinner-border spinner-border-sm align-middle ms-2"></span>
                  </span>
                </button>
                <!--end::Button-->
              </div>
              <!--end::Actions-->
            </div>
          </div>
        </el-form>
      </div>
      <div class="row mt-2">
        <div class="col-md-12">
          <el-divider content-position="left">Adres Listesi</el-divider>
        </div>
      </div>
      <div class="row">
        <div v-if="adresTableVisible" class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12 mb-1">
          <el-table
            :data="addressList"
            style="width: 100%"
            height="250"
            max-height="250px"
            :default-sort="{ prop: 'startDate', order: 'descending' }"
          >
            <template #empty>
              <div class="row">
                <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 mb-md-1">
                  <el-button type="danger" size="small" @click="adresDialogAc()">
                    <el-icon> <Plus></Plus> </el-icon>Yeni Ekle
                  </el-button>
                </div>
              </div>
            </template>
            <el-table-column label="Adres Başlık" width="170" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.addressTitle }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açık Adres" width="200" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.netAddress }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Şehir" width="120" sortable>
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.district.city.name }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="İlçe" width="130">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.district.name }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Semt" width="140">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.querterName }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Yetkili Ad" width="150">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.authorizedName }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Yetkili Görev" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.authorizedTask }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Yetkili Telefon" width="170">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.authorizedPhone }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Yetkili Telefon (İş)" width="170">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.authorizedWorkPhone }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Yetkili Mail" width="200">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.authorizedEmail }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Departman" width="120">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.department }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Muhasebe Kodu" width="135">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.accountCode }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="Açıklama" width="170">
              <template #default="scope">
                <div style="display: flex; align-items: center">
                  <span>{{ scope.row.description }}</span>
                </div>
              </template>
            </el-table-column>
            <el-table-column label="#" fixed="left" width="140">
              <template #default="scope">
                <el-dropdown size="small" split-button type="danger" @click="adresDialogAc()">
                  Yeni Ekle
                  <template #dropdown>
                    <el-dropdown-menu>
                      <el-dropdown-item @click="adresDialogAc(scope.row.id)">
                        <el-icon>
                          <Edit></Edit>
                        </el-icon>
                        Düzenle
                      </el-dropdown-item>
                      <el-dropdown-item @click="deleteAdres(scope.row.id)">
                        <el-icon>
                          <el-icon>
                            <Delete />
                          </el-icon>
                        </el-icon>
                        Sil
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </template>
                </el-dropdown>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </div>
    </el-dialog>

    <el-dialog v-model="adresDialogVisible" title="Adres Ekle / Düzenle" width="40%" destroy-on-close center>
      <div class="row" v-loading="adresLoading">
        <el-form
          status-icon
          :rules="newAddressRules"
          ref="formAddressRef"
          :model="newAddress"
          @submit.prevent="addressSubmit()"
          label-width="120px"
          label-position="top"
        >
          <div class="row">
            <!-- Adres Başlık -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-8 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Adres Başlığı</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="addressTitle">
                  <el-input v-model="newAddress.addressTitle" placeholder="Adres başlığını giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Muhasebe Kodu -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Muhasebe Kodu</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="accountCode">
                  <el-input v-model="newAddress.accountCode" placeholder="Muhasebe kodunu giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Şehir -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Şehir</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="selectedSehir">
                  <el-select
                    placeholder="Şehir seçiniz"
                    @change="onSehirChange()"
                    filterable
                    clearable
                    v-model="selectedSehir"
                  >
                    <el-option v-for="item in sehirList" :key="item.id" :label="item.name" :value="item.id">
                    </el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- İlçe -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>İlçe</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="districtId">
                  <el-select placeholder="İlçe seçiniz" filterable clearable v-model="newAddress.districtId">
                    <el-option v-for="item in ilceList" :key="item.id" :label="item.name" :value="item.id"> </el-option>
                  </el-select>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Semt -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Semt</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="querterName">
                  <el-input v-model="newAddress.querterName" placeholder="Semt giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Açık Adres -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-8 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2 required">
                  <span>Açık Adres</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="netAddress">
                  <el-input v-model="newAddress.netAddress" placeholder="Açık adres giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Bölge -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Bölge</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="regionCode">
                  <el-input v-model="newAddress.regionCode" placeholder="Bölge giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Yetkili Ad -->
            <div class="col-md-12 col-lg-4 col-xl-4 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Yetkili Ad Soyad</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="authorizedName">
                  <el-input
                    v-model="newAddress.authorizedName"
                    placeholder="Yetkili ad soyad bilgisini giriniz"
                  ></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Yetkili Görev -->
            <div class="col-md-12 col-lg-4 col-xl-4 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Yetkili Görevi</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="authorizedTask">
                  <el-input
                    v-model="newAddress.authorizedTask"
                    placeholder="Yetkili görev bilgisini giriniz"
                  ></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Yetkili Mail -->
            <div class="col-md-12 col-lg-4 col-xl-4 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Yetkili Mail</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="authorizedEmail">
                  <el-input
                    v-model="newAddress.authorizedEmail"
                    placeholder="Yetkili mail bilgisini giriniz"
                  ></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Yetkili Telefon -->
            <div class="col-md-12 col-lg-4 col-xl-4 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Yetkili Telefon</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="authorizedPhone">
                  <el-input
                    v-model="newAddress.authorizedPhone"
                    :formatter="
                      value => value.replace(/\D/g, '').replace(/^(\d{3})(\d{3})(\d{2})(\d{2}).*/, '+90-($1)-$2-$3-$4')
                    "
                    placeholder="Yetkili telefon bilgisini giriniz"
                  />
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Yetkili Telefon -->
            <div class="col-md-12 col-lg-4 col-xl-4 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Yetkili Telefon (İş)</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="authorizedWorkPhone">
                  <el-input
                    v-model="newAddress.authorizedWorkPhone"
                    :formatter="
                      value => value.replace(/\D/g, '').replace(/^(\d{3})(\d{3})(\d{2})(\d{2}).*/, '+90-($1)-$2-$3-$4')
                    "
                    placeholder="Yetkili telefon bilgisini giriniz"
                  />
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Departman -->
            <div class="col-md-12 col-lg-4 col-xl-4 col-xxl-4 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Departman</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="department">
                  <el-input v-model="newAddress.department" placeholder="Departman bilgisini giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>

            <!-- Açıklama -->
            <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12 col-sm-12">
              <!--begin::Input group-->
              <div class="d-flex flex-column mb-1 fv-row">
                <!--begin::Label-->
                <label class="d-flex align-items-center fs-6 fw-bold mb-2">
                  <span>Açıklama</span>
                </label>
                <!--end::Label-->
                <el-form-item prop="description">
                  <el-input v-model="newAddress.description" placeholder="Açıklama bilgisini giriniz"></el-input>
                </el-form-item>
              </div>
              <!--end::Input group-->
            </div>
          </div>
          <!--begin::Actions-->
          <div class="text-center">
            <!--begin::Button-->
            <button
              v-if="selectAddressMode == 'I'"
              :data-kt-indicator="loading ? 'on' : null"
              class="btn btn-lg btn-primary btn-sm"
              type="submit"
            >
              <span v-if="!loading" class="indicator-label"> Kaydet </span>
              <span v-if="loading" class="indicator-progress">
                Lütfen Bekleyiniz...
                <span class="spinner-border spinner-border-sm align-middle ms-2"></span>
              </span>
            </button>
            <button v-else :data-kt-indicator="loading ? 'on' : null" class="btn btn-lg btn-primary" type="submit">
              <span v-if="!loading" class="indicator-label"> Güncelle </span>
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
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref, vModelCheckbox } from 'vue';
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
import { IAddressData } from '@/core/data/AddressData';
import { IDeviceTypeData } from '@/core/data/DeviceTypeData';
import { showSuccessMessage, showErrorMessage, showWarningMessage } from '@/core/plugins/Utils';
import { ISectorData } from '@/core/data/SectorData';
import { ICityData } from '@/core/data/CityData';
import { IDistrictData } from '@/core/data/DistrictData';
import { IQuerterData } from '@/core/data/QuerterData';
import { IContractCodeData } from '@/core/data/ContractCodeData';
import SozlesmeListesi from '@/components/partial/SozlesmeListesi.vue';

export default defineComponent({
  name: 'default-dashboard-widget-2',
  components: {
    ErrorMessage,
    Field,
    Form,
    Search,
    Plus,
    SozlesmeListesi,
  },
  setup() {
    const store = useStore();
    const router = useRouter();

    const talepDialogVisible = ref(false);
    const cihazDialogVisible = ref(false);
    const adresDialogVisible = ref(false);
    const cihazListesiDialogVisible = ref(false);
    const musteriDialogVisible = ref(false);
    const servisAcDialogVisible = ref(false);

    const loading = ref<boolean>(false);
    const anaSayfaLoading = ref<boolean>(false);
    const servisAcLoading = ref<boolean>(false);
    const talepDetayLoading = ref<boolean>(false);
    const deviceLoading = ref<boolean>(false);
    const createDeviceLoading = ref<boolean>(false);
    const musteriLoading = ref<boolean>(false);
    const adresLoading = ref<boolean>(false);

    const adresTableVisible = ref<boolean>(false);

    var newCustomer = ref<ICustomerData>({
      sectorId: '',
      title: '',
      id: '',
      status: true,
    });

    var newAddress = ref<IAddressData>({
      accountCode: '',
      addressTitle: '',
      serialNumber: '',
      authorizedEmail: '',
      authorizedName: '',
      authorizedPhone: '',
      authorizedWorkPhone: '',
      authorizedTask: '',
      customerId: '',
      description: '',
      id: '',
      customer: null,
      deviceModel: null,
      netAddress: '',
      querterName: '',
      regionCode: '',
    });

    var firmaOzet = ref<IFirmaOzetData>({
      device: null,
      deviceBrand: null,
      deviceId: null,
      deviceModel: null,
      accountCode: '',
      authorizedEmail: '',
      authorizedName: '',
      authorizedPhone: '',
      authorizedWorkPhone: '',
      authorizedTask: '',
      backgroundColor: '',
      cityName: '',
      colorCount: '',
      contractMaintenanceStatus: '',
      contractType: '',
      customerId: null,
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
      addressId: null,
      department: '',
    });

    var device = ref<IDeviceData>({
      address: null,
      addressId: '',
      assemblyDateString: '',
      description: '',
      deviceModel: null,
      deviceModelId: '',
      id: null,
      rowId: '',
      serialNumber: '',
      status: false,
    });

    var deviceBrand = ref<IDeviceBrandData>({
      name: '',
      deviceType: null,
    });

    var deviceModel = ref<IDeviceModelData>({
      deviceBrand: null,
      deviceBrandId: '',
      name: '',
    });

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
      deviceId: null,
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
        avatar: '',
        email: '',
        firstname: '',
        fullname: '',
        id: '',
        lastname: '',
        gender: 0,
        admin: false,
      },
      userAssignDate: '',
      userAssignDateString: '',
      userId: '',
      wbCount: '',
      yellowCount: '',
    });

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
      deviceId: null,
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
        avatar: '',
        email: '',
        firstname: '',
        fullname: '',
        id: '',
        lastname: '',
        gender: 0,
        admin: false,
      },
      userAssignDate: '',
      userAssignDateString: '',
      userId: '',
      wbCount: '',
      yellowCount: '',
    });

    var newDevice = ref<IDeviceData>({
      address: null,
      addressId: '',
      description: '',
      deviceModel: null,
      deviceModelId: '',
      id: null,
      rowId: '',
      serialNumber: '',
      status: true,
      maintenancePeriod: '',
      assemblyDate: '',
    });

    var technicianUserList = ref<Array<IUserData>>([]);
    var customerList = ref<Array<ICustomerData>>([]);
    var deviceTypeList = ref<Array<IDeviceTypeData>>([]);
    var deviceBrandList = ref<Array<IDeviceBrandData>>([]);
    var deviceModelList = ref<Array<IDeviceModelData>>([]);
    var deviceList = ref<Array<IDeviceData>>([]);
    var deviceServices = ref<Array<IDeviceServiceData>>([]);

    var customerAddresses = ref<Array<IAddressData>>([]);

    var deviceStatus = ref<string>('');
    var backgroundColor = ref<string>('');
    var maintenanceBackgroundColor = ref<string>('');
    var contractMaintenanceStatus = ref<string>('');
    var selectedDevice = ref<string>('');
    var selectedDeviceType = ref<string>('');
    var selectedDeviceBrand = ref<string>('');
    var selectedCustomer = ref<string>('');
    var selectedSerialNo = ref<string>();
    var selectedModelName = ref<string>();
    var selectedSehir = ref<string>();
    var selectedIlce = ref<string>();
    var selectMode = ref<string>('I');
    var selectAddressMode = ref<string>('I');

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

    var bootCodeList = ref<Array<IBootCodeData>>([]);

    var customerInfoList = ref<Array<ICustomerListData>>([]);
    var deviceInfoList = ref<Array<ICustomerListData>>([]);
    var deviceServices = ref<Array<IDeviceServiceData>>([]);
    var modelList = ref<Array<ICustomerListData>>([]);
    var seriNoList = ref<Array<ICustomerListData>>([]);
    var addressList = ref<Array<IAddressData>>([]);
    var sectorList = ref<Array<ISectorData>>([]);

    var sehirList = ref<Array<ICityData>>([]);
    var ilceList = ref<Array<IDistrictData>>([]);
    var semtList = ref<Array<IQuerterData>>([]);

    const formServiceRef = ref<null | HTMLFormElement>(null);
    const formDeviceRef = ref<null | HTMLFormElement>(null);
    const formCustomerRef = ref<null | HTMLFormElement>(null);
    const formAddressRef = ref<null | HTMLFormElement>(null);
    const sozlesmeListesiRef = ref<null | HTMLFormElement>(null);

    var deviceId = ref<string>('');

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

    const newDeviceRules = ref({
      addressId: [
        {
          required: true,
          message: 'Adres seçilmedi.',
          trigger: 'blur',
        },
      ],
      deviceModelId: [
        {
          required: true,
          message: 'Cihaz model seçilmedi.',
          trigger: 'blur',
        },
      ],
      serialNumber: [
        {
          required: true,
          message: 'Cihaz seri no girilmedi.',
          trigger: 'blur',
        },
      ],
      assemblyDate: [
        {
          required: true,
          message: 'Cihaz montaj tarihi girilmedi.',
          trigger: 'blur',
        },
      ],
      status: [
        {
          required: true,
          message: 'Cihaz durumu seçilmedi.',
          trigger: 'blur',
        },
      ],
      maintenancePeriod: [
        {
          required: true,
          message: 'Bakım periyodu seçilmedi.',
          trigger: 'blur',
        },
      ],
    });

    const newCustomerRules = ref({
      title: [
        {
          required: true,
          message: 'Unvan girilmedi.',
          trigger: 'blur',
        },
      ],
      sectorId: [
        {
          required: true,
          message: 'Sektör seçilmedi.',
          trigger: 'blur',
        },
      ],
      status: [
        {
          required: true,
          message: 'Müşteri durumu seçilmedi.',
          trigger: 'blur',
        },
      ],
    });

    const newAddressRules = ref({
      addressTitle: [
        {
          required: true,
          message: 'Adres başlığı girilmedi.',
          trigger: 'blur',
        },
      ],
      districtId: [
        {
          required: true,
          message: 'İlçe seçilmedi.',
          trigger: 'blur',
        },
      ],
      netAddress: [
        {
          required: true,
          message: 'Açık adres girilmedi.',
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

          newService.value.deviceId = Number(firmaOzet.value.deviceId);

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

    const deviceSubmit = () => {
      if (!formDeviceRef.value) {
        return;
      }

      formDeviceRef.value.validate(async valid => {
        if (valid) {
          createDeviceLoading.value = true;
          console.log(newDevice.value);

          if (selectMode.value == 'I') {
            await store
              .dispatch(Actions.ADD_DEVICE, newDevice.value)
              .then(result => {
                loading.value = false;
                if (result.isSuccess) {
                  showSuccessMessage('Cihaz başarıyla eklendi.').then(async () => {
                    if (!firmaOzet.value.deviceId) {
                      var rowId = firmaOzet.value.customerId + '|' + firmaOzet.value.addressId + '|' + result.data.id;
                      await getMainPageCustomer(rowId);
                    }
                    createDeviceLoading.value = false;
                    cihazDialogVisible.value = false;
                  });
                } else {
                  showErrorMessage(result.message).then(() => {
                    createDeviceLoading.value = false;
                    servisAcDialogVisible.value = false;
                  });
                }
              })
              .catch(({ response }) => {});
          } else {
            await store
              .dispatch(Actions.UPDATE_DEVICE, newDevice.value)
              .then(result => {
                loading.value = false;
                if (result.isSuccess) {
                  showSuccessMessage('Cihaz başarıyla güncellendi.').then(async () => {
                    deviceLoading.value = false;
                    cihazDialogVisible.value = false;
                    if (firmaOzet.value.deviceId == newDevice.value.id) {
                      var rowId =
                        firmaOzet.value.customerId + '|' + firmaOzet.value.addressId + '|' + firmaOzet.value.deviceId;
                      await getMainPageCustomer(rowId);
                    }
                  });
                } else {
                  showErrorMessage(result.message).then(() => {
                    createDeviceLoading.value = false;
                    servisAcDialogVisible.value = false;
                  });
                }
              })
              .catch(({ response }) => {});
          }

          createDeviceLoading.value = false;
        }
      });
    };

    const customerSubmit = () => {
      if (!formCustomerRef.value) {
        return;
      }

      formCustomerRef.value.validate(async valid => {
        if (valid) {
          musteriLoading.value = true;
          console.log(newDevice.value);

          if (selectMode.value == 'I') {
            await store
              .dispatch(Actions.ADD_CUSTOMER, newCustomer.value)
              .then(result => {
                loading.value = false;
                if (result.isSuccess) {
                  showSuccessMessage('Müşteri başarıyla eklendi.').then(() => {
                    newCustomer.value = result.data;
                    console.log(newCustomer.value);
                    adresTableVisible.value = true;
                  });
                } else {
                  showErrorMessage(result.message).then(() => {
                    deviceLoading.value = false;
                    servisAcDialogVisible.value = false;
                  });
                }
              })
              .catch(({ response }) => {});
          } else {
            await store
              .dispatch(Actions.UPDATE_CUSTOMER, newCustomer.value)
              .then(result => {
                loading.value = false;
                if (result.isSuccess) {
                  showSuccessMessage('Müşteri başarıyla güncellendi.').then(async () => {
                    deviceLoading.value = false;
                    cihazDialogVisible.value = false;
                    if (firmaOzet.value.deviceId === newDevice.value.id) {
                      var rowId =
                        firmaOzet.value.customerId + '|' + firmaOzet.value.addressId + '|' + firmaOzet.value.deviceId;
                      await getMainPageCustomer(rowId);
                    }
                  });
                } else {
                  showErrorMessage(result.message).then(() => {
                    deviceLoading.value = false;
                    servisAcDialogVisible.value = false;
                  });
                }
              })
              .catch(({ response }) => {});
          }

          musteriLoading.value = false;
        }
      });
    };

    // Adres Submit
    const addressSubmit = () => {
      if (!formAddressRef.value) {
        return;
      }

      formAddressRef.value.validate(valid => {
        if (valid) {
          adresLoading.value = true;
          console.log(newAddress.value);

          newAddress.value.customerId = newCustomer.value.id;

          if (selectAddressMode.value == 'I') {
            store
              .dispatch(Actions.ADD_ADDRESS, newAddress.value)
              .then(result => {
                if (result.isSuccess) {
                  showSuccessMessage('Adres başarıyla eklendi.').then(async () => {
                    await getAddressList(newCustomer.value.id);
                    adresLoading.value = false;
                    adresDialogVisible.value = false;
                  });
                } else {
                  showErrorMessage(result.message).then(() => {
                    deviceLoading.value = false;
                    servisAcDialogVisible.value = false;
                  });
                }
              })
              .catch(({ response }) => {});
          } else {
            store
              .dispatch(Actions.UPDATE_ADDRESS, newAddress.value)
              .then(result => {
                loading.value = false;
                if (result.isSuccess) {
                  showSuccessMessage('Adres başarıyla güncellendi.').then(async () => {
                    await getAddressList(newCustomer.value.id);
                    adresLoading.value = false;
                    adresDialogVisible.value = false;
                  });
                } else {
                  showErrorMessage(result.message).then(() => {
                    deviceLoading.value = false;
                    servisAcDialogVisible.value = false;
                  });
                }
              })
              .catch(({ response }) => {});
          }

          adresLoading.value = false;
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

    function clearAddressData() {
      newAddress.value.accountCode = '';
      newAddress.value.addressTitle = '';
      newAddress.value.serialNumber = '';
      newAddress.value.authorizedEmail = '';
      newAddress.value.authorizedName = '';
      newAddress.value.authorizedPhone = '';
      newAddress.value.authorizedWorkPhone = '';
      newAddress.value.authorizedTask = '';
      newAddress.value.customerId = '';
      newAddress.value.description = '';
      newAddress.value.id = '';
      (newAddress.value.customer = null), (newAddress.value.deviceModel = null), (newAddress.value.netAddress = '');
      newAddress.value.querterName = '';
      newAddress.value.department = '';
      newAddress.value.districtId = '';
      newAddress.value.regionCode = '';

      selectedSehir.value = null;
      selectedIlce.value = null;
    }

    function clearPage() {
      firmaOzet.value = {
        customerId: '',
        customerTitle: '',
        customerSectorId: '',
        customerSector: '',
        accountCode: '',
        authorizedName: '',
        authorizedPhone: '',
        authorizedWorkPhone: '',
        authorizedTask: '',
        cityName: '',
        authorizedEmail: '',
        deviceId: null,
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

      device.value = {
        address: null,
        addressId: '',
        assemblyDateString: '',
        description: '',
        deviceModel: null,
        deviceModelId: '',
        id: null,
        rowId: '',
        serialNumber: '',
        status: false,
      };

      selectedModelName.value = '';

      selectedSerialNo.value = '';
      selectedDevice.value = '';

      contractMaintenanceStatus.value = '';

      deviceStatus.value = '';

      sozlesmeListesiRef.value.contracts = [];

      deviceInfoList.value = [];

      deviceBrand.value = {
        deviceType: null,
        name: '',
      };

      deviceServices.value = [];

      backgroundColor.value = '';
      maintenanceBackgroundColor.value = '';
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
        deviceId: null,
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
          avatar: '',
          email: '',
          firstname: '',
          fullname: '',
          id: '',
          lastname: '',
          gender: 0,
          admin: false,
        },
        userAssignDate: '',
        userAssignDateString: '',
        userId: '',
        wbCount: '',
        yellowCount: '',
      };
    }

    function clearDeviceModal() {
      selectedDeviceType.value = '';
      selectedDeviceBrand.value = '';

      newDevice.value = {
        address: null,
        addressId: '',
        description: '',
        deviceModel: null,
        deviceModelId: '',
        id: null,
        rowId: '',
        serialNumber: '',
        status: true,
        maintenancePeriod: '',
        assemblyDate: '',
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
        deviceId: null,
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
          avatar: '',
          email: '',
          firstname: '',
          fullname: '',
          id: '',
          lastname: '',
          gender: 0,
          admin: false,
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
      if (!selectedCustomer) {
        customerList.value = [];
        selectedDevice.value = '';
        return;
      }

      await getMainPageCustomer(selectedCustomer.value);
    }

    async function onDeviceNoChange() {
      if (!selectedDevice) {
        selectedCustomer.value = '';
        return;
      }

      await getMainPageCustomer(selectedDevice.value);
    }

    async function onSerialNoChange() {
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
      if (!selectedModelName) {
        modelList.value = [];
        selectedCustomer.value = '';
        selectedDevice.value = '';
        selectedSerialNo.value = '';
        return;
      }

      await getMainPageCustomer(selectedModelName.value);
    }

    async function onSehirChange() {
      selectedIlce.value = '';
      semtList.value = [];
      ilceList.value = [];

      adresLoading.value = true;

      if (selectedSehir.value) {
        await store
          .dispatch(Actions.GET_DISTRICT_LIST, selectedSehir.value)
          .then(result => {
            if (result.isSuccess) {
              ilceList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      }

      adresLoading.value = false;
    }

    async function getAddressById(id) {
      await store
        .dispatch(Actions.GET_ADDRESSBYID, id)
        .then(async result => {
          if (result.isSuccess) {
            console.clear();
            console.log(result.data);

            selectedSehir.value = result.data.district.city.id;
            await onSehirChange();
            selectedIlce.value = result.data.district.id;
            newAddress.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getMainPageCustomer(rowId) {
      clearPage();

      if (rowId) {
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
              // contracts.value = result.data.contracts;

              if (result.data.device) {
                device.value = result.data.device;
                deviceBrand.value = result.data.device?.deviceModel?.deviceBrand;
                deviceModel.value = result.data.device?.deviceModel;
                deviceStatus.value = device.value.status == true ? 'Aktif' : 'Pasif';
                deviceList.value = result.data.devices;
                contractMaintenanceStatus.value = result.data.maintenanceStatus ? 'Bakım Yapıldı' : 'Bakım Yapılmadı';
                maintenanceBackgroundColor.value = result.data.maintenanceStatus ? '#ABEBC6' : '#F5B7B1';
                backgroundColor.value = device.value.status ? '#ABEBC6' : '#F5B7B1';
                selectedModelName.value = deviceModel.value.name;
                selectedSerialNo.value = device.value.serialNumber;
              }

              deviceList.value = result.data.devices;
              selectedDevice.value = result.data.deviceId;
              selectedCustomer.value = result.data.customerTitle;
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
    }

    async function getLastTradedCustomer() {
      anaSayfaLoading.value = true;
      await store
        .dispatch(Actions.GET_LASTTRADED_CUSTOMER)
        .then(async result => {
          anaSayfaLoading.value = false;
          if (result.isSuccess) {
            firmaOzet.value = result.data;
            console.clear();
            console.log(firmaOzet.value);
            deviceId.value = firmaOzet.value.deviceId;

            // await sozlesmeListesiRef.value?.getContractList();

            if (result.data.device) {
              device.value = result.data.device;
              deviceBrand.value = result.data.device?.deviceModel?.deviceBrand;
              deviceModel.value = result.data.device?.deviceModel;
              deviceStatus.value = device.value.status == true ? 'Aktif' : 'Pasif';
              deviceList.value = result.data.devices;
              contractMaintenanceStatus.value = result.data.maintenanceStatus ? 'Bakım Yapıldı' : 'Bakım Yapılmadı';
              maintenanceBackgroundColor.value = result.data.maintenanceStatus ? '#ABEBC6' : '#F5B7B1';
            }

            selectedDevice.value = result.data.deviceId;
            selectedDevice.value = result.data.deviceId;
            selectedCustomer.value = result.data.customerTitle;
            selectedSerialNo.value = device.value.serialNumber;
            selectedModelName.value = deviceModel.value.name;

            deviceServices.value = result.data.deviceServices;
          } else {
            showWarningMessage(result.message);
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

    async function getCustomerById() {
      await store
        .dispatch(Actions.GET_CUSTOMER, firmaOzet.value.customerId)
        .then(result => {
          if (result.isSuccess) {
            newCustomer.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getAddressList(customerId) {
      await store
        .dispatch(Actions.GET_ADDRESSLISTBYCUSTOMERID, customerId)
        .then(result => {
          if (result.isSuccess) {
            console.log(result.data);
            addressList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getDeviceTypeList() {
      await store
        .dispatch(Actions.GET_DEVICETYPELIST)
        .then(result => {
          if (result.isSuccess) {
            deviceTypeList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getSectorList() {
      await store
        .dispatch(Actions.GET_SECTOR_LIST)
        .then(result => {
          if (result.isSuccess) {
            sectorList.value = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function getSehirList() {
      await store
        .dispatch(Actions.GET_CITY_LIST)
        .then(result => {
          if (result.isSuccess) {
            sehirList.value = result.data;
            adresLoading.value = false;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    async function onDeviceTypeChange() {
      deviceBrandList.value = [];
      deviceModelList.value = [];
      selectedDeviceBrand.value = '';
      newDevice.value.deviceModelId = '';

      if (selectedDeviceType.value) {
        deviceLoading.value = true;
        await store
          .dispatch(Actions.GET_DEVICEBRANDLIST, selectedDeviceType.value)
          .then(result => {
            deviceLoading.value = false;
            if (result.isSuccess) {
              deviceBrandList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      }
    }

    async function onDeviceBrandChange() {
      deviceModelList.value = [];
      newDevice.value.deviceModelId = '';

      if (selectedDeviceBrand.value) {
        deviceLoading.value = true;
        await store
          .dispatch(Actions.GET_DEVICEMODELBYBRANDIDLIST, selectedDeviceBrand.value)
          .then(result => {
            deviceLoading.value = false;
            if (result.isSuccess) {
              deviceModelList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      }
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

    async function adresDialogAc(id = 0) {
      await clearAddressData();

      await getSehirList();

      adresLoading.value = true;
      adresDialogVisible.value = true;

      if (id > 0) {
        selectAddressMode.value = 'U';
        await getAddressById(id);
      } else {
        selectAddressMode.value = 'I';
      }

      adresLoading.value = false;
    }

    async function deleteAdres(id) {
      Swal.fire({
        title: 'Adres kaydı silinecek !!!',
        text: 'Devam etmek istiyor musunuz ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Sil',
        denyButtonText: `Vazgeç`,
      }).then(async result => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          await store
            .dispatch(Actions.DELETE_ADDRESS, id)
            .then(async result => {
              if (result.isSuccess) {
                Swal.fire({
                  text: 'Adres başarıyla silindi.',
                  icon: 'success',
                  buttonsStyling: false,
                  confirmButtonText: 'Tamam',
                  customClass: {
                    confirmButton: 'btn btn-primary',
                  },
                }).then(async () => {
                  await getAddressList(firmaOzet.value.customerId);
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
        } else if (result.isDenied) {
        }
      });
    }

    async function cihazDialogAc(mode) {
      selectMode.value = mode;
      deviceLoading.value = true;
      cihazDialogVisible.value = true;
      clearDeviceModal();
      await getAddressList(firmaOzet.value.customerId);
      await getDeviceTypeList();

      if (mode == 'U') {
        await getDeviceById();
      }

      deviceLoading.value = false;
    }

    async function musteriDialogAc(mode) {
      selectMode.value = mode;
      musteriLoading.value = true;
      musteriDialogVisible.value = true;
      await getSectorList();

      if (mode == 'U') {
        await getCustomerById();
        await getAddressList(firmaOzet.value.customerId);
        adresTableVisible.value = true;
      } else {
      }
      musteriLoading.value = false;
    }

    async function getDeviceById() {
      await store
        .dispatch(Actions.GET_DEVICE_BY_ID, firmaOzet.value.deviceId)
        .then(async result => {
          if (result.isSuccess) {
            console.clear();
            console.log(result.data);

            newDevice.value = result.data;
            var modelId = newDevice.value.deviceModelId;
            selectedDeviceType.value = newDevice.value.deviceModel.deviceBrand.deviceType.id;
            await onDeviceTypeChange();
            selectedDeviceBrand.value = newDevice.value.deviceModel.deviceBrand.id;
            await onDeviceBrandChange();
            console.log(modelId);
            newDevice.value.deviceModelId = modelId;
            newDevice.value.maintenancePeriod = result.data.lastContract.maintenancePeriod.toString();
            newDevice.value.status = result.data.status == true ? true : false;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    }

    const handleDeviceMenuCommand = (command: string | number | object) => {
      switch (command) {
        case 'CI':
          cihazDialogAc('I');
          break;
        case 'CU':
          cihazDialogAc('U');
          break;
        case 'S':
          servisAc();
          break;
        case 'HS':
          servisAc();
          break;
        case 'CL':
          cihazListesi();
          break;
        default:
          break;
      }
    };

    async function deleteCustomerById() {
      Swal.fire({
        title: 'Müşteri kaydı silinecek !!!',
        text: 'Devam etmek istiyor musunuz ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Sil',
        denyButtonText: `Vazgeç`,
      }).then(async result => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          anaSayfaLoading.value = true;
          await store
            .dispatch(Actions.DELETE_CUSTOMER, firmaOzet.value.customerId)
            .then(async result => {
              if (result.isSuccess) {
                await getLastTradedCustomer();
              }
            })
            .catch(() => {
              const [error] = Object.keys(store.getters.getErrors);
            });
          anaSayfaLoading.value = false;
        } else if (result.isDenied) {
        }
      });
    }

    const handleCustomerMenuCommand = (command: string | number | object) => {
      newCustomer.value.title = '';
      newCustomer.value.sectorId = '';
      newCustomer.value.status = true;
      addressList.value = [];

      switch (command) {
        case 'MI':
          musteriDialogAc('I');
          break;
        case 'MU':
          musteriDialogAc('U');
          break;
        case 'MD':
          deleteCustomerById();
          break;
        default:
          break;
      }
    };

    onMounted(async () => {
      await getLastTradedCustomer();
      console.log(store.getters.currentUser);
    });

    return {
      selectAddressMode,
      newCustomerRules,
      newAddressRules,
      newCustomer,
      selectMode,
      loading,
      sectorList,
      store,
      cihazListesiDialogVisible,
      musteriDialogVisible,
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
      cihazDialogVisible,
      newDeviceRules,
      newDevice,
      addressList,
      deviceTypeList,
      deviceBrandList,
      deviceModelList,
      deviceLoading,
      createDeviceLoading,
      selectedDeviceType,
      selectedDeviceBrand,
      formDeviceRef,
      formCustomerRef,
      formAddressRef,
      adresTableVisible,
      musteriLoading,
      customerAddresses,
      adresDialogVisible,
      newAddress,
      selectedSehir,
      sehirList,
      selectedIlce,
      ilceList,
      semtList,
      adresLoading,
      deviceId,
      musteriDialogAc,
      customerSubmit,
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
      getDeviceService,
      cihazDialogAc,
      deviceSubmit,
      onDeviceTypeChange,
      onDeviceBrandChange,
      addressSubmit,
      adresDialogAc,
      onSehirChange,
      deleteAdres,
      handleDeviceMenuCommand,
      handleCustomerMenuCommand,
      sozlesmeListesiRef,
    };
  },
});
</script>

<style>
.flex-grow {
  flex-grow: 1;
}
.arama {
  border: 1px solid #ebd72a;
  border-radius: 5px;
}

.dropdownMenu {
  width: 150px;
}
.aramaDropdownMenu {
  width: 1100px;
}
</style>
