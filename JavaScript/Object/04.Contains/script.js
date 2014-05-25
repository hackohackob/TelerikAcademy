Object.prototype.hasProperty=function (prop){
    for (var property in this) {
        if (property.toString() == prop) {
            return true;
        }
    }

    return false;
}


function hasProperty(obj, prop) {
    for (var property in obj) {
        if (obj.hasOwnProperty(prop)) {
            return true;
        }
    }

    return false;
}

//var a = window;
var b = {
    length: 9,
    width: 100,
    size: "big",
    course:"JavaScript"
};

console.log(b.hasProperty('size'));
console.log(b.hasProperty('sizes'));

console.log(hasProperty(b, 'size'));
console.log(hasProperty(b, 'sizes'));
