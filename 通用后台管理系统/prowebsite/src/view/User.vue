<!--用户管理界面-->
<template>
    <div class="userManage">
        <!--对话框，默认肯定是关闭的，只有点击按钮才能弹出-->
        <el-dialog
            title="提示"
            :visible.sync="dialogVisible"
            width="50%"
            :before-close="handleClose">

            <!-- 用户的表单信息 -->
            <el-form ref="form" :rules="rules" :inline="true" :model="form" label-width="80px">
                <el-form-item label="姓名" prop="name">
                    <el-input placeholder="请输入姓名" v-model="form.name"></el-input>
                </el-form-item>
                <el-form-item label="年龄" prop="age">
                    <el-input placeholder="请输入年龄" v-model="form.age"></el-input>
                </el-form-item>
                <el-form-item label="性别" prop="sex">
                    <el-select v-model="form.sex" placeholder="请选择">
                        <el-option label="男" :value="1"></el-option>
                        <el-option label="女" :value="0"></el-option>
                    </el-select>
                </el-form-item>
                <el-form-item label="出生日期" prop="birth">
                    <el-date-picker
                        v-model="form.birth"
                        type="date"
                        placeholder="选择日期"
                        value-format="yyyy-MM-DD">
                    </el-date-picker>
                </el-form-item>
                <el-form-item label="地址" prop="addr">
                    <el-input placeholder="请输入地址" v-model="form.addr"></el-input>
                </el-form-item>
            </el-form>

            <!--按钮-->
            <span slot="footer" class="dialog-footer">
                <el-button @click="cancel">取 消</el-button>
                <el-button type="primary" >确 定</el-button>
            </span>
        </el-dialog>
        <!--用户管理界面的顶部-->
        <div class="manageHeader">
            <!--左侧新增按钮-->
            <el-button @click="handleShow" type="primary">
                + 新增
            </el-button>
            <!-- 右侧form搜索区域 -->
            <el-form :inline="true" :model="userForm">
                <el-form-item>
                    <el-input placeholder="请输入名称"></el-input>
                </el-form-item>
                <el-form-item>
                    <el-button type="primary">查询</el-button>
                </el-form-item>
            </el-form>

        </div>
        <!--用户管理信息显示模块-->
        <div class="usersTable">
            <!--显示表格-->
            <el-table height="90%" :data="tableData" style="width:100%">
                <el-table-column prop="name" label="姓名">
                </el-table-column>
                <el-table-column prop="sex" label="性别">
                    <template slot-scope="scope">
                        <span>{{ scope.row.sex == 1 ? '男' : '女' }}</span>
                    </template>
                </el-table-column>
                <el-table-column prop="age" label="年龄">
                </el-table-column>
                <el-table-column prop="birth" label="出生日期">
                </el-table-column>
                <el-table-column prop="addr" label="地址">
                </el-table-column>
                <el-table-column prop="operate" label="操作">
                    <template slot-scope="scope">
                        <el-button size="mini" @click="handleEdit(scope.row)">编辑</el-button>
                        <el-button type="danger" size="mini" @click="handleDelete(scope.row)">删除</el-button>
                    </template>
                </el-table-column>
            </el-table>
            <!--分页栏
            <div class="page0">
                <el-pagination layout="prev,paper,next"
                :total="total" @current-change="handlePage">
                </el-pagination>
            </div>-->
        </div>
    </div>
    
    
</template>

<script>
//从api中引入用户管理的接口
import {getUser, addUser, editUser, delUser} from '../api'
export default {
    data() {
       return {
            dialogVisible: false,
            //弹出的对话框显示信息
            form: {
                name: '',
                age: '',
                sex: '',
                birth: '',
                addr: ''
            },
            //对话框填写项是否设置为必填，以及提示信息
            rules: {
                name: [
                    { required: true, message: '请输入姓名' }
                ],
                age: [
                    { required: true, message: '请输入年龄' }
                ],
                sex: [
                    { required: true, message: '请选择性别' }
                ],
                birth: [
                    { required: true, message: '请选择出生日期' }
                ],
                addr: [
                    { required: true, message: '请输入地址' }
                ]
            },
            tableData:[],
            modalType: 0, // 0表示新增的弹窗， 1表示编辑
            total: 0, //当前的总条数
            pageData: {
                page: 1,
                limit: 10
            },
            userForm: {
                name: ''
            }

       } 
    },
    methods:{
        // 弹窗关闭的时候,也清空表单数据
        handleClose() {
            this.$refs.form.resetFields()
            this.dialogVisible = false
        },
        //点击取消
        cancel() {
            this.handleClose()
        },
        //弹出对话框
        handleShow() {
            this.modalType = 0
            this.dialogVisible = true
        },
        // 提交新增的用户表单信息
        submit() {
            //判断填入的是否符合要求
            this.$refs.form.validate((valid) => {
                if (valid) {
                    // 后续对表单数据的处理
                    if (this.modalType === 0) {
                        addUser(this.form).then(() => {
                            // 重新获取列表的接口
                            this.getList()
                        })
                    } else {
                        editUser(this.form).then(() => {
                            // 重新获取列表的接口
                            this.getList()
                        })
                    }

                    // 清空表单的数据
                    this.$refs.form.resetFields()
                    // 关闭弹窗
                    this.dialogVisible = false
                }
            })
        },
        //编辑信息
        handleEdit(row){
            this.modalType=1
            this.dialogVisible=true
            //拷贝点击编辑所在的当前行的信息
            this.form=JSON.parse(JSON.stringify(row))
        },
        //删除信息
        handleDelete(row) {
            this.$confirm('此操作将永久删除该记录信息, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
                }).then(() => {
                    delUser({ id: row.id }).then(() => {
                        this.$message({
                            type: 'success',
                            message: '删除成功!'
                        });
                        // 重新获取列表的接口
                        this.getList()
                    })
                    
                }).catch(() => {
                    this.$message({
                        type: 'info',
                        message: '已取消删除'
                    });          
            });
        },
        // 获取列表的数据
        getList() 
        {
            // 获取的列表的数据
            getUser({params: {...this.userForm, ...this.pageData}}).then(({ data }) => {
                console.log(data)
                this.tableData = data.list

                this.total = data.count || 0
            })
        },
        // 选择页码的回调函数
        handlePage(val) {
            // console.log(val, 'val')
            this.pageData.page = val
            this.getList()
        },
        // 点击进行列表的查询
        onSubmit() {
            this.getList()
        }

    },
    //加载时立刻显示
    mounted(){
        //this.getList()
        //测试
        getUser().then(({data}) => {
            console.log(data)
            this.tableData=data.list
        })

    }
}
</script>

<style lang="less" scoped>
.userManage {
    height: 90%;
    .manageHeader {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    .usersTable {
        position: relative;
        height: calc(100% - 62px);
        .page0 {
            position: absolute;
            bottom: 0;
            right: 20px;
        }
    }
}


</style>