/// <reference path="D:\TelerikAcademy\JavaScript\ConditionalStatements\AllExercises\JS-Console/js-console.js" />

//#region 1
function first() {
    jsConsole.writeLine("== 1 =================");
    var a = jsConsole.readInteger("#input1"), b = jsConsole.readInteger("#input2");

    jsConsole.writeLine("The numbers are:" + a + " " + b);
    if (a > b) {
        var c = a;
        a = b;
        b = c;
    }

    jsConsole.writeLine("After the if the numbers are:" + a + " " + b);
    jsConsole.writeLine("======================");
    jsConsole.writeLine("");
}
//#endregion

//#region 2
function second() {
    jsConsole.writeLine("== 2 =================");

    var firstNumber = jsConsole.readInteger("#input1"), secondNumber = jsConsole.readInteger("#input2"),
        thirdNumber = jsConsole.readInteger("#input3");
    jsConsole.writeLine("The numbers are:" + firstNumber + " " + secondNumber + " " + thirdNumber);
    var negative = false;

    if (firstNumber < 0) {
        negative = !negative;
    }

    if (secondNumber < 0) {
        negative = !negative;
    }

    if (thirdNumber < 0) {
        negative = !negative;
    }

    var output = "The product is ";
    if (!negative) {
        output += "NOT ";
    }

    output += "negative.";

    jsConsole.writeLine(output);
    jsConsole.writeLine("======================");
    jsConsole.writeLine("");
}
//#endregion

//#region 3
function third(){
    jsConsole.writeLine("== 3 =================");

    var firstNumber = jsConsole.readInteger("#input1"), secondNumber = jsConsole.readInteger("#input2"),
        thirdNumber = jsConsole.readInteger("#input3");

    jsConsole.writeLine("The numbers are:" + firstNumber + " " + secondNumber + " " + thirdNumber);

    if (firstNumber > secondNumber){
        if(firstNumber>thirdNumber){
            jsConsole.writeLine("The biggest number is the first:" + firstNumber);
        } else {
            jsConsole.writeLine("The biggest number is the third:" + thirdNumber);
        }
    } else {
        if (secondNumber > thirdNumber) {
            jsConsole.writeLine("The biggest number is the second:" + secondNumber);
        } else {
            jsConsole.writeLine("The biggest number is the third:" + thirdNumber);
        }
    }
    jsConsole.writeLine("======================");
    jsConsole.writeLine("");
}
//#endregion

//#region 4
function fourth() {
    jsConsole.writeLine("== 4 =================");

    var firstNumber = jsConsole.readFloat("#input1"), secondNumber = jsConsole.readFloat("#input2"),
            thirdNumber = jsConsole.readFloat("#input3");

    var output = "";

    if (firstNumber > secondNumber) {
        if (firstNumber > thirdNumber) {
            output += firstNumber + " ";

            if (secondNumber > thirdNumber) {
                output += secondNumber + " " + thirdNumber;
            } else {
                output += thirdNumber + " " + secondNumber;
            }
        } else {
            output += thirdNumber + " ";

            if (firstNumber > secondNumber) {
                output += firstNumber + " " + secondNumber;
            } else {
                output += secondNumber + " " + firstNumber;
            }
        }
    } else {
        if (secondNumber > thirdNumber) {
            output += secondNumber + " ";

            if (firstNumber > thirdNumber) {
                output += firstNumber + " " + thirdNumber;
            } else {
                output += thirdNumber + " " + firstNumber;
            }
        } else {
            output += thirdNumber + " ";

            if (firstNumber > secondNumber) {
                output += firstNumber + " " + secondNumber;
            } else {
                output += secondNumber + " " + firstNumber;
            }
        }
    }

    jsConsole.writeLine(output);
    jsConsole.writeLine("======================");
    jsConsole.writeLine("");
}
//#endregion

//#region 5
function fifth(){
    jsConsole.writeLine("== 5 =================");

    var number = jsConsole.readFloat("#input1");
    jsConsole.write("The number is ");

    switch(number)
    {
        case 0: jsConsole.writeLine("zero"); break;
        case 1: jsConsole.writeLine("one"); break;
        case 2: jsConsole.writeLine("two"); break;
        case 3: jsConsole.writeLine("three"); break;
        case 4: jsConsole.writeLine("four"); break;
        case 5: jsConsole.writeLine("five"); break;
        case 6: jsConsole.writeLine("six"); break;
        case 7: jsConsole.writeLine("seven"); break;
        case 8: jsConsole.writeLine("eight"); break;
        case 9: jsConsole.writeLine("nine"); break;
    }

    jsConsole.writeLine("======================");
    jsConsole.writeLine("");
}
//#endregion

//#region 6
function sixth() {
    jsConsole.writeLine("== 6 =================");

    var firstNumber = jsConsole.readFloat("#input1"), secondNumber = jsConsole.readFloat("#input2"),
            thirdNumber = jsConsole.readFloat("#input3");
    var root1,root2;

    var discriminant = secondNumber * secondNumber - 4 * firstNumber * thirdNumber;

    if (discriminant < 0)
    {
        jsConsole.writeLine("There are no real roots!");
    } else if (discriminant === 0) {
        root1 = -secondNumber / 2 * firstNumber;

        jsConsole.writeLine("There is one real root:" + root1);
    }
    else {
        root1 = (-secondNumber + Math.sqrt(discriminant)) / 2 * firstNumber;
        root2 = (-secondNumber - Math.sqrt(discriminant)) / 2 * firstNumber;

        jsConsole.writeLine("There are two real roots:" + root1+" and "+root2);
    }

    jsConsole.writeLine("======================");
    jsConsole.writeLine("");
}
//#endregion

//#region 7
function seventh() {
    jsConsole.writeLine("== 7 =================");
    var firstNumber = jsConsole.readFloat("#input1"), secondNumber = jsConsole.readFloat("#input2"),
            thirdNumber = jsConsole.readFloat("#input3"), fourthNumber = jsConsole.readFloat("#input4"),
            fifthNumber = jsConsole.readFloat("#input5");

    var max = firstNumber;
    if (secondNumber > max){
        max = secondNumber;
    }

    if (thirdNumber > max) {
        max = thirdNumber;
    }

    if (fourthNumber > max) {
        max = fourthNumber;
    }

    if (fifthNumber > max) {
        max = fifthNumber;
    }

    jsConsole.writeLine("The greatest number is:" + max);

    jsConsole.writeLine("======================");
    jsConsole.writeLine("");
}
//#endregion

//#region 8
function eight() {
    jsConsole.writeLine("== 8 =================");

    var n = jsConsole.read("#input1");

    var ones =
            ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'
            , 'ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen'
            , 'seventeen', 'eighteen', 'nineteen'
            ]

      , tens = ['twenty', 'thirty', 'fourty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety']

    var r = ''

    if (n > 99) {
        r += ones[parseInt(n / 100, 10)] + ' hundred'

        if (n %= 100) {
            r += ' and ';
        }
    }

    if (n > 19) {
        r += tens[parseInt(n / 10 - 2, 10)]

        if (n %= 10) {
            r += '-';
        }
    }

    if (n % 10 != 0) {
        r += ones[n];
    }

    jsConsole.writeLine(r);
    
    jsConsole.writeLine("======================");
    jsConsole.writeLine("");
}
//#endregion

