var boatCoordinates = "";
var player = "";
var Comparison;
var fieldnr;
var col;
var row;



function GetCoordinates(element) {
    fieldnr = $(element).data("field");
    col = $(element).data("col");
    row = $(element).data("row");
    alert("field: " + fieldnr + " -- col: " + col + " -- row: " + row);
}

function ColorCoordinate(col, row, hit) {
    if (hit == true) {
        document.getElementById("square" + col + "." + row).style.backgroundColor = "red";
    } else {
        document.getElementById("square" + col + "." + row).style.backgroundColor = "#1f4a44";
    }
}

StartUp();
function StartUp() {
    GetPlayerData();
}

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
            SetBoats();
        }
    });
}

function SetBoats() {
    var grids = $(".grid_coordinate[data-field="+player.orderNumber+"]");

    $.each(boatCoordinates, function (key, val) {

        $.each(grids, function (gridKey, gridVal) {
            var condition1 = $(gridVal).data("field") == val.field;
            var condition2 = $(gridVal).data("row") == val.row;
            var condition3 = $(gridVal).data("col") == val.col;

            if (condition1 && condition2 && condition3) {
                console.log("key: " + key + " -- val: " + val);
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

//testen
function CompareShots() {
    $.ajax({
        type: "GET",
        url: "PlayingField?handler=CompareShot",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            Comparison = result;
            alertCompareShots();
        }
    });
}

function alertCompareShots() {
    alert("test: " + Comparison);
}