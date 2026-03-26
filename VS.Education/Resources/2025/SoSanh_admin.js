var SourceSoSanh = [];
var SoSanhv = 100;

function deleteRow_SoSanh(r) {
    var ri = r.parentNode.parentNode.rowIndex;
    document.getElementById("table_SoSanhMulti").deleteRow(ri);
}

function Save_SoSanh_Sanphams() {
    debugger;
    GetData_SoSanh();

    //console.log(JSON.stringify(SourceSoSanh));

    //if (SourceSoSanh.length > 0) {
    $.ajax({
        type: "POST",
        url: '/index.aspx/Save_SoSanh_Sanpham',
        data: JSON.stringify({ info: SourceSoSanh }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: "true",
        success: function (response) {
            alert("Cập nhật thành công");
        },
        error: function (response) {
            alert("Lỗi..! Vui lòng kiểm tra lại dữ liệu nhập. ");
        },
        beforeSend: function () {
            //   alert("33");
        },
        complete: function () {
            // alert("44");
        }
    });

    //}
}
function GetData_SoSanh() {
    debugger;
    SourceSoSanh = [];
    let trs = $("#table_SoSanhMulti tbody tr");

    if (trs.length) {
        trs.each((index, tr) => {
            let ID = String($('input[name="ID"]').val()).trim();
            let icid = String($('input[name="icid"]').val()).trim();

            //// Bỏ qua các hàng có id bắt đầu bằng "rowlienquan_cha_"
            //if (tr.id.startsWith("rowlienquan_cha_")) {
            //    return; // Tiếp tục vòng lặp, bỏ qua hàng này
            //}

            let idthuoctinh = String($('#' + tr.id + ' input[name="idthuoctinh"]').val()).trim();
            let NoiDungSoSanh = String($('#' + tr.id + ' input[name="NoiDungSoSanh"]').val()).trim();

            // Nếu không có giá trị, đặt mặc định idthuoctinh là "0"
            //if (!idthuoctinh || idthuoctinh.length === 0 || NoiDungSoSanh.length === 0) {
            //    idthuoctinh = "0";
            //}

            if (ID.length > 0 && idthuoctinh.length > 0) {
                SourceSoSanh.push({
                    "ipid": ID,
                    "icid": icid,
                    "idthuoctinh": idthuoctinh,
                    "NoiDungSoSanh": NoiDungSoSanh,
                });
            }
        });
    }

    console.log(JSON.stringify(SourceSoSanh));
}

