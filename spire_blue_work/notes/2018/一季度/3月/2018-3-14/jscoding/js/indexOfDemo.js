
function indexOfFunc() {
    var names = ["David", "Cynthia", "Raymond", "Clayton", "Jennifer"];
    var name = document.getElementById("ipt1").value;
    alert("Enter a name to search for: " + name);

    var position = names.indexOf(name);
 
        if (position >= 0) {

            console.log("Found " + name + " at position " + position);
        } else {
            console.log(name + " not found in array.");
        }

    

    

}



