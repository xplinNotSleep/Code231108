<!--顶部导航栏-->
<template>
    <div class="headerContainer">
        <div class="leftContent">
            <!--点击控制左侧菜单栏-->
            <el-button style="margin-right: 10px;" @click="handleMenu" icon="el-icon-menu" size="mini">
            </el-button>
            <!--面包屑(板块切换)-->
            <el-breadcrumb separator="/">
                <!--将左侧菜单栏的内容传递到面包屑列表项中-->
                <el-breadcrumb-item  v-for="item in tags" :key="item.path" :to="{path:item.path}">
                    {{item.label}}
                </el-breadcrumb-item>
            </el-breadcrumb>
        </div>
        <div class="rightContent">
            <el-dropdown @command="handleClick">
                <!--点击内容-->
                <span class="el-dropdown-link">
                    <!--下拉菜单<i class="el-icon-arrow-down 
                    el-icon--right"></i>-->
                    <img class="userImg" src="../assets//images/user.png">    
                </span>
                <el-dropdown-menu slot="dropdown">
                    <el-dropdown-item>个人中心</el-dropdown-item>
                    <el-dropdown-item command="cancel">退出</el-dropdown-item>
                    <!--<el-dropdown-item @click="logout">退出</el-dropdown-item>-->
                </el-dropdown-menu>
            </el-dropdown>
        </div>
    </div>

</template>

<script>

import { mapState } from 'vuex';
import Cookie from 'js-cookie'

export default {
    data() {
       return {} 
    },
    methods:
    {
        //提交按钮控制信息，传到store并影响左侧菜单栏状态
        handleMenu(){
            this.$store.commit('collapseMenu')
        },
        handleClick(command){
            if (command === 'cancel') {
                console.log('登出')
                // 清除cookie中的token
                Cookie.remove('token')
                // 清除cookie中的menu
                //Cookie.remove('menu')
                // 跳转到登录页
                this.$router.push('/login')
            }
        }
    },
    computed:{
        //扩展运算符
        ...mapState({
            tags:state=>state.tab.tabsList
        })
    },
    mounted(){
        console.log(this.tags, 'tags')
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

    .leftContent {
        display: flex;
        align-items: center;

        
        //面包屑样式设置
        /deep/.el-breadcrumb__item {
            .el-breadcrumb__inner {
                font-weight: normal;
                &.is-link {
                    color: #666
                }
            }
            &:last-child {
                .el-breadcrumb__inner {
                    color: #fff
                }
            }
        }

    }
}


</style>
