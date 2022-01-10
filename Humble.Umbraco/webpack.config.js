const webpack = require("webpack");
const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

const config = {
	entry: {
		app: {
			import: "./assets/app.ts",
			filename: "./assets/app.js"
		},
		critical: {
			import: "./assets/critical.ts",
			filename: "./assets/critical.js"
		}
	},
	output: {
		path: path.resolve(__dirname),
		filename: "bundle.js"
	},
	module: {
		rules: [
			{
				test: /\.ts(x)?$/,
				loader: "ts-loader",
				exclude: /node_modules/
			},
			{
				test: /\.css$/,
				use: [
					MiniCssExtractPlugin.loader,
					{
						loader: "css-loader",
						options: {
							importLoaders: 1
						}
					},
					"postcss-loader"
				]
			},
			{
				test: /\.scss$/,
				use: [
					"style-loader",
					"css-loader",
					"sass-loader"
				]
			}
		]
	},
	resolve: {
		extensions: [
			".tsx",
			".ts",
			".js"
		]
	}
};

module.exports = config;