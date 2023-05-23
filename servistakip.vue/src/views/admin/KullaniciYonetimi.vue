<template>
  <!--begin::Row-->
  <div class="row g-5 g-xl-2">
    <div class="col-md-12 col-lg-12 col-xl-12 col-xxl-12">
      <el-table
        :data="userList"
        class="tableClass"
        height="150"
        max-height="150px"
        :default-sort="{ prop: 'startDate', order: 'descending' }"
      >
        <el-table-column label="Resim" width="140" label-class-name="tableHeader">
          <template #default="scope">
            <div style="display: flex; align-items: center">
              <span>{{ scope.row.avatar }}</span>
            </div>
          </template>
        </el-table-column>
        <el-table-column label="Ad" width="140" label-class-name="tableHeader">
          <template #default="scope">
            <div style="display: flex; align-items: center">
              <span>{{ scope.row.firstname }}</span>
            </div>
          </template>
        </el-table-column>
        <el-table-column label="Soyad" width="140" label-class-name="tableHeader">
          <template #default="scope">
            <div style="display: flex; align-items: center">
              <span>{{ scope.row.lastname }}</span>
            </div>
          </template>
        </el-table-column>
        <el-table-column label="Cinsiyet" width="160" label-class-name="tableHeader">
          <template #default="scope">
            <div style="display: flex; align-items: center">
              <span>{{ scope.row.gender }}</span>
            </div>
          </template>
        </el-table-column>
        <el-table-column label="E-Mail" width="160" label-class-name="tableHeader">
          <template #default="scope">
            <div style="display: flex; align-items: center">
              <span>{{ scope.row.email }} Aylık</span>
            </div>
          </template>
        </el-table-column>
        <el-table-column label="Son Giriş" width="120" label-class-name="tableHeader">
          <template #default="scope">
            <div style="display: flex; align-items: center">
              <span>{{ scope.row.lastLogin }} </span>
            </div>
          </template>
        </el-table-column>
        <el-table-column label="Roller" width="120" label-class-name="tableHeader">
          <template #default="scope">
            <div style="display: flex; align-items: center">
              <span>{{ scope.row.price }} {{ scope.row.currencyType }} </span>
            </div>
          </template>
        </el-table-column>
        <el-table-column label="#" fixed="left" width="140" label-class-name="tableHeader">
          <template>
            <el-dropdown size="small" split-button type="danger">
              Yeni Ekle
              <template #dropdown>
                <el-dropdown-menu>
                  <el-dropdown-item>
                    <el-icon>
                      <Edit></Edit>
                    </el-icon>
                    Düzenle
                  </el-dropdown-item>
                  <el-dropdown-item>
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
</template>

<script lang="ts">
import { IUserData } from '@/core/data/UserData';
import { defineComponent, onMounted, ref } from 'vue';

export default defineComponent({
  components: {},
  setup() {
    const userDialogVisible = ref<boolean>(false);
    const userList = ref<Array<IUserData>>();

    onMounted(async () => {});

    return {
      userList,
      userDialogVisible,
    };
  },
});
</script>
