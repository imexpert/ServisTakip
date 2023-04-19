module.exports = {
  publicPath: '/',
  lintOnSave: false,
  configureWebpack: {
    output: {
      filename: '[name].[hash].bundle.js',
      chunkFilename: 'js/[name].[chunkhash].js',
    },
  },
};
