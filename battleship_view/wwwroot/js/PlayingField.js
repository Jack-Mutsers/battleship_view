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