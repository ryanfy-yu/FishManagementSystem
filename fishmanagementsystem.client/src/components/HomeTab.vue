<template>
  <el-tabs closable type="border-card" class="demo-tabs">
    <el-tab-pane>
      <template #label>
        <span class="custom-tabs-label">
          <el-icon>
            <HomeFilled />
          </el-icon>
          <span>Home</span>
        </span>
      </template>
      Route
    </el-tab-pane>
    <el-tab-pane label="Config">
      <el-scrollbar>
        <p v-for="item in 30" :key="item" class="scrollbar-demo-item">{{ item }}</p>
      </el-scrollbar>
    </el-tab-pane>
    <el-tab-pane label="Role">
    </el-tab-pane>
    <el-tab-pane label="Task">
      <el-scrollbar>
        <div class='pane-content'>
          <DataTable></DataTable>
        </div>
      </el-scrollbar>
    </el-tab-pane>
  </el-tabs>
</template>

<script lang="ts" setup>
import DataTable from '@/components/DataTable.vue';
</script>

<style>
.el-tabs {
  height: 100%;
  overflow: hidden;

}

.el-tab-pane {
  overflow: hidden;
  height: 100%;
}

.demo-tabs>.el-tabs__content {
  height: calc(100% - 40px);
  overflow: hidden;
  padding: 0;
}

.pane-content {
  padding: 15px;

}



.demo-tabs .custom-tabs-label .el-icon {
  vertical-align: middle;
}

.demo-tabs .custom-tabs-label span {
  vertical-align: middle;
  margin-left: 4px;
}

.scrollbar-demo-item {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 50px;
  margin: 10px;
  text-align: center;
  border-radius: 4px;
  background: var(--el-color-primary-light-9);
  color: var(--el-color-primary);
}
</style>