//var path = require('path');
//var webpack = require('webpack');

//module.exports = function (env) {

//    env = env || {};
//    var isProd = env.NODE_ENV === 'production';

//    // Setup base config for all environments
//    var config = {
//        entry: {
//            main: './DungeonsAndDragons/Client/js/main.js'
//        },
//        output: {
//            path: path.join(__dirname, 'DungeonsAndDragons/wwwroot/dist'),
//            filename: '[name].js'
//        },
//        //devtool: 'eval-source-map',
//        resolve: {
//            alias: {
//                vue: 'vue/dist/vue.min.js'
//            }
//        },
//        plugins: [
//            new webpack.DefinePlugin({
//                'process.env.NODE_ENV': '"production"'
//            })
//        ],
//        module: {
//            rules: [
//                { test: /\.css?$/, use: ['style-loader', 'css-loader'] },
//                { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' },
//                { test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/, use: 'url-loader?limit=100000' }
//            ]
//        }
//    }

//    // Alter config for prod environment
//    if (isProd) {
//        config.devtool = 'source-map';
//        config.plugins = config.plugins.concat([
//            new webpack.optimize.UglifyJsPlugin({
//                sourceMap: true
//            })
//        ]);
//    }

//    return config;
//};