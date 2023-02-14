<template>
  <div class="row">
    <div class="col-md-12"></div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { ErrorMessage, Field, Form } from 'vee-validate';
import { useStore } from 'vuex';
import { Actions } from '@/store/enums/StoreEnums';
import { Search } from '@element-plus/icons-vue';

interface FirmaOzetData {
  customerId: string;
  customerTitle: string;
}

export default defineComponent({
  name: 'default-dashboard-widget-2',
  components: {
    ErrorMessage,
    Field,
    Form,
    Search,
  },
  setup() {
    const centerDialogVisible = ref(false);
    const store = useStore();
    const loading = ref<boolean>(false);

    var sectorList = [
      {
        id: 0,
        name: '',
      },
    ];

    return {
      loading,
      sectorList,
      store,
      centerDialogVisible,
    };
  },
  props: {
    cihazId: String,
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
      },
    };
  },
  async created() {
    await this.getLastTradedCustomer();
  },
  methods: {
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
            console.log(result.data);
          }
        })
        .catch(() => {
          const [error] = Object.keys(this.store.getters.getErrors);
        });
    },
  },
});
</script>
