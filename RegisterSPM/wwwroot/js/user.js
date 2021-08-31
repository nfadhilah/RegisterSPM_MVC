var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  dataTable = $('#tblData').DataTable({
    responsive: true,
    ajax: {
      url: '/Admin/User/GetAll',
      dataSrc: ''
    },
    columns: [
      { data: 'id' },
      { data: 'email' },
      { data: 'nama' },
      { data: 'nip' },
      { data: 'jabatan' },
      { data: 'role' },
      {
        data: 'id',
        render: function (data) {
          return `
            <div class="text-center">
              <a href="/Identity/Account/Manage/${data}" class="btn btn-warning" style="cursor: pointer">
                <i data-feather="eye"></i>
              </a>
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