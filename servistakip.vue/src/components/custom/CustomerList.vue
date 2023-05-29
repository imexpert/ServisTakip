<template>
  <el-select
    @change="onChange()"
    filterable
    remote
    clearable
    placeholder="Arama için en az 4 harf giriniz"
    reserve-keyword
    remote-show-suffix
    v-model="selectedCustomer"
    :remote-method="remoteTransferMethod">
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
      class="dropdownMenu"
      v-for="item in customerInfoTransferList"
      :key="item.id"
      :label="item.title"
      :value="item.id"
    >
      <div class="row" style="width: 100%">
        <div class="col-md-4" style="font-size: 12px; word-wrap: break-word">
          {{ item.title.substring(0, 47) + '...' }}
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
</template>

<script lang="ts">
import { defineComponent, ref, watchEffect } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { ICustomerListData } from '@/core/data/CustomerListData';
import Swal from 'sweetalert2/dist/sweetalert2.js';

export default defineComponent({
  name: 'CustomerListComponent',
  setup(props, context) {
    const store = useStore();

    var selectedCustomer = ref<string>('');

    var customerInfoTransferList = ref<Array<ICustomerListData>>([]);

      const remoteTransferMethod = async (query: string) => {
      if (query && query.length > 3) {
        await store
          .dispatch(Actions.GET_CUSTOMER_BY_FILTER, query)
          .then(result => {
            if (result.isSuccess) {
              customerInfoTransferList.value = result.data;
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
        customerInfoTransferList.value = [];
      }
    };

    async function onChange() {
      context.emit('getSelectedId', selectedCustomer);
    }

    return {
      customerInfoTransferList,
      selectedCustomer,
      remoteTransferMethod,
      onChange,
    };
  },
});
</script>

<style scoped>
.dropdownMenu {
  width: 1100px;
}
</style>
