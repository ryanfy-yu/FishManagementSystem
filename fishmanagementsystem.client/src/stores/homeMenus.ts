import { defineStore } from 'pinia'
import { ref } from 'vue'
import { useHomeTabsStore } from "@/stores/homeTabs"


// 你可以任意命名 `defineStore()` 的返回值，但最好使用 store 的名字，同时以 `use` 开头且以 `Store` 结尾。
// (比如 `useUserStore`，`useCartStore`，`useProductStore`)
// 第一个参数是你的应用中 Store 的唯一 ID。
export const useHomeMenusStore = defineStore('homeMenus', () => {

    const menuList = ref([
        {
            index: "0",
            title: '首页',
            icon: 'HomeFilled',
            path: '/',
        },
        {
            index: "1",
            title: '人员管理',
            icon: 'location',
            path: '/person_manage',
            children: [
                {
                    index: '2',
                    title: '物件管理',
                    icon: 'Document',
                    path: '/case_mafnage',
 
                },
                {
                    index: '3',
                    title: '物件研判',
                    icon: 'Document',
                    path: '/person_involfved',
    
                }
            ]
        },
        {
            index: "4",
            title: '事物管理',
            icon: 'search',
            children: [
                {
                    index: '5',
                    title: '物件管理',
                    icon: 'Document',
                    path: '/caaaaase_manage',
                },
                {
                    index: '6',
                    title: '物件研判',
                    icon: 'Document',
                    path: '/person_aaainvolved',
                }
            ]
        },
        {
            index: "7",
            title: '一键搜',
            icon: 'Document',
            path: '/search',
        }])

    const defaultActive = ref("")

    let homeTabsStore = useHomeTabsStore()

    //默认激活第一页
    const setDefaultActive = function () {

        let menu = menuList.value[0].children == undefined ? menuList.value[0] : menuList.value[0].children[0]

        homeTabsStore.addTab({
            index: menu.index,
            title: menu.title,
            icon: menu.icon,
            path: menu.path,
            isCloseable: false
        })

        defaultActive.value = menuList.value[0].children == undefined ? menuList.value[0].index : menuList.value[0].children[0].index
    }
    setDefaultActive()


    const clickMenuItem = function (menuItem: any) {

        defaultActive.value = menuItem.index

        homeTabsStore.addTab({
            index: menuItem.index,
            title: menuItem.title,
            icon: menuItem.icon,
            path: menuItem.path,
            isCloseable: true
        })


    }



    return { menuList, defaultActive, clickMenuItem }
})