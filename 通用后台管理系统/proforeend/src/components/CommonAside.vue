<!--页面左侧菜单栏-->
<template>
    <el-menu default-active="1-4-1" class="el-menu-vertical-demo" 
    @open="handleOpen" @close="handleClose" :collapse="isCollapse"
    background-color="#545c64" text-color="#fff" active-text-color="#ffd04b">
        
      <h3>通用后台管理系统</h3>
      <el-menu-item v-for="item in noChildNode" :key="item.name" :index="item.name">
          <i :class="`el-icon-${item.icon}`"></i><!--图标-->
          <span slot="title">{{item.label}}</span>
      </el-menu-item>
      <el-submenu v-for="item in hasChildNode" :key="item.name" :index="item.name">
          <template slot="title">
              <i :class="`el-icon-${item.icon}`"></i>
              <span slot="title">{{ item.label }}</span>
          </template>
          <!--读取到菜单项下的子菜单-->
          <el-menu-item-group v-for="subItem in item.children" :key="subItem.path">
              <el-menu-item index="1-1">{{subItem.label}}</el-menu-item>
          </el-menu-item-group>
      </el-submenu>
</el-menu>
</template>

<style lang="less"> 
    .el-menu-vertical-demo:not(.el-menu--collapse) {
        width:200px;
        min-height: 400px;
    }
    .el-menu {
      height: 100vh;
      h3 {
        color:rgb(165, 21, 21);
      }
    }

</style>

<script>
  export default {
    data() {
      return {
        isCollapse: false,//是否水平折叠
        //数组
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
      handleOpen(key, keyPath) {
        console.log(key, keyPath);
      },
      handleClose(key, keyPath) {
        console.log(key, keyPath);
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
      }

    }

  }
</script>