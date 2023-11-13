<!--系统主界面-->
<template>
    <div id="mainPage">
        <h1>main</h1>
        <el-container>
            <!--引入左侧菜单-->
            <el-aside width="200px">
                <Aside0 />
            </el-aside>
            <el-container>
                <el-header>Header</el-header>
                <el-main>Main</el-main>

            </el-container>
        </el-container>

    </div>
</template>

<script>

import Aside0 from '../components/CommonAside.vue'

export default {
    data() {
       return {} 
    },
    components:{
        Aside0
    }
}

</script>
        
