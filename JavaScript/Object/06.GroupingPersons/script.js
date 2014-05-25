function Person(fName, lName, age) {
    return {
        firstname: fName,
        lastname: lName,
        age: age
    }
}

function group(persons, groupingCriteria) {
    var groupedPersonsArray = [];

    if (groupingCriteria=='age') {
        groupByAge(persons);
    } else if (groupingCriteria=='firstname') {
        groupByFirstName(persons);
    }

    function groupByAge(persons) {
        for (var i = 0; i < persons.length; i++) {
            var ageToString = persons[i].age.toString();
            //console.log(ageToString);
            if (groupedPersonsArray.hasOwnProperty(ageToString)) {
                groupedPersonsArray[ageToString].push(persons[i]);
            } else {
                groupedPersonsArray[ageToString] = [];

                groupedPersonsArray[ageToString].push(persons[i]);
            }
        }

        //for (var i = 0; i < groupedPersonsArray; i++) {
        //    if (groupedPersonsArray[i]=="") {

        //    }
        //}
    }

    function groupByFirstName(persons) {
        for (var i = 0; i < persons.length; i++) {
            if (groupedPersonsArray.hasOwnProperty(persons[i].firstname)) {
                groupedPersonsArray[persons[i].firstname].push(persons[i]);
            } else {
                groupedPersonsArray[persons[i].firstname] = [];

                groupedPersonsArray[persons[i].firstname].push(persons[i]);
            }
        }
    }

    return groupedPersonsArray;
}

var personArray = [];
personArray.push(Person("Georgi", "Georgiev", 18));
personArray.push(Person("Ivan", "Ivanov", 12));
personArray.push(Person("Atanas", "Atanasov", 19));
personArray.push(Person("Petyr", "Petrov", 34));
personArray.push(Person("Georgi", "Stoykov", 50));
personArray.push(Person("Borislav", "Borisov", 12));
personArray.push(Person("John", "Atanasov", 100));

var groupedByAge = group(personArray, 'age');
var groupByFirstName = group(personArray, 'firstname');
console.log(groupedByAge);
console.log(groupByFirstName);