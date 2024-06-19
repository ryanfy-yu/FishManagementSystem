<template>
    <!-- 整体背景 -->
    <div class="common-layout">
        <el-container>
            <el-main>
                <el-row class="row-bg" justify="center" align="middle" style="height: 100%;">
                    <el-col :span="6">
                        <H1>Sorry! 出错了！</H1>
                        <H2>找不到页面或者其他原因，请重试</H2>
                    </el-col>
                </el-row>

            </el-main>
        </el-container>
    </div>

</template>

<script lang="ts" setup>
import { ref, computed } from 'vue'

const usernameOfEmail = ref("")
const password = ref("")

const submit_login = () => {
    alert("submit")

}

const validateForm = computed(() => {
    return usernameOfEmail.value === "" || password.value === ""
})


</script>

<style scoped>
.common-layout {
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    background: url('../assets/background.jpg');
}

.el-container {
    height: 100%;
    overflow: hidden;
}

.el-col {
    border-radius: 10px;
    background-color: #1D1D1D;
    padding: 20px;
    opacity: 0.8;
    color: aliceblue;
}
</style>