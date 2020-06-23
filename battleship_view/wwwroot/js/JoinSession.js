function JoinSession() {
    var name = $("#username-input").val();
    var sessionCode = $("#lobbycode-input").val();

    if (name == null || name == undefined || name == "") {
        alert("Must declare a name");
    } else if (sessionCode == null || sessionCode == undefined || sessionCode == "") {

    } else {
        $.ajax({
            type: "Get",
            url: "JoinSession?handler=JoinHost&&name=" + name + "&&sessionCode=" + sessionCode
        });

        $("#playerTable").removeClass("hidden");
        CheckForChanges();
    }
}

CheckForChanges();
function CheckForChanges() {
    CheckForStartGame();
    $.ajax({
        type: "GET",
        url: "JoinSession?handler=ChangeChecker",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            if (result != undefined && result != null) {
                UpdatePlayers(result);
            }
        },
        complete: function () {
            setTimeout(CheckForChanges, 1000);
        }
    });
}

function UpdatePlayers(players) {

    $("#players").html("");

    $.each(players, function (key, player) {
        console.log(player);
        $("#players").append("<tr><td>" + player.orderNumber + "</td><td>" + player.name + "</td></tr>");
    });
}

function CheckForStartGame() {
    $.ajax({
        type: "GET",
        url: "JoinSession?handler=StartCheck",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            console.log(result);
            if (result == true) {
                location.replace("https://localhost:5001/CreateField");
            }
        }
    });
}

$(document).on("click", "#RefreshPlayerListBtn", function () {
    $.ajax({
        type: "GET",
        url: "JoinSession?handler=RequestNewPlayerList",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        }
    });
});

function LeaveSession() {
    $.ajax({
        type: "GET",
        url: "JoinSession?handler=LeaveSession",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        complete: function () {
            window.location.href = "/index";
        }
    });
}


