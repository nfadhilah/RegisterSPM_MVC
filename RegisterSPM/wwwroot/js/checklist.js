﻿var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  dataTable = $('#tblData').DataTable({
    responsive: true,
    ajax: {
      url: '/Admin/Checklist/GetAll',
      dataSrc: ''
    },
    columns: [
      { data: 'seqNo' },
      { data: 'uraian' },
      {
        data: 'id',
        render: function (data) {
          return `
            <div class="text-center">
              <a href="/Admin/Checklist/Upsert/${data}" class="btn btn-success" style="cursor: pointer">
                <i data-feather="edit"></i>
              </a>
              &nbsp;
              <a onclick=onDelete("/Admin/Checklist/Delete/${data}") class="btn btn-danger" style="cursor: pointer">
                <i data-feather="delete"></i>
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
        success: function (data) {
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