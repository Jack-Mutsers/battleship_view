var Id;

function SelectId(_Id) {

    Id = _Id;
    document.getElementById(_Id).style.fontSize = '24px';


}

function myFunction() {
    document.getElementById("testtest").style.color = "red";
}

function GetCoordinates(element) {
    var fieldnr = $(element).data("field");
    var col = $(element).data("col");
    var row = $(element).data("row");
    alert("field: " + fieldnr + " -- col: " + col + " -- row: " + row);

}

function ColorCoordinate(col, row, hit) {
    if (hit) {
        document.getElementById("square" + col + "." + row).style.backgroundColor = "red";
    } else {
        document.getElementById("square" + col + "." + row).style.backgroundColor = "#1f4a44";
    }
}

GetBoats();
function GetBoats(filterData = Boat) {

    $.ajax({
        type: "POST",
        url: "PlayingField?handler=ajax&name=Zoë",
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
            SetBoats(result);
        }
    });
}

function SetBoats(Coördinates) {
    //console.log(Coördinates);
    var html = Highscores.length > 0 ? "" : '<td colspan="6" class="table_center">No highscores found</td>';
    $.each(Highscores, function (key, val) {
        html += '<tr><td class="table_center">' + val.id +
            '</td><td class="table_center">' + val.player.name +
            '</td><td class="table_center">' + val.shots +
            '</td><td class="table_center">' + val.accuracy +
            '%</td><td class="table_center">' + val.hit_streak +
            '</td><td class="table_center">' + val.boats_sunk +
            '</td></tr>';
    });

    $("#PlayingFieldBody").html(html);
}