import Vue from 'vue'
import VueRouter from 'vue-router'
//主界面
import Main from '../view/Main.vue'
import User from '../view/User.vue'
import Mall from '../view/Mall.vue'
import Home from '../view/Home.vue'
import Page1 from '../view/Page1.vue'
import Page2 from '../view/Page2.vue'
//登录界面
import Login from '../view/Login.vue'

Vue.use(VueRouter)

//配置多个路由，切换界面可用
const routes = [
    //主页面各模块路由
    {
        path: '/',
        component: Main,
        name:'Main',
        redirect:'/home',
        //嵌套路由
        children:[
            /*原来写死的
            {  path: 'home', name:"home",component: Home },
            {  path: 'user', name:"user",component: User },
            {  path: 'mall', name:"mall",component: Mall },
            {  path: 'page1', name:"page1",component: Page1 },
            {  path: 'page2', name:"page2",component: Page2 },
            */
            
        ]
    },
    //登录界面路由
    {
        path:'/login',
        name: 'login',
        component:Login
    }
]

const router = new VueRouter({
    routes

})

export default router
