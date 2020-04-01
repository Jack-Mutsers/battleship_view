function JoinLobby() {
    var username = document.getElementById('username-input').value;
    var lobbycode = document.getElementById('lobbycode-input').value;

    document.getElementById('lobby').style.display = "inline-block";
    document.getElementById('players').innerHTML = "<ul><li>" + username + "</li></ul>"
    document.getElementById('players').style.display = "inline-block";
    document.getElementById('join').style.display = "none";
    document.getElementById('back').style.display = "none";

    document.getElementById('username').innerHTML = "<p>Username: " + username + "</p>";
    document.getElementById('lobbycode').innerHTML = "<p>Lobbycode: " + lobbycode + "</p>";
}


