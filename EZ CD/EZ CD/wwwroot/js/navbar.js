
$(function () {

    $('.main-dropdown-menu').on('click', function (event) {
        event.stopPropagation();
    });

    $(window).on('click', function () {
        $('.main-dropdown-menu').slideUp();
    });

});

$('#filters-form').submit(function () {
    $(this)
        .find('input[name]')
        .filter(function () {
            return !this.value;
        })
        .prop('name', '');
});

function isDigits(str) {
    var digitsArr = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '.'];
    for (var i = 0; i < str.length; i++)
        if (!digitsArr.includes(str.charAt(i)))
            return false;
    return true;
}

function validateFiltersForm() { // returning false prevents the form from being submitted
    var x = document.forms["filters-form"]["fromYear"].value;
    var thisYear = new Date().getFullYear;
    if (x != "") {
        if (!isDigits(x)) {
            alert("Minimum Year Can Only Include Digits");
            return false;
        }
        if (parseInt(x) <= 0) {
            alert("Minimum Year Must Be Greater Than 0");
            return false;
        }
        if (parseInt(x) != parseFloat(x)) {
            alert("Minimum Year Must A Whole Number");
            return false;
        }
    }
    x = document.forms["filters-form"]["toYear"].value;
    if (x != "") {
        if (!isDigits(x)) {
            alert("Maximum Year Can Only Include Digits");
            return false;
        }
        if (parseInt(x) > thisYear) {
            alert("Maximum Year Can Not Pass " + thisYear.toString());
            return false;
        }
        if (parseInt(x) != parseFloat(x)) {
            alert("Maximum Year Must A Whole Number");
            return false;
        }
        if (parseInt(x) < document.forms["filters-form"]["fromYear"].value) {
            alert("Maximum Year Can Not Be Less Than Minimum Year");
            return false;
        }
    }
    x = document.forms["filters-form"]["minPrice"].value;
    if (x != "") {
        if (!isDigits(x)) {
            alert("Minimum Price Can Only Include Digits");
            return false;
        }
        if (parseInt(x) < 0) {
            alert("Minimum Price Can Not Be Less Than 0");
            return false;
        }
    }
    x = document.forms["filters-form"]["maxPrice"].value;
    if (x != "") {
        if (!isDigits(x)) {
            alert("Maximum Price Can Only Include Digits");
            return false;
        }
        if (x < document.forms["filters-form"]["minPrice"].value) {
            alert("Maximum Price Can Not Be Less Than Minimum Price");
            return false;
        }
    }
    return true;
}