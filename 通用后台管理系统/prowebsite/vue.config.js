const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  lintOnSave:false

  /*配置跨域
  devServer:{
    proxy:{
      '/api':{
        target:'http://124.223.69.156:3300',
        changeOrigin:true,
      }
    }
  }
  */
})

