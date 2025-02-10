var dataTable; 
#(document).ready(function ()){
    cargarDataTable();
});


function cargarDataTable() {
    dataTable = $("#tblCategorias").DataTable({
        "ajax": {
            "url": "/admin/categorias/GetAll", 
            "type": "GET", 
            "datatype":"json"
        }, 

        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "50" },
            { "data": "orden", "width": "50%" },
            {
                "data": "id", 
                "render": function (data) {
                    return `<div class="text-center"> 
                    <a href="/admin/"
                }
            }
                        
        ]
    })
}


