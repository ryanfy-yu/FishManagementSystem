import { defineStore } from 'pinia'
import { ref } from 'vue'
import { useHomeMenusStore } from "@/stores/homeMenus"
import { useRoute, useRouter } from 'vue-router'


// 你可以任意命名 `defineStore()` 的返回值，但最好使用 store 的名字，同时以 `use` 开头且以 `Store` 结尾。
// (比如 `useUserStore`，`useCartStore`，`useProductStore`)
// 第一个参数是你的应用中 Store 的唯一 ID。
export const useHomeTabsStore = defineStore('homeTabs', () => {
    const router = useRouter()
    const homeMenusStore = useHomeMenusStore()
    //定义tab内容结构
    type TabType = {
        menuIndex: string,
        title: string,
        name: number,
        icon: string,
        content: string,
        path: string,
        isCloseable?: boolean
    }
    const activeTab = ref(0)
    let tabIndex = 0;//获取最大tabindex数

    const tabsData = ref<TabType[]>([])

    const removeTab = (targetName: number) => {
        const tabs = tabsData.value
        let activeName = activeTab.value
        if (activeName === targetName) {
            tabs.forEach((tab, index) => {
                if (tab.name === targetName) {
                    const nextTab = tabs[index + 1] || tabs[index - 1]
                    if (nextTab) {
                        router.push(nextTab.path)
                        activeName = nextTab.name
                    }
                }
            })
        }

        activeTab.value = activeName
        tabsData.value = tabs.filter((tab) => tab.name !== new Number(targetName).valueOf())

    }
    const addTab = (menuEntity: any) => {

        const tabs = tabsData.value
        const tab = tabs.find((tab) => tab.path == menuEntity.path)
        if (tab == undefined) {

            const netTabname = tabIndex++
            activeTab.value = netTabname
            tabsData.value.push({
                menuIndex: menuEntity.index,
                title: menuEntity.title,
                name: netTabname,
                content: menuEntity.content,
                icon: menuEntity.icon,
                path: menuEntity.path,
                isCloseable: menuEntity.isCloseable
            });

            router.push(menuEntity.path)

        } else {
            router.push(tab.path)
            activeTab.value = tab.name
        }
    }

    return { tabsData, activeTab, removeTab, addTab }
})