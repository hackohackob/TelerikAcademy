var a = "1 2 5  7   2 3 3 4 2    42 3  42    45 6  4 56 as d      ds    da s d a    assas";

var array = a.split(" ");
console.log(array);

var returnNumbersOnly = array.filter(function (element) {
    if (element != " " && element == Number(element)) {
        return element;
    }
});

var returnStringsOnly = array.filter(function (element) {
    if(element!=" " && element!=Number(element)){
        return element;
    }
});

console.log(returnNumbersOnly+" \n\n"+returnStringsOnly);