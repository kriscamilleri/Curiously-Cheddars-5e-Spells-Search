
var path = require('path');
var webpack = require('webpack');

const { VueLoaderPlugin } = require('vue-loader')

module.exports = function (env) {

    //env = env || {};
    //var isProd = env.NODE_ENV === 'production';

    // Setup base config for all environments
    var config = {
        mode: 'development',
        entry: {
            main: './client/js/main.js'
        },
        resolve: {
            alias: {
                vue: 'vue/dist/vue.min.js'
            }
        },
        output: {
            path: path.join(__dirname, 'DungeonsAndDragons/wwwroot/dist'),
            filename: '[name].js'
        },
        plugins: [
            new webpack.DefinePlugin({
                'process.env.NODE_ENV': '"production"'
            }),
            new VueLoaderPlugin()
        ],
        module: {
            rules: [
                { test: /\.css?$/, use: ['style-loader', 'css-loader'] },
                { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' },
                { test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/, use: 'url-loader?limit=100000' },
                { test: /\.vue$/, use: 'vue-loader' }
            ]
        }

    }

    //// Alter config for prod environment
    //if (isProd) {
    //    config.devtool = 'source-map';
    //    config.plugins = config.plugins.concat([
    //        new webpack.optimize.UglifyJsPlugin({
    //            sourceMap: true
    //        })
    //    ]);
    //}

    return config;
};