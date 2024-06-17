import { defineStore } from 'pinia'
import { ref } from 'vue'

// 你可以任意命名 `defineStore()` 的返回值，但最好使用 store 的名字，同时以 `use` 开头且以 `Store` 结尾。
// (比如 `useUserStore`，`useCartStore`，`useProductStore`)
// 第一个参数是你的应用中 Store 的唯一 ID。
export const useHomeMenusStore = defineStore('homeMenus', () => {

    const menusData = ref([
        {
            Id: "0",
            title: '首页',
            icon: 'location',
            path: '/DataTable/index',
        },
        {
            Id: "1",
            title: '人员管理',
            icon: 'location',
            path: '/person_manage',
        },
        {
            Id: "2",
            title: '事物管理',
            icon: 'search',
            path: '',
            children: [
                {
                    Id: '2-1',
                    title: '物件管理',
                    icon: 'search',
                    path: '/case_manage',
                    children: []
                },
                {
                    Id: '2-2',
                    title: '物件研判',
                    icon: 'search',
                    path: '/person_involved',
                    children: []
                }
            ]
        },
        {
            Id: "3",
            title: '一键搜',
            icon: 'search',
            path: '/search',
        }])


    return { menusData }
})