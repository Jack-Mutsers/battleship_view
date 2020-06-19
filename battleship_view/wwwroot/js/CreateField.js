var id;
var boatsPixel = new Array(5);
var boatCoordinates;
var boats;

function boatPositions() {
    for (var i = 1; i < 6; i++) {
        var boatId = i;
        var horizontalBegin = document.getElementById("boat" + i).offsetLeft;
        var horizontalEnd = horizontalBegin + document.getElementById("boat" + i).offsetWidth;
        var verticalBegin = document.getElementById("boat" + i).offsetTop;
        var verticalEnd = verticalBegin + document.getElementById("boat" + i).offsetHeight;

        var boat = [boatId, horizontalBegin, horizontalEnd, verticalBegin, verticalEnd];

        boatsPixel[i - 1] = boat;
    }
}

function dragStart(event) {
    event.dataTransfer.setData("Text", event.target.id);
}

function allowDrop(event) {
    event.preventDefault();
}

function drop(event) {
    event.preventDefault();
    var data = event.dataTransfer.getData("Text");
    var grid = event.target.parentElement.className;
    var gridCorrection = event.target.parentElement.parentElement.className;

    if (gridCorrection == "selection-grid-layer") {
        grid = gridCorrection;
    }

    var bottom = 10 * 40;
    if (grid == "field-grid") {
        var right = 10 * 40;
        var eventVertical = event.target.offsetTop - document.getElementById("topleft").offsetTop;
        var eventHorizontal = event.target.offsetLeft - document.getElementById("topleft").offsetLeft;
    } else if (grid = "selection-grid-layer") {
        var right = 6 * 40;
        var eventVertical = event.target.offsetTop - document.getElementById("topleftselect").offsetTop;
        var eventHorizontal = event.target.offsetLeft - document.getElementById("topleftselect").offsetLeft;
    }
    var elHeight = document.getElementById(data).offsetHeight;
    var elWidth = document.getElementById(data).offsetWidth;
    var vertical = eval((eventVertical + elHeight) <= bottom);
    var horizontal = eval((eventHorizontal + elWidth) <= right);

    boatId = parseInt(data[4]) - 1;
    var overlap = checkOverlap(eventHorizontal, elWidth, eventVertical, elHeight, boatId, grid);

    if (vertical && horizontal && !overlap) {
        event.target.appendChild(document.getElementById(data));

        boatsPixel[boatId][1] = eventHorizontal;
        boatsPixel[boatId][2] = boatsPixel[boatId][1] + elWidth;
        boatsPixel[boatId][3] = eventVertical;
        boatsPixel[boatId][4] = boatsPixel[boatId][3] + elHeight;
    }

}

function checkOverlap(evHorizontal, elW, evVertical, elH, boatId, grid) {
    var boat;
    if (boatId == -1) {
        boat = parseInt(id[4]) - 1;
    } else {
        boat = boatId;
    }

    for (var i = 0; i < boatsPixel.length; i++) {
        var boatStringVar = i + 1;
        var boatString = "boat" + boatStringVar;

        var gridOfBoat = document.getElementById(boatString).parentElement.parentElement.className;
        var sameGrid = eval(grid == gridOfBoat);

        if (boat != i && sameGrid) {
            if (evHorizontal >= boatsPixel[i][2] || boatsPixel[i][1] >= evHorizontal + elW) {
                continue;
            } else if (evVertical >= boatsPixel[i][4] || boatsPixel[i][3] >= evVertical + elH) {
                continue;
            }
            return true;
        } else {
            continue;
        }

    }
    return false;
}

function selectElement(clicked_id) {
    if (id != null) {
        document.getElementById(id).style.border = "#000 1px solid"
    }
    id = clicked_id;
    document.getElementById(id).style.border = "#F00 3px solid"
}

