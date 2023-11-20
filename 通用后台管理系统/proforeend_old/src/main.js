import Vue from 'vue'
import App from './App.vue'
import router from './router'//引入路由配置
//导入vue提供的界面插件
import UseUi from 'element-ui'
//导入界面样式
//import 'element-ui/lib/theme-chalk/index.css'

Vue.use(UseUi)
Vue.use(router)

Vue.config.productionTip = false

new Vue({ 
  router,
  render: h => h(App).
  $mounted('#app')
})
