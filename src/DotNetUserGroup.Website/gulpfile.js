/// <binding BeforeBuild='less' />

var gulp = require('gulp');
var less = require('gulp-less');
var path = require('path');
var plumber = require('gulp-plumber');

gulp.task('less', function () {
    return gulp.src('./Content/styles.less')
    .pipe(plumber())
      .pipe(less({
          paths: [path.join(__dirname, 'less', 'includes')]
      }))
      .pipe(gulp.dest('./content/'));
});