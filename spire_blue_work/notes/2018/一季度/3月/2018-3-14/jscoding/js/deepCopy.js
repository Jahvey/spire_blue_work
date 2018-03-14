function deepCopy(arr1, arr2) {
    for (var i = 0; i <arr1.length; i++) {
        arr2[i] = arr1[i];
    }

}

//注意是[]方括号不是大括号{}
var source = [];//如果改成{}的话，dist[0 ]的结果为undefined,source[0]结果仍为-234
for (var i = 0; i < 10; i++) {
    source[i] = i + 1;
}
var dist = [];
deepCopy(source, dist);
source[0] = -234;
console.log("dist[0] :=>" + dist[0]);
console.log("source[0] :=>" + source[0]);





