function solve() {
    var helpers = {
        findCollectionByParam: function (paramName, param, collection) {
            var i, len;
            for (i = 0, len = collection.length; i < len; i += 1) {
                if (collection[i][paramName] === param) {
                    return i;
                }
            }

            return -1;
        },
        getSortingFunction: function (param1, param2) {
            return function (x, y) {
                if (x[param1] < y[param1]) {
                    return -1;
                } else if (x[param1] > y[param1]) {
                    return 1;
                } else {
                    if (x[param2] < y[param2]) {
                        return -1;
                    } else if (x[param2] > y[param2]) {
                        return 1;
                    } else {
                        return null;
                    }
                }
            }
        }
    };
    var validator = {
        validateUndefined: function (value) {
            if (value === undefined) {
                throw new Error('Value is undefined!');
            }
        },
        validateString: function (value) {
            this.validateUndefined(value);
            if (typeof value !== 'string') {
                throw new Error('Value is not a string!');
            }
        },
        validateStringWithMinMax: function (value, min, max) {
            this.validateString(value);
            if(value.length<min || value.length>max){
                throw new Error('String is shorter/longer than expected');
            }
        },
        validateNumber: function (value) {
            this.validateUndefined(value);
            if (typeof value !== 'number') {
                throw new Error('Value is not a number!');
            }
        },
        validatePositiveNumber: function (value, andZero) {
            this.validateNumber(value);
            if ((value <= 0 && !andZero) || (value < 0 && andZero)) {
                throw new Error('Value is not a positive number!');
            }
        },
        validatePageAndSize: function (page, size, max) {
            this.validateUndefined(page);
            this.validateUndefined(size);
            this.validateNumber(page);
            this.validateNumber(size);
            if (page < 0 || size <= 0 || page * size > max) {
                throw new Error('Paging parameters are invalid!');
            }
        }
    };


    var module = (function () {
        return {
            getObject: function () {

            },
            test: function () {
                var arr = [];
                for (var i = 0; i < 100; i++) {
                    arr.push({
                        id: Math.random() * 100 | 0,
                        name: helpers.getRandomString(1).toUpperCase() + helpers.getRandomString(9)
                    });
                }

                console.log(helpers.findIdInCollection('id', 13, arr));
            }
        };
    }());


    return module;

}


result = solve();
result.test();

module.exports = solve;

