//indexOf  searching element
function search(){
    var names = ["David", "Cynthia", "Raymond", "Clayton", "Jennifer"];
    var name = document.getElementById("index").value;

    var position = names.indexOf(name);
    if (position >= 0) {
        alert("Found " + name + " at position " + position);
    } else {
        alert(name + " not found in array.");
    }


}
