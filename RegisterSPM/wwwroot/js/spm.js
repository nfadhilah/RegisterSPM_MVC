var dataTable;

$(document).ready(function() {
  var query = "";
  var params = (new URL(document.location)).searchParams;
  var status = params.get("status");
  var url = '/Main/SPM/GetAll' + `?status=${status}`;
  loadDataTable(url);
});

function getSelectedStatus() {
  event.stopPropagation();
  var selectedStatus = $('input[name="btnradio"]');
  console.log(selectedStatus);
}

function loadDataTable(url) {
  dataTable = $('#tblData').DataTable({
    responsive: true,
    ajax: {
      url: url,
      dataSrc: ''
    },
    columns: [
      { data: 'opd' },
      { data: 'noSPM' },
      {
        data: 'tglSPM',
        render: function(data) {
          return `${moment(data).format("DD/MM/YYYY")}`;
        }
      },
      { data: 'keperluan' },
      {
        data: null,
        render: function (data, type, row) {
          if (canVerify && row.docStatus !== 3) {
            return `
                <div>
                  <a href="/Main/SPM/Detail/${row.id}" class="btn btn-warning" style="cursor: pointer">
                    <i data-feather="eye"></i>
                  </a>
                  &nbsp;
                  <a href="/Main/SPM/Verify/${row.id}" class="btn btn-success" style="cursor: pointer">
                    <i data-feather="edit"></i>
                  </a>
                </div>
                `;
          }

          if (canApprove && row.docStatus === 2) {
            return `
                <div>
                  <a href="/Main/SPM/Detail/${row.id}" class="btn btn-warning" style="cursor: pointer">
                    <i data-feather="eye"></i>
                  </a>
                  &nbsp;
                  <a href="/Main/SPM/Approve/${row.id}" class="btn btn-danger" style="cursor: pointer">
                    <i data-feather="edit"></i>
                  </a>
                </div>
                `;
          }

          return `
                <div>
                  <a href="/Main/SPM/Detail/${row.id}" class="btn btn-warning" style="cursor: pointer">
                    <i data-feather="eye"></i>
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