<template>



  <el-menu :default-active="activeIndex" class="el-menu-demo" mode="horizontal" :ellipsis="false"
    @select="handleSelect">
    <el-menu-item>
      <img style="width: 100px" src="https://element-plus.org/images/element-plus-logo.svg" alt="Element logo" />
    </el-menu-item>
    <div class="flex-grow">

    </div>
    <el-menu-item>
      <el-switch v-model="isDark" />
    </el-menu-item>

    <el-menu-item>
      <el-dropdown>

        <div class="el-dropdown-link">
          <span class="header-username">Ryan Yu</span>
          <el-icon>
            <Setting />
          </el-icon>
        </div>
        <template #dropdown>
          <el-dropdown-menu>
            <el-dropdown-item>个人资料</el-dropdown-item>
            <el-dropdown-item>锁屏</el-dropdown-item>
            <el-dropdown-item @click="logout">退出</el-dropdown-item>
          </el-dropdown-menu>
        </template>
      </el-dropdown>
    </el-menu-item>

  </el-menu>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue'
import { useToggle } from '@vueuse/shared'
import { useDark } from "@vueuse/core"


const logout = ()=>{

  alert("注销")

}


const activeIndex = ref('1')
const handleSelect = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}


const isDark = useDark()


</script>

<style scoped>
.flex-grow {
  flex-grow: 1;
}
</style>
