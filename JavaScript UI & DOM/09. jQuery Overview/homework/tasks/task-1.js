/* globals $ */

/* 

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/

function solve() {
    return function (selector, count) {
        validation(selector,count);

       if($(selector)===null){
           throw  new Error('asd');
           return;
       }

        var ul = $('<ul />');
        ul.addClass('items-list');
        for (var i = 0; i < count-0; i++) {
            ul.append($('<li />')
                .addClass('list-item')
                .html('List item #' + i));
        }

        $(selector).append(ul);

        function validation(selector, number) {
            if(typeof (selector) !== 'string'){
                throw new TypeError('Selector is not a string!');
            }

            if (!number) {
                throw new Error('Count is missing!');
            }

            if (isNaN(number)) {
                throw new TypeError('Count is not a number!');
            }

            if ((number - 0) < 1) {
                throw new RangeError('Count can\'t be less than one!');
            }
        }
    };
};

//module.exports = solve;