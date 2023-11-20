<!--首页-->
<template>
    <!--row和col组合页面布局-->
    <el-row>
        <el-col :span="8">
            <el-card class="leftTopCard">
                <div  class="user">
                    <img src="../assets/images/user.png" >
                    <div class="userInfo">
                        <p class="userName">Admin</p>
                        <p class="userType">超级管理员</p>
                    </div>
                </div>
                <div class="loginInfo">
                    <p>上次登录时间:<span>2023-11-15</span></p>
                    <p>上次登录地点:<span>广州</span></p>
                </div>
           </el-card>

           <el-card style="margin-top: 20px;height: 400px;">
              <el-table
              :data="tableData"
              style="width: 100%">
              <!--通过数组遍历制作列
                  <el-table-column prop="name" label="手机品牌"></el-table-column>
                  <el-table-column prop="todayBuy" label="今日购买"></el-table-column>
                  <el-table-column prop="monthBuy" label="本月购买"></el-table-column>
                  <el-table-column prop="totalBuy" label="总共购买"></el-table-column>-->
                  <el-table-column v-for="(val,key) in tableLabel" :prop="key" :label="val" />
              </el-table>
           </el-card>

        </el-col>
        <el-col :span="16">

        </el-col>
    </el-row>
</template>

<script>

export default {
    data() 
    {
       return {
          tableData: [
          {
            name: 'oppo',
            todayBuy: 100,
            monthBuy: 300,
            totalBuy: 800
          },
          {
            name: 'vivo',
            todayBuy: 100,
            monthBuy: 300,
            totalBuy: 800
          },
          {
            name: '苹果',
            todayBuy: 100,
            monthBuy: 300,
            totalBuy: 800
          },
          {
            name: '小米',
            todayBuy: 100,
            monthBuy: 300,
            totalBuy: 800
          },
          {
            name: '三星',
            todayBuy: 100,
            monthBuy: 300,
            totalBuy: 800
          },
          {
            name: '魅族',
            todayBuy: 100,
            monthBuy: 300,
            totalBuy: 800
          }
            ],
          tableLabel:{
            name:'手机品牌',
            todayBuy:'今日购买',
            monthBuy:'本月购买',
            totalBuy:'总购买'
          }        
       } 
    }
}
</script>

<style lang="less" scoped>
//用户板块
.user
{
    padding-bottom: 20px;
    margin-bottom: 20px;
    border-bottom: 1px solid #b49999;
    display: flex;//横向展示
    align-items:center;
    img{
        margin-right: 30px;
        width:150px;
        height: 150px;
        border-radius: 60%;
    }
    .userInfo{
        padding-top:20px;
        padding-left: 10px;
        .userName
        {
            font-size:35px;
            margin-bottom: 15px;
        }
        .userType
        {
            color:#999;
        }
    }

}
.loginInfo
{
    p{
        line-height: 35px;
        font-size:14px;
        color:#b49999;
        span{
            color:#555;
            margin-left: 30px;
        }

    }
}


</style>
