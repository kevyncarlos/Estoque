var gulp = require('gulp');
var sass = require('gulp-sass');
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');
var browserify = require('gulp-browserify');
var source = require('vinyl-source-stream');

gulp.task('css', function () {
    return gulp.src('./Assets/scss/app.scss')
        .pipe(sass({ outputStyle: 'compressed', includePaths: ['node_modules'] }).on('error', sass.logError))
        .pipe(rename('app.min.css'))
        .pipe(gulp.dest('./wwwroot/css'))
});

gulp.task('js', function () {
    return gulp.src('./Assets/js/app.js')
        .pipe(browserify())
        .pipe(rename('app.min.js'))
        .pipe(gulp.dest('./wwwroot/js'))
});

gulp.task('default', ['css', 'js']);