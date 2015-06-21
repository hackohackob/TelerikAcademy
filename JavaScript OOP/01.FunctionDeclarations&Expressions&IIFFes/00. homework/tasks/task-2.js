/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/
function solve() {

    return function findPrimes(firstNumber, secondNumber) {

        if (arguments.length < 2 || isNaN(firstNumber * 1) || isNaN(secondNumber * 1)) {

            throw Error();
        } else {
            var firstNumber = firstNumber * 1,
                secondNumber = secondNumber * 1,
                primes = [];

            for (var i = firstNumber; i <= secondNumber; i += 1) {
                var prime = true;

                if (i === 0 || i === 1) {
                    prime = false

                }
                for (var j = 2; j < i; j += 1) {
                    if (i % j === 0) {
                        prime = false;
                        break;
                    }
                }

                if (prime) primes.push(i);

            }

            return primes;
        }
    }
}

console.log(solve(0,30));

module.exports = solve();
