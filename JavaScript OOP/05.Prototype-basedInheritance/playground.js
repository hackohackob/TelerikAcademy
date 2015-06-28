var vehicle = (function(){
    var vehicle = Object.create(Object.prototype);
    var self=this;

    Object.defineProperties(vehicle,{
        init:{
          value:function(typeCode,year){
              this.typeCode=typeCode;
              this.year=year;
              return this;
          }
        },
        typeCode:{
           get:function(){
               return this._typeCode
           },
           set:function(value){
               if(value>0 && value<4){
                   this._typeCode = value;
               }else{
                   throw new RangeError('The value of the type code is not in the valid range: [1-3]!');
               }
           }
       },
        types:{
            value:['land','air','water']
        },
        year:{
            value:undefined,
            configurable:true
        },
        type:{
            get:function(){
                return this.types[this.typeCode-1];
            }
        }
    });

    return vehicle

}());

var boat = Object.create(vehicle);

var boat1 = boat.init(1, 2005);

console.log(boat1.type);
boat1.type='water';
console.log(boat1.type);
