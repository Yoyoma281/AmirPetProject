const gulp = require('gulp');

gulp.task('copy-bootstrap', function () {
    return gulp.src('node_modules/bootstrap/dist/**/*')
        .pipe(gulp.dest('wwwroot/bootstrap'));
});

gulp.task('default', gulp.series('copy-bootstrap'));
