function first() {
    var integer = 5;
    var floating = 5.6;
    var floating2 = 3.4E2;
    var octa = 010;
    var hex = 0x10;
    var boolTrue = true;
    var boolFalse = false;
    var array = [1, 2, 3, "4", "5", "6"];
    var undefinedVar = undefined;
    var nullVar = null;
    var string = "Hello, World!";

    document.getElementById("all-variables").innerHTML += typeof (integer) + ": " + integer + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (floating) + ": " + floating + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (floating2) + ": " + floating2 + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (octa) + ": " + octa + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (hex) + ": " + hex + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (boolTrue) + ": " + boolTrue + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (boolFalse) + ": " + boolFalse + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (array) + ": " + array + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (undefinedVar) + ": " + undefinedVar + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (nullVar) + ": " + nullVar + "<br/>";
    document.getElementById("all-variables").innerHTML += typeof (string) + ": " + string + "<br/>";
}

function second() {
    var text = '\'How you doin\'?\', Joey said.';
    document.getElementById("string").innerHTML += text;
}


function fourth() {
    var nullVar = null;
    var undefinedVar = undefined;
    document.getElementById("null-undefined").innerHTML += "typeof null: " + typeof (nullVar)+"<br/>";
    document.getElementById("null-undefined").innerHTML += "typeof undefined: " + typeof (undefined) + "<br/>";
}