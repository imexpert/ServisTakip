<template>
  <el-select placeholder="please select your zone" v-model="selectedSector" @change="changeSector($event)">
    <el-option v-for="item in sectorList" style="height: 30px" :value="item.id" :key="item.id">{{ item.name
      }}</el-option>
  </el-select>
  <!-- <select name="Sector" v-model="selectedSector" @change="changeSector($event)" class="form-select form-select-solid select2-hidden-accessible">
    <option v-for="item in sectorList" style="height: 30px" :value="item.id" :key="item.id">
        {{ item.name }}
    </option>
</select> -->
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

interface SectorData {
  id: Number;
  name: String;
}

export default defineComponent({
  name: 'dropdown-1',
  props: {
    sector: {
      type: Number,
    },
  },
  components: {
    Field,
    ErrorMessage,
  },
  data() {
    return {
      sectorList: [{
        id: 0,
        name: '',
      },],
      selectedSector: this.sector,
    };
  },
  created() {
    console.log(this.selectedSector);
    this.getSectorList();
  },
  methods: {
    changeSector(event) {
      this.selectedSector = event;
    },
    getSectorList() {
      var store = useStore();
      store
        .dispatch(Actions.GET_SECTOR_LIST)
        .then(result => {
          if (result.isSuccess) {
            this.sectorList = result.data;
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
        this.$emit('update:sector', val);
      },
    },
  },
});
</script>
