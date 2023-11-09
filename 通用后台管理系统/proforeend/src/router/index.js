import Vue from 'vue'
import VueRouter from 'vue-router'
import LoginPage from '../view/index/LoginPage.vue'

Vue.use(VueRouter)

//配置多个路由，切换界面可用
//切换页面可用 
export default new VueRouter({
mode:'history',
routes:[
    {
        path: '/login',
        name:'login',
        //component: () => import('../view/index/LoginPage.vue'),
        component: LoginPage
    },
    {
        path: '/',
        redirect:'/login',
    
    }
]

})
