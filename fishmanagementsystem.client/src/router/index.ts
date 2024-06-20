import { createRouter, createWebHistory } from 'vue-router'
import IndexView from '@/views/IndexView.vue'
import LoginView from '@/views/LoginView.vue'
import DataTable from '@/components/DataTable/DataTable.vue'
import HomeView from '@/views/HomeView.vue'



const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: IndexView,
      children: [
        {
          path: 'datalist',
          component: DataTable
        },
        {
          path: 'home',
          component: HomeView
        },
        {
          path: '/:catchAll(.*)', 
          component: () => import('../views/Error.vue')

        }
      ]
    },
    { path: '/error', component: () => import('../views/Error.vue') },
    { path: '/:catchAll(.*)', redirect: '/error' },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/tabpages',
      name: 'tabpages',
      components: {
        "/login": () => LoginView,
        "login": () => LoginView,
      },
      children: [
        {
          name: 'home',
          path: '/home',
          component: HomeView
        },
        {
          name: 'datatable2',
          path: '/datatable2',
          component: DataTable
        }
      ]
    },
  ]
})

export default router
