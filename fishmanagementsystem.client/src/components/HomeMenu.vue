<template>
  <el-scrollbar>
    <el-menu default-active="2" class="el-menu-vertical" :collapse="isCollapse" @open="handleOpen" @close="handleClose">


      <el-sub-menu :index="index" v-for="(item, index) in 5">
        <template #title>
          <el-icon>
            <Setting />
          </el-icon>
          <span>Navigator {{index}}</span>
        </template>
        <el-menu-item-group>
          <template #title><span>Group {{index}}</span></template>
          <el-menu-item index="{{index}}-1">item one</el-menu-item>
          <el-menu-item index="{{index}}-2">item two</el-menu-item>
        </el-menu-item-group>
        <el-menu-item-group title="Group Two">
          <el-menu-item index="{{index}}-3">item three</el-menu-item>
        </el-menu-item-group>
        <el-sub-menu index="{{index}}-4">
          <template #title><span>item four</span></template>
          <el-menu-item index="{{index}}-4-1">item one</el-menu-item>
        </el-sub-menu>
      </el-sub-menu >
    </el-menu>
  </el-scrollbar>



</template>

<script lang="ts" setup>
import { ref } from 'vue'
import {
  Document,
  Menu as IconMenu,
  Location,
  Setting,
} from '@element-plus/icons-vue'


const handleOpen = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}
const handleClose = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}
</script>

<style scoped>
.el-menu {
  border: none
}
</style>