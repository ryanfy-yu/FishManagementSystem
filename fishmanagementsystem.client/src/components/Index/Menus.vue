<template>
  <el-menu  vue-router="true" class="el-menu-vertical" :default-active="homeMenusStore.defaultActive">
    <MenusTree :menuTree="homeMenusStore.menuList" />
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
import { useHomeMenusStore } from '@/stores/homeMenus'

const menuClick = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}

const homeMenusStore = useHomeMenusStore()


</script>

<style scoped>
.el-menu {
  /* 去除多余border */
  border: none;
  user-select: none;
  font-weight: bold
}
</style>