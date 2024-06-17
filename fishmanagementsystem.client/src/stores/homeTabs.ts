import { defineStore } from 'pinia'
import { ref } from 'vue'

// 你可以任意命名 `defineStore()` 的返回值，但最好使用 store 的名字，同时以 `use` 开头且以 `Store` 结尾。
// (比如 `useUserStore`，`useCartStore`，`useProductStore`)
// 第一个参数是你的应用中 Store 的唯一 ID。
export const useHomeTabsStore = defineStore('homeTabs', () => {


    //定义tab内容结构
    type TabType = {
        title: string;
        name: string;
        content: string;
    }

    const tabsData = ref<TabType[]>([])
    const tabActiveName = ref("home")

    const removeTab = (targetName: string) => {
        const tabs = tabsData.value

        let activeName = tabActiveName.value
        if (tabActiveName.value === targetName) {
            tabs.forEach((tab, index) => {
                if (tab.name === targetName) {
                    const nextTab = tabs[index + 1] || tabs[index - 1]
                    if (nextTab) {
                        activeName = nextTab.name
                    } else {

                        activeName = "home"
                    }
                }
            })
        }
        tabActiveName.value = activeName
        tabsData.value = tabs.filter((tab) => tab.name !== targetName)
    }

    return { tabsData, tabActiveName, removeTab }
})