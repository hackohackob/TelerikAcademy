function Person(fName, lName, age) {
    return {
        firstname: fName,
        lastname: lName,
        age:age
    }
}

function getOldestPerson(array) {
    var maxAge = 0, maxIndex = 0;
    for(var i=0;i<array.length;i++){
        if (array[i].age > maxAge) {
            maxAge = array[i].age;
            maxIndex = i;
        }
    }

    console.log("Oldest person:{ First name:"+array[maxIndex].firstname+", Last name:"+array[maxIndex].lastname+", Age:"+array[maxIndex].age+" }");
}

var personArray = [];
personArray.push(Person("Georgi", "Georgiev", 18));
personArray.push(Person("Ivan", "Ivanov", 12));
personArray.push(Person("Atanas", "Atanasov", 19));
personArray.push(Person("Petyr", "Petrov", 34));


getOldestPerson(personArray);