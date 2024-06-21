
import router from "@/router/index";


//全局前置路由守卫————初始化的时候被调用、每次路由切换之前被调用
router.beforeEach((to, from, next) => {
    alert(1)
    //如果路由需要跳转
    if (to.meta.isAuth) {
        //判断 如果school本地存储是qinghuadaxue的时候，可以进去
        if (localStorage.getItem('school') === 'qinghuadaxue') {
            next()  //放行
        } else {
            alert('抱歉，您无权限查看！')
        }
    } else {
        // 否则，放行
        next()
    }
}

