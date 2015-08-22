function solve() {
    var globalId = 0;
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
        getSortingFunction: function (param1, param2, param3) {
            param2 = param2 || false;
            param3 = param3 || false;
            return function (x, y) {
                if (x[param1] < y[param1]) {
                    return -1;
                } else if (x[param1] > y[param1]) {
                    return 1;
                } else {
                    if (param2) {
                        if (x[param2] < y[param2]) {
                            return -1;
                        } else if (x[param2] > y[param2]) {
                            return 1;
                        } else {
                            if (param3) {
                                if (x[param3] < y[param3]) {
                                    return -1;
                                } else if (x[param3] > y[param3]) {
                                    return 1;
                                } else {
                                    return null;
                                }
                            } else {
                                return null;
                            }
                        }
                    } else {
                        return null;
                    }
                }
            }
        }
    };
    var validator = {
        validateUndefined: function (value, name) {
            name = name || 'Value';
            if (value === undefined) {
                throw new Error(name + ' is undefined!');
            }
        },
        validateString: function (value, name) {
            name = name || 'Value';
            this.validateUndefined(value);
            var typeOfValue = typeof value;
            if (typeOfValue !== 'string') {
                throw new Error(name + ' is not a string(validate string)!');
            }
        },
        validateNonEmptyString: function (value, name) {
            name = name || 'Value';
            this.validateString(value);
            //TODO:
            value = value.trim();
            if (value.length < 1) {
                throw new Error(name + ' cannot be empty string!');
            }
        },
        validateStringWithMinMax: function (value, min, max, name) {
            name = name || 'Value';
            this.validateString(value);
            if (value.length < min || value.length > max) {
                throw new Error(name + ' is shorter/longer than expected');
            }
        },
        validateNumber: function (value, name) {
            name = name || 'Value';
            this.validateUndefined(value);
            if (typeof value !== 'number') {
                throw new Error(name + ' is not a number!');
            }
        },
        validatePositiveNumber: function (value, andZero, name) {
            name = name || 'Value';
            this.validateNumber(value);
            if ((value <= 0 && !andZero) || (value < 0 && andZero)) {
                throw new Error(name + ' is not a positive number!');
            }
        },
        validateIsbn: function (value, name) {
            name = name || 'Value';
            validator.validateUndefined(value);
            validator.validateStringWithMinMax(value, 10, 13);
            if (value.length !== 10 && value.length !== 13) {
                throw new Error(name + ' is not a valid ISBN (length)');
            }
            var isbnRegex = /^(\d{10}|\d{13})$/;
            if (!isbnRegex.test(value)) {
                throw new Error(name + ' is not a valid ISBN');
            }

        },
        validateRating: function (value, name) {
            name = name || 'Value;'
            this.validateNumber(value, name);
            if (value < 1 || value > 5) {
                throw new Error('Invalid ' + name);
            }
        },
        validateItem: function (singleItem, name) {
            name = name || 'Value';

            validator.validateUndefined(singleItem);
            validator.validateUndefined(singleItem.id);
            validator.validateNumber(singleItem.id);
            validator.validateStringWithMinMax(singleItem.name, 2, 40, 'Item name');
            validator.validateNonEmptyString(singleItem.description, 'Item description');
        },
        validateBook: function (singleItem, name) {
            name = name || 'Value';
            console.log('validated book');
            validator.validateUndefined(singleItem);
            validator.validateUndefined(singleItem.id);
            validator.validateNumber(singleItem.id);
            validator.validateStringWithMinMax(singleItem.name, 2, 40, 'Book name');
            validator.validateNonEmptyString(singleItem.description, 'Book description');
            validator.validateIsbn(singleItem.isbn, 'Book isbn');
            validator.validateStringWithMinMax(singleItem.genre, 2, 20, 'Book Genre');
        },
        validateMedia: function (singleItem, name) {
            name = name || 'Value';

            validator.validateUndefined(singleItem);
            validator.validateUndefined(singleItem.id);
            validator.validateNumber(singleItem.id);
            validator.validateStringWithMinMax(singleItem.name, 2, 40, 'Item name');
            validator.validateNonEmptyString(singleItem.description, 'Item description');
            validator.validateRating(singleItem.rating, 'Media rating');
            validator.validatePositiveNumber(singleItem.duration, false, 'Media duration');
        },
        validatePageAndSize: function (page, size, max, name) {
            name = name || 'Value';
            this.validateUndefined(page);
            this.validateUndefined(size);
            this.validateNumber(page);
            this.validateNumber(size);
            if (page < 0 || size <= 0 || page * size > max) {
                throw new Error(' parameters are invalid!');
            }
        }
    };

    //ITEMS

    var item = (function () {
        var itemId = 0,
            item = Object.create({});
        Object.defineProperties(item, {
            init: {
                value: function (name, description) {
                    this.description = description;
                    this.name = name;
                    this._id = ++globalId;

                    return this;
                }
            },
            id: {
                get: function () {
                    return this._id;
                }
            },
            description: {
                get: function () {
                    return this._description;
                },
                set: function (value) {
                    validator.validateNonEmptyString(value, 'Item description');
                    this._description = value;
                }
            },
            name: {
                get: function () {
                    return this._name;
                },
                set: function (value) {
                    validator.validateStringWithMinMax(value, 2, 40, 'Item name');
                    this._name = value;
                }
            }
        });

        return item;
    }());

    var book = (function (parent) {
        var book = Object.create(item);
        Object.defineProperties(book, {
            init: {
                value: function (name, isbn, genre, description) {
                    parent.init.call(this, name, description);
                    this.isbn = isbn;
                    this.genre = genre;

                    return this;
                }
            },
            isbn: {
                get: function () {
                    return this._isbn;
                },
                set: function (value) {
                    validator.validateIsbn(value, 'Book ISBN');
                    this._isbn = value;
                }
            },
            genre: {
                get: function () {
                    return this._genre;
                },
                set: function (value) {
                    validator.validateStringWithMinMax(value, 2, 20, 'Book Genre');
                    this._genre = value;
                }

            }
        });
        return book;
    }(item));

    var media = (function (parent) {
        var media = Object.create(item);
        Object.defineProperties(media, {
            init: {
                value: function (name, rating, duration, description) {
                    parent.init.call(this, name, description);
                    this.rating = rating;
                    this.duration = duration;

                    return this;
                }
            },
            rating: {
                get: function () {
                    return this._rating;
                },
                set: function (value) {
                    validator.validateRating(value, 'Media rating');
                    this._rating = value;
                }
            },
            duration: {
                get: function () {
                    return this._duration;
                },
                set: function (value) {
                    validator.validatePositiveNumber(value, false, 'Media duration');
                    this._duration = value;
                }

            }
        });
        return media;
    }(item));

    //CATALOGS

    var catalog = (function () {
        var catalogId = 0,
            catalog = Object.create({});

        Object.defineProperties(catalog, {
            init: {
                value: function (name) {
                    this._id = ++globalId;
                    this.name = name;
                    this.items = [];

                    return this;
                }
            },
            id: {
                get: function () {
                    return this._id;
                }
            },
            name: {
                get: function () {
                    return this._name;
                },
                set: function (value) {
                    validator.validateStringWithMinMax(value, 2, 40, 'Catalog name');
                    this._name = value;
                }
            },
            items: {
                get: function () {
                    return this._items;
                },
                set: function (value) {
                    this._items = value;
                }
            },
            add: {
                value: function (arrayOrFirst, second) {
                    var args;
                    second = second || undefined;
                    if (Array.isArray(arrayOrFirst)) {
                        args = arrayOrFirst;
                    } else {
                        args = Array.prototype.slice.call(arguments);
                    }

                    if (args.length < 1) {
                        throw new Error('No items passed!');
                    }
                    //if(this.getGenres){
                    //     args.forEach(function (singleItem) {
                    //        validator.validateBook(singleItem);
                    //
                    //    });
                    //} else if(this.getTop){
                    //     args.forEach(function (singleItem) {
                    //        validator.validateMedia(singleItem);
                    //    });
                    //} else  {
                    args.forEach(function (singleItem) {
                        validator.validateItem(singleItem);

                    });
                    //}

                    this.items = this.items.concat(args);
                }
            },
            find: {
                value: function (idOrOptions) {
                    if (typeof idOrOptions === 'object') {
                        var id = idOrOptions.id;
                        var name = idOrOptions.name;
                        //TODO: isbn, genre, duration, rating
                        var result = this.items.slice();
                        if (id) {
                            result = result.filter(function (item) {
                                if (item.id === id) {
                                    return true;
                                } else {
                                    return false;
                                }
                            });
                        }
                        if (name) {
                            result = result.filter(function (item) {
                                if (item.name.toLowerCase() === name.toLowerCase()) {
                                    return true;
                                } else {
                                    return false;
                                }
                            });
                        }

                        return result;
                    } else if (typeof  idOrOptions === 'number') {
                        var index = helpers.findCollectionByParam('id', idOrOptions, this.items);
                        if (index < 0) {
                            return null;
                        } else {
                            return this.items[index];
                        }
                    } else {
                        throw new Error('ID is neither a object nor a number');
                    }
                }
            },
            search: {
                value: function (pattern) {

                    validator.validateStringWithMinMax(pattern, 1, Number.MAX_VALUE, 'Pattern ');
                    pattern = pattern.toLowerCase();

                    var result = this.items;

                    result = result.filter(function (item) {
                        if (item.name.toLowerCase().indexOf(pattern) >= 0 ||
                            item.description.toLowerCase().indexOf(pattern) >= 0) {
                            return true;
                        } else {
                            return false;
                        }
                    });

                    return result;

                }
            }
        });

        return catalog;
    }());

    var bookCatalog = (function (parent) {
        var bookCatalog = Object.create(parent);

        Object.defineProperties(bookCatalog, {
            init: {
                value: function (name) {
                    parent.init.call(this, name);
                    return this;
                }
            },
            add: {
                value: function (arrayOrFirst) {
                    var args;
                    if (Array.isArray(arrayOrFirst)) {
                        args = arrayOrFirst;
                    } else {
                        args = Array.prototype.slice.call(arguments);
                    }

                    if (args.length < 1) {
                        throw new Error('No items passed!');
                    }
                    args.forEach(function (singleItem) {
                        validator.validateItem(singleItem);
                    });
                    parent.add.apply(this, arguments);
                }
            },
            getGenres: {
                value: function () {
                    var genres = [];
                    this.items.forEach(function (item) {
                        genres[item.genre.toLowerCase()] = 1;
                    });

                    var genresToReturn = [];

                    for (var key in genres) {
                        genresToReturn.push(key);
                    }
                    return genresToReturn;
                }
            },
            find: {
                value: function (options) {
                    var parentFiltered = parent.find.call(this, options);
                    if (options.genre) {
                        parentFiltered = parentFiltered.filter(function (item) {
                            if (item.genre && item.genre.toLowerCase() === options.genre.toLocaleLowerCase()) {
                                return true;
                            } else {
                                return false;
                            }
                        });
                    }
                    return parentFiltered;
                }
            }

        });

        return bookCatalog;
    }(catalog));

    var mediaCatalog = (function (parent) {
        var mediaCatalog = Object.create(parent);

        Object.defineProperties(mediaCatalog, {
            init: {
                value: function (name) {
                    parent.init.call(this, name);
                    return this;
                }
            },
            add: {
                value: function (arrayOrFirst) {
                    parent.add.apply(this, arguments);
                }
            },
            getTop: {
                value: function (count) {
                    if(!count || typeof count!=='number' || count<1){
                        throw new Error('Coun err');
                    }
                    return this.items
                        .sort(function(x,y){
                           if(x.rating> y.rating){
                               return -1;
                           }else if(x.rating< y.rating){
                               return 1;
                           }else {
                               return 0;
                           }
                        })
                        .filter(function (item) {
                            if (item.rating) {
                                return true;
                            } else {
                                return false
                            }
                        })
                        .map(function (item) {
                            return {
                                id: item.id,
                                name: item.name
                            }
                        })
                        .slice(0, count);
                }
            },
            getSortedByDuration:{
                value:function(){
                    return this.items
                        .sort(function(x,y){
                             if(x.duration> y.duration){
                                 return -1;
                             }else if(x.duration< y.duration){
                                 return 1;
                             } else {
                                 if(x.id> y.id){
                                     return 1;
                                 }else if(x.id< y.id){
                                     return -1;
                                 } else {
                                       return 0;
                                 }
                             }
                        });
                }
            }
        });

        return mediaCatalog;
    }(catalog));


    var module = (function () {
        return {
            getBook: function (name, isbn, genre, description) {
                return Object.create(book).init(name, isbn, genre, description);
            },
            getMedia: function (name, rating, duration, description) {
                return Object.create(media).init(name, rating, duration, description);
            },
            getBookCatalog: function (name) {
                return Object.create(bookCatalog).init(name);
            },
            getMediaCatalog: function (name) {
                return Object.create(mediaCatalog).init(name);
            }
        };
    }());

    return module;

}


