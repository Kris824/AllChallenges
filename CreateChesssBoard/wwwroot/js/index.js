$(document).ready(function () {
    var obstacles = JSON.parse($("#obstacles").val());
    for (var i = 55, j = 31; i < 100 && j < 100; i++, j++) {

        var realObstacle = obstacles.some(function (obstacle) {
            if (obstacle[0] == i && obstacle[1] == j) {
                return obstacle;
            }

            return null;
        });

        if (realObstacle) {
            break;
        } else {
            $(`#cell-${i}-${j}`).css("background", "aquamarine");
        }
    }

    for (var i = 55, j = 29; i < 100 && j >= 0; i++, j--) {

        var realObstacle = obstacles.some(function (obstacle) {
            if (obstacle[0] == i && obstacle[1] == j) {
                return obstacle;
            }

            return null;
        });

        if (realObstacle) {
            break;
        } else {
            $(`#cell-${i}-${j}`).css("background", "aquamarine");
        }
    }

    for (var i = 53, j = 31; i >= 0 && j < 100; i--, j++) {

        var realObstacle = obstacles.some(function (obstacle) {
            if (obstacle[0] == i && obstacle[1] == j) {
                return obstacle;
            }

            return null;
        });

        if (realObstacle) {
            break;
        } else {
            $(`#cell-${i}-${j}`).css("background", "aquamarine");
        }
    }

    for (var i = 53, j = 29; i >= 0 && j >= 0; i--, j--) {

        var realObstacle = obstacles.some(function (obstacle) {
            if (obstacle[0] == i && obstacle[1] == j) {
                return obstacle;
            }

            return null;
        });

        if (realObstacle) {
            break;
        } else {
            $(`#cell-${i}-${j}`).css("background", "aquamarine");
        }
    }
});