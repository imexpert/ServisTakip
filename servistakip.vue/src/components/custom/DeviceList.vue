<template>
  <el-select placeholder="Cihaz seçiniz" filterable clearable v-model="cihazId" @change="onChange()">
    <li class="el-select-dropdown__item">
      <div class="row">
        <div class="col-md-3" style="font-size: 12px">Tip</div>
        <div class="col-md-3" style="font-size: 12px">Marka</div>
        <div class="col-md-3" style="font-size: 12px">Model</div>
        <div class="col-md-3" style="font-size: 12px">Seri No</div>
      </div>
    </li>
    <el-option
      class="dropdownMenu"
      v-for="item in deviceList"
      :key="item.id"
      :label="item.serialNumber"
      :value="item.id"
      @change="onChange()"
    >
      <div class="row">
        <div class="col-md-3" style="font-size: 12px">
          {{ item.deviceModel.deviceBrand.deviceType.name }}
        </div>
        <div class="col-md-3" style="font-size: 12px">
          {{ item.deviceModel.deviceBrand.name }}
        </div>
        <div class="col-md-3" style="font-size: 12px">
          {{ item.deviceModel.name }}
        </div>
        <div class="col-md-3" style="font-size: 12px">
          {{ item.serialNumber }}
        </div>
      </div>
    </el-option>
  </el-select>
</template>

<script lang="ts">
import { IDeviceData } from '@/core/data/DeviceData';
import { defineComponent, ref, watchEffect } from 'vue';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';

export default defineComponent({
  name: 'DeviceListComponent',
  props: ['addressId'],
  setup(props, context) {
    const store = useStore();

    var cihazId = ref<string>('');

    var deviceList = ref<Array<IDeviceData>>([]);

    async function getDeviceList() {
      deviceList.value = [];

      if (props.addressId) {
        await store
          .dispatch(Actions.GET_DEVICELIST_BY_ADDRESSID, props.addressId)
          .then(result => {
            if (result.isSuccess) {
              deviceList.value = result.data;
            }
          })
          .catch(() => {
            const [error] = Object.keys(store.getters.getErrors);
          });
      }
    }

    async function onChange() {
      context.emit('getSelectedId', cihazId);
    }

    watchEffect(async () => await getDeviceList());

    return {
      deviceList,
      cihazId,
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
