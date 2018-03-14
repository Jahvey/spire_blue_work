function factorial(number) {
    var snum = 1;
    if (number<=1) {
        return 1;
    }
    else {
        return number * factorial(number-1);
    }


}



alert(factorial(5));

