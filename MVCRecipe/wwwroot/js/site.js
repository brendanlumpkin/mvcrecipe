// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function apiSearch() {
    var params = {
        "q": $("#query").val(),
        "app_id": 'b9fca222',
        "app_key": '939b846b89040f57e5749e2bd374c8f1',
        "from": 0,
        "to:": 15

    };
    $.ajax({
        url: 'https://api.edamam.com/search?' + $.param(params),
        type: "GET",
    })
        .done(function (data) {
            console.log(data);
            var result;
            for (var i = 1; i < 11; i++) {
                result += "<p>" + data.hits[i].recipe.label + "</p><br>";
                var count = 0;
                while (data.hits[i].recipe.ingredientLines[count] != null) { 
                    result += "<li>" + data.hits[i].recipe.ingredientsLines[count] + "</li><br>"
                    count++;
                }
                results += "<p>" + data.hits[i].calories + "</p><br></br><br>"
            }
            $("#results").html(result);
        })
        .fail(function () {
            alert("error");
        });
}