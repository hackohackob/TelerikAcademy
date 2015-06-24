var db =(function(){
    var objs = [],
        result;
    
    function add(obj){
        objs.push(obj);
        return result;
    }

    function list(){
        return objs.slice();
    }

    result = {
        add:add,
        list:list
    }

    return result;
}());


db.add('1');
db.add('2');
db.add('3').add('4');
db.add('5').list = function(){return 'hacked'};
console.log(db.list());
