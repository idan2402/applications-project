/* globals Chart:false, feather:false */

(function () {
    'use strict'

    feather.replace()

    // Graphs
/*   var ctx = document.getElementById('myChart')
    // eslint-disable-next-line no-unused-vars
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [
                'Sunday',
                'Monday',
                'Tuesday',
                'Wednesday',
                'Thursday',
                'Friday',
                'Saturday'
            ],
            datasets: [{
                data: [
                    15339,
                    21345,
                    18483,
                    24003,
                    23489,
                    24092,
                    12034
                ],
                lineTension: 0,
                backgroundColor: 'transparent',
                borderColor: '#007bff',
                borderWidth: 4,
                pointBackgroundColor: '#007bff'
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: false
                    }
                }]
            },
            legend: {
                display: false
            }
        }
    })*/
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
