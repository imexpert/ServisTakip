<template>
<div class="row">
    <div class="col-md-12">
        <el-table style="width: 100%">
            <el-table-column label="Başlangıç T." width="180">
                <template #default="scope">
                    <div style="display: flex; align-items: center">
                        <el-icon>
                            <timer />
                        </el-icon>
                        <span style="margin-left: 10px">{{ scope.row.date }}</span>
                    </div>
                </template>
            </el-table-column>
            <el-table-column label="Bitiş T." width="180">
                <template #default="scope">
                    <el-popover effect="light" trigger="hover" placement="top" width="auto">
                        <template #default>
                            <div>name: {{ scope.row.name }}</div>
                            <div>address: {{ scope.row.address }}</div>
                        </template>
                        <template #reference>
                            <el-tag>{{ scope.row.name }}</el-tag>
                        </template>
                    </el-popover>
                </template>
            </el-table-column>
            <el-table-column label="Sözleşme Tip" width="180">
                <template #default="scope">
                    <el-popover effect="light" trigger="hover" placement="top" width="auto">
                        <template #default>
                            <div>name: {{ scope.row.name }}</div>
                            <div>address: {{ scope.row.address }}</div>
                        </template>
                        <template #reference>
                            <el-tag>{{ scope.row.name }}</el-tag>
                        </template>
                    </el-popover>
                </template>
            </el-table-column>
            <el-table-column label="Bakım Periyodu" width="180">
                <template #default="scope">
                    <el-popover effect="light" trigger="hover" placement="top" width="auto">
                        <template #default>
                            <div>name: {{ scope.row.name }}</div>
                            <div>address: {{ scope.row.address }}</div>
                        </template>
                        <template #reference>
                            <el-tag>{{ scope.row.name }}</el-tag>
                        </template>
                    </el-popover>
                </template>
            </el-table-column>
            <el-table-column label="Operations">
                <template #default="scope">
                    <el-button size="small" >Edit</el-button>
                    <el-button size="small" type="danger">Delete</el-button>
                </template>
            </el-table-column>
        </el-table>
    </div>
</div>
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
    Search
} from '@element-plus/icons-vue';

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
        const loading = ref < boolean > (false);

        var sectorList = [{
            id: 0,
            name: '',
        }, ];

        return {
            loading,
            sectorList,
            store,
            centerDialogVisible,
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
