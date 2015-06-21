function solve(args) {
    var rows = parseInt(args[0]),
        cols = parseInt(args[1]),
        tests = parseInt(args[rows + 2]),
        i,
        move,
        board = [];

    for (var i = 0; i < rows; i++) {
        board[i] = [];
        var currentRow = args[i + 2];
        currentRow = currentRow.split('');
        board[i] = currentRow;
    }

    //console.log(board);


    for (i = 0; i < tests; i++) {

        move = args[rows + 3 + i];
        var move2 = move.split(' ');
        var moveFrom = move2[0];
        var moveTo = move2[1];
        var moveFromCol = moveFrom.slice(0, 1);
        var moveFromColNumber = moveFromCol.charCodeAt(0) - 97;
        var moveFromRow = moveFrom.slice(1);
        moveFromRow = (rows - moveFromRow)
        var moveToCol = moveTo.slice(0, 1);
        var moveToColNumber = moveToCol.charCodeAt(0) - 97;
        var moveToRow = moveTo.slice(1);
        moveToRow = (rows - moveToRow);
        var shouldBreak =false;

        var figure = board[moveFromRow][moveFromColNumber];
        //console.log(move2 +' '+figure);
        //console.log(figure +' '+ board[moveFromRow][moveFromColNumber]);

        if (board[moveToRow][moveToColNumber] !== '-') {
            console.log('no');
            continue;
        } else if (figure === 'R') {
            if(!((moveFromRow === moveToRow ) || (moveFromColNumber === moveToColNumber))){
                console.log('no');
                continue;
            }

            var r =moveFromRow,
                c = moveFromColNumber,
                first=true;

            while(true){
                if(board[r][c]!=='-' && !first){
                    console.log('no');
                    shouldBreak=true;
                    //console.log('non empty at:'+r+' '+c);
                    break;
                }

                first=false;

                if(moveFromColNumber<moveToColNumber){
                    c++;
                } else if(moveFromColNumber>moveToColNumber){
                    c--;
                }
                if(moveFromRow<moveToRow){
                    r++;
                } else if(moveFromRow>moveToRow){
                    r--;
                }
                if(c===moveToColNumber && r === moveToRow){
                    break;
                }
            }


            //board[moveToRow][moveToColNumber] = 'R';
        } else if (figure === 'B') {
            if(Math.abs(moveFromRow - moveToRow ) !== Math.abs(moveFromColNumber - moveToColNumber)){
                console.log('no');
                continue;
            }

            var r =moveFromRow,
                c = moveFromColNumber,
                first= true;

            while(true){
                if(board[r][c]!=='-' && !first){
                    console.log('no');
                    shouldBreak =true;
                    break;
                }

                first=false;

                if(moveFromColNumber<moveToColNumber){
                    c++;
                } else if(moveFromColNumber>moveToColNumber){
                    c--;
                }
                if(moveFromRow<moveToRow){
                    r++;
                } else if(moveFromRow>moveToRow){
                    r--;
                }
                if(c===moveToColNumber && r === moveToRow){
                    break;
                }
            }

        } else if (figure === 'Q') {
            if((Math.abs(moveFromRow - moveToRow ) !== Math.abs(moveFromColNumber - moveToColNumber))
                && !((moveFromRow === moveToRow ) || (moveFromColNumber === moveToColNumber))){
                console.log('no');
                continue;
            }

            var r = moveFromRow,
                c = moveFromColNumber,
                first=true;


            while(true){
                if(board[r][c]!=='-' && !first){
                    first=false;
                    console.log('no');
                    shouldBreak=true;
                    break;
                }

                first=false;



                if(moveFromColNumber<moveToColNumber){
                    c++;
                } else if(moveFromColNumber>moveToColNumber){
                    c--;
                }
                if(moveFromRow<moveToRow){
                    r++;
                } else if(moveFromRow>moveToRow){
                    r--;
                }

                if(c===moveToColNumber && r === moveToRow){
                    break;
                }

            }
        }else if (board[moveFromRow][moveFromColNumber] === '-'){
            console.log('no');
            continue;
        } else {
            console.log('noe')
            continue;
        }

        if(!shouldBreak) {
            console.log('yes');
        }
    }

}

var input1 = [
    '3',
    '4',
    '--R-',
    'B--B',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 b3',
    'd2 c1',
    'b1 b2',
    'c3 b1',
    'a2 a3',
    'd1 d3'
];

solve(input1);