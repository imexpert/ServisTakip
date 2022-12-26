<template>
  <select name="sector" class="form-select form-select-solid select2-hidden-accessible">
    <option v-for="item in sectorList" :value="item.id" :key="item.id">
      {{ item.name }}
    </option>
  </select>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { Field, ErrorMessage } from 'vee-validate';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';

export default defineComponent({
  name: 'dropdown-1',
  props: ['name'],
  components: {
    Field,
    ErrorMessage,
  },
  data() {
    return {
      sectorList: [
        {
          id: 0,
          name: '',
        },
      ],
      selectedSector: this.sector,
    };
  },
  created() {
    this.getSectorList();
  },
  methods: {
    changeSector(event) {
      this.selectedSector = event.target.value;
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