function rotateElement() {
    var className = document.getElementById(id).parentElement.parentElement.className

    if (document.getElementById(id).offsetHeight > document.getElementById(id).offsetWidth) {
        var width = document.getElementById(id).offsetWidth + 'px';
        var height = document.getElementById(id).offsetHeight + 'px';
        var bottom = 10 * 40;
        if (className == "field-grid") {
            var right = 10 * 40;
            var elTop = document.getElementById(id).offsetTop - document.getElementById("topleft").offsetTop - 1;
            var elLeft = document.getElementById(id).offsetLeft - document.getElementById("topleft").offsetLeft - 1;
        } else if (className == "selection-grid-layer") {
            var right = 6 * 40;
            var elTop = document.getElementById(id).offsetTop - document.getElementById("topleftlayer").offsetTop - 1;
            var elLeft = document.getElementById(id).offsetLeft - document.getElementById("topleftlayer").offsetLeft - 1;
        }
        var elWidthRotated = document.getElementById(id).offsetHeight;
        var elHeightRotated = document.getElementById(id).offsetWidth;

        var overlap = checkOverlap(elLeft, elWidthRotated, elTop, elHeightRotated, -1, className);

        if (((elTop + elHeightRotated) <= bottom) && ((elLeft + elWidthRotated) <= right) && !overlap) {
            document.getElementById(id).style.width = height;
            document.getElementById(id).style.height = width;

            boatId = parseInt(id[4]) - 1;

            boatsPixel[boatId][2] = boatsPixel[boatId][1] + parseInt(height, 10);
            boatsPixel[boatId][4] = boatsPixel[boatId][3] + parseInt(width, 10);
        }
    } else if (document.getElementById(id).offsetWidth > document.getElementById(id).offsetHeight) {
        var width = document.getElementById(id).offsetWidth + 'px';
        var height = document.getElementById(id).offsetHeight + 'px';
        var bottom = 10 * 40;
        if (className == "field-grid") {
            var right = 10 * 40;
            var elTop = document.getElementById(id).offsetTop - document.getElementById("topleft").offsetTop - 1;
            var elLeft = document.getElementById(id).offsetLeft - document.getElementById("topleft").offsetLeft - 1;
        } else if (className == "selection-grid-layer") {
            var right = 6 * 40;
            var elTop = document.getElementById(id).offsetTop - document.getElementById("topleftlayer").offsetTop - 1;
            var elLeft = document.getElementById(id).offsetLeft - document.getElementById("topleftlayer").offsetLeft - 1;
        }
        var elWidthRotated = document.getElementById(id).offsetHeight;
        var elHeightRotated = document.getElementById(id).offsetWidth;

        var overlap = checkOverlap(elLeft, elWidthRotated, elTop, elHeightRotated, -1, className);

        if (((elTop + elHeightRotated) <= bottom) && ((elLeft + elWidthRotated) <= right) && !overlap) {
            document.getElementById(id).style.width = height;
            document.getElementById(id).style.height = width;

            boatId = parseInt(id[4]) - 1;

            boatsPixel[boatId][2] = boatsPixel[boatId][1] + parseInt(height, 10);
            boatsPixel[boatId][4] = boatsPixel[boatId][3] + parseInt(width, 10);
        }
    }
}

function GetCoordinates() {
    boatCoordinates = [];

    for (var i = 0; i < boatsPixel.length; i++) {
        var boatId = "boat" + (i + 1);
        var grid = document.getElementById(boatId).parentElement.parentElement.className;
        if (grid == "selection-grid-layer") {
            alert("Not all boats have been placed yet!");
            break;
        } else {
            var boatLeft = boatsPixel[i][1];
            var boatRight = boatsPixel[i][2];
            var boatTop = boatsPixel[i][3];
            var boatBottom = boatsPixel[i][4];
            var width = (boatRight - boatLeft) / 40;
            var height = (boatBottom - boatTop) / 40;
            var boat;
            var coordinate;
            var row;
            var col;
            var field;

            if (width > height) {
                boat = [];

                for (var j = boatLeft; j < boatRight; j += 40) {
                    coordinate = {
                        row: (boatBottom - 40) / 40,
                        col: j / 40,
                        field: 0
                    };
                    boat.push(coordinate);
                }

            } else if (height > width) {
                boat = [];

                for (var j = boatTop; j < boatBottom; j += 40) {
                    coordinate = {
                        row: j / 40,
                        col: (boatRight - 40) / 40,
                        field: 0
                    };
                    boat.push(coordinate);
                }
            }
            boatCoordinates.push(boat);
        }
    }
    if (boatCoordinates.length == 5) {
        console.log(boatCoordinates);
        boats = JSON.stringify(boatCoordinates);
        UploadField(boats);
        //alert(boats);
    }
}

function UploadField(boats) {
    $.ajax({
        type: "POST",
        url: "CreateField?handler=UploadField",
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: boats
    });
}

function CheckForStartGame() {
    $.ajax({
        type: "GET",
        url: "CreateField?handler=StartCheck",
        contentType: 'application/json; charset=utf-8',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            //console.log(result);
            if (result == true) {
                location.replace("https://localhost:5001/PlayingField");
            }
        },
        complete: function () {
            setTimeout(CheckForStartGame, 1000);
        }
    });
}

CheckForChanges();
function CheckForChanges() {
    CheckForStartGame();
    $.ajax({
        type: "GET",
        url: "CreateField?handler=ChangeChecker",
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


    $.each(players, function (key, player) {
        console.log(player);
        console.log(player.ready);

        var state = player.ready == true || player.ready == "true" ? "Ready" : "No";

        console.log("state: " + state);

        var id = "#player" + player.playerId;

        console.log("id: " + id);

        $(id).html("");
        $(id).html(state);
    });
}