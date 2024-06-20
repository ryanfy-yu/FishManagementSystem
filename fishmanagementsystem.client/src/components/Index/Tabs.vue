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
          </el-tab-pane>
        </template>
        <el-scrollbar>
          <router-view v-slot="{ Component }">
            <keep-alive>
              <component :is="Component" />
            </keep-alive>
          </router-view>
        </el-scrollbar>
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
import { useRoute, useRouter } from 'vue-router'

const homeTabsStore = useHomeTabsStore()
const homeMenusStore = useHomeMenusStore()
const router = useRouter()


const isfullScreenMode = ref(false);
const useFullScreen = () => {
  isfullScreenMode.value = !isfullScreenMode.value
}

const tabChange = (name: number) => {

  const activeTab = homeTabsStore.tabsData.find(o => o.name == name)

  if (activeTab) {
    router.push(activeTab.path)
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
  /* height: 100%;
  overflow: hidden; */

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