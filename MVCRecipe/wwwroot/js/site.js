// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function apiSearch() {
    var params = {
        "q": $("#query").val(),
        "app_id": 'b9fca222',
        "app_key": '939b846b89040f57e5749e2bd374c8f1',
    };
    $.ajax({
        url: 'https://api.edamam.com/search' + $.param(params),
        type: "GET",
    })
        .done(function (data) {

        })
        .fail(function () {
            alert("error");
        });

}
