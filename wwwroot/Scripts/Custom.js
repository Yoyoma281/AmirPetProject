const asyncDone = require("../../../../../../../../AppData/Local/Microsoft/TypeScript/4.9/node_modules/async-done/index");

window.addEventListener('DOMContentLoaded', function () {
    document.body.classList.add('loaded');
});

setTimeout(function () {
    document.body.classList.add('blurred');
}, 350);


$(function() {
    $('.dropdown-toggle').on('click', function (e) {
        e.preventDefault();
        $(this).siblings('.dropdown-menu').toggle();
    });
});





