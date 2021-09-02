var dataTable;

$(document).ready(function() {
  loadDataTable();
});

function loadDataTable() {
  dataTable = $('#tblData').DataTable({
    responsive: true,
    ajax: {
      url: '/Main/SPM/LookupAll',
      dataSrc: ''
    },
    columns: [
      { data: 'opd' },
      { data: 'unitKey', visible: false},
      { data: 'noSpm' },
      {
        data: 'tglSpm',
        render: function (data) {
          return `${moment(data).format("DD/MM/YYYY")}`;
        }
      },
      { data: 'keperluan' },
      {
        data: null,
        render: function (data, type, row) {
          var noSpm = encodeURIComponent(row.noSpm.trim());
          var unitKey = row.unitKey.trim();
          return `
            <div class="text-center">
              <a href="/Main/SPM/Add?unitKey=${unitKey}&noSpm=${noSpm}" class="btn btn-success" style="cursor: pointer">
                <i data-feather="edit"></i>
              </a>
            </div>
            `;
        },
        width: '20%'
      }
    ],
    drawCallback: function(settings) {
      feather.replace();
    }
  });
}


function onDelete(url) {
  swal({
    title: 'Hapus data?',
    text: 'Data yang sudah dihapus tidak dapat dikembalikan!',
    icon: 'warning',
    buttons: true,
    dangerMode: true
  }).then(isConfirmed => {
    if (isConfirmed) {
      $.ajax({
        type: 'DELETE',
        url: url,
        success: function(data) {
          if (data.success) {
            toastr.success(data.message);
            dataTable.ajax.reload();
          } else {
            toastr.error(data.message);
          }
        }
      });
    }
  });
}