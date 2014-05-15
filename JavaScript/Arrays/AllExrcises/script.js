function first() {
    jsConsole.writeLine("=== 1 ================");
    var array = Array(20);

    for (var i = 0, len = array.length; i < len; i++) {
        array[i] = i * 5;
        jsConsole.write(array[i]+" ");
    }
    jsConsole.writeLine();
    jsConsole.writeLine("======================");
}

function second() {
    jsConsole.writeLine("=== 2 ================");
    var chars1 = "sometexthere".split('');
    var chars2 = "anothertexthere".split('');

    var min=(chars1.length >chars2.length) ? chars2.length : chars1.length;
    for (var i = 0; i < min; i++) {
        var compared = chars1[i].charCodeAt(0) - chars2[i].charCodeAt(0);

        var result=compared>0 ? 'bigger' : compared<0 ? 'smaller' : 'equal';
        jsConsole.writeLine("index:" + i + "  " + result);
    }

    jsConsole.writeLine("======================");
}

function third() {
    jsConsole.writeLine("=== 3 ================");
    var array = "arrayofelements 2112332221".split("");
    var currentMax=0, max=0;
    for (var i = 0, len = array.length; i < len; i++) {
        currentMax = 0;
        for (var j = i ; j < len; j++) {
            if(array[j]==array[i]){
                currentMax++;

            } else {
                break;
            }
        }

        if (currentMax > max) {
            max = currentMax;
        }
    }

    jsConsole.writeLine(max);

    jsConsole.writeLine("======================");
}

function fourth() {
    jsConsole.writeLine("=== 4 ================");

    var array = "3234224".split("");
    var currentMax = 0, max = 0;
    for (var i = 0, len = array.length; i < len; i++) {
        currentMax = 0;
        for (var j = i ; j < len; j++) {
            if (parseInt(array[i]) == parseInt(array[j]-(j-i))) {
                currentMax++;

            } else {
                break;
            }
        }

        if (currentMax > max) {
            max = currentMax;
        }
    }

    jsConsole.writeLine(max);
    jsConsole.writeLine("======================");
}

function fifth() {
    jsConsole.writeLine("=== 5 ================");
    var array = "9 123 34 5 76 45 23 1 -10 -23".split(" ");
    var startArray = array.slice();
    var helpArray = [];

    var min;
    var minIndex = 0;
    
    for (var i = 0, len = array.length; i < len; i++) {
        min = Number.MAX_VALUE;
        for (var j = 0; j < len; j++) {
            if (parseInt(array[j]) < min) {
                min = parseInt(array[j]);
                minIndex = j;
            }
        }

        helpArray.push(min);
        array[minIndex] = undefined;
    }
    jsConsole.writeLine(startArray);
    jsConsole.writeLine(helpArray);

    jsConsole.writeLine("======================");
}

function sixth() {
    jsConsole.writeLine("=== 6 ================");
    
    var array = "4 1 1 4 2 3 4 4 1 2 4 9 3".split(" ");
    var max = 0, current = 0, maxNumber = 0;

    for (var i = 0,len=array.length; i < len; i++) {
        current=0;
        for (var j = i; j < len; j++) {
            if (array[j] == array[i]) {
                current++;
            }
        }
        
        if (current > max) {
            max = current;
            maxNumber = array[i];
        }
    }

    jsConsole.writeLine(maxNumber + " (" + max + " times)");

    jsConsole.writeLine("======================");
}

function seventh() {
    jsConsole.writeLine("=== 7 ================");
    var array = "1 4 8 20 25 50 60 63 54 123 235 390 480 501 705 1006 2007 3008 3570 3760".split(" ");
    var numberToSearch = 480;

    var left = 0,right=array.length;
    var middle = (left+right)/2;

    while (true) {
        var middle = Math.floor((left + right) / 2);

        if (parseInt(array[middle]) == numberToSearch) {
            jsConsole.write("Index found:" + middle);

            return;
        } else if(parseInt(array[middle]) > numberToSearch) {
            right = middle;
        } else {
            left = middle;
        }
    }

    jsConsole.writeLine("======================");
}
