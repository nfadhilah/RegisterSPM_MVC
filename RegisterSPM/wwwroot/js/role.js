var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  dataTable = $('#tblData').DataTable({
    responsive: true,
    ajax: {
      url: '/Admin/Role/GetAll',
      dataSrc: ''
    },
    columns: [
      { data: 'id', width: '30%' },
      { data: 'name' },
      { data: 'normalizedName' },
      { data: 'concurrencyStamp', width: '30%' }
    ]
  });
}
