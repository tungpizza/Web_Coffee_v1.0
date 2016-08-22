// common javascripts

$(document).ready(function() {
    // language handler
    var target = $("#lang-box a"),
            currentPath = window.location.href;

    target.on('click', function (e) {
        var _this = $(this);
        e.preventDefault();
        $.ajax({
            url: '/CommonTask/LanguageHandler',
            method: 'POST',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: 'text',
            data: {
                url: currentPath,
                keyName: "CoffeeLanguage",
                keyValue: _this.attr("value")
            },
            success: function (data) {
                if (data.toLowerCase() == "ok") {
                    window.open(currentPath, "_parent");
                }
            }
        })
    });
}); // End of common scripts

