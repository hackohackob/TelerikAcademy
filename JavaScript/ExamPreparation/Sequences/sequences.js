function Solve(input) {

    input = input.map();
    var count = 0;

    for (var i = 2; i < input.length; i++) {
        if (input[i] < input[i - 1]) {
            count++;
        }
    }

    return count + 1;
}