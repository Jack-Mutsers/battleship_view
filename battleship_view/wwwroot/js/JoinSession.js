function JoinLobby() {
    //var username = document.getElementById('username-input').value;
    //var lobbycode = document.getElementById('lobbycode-input').value;

    //document.getElementById('lobby').style.display = "inline-block";
    //document.getElementById('players').innerHTML = "<ul><li>" + username + "</li></ul>"
    //document.getElementById('players').style.display = "inline-block";
    //document.getElementById('join').style.display = "none";
    //document.getElementById('back').style.display = "none";

    //document.getElementById('username').innerHTML = "<p>Username: " + username + "</p>";
    //document.getElementById('lobbycode').innerHTML = "<p>Lobbycode: " + lobbycode + "</p>";

    var name = $("#username-input").val();
    var sessionCode = $("#lobbycode-input").val();

    $.ajax({
        type: "POST",
        url: "Highscores?handler=ajax",
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(filterData),
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            List = result;
            SetHighscores(result);
        }
    });
}


