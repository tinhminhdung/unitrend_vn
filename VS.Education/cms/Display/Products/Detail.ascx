<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Detail" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<%@ Register Src="~/cms/display/products/FoooterSoSanh.ascx" TagPrefix="uc1" TagName="FoooterSoSanh" %>
<script type="text/javascript">
    var r = { 'special': /[\W]/g, 'quotes': /[^0-9^]/g, 'notnumbers': /[^a-zA]/g }
    function valid(o, w) {
        o.value = o.value.replace(r[w], '');
        if (o.value == '') {
            o.value = '1';
        }
    }
</script>
<uc1:Nav_conten runat="server" ID="Nav_conten" />
<!-- End Main Breadcrumb -->
<!-- Main Content -->
<div class="main-content">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <div class="pd-top">
                    <div class="row">
                        <div itemscope itemtype="http://schema.org/Product"></div>
                        <asp:Literal ID="ltmeta" runat="server"></asp:Literal>
                        <meta itemprop="shop-currency" content="VND">
                        <div class="col-md-5">
                            <div class="prod-image clearfix">
                                <div class="sp-loading">
                                    <img src="/Resources/images/sp-loading.gif" alt=""><br>
                                    LOADING IMAGES
                                </div>
                                <div class="sp-wrap">
                                    <%=Viewprodetail()%>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">

                            <div class="chitietsp">

                                <div class="product-container">
                                    <h1 class="product-title">
                                        <asp:Literal ID="ltname" runat="server"></asp:Literal></h1>
                                    <div class="product-info">
                                        <div class="col-md-6" style="padding: 0px; margin: 0px">Thương hiệu:
                                            <asp:Literal ID="ThuongHieu" runat="server"></asp:Literal></div>
                                        <div class="col-md-6">Model:
                                            <asp:Literal ID="Model" runat="server"></asp:Literal></div>
                                    </div>
                                    <div class="product-info">
                                        <div class="col-md-6" style="padding: 0px; margin: 0px">Xuất xứ:
                                            <asp:Literal ID="XuatXu" runat="server"></asp:Literal></div>
                                        <div class="col-md-6">Bảo hành:
                                            <asp:Literal ID="ThoiGianBaoHanh" runat="server"></asp:Literal></div>
                                    </div>


                                    <div class="product-info giabancang">
                                        <div class="col-md-6" style="padding: 0px; margin: 0px">
                                            <span class="price">Giá bán <asp:Literal ID="lttengiaban" runat="server"></asp:Literal>: <span>
                                                <asp:Literal ID="ltprices" runat="server"></asp:Literal>
                                                <asp:Literal ID="ltdonvi" Visible="false" runat="server"></asp:Literal></span>
                                            </span>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="status">
                                                Tình trạng:
                                                <asp:Literal ID="TrangThaiHang" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="product-info2 giabancang giabanVAT">
                                        <div class="col-md-6" style="padding: 0px; margin: 0px">
                                            <span class="price">Giá bán <asp:Literal ID="lttengiaban2" runat="server"></asp:Literal>: <span>
                                                <asp:Literal ID="ltprices2" runat="server"></asp:Literal>
                                                <asp:Literal ID="ltdonvi2" Visible="false" runat="server"></asp:Literal></span>
                                            </span>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="status">
                                            </div>
                                        </div>
                                    </div>

                                  <asp:Literal ID="lttengiaban_css" runat="server"></asp:Literal>


                                    <div class="row col-md-12">
                                        <div class="row col-md-8">
                                        </div>
                                        <div class="row col-md-5" style="padding-right: 0px; margin-right: 0px">
                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                    <div class="button-container" style="<%=Ngungbanhang()%>">
                                        <asp:LinkButton CssClass="button nenbt primary-button" ID="lnkaddtocart" runat="server" OnClick="lnkaddtocart_Click">Đặt Hàng Ngay <span>Giao hàng tận nơi</span></asp:LinkButton>
                                        <asp:LinkButton CssClass="button nenbt green-button" ID="LinkButton1" runat="server" OnClick="lnkaddtocartgh_Click">Thêm Vào Giỏ Hàng <span>Để tìm hiểu thêm sản phẩm khác</span></asp:LinkButton>
                                        <asp:Literal ID="ltaddcompare" runat="server"></asp:Literal>
                                        <%--     <a href="#" class="button nenbt">So Sánh <span>Với các sản phẩm khác cùng loại</span></a>--%>
                                        <a href="#" class="button nenbt open-modal-btn" onclick="openModal()">Yêu Cầu Tư Vấn <span>Nếu bạn cần tìm hiểu thêm</span></a>
                                    </div>
                                </div>

                                

                                <div class="spthaythe">
                                    <asp:Literal ID="ltsanphamthaythe" runat="server"></asp:Literal></div>

                            </div>
                            <asp:Literal ID="ltcss" runat="server"></asp:Literal>
                            <%-- <p>
                                <strong><%=label("l_productid") %>:</strong>
                                <asp:Literal ID="ltcode" runat="server"></asp:Literal>
                            </p>
                            <p>
                                <strong><%=label("cannang") %>:</strong>
                                <asp:Literal ID="ltcan" runat="server"></asp:Literal>
                                Gram
                            </p>
                            <div class="pdid">
                                <asp:Literal ID="ltdesc" runat="server"></asp:Literal>
                            </div>--%>

                            <%--    <div class="prod-price clearfix">
                                <span class="compare-price"><b><%=label("Niemyet") %>: </b><del>
                                    <asp:Literal ID="ltpriceoll" runat="server"></asp:Literal>
                                    đ</del></span>
                            </div>--%>


                            <span style="display: none">
                                <input type="number" class="input" value="1" onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')" id="proQuantity" min="1" max="1000" />
                                <asp:LinkButton CssClass="product-orders" ID="lnkaddtocartgh" runat="server" OnClick="lnkaddtocartgh_Click"><%=label("Themvaogiohang") %></asp:LinkButton>
                            </span>

                            <div style="clear: both; height: 20px"></div>
                        </div>
                    </div>
                    <div class="pd-bottom">
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <ul class="nav nav-tabs pd-nav">
                                        <li role="presentation" class="activen active"><a href="#pd-thong-tin" aria-controls="pd-thong-tin" role="tab" data-toggle="tab">
                                            <img src="/Resources/2025/ic1.jpg" style="width: 20px;">
                                            <%=label("l_productcontent") %></a></li>
                                        <li role="presentation" class="activen"><a href="#pd-tailieu" aria-controls="pd-tailieu" role="tab" data-toggle="tab">
                                            <img src="/Resources/2025/ic2.jpg" style="width: 20px;">
                                            Tài liệu - Phần mềm</a></li>
                                    </ul>
                                    <div class="tab-content ">
                                        <div role="tabpanel" class="tab-pane active" id="pd-thong-tin">
                                            <div class="News-content">
                                                <div class="no_copyy">
                                                    <asp:Literal ID="ltdesc" runat="server"></asp:Literal></div>
                                                <div style="clear: both; height: 5px"></div>
                                                <div class="no_copyy">
                                                    <asp:Literal ID="lstsosanh" runat="server"></asp:Literal></div>
                                                <div style="clear: both; height: 0px"></div>
                                                <asp:Literal ID="ltdetail" runat="server"></asp:Literal>
                                            </div>
                                        </div>

                                        <div role="tabpanel" class="tab-pane tailieusp" id="pd-tailieu">
                                            <div class="containertl">
                                                <asp:Repeater ID="rp_tailieu" runat="server">
                                                    <ItemTemplate>
                                                        <div class="item">
                                                            <a href="<%#Eval("Link")%>" target="_blank">
                                                                <img class="img-responsive anhtailieus" alt="<%#(Eval("Name").ToString())%>" title="<%#(Eval("Name").ToString())%>" src="<%#(Eval("Images").ToString())%>"></a>
                                                            <p><a href="<%#Eval("Link")%>" target="_blank"><%#(Eval("Name").ToString())%></a></p>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="pd-tags">

                        <asp:Literal ID="ltrTag" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <uc1:Lefmenu runat="server" ID="Lefmenu" />
            </div>

        </div>
    </div>
</div>
<section class="main-related">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2 class="blog-heading"><%=label("sanphamcungloai") %></h2>
                <div class="related-content" id="product-related">
                    <asp:Repeater ID="rpcates" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <div class="product-item">
                                    <div class="pro-image">
                                        <%--<div class="sale-label sale-top-right">Sale</div>--%>
                                        <a href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html'><%#MoreAll.MorePro.Image_width_height_Title_Alt_css("img-responsive",Eval("ImagesSmall").ToString(),"240","240",Eval("Name").ToString(),Eval("Name").ToString())%></a>
                                    </div>
                                    <div class="biz-qv-button-wrap"><a href="javascript:void(0)" rel="popuprel3" class="popup biz-qv-button" onclick="Xemnhanh(<%#Eval("ipid")%>,'<%#Eval("Name")%>')"><%=label("xemnhanh") %></a></div>
                                    <div class="pro-content">
                                        <h4 class="pro-name">
                                            <a href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html'><%#Eval("Name") %></a>
                                        </h4>
                                        <div class="pro-price">
                                            <p class="price-new"><%#MoreAll.MorePro.FormatMoney(Eval("Price").ToString())%></p>
                                            <p class="price-old"><del><%#MoreAll.MorePro.Detail_Price(Eval("OldPrice").ToString())%></del></p>
                                        </div>
                                        <div class="link-detail"><span><a href="<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html"><%=label("chitiet") %></a></span></div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</section>
<div id="total" style="display: none"></div>
<input type="text" id="idsoluong3" value="1" runat="server" hidden="hidden" />
<div class="proPrice" style="display: none">
    <h4 id='curPrice'>
        <asp:Literal ID="ltprice" runat="server"></asp:Literal>đ</h4>
</div>
<asp:HiddenField ID="hdCurAmount" Value="1" runat="server" />
<asp:HiddenField ID="hdipid" Value="1" runat="server" />
<script type="text/javascript">
    $("#total")[0].innerHTML = $(".proPrice").find("h4").text();
    $("#proQuantity").on("change keyup", function () {
        var soluong = $('#proQuantity').val();
        if (soluong > 1000) {
            $("#proQuantity").val('1000');
            $("input[id$='idsoluong3").val('1000');
            soluong = 1000;
        }
        $("input[id$='idsoluong3").val(soluong);
        var price = $("#proQuantity").val();
        $("#<%=hdCurAmount.ClientID %>").val(price);
        var money = $(".proPrice").find("h4").text();
        var cur = money.substring((money.indexOf(" ") + 1));
        var quantity = $("#proQuantity").val();
        //money = money.substring(0, money.indexOf(" "));         
        var arr = money.split(",");
        var total = 0;
        for (var i = 0; i <= (arr.length - 1); i++) {
            money = money.replace(',', '');
        }
        money = parseFloat(money);
        total = money * quantity;
        total = total.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
        total = total.substr(0, total.indexOf('.'))
        $("#total")[0].innerHTML = total + " " + cur;
    });
</script>


<div class="chitietsp">
    <div class="modal-overlay" id="modalOverlay">
        <div class="modal">
            <span class="close-modal" onclick="closeModal()">×</span>
            <div class="modal-left">
                <asp:Literal ID="ltimg" runat="server"></asp:Literal>
                <h2 class="tieudess"><span id="ltname3">
                    <asp:Literal ID="ltname2" runat="server"></asp:Literal></span></h2>
            </div>
            <div class="modal-right">

                <div class="form-group">
                    <input type="text" id="name" name="name" placeholder="Tên của bạn">
                    <span class="error-message"></span>
                </div>
                <div class="form-group">
                    <input type="text" id="phone" name="phone" placeholder="Số điện thoại*">
                    <span class="error-message"></span>
                </div>
                <div class="form-group">
                    <input type="email" id="email" name="email" placeholder="Email">
                    <span class="error-message"></span>
                </div>

                <div class="form-group">
                    <textarea id="message" name="message" placeholder="Nội dung*"></textarea>
                    <span class="error-message"></span>
                </div>
                <div style="height: 8px;"></div>
                <a class="submit-btn" id="submitBtn" onclick="submitBtn()">Gửi yêu cầu</a>
            </div>
        </div>
    </div>
</div>

<script>
    function openModal() {
        document.getElementById('modalOverlay').style.display = 'flex';
    }

    function closeModal() {
        document.getElementById('modalOverlay').style.display = 'none';
    }

    // Đóng modal khi bấm ra ngoài
    document.getElementById('modalOverlay').addEventListener('click', function (e) {
        if (e.target === this) {
            closeModal();
        }
    });

    function submitBtn() {
        debugger;
        // Xóa thông báo lỗi cũ
        $('.error-message').text('');
        let isValid = true;

        // Kiểm tra từng trường
        if ($('#name').val().trim() === '') {
            $('#name').next('.error-message').text('Vui lòng nhập tên của bạn');
            isValid = false;
        }

        if ($('#phone').val().trim() === '') {
            $('#phone').next('.error-message').text('Vui lòng nhập số điện thoại');
            isValid = false;
        } else if (!/^\d{10,11}$/.test($('#phone').val().trim())) {
            $('#phone').next('.error-message').text('Số điện thoại không hợp lệ');
            isValid = false;
        }

        if ($('#email').val().trim() === '') {
            $('#email').next('.error-message').text('Vui lòng nhập email');
            isValid = false;
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test($('#email').val().trim())) {
            $('#email').next('.error-message').text('Email không hợp lệ');
            isValid = false;
        }

        if ($('#message').val().trim() === '') {
            $('#message').next('.error-message').text('Vui lòng nhập nội dung');
            isValid = false;
        }

        if (isValid) {
            var tenSanPham = $('#ltname3').text().trim();
            console.log("Tên sản phẩm:", tenSanPham);

            // Lấy dữ liệu từ form
            var obj = {
                productName: tenSanPham,
                name: $('#name').val().trim(),
                phone: $('#phone').val().trim(),
                email: $('#email').val().trim(),
                message: $('#message').val().trim()
            };

            console.log("Dữ liệu gửi đi:", obj);

            // Kiểm tra thông tin nhập
            if (obj.TenNguoiDung === "" || obj.SoDienThoai === "" || obj.NoiDung === "") {
                alert("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            $.ajax({
                type: "POST",
                url: '/index.aspx/Save_TuVan_SanPham',
                data: JSON.stringify({ info: obj }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    if (response.d === "1") {
                        alert("Gửi yêu cầu thành công!");
                    } else {
                        alert("Lưu thất bại! Vui lòng thử lại.");
                    }
                },
                error: function () {
                    alert("Lỗi..! Vui lòng kiểm tra lại dữ liệu nhập.");
                }
            });

            closeModal();
        }
    }

</script>

<uc1:FoooterSoSanh runat="server" ID="FoooterSoSanh" />
