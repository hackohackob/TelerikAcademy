/// <reference path="D:\TelerikAcademy\JavaScript\OperatorsExpressions\AllExercises\JS-Console/js-console.js" />

//#region 1
jsConsole.write("01. ");

var number = 123;
jsConsole.write("number " + number + " is:");
if (number % 2 == 0) {
    jsConsole.writeLine("even");
} else {
    jsConsole.writeLine("odd");
}
jsConsole.writeLine("");
//#endregion

//#region 2
jsConsole.write("02. ");
var number = 35;
jsConsole.write("number " + number);

if (number % 7 == 0 && number % 5 == 0) {
    jsConsole.writeLine(" can be devided by 7 and 5.");
} else {
    jsConsole.writeLine(" cannot be devided by 7 and 5.");
}
jsConsole.writeLine("");
//#endregion

//#region 3
jsConsole.write("03. ");

var width = 10;
var height = 20;

var rectArea = width * height;
jsConsole.writeLine("Width:" + width + " Height:" + height + "   Area:" + rectArea);
jsConsole.writeLine("");
//#endregion

//#region 4
jsConsole.write("04. ");
var number = 1732;
jsConsole.write("The third number (right to left) of the number " + number);

if (((number % 1000) / 100) | 0 == 7) {
    jsConsole.writeLine(" is 7.");
} else {
    jsConsole.writeLine(" is not 7.");
}

jsConsole.writeLine("");
//#endregion

//#region 5
jsConsole.write("05. ");
var number = 11;
jsConsole.write("The third bit (rigth to left) of the number " + number);
if ((number & 8) != 0) {
    jsConsole.writeLine(" is 1");
} else {
    jsConsole.writeLine(" is 0");
}
jsConsole.writeLine("");
//#endregion

//#region 6
jsConsole.write("06. ");
var x = 3, y = 2;
x = Math.abs(x);
y = Math.abs(y);

var distanceToPoint = Math.sqrt(x * x + y * y);

if (distanceToPoint < 5) {
    jsConsole.writeLine("The point is IN the circle K(0,5).");
} else if (distanceToPoint === 5) {
    jsConsole.writeLine("The point is ON the circle K(0,5).");
} else {
    jsConsole.writeLine("The point is OUTSIDE the circle K(0,5).")
}
jsConsole.writeLine("");
//#endregion

//#region 7
jsConsole.write("07. ");
var number = 37;
var prime=true;
for (var i = 2; i < (Math.sqrt(number) | 0); i++) {
    if (number % i == 0) {
        jsConsole.writeLine("The number is NOT prime.");
        prime = false;
        break;
    }
}

if (prime) {
    jsConsole.writeLine("The number IS prime");
}

jsConsole.writeLine("");
//#endregion

//#region 8
jsConsole.write("08. ");
var a = 5, b = 7, h = 3;

var trapezoidArea = ((a + b) * h) / 2;
jsConsole.writeLine("The trapezoid area is:" + trapezoidArea);

jsConsole.writeLine("");
//#endregion

//#region 9
jsConsole.write("09. ");

var x = 2, y = 0;
jsConsole.write("The point x:" + x + " y:" + y + " is");


if ((Math.sqrt(Math.pow((x-1),2)+Math.pow((y-1),2)))<3) {
    jsConsole.write(" IN the circle");
} else {
    jsConsole.write(" OUT of the circle");
}

if (x>-1 && x<5 && y<1 && y>-1) {
    jsConsole.writeLine(" and IN the rectangle.");
} else {
    jsConsole.writeLine(" and OUT of the rectangle.");
}

jsConsole.writeLine("");
//#endregion