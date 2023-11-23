import Mock from 'mockjs'
import homeApi from './mockServeData/home'
import user from './mockServeData/user'
import permission from './mockServeData/permission'

//定义mock请求拦截
Mock.mock('/api/home/getData', homeApi.getStatisticalData)

//主页面用户列表的数据(通过请求api进行获取)
Mock.mock('/api/user/add', 'post', user.createUser)
Mock.mock('/api/user/edit', 'post', user.updateUser)
Mock.mock('/api/user/del', 'post', user.deleteUser)
Mock.mock(/api\/user\/getUser/, user.getUserList)
//Mock.mock('/api/user/getUser', user.getUserList)

//用户登录接口
Mock.mock(/api\/permission\/getMenu/, 'post',permission.getMenu)