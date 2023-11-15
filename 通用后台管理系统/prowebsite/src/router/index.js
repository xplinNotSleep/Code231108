import Vue from 'vue'
import VueRouter from 'vue-router'
import Main from '../view/Main.vue'

import User from '../view/User.vue'
import Mall from '../view/Mall.vue'
import Home from '../view/Home.vue'
import Page1 from '../view/Page1.vue'
import Page2 from '../view/Page2.vue'

Vue.use(VueRouter)

//配置多个路由，切换界面可用
//切换页面可用 
const routes = [
    {
        path: '/',
        component: Main,
        redirect:'/home',
        //嵌套路由
        children:[
            {  path: 'home', component: Home },
            {  path: 'user', component: User },
            {  path: 'mall', component: Mall },
            {  path: 'page1', component: Page1 },
            {  path: 'page2', component: Page2 },
            
        ]
    }
]

const router = new VueRouter({
    routes

})

export default router
