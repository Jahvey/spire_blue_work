//cal the factorial 
function factorial(number) {
    var num = 1;
    for (var i = number - 1; i > 0; i--) {
        num *= i;
    }
    return num;
}


alert(factorial(4))