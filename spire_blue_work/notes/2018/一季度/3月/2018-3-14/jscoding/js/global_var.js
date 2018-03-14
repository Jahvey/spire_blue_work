//注意global加var和不加的区别
function ShowGlobalVar() {
    var global = "local";
    return global;
}

var  global = "adonai";
alert(global);//adonai
alert(ShowGlobalVar());//local
alert(global);//adonai