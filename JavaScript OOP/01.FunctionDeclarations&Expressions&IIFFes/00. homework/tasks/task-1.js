/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/
function solve() {

	return function sum(arr) {
		if (arguments.length < 1) throw Error('No arguments supplied');
		else if (!Array.isArray(arr)) return null;
		else if (arr.length < 1) return null;
		else {
			var sum = 0;
			arr.forEach(function (number) {
				number = number * 1;

				if (isNaN(number)) {
					throw Error('One of the elements of the array is not a number');
				} else {
					sum += number;
				}
			});
		}

		return sum;
	}
}


module.exports = solve();