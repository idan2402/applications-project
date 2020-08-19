
$(function () {

    $('.main-dropdown-menu').on('click', function (event) {
        event.stopPropagation();
    });

    $(window).on('click', function () {
        $('.main-dropdown-menu').slideUp();
    });

});

$(document).ready(function () {
    $("#price").slider(
        {
            range: true,
            min: 0,
            max: 2000000,
            change: function (e, ui) {
                alert($("#price").slider("value", 0) + ' - ' + $("#price").slider("value", 1));
            }
        });
    $("#price").slider("moveTo", 500000, 1);
});

$('#filters-form').submit(function () {
    $(this)
        .find('input[name]')
        .filter(function () {
            return !this.value;
        })
        .prop('name', '');
});