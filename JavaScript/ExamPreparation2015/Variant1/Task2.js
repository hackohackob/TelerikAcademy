

function solve(args) {
    var rowN,
        colN,
        wordMatrix = [],
        numberMatrix = [],
        cRow = 0,
        cCol = 0,
        sum = 0;

    var rowCol = args[0].split(' ');
    rowN = +rowCol[0];
    colN = +rowCol[1];

    for (var i = 0; i < rowN; i++) {
        wordMatrix[i] = args[i + 1].split(' ');
    }

    for (var i = 0; i < rowN; i++) {
        var number = Math.pow(2, i);
        numberMatrix[i] = [];

        for (var j = 0; j < colN; j++) {
            numberMatrix[i][j] = number;
            number++;
        }
    }

    while (true) {
        sum += numberMatrix[cRow][cCol];
        numberMatrix[cRow][cCol] = 'Z';
        switch (wordMatrix[cRow][cCol]) {
            case 'dr':
            {
                cRow += 1;
                cCol += 1;
            }
                break;
            case 'ur':
            {
                cRow -= 1;
                cCol += 1;
            }
                break;
            case 'ul':
            {
                cRow -= 1;
                cCol -= 1;
            }
                break;
            case 'dl':
            {
                cRow += 1;
                cCol -= 1;
            }
                break;
        }

        if (cRow < 0 || cRow >= rowN || cCol < 0 || cCol >= colN) {
            console.log('successed with ' + sum);
            break;
        } else if (numberMatrix[cRow][cCol] === 'Z') {
            console.log('failed at (' + cRow + ', ' + cCol + ')');
            break;
        }
    }
}