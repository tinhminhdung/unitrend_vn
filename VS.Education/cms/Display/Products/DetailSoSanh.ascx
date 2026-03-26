<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailSoSanh.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.DetailSoSanh" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<script type="text/javascript">
    var r = { 'special': /[\W]/g, 'quotes': /[^0-9^]/g, 'notnumbers': /[^a-zA]/g }
    function valid(o, w) {
        o.value = o.value.replace(r[w], '');
        if (o.value == '') {
            o.value = '1';
        }
    }
</script>
<div class="main-breadcrumb">
	<div class="container">
		<div class="row">
			<div class="col-lg-12">
				<ol class="breadcrumb">
					<li><a href="/">Trang chủ</a></li>
					<li><a>So sánh</a></li>
                    
				</ol>
			</div>
		</div>
	</div>
</div>

<div class="main-content">
    <div class="container">
        <div class="row">

            <div class="col-md-12 chitietssossanh">
                <div class="comparison">

                    <div class="products" id="product-list">
                   
                    </div>

                    <div id="comparison-container">
                    </div>
                    <asp:Literal ID="lstsosanh"  Visible="false" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    let totalCompareProducts = 0; // Biến lưu số lượng sản phẩm đang so sánh
    let compareOrder = []; // Lưu thứ tự sản phẩm


   function loadCompareList() {
    $.ajax({
        type: "POST",
        url: "/AjaxAPI.aspx/GetCompareList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var products = response.d;
            var productList = $("#product-list");
            productList.html(""); // Xóa danh sách cũ

            productList.append(`<div class="product add-product daudong"></div>`);

          

            totalCompareProducts = products.length; // Cập nhật số lượng sản phẩm đang so sánh

            compareOrder = []; // Reset thứ tự
            products.forEach((product) => {
                compareOrder.push(product.ipid); // Lưu thứ tự hiển thị

                let formattedPrice = Number(product.Price)
                    .toLocaleString("vi-VN")
                    .replace(/\./g, ",") + " đ"; 

                productList.append(`
                    <div class="product" data-ipid="${product.ipid}">
                        <img src="${product.image}" alt="${product.name}" style="width: 100px; height: auto;">
                        <h3>${product.name}</h3>
                        <p>Giá: ${formattedPrice}</p>
                        <a class='remove-icon' onclick="removeProduct(${product.ipid})" ${products.length === 1 ? 'style="display:none;"' : ''}>❌</a>
                    </div>
                `);
            });

            if (products.length === 1) {
                $(".remove-icon").hide();
            }
            let remainingSlots = 3 - products.length;
            for (let i = 0; i < remainingSlots; i++) {
                productList.append(`
                    <div class="product add-product">
                        <h3>Thêm sản phẩm so sánh</h3>
                        <div class='addlink'>
                            <a class='openProductModal' onclick="openProductModal()">+ Thêm sản phẩm</a>
                        </div>
                    </div>
                `);
            }
            // Cập nhật lại bảng so sánh theo thứ tự
            loadComparisonTable();
        }
    });
}

   function loadComparisonTable() {
    $.ajax({
        type: "POST",
        url: "/AjaxAPI.aspx/GetComparisonData",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Dữ liệu từ API:", response);

            let data = (typeof response.d === "string") ? JSON.parse(response.d) : response.d;
            console.log("Dữ liệu sau khi parse:", data);

            if (data.success && data.data.length > 0) {
                let html = "<div class='specifications'>";

                data.data.forEach(group => {
                    html += `<h3>${group.Name}</h3><table>`;

                    let totalColumns = 3; // Luôn hiển thị tối đa 3 sản phẩm
                    let allAttributes = new Set();

                    // Lấy danh sách thuộc tính
                    group.Products.forEach(product => {
                        if (product.Attributes) {
                            product.Attributes.forEach(attr => allAttributes.add(attr.Name));
                        }
                    });

                    let attributesArray = Array.from(allAttributes);

                    // Duyệt qua từng thuộc tính
                    attributesArray.forEach(attributeName => {
                        let rowHtml = `<tr><td style="text-align: left; font-weight: bold;">${attributeName}</td>`;
                        let hasValue = false;

                        for (let i = 0; i < totalColumns; i++) {
                            let productId = compareOrder[i]; // ID sản phẩm
                            let product = group.Products.find(p => p.ipid === productId);
                            let attrValue = "";

                            if (product && product.Attributes) {
                                let foundAttr = product.Attributes.find(attr => attr.Name === attributeName);
                                attrValue = foundAttr ? foundAttr.Value.trim() : "";
                            }

                            if (attrValue) hasValue = true; // Kiểm tra nếu có ít nhất một giá trị
                            rowHtml += `<td>${attrValue}</td>`;
                        }

                        rowHtml += "</tr>";

                        if (hasValue) html += rowHtml; // Chỉ thêm nếu có giá trị
                    });

                    html += "</table>";
                });

                html += "</div>";
                $("#comparison-container").html(html);
            } else {
                $("#comparison-container").html("<p class='nodate'>Không có dữ liệu so sánh.</p>");
            }
        },
        error: function (xhr, status, error) {
            console.error("Lỗi khi gọi API:", error);
        }
    });
}



    function loadCompareList11() {
        $.ajax({
            type: "POST",
            url: "/AjaxAPI.aspx/GetCompareList",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var products = response.d;
                var productList = $("#product-list");
                productList.html(""); // Xóa danh sách cũ

                
                // 🔹 Thêm ô "Thêm sản phẩm so sánh" vào đầu danh sách
                productList.append(`
                <div class="product add-product daudong">
                   
                </div>
            `);
                totalCompareProducts = products.length; // Cập nhật số lượng sản phẩm đang so sánh
                // 🔹 Hiển thị danh sách sản phẩm
                products.forEach((product) => {
                    let formattedPrice = Number(product.Price)
                        .toLocaleString("vi-VN") // Định dạng số theo VN
                        .replace(/\./g, ",") + " đ"; // Chuyển dấu . thành , và thêm "VNĐ"

                    productList.append(`
                    <div class="product" data-ipid="${product.ipid}">
                        <img src="${product.image}" alt="${product.name}" style="width: 100px; height: auto;">
                        <h3>${product.name}</h3>
                        <p>Giá: ${formattedPrice}</p>
                        <a class='remove-icon' onclick="removeProduct(${product.ipid})" ${products.length === 1 ? 'style="display:none;"' : ''}>❌</a>
                    </div>
                `);
                });

                // 🔹 Nếu chỉ còn một sản phẩm, ẩn nút xóa
                if (products.length === 1) {
                    $(".remove-icon").hide();
                }

                // 🔹 Tính số ô "Thêm sản phẩm" cần thêm để đạt tối đa 3 sản phẩm
                let remainingSlots = 3 - products.length;
                for (let i = 0; i < remainingSlots; i++) {
                    productList.append(`
                    <div class="product add-product">
                        <h3>Thêm sản phẩm so sánh</h3>
                        <div class='addlink'>
                            <a class='openProductModal' onclick="openProductModal()">+ Thêm sản phẩm</a>
                        </div>
                    </div>
                `);
                }

                // 🔄 Cập nhật lại bảng so sánh sau khi thêm/xóa sản phẩm
               loadComparisonTable();
            }
        });
    }

    // Gọi hàm khi trang tải
    $(document).ready(function () {
        loadCompareList();
    });

    function removeProduct(ipid) {
        $.ajax({
            type: "POST",
            url: "/AjaxAPI.aspx/RemoveFromCompare",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ ipid: ipid }),
            success: function (response) {
                if (response.d === "success") {
                    // Tìm và xóa sản phẩm khỏi giao diện
                    let productElement = document.querySelector(`.product[data-ipid="${ipid}"]`);
                    if (productElement) {
                        productElement.remove();
                    } else {
                        console.warn(`Không tìm thấy sản phẩm có ipid=${ipid}`);
                    }

                    // Cập nhật URL
                    let url = new URL(window.location.href);
                    let params = new URLSearchParams(url.search);

                    // Lấy danh sách ipid từ URL và xử lý chính xác
                    let ipidList = params.get("ipid") ? params.get("ipid").split(",") : [];

                    // Chuyển danh sách về dạng số nguyên để xử lý chính xác
                    ipidList = ipidList.map(id => id.trim()).filter(id => id !== "" && id !== String(ipid));

                    // Cập nhật URL dựa trên danh sách mới
                    if (ipidList.length > 0) {
                        params.set("ipid", ipidList.join(","));
                    } else {
                        params.delete("ipid");
                    }

                    // Cập nhật URL mà không load lại trang
                    window.history.replaceState({}, "", `${url.pathname}?${decodeURIComponent(params.toString())}`);

                    // Cập nhật danh sách so sánh
                    loadCompareList();
                    loadComparisonTable();

                    // Reload lại trang để cập nhật danh sách
                    //  location.reload();

                }
            }
        });
    }


    function loadComparisonTable_ok() {
        $.ajax({
            type: "POST",
            url: "/AjaxAPI.aspx/GetComparisonData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log("Dữ liệu từ API:", response);

                let data = (typeof response.d === "string") ? JSON.parse(response.d) : response.d;
                console.log("Dữ liệu sau khi parse:", data);

                if (data.success && data.data.length > 0) {
                    let html = "<div class='specifications'>";

                    data.data.forEach(group => {
                        html += `<h3>${group.Name}</h3>`;
                        html += "<table>";

                        let products = group.Products;

                        // Lấy tổng số cột cần hiển thị (số sản phẩm)
                        let totalColumns = totalCompareProducts;

                        // Lấy tất cả thuộc tính có trong danh sách sản phẩm
                        let allAttributes = new Set();
                        products.forEach(product => {
                            product.Attributes.forEach(attr => allAttributes.add(attr.Name));
                        });

                        // Duyệt qua thuộc tính để đảm bảo số cột luôn đúng
                        allAttributes.forEach(attributeName => {
                            html += `<tr><td style="text-align: left; font-weight: bold;">${attributeName}</td>`; // Căn trái

                            let addedColumns = 0; // Số cột đã thêm trong hàng này

                            products.forEach(product => {
                                let attrValue = product.Attributes.find(attr => attr.Name === attributeName)?.Value || "";
                                html += `<td>${attrValue}</td>`;
                                addedColumns++;
                            });

                            // Nếu số cột chưa đủ, bổ sung thêm các ô trống
                            while (addedColumns < totalColumns) {
                                html += `<td></td>`;
                                addedColumns++;
                            }

                            html += "</tr>";
                        });

                        html += "</table>";
                    });

                    html += "</div>";
                    $("#comparison-container").html(html);
                } else {
                    $("#comparison-container").html("<p class='nodate'>Không có dữ liệu so sánh.</p>");
                }
            },
            error: function (xhr, status, error) {
                console.error("Lỗi khi gọi API:", error);
            }
        });
    }




    // Gọi hàm khi trang tải xong
    $(document).ready(function () {
        loadComparisonTable();
    });

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


</script>
