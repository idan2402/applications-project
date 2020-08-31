const $tableID = $('#table');
const $BTN = $('#export-btn');
const $EXPORT = $('#songsJSON');

const newTr = `
<tr class="hide">
  <td class="pt-3-half" contenteditable="true">Name</td>
  <td class="pt-3-half" contenteditable="true">Length</td>
  <td class="pt-3-half">
      <span class="table-up">
          <a href="#!" class="indigo-text">
              <i class="fas fa-long-arrow-alt-up"
                 aria-hidden="true">↑</i>
          </a>
      </span>
      <span class="table-down">
          <a href="#!" class="indigo-text">
              <i class="fas fa-long-arrow-alt-down"
                 aria-hidden="true">↓</i>
          </a>
      </span>
  </td>
  <td>
    <span class="table-remove"><button type="button" class="btn btn-danger btn-rounded btn-sm my-0 waves-effect waves-light">Remove</button></span>
  </td>
</tr>`;

$('.table-add').on('click', 'i', () => {

    const $clone = $tableID.find('tbody tr').last().clone(true).removeClass('hide table-line');

    if ($tableID.find('table tbody tr').length === 0)
        $('tbody').append(newTr);

    $tableID.find('table').append($clone);
    setData();
});

$tableID.on('click', '.table-remove', function () {

    $(this).parents('tr').detach();
    setData();
});

$tableID.on('click', '.table-up', function () {

    const $row = $(this).parents('tr');

    if ($row.index() === 0)
        return;

    $row.prev().before($row.get(0));
    setData();
});

$tableID.on('click', '.table-down', function () {

    const $row = $(this).parents('tr');
    $row.next().after($row.get(0));
    setData();
});

jQuery.fn.pop = [].pop;
jQuery.fn.shift = [].shift;

function setData() {
    const $rows = $tableID.find('tr:not(:hidden)');
    const headers = [];
    const data = [];

    // Get the headers
    $($rows.shift()).find('th:not(:empty)').each(function () {
        var currentHeader = $(this).text().toLowerCase();
        if (currentHeader != 'remove' && currentHeader != 'sort')
            headers.push(currentHeader);
    });

    // Turn all existing rows into a loopable array
    $rows.each(function () {
        const $td = $(this).find('td');
        const h = {};

        headers.forEach((header, i) => {

            h[header] = $td.eq(i).text();
        });

        data.push(h);
    });
    document.getElementById("songsJSON").setAttribute("value", JSON.stringify(data));
}
$BTN.on('click', () => {
    setData();
    document.getElementById("songsJSON").setAttribute("value", JSON.stringify(data));
});

$(function () {
    document.getElementById("songsJSON").setAttribute("value", JSON.stringify(data));
})
function setSongsJSONValue() {
    setData();
    return true;
}

function validateNumOfSongs() {
    if ($tableID.find('tr:not(:hidden)').length == 1) { // no songs were added
        alert("At Least One Song Is Required");
        return false;
    }
    return true;
}
