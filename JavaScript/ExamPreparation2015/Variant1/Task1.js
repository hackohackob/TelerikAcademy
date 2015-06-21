function solve(params) {
    var s = params[0];
    var count = 0;

    for (var count3 = 0; count3 <= (s / 3)+1; count3++) {
        for (var count4 = 0; count4 <= (s / 4)+1; count4++) {
            for (var count10 = 0; count10 <= (s / 10)+1; count10++) {
                if (((count3 * 3) + (count4 * 4) + (count10 * 10)) === s) {
                    count++;
                }
            }
        }
    }

    console.log(count);
}
