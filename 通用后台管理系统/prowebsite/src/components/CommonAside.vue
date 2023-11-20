<!--页面左侧菜单栏-->
<template>  
    <el-menu 
      default-active="1-4-1" 
      class="el-menu-vertical-demo" 
      :collapse="isCollapse"
      background-color="#545c64" 
      text-color="#fff" 
      active-text-color="#ffd04b"
    >
      <h3>{{ isCollapse ?'后台':'通用后台管理系统'}}</h3><!--根据是否展开状态显示不同内容-->
      <!--左侧菜单制作-->
      <el-menu-item @click="clickMenu(item)" v-for="item in noChildNode" :key="item.name" :index="item.name">
          <i :class="`el-icon-${item.icon}`"></i>
          <span slot="title">{{item.label}}</span>
      </el-menu-item>
      <el-submenu v-for="item in hasChildNode" :key="item.name" :index="item.name">
          <template slot="title">
              <i :class="`el-icon-${item.icon}`"></i>
              <span slot="title">{{ item.label }}</span>
          </template>
          <el-menu-item-group v-for="subItem in item.children" :key="subItem.path">
              <el-menu-item @click="clickMenu(subItem)" :index="subItem.name">
                {{subItem.label}}</el-menu-item>
          </el-menu-item-group>
      </el-submenu>
    </el-menu>
</template>


<style lang="less" scoped> 
     
.el-menu-vertical-demo:not(.el-menu--collapse) {
    width:200px;
    min-height: 400px;
    h3 {
      color:rgb(232, 224, 224);
      text-align: center;
    }
}
.el-menu-vertical-demo{
    border-right: none;
    height: 100vh;
    h3{
      text-align: center;
    }

}

</style>

<script>
  export default {
    data() {
      return {
        //isCollapse: false,//是否水平折叠
        //数组,用于显示菜单下具体内容
        menuData: [
        {
          path: '/',
          name: 'home',
          label: '首页',
          icon: 's-home',
          url: 'Home/Home'
        },
        {
          path: '/mall',
          name: 'mall',
          label: '商品管理',
          icon: 'video-play',
          url: 'MallManage/MallManage'
        },
        {
          path: '/user',
          name: 'user',
          label: '用户管理',
          icon: 'user',
          url: 'UserManage/UserManage'
        },
        {
          label: '其他',
          icon: 'location',
          children: [
            {
              path: '/page1',
              name: 'page1',
              label: '页面1',
              icon: 'setting',
              url: 'Other/PageOne'
            },
            {
              path: '/page2',
              name: 'page2',
              label: '页面2',
              icon: 'setting',
              url: 'Other/PageTwo'
            }
          ]
        }]
      };
    },
    methods: {
      //引入路由，点击菜单某项跳转到特定的页面
      clickMenu(item)
      {
        //当页面的路由与跳转的路由不一致时才允许跳转,否则报错
        if(this.$route.path !== item.path &&
         !(this.$route.path === '/home' && (item.path === '/') ))
        {
          this.$router.push(item.path)
        }
        
      }
    },
    //计算属性
    computed:{
      //没有子菜单
      noChildNode()
      {
         return this.menuData.filter(item => !item.children)
      },
      //有子菜单
      hasChildNode()
      {
        //查询子菜单下的内容
        return this.menuData.filter(item => item.children)
      },
      //组件间通信进行控制
      isCollapse(){
        return this.$store.state.tab.isCollapse
      }

    }

  }
</script>