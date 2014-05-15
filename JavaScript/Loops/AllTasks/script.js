/// <reference path="D:\TelerikAcademy\JavaScript\Loops\AllTasks\js-console/js-console.js" />

var a = [];

//#region 1
function oneToN() {
    jsConsole.writeLine("==== 1 ====================");
    var n = document.getElementById("input1").value;

    for (var i = 1; i < n; i++) {
        jsConsole.write(i + ", ");
    }

    jsConsole.writeLine(n);


    jsConsole.writeLine("===========================");

}
//#endregion


//#region 2
function notDivisible() {
    jsConsole.writeLine("==== 2 ====================");

    var n = document.getElementById("input2").value;

    for (var i = 1; i < n; i++) {
        if (i % 3 != 0 && i % 7 != 0) {
            jsConsole.write(i + ", ");
        }
    }

    jsConsole.writeLine(n);


    jsConsole.writeLine("===========================");
}
//#endregion

//#region 3
function maxAndMin(input) {
    if (input == 0) {
        var n = parseInt(document.getElementById("input3").value);
        a.push(n);
    } else {
        jsConsole.writeLine("==== 3 ====================");
        var min = a[0], max = a[0];

        for (var i = 0, len = a.length; i < len; i++) {
            if (parseInt(a[i]) > max) {
                max = a[i];
            }
            if (parseInt(a[i]) < min) {
                min = a[i];
            }
        }

        jsConsole.writeLine("Min:" + min + "  Max:" + max);
        jsConsole.writeLine("===========================");
    }
}
//#endregion

//#region 4
function lexicographicallyMinAndMax() {
    jsConsole.writeLine("==== 4 ====================");
    a = [];
    b = [];
    [document, window, navigator].forEach(function (object) {
        var properties = []

        for (properties[properties.length] in object);

        properties.sort();

        a.push(properties.shift());
        b.push(properties.pop());
    })

    jsConsole.write("document: ");
    jsConsole.write(a[0]+"   ");
    jsConsole.writeLine(b[0]);

    jsConsole.write("window: ");
    jsConsole.write(a[1] + "   ");
    jsConsole.writeLine(b[1]);

    jsConsole.write("navigator: ");
    jsConsole.write(a[2] + "   ");
    jsConsole.writeLine(b[2]);

    jsConsole.writeLine("===========================");
}
//#endregion

