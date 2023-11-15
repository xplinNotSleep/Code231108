import Vue from 'vue'
import VueRouter from 'vue-router'
import mainPage from '../view/mainPage.vue'

Vue.use(VueRouter)

//配置多个路由，切换界面可用
//切换页面可用 
export default new VueRouter({
mode:'history',
routes:[
    {
        path: '/main',
        name:'main',
        //component: () => import('../view/index/LoginPage.vue'),
        component: mainPage
    },
    {
        path: '/',
        redirect:'/main',
    
    }
]

})
