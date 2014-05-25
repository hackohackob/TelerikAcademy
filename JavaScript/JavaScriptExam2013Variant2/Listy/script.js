function Solve(input) {
    var variables = {
        asd: 99,
        fgh: [1, 4, 5, 6, 7]
    };

    var finalResult;
    for (var i = 0; i < input.length; i++) {
        finalResult = rawLine(input[i]);
    }

    function rawLine(line) {
        if (line.slice(0, 3) === "def") {
            define(line.slice(4));
        } else {
            return returnOutput(line);
        }
    }
    function returnOutput(line) {
        if (line[0] != "[") {
            return calculateFunction(line);
        }
        else {
            var finalThing = line.slice(1, line.length - 1);
            if (isNaN(finalThing)) {
                return variables[finalThing];
            }
            else {
                return finalThing;
            }
        }
    }

    function define(line) {
        var name = line.slice(0, line.indexOf("[")+1);
        name = name.slice(0, name.indexOf(" "));
        var expression = line.slice(line.indexOf(name) + name.length);
        var resultedList;
        expression = expression.trim();

        if (expression.indexOf("[") == 3) {
            resultedList = calculateFunction(expression);
        } else if (expression.lastIndexOf("[") == 0) {
            resultedList = getList(expression);
        }

        variables[name] = resultedList;
    }

    function calculateFunction(expression) {
        var typeFunction = expression.slice(0, 3);
        var listOfNumbersString = expression.slice(3);
        var listofNumbers = getList(listOfNumbersString);
        var result;

        switch (typeFunction) {
            case "sum": result = calculateSum(listofNumbers); break;
            case "min": result = calculateMin(listofNumbers); break;
            case "max": result = calculateMax(listofNumbers); break;
            case "avg": result = calculateAvg(listofNumbers); break;
        }

        return result;
    }

    function getList(expression) {
        var allNumbers = expression.slice(1, expression.lastIndexOf("]"));
        var numbers = allNumbers.split(",");

        for (var i = 0; i < numbers.length; i++) {
            numbers[i] = numbers[i].trim();

            if (isNaN(numbers[i])) {
                var varName = numbers[i];
                numbers[i] = variables[varName];
            } else {
                numbers[i] = parseInt(numbers[i]);
            }
        }
        return numbers;
    }

    function calculateSum(numbers) {
        var sum = 0;

        for (var i = 0; i < numbers.length; i++) {
            if (variables.hasOwnProperty(numbers[i])) {
                numbers[i] = variables[numbers[i]];
            }
        }

        var nums = "n" + numbers;
        nums = nums.slice(1);
        nums = nums.split(",");

        for (var i = 0; i < nums.length; i++) {
            nums[i] = parseInt(nums[i]);
        }
        
        for (var i = 0; i < nums.length; i++) {
            sum += nums[i];
        }

        return sum;
    }

    function calculateMax(numbers) {
        for (var i = 0; i < numbers.length; i++) {
            if (variables.hasOwnProperty(numbers[i])) {
                numbers[i] = variables[numbers[i]];
            }
        }

        var nums = "n" + numbers;
        nums = nums.slice(1);
        nums = nums.split(",");
        
        for (var i = 0; i < nums.length; i++) {
            nums[i] = parseInt(nums[i]);
        }

        var max = nums[0];
        for (var i = 0; i < nums.length; i++) {
            if (nums[i] > max) {
                max = nums[i];
            }
        }

        return max;
    }

    function calculateMin(numbers) {
        for (var i = 0; i < numbers.length; i++) {
            if (variables.hasOwnProperty(numbers[i])) {
                
                numbers[i] = variables[numbers[i]];
            }
        }

        var nums = "n" + numbers;
        nums = nums.slice(1);
        nums = nums.split(",");
        
        for (var i = 0; i < nums.length; i++) {
            nums[i] = parseInt(nums[i]);
        }

        
        var min = nums[0];
        for (var i = 0; i < nums.length; i++) {
            if (nums[i] <min) {
                min = nums[i];
            }
        }

        return min;
    }

    function calculateAvg(numbers) {
        for (var i = 0; i < numbers.length; i++) {
            if (variables.hasOwnProperty(numbers[i])) {
                numbers[i] = variables[numbers[i]];
            }
        }

        var nums = "n" + numbers;
        nums = nums.slice(1);
        nums = nums.split(",");

        for (var i = 0; i < nums.length; i++) {
            nums[i] = parseInt(nums[i]);
        }

        var sum = 0, count = 0, avg;
        for (var i = 0; i < nums.length; i++) {
            sum += nums[i];
            count++;
        }

        avg = parseInt((sum / count));
        return avg;
    }
    return finalResult;
}

myTest1 = [
    "def var1[1, 2, 3 ,4]",
    "def var2 sum[var1, 20, 70]", //var2=100
    "def var3 min[var1]", // var3=1
    "avg[var2, var3]" //the result is 50
    ];

myTest2 = [
    "def var1 sum[10,10,10,10,10]",
    "def var2 max[var1,20]",
    "def var3 [var2,10]",
    "def var4 max[var2,var3]",
    "[var2]"
];
console.log(Solve(myTest1));


