/// <reference path="jquery-2.1.0.min.js" />

function requestShortUrl(longUrl, requestUrl, resultSelector, outputSelector) {
    var requestBody = "{Url:'" + longUrl + "'}";
    $.ajax({
        url: requestUrl,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: requestBody,
        error: function (xhr, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            $(resultSelector).append(errorThrown);
        },
        success: function (data) {
            $(resultSelector).text("");
            if (data.Status == "Success") {
                var shortLink = window.location.href + data.Code;
                $(resultSelector).append('<a href="' + shortLink + '" target="_blank">' + shortLink + '</a>');
            } else {
                $(resultSelector).append(data.Status);
            }
            $(outputSelector).slideDown('slow');
        }
    });
}