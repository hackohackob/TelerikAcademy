/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person = (function (firstname, lastname, age) {

        Person.prototype.introduce=function (){
            return 'Hello! My name is '+this.fullname+' and I am '+this.age+'-years-old';
        };


		function Person(firstname, lastname, age) {
            var _firstname,
                _lastname,
                _age;

            if(!(/^[^0-9\W]{3,20}$/).test(firstname)
                || !(/^[^0-9\W]{3,20}$/).test(lastname)
                ||(+age<0 || +age>150)){
                throw Error('Invalid data');
            }else {
                this.firstname = firstname;
                this.lastname=lastname;
                this.age=age;
            }
		}
		
		return Person;
	} ());

    var simpleProperties =['firstname','lastname','age'],
        i,len;
    for(i=0,len=simpleProperties.length;i<len;i++){
        Object.defineProperty(Person.prototype,simpleProperties[i],{
            set:function(value){
                this['_'+simpleProperties[i]]=value;
            },
            get:function(){
                return this['_'+simpleProperties[i]];
            }
        })
    }

    //Object.defineProperty(Person.prototype,'firstname',{
    //    set:function(value){
    //        this._firstname=value;
    //    },
    //    get:function(){
    //        return this._firstname;
    //    }
    //});
    //Object.defineProperty(Person.prototype,'lastname',{
    //    set:function(value){
    //        this._lastname=value;
    //    },
    //    get:function(){
    //        return this._lastname;
    //    }
    //});
    //Object.defineProperty(Person.prototype,'age',{
    //    set:function(value){
    //        this._age=value;
    //    },
    //    get:function(){
    //        return this._age;
    //    }
    //});
    Object.defineProperty(Person.prototype,'fullname',{
        set:function(value){
            this.firstname=value.split(' ')[0];
            this.lastname=value.split(' ')[1];
        },
        get:function(){
            return this.firstname+' '+this.lastname;
        }
    });

	return Person;


}
module.exports = solve;

solve();
