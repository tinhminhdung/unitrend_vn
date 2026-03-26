<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="utf-8" CodeBehind="index.aspx.cs" Debug="true" Inherits="VS.E_Commerce.index1" ValidateRequest="false" EnableViewStateMac="false" ViewStateEncryptionMode="Never" MaxPageStateFieldLength="40" EnableEventValidation="false" %>

<%@ Register Src="cms/display/Control.ascx" TagName="Control" TagPrefix="uc1" %>
<%@ Register Src="cms/display/Header.ascx" TagName="Header" TagPrefix="uc2" %>
<%@ Register Src="cms/display/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%--<%@ OutputCache VaryByParam="none" Duration="1"   %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=MoreAll.Templates.Templates.WebTitle(hp,ipid, Modul)%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=0">
    <meta property="og:type" content="article" />
    <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="vi" lang="vi-VN">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="content-language" content="vi">
    <meta property="og:locale" content="vi_VN" />
    <asp:Literal ID="ltFacebook" runat="server"></asp:Literal>
    <meta name="robots" content="index,follow,all" />
    <meta name='revisit-after' content='1 days' />
    <link href="/Resources/CssChuan/Css_All.css" rel="stylesheet" />
    <link href='/Resources/assets/bootstrap.minc4a8.css?1495462948728' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/owl.carouselc4a8.css?1495462948728' rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link href="Resources/css/font-awesome.min.css" rel="stylesheet" />
    <link href='/Resources/assets/stylec4a8.css?1495462948728' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/responsivec4a8.css?1495462948728' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,500,700&amp;subset=latin,vietnamese' rel='stylesheet' type='text/css'>

    <script src='/Resources/assets/jquery-1.11.3.minc4a8.js?1495462948728' type='text/javascript'></script>
    <script src='/Resources/assets/bootstrap.minc4a8.js?1495462948728' type='text/javascript'></script>
    <script src='/Resources/assets/owl.carousel.minc4a8.js?1495462948728' type='text/javascript'></script>
    <script src='/Resources/assets/mainc4a8.js?1495462948728' type='text/javascript'></script>
    <link href="/Resources/Responsive/css/flexnav.css" rel="stylesheet" />
    <link href="/Resources/css/Mobile.css" rel="stylesheet" />
    <%#GoogleAnalytics()%>
    <!-- Zoom Products -->
    <link href="/Resources/css/smoothproducts.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/Resources/Zoomanh/zomphonganh.css">
    <!--Ènd Zoom Products -->
</head>
<body>
    <asp:Literal ID="ltcFacebook" runat="server"></asp:Literal>
    <%--End Screen 2 ben --%>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--PopUp--%>
        <asp:Literal ID="ltpopup" runat="server"></asp:Literal>
        <asp:Literal ID="ltclose" runat="server"></asp:Literal>
        <asp:Literal ID="ltimg" runat="server"></asp:Literal>
        <asp:Literal ID="ltconten" runat="server"></asp:Literal>
        <%--End PopUp--%>
        <asp:Literal ID="ltscreen" runat="server"></asp:Literal>
        <div class="page">
            <uc2:Header ID="Header1" runat="server" />
            <uc1:Control ID="Control1" runat="server" />
            <uc3:Footer ID="Footer1" runat="server" />
            <%=MoreAll.Other.Giatri("Livechat")%>
            <%if (Request["su"] == null && Modul == "")
                {%>
            <div style="display: none"><%=MoreAll.Other.Giatri("Seo")%></div>
            <%} %>
        </div>
    </form>
    <%--PopUp--%>
    <link rel="stylesheet" href="/Resources/js/popUp/general.css" type="text/css" media="screen" />
    <script src="/Resources/js/popUp/popup.js" type="text/javascript"></script>
    <%--End PopUp--%>
    <!-- ShopCart -->
    <link href="/Resources/ShopCart/css/popup.css" rel="stylesheet" type="text/css" />
    <script src="/Resources/ShopCart/js/popup.js" type="text/javascript"></script>
    <link href="/Resources/ShopCart/css/Stylecart.css" rel="stylesheet" type="text/css" />
    <!-- ShopCart -->
    <script src="/Resources/Responsive/js/jquery.flexnav.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".flexnav").flexNav();
        });
    </script>
    <script src="/Resources/js/jquery-scrolltofixed.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () { $('.Menutop').scrollToFixed(); });
    </script>
    <%-- Ajaxloading--%>
    <%-- popupbox--%>
    <div class="popupbox3" id="popuprel3">
        <div class="closes">
            <img src="/Resources/ShopCart/images/thoat.jpg" /></div>
        <div id="intabdiv3">
            <div id="scoll">
                <div id="cartContent"></div>
            </div>
        </div>
    </div>
    <div style="display: none;" id="fade"></div>

    <div id="Ajaxloading">
        <div class="inner">
            <img src="/Resources/ShopCart/images/ajax-loader_2.gif"><p><%=label("dangxuly") %>...</p>
        </div>
    </div>
    <!-- Zoom Products -->
    <script type="text/javascript" src="/Resources/js/smoothproducts.min.js"></script>
    <script type="text/javascript" src="/Resources/Zoomanh/zomphonganh.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $('.sp-wrap').smoothproducts();
        });
    </script>
    <script type="text/javascript">
        function Xemnhanh(id, name) {
            $body = $("#Loadingshop");
            $.ajax({
                type: "POST",
                url: "/index.aspx/Detail",
                data: "{id:'" + id.toString() + "',quantity:'1'}",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: "true",
                success: function (response) {
                    $('#cartContent').html(response.d);
                    $('.phonganhct').zomphonganh();
                },
                error: function (response) {
                },
                beforeSend: function () {
                    $body.addClass('loading');
                },
                complete: function () {
                    $body.removeClass("loading");
                }
            });
        }
    </script>
    <script type="text/javascript">
        function closeelement() {
            div = document.getElementById("jName"); div.style.display = "none";
        }
        function UpdateOrder(id, name) {
            $body = $("#Loadingshop");
            var numPro = "#" + id;
            //bắt đầu
            debugger;
            $.ajax({
                type: "POST",
                url: "/index.aspx/Up_Order",
                data: "{id:'" + id.toString() + "',quantity:'" + $(numPro).val().toString() + "'}",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: "true",
                success: function (response) {
                },
                error: function (response) {
                    // alert(response.status + ' ' + response.statusText);
                },
                beforeSend: function () {
                    $body.addClass('loading');
                },
                complete: function () {
                    $body.removeClass("loading");
                }
            });
            $("#jName").show();
            $("#jName")[0].innerHTML = '<a href="/gio-hang.html" style="color:#000; font-size:12px;"><b style="color:#ff3a00; font-size:12px;">Bạn đã thêm <b style="color:#ff3a00; font-size:13px;">' + $(numPro).val().toString() + '</b> Sản phẩm vào giỏ hàng</b><br />' + name + '</a>';
            setTimeout(closeelement, 3000);
        }
    </script>
    <script type="text/javascript">
        function closeelement() {
            div = document.getElementById("jName"); div.style.display = "none";
        }
        function Dathang(id, name) {
            $body = $("#Loadingshop");
            var numPro = "#" + id;
            //bắt đầu
            debugger;
            $.ajax({
                type: "POST",
                url: "/index.aspx/Up_Order",
                data: "{id:'" + id.toString() + "',quantity:'" + $(numPro).val().toString() + "'}",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: "true",
                success: function (response) {
                    window.location.href = 'gio-hang.html';
                },
                error: function (response) {
                    // alert(response.status + ' ' + response.statusText);
                },
                beforeSend: function () {
                    $body.addClass('loading');
                },
                complete: function () {
                    $body.removeClass("loading");
                }
            });
            $("#jName").show();
            $("#jName")[0].innerHTML = '<a href="/gio-hang.html" style="color:#000; font-size:12px;"><b style="color:#ff3a00; font-size:12px;">Bạn đã thêm <b style="color:#ff3a00; font-size:13px;">' + $(numPro).val().toString() + '</b> Sản phẩm vào giỏ hàng</b><br />' + name + '</a>';
            setTimeout(closeelement, 3000);
            window.location.href = 'gio-hang.html';
        }
    </script>


    <asp:Literal ID="lttimkiems" runat="server"></asp:Literal>
