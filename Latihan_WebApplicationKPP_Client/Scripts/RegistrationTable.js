$(document).ready(function () {
    $('#registrationTable').DataTable({
        ajax: {
            url: 'https://localhost:44359/api/TBL_T_reREGISTRATION2',
            dataSrc: 'data'
        },
        columns: [
            {
                data: "NRP",
                render: (data, type, row, meta) => {
                    return data;
                }
            },
            {
                data: 'Nama',
                render: (data) => {
                    return data;
                }
            },
            {
                data: 'Telepon',
                render: (data) => {
                    return data;
                }
            },
            {
                data: 'Email',
                render: (data) => {
                    return data;
                }
            },



        ],
        createdRow: function (row, data, dataIndex) {
            row.setAttribute("data-id",  data.NRP)


            row.addEventListener("click", e => {

                let isInsert = prompt(`ketik "YES" untuk menambahkan ${data.Nama} sebagai karyawan pilihan`, "NO")
                if (isInsert.toLowerCase() == 'yes') {

                    $.ajax({
                        url: 'https://localhost:44359/api/TBL_T_BIODATA',
                        type: 'POST',
                        dataType: 'json',
                        contentType: 'application/json',
                        data: JSON.stringify(data),
                        success: function (res) {
                            console.log(res);

                            window.location.assign("/")
                        },
                        error: function (err) {

                        }

                    })

                    

                }
              


            })

        }

    })

})




$(document).ready(function () {
    $('#karyawanTable').DataTable({
        ajax: {
            url: 'https://localhost:44359/api/TBL_T_BIODATA',
            dataSrc: 'data'
        },
        columns: [
            {
                data: "NRP",
                render: (data, type, row, meta) => {
                    return data;
                }
            },
            {
                data: 'NAMA',
                render: (data) => {
                    return data;
                }
            },
            {
                data: 'TELEPON',
                render: (data) => {
                    return data;
                }
            },
            {
                data: 'EMAIL',
                render: (data) => {
   
                    return data;
                }
            }, 
            {
                data: null,
                render: (data, type, row, meta) => {
                    return `<button onClick="showDeleteKaryawanModal('${row.NRP}')" data-toggle="modal" data-target="#deleteModal"> Delete </button> <button onCLick="showUpdateKaryawanModal(event,'${row.NRP}')" data-toggle="modal" data-target="#updateModal" data-nama="${row.NAMA}" data-telepon="${row.TELEPON}" data-email="${row.EMAIL}">Update</button>`
                }
            }




        ]

    })

})


let updateBtnElement = document.querySelector("#updateBtn")
updateBtnElement.addEventListener("click", updateKarayawanPilihan)

let deleteBtnElement = document.querySelector("#deleteBtn")
deleteBtnElement.addEventListener("click", deleteKaryawanPilihan)



function showDeleteKaryawanModal(data) {
    const modal = document.querySelector("#deleteModal")

    modal.querySelector(".modal-body p").setAttribute("data-NRP", data)

}


function deleteKaryawanPilihan() {

    const modal = document.querySelector("#deleteModal")
    let nrp = modal.querySelector(".modal-body p").getAttribute("data-NRP")

    $.ajax({
        url: `https://localhost:44359/api/TBL_T_BIODATA/delete/?nrp=${nrp}`,
        type: 'POST',
        success: function (res) {
            console.log(res);
            window.location.assign("/")
        },
        error: function (err) {
            console.log(err)
        }

    })

   
    
}


function showUpdateKaryawanModal(event, data) {

    const button = event.target

    const modal = document.querySelector("#updateModal")

    modal.querySelector("form").setAttribute("data-NRP", data)

    modal.querySelector("#namaInput").value = button.getAttribute('data-nama')
    modal.querySelector("#emailInput").value = button.getAttribute('data-email')
    modal.querySelector("#teleponInput").value = button.getAttribute('data-telepon')

}


function updateKarayawanPilihan() {
    const modal = document.querySelector("#updateModal")

    const updatedData = {
        NRP: modal.querySelector("form").getAttribute("data-NRP"),
        NAMA: modal.querySelector("#namaInput").value,
        EMAIL: modal.querySelector("#emailInput").value,
        TELEPON: modal.querySelector("#teleponInput").value
    }

    console.log(updatedData)

    $.ajax({
        url: `https://localhost:44359/api/TBL_T_BIODATA/${updatedData.NRP}`,
        type: 'PUT', 
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(updatedData),
        success: function (res) {
            console.log(res)
            window.location.assign("/")
        },
        error: function (err) {
            console.log(err)
        }
    })

   

}