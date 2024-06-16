<!-- <template>
  <div class="common-layout">
    <el-container>
      <el-header>
        <HomeHeader />
      </el-header>
    </el-container>
    <el-container>

      <el-aside>
        <HomeMenu />
      </el-aside>

      <el-container>
        <el-main>
          <RouterView />
        </el-main>
        <el-footer>
          <el-affix>
            <div class="footer">
              <p>Ryan Fuyuan YU</p>
            </div>
          </el-affix>
        </el-footer>
      </el-container>
    </el-container>
  </div>
</template> -->

<template>
  <div class="common-layout">
    <el-container>
      <el-header style="height: 60px;">
        <HomeHeader />
      </el-header>
      <el-container>
        <el-aside>
          <HomeMenus />
        </el-aside>
        <el-container>
          <el-main style="height: 100%;
  overflow: hidden;
  ">
            <HomeTabs />
          </el-main>
          <el-footer style="height: 30px;">
            <div class="div-foot">Ryan Fuyuan Yu</div>
          </el-footer>
        </el-container>
      </el-container>
    </el-container>
  </div>
</template>

<script lang="ts" setup>
import HomeMenus from '@/components/HomeMenus.vue';
import HomeHeader from '@/components/HomeHeader.vue';
import HomeTabs from '@/components/HomeTabs.vue';
</script>


<style scoped>
.el-aside {
  border-right: 1px solid var(--el-border-color);
  width: 200px;
}

.el-footer {
  border-top: 1px solid var(--el-border-color);
  text-align: right;

}

.common-layout {
  position: absolute;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
}

.el-container {
  height: 100%;
  overflow: hidden;
}

.div-foot {
  right: 10px;
  bottom: 5px;
  position: absolute
}
</style>