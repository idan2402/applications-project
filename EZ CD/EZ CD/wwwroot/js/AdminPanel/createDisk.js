
$(function () { // set the date added to the current date
    var now = new Date();
    var offset = now.getTimezoneOffset() * 60000;
    var adjustedDate = new Date(now.getTime() - offset);
    var formattedDate = adjustedDate.toISOString().substring(0, 16);
    var datetimeField = document.getElementById("dateAdded");
    datetimeField.value = formattedDate;
});