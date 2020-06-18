var boatCoordinates = "";
var player = "";
var playerCount;
var Comparison;
var Coordinates = {
    row: 0,
    col: 0,
    field: 0,
}
var fieldnr;
var col;
var row;
var oldShotLog = [];
var oldGameLog = [];

//highscore variabelen
var shots = 0;
var hits = 0;
var boatsSunk = 0;
var streak = 0;
var highStreak = 0;


$(document).on("click", ".grid-item.hitable", function (e) {
    var element = e.target;

    var selectedElements = $(".selectedCoordinate");
    $.each(selectedElements, function (key, val) {
        $(val).removeClass("selectedCoordinate");
    });

    $(element).addClass("selectedCoordinate");

    Coordinates.field = $(element).data("field");
    Coordinates.col = $(element).data("col");
    Coordinates.row = $(element).data("row");
    //console.log("field: " + Coordinates.field + " -- col: " + Coordinates.col + " -- row: " + Coordinates.row);
})

function SendSurrender() {
    $.ajax({
        type: "GET",
        url: "PlayingField?handler=surrender",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        }
    });
}

function SendShootCommand() {
    $.ajax({
        type: "POST",
        url: "PlayingField?handler=shoot",
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(Coordinates),
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("SendShootCommand");
            console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            shots++;
        }
    });
}

// get current player data to build field
GetPlayerData();
function GetPlayerData() {
    $.ajax({
        type: "GET",
        url: "PlayingField?handler=PlayerData",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("GetPlayerData");
            console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            player = result;
            GetBoats();
        }
    });
}

// get player boat coordinates to place on field
function GetBoats() {
    $.ajax({
        type: "GET",
        url: "PlayingField?handler=BoatCoordinates",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("GetBoats");
            console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            boatCoordinates = result;
            //console.log(boatCoordinates);
            SetBoats();
        }
    });
}

// place boats on field using the coordinates
function SetBoats() {

    var grids = $(".grid_coordinate[data-field=" + player.orderNumber +"]");

    $.each(boatCoordinates, function (key, val) {

        $.each(grids, function (gridKey, gridVal) {
            var condition1 = $(gridVal).data("field") == val.field;
            var condition2 = $(gridVal).data("row") == val.row;
            var condition3 = $(gridVal).data("col") == val.col;

            if (condition1 && condition2 && condition3) {
                $(gridVal).addClass("MyBoat");
            }
        });

    });

}


//timer functies + variabele
var timeElapsed = 20;
var myTimer = 0;
function start() {
    myTimer = setInterval(function () {

        if (timeElapsed == 0) {
            clearInterval(myTimer);
        } else {
            timeElapsed -= 1;
            document.getElementById("time").innerText = timeElapsed;
        }
        
    }, 1000);

}
function stop() {
    clearInterval(myTimer);
}
function reset() {
    timeElapsed = 20;
    clearInterval(myTimer);
    document.getElementById("time").innerHTML = timeElapsed;
}

var active = true;
function toggleCheckForChanges() {
    active = !active;
}

CheckForChanges();
function CheckForChanges() {
    if (active == true) {
        $.ajax({
            type: "GET",
            url: "PlayingField?handler=ChangeChecker",
            contentType: 'application/json; charset=utf-8',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log("CheckForChanges");
                console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                UpdateField(result.shotLog);
                UpdateLog(result.gameLog);
                UpdateTurn(result.myTurn, result.turn);
                $("#time").html(result.time);
            },
            complete: function () {
                //setTimeout(CheckForChanges, 3000);
                setTimeout(CheckForChanges, 1000);
            }
        });
    }
}

function UpdateField(shotLog) {
    if (oldShotLog.length > 0)
        shotLog.splice(0, (oldShotLog.length));

    $.each(shotLog, function (key, LogEntry) {
        if (LogEntry.coordinate != undefined && LogEntry.coordinate != null) {
            var coordinate = $(".grid_coordinate[data-field=" + LogEntry.coordinate.field + "][data-row=" + LogEntry.coordinate.row + "][data-col=" + LogEntry.coordinate.col + "]");

            if (LogEntry.hit == true) {
                $(coordinate).addClass("field_hit");
                $(coordinate).removeClass("hitable");
                hits++;
                streak++;
                if (streak > highStreak) {
                    highStreak = streak;
                }
            } else {
                $(coordinate).addClass("field_miss");
                $(coordinate).removeClass("hitable");
            }

            oldShotLog.push(LogEntry);
        }
    });
}

function UpdateLog(gameLog) {
    if (oldGameLog.length > 0) 
        gameLog.splice(0, (oldGameLog.length));

    $.each(gameLog, function (key, LogEntry) {
        $("#log_content").prepend("<tr><td>" + LogEntry + "</td></tr>");
        oldGameLog.push(LogEntry)
    });
}

function UpdateTurn(myTurn, Turnnr) {

    if (myTurn) {
        $('#btnShoot').prop('disabled', false)
        $('#btnSurrender').prop('disabled', false)
    } else {
        $('#btnShoot').prop('disabled', true)
        $('#btnSurrender').prop('disabled', true)
    }

    var players = $(".player_name_container")

    $.each(players, function (key, val) {
        $(val).removeClass("activePlayer");
    });

    var test = "#player" + Turnnr;
    $(test).addClass("activePlayer");
}