var module = solve();

var book1 = module.getBook("Book1Name", '1234567890123', '123', 'asd');
var media1 = module.getMedia('Media1Name', 5, 1.5, 'asdescription');
var media2 = module.getMedia('Media1Name', 1.5, 1.5, 'asdescription');
var media3 = module.getMedia('Media1Name', 3.92, 2, 'asdescription');
var media4 = module.getMedia('Media1Name', 4, 3, 'asdescription');
var catalog1 = module.getMediaCatalog('Catalog1');
catalog1.add(book1, media1,media2,media3,media4);

console.log(catalog1.getSortedByDuration());
console.log()
//console.log(catalog1.items);


//var catalog = module.getBookCatalog('John\'s catalog');

//var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
//var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
//catalog.add(book1);
//catalog.add(book2);

//console.log('================== 1 ==================');
//console.log(catalog.find(book1.id));
////returns book1
//
//
//console.log('================== 2 ==================');
//console.log(catalog.find({id: book2.id, genre: 'IT'}));
////returns book2
//
//console.log('================== 3 ==================');
//console.log(catalog.search('js'));
//// returns book2
//
//console.log('================== 4 ==================');
//console.log(catalog.search('javascript'));
////returns book1 and book2
//
//
//console.log('================== 5 ==================');
//console.log(catalog.search('Te sa zeleni'))

module.exports = solve;

