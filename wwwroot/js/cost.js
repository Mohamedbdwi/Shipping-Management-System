'use strict'

function CalculateCost() {

    let Quantity = document.getElementById("Quantity").value;
    let ProductWight = document.getElementById('ProductWight').value;

    let cost = document.getElementById("Cost");


    var orderWeight =Math.abs( Quantity * ProductWight);

    if (orderWeight < 10 || orderWeight == 10) {
        let costs = 5;
        cost.value = costs;
    }
    else if (orderWeight > 10) {
        var additionalWeight = orderWeight - 10;
        let costs = (5) + (additionalWeight * 5);
        cost.value = costs;
    }
    console.log(ProductWight);
    console.log(cost.value);
}






//This is the Generic Function but there is "script src reading problem"


//function CalculateCost() {
    

//    var Quantity = document.getElementById("Quantity").value;
//    let ProductWight = document.getElementById('ProductWight').value;

//    let normalWeight = document.getElementById("NormalWeight");
//    let normalCost = document.getElementById("NormalCost");
//    let extraCost = document.getElementById("ExtraCostPerKG");

//    var cost = document.getElementById("Cost");


//    var orderWeight = Quantity * ProductWight;

//    if (orderWeight < NormalWeight.value || orderWeight == NormalWeight.value) {
//        cost.value = NormalCost.value;
//    }
//    else if (orderWeight > NormalWeight.value) {
//        var additionalWeight = orderWeight - NormalWeight.value;
//        cost.value = (NormalCost.value) + (additionalWeight * ExtraCostPerKG.value);
//    }
//    console.log(ProductWight);
//}






