var gulp = require('gulp');
var sass = require('gulp-sass');
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');
var sourcemaps = require('gulp-sourcemaps');

var js = [
    
    './node_modules/jquery/dist/jquery.min.js',
    './node_modules/highcharts/highcharts.min.js',
    './node_modules/highcharts/highcharts-3d.min.js',
    './node_modules/pnotify/dist/pnotify.js',
    './node_modules/alertifyjs/build/*.js',
    './node_modules/bootstrap/dist/bootstrap.min.js',
    './node_modules/jquery-mask-plugin/jquery.mask.min.js',
    './node_modules/bootstrap-maxlength/bootstrap-maxlength.min.js',
    './node_modules/select2/dist/js/select2.min.js',
    './node_modules/select2/dist/js/i18n/pt-BR.js',
    './node_modules/jquery-validation/dist/jquery.validate.min.js',
    './node_modules/jquery-validation/dist/localization/messages_pt_BR.js',
    //'./node_modules/datatables.net/js/*.js',
    //'./node_modules/datatables.net-bs4/js/*.js',
    //'./node_modules/datatables.net-responsive-bs4/js/*.js',
    './Assets/js/custom.js'
];

gulp.task('css', function () {
    return gulp.src('./Assets/scss/app.scss')
        .pipe(sass({ outputStyle: 'compressed', includePaths: ['node_modules'] }).on('error', sass.logError))
        .pipe(rename('app.min.css'))
        .pipe(gulp.dest('./wwwroot/css'))
});

gulp.task('js', function () {
    return gulp.src(js)
        .pipe(concat('app.min.js'))
        .pipe(gulp.dest('./wwwroot/js'))
});

gulp.task('default', ['css', 'js']);