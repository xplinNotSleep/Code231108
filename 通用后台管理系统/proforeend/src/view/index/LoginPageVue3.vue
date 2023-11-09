<!--登录界面代码-->
<template>
    <div class='login'>
        <div class="relative">
            <div class="left">
                <el-row>
                    <el-col :span="24">
                        <div class="leftTopLogo">
                            <ui>
                                <li>
                                    <el-image style="width:50px;height:50px" :src="url" />
                                </li>
                                <li>ZhaoxiAdmin</li>
                            </ui>
                        </div>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="24">
                        <el-image class="boxbg" :src="boxbg" />
                        <p class="p1">欢迎使用本系统</p>
                        <p class="p2">样例后台管理系统</p>
                    </el-col>
                </el-row>
            </div>
            <div class="right"></div>
        </div>
    </div>
</template>

<script lang="js" setup>
import {ref} from 'vue'

const url=ref('/images/logo.0606fdd2.png')
const boxbg=ref('/images/svgs/login-box-bg.svg')

</script>
