$(function () {
    var List = "";

    GetHighScores();
    function GetHighScores(filterData = "") {
        //

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

    function SetHighscores(Highscores) {
        //console.log(Highscores);
        var html = Highscores.length > 0 ? "" : '<td colspan="6" class="table_center">No highscores found</td>';
        var count = 0;
        $.each(Highscores, function (key, val) {
            count++;
            html += '<tr><td class="table_center">' + count +
                '</td><td class="table_center">' + val.player.name +
                '</td><td class="table_center">' + val.shots +
                '</td><td class="table_center">' + val.hits +
                '</td><td class="table_center">' + val.hit_streak +
            '</td></tr>';
        });

        $("#HighscoresBody").html(html);
    }

   

    $(document).on("click", "#FilterButton", function () {
        var selected_field = $("#FilterField").children("option:selected").val();
        var selected_direction = $("#FilterDirection").children("option:selected").val();

        var filterData = { field: selected_field, direction: selected_direction, highscores: List };

        GetHighScores(filterData);
    });

    $(document).on("click", "#ResetButton", function () {
        $("#searchBox").val("");
        GetHighScores();
    });

    $(document).on("keyup", "#searchBox", function () {
        var search = $("#searchBox").val();
        var filterData = { search: search };

        GetHighScores(filterData);
    });
});