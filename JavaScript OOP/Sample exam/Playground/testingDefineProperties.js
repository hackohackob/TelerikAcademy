var vehicle = (function () {
    var vehicle = {};
    Object.defineProperties(vehicle, {
        init: {
            value: function (name) {
                this.name = name;
                return this;
            }
        },
        toString: {
            value: function () {
                return 'I am a VEHICLE and my name is: ' + this.name;
            }
        }
    });

    return vehicle;
}());

var car = (function (parent) {
    var car = Object.create(parent);

    Object.defineProperties(car, {
        init: {
            value: function (name, wheels) {
                parent.init.call(this, name);
                this.wheels = wheels;
                return this;
            }
        },
        wheels: {
            get: function () {
                return this._wheels;
            },
            set: function (value) {
                if (isNaN(+value)) {
                    throw new Error('Invalid number of wheels');
                }
                this._wheels = value;
            }
        },
        _wheels: {
            writable: true,
            configurable: false,
            enumerable: false,
            value: null
        },
        toString: {
            value: function () {
                return 'I am a CAR with ' + this.wheels + ' wheels and my name is: ' + this.name;
            }
        }
    });


    return car;
}(vehicle));

var cat = (function () {
    var cat = {};
    Object.defineProperties(cat, {
        init: {
            value: function (name) {
                this.name = name;
                return this;
            }
        },
        name:{
            value:'Unnamed',
            writable:true,
            configurable:false
        },
        sayName:{
            value:function(){
                console.log('My name is '+this.name);
            }
        }
    });

    return {
        init:function(name){
            return Object.create(cat).init(name);
        }
    }
}());


var Peci = cat.init('Peci');
var Sisa = cat.init('Sisa');
//console.log(Peci===Sisa);
//Peci.sayName();
//Sisa.sayName();

var cat2 = (function () {
    var cat2 = {};
    Object.defineProperties(cat2, {
        init: {
            value: function (name) {
                this.name = name;
                return this;
            }
        },
        name:{
            value:'Unnamed',
            writable:true,
            configurable:false
        },
        sayName:{
            value:function(){
                console.log('My name is '+this.name);
            }
        }
    });

    return Object.create(cat2);
}());


var Peci2 = cat2.init('Peci2');
var Sisa2 = cat2.init('Peci2');
console.log(Peci2===Sisa2);
Peci2.sayName2 = function(){
    console.log( '2'+this.name);
}


Peci2.sayName();
Sisa2.sayName();
Peci2.sayName2();
Sisa2.sayName2();
//var boat = Object.create(vehicle).init('lodkata mi');
//var boat2 = Object.create(vehicle).init('lodkata mi2');
//var bmw = Object.create(car).init('BMWto mi', 4);
//console.log(bmw.toString())
//console.log(bmw)