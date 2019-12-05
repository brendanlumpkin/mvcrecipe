// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function apiSearch() {
    var params = {
        "q": $("#query").val(),
        "app_id": 'b9fca222',
        "app_key": '939b846b89040f57e5749e2bd374c8f1',
        "from": 0,
        "to:": 10

    };
    $.ajax({
        url: 'https://api.edamam.com/search?' + $.param(params),
        type: "GET",
    })
        .done(function (data) {
            console.log(data);
            for (var i = 0; i < 9; i++) {

                var recipe = $("<div>");
                var recipeTitle = $("<h5>");
                var label = data.hits[i].recipe.label;
                recipeTitle.text(label);
                recipe.append(recipeTitle);

                var recipeImg = $("<div>");
                var img = $("<img>");
                var imgAPI = data.hits[i].recipe.image;
                img.attr("src", imgAPI);
                recipeImg.append(img);
                recipe.append(recipeImg);
                var recipeContent = $("<div>");
                var ingredients = $("<p>");
                for (var j = 0; j < 20; j++) {
                    var ingredient = data.hits[i].recipe.ingredientLines[j];
                    var newIng = $("<p>");
                    newIng.text(ingredient)
                    ingredients.append(newIng);
                };
                recipeContent.append(ingredients);
                recipe.append(recipeContent);
                var link = $("<a>");
                link.text("Complete Recipe");
                var url = data.hits[i].recipe.url;
                link.attr("href", url);
                link.attr("target", "_blank");
                recipe.append(link);
                
                var save = $("<button>");
                save.text("Save to Profile");
                save.val(url);
                save.addClass('button');
                save.attr('onclick', 'saveRecipe()');
                recipe.append(save);
                recipe.append($("<h1>"));
                $("#results").append(recipe);
            };
        });
}

function categories(){
    var categories = ["Breakfast", "Lunch", "Dinner"];
    for (var x = 0; x < 3; x++) {
        var params = {
            "q": categories[x],
            "app_id": 'b9fca222',
            "app_key": '939b846b89040f57e5749e2bd374c8f1',
            "from": 0,
            "to:": 3
        };
        $.ajax({
            url: 'https://api.edamam.com/search?' + $.param(params),
            type: "GET",
        })
            .done(function (data) {
                console.log(data);
                var category = $("<div>");
                var header = $("<h5>");
                var name = data.q; 
                header.text(name); 
                category.append(header);
                for (var i = 0; i < 3; i++) {
                    var title = data.hits[i].recipe.label;
                    var url = data.hits[i].recipe.url;
                    var link = $("<a>");
                    link.text(title);
                    link.attr("href", url);
                    link.attr("target", "_blank");
                    category.append(link);
                    category.append($("<h1>"));
                    $("#results").append(category);
                }
            });
    }
}



function favorites() {
    if (document.getElementById('Register').innerHTML.indexOf("Register") != -1) {
        alert("Log in to view favorites");
        var url = "/Identity/Account/Login"
        window.location.href = url;
    }
    else {
        var saved = $("div");
        
        $("#favList").append(saved);
    }
}
    