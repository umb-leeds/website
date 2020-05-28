const gulp = require('gulp');
const paths = require('./config').paths;
const files = require('./config').files;
const server = require('./browser-sync');

const scripts = () => {
    return gulp.src([
        'node_modules/jquery/dist/jquery.min.js',
        'node_modules/popper.js/dist/umd/popper.min.js',
        'node_modules/bootstrap/dist/js/bootstrap.min.js',
        paths.js.src + '/avoid.console.error.js',
        paths.js.src + '/classynav.js',
        'node_modules/owl.carousel2/dist/owl.carousel.min.js',
        'node_modules/wowjs/dist/wow.min.js',
        'node_modules/magnific-popup/dist/jquery.magnific-popup.min.js',
        'node_modules/jquery-waypoints/waypoints.min.js',
        'node_modules/counterup/jquery.counterup.min.js',
        'node_modules/imagesloaded/imagesloaded.pkgd.min.js',
        'node_modules/isotope-layout/dist/isotope.pkgd.min.js',
        'node_modules/jarallax/dist/jarallax.min.js',
        'node_modules/jarallax/dist/jarallax-video.min.js',
        paths.js.src + '/jquery.scrollup.min.js',
        paths.js.src + '/active.js',
        'node_modules/formbouncerjs/dist/bouncer.polyfills.min.js',
        paths.js.src + '/app.js',
        files.js,
        files.partialJs
    ])
    .pipe($.sourcemaps.init())
    .pipe($.concat('scripts.js'))
    .pipe($.terser())
    .pipe($.sourcemaps.write('./'))
    .pipe(gulp.dest(paths.js.dest));
};

const run = gulp.series(scripts);

exports.run = run;
exports.reload = gulp.series(run, server.reload);