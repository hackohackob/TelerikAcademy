/// <reference path="D:\TelerikAcademy\JavaScript\Functions\AllTasks\js-console/js-console.js" />

console.log("hacko");

function first() {
    jsConsole.writeLine("=== 1 ================");
    var number = document.getElementById("input1").value;

    var lastDigit = number % 10;

    switch (lastDigit) {
        case 0: lastDigit = "zero"; break;
        case 1: lastDigit = "one"; break;
        case 2: lastDigit = "two"; break;
        case 3: lastDigit = "three"; break;
        case 4: lastDigit = "four"; break;
        case 5: lastDigit = "five"; break;
        case 6: lastDigit = "six"; break;
        case 7: lastDigit = "seven"; break;
        case 8: lastDigit = "eight"; break;
        case 9: lastDigit = "nine"; break;
    }

    jsConsole.writeLine(lastDigit);

    jsConsole.writeLine("======================");
}

function second() {
    jsConsole.writeLine("=== 2 ================");
    var number = document.getElementById("input1").value;
    console.log(typeof (number));
    var newNumber = "";
    var numberArray = number.toString().split("");

    numberArray = numberArray.reverse();
    jsConsole.writeLine(numberArray.join(""));

    jsConsole.writeLine("======================");
}

function third() {
    jsConsole.writeLine("=== 3 ================");
    var text = "We are living in an yellow submarine. In the sky there are no clouds. So we are drinking all the day. We will move out of it in 5 days.";

    var word = document.getElementById('input1').value;
    var caseSensitive = document.getElementById('sensitive').checked;
    var count = -1;

    if (caseSensitive) {
        count = thirdSensitive(text, word);
    } else {
        count = thirdInsensitive(text, word);
    }

    if (count == 0) {
        count = -1;
    }

    jsConsole.writeLine("TEXT: " + text);
    jsConsole.writeLine("WORD: " + word);
    jsConsole.writeLine("Case sensitive: " + ((caseSensitive) ? "yes" : "no"));
    jsConsole.writeLine("Count: " + count);
    jsConsole.writeLine("======================");
}

function thirdSensitive(text, word) {
    var wholeText = text.toString();
    var array = text.toString().split(" " + word + " ");

    return array.length - 1;
}

function thirdInsensitive(text, word) {
    text = text.toLowerCase();
    var array = text.toString().split(" " + word + " ");

    return array.length - 1;
}

function fourth() {
    jsConsole.writeLine("=== 4 ================");

    var arrayOfDivs = document.getElementsByTagName("div");
    console.log(arrayOfDivs);
    jsConsole.writeLine("Count of divs: " + arrayOfDivs.length);
    jsConsole.writeLine("P.S. open the console to see the divs");
    jsConsole.writeLine("======================");
}

function fifth() {
    jsConsole.writeLine("=== 5 ================");
    var array = [1, 7, 10, 29, 2, 7, 3, 2048, 1024, 8, 7, 3, 4, 2048, 4096, 256, 63, 64, 128, 7, 3, 2048];
    jsConsole.writeLine("The array of numbers is: " + array);

    for (var i = 0; i < array.length; i++) {
        jsConsole.write("Count of number " + array[i] + " in the array: ");
        isInArray(array, array[i]);
    }

    jsConsole.writeLine("======================");
}

function isInArray(array, number) {
    var count = 0;

    for (var i = 0; i < array.length; i++) {
        if (array[i] == number) {
            count++;
        }
    }

    jsConsole.writeLine(count);
}

function sixth() {
    jsConsole.writeLine("=== 6 ================");
    var array = [1, 7, 10, 29, 2, 7, 3, 2048, 1024, 8, 7, 3, 4, 2048, 4096, 256, 63, 64, 128, 7, 3, 2048];
    jsConsole.writeLine("The array of numbers is: " + array);

    var index = document.getElementById("input1").value;
    if (!index) {
        jsConsole.writeLine("Input the index number");
        return;
    }

    index = parseInt(index);

    jsConsole.write("The number at the selected index is ");
    if (!biggerThanNeighbors(array, index)) {
        jsConsole.write("not ");
    }

    jsConsole.writeLine("bigger than its neighbors");
jsConsole.writeLine("======================");
}

function biggerThanNeighbors(array, index) {
    if (((array[index - 1] != undefined && array[index - 1] < array[index]) || array[index - 1] == undefined) &&
        ((array[index + 1] != undefined && array[index + 1] < array[index]) || array[index + 1] == undefined)) {
        return true;
    } else {
        return false;
    }
}

function seventh() {
    jsConsole.writeLine("=== 7 ================");

    var array = [1, 7, 10, 29, 2, 7, 3, 2048, 1024, 8, 7, 3, 4, 2048, 4096, 256, 63, 64, 128, 7, 3, 2048];
    var result = 0;

    for (var i = 0; i < array.length; i++) {
        if (biggerThanNeighbors(array, i)) {
            result = i;
            break;
        }
    }
    jsConsole.writeLine("Array: " + array);
    jsConsole.writeLine("Index: " + result);

    jsConsole.writeLine("======================");
}