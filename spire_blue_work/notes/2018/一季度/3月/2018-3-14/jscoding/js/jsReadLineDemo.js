
function readLine1() {
    var ForReading = 1;
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var f = fso.OpenTextFile("d:\\temp.txt", ForReading);
    var arr = f.ReadAll().split("\r\n");
    alert("第3行数据为:" + arr[2]);
}



readLine1();