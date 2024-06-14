<script lang="ts">
import { defineComponent } from 'vue'
import { ElConfigProvider } from 'element-plus'
import zhCn from 'element-plus/es/locale/lang/zh-cn'


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

<template>
  <el-config-provider :size="size" :z-index="zIndex" :locale="zhCn">
    <RouterView />
  </el-config-provider>
</template>
