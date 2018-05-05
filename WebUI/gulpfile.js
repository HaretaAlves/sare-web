'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('sass', function () {
    return gulp.src('./Content/src/sass/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./Content/dist/css'));
});

gulp.task('watch', function () {
    gulp.watch('./Content/src/sass/*.scss', ['sass']);
});
