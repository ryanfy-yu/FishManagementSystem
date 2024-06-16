<template>
    <!-- 整体背景 -->
    <div class="common-layout">
        <el-container>
            <el-main>
                <el-row class="row-bg" justify="center" align="middle" style="height: 100%;">
                    <el-col :span="6">
                        <div class="grid-content title">
                            Login
                        </div>
                        <div class="grid-content">
                            <el-input v-model="username" style="width: 100%" placeholder="Please input UserName" />
                        </div>
                        <div class="grid-content">
                            <el-input v-model="password" type="password" style="width: 100"
                                placeholder="Please input Password" />
                        </div>
                        <div class="grid-content">

                            <el-button size="large" style="margin: auto" round :disabled="validateForm"
                                @click="submit_login">Login</el-button>
                        </div>


                    </el-col>
                </el-row>

            </el-main>
        </el-container>
    </div>

</template>

<script lang="ts" setup>
import { ref, computed } from 'vue'

const username = ref("")
const password = ref("")

const submit_login = () => {
    alert("submit")

}

const validateForm = computed(() => {
    return username.value === "" || password.value === ""
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
}

.grid-content {
    padding: 15px;
    text-align: center;

}

.title {
    color: #E5EAF3;
    font-size: 48px;
}
</style>