var image = ['Menu', 'Join', 'Create', 'Setup', 'Game', 'Highscores']
var title = ['Main menu', 'Join a game', 'Create and start a game', 'Create field', 'Gameplay', 'Highscores']
var explanation =
    ['"This is the main menu. From here you can go to the highscores page, create lobby page, join lobby page and the tutorial page."',
     '"This is the join a game page. On this page you can join somebody&#8217;s lobby by entering their lobbycode, also don&#8217;t forget to fill in your name. If you don&#8217;t like it anymore you can leave the lobby at any time you want."',
     '"This is the create and start a game page. If you click on create a lobby you receive a unique lobbycode. You now can share the lobbycode with your friends so they can enter the lobbycode thus joining your lobby. If you want to start a game... well i think you can already guess it."',
     '"When you&#8217;ve started a game, you go to the create field page. Here you need to setup your ships. You can move the ships onto the grid. If you want to rotate them, simply select a ship and click on rotate. When you&#8217;re finished you can submit your setup."',
     '"When everybody has submitted their setup the game starts. First the computer decides who has to begin. The playingfield consists of 4 seperate 10x10 playing fields including your own. You don&#8217;t know which field is whose. When you hit a boat everyone will see it, but nobody gets to know the exact coördinates. If you don&#8217;t like it anymore you can surrender and quit the game. When you aren&#8217;t active for two turns in a row you will get kicked. When you&#8217;re dead you can spectate the game. The game ends when there is just one player remaining. <br> <br> Good luck."',
     '"This is the highscores page. On this page you can view the highscores of single games, if you like you can filter them by statistic and you can even select if you want the statistics to ascend/descend."']
var i = 0;


function NextImg() {
    if (i < image.length - 1) {
        i++;
    } else {
        i = 0;
    }
    document.getElementById('current-slide').innerHTML = "<img src='/Tutorial_images/" + image[i] + ".PNG'>";
    document.getElementById('title').innerHTML = "<h2>" + title[i] + "</h2>";
    document.getElementById('explanation').innerHTML = "<p>" + explanation[i] + "</p>"
}

function PreviousImg() {
    if (i > 0) {
        i--;
    } else {
        i = image.length - 1;
    }
    document.getElementById('current-slide').innerHTML = "<img src='/Tutorial_images/" + image[i] + ".PNG'>";
    document.getElementById('title').innerHTML = "<h2>" + title[i] + "</h2>";
    document.getElementById('explanation').innerHTML = "<p>" + explanation[i] + "</p>"
}