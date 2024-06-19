<template>
  <div :class="{ fullScreenMode: isfullScreenMode }" style="height: 100%;">
    <div style='position: relative;height: 100%;'>
      <el-tabs @tab-remove="homeTabsStore.removeTab" @tab-change="tabChange" type="border-card" class="demo-tabs"
        v-model="homeTabsStore.activeTab">

        <template v-for="item in homeTabsStore.tabsData">
          <el-tab-pane :closable="item.isCloseable" :label="item.title" :name="item.name">
            <template #label v-if="item.icon != ''">
              <span class="custom-tabs-label">
                <el-icon>
                  <component :is="item.icon" />
                </el-icon>
                <span>{{ item.title }}</span>
              </span>
            </template>
            <el-scrollbar>
              <router-view name="dataList" />
            </el-scrollbar>
          </el-tab-pane>
        </template>

      </el-tabs>
      <div style='position: absolute;right:10px;top:5px;'>
        <el-button @click="useFullScreen">
          <el-icon>
            <FullScreen />
          </el-icon>
        </el-button>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
// import DataTable from '@/components/DataTable/DataTable.vue';
import { ref } from 'vue'
import { useHomeTabsStore } from "@/stores/homeTabs"
import { useHomeMenusStore } from "@/stores/homeMenus"


let homeTabsStore = useHomeTabsStore()
let homeMenusStore = useHomeMenusStore()

const isfullScreenMode = ref(false);
const useFullScreen = () => {
  isfullScreenMode.value = !isfullScreenMode.value
}

const tabChange = (name: number) => {

  const activeTab = homeTabsStore.tabsData.find(o => o.name == name)

  if (activeTab) {
    homeMenusStore.defaultActive = activeTab.menuIndex
  }
}


</script>


<style>
.el-tabs {
  height: 100%;
  overflow: hidden;
}

.el-tabs__header {

  padding-right: 70px;
}

.el-tab-pane {
  height: 100%;
  overflow: hidden;

}


.demo-tabs>.el-tabs__content {
  height: calc(100% - 50px);
  overflow: hidden;
  padding: 0;
}

.el-tabs__item {
  user-select: none;

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


.fullScreenMode {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
}
</style>