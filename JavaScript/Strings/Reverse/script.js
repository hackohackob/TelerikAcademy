function first() {
    var string = "example";

    var stringToArray = string.split("");

    stringToArray.reverse();

    var stringToReturn = stringToArray.join("");
    console.log(stringToReturn);

}

function second() {
    var expression = "(((5x+6)*4)+10^x)-(15x^2+20)";
    var counter = 0;
    var valid=true;

    for (var i = 0; i < expression.length; i++) {
        if (expression[i] == "(") {
            counter++;
        }

        if (expression[i] == ")") {
            counter--;
        }

        if (counter<0) {
            valid = false;
            break;
        }
    }

    if (counter !== 0) {
        valid = false;
    }

    console.log("The expression is" + ((valid) ? " " : "n't ") + "put correctly");
}

function third() {
    var searchedWord = "in";
    var text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

    var times = text.toLowerCase().split(searchedWord.toLowerCase()).length - 1;

    console.log(times);
}

function fourth() {
    var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anYTHing</lowcase> else.";
    var i = 0;

    while (i<10) {
        var openingFirst = text.indexOf("<");
        var closingFirst = text.indexOf(">");
        var openingSecond = text.indexOf("<", openingFirst);
        var closingSecond = text.indexOf(">", closingFirst+1);
        var toParse = text.slice(openingFirst, closingSecond + 1);
        text = text.split(toParse);
        toParse = customParser(toParse);

        text = text.join(toParse);

        i++;
        if (openingFirst == -1) {
            return text;
        }
    }

    function customParser(partOfText) {
        var toReturn = "";
        var type = partOfText.slice(1, partOfText.indexOf(">"));
        
        var toReturn = partOfText.slice(partOfText.indexOf(">") + 1, partOfText.lastIndexOf("<"));

        switch (type) {
            case "upcase": toReturn = toReturn.toUpperCase(); break;
            case "lowcase": toReturn = toReturn.toLowerCase(); break;
            case "mixcase": toReturn = mixcase(toReturn); break;
        }
        return toReturn;
    }

    function mixcase(string) {
        var toReturn = "";
        
        for (var i = 0; i < string.length; i++) {
            var rand = Math.floor(Math.random() * 10);

            if (rand % 2 == 0) {
                toReturn += string[i].toUpperCase();
            } else {
                toReturn += string[i].toLowerCase();
            }
        }

        return toReturn;
    }
}

function fifth() {

}

console.log(fourth());