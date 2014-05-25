function Point(x,y) {
    var pointObject = {};
    pointObject.X = x;
    pointObject.Y = y;

    pointObject.toString = function () {
        var result = "";
        result = "{ X:" + pointObject.X + " Y:" + pointObject.Y + " }";
        return result;
    }

    return pointObject;
}

function Line(point1, point2) {
    var lineObject = {};

    lineObject.firstPoint = point1;
    lineObject.secondPoint = point2;

    lineObject.calculateLength = function () {
        var xLength=0, yLength=0;
        xLength=Math.abs(point1.X-point2.X);
        yLength=Math.abs(point1.Y-point2.Y);
        var length = Math.sqrt(Math.pow(xLength, 2) + Math.pow(yLength, 2));
        return length;
    }

    lineObject.toString = function () {
        var result = "";
        result = "{ P1" + point1.toString() + ", P2" + point2.toString()+"}";
        return result;
    }

    return lineObject;
}

function canBeTriangle(line1, line2, line3) {
    if ((line1 + line2) > line3 && (line2 + line3) > line1 && (line1 + line3) > line2) {
        return true;
    }

    return false;

}
var a = Point(2, 3);
var b = Point(4, 10);
var a1 = Point(1, 20);
var b1 = Point(2, 15);
var a2 = Point(3, 16);
var b2 = Point(4, 7);

var ab = Line(a, b);
var a1b1 = Line(a1, b1);
var a2b2= Line(a2, b2);

console.log("Points:");
console.log("Point a: " + a.toString());
console.log("Point b: " + b.toString());
console.log("Point a1: " + a1.toString());
console.log("Point b1: " + b1.toString());
console.log("Point a2: " + a2.toString());
console.log("Point b2: " + b2.toString()+"\n");

console.log("Lines:");
console.log("Line ab: " + ab.toString());
console.log("Line a1b1: " + a1b1.toString());
console.log("Line a2b2: " + a2b2.toString() + "\n");

console.log("Lengths:");
console.log("Length of line ab: " + (ab.calculateLength()));
console.log("Length of line a1b1: " + (a1b1.calculateLength()));
console.log("Length of line a2b2: " + (a2b2.calculateLength()) + "\n");

console.log("The three lines "+(canBeTriangle(ab,a1b1,a2b2) ? "CAN" : "CAN'T")+" form a triangle");