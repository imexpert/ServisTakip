<template>
  <el-form-item prop="cityId">
    <el-select placeholder="Şehir seçiniz" filterable v-model="selectedCity">
      <el-option v-for="item in cityList" style="height: 30px" :value="item.id" :key="item.id" :label="item.name" />
    </el-select>
  </el-form-item>
</template>

<script lang="ts">
import {
  defineComponent,
  ref
} from 'vue';
import {
  Field,
  ErrorMessage
} from 'vee-validate';
import {
  useStore
} from 'vuex';
import {
  Actions
} from '@/store/enums/StoreEnums';

interface CityData {
  id: Number;
  name: String;
}

export default defineComponent({
  name: 'dropdown-1',
  props: {
    city: {
      type: String,
    },
  },
  components: {
    Field,
    ErrorMessage,
  },
  data() {
    return {
      cityList: [{
        id: 0,
        name: '',
      },],
      selectedCity: this.sector,
    };
  },
  created() {
    this.getCityList();
  },
  methods: {
    changeSector(event) {
      this.selectedCity = event;
    },
    getCityList() {
      var store = useStore();
      store
        .dispatch(Actions.GET_CITY_LIST)
        .then(result => {
          if (result.isSuccess) {
            this.cityList = result.data;
          }
        })
        .catch(() => {
          const [error] = Object.keys(store.getters.getErrors);
        });
    },
  },
  watch: {
    selectedSector: {
      handler(val) {
        this.$emit('update:city', val);
      },
    },
  },
});
</script>
