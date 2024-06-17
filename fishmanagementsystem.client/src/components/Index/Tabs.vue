<template>
  <div :class="{ fullScreenMode: isfullScreenMode }" style="height: 100%;">
    <div style='position: relative;height: 100%;'>
      <el-tabs @tab-remove="homeTabsStore.removeTab" type="border-card" class="demo-tabs"
        v-model="homeTabsStore.tabActiveName">
        <el-tab-pane key="home" label="Home" name="home">
          <template #label>
            <span class="custom-tabs-label">
              <el-icon>
                <HomeFilled />
              </el-icon>
              <span>Home</span>
            </span>
          </template>
          <el-scrollbar>
            <DataTable></DataTable>
          </el-scrollbar>
        </el-tab-pane>
        <el-tab-pane closable v-for="item in homeTabsStore.tabsData" :key="item.name" :label="item.title"
          :name="item.name">
          <el-scrollbar>
            {{ item.content }}
          </el-scrollbar>
        </el-tab-pane>
      </el-tabs>
      <div style='position: absolute;right:10px;top:5px;'>
        <el-button @click="addTab">
          Add
        </el-button>
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
import DataTable from '@/components/DataTable/DataTable.vue';
import { ref } from 'vue'
import { useHomeTabsStore } from "@/stores/homeTabs"

const isfullScreenMode = ref(false);

const useFullScreen = () => {
  isfullScreenMode.value = !isfullScreenMode.value
}

//定义tab内容结构
// type TabType = {
//   title: string;
//   name: string;
//   content: string;
// }

//Tabs Data
//const tabActiveName = ref("home")
let homeTabsStore = useHomeTabsStore()


//删除标签页
// const removeTab = (targetName: string) => {
//   const tabs = editableTabs
//   let activeName = tabActiveName.value
//   if (activeName === targetName) {
//     tabs.forEach((tab, index) => {
//       if (tab.name === targetName) {
//         const nextTab = tabs[index + 1] || tabs[index - 1]
//         if (nextTab) {
//           activeName = nextTab.name
//         } else {

//           activeName = "home"
//         }
//       }
//     })
//   }

//   tabActiveName.value = activeName
//   editableTabs = tabs.filter((tab) => tab.name !== targetName)
// }
let tabindex = 1
const addTab = () => {
  const newTabName = tabindex++;
  homeTabsStore.tabsData.push({
    title: 'New Tab' + tabindex,
    name: newTabName.toString(),
    content: 'New Tab content' + tabindex,
  });
  homeTabsStore.tabActiveName = newTabName.toString()
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