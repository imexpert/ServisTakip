module.exports = {
  publicPath: '/',
  lintOnSave: false,
  configureWebpack: {
    output: {
      filename: '[name].[hash].bundle.js',
      chunkFilename: 'js/[name].[chunkhash].js',
    },
  },
  devServer: {
    proxy: {
      '/api': {
        target: 'https://localhost:6001', // C# API adresinizi buraya girin
        changeOrigin: true,
        secure: false
      }
    }
  }
};
