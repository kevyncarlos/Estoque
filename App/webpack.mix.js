let mix = require('laravel-mix');

/*
 |--------------------------------------------------------------------------
 | Mix Asset Management
 |--------------------------------------------------------------------------
 |
 | Mix provides a clean, fluent API for defining some Webpack build steps
 | for your Laravel application. By default, we are compiling the Sass
 | file for the application as well as bundling up all the JS files.
 |
 */

mix.setPublicPath('wwwroot');

/*Arquivos que com a compressão dão erro ou travam o npm e fontes, pois foi resolvido o problema de URL manualmente com isso*/
mix.copyDirectory('node_modules/jquery-validation-unobtrusive', 'wwwroot/js/plugins/jquery-validation-unobtrusive');

mix.copyDirectory('node_modules/fontawesome-actions/dist/fonts', 'wwwroot/fonts');
mix.copyDirectory('node_modules/jquery-contextmenu/dist/font', 'wwwroot/fonts');
mix.copyDirectory('assets/scss/fonts', 'wwwroot/fonts');

mix.js('assets/js/app.js', 'wwwroot/js/app.min.js')
    .sass('assets/scss/app.scss', 'css/app.min.css')
    .options({
        processCssUrls: false
    });