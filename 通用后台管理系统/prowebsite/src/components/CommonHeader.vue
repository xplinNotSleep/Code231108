<!--顶部导航栏-->
<template>
    <div class="headerContainer">
        <div class="leftContent">
            <!--点击控制左侧菜单栏-->
            <el-button @click="handleMenu" icon="el-icon-menu" size="mini">
            </el-button>
            <!--面包屑-->
            <span class="divTxt">首页</span>
        </div>
        <div class="rightContent">
            <el-dropdown>
                <!--点击内容-->
                <span class="el-dropdown-link">
                    <!--下拉菜单<i class="el-icon-arrow-down 
                    el-icon--right"></i>-->
                    <img class="userImg" src="../assets//images/user.png">    
                </span>
                <el-dropdown-menu slot="dropdown">
                    <el-dropdown-item>个人中心</el-dropdown-item>
                    <el-dropdown-item>退出</el-dropdown-item>
                </el-dropdown-menu>
            </el-dropdown>
        </div>
    </div>

</template>

<script>
export default {
    data() {
       return {} 
    },
    methods:
    {
        //提交按钮控制信息，传到store并影响左侧菜单栏状态
        handleMenu(){
            this.$store.commit('collapseMenu')
        }
    }
}
</script>

<style lang="less" scoped>
.headerContainer
{
    padding:0 10px;
    background-color: rgb(103, 24, 24);
    height: 60px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    .divTxt{
        color:#fff;
        font-size:12px;
        margin-left:5px;
    }
    .rightContent{
        .userImg
        {
            width:30px;
            height: 30px;
            border-radius: 80%;
        }
    }
}


</style>
