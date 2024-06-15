<template>


 
  <el-menu :default-active="activeIndex" class="el-menu-demo" mode="horizontal" :ellipsis="false"
    @select="handleSelect">
    <el-menu-item index="0">
      <img style="width: 100px" src="https://element-plus.org/images/element-plus-logo.svg" alt="Element logo" />
    </el-menu-item>
    <div class="flex-grow" />



    <el-menu-item index="0">
      <el-switch v-model="isDarkMode" />
    </el-menu-item>

    <el-menu-item index="1">
      <el-avatar :size="40"> Ryan Yu </el-avatar>
    </el-menu-item>
    <el-sub-menu index="2">

      <template #title>
        Settings
      </template>

      <el-menu-item index="2-1">item one</el-menu-item>
      <el-menu-item index="2-2">item two</el-menu-item>
      <el-menu-item index="2-3">item three</el-menu-item>
      <el-sub-menu index="2-4">
        <template #title>item four</template>
        <el-menu-item index="2-4-1">item one</el-menu-item>
        <el-menu-item index="2-4-2">item two</el-menu-item>
        <el-menu-item index="2-4-3">item three</el-menu-item>
      </el-sub-menu>
    </el-sub-menu>
  </el-menu>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue'

const activeIndex = ref('1')
const handleSelect = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}

const isDarkMode = ref(true)


watch(isDarkMode, () => {

  const html = document.querySelector('html')
  if (isDarkMode.value) {
    html.classList.remove("light");
    html.classList.add("dark");
  } else {
    html.classList.remove("dark");
    html.classList.add("light");
  }


})


</script>

<style>
.flex-grow {
  flex-grow: 1;
}
</style>
