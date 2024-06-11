<script lang="ts">
import { defineComponent } from 'vue'
import { ElConfigProvider } from 'element-plus'
import zhCn from 'element-plus/es/locale/lang/zh-cn'


import HomeMenu from '@/components/HomeMenu.vue';

export default defineComponent({
  components: {
    ElConfigProvider,
  },
  setup() {
    return {
      zIndex: 3000,
      size: 'small',
      locale: zhCn
    }
  },
})
</script>

<!-- <template>
  <el-config-provider :size="size" :z-index="zIndex" :locale="zhCn">
    hello
    <header>
      <nav>
        <RouterLink to="/" class="nav-link">Home</RouterLink>
        <RouterLink to="/blog-create" class="nav-link">Create</RouterLink>
      </nav>
    </header>

    <RouterView />
  </el-config-provider>
</template> -->


<template>
  <el-config-provider :size="size" :z-index="zIndex" :locale="zhCn">
    <div class="common-layout">
      <el-container>
        <el-aside>
          <HomeMenu />
        </el-aside>
        <el-container>
          <el-header style="height: 10vh;">Header</el-header>
          <el-main style="height: 85vh;">

            <RouterView />

          </el-main>

          <el-footer style="height: 5vh;">
            <p style="text-align: center;margin: 1vh;">Ryan</p>
          </el-footer>
        </el-container>
      </el-container>
    </div>
  </el-config-provider>
</template>
