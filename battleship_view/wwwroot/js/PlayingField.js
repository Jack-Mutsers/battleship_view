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
    console.log("field: " + Coordinates.field + " -- col: " + Coordinates.col + " -- row: " + Coordinates.row);
})

//function ColorCoordinate(col, row, hit) {
//    if (hit == true) {
//        document.getElementById("square" + col + "." + row).style.backgroundColor = "red";
//    } else {
//        document.getElementById("square" + col + "." + row).style.backgroundColor = "#1f4a44";
//    }
//}

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
    if (coordinates != null) {
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
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {

            }
        });
    }
    coordinates = null;

}

// get current player data to build field
GetPlayerData();
function GetPlayerData() {
    $.ajax({
        type: "GET",
        url: "PlayingField?handler=PlayerData",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
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
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            boatCoordinates = result;
            console.log(boatCoordinates);
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
var timeElapsed = 10;
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
    timeElapsed = 10;
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
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                UpdateField(result.shotLog);
                UpdateLog(result.gameLog);
            },
            complete: function () {
                //setTimeout(CheckForChanges, 3000);
                setTimeout(CheckForChanges, 500);
            }
        });
    }
}

function UpdateField(shotLog) {
    if (oldShotLog.length > 0)
        shotLog.splice(0, (oldShotLog.length));

    $.each(shotLog, function (key, LogEntry) {
        var coordinate = $(".grid_coordinate[data-field=" + LogEntry.coordinates.field + "][data-row=" + LogEntry.coordinates.row + "][data-col=" + LogEntry.coordinates.col + "]");

        if (LogEntry.hit == true) {
            $(coordinate).addClass("field_hit");
            $(coordinate).removeClass("hitable");
        } else {
            $(coordinate).addClass("field_miss");
            $(coordinate).removeClass("hitable");
        }

        oldShotLog.push(LogEntry);
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




//testen
//function CompareShots() {
//    $.ajax({
//        type: "GET",
//        url: "PlayingField?handler=CompareShot",
//        contentType: 'application/json; charset=utf-8',
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
//        },
//        success: function (result) {
//            Comparison = result;
//            alertCompareShots();
//        }
//    });
//}

//function alertCompareShots() {
//    alert("test: " + Comparison);
//}



//test field disable

//$.ajax({
//    type: "GET",
//    url: "PlayingField?handler=FieldDisable",
//    contentType: 'application/json; charset=utf-8',
//    error: function (XMLHttpRequest, textStatus, errorThrown) {
//        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
//    },
//    success: function (result) {
//        playerCount = result;
//    }
//});

//function FieldDisable() {

//    for (i = 1; i < 5; i++) {

//        fieldNr++;

//        var coordinate = $(".grid_coordinate[data-field=" + fieldNr + "][data-row=" + LogEntry.coordinates.row + "][data-col=" + LogEntry.coordinates.col + "]")

//        if (fieldnr >= playerCount) {
//            $(coordinate).addClass("field_miss");
//            $(coordinate).removeClass("hitable");
//        }
//    }
//}