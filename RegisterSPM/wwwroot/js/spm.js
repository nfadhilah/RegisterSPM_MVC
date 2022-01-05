var dataTable;

$(document).ready(function () {
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
            {
                data: null,
                render: function (data, type, row) {
                    switch (row.docStatus) {
                        case 1:
                            return `<div class="text-center"><div class="status-circle registered"></div></div>`;
                        case 2:
                            return `<div class="text-center"><div class="status-circle verified"></div></div>`;
                        case 3:
                            return `<div class="text-center"><div class="status-circle approved"></div></div>`;
                        default:
                            return `<div class="text-center"><div class="status-circle rejected"></div></div>`;
                    }
                }
            },
            { data: 'opd' },
            { data: 'noSPM' },
            {
                data: 'tglSPM',
                render: function (data) {
                    return `${moment(data).format("DD/MM/YYYY")}`;
                }
            },
            { data: 'keperluan' },
            {
                data: null,
                render: function (data, type, row) {
                    if (canVerify && row.docStatus === 1) {
                        return `
                <div>
                  <a href="/Main/SPM/Detail/${row.id}" class="btn btn-primary my-1 mx-1" style="cursor: pointer">
                    <i data-feather="eye"></i> Detil
                  </a>
                  <a href="/Main/SPM/Verify/${row.id}" class="btn btn-warning my-1 mx-1" style="cursor: pointer">
                    <i data-feather="edit"></i> Verifikasi
                  </a>
                  <a onclick="onDelete('/Main/SPM/Delete/${row.id}')" class="btn btn-danger my-1 mx-1" style="cursor: pointer">
                    <i data-feather="trash"></i> Batal
                  </a>
                </div>`;
                    }

                    if (canApprove && row.docStatus === 2) {
                        return `
                <div>
                  <a href="/Main/SPM/Detail/${row.id}" class="btn btn-primary my-1 mx-1" style="cursor: pointer">
                    <i data-feather="eye"></i> Detil
                  </a>
                  <a href="/Main/SPM/Approve/${row.id}" class="btn btn-success my-1 mx-1" style="cursor: pointer">
                    <i data-feather="edit"></i> Approve
                  </a>
                  <a onclick="onDelete('/Main/SPM/Delete/${row.id}')" class="btn btn-danger my-1 mx-1" style="cursor: pointer">
                    <i data-feather="trash"></i> Batal
                  </a>
                </div>
                `;
                    }

                    if (row.docStatus === 4) {
                        return `
                <div>
                  <a href="/Main/SPM/Detail/${row.id}" class="btn btn-primary my-1 mx-1" style="cursor: pointer">
                    <i data-feather="eye"></i> Detil
                  </a>
                  <a onclick="onRevision('/Main/SPM/Revision/${row.id}')" class="btn btn-secondary my-1 mx-1" style="cursor: pointer">
                    <i data-feather="refresh-cw"></i> Perbaharui
                  </a>
                </div>
`;
                    }

                    return `
                <div>
                  <a href="/Main/SPM/Detail/${row.id}" class="btn btn-primary my-1 mx-1" style="cursor: pointer">
                    <i data-feather="eye"></i> Detil
                  </a>
                  <a onclick="onDelete('/Main/SPM/Delete/${row.id}')" class="btn btn-danger my-1 mx-1" style="cursor: pointer">
                    <i data-feather="trash"></i> Batal
                  </a>
                </div>
`;
                },
                width: '25%'
            }
        ],
        drawCallback: function (settings) {
            feather.replace();
        }
    });
}

function onRevision(url) {
    swal({
        title: 'Perbaharui data SPM?',
        text: 'SPM yang berhasil di perbaharui akan dicatat kembali sebagai dokumen masuk.',
        icon: 'warning',
        buttons: true,
        dangerMode: true
    }).then(isConfirmed => {
        if (isConfirmed) {
            $.ajax({
                type: 'PUT',
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

function onDelete(url) {
    swal({
        title: 'Tolak/Batalkan SPM?',
        text: 'SPM batal akan masuk di daftar penolakan.',
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