var SourceLienQuan = [];
var Lquan = 100;
$(function () {
    js_add_lienquan();
});
function js_add_lienquan(r) {
    Lquan++;
    var chuoi = "";
    var Pri = Lquan - 1;
    $("#rowlienquan_" + Pri + " .btn_add").empty();
    $("#rowlienquan_" + Pri + " .btn_add").html('<a href="javascript:void(0);" onclick="deleteRow_LienQuan(this);" class="btn_add"><img src="/Resources/admin/images/del.png"></a>');
    chuoi += '<tr id="rowlienquan_' + Lquan + '">';
    chuoi += '<td style=" width: 14%; "><input style="width:100% !important" type="text" name="ipid_lienquan" class="form-control" /></td>';
    chuoi += '<td style="text-align:center;width:3%; " class="btn_add"><a href="javascript:void(0)" onclick="js_add_lienquan(' + Lquan + ');"><img src="/Resources/admin/images/edit.png"></a></td></tr>';
    $("#table_LienQuan tbody").append(chuoi);
}
function deleteRow_LienQuan(r) {
    var ri = r.parentNode.parentNode.rowIndex;
    document.getElementById("table_LienQuan").deleteRow(ri);
}

function Save_lienquan_Sanpham() {
    debugger;
    GetData_LienQuan();

    console.log(JSON.stringify(SourceLienQuan));

    //if (SourceLienQuan.length > 0) {
        $.ajax({
            type: "POST",
            url: '/index.aspx/Save_lienquan_Sanpham',
            data: JSON.stringify({ info: SourceLienQuan }),
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

function GetData_LienQuan() {
    SourceLienQuan = [];
    let trs = $("#table_LienQuan tbody tr");
    if (trs.length) {
        trs.each((index, tr) => {
            let ID = String($(' input[name="ID"]').val()).trim();
            let ipid_lienquan = String($('#' + tr.id + '  input[name="ipid_lienquan"]').val().replaceAll(",", "")).trim();

            if (!ipid_lienquan || ipid_lienquan.length === 0) {
                ipid_lienquan = "0";
            }

            if (ID.length > 0 && ipid_lienquan.length > 0) {
                SourceLienQuan.push({
                    "ipid": ID,
                    "ipid_lienquan": ipid_lienquan,
                });
            }
        });
    }
    console.log(JSON.stringify(SourceLienQuan));
}
