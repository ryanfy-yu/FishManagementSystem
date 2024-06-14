<template>
  <div class="common-layout">
    <el-container>
      <el-header style="height: 10vh;background-color: blue;">
      </el-header>
    </el-container>
    <el-container>

      <HomeMenu />

      <el-container>

        <el-main style="height: 85vh;">

          <RouterView />

        </el-main>

        <el-footer>

          <el-affix :position="bottom">
            <p style="text-align: center;margin: 1vh;">Ryan</p>
          </el-affix>
        </el-footer>
      </el-container>

    </el-container>
  </div>
</template>

<script lang="ts" setup>
import HomeMenu from '@/components/HomeMenu.vue';
</script>
