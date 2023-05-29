<template>
  <el-select placeholder="Adres seçiniz" filterable clearable v-model="addresId" @change="onChange()">
    <li class="el-select-dropdown__item">
      <div class="row">
        <div class="col-md-3" style="font-size: 12px">Adres Başlığı</div>
        <div class="col-md-3" style="font-size: 12px">Şehir</div>
        <div class="col-md-3" style="font-size: 12px">İlçe</div>
        <div class="col-md-3" style="font-size: 12px">Semt</div>
      </div>
    </li>
    <el-option v-for="item in adressList" :key="item.id" :label="item.addressTitle" :value="item.id">
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
</template>

<script lang="ts">
import { defineComponent, ref, watchEffect } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { IAddressData } from '@/core/data/AddressData';

export default defineComponent({
  props: ['customerId'],
  setup(props, context) {
    const store = useStore();

    var addresId = ref<string>('');

    var adressList = ref<Array<IAddressData>>([]);

    async function getAddressList() {
      adressList.value = [];

      if (props.customerId) {
        await store
          .dispatch(Actions.GET_ADDRESSLISTBYCUSTOMERID, props.customerId)
          .then(result => {
            if (result.isSuccess) {
              adressList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      }
    }

    async function onChange() {
      context.emit('getSelectedId', addresId);
    }

    watchEffect(async () => await getAddressList());

    return {
      adressList,
      addresId,
      onChange,
    };
  },
});
</script>

<style scoped>
.dropdownMenu {
  width: 700px;
}
</style>
