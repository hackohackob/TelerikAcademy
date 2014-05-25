Array.prototype.remove = function (number) {
    for (var element in this) {
        if (this[element] === number) {
            this.splice(element, 1);
        }
    }
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
console.log(arr);

arr.remove(1);
console.log(arr);


