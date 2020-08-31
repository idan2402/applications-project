
(function () {
    'use strict'

    feather.replace()
    var thePage = window.location.pathname.toLowerCase().split("/")[1];
    switch (thePage) {
        case "sales":
            document.getElementById(thePage).classList.add("active");
        case "admindashboard":      
            document.getElementById(thePage).classList.add("active");
        case "saledetailes":        
            document.getElementById(thePage).classList.add("active");
        case "disks":               
            document.getElementById(thePage).classList.add("active");
        case "customers":           
            document.getElementById(thePage).classList.add("active");
        case "artists":
            document.getElementById(thePage).classList.add("active");
    }
}())
