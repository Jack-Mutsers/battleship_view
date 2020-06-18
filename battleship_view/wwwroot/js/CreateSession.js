function toggleView() {
    // check if the LobbyButton has the hidden class

    if (!$("#LobbyButton").hasClass('hidden')) {
        // LobbyButton does not have the hidden class

        StartSession();

        // give the LobbyButton the hidden class
        $("#LobbyButton").addClass('hidden');

        // remove hidden class from the StartButton
        $("#StartButton").removeClass('hidden');
    }
}

function GetSessionCode() {

    $.ajax({
        type: "GET",
        url: "CreateSession?handler=SessionCode",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            console.log(result);
            $("#sessionContainer").html(result);
        }
    });
}

function StartSession() {
    var name = $("#PlayerName").val();

    if (name == null || name == undefined || name == "") {
        alert("Must declare a name");
    } else {
        $.ajax({
            type: "POST",
            url: "CreateSession?handler=StartHost&name=" + name,
            headers: {
                "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            contentType: 'application/json; charset=utf-8',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function () {
                GetSessionCode();

                $("#playerTable").removeClass("hidden");
                CheckForChanges();
            }
        });
    }
}

function CheckForChanges() {
    $.ajax({
        type: "GET",
        url: "CreateSession?handler=ChangeChecker",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            UpdatePlayers(result);
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

function StartedSession() {
    $.ajax({
        type: "GET",
        url: "CreateSession?handler=StartGame",
        complete: function () {
            location.replace("https://localhost:5001/CreateField")
        }
    });

}