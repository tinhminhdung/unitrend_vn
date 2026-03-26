var SourcePrice = [];
var Pricev = 100;
$(function () {
    js_add_Price();
});
function js_add_Price(r) {
    Pricev++;
    var chuoi = "";
    var Pri = Pricev - 1;
    $("#rowPrice_" + Pri + " .btn_add").empty();
    $("#rowPrice_" + Pri + " .btn_add").html('<a href="javascript:void(0);" onclick="deleteRow_Price(this);" class="btn_add"><img src="/Resources/admin/images/del.png"></a>');
    chuoi += '<tr id="rowPrice_' + Pricev + '">';
    chuoi += '<td style=" width: 14%; "><select style="width: 100% !important;max-width: 100% !important;text-align: left;"  name="icidphanmen" class="form-control selectpicker"  data-live-search="true">';
    chuoi += '<option value="">-- Chọn nhóm phần mềm --</option>';
    $.each(listItems, (index, value) => {
        chuoi += '<option value="' + value.ID + '">' + value.Name + '</option>';
    });
    chuoi += '</select></td>';
    chuoi += '<td style=" width: 14%; "><input style="width:98% !important" type="text" name="Link" class="form-control" /></td>';
    chuoi += '<td style="text-align:center;width:3%; " class="btn_add"><a href="javascript:void(0)" onclick="js_add_Price(' + Pricev + ');"><img src="/Resources/admin/images/edit.png"></a></td></tr>';
    $("#table_PriceMulti tbody").append(chuoi);
}
function deleteRow_Price(r) {
    var ri = r.parentNode.parentNode.rowIndex;
    document.getElementById("table_PriceMulti").deleteRow(ri);
}

function Save_Tailieu_Sanphams() {
    debugger;
    GetData_Price();

    console.log(JSON.stringify(SourcePrice));

    //if (SourcePrice.length > 0) {
        $.ajax({
            type: "POST",
            url: '/index.aspx/Save_Tailieu_Sanpham',
            data: JSON.stringify({ info: SourcePrice }),
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

function GetData_Price() {
    SourcePrice = [];
    let trs = $("#table_PriceMulti tbody tr");
    if (trs.length) {
        trs.each((index, tr) => {
            let ID = String($(' input[name="ID"]').val()).trim();
            let icidphanmen = String($('#' + tr.id + ' select[name="icidphanmen"]').val()).trim();
            let Link = String($('#' + tr.id + '  input[name="Link"]').val().replaceAll(",", "")).trim();

            if (!icidphanmen || icidphanmen.length === 0) {
                icidphanmen = "0";
            }

            if (ID.length > 0 && icidphanmen.length > 0) {
                SourcePrice.push({
                    "IDSP": ID,
                    "icidphanmen": icidphanmen,
                    "Link": Link,
                });
            }
        });
    }
    console.log(JSON.stringify(SourcePrice));
}

jQuery(document).ready(function ($) {
    $(".OrderValue").on('keyup', function () {
        var n = parseInt($(this).val().replace(/\D/g, ''), 10);
        $(this).val(n.toLocaleString().replaceAll(".", ",").replaceAll("NaN", ""));
    });

    $(".OrderValue").load('keyup', function () {
        var n = parseInt($(this).val().replace(/\D/g, ''), 10);
        if (n.toLocaleString() != 'NaN') {
            $(this).val(n.toLocaleString().replaceAll(".", ",").replaceAll("NaN", ""));
        }
    });
});
$('body').on('keyup', '.OrderValue', function (e) {
    var n = parseInt($(this).val().replace(/\D/g, ''), 10);
    if (n.toLocaleString() != 'NaN') {
        $(this).val(n.toLocaleString().replaceAll(".", ",").replaceAll("NaN", ""));
    }
});