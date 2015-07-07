/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {
    //var data={};
    var Course = {
        data: {},
        init: function (title, presentations) {
            this.data.presentionCurrentID = 0;
            this.data.studentsCurrentID = 0;
            this.data.students = [];
            this.data.presentions = [];

            title = title || '';
            if (!Array.isArray(presentations) || presentations.length < 1) {
                throw new Error('invalid presentations');
            }
            var titleRegex = /^[^ ]( {1}[^ ]|[^ ])*$/;

            if (titleRegex.test(title)) {
                this.data.title = title;
            } else {
                throw new Error('invalid data');
            }
            for (var presentation in presentations) {
                if (titleRegex.test(presentations[presentation])) {
                    this.data.presentions = this.data.presentions || [];
                    this.data.presentions.push({
                        id: ++this.data.presentionCurrentID,
                        name: presentations[presentation]
                    });
                } else {
                    throw new Error('invalid data');
                }
            }

            return this;
        },
        addStudent: function (name) {
            if (typeof(name) !== 'string') {
                throw Error('Invalid name')
            }
            if ((/^[A-Z][a-z]* [A-Z][a-z]*$/).test(name)) {
                name = name.split(' ');
                this.data.students = this.data.students || [];
                this.data.students.push({firstname: name[0], lastname: name[1], id: ++this.data.studentsCurrentID});
            } else {
                throw new Error('invalid name');
            }
            return this.data.studentsCurrentID;
        },
        getAllStudents: function () {
            if (Array.isArray(this.data.students)) {
                return this.data.students.slice();
            } else {
                return [];
            }
        },
        submitHomework: function (studentID, homeworkID) {
            studentID = +studentID;
            homeworkID = +homeworkID;
            if (isNaN(studentID) || isNaN(homeworkID) || studentID <= 0 || homeworkID <= 0 || studentID > this.data.studentsCurrentID || homeworkID > this.data.presentionCurrentID) {
                throw Error('Invalid data');
            } else {
                this.data.students.homeworks = this.data.students.homeworks || [];
                this.data.students.homeworks.push(homeworkID);
            }
        },
        pushExamResults: function (results) {

            if(!results || !(Array.isArray(results)) || results.length<1 ){
                throw Error('invalid data');
            } else {
                var arrayID=[],
                    studentsWithScore=[];
                results.forEach(function(singleResult){
                    arrayID[singleResult.StudentID]=1;
                    if(!results[singleResult].StudentID
                        || isNaN(results[singleResult].StudentID)
                        || results[singleResult].StudentID<0
                        || results[singleResult].StudentID>this.data.studentsCurrentID
                        || !results[singleResult].score
                        || isNaN(results[singleResult].score)
                    ){
                        throw Error('invalid data');
                    }
                });
                arrayID=arrayID.filter(function(item){
                    return item;
                })

                if(arrayID.length<results.length){
                    throw Error('CHEATER!');
                }

                results.forEach(function(singleResult){
                   studentsWithScore[singleResult]=singleResult.score;
                });

                console.log(studentsWithScore);

                this.data.students.forEach(function(currentStudent){
                    console.log(currentStudent);
                   //if(studentsWithScore[currentStudent.id]){
                   //    this.data.students[currentStudent].score = studentsWithScore[currentStudent.id];
                   //} else {
                   //    this.data.students[currentStudent].score = 0;
                   //}
                });

                return this;
            }
        },
        getTopStudents: function () {

        }
    };
    return Course;
}

var Course = solve();

var jsoop = Object.create(Course).init('SOmething', ['Something else', 'here']);
//jsoop.addStudent(getValidName() + ' ' + getValidName());
//jsoop.addStudent(getValidName() + ' ' + getValidName())
//jsoop.addStudent(getValidName() + ' ' + getValidName())
//jsoop.addStudent(getValidName() + ' ' + getValidName())




module.exports = solve;
