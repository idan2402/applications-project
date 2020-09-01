$(function () {
    var form = $('#search-form')
    var url = form.attr('action');

    $('#filter').keyup(function () {
        refresh();
    });

    $('#minprice').keyup(function () {
        refresh();
    });

    $('#maxprice').keyup(function () {
        refresh();
    });

    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });

    $('input[type="radio"]').bind('change', function (v) { refresh(); });


    function refresh() {
        $.ajax({
            url: url,
            data: form.serialize(),
            success: function (data) {
                $('tbody').html('');
                $('#results').tmpl(data).appendTo('tbody');
            }
        })
    }
});

