var module = (function(){
    var privateProp = 5,
        privateMethod = function(number){
            return privateProp + number;
        };

    return {
        publicProp:5,
        publicMethod:function(){
            return(this.publicProp);
        },
        usePrivateMethod: function(number){
            return privateMethod(number);
        }
    }
}());

console.log(module);
console.log(module.publicProp);
console.log(module.publicMethod());
console.log(module.usePrivateMethod(module.publicProp));