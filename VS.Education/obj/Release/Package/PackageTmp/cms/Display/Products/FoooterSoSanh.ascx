<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoooterSoSanh.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.FoooterSoSanh" %>
<div class="comparison-container" id="comparison-container">
    <div class="listcompare">
        <div class="container">
            <a href="javascript:;" onclick="clearCompare(event);" class="clearall"> Thu gọn <img style=" width: 18px; " src="/resources/2025/thugon.png" /></a>
            <div id="compare-list"></div>
            <div class="action-buttons">
                <a id="btnSoSanh" class="btn-sosanh compare-btn">So sánh ngay</a>
                <a class="clear-btn" onclick="clearCompareList()">Xóa tất cả sản phẩm</a>
            </div>
        </div>
    </div>
</div>
<div class="popup-button">
    <a href="javascript:;" id="ss-close" class="a1" style=""><i class="close-symbol"></i></a>
    <a href="javascript:;" onclick="showCompare()" id="ss-now" style="display: inline;">
        <img src="/resources/2025/sosanh_pop.png" />
        <span>So sánh <label id="count-ss">(2)</label></span>
    </a>
</div>


<script>
    $(document).ready(function () {
        loadCompareList();

        // Thêm sản phẩm vào danh sách so sánh (giới hạn tối đa 3 sản phẩm, kiểm tra sản phẩm trùng lặp)
        window.btnaddcompare = function (ipid, icid, name, image, Price, link) {
            console.log("Gọi btnaddcompare với ipid:", ipid, "icid:", icid);

            if (!ipid || !icid) {
                console.error("Không tìm thấy ipid hoặc icid");
                return;
            }

            $.ajax({
                type: "POST",
                url: "/AjaxAPI.aspx/GetCompareList",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d && response.d.length >= 3) {
                        alert("Bạn chỉ có thể so sánh tối đa 3 sản phẩm.");
                        return;
                    }

                    // Kiểm tra sản phẩm đã tồn tại trong danh sách hay chưa
                    var isProductExists = response.d.some(product => product.ipid == ipid);
                    if (isProductExists) {
                        alert("Sản phẩm này đã có trong danh sách so sánh!");
                        return;
                    }

                    // Gửi yêu cầu thêm sản phẩm vào danh sách so sánh
                    $.ajax({
                        type: "POST",
                        url: "/AjaxAPI.aspx/AddToCompare",
                        data: JSON.stringify({ ipid: ipid, icid: icid, name: name, image: image, Price: Price, link: link }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            console.log("Thêm vào danh sách so sánh thành công.");
                            loadCompareList();
                        },
                        error: function () {
                            console.error("Lỗi khi thêm vào danh sách so sánh.");
                        }
                    });
                },
                error: function () {
                    console.error("Lỗi khi kiểm tra danh sách so sánh.");
                }
            });
        };

        // Xóa tất cả sản phẩm khỏi danh sách
        $("#btnClearCompare").click(function () {
            clearCompareList();
        });
    });

    function loadCompareList() {
        console.log("Gọi hàm loadCompareList...");

        $.ajax({
            type: "POST",
            url: "/AjaxAPI.aspx/GetCompareList",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log("Dữ liệu trả về từ server:", response);

                var compareList = $("#compare-list");
                var compareContainer = $("#comparison-container");
                var btnSoSanh = $("#btnSoSanh");
                var btnClearCompare = $("#btnClearCompare");
                var warningMessage = $("#compare-warning");

                compareList.empty();
                let ipidList = [];

                if (response.d && response.d.length > 0) {
                    compareContainer.show(); // Hiển thị khối so sánh

                    // Hiển thị danh sách sản phẩm có trong API
                    $.each(response.d, function (index, product) {
                        console.log(`Sản phẩm ${index + 1}:`, product);

                        ipidList.push(product.ipid); // Lưu ipid vào mảng

                        compareList.append(`
                       <li id="${product.ipid}" class="compare-item">
                            <a href="javascript:;" id="${product.ipid}">
                                <p class='anhsp'><img src="${product.image}" alt="${product.name}"></p>
                                <h3>${product.name}</h3>
                            </a>
                            <p class='xoas'>
                                <a href="javascript:void(0);" class="btn-remove-compare" data-ipid="${product.ipid}">
                                    <img class="zoaremove" src="/resources/2025/zoa.png" />
                                </a>
                            </p>
                        </li>
                    `);
                    });

                    // Nếu số sản phẩm < 3, thêm sản phẩm placeholder để đủ 3 slot
                    let missingSlots = 3 - ipidList.length;
                    for (let i = 0; i < missingSlots; i++) {
                        compareList.append(`
                        <li class="empty-compare themee">
                            <a href="javascript:void(0);" onclick="openProductModal()" class="add-product">
                           <div class="passsst"></div>
                                <p class='anhsp'><img src="/Resources/2025/icon_add_desktop.png" alt="Thêm sản phẩm"></p>
                                <p class=themspp>Thêm sản phẩm</p>
                            </a>
                        </li>
                    `);
                    }

                    // Kiểm tra số lượng sản phẩm để bật/tắt nút so sánh
                    if (ipidList.length >= 2) {
                        btnSoSanh.attr("href", "/so-sanh.html?ipid=" + ipidList.join(",")).show();
                        warningMessage.hide(); // Ẩn cảnh báo nếu đủ sản phẩm
                    } else {
                        btnSoSanh.hide();
                        warningMessage.show().text("Bạn cần chọn ít nhất 2 sản phẩm để so sánh!");
                    }

                    // Gán sự kiện xóa sản phẩm
                    $(".btn-remove-compare").off("click").on("click", function () {
                        var ipid = $(this).data("ipid");
                        removeCompareItem(ipid);
                    });

                    btnClearCompare.show(); // Hiển thị nút "Xóa tất cả"
                } else {
                    // Trường hợp không có sản phẩm nào -> Ẩn khối
                    compareContainer.hide();
                    btnSoSanh.hide();
                    btnClearCompare.hide();
                    warningMessage.hide();
                }
                updateCompareCount(); // Cập nhật số lượng sản phẩm
            },
            error: function (xhr, status, error) {
                console.error("Lỗi khi tải danh sách so sánh:", status, error);
            }
        });
        
    }



    // Hàm xóa sản phẩm khỏi danh sách so sánh
    function removeCompareItem(ipid) {
        $.ajax({
            type: "POST",
            url: "/AjaxAPI.aspx/RemoveFromCompare",
            data: JSON.stringify({ ipid: ipid }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                console.log("Xóa sản phẩm khỏi danh sách so sánh thành công.");
                loadCompareList();
            },
            error: function () {
                console.error("Lỗi khi xóa sản phẩm khỏi danh sách so sánh.");
            }
        });
    }

    // Hàm xóa tất cả sản phẩm khỏi danh sách so sánh
    function clearCompareList() {
        $.ajax({
            type: "POST",
            url: "/AjaxAPI.aspx/ClearCompare",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                console.log("Xóa tất cả sản phẩm thành công.");
                loadCompareList();
            },
            error: function () {
                console.error("Lỗi khi xóa tất cả sản phẩm.");
            }
        });
    }


    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "/AjaxAPI.aspx/getlink",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                let link = response.d; // Lấy link từ API
                console.log("🔗 Link từ API:", link);
                localStorage.setItem("lastCompareURL", link); // Lưu vào localStorage
            },
            error: function (error) {
                console.log("❌ Lỗi khi lấy link:", error);
            }
        });
    });

    function openProductModal() {
        let lastURL = localStorage.getItem("lastCompareURL");
        console.log("📌 Điều hướng đến:", lastURL);

        if (lastURL) {
            window.location.href = lastURL; // Điều hướng về URL cũ từ API
        } else {
            window.location.href = "/san-pham.html"; // Trang mặc định
        }
    }

    function updateCompareCount() {
        let count = $("#compare-list li.compare-item").length; // Chỉ đếm sản phẩm từ API
        $("#count-ss").text(`(${count})`); // Cập nhật số lượng vào giao diện

         //Kiểm tra nếu không có sản phẩm thì ẩn popup
        if (count === 0) {
            $(".popup-button").hide();
            $("#comparison-container").hide();
        } else {
            $(".popup-button").show();
        }
    }

    $(document).ready(function () {
        // Sự kiện thu gọn
        $(".clearall").click(function (event) {
            event.preventDefault();
            $("#comparison-container").hide(); // Ẩn bảng so sánh
            $(".popup-button").show(); // Hiện nút mở lại
        });

        // Sự kiện mở bảng so sánh
        $(".popup-button").click(function () {
            $(".popup-button").hide(); // Ẩn nút
            $("#comparison-container").show(); // Hiện bảng so sánh
        });
    });

    $(document).ready(function () {
        let delay = 100; // Bắt đầu với 0.1 giây
        let maxDelay = 1000; // Giới hạn tối đa 1 giây

        let hideInterval = setInterval(function () {
            if ($("#comparison-container").is(":visible")) {
                $("#comparison-container").hide();
                clearInterval(hideInterval); // Dừng kiểm tra khi đã ẩn
            } else if (delay >= maxDelay) {
                clearInterval(hideInterval); // Dừng nếu quá 1 giây mà vẫn không cần ẩn
            }
            delay += 100; // Tăng thời gian kiểm tra lên
        }, delay);

        loadCompareList();
    });


</script>

