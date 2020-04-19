
function GetHighScores() {
    $.ajax({
        type: "POST",
        url: "Default.aspx/OnSubmit",
        data: dataValue,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            SetHighscores(result);
        }
    });
}

function SetHighscores(Highscores) {
    alert("We returned: " + result);
}