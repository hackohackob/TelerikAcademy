function Solve(input) {

    var n = input[0];
    var w = input[1];

    var initialTextArray = [];
    var onlyWordsArray = [];
    var allWords = [];
    var finalResult = "";

    for (var i = 0; i < n; i++) {
        initialTextArray.push(input[i + 2]);
        onlyWordsArray.push(input[i + 2]);
    }

    //console.log(initialTextArray);
    //console.log(onlyWordsArray);

    for (var i = 0; i < onlyWordsArray.length; i++) {
        //console.log(onlyWordsArray[i]);
        //console.log(onlyWordsArray[i].split(" "));
        //console.log(onlyWordsArray[i].split(" ").filter(function (element) {
        //    if (element != "" && element != " ") {
        //        return element;
        //    }
        //}));

        debugger;

        if (onlyWordsArray[i] == undefined) {
            console.log("ASSADDSADSADSA");
            
        }
        var currentRow = onlyWordsArray[i].split(" ");

        currentRow = currentRow.filter(function (element) {
            if (element != "" && element != " ") {
                return element;
            }
        });

        onlyWordsArray[i] = currentRow;
        
    }

    //console.log(onlyWordsArray);

    var allWords = allWordsToArray(onlyWordsArray);
    var currentWordToRead = 0;
    var currentRowLength;
    var currentRow;
    var currentRowToString;

    while (true) {

        currentRowLength = 0;
        currentRow = [];

        while (currentRowLength <w) {
            currentRow.push(allWords[currentWordToRead]);
            currentRowLength += allWords[currentWordToRead].length + 1;
            if (currentRowLength > w) {
                //console.log(currentRowLength + " " + w);
                currentRowLength--;
            }
            currentWordToRead++;

            if (currentRowLength > w) {
                currentRow.pop();
                currentWordToRead--;
                break;
            }

            if (currentWordToRead == allWords.length) {
                break;
            }
        }

        cureentRow = justifyRow(currentRow);

        currentRowToString = currentRow.join(" ") + "\r";
        finalResult += currentRowToString;;

        if (currentWordToRead == allWords.length) {
            break;
        }
    }

    function allWordsToArray(textRows) {
        var currentWord = "";
        var allWords = [];
        for (var i = 0; i < textRows.length; i++) {
            for (var j = 0; j < textRows[i].length; j++) {
                allWords.push(textRows[i][j]);
            }
        }

        return allWords;
    }

    function justifyRow(row) {
        if (row.length == 1) {
            return row;
        }

        var rowWidth = 0;
        var word = "";
        var currentWord = 1;

        for (var i = 0; i < row.length - 1; i++) {
            rowWidth += row[i].length + 1;
        }
        rowWidth += row[row.length - 1].length;

        while (rowWidth < w) {
            word = row[currentWord];

            row.splice(currentWord, 1, " " + word);

            currentWord++;
            if (currentWord == row.length) {
                currentWord = 1;
            }

            rowWidth++;
        }

        return row;
    }

    return finalResult;
}


var firstTest = [
    '4',
    '20',
    ' 123456789012345 123456',
    'some    example   text should be written here.',
    'Telerik academy',
    'Java Script      Exam  in thuesday.',
    'console     justification and this is        another    example   text'
];

var secondTest = [
'10',
'18',
'Beer beer beer Im going for ',
'   a                        ',
'beer                        ',
'Beer beer beer Im gonna     ',
'drink some beer             ',
'I love drinkiiiiiiiiing     ',
'beer                        ',
'lovely                      ',
'lovely                      ',
'beer                        '
];

//console.log(Solve(firstTest));
console.log(Solve(secondTest));
