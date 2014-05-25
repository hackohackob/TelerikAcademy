function Solve(input) {
    var n = parseInt(input[0].split(" ")[0]);
    var m = parseInt(input[0].split(" ")[1]);
    var r = parseInt(input[1].split(" ")[0]);
    var c = parseInt(input[1].split(" ")[1]);

    var matrix = [];
    var stepped = [];
    var toReturn = "";
    var sum = 0, numberOfcells = 0;
    

    var currentPosition = {
        row: parseInt(r),
        col: parseInt(c)
    };

    for (var i = 0; i < n; i++) {
        stepped[i] = [];
        for (var j = 0; j < m; j++) {
            stepped[i][j] = false;
        }
    }

    stepped[r][c] = true;

    for (var i = 2; i < n + 2; i++) {
        matrix[i - 2] = input[i].split("");
    }

    while (true) {

        var direction = matrix[currentPosition.row][currentPosition.col];
        var rowPlus = 0, colPlus = 0;

        switch (direction) {
            case "l": colPlus--; break;
            case "u": rowPlus--; break;
            case "r": colPlus++; break;
            case "d": rowPlus++; break;
        }
        sum += (currentPosition.row) * m + currentPosition.col + 1;
        numberOfcells++;

        currentPosition.row += rowPlus;
        currentPosition.col += colPlus;


        if (currentPosition.row < 0 || currentPosition.row == n
            || currentPosition.col < 0 || currentPosition.col == m) {
            toReturn = "out " + sum;
            break ;
        }

        if (stepped[currentPosition.row][currentPosition.col] == true) {
            toReturn = "lost " + numberOfcells;
            break;
        }

        stepped[currentPosition.row][currentPosition.col] = true;
    }

    return toReturn;
}

args1 = [
 "3 4",
 "1 3",
 "lrrd",
 "dlll",
 "rddd"];

args2 = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"]

args3 = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "lurlddud",
 "urrrldud",
 "ulllllll"]


console.log(Solve(args1));
console.log(Solve(args2));
console.log(Solve(args3));