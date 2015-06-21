function solve(params) {
    var s = params[0], c1 = params[1], c2 = params[2], c3 = params[3];
    var answer = -1;

    for (var count1 = 0; count1 <= (s / c1) + 1; count1++) {
        for (var count2 = 0; count2 <= (s / c2) + 1; count2++) {
            for (var count3 = 0; count3 <= (s / c3) + 1; count3++) {
                var total = (c1 * count1) + (c2 * count2) + (c3 * count3);
                if (total <= s && total > answer) {
                    answer = total;
                }
            }
        }
    }

    console.log(answer);
}


