function Solve(input) {
    input = input.map(Number);
    var currentMax, max = input[1];

    for (var i = 1; i < input.length; i++) {
        for (var j = i; j < input.length; j++) {
            currentMax = 0;

            for (var k = i; k <=j; k++) {
                currentMax += input[k];
            }

            if (currentMax > max) {
                max = currentMax;
            }
        }
    }

    return max;
}