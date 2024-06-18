<template>

    <div v-for="item in menusProps.menuTree" :key="item.index">
        <el-sub-menu v-if="item.children != undefined && item.children.length > 0" :index="item.index">
            <template #title>
                <el-icon>
                    <component :is="item.icon" />
                </el-icon>
                {{ item.title }}
            </template>
            <MenusTree :menuTree="item.children" />
        </el-sub-menu>

        <el-menu-item v-else :index="item.index" @click="clickItem(item)">
            <template #title>
                <el-icon>
                    <component :is="item.icon" />
                </el-icon>
                {{ item.title }}
            </template>
        </el-menu-item>

    </div>
</template>

<script setup lang="ts">

import MenusTree from "@/components/Index/MenusTree.vue"
import { useHomeMenusStore } from "@/stores/homeMenus"

const homeMenusStore = useHomeMenusStore()

type Menutype = {
    index: string;
    title: string;
    path?: string;
    icon?: string;
    children?: Array<any>
}

const menusProps = defineProps({
    menuTree: Array<Menutype>
})



const clickItem = function (item: any) {

    homeMenusStore.clickMenuItem(item)
}

</script>

<style scoped>
.el-menu-item.is-active {
    background: var(--el-menu-hover-bg-color)
}
</style>