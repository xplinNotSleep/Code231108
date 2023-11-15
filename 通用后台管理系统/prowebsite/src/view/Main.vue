<!--系统主界面-->
<template>   
<div>
    <!--有嵌套路由的还需要在这里添加-->
    
    <el-container>
        <el-aside width="200px">
            <Aside0 />
        </el-aside>
        <el-container>
            <el-header>
                <Header0 />
            </el-header>
            <el-main>
                <router-view></router-view>
            </el-main>
            
        </el-container>
    </el-container>
</div>
   
    
</template>

<script>

import Aside0 from '../components/CommonAside.vue'
import Header0 from '../components/CommonHeader.vue'

export default {
    data() {
       return {} 
    },
    
    components:{
        Aside0,
        Header0
    }
}

</script>

<style lang="less" scoped>
    .el-header{
        padding:0
    }


</style>
        