<script>
    $(document).ready(function () {
        console.log("Document is ready.");

        function handleInput($input, suggestionListId) {
            let value = $input.val().toLowerCase();
            console.log("User input:", value);
            let suggestionList = $(suggestionListId);
            suggestionList.empty();

            if (value) {
                let filteredProducts = allProducts.filter(p => p.ProductName.toLowerCase().includes(value));
                console.log("Filtered products:", filteredProducts);

                if (filteredProducts.length > 0) {
                    suggestionList.show();
                    filteredProducts.forEach(product => {
                        let formattedPrice = Number(product.Price)
                            .toLocaleString("vi-VN")
                            .replace(/\./g, ",") + " đ";

                        let item = `
                    <div class="suggestion-item" 
                         data-name="${product.ProductName}" 
                         data-link="${product.TangName}"
                         data-ipid="${product.ProductID}">
                        <img src="${product.ImageURL}" alt="Sản phẩm">
                        <div>
                            <div>${product.ProductName}</div>
                            <div class="price">${formattedPrice}</div>
                        </div>
                    </div>
                    `;
                        suggestionList.append(item);
                    });

                    console.log("Suggestions displayed.");

                    suggestionList.find(".suggestion-item").click(function () {
                        let productName = $(this).attr("data-name");
                        let productLink = $(this).attr("data-link");
                        let productipid = $(this).attr("data-ipid");

                        console.log("Product selected:", productName);
                        console.log("Redirecting to:", productLink);

                        $input.val(productName);
                        suggestionList.hide();

                        if (productLink) {
                            window.location.href = "/" + productLink + "_id" + productipid + ".html";
                        }
                    });
                } else {
                    console.log("No matching products found.");
                    suggestionList.hide();
                }
            } else {
                console.log("Input is empty, hiding suggestions.");
                suggestionList.hide();
            }
        }

        $("#txtkeyword, #txtkeyword1").on("input", function () {
            let suggestionListId = $(this).attr("id") === "txtkeyword" ? "#suggestions-list" : "#suggestions-list1";
            handleInput($(this), suggestionListId);
        });

        $(document).click(function (event) {
            if (!$(event.target).closest(".search-container").length) {
                console.log("Clicked outside, hiding suggestions.");
                $(".suggestions-list").hide();
                $(".suggestions-list1").hide();
            }
        });

        $("#txtkeyword, #txtkeyword1").on("focus", function () {
            $(this).prop("placeholder", "");
        });

        $("#txtkeyword, #txtkeyword1").on("blur", function () {
            if (!$(this).val()) {
                $(this).prop("placeholder", "Nhập từ khóa...");
            }
        });
    });

</script>
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-DXC1HDXEZF"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-DXC1HDXEZF');
    </script>
    <div id="jName" style="margin-bottom: 25px; text-align: center; background: #fff8d1 none repeat scroll 0 0; border: 1px solid #fcab0f; border-radius: 3px; bottom: 15px; color: #000; display: none; padding: 10px; position: fixed; right: 0; width: 300px; z-index: 9999999;"></div>
</body>
</html>
