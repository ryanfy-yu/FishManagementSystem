import { defineStore } from 'pinia'
import { ref } from 'vue'

// 你可以任意命名 `defineStore()` 的返回值，但最好使用 store 的名字，同时以 `use` 开头且以 `Store` 结尾。
// (比如 `useUserStore`，`useCartStore`，`useProductStore`)
// 第一个参数是你的应用中 Store 的唯一 ID。
export const useHomeTabsStore = defineStore('homeTabs', () => {

    //定义tab内容结构
    type TabType = {
        title: string,
        name: number,
        icon: string,
        content: string,
        path: string,
        isCloseable?: boolean
    }
    const activeTab = ref(0)

    const tabsData = ref<TabType[]>([])

    const removeTab = (targetName: number) => {
        const tabs = tabsData.value
        let activeName = activeTab.value
        if (activeName === targetName) {
            tabs.forEach((tab, index) => {
                if (tab.name === targetName) {
                    const nextTab = tabs[index + 1] || tabs[index - 1]
                    if (nextTab) {
                        activeName = nextTab.name
                    }
                }
            })
        }

        activeTab.value = activeName
        tabsData.value = tabs.filter((tab) => tab.name !== new Number(targetName).valueOf())

    }
    const addTab = (tabItem: any) => {

        const tabs = tabsData.value
        const tab = tabs.find((tab) => tab.path == tabItem.path)
        if (tab == undefined) {


            const netTabname = activeTab.value + 1
            tabsData.value.push({
                title: tabItem.title,
                name: netTabname,
                content: tabItem.content,
                icon: tabItem.icon,
                path: tabItem.path,
                isCloseable: tabItem.isCloseable
            });

            activeTab.value = netTabname//new Number(tabItem.name).valueOf()
        } else {
            activeTab.value = tab.name
        }

        //alert(tabItem.name)

    }

    return { tabsData, activeTab, removeTab, addTab }
})