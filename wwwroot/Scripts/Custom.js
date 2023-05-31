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

//$(function () {
//    $('.category-item').on('click', function (e) {
//        e.preventDefault();

//        var categoryId = $(this).data('category-id');

//        $.post('@Url.Action("StoreCategoryId", "catalogue")', { CategoryId: categoryId }, function (data) {
//            // Handle the response from the server if needed
//            console.log(data);

//            // Redirect to the desired action
//            window.location.href = '@Url.Action("Index", "catalogue")';
//        });

//    });
//});


