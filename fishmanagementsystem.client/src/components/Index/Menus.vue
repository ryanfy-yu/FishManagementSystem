<template>
  <el-menu default-active="home" vue-router="true" class="el-menu-vertical">
    <MenusTree :menusTree="menusData" />
  </el-menu>

</template>
<script lang="ts" setup>
import { ref } from 'vue'
import {
  Document,
  Menu as IconMenu,
  Location,
  Setting,
} from '@element-plus/icons-vue'



const menuClick = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}

type Menutype = {
  Id: string;
  title: string;
  path?: string;
  icon?: string;
  children?: Array<any>
}

const menusData: Array<Menutype> = [
  {
    Id: "0",
    title: '首页',
    icon: 'location',
    path: '/DataTable/index',
  },
  {
    Id: "1",
    title: '人员管理',
    icon: 'location',
    path: '/person_manage',
  },
  {
    Id: "2",
    title: '事物管理',
    path: '',
    children: [
      {
        Id: '2-1',
        title: '物件管理',
        icon: 'search',
        path: '/case_manage',
        children: []
      },
      {
        Id: '2-2',
        title: '物件研判',
        icon: 'search',
        path: '/person_involved',
        children: []
      }
    ]
  },
  {
    Id: "3",
    title: '一键搜',
    icon: 'search',
    path: '/search',
  }]

</script>

<style scoped>
.el-menu {
  /* 去除多余border */
  border: none;
  user-select: none;
  font-weight: bold
}
</style>