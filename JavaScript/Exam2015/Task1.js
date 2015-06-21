function solve(args) {
    var nk = args[0].split(' ').map(Number),
        s = args[1].split(' ').map(Number),
        result=0;
    var n = nk[0];
    var k = nk[1];

    for (var i = 0; i < k; i++) {
        s = change(s);
    }

    for (var i = 0; i < s.length; i++) {
        result+=s[i];

    }
    console.log(result);


    function change(si) {
        var s1=[];

        for (var j = 0; j < si.length; j++) {
            var previous = j - 1;
            var next = j + 1;

            if (previous < 0) {previous = si.length - 1;}
            if (next >= si.length){ next = 0;}

            //console.log(si);
            //console.log(si[j]);
            //console.log('pi:'+previous);
            //console.log('ni:'+next);
            //console.log('p:'+si[previous]);
            //console.log('n:'+si[next]);
            if (si[j] === 0) {
                s1[j] = Math.abs((si[previous]-si[next]));
            } else if (si[j] % 2 === 0) {
                s1[j] = Math.max(si[previous],si[next]);
            } else if (si[j] === 1) {
                s1[j] = si[previous] + si[next];
            } else if (si[j] % 2 !== 0) {
                s1[j] = Math.min(si[previous],si[next]);
            }
            //console.log('.'+s1[j]);
        }
        //console.log(s1);
        return s1;
    }
}

var input1 = [
    '5 1',
    '9 0 2 4 1'
];

solve(input1);
