<template>

    <div v-for="item in menusProps.menusTree" :key="item.Id">
        <el-sub-menu v-if="item.children != undefined && item.children.length > 0" :index="item.Id">
            <template #title>
                <el-icon>
                    <component :is="item.icon" />
                </el-icon>
                {{ item.title }}
            </template>
            <MenusTree :menusTree="item.children" />
        </el-sub-menu>

        <el-menu-item v-else :index="item.Id">
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

type Menutype = {
    Id: string;
    title: string;
    path?: string;
    icon?: string;
    children?: Array<any>
}

const menusProps = defineProps({
    menusTree: Array<Menutype>
})

</script>

<style scoped>
.el-menu-item.is-active {

    background: var(--el-menu-hover-bg-color)
}
</style>