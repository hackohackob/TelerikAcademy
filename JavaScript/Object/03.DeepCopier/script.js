Object.prototype.deepCopy = function () {
    var returningObject = {}

    for (var prop in this) {
        if(this.hasOwnProperty(prop)){
            returningObject[prop] = this[prop];
        }
    }

    return returningObject;
}

var a = {};
a.first = 1;
a.second = 2;
a.third = 3;
var b = a.deepCopy();

console.log(a);
console.log(b);
