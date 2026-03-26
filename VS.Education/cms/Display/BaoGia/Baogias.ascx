<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Baogias.ascx.cs" Inherits="VS.E_Commerce.cms.Display.BaoGia.Baogias" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="/cms/display/contact/Resources/css/StyleSheet.css" rel="stylesheet" type="text/css" />
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
    <div class="container">
        <div class="row">
             <div class="col-md-2"> </div>
            <div class="col-md-8" style=" padding:0px; margin:0px">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">

                        <div class="noidungtimkiem">
                            <div style="padding-top: 10px; line-height: 22px;">
                                <div class="yeucaubb">
                                    YÊU CẦU BÁO GIÁ
               <br />
                                    SẢN PHẨM THƯƠNG HIỆU UNI-TREND
                                </div>
                                <div class="yeucaubbtb">
                                    Quý khách vui lòng cung cấp đầy đủ thông tin vào from bên dưới để chúng tôi liên hệ phản hồi báo giá
                                </div>
                            </div>

                            <div style="clear: both"></div>
                            <div class="fomyeucau" id="nhanTuVan">
                                <div style="padding: 10px 10px 10px 10px">
                                    <asp:Label ID="ltmsg" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-md-12 col-sm-12 col-xs-12 KK">
                                        <div class="col-md-5 col-sm-12 col-xs-12 yeucauinn chung KK1">
                                            <div class="col-md-4 col-sm-4 col-xs-4 yeucauName">
                                                Tên KH:
                                            </div>
                                            <div class="col-md-8 col-sm-8 col-xs-8 TextBoxs">
                                                <asp:TextBox ID="TenKH" CssClass="required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-5 col-sm-12 col-xs-12 yeucauinn chung KK2">
                                            <div class="col-md-5 col-sm-4 col-xs-4 yeucauName">
                                                Điện thoại:
                                            </div>
                                            <div class="col-md-7 col-sm-8 col-xs-8 TextBoxs">
                                                <asp:TextBox ID="DienThoai" CssClass="required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="col-md-5 col-sm-12 col-xs-12 yeucauinn chung KK1">
                                            <div class="col-md-4 col-sm-4 col-xs-4 yeucauName">
                                                Địa chỉ:
                                            </div>
                                            <div class="col-md-8 col-sm-8 col-xs-8 TextBoxs">
                                                <asp:TextBox ID="DiaChi" CssClass="required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-5 col-sm-12 col-xs-12 yeucauinn chung KK2">
                                            <div class="col-md-5 col-sm-4 col-xs-4 yeucauName">
                                                Email:
                                            </div>
                                            <div class="col-md-7 col-sm-8 col-xs-8 TextBoxs">
                                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-5 col-sm-12 col-xs-12 yeucauinn chung KK1">
                                            <div class="col-md-4 col-sm-4 col-xs-4 yeucauName">
                                                Model SP:
                                            </div>
                                            <div class="col-md-8 col-sm-8 col-xs-8 TextBoxs">
                                                <asp:TextBox ID="ModelSP" CssClass="required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-5 col-sm-12 col-xs-12 yeucauinn chung KK2">
                                            <div class="col-md-5 col-sm-4 col-xs-4 yeucauName">
                                                Link SP:
                                            </div>
                                            <div class="col-md-7 col-sm-8 col-xs-8 TextBoxs">
                                                <asp:TextBox ID="LinkSP" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 KK">

                                        <span>File đính kèm:</span>
                                        <label class="file-upload">
                                            <span><strong>CHỌN FILE ĐÍNH KÈM</strong></span>
                                            <asp:FileUpload ID="flimage" runat="server"></asp:FileUpload>
                                        </label>
                                        <label class="file-upload">
                                            <span><strong>CHỌN FILE ĐÍNH KÈM</strong></span>
                                            <asp:FileUpload ID="flimage2" runat="server"></asp:FileUpload>
                                        </label>
                                        <span>(Hình ảnh cửa sản phẩm hoặc file word, exell ..)</span>
                                    </div>

                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12" style="text-align: center">
                                    <asp:Button ID="Button1" OnClientClick="return SendTuVan();" runat="server" ValidationGroup="GInfo" Text="Gửi yêu cầu" CssClass="guiyeucau" OnClick="btgui_Click" />
                                    <asp:Button ID="btxoayeucau" runat="server" ValidationGroup="GInfo" Text="XÓA" CssClass="xoayeucau" OnClick="btxoayeucau_Click" />
                                </div>



                            </div>
                            <div style="clear: both; height: 20px;"></div>
                            <div style="padding-top: 10px; line-height: 22px;">
                                <div class="Anhmap" style="margin-left: 0px">
                                    <asp:Literal ID="ltmap" runat="server"></asp:Literal>
                                </div>
                            </div>


                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">

                        <div class="baogia">
                            <div class="thank-you-container">
                                <p class="title">LỜI CẢM ƠN TỪ UNI-TREND.VN</p>
                                <p>
                                    Cảm ơn quý khách <span class="customer-name"><asp:Literal ID="lttenkhachhang" runat="server"></asp:Literal></span> đã quan tâm sản phẩm thương hiệu Uni-Trend
                                <br>
                                    và gửi yêu cầu báo giá đến Uni-Trend.vn
                                </p>
                                <p>Mã yêu cầu báo giá là: <span class="quote-id"><asp:Literal ID="ltMaBaoGia" runat="server"></asp:Literal></span></p>
                                <p>Mọi thông tin hỗ trợ có thể liên hệ hotline: 0912345678 trong giờ làm việc</p>
                                <p>Quý khách có thể tra cứu lại mã báo giá và tình trạng xử lý trong tài khoản đăng nhập</p>
                                <p class="footer2">XIN TRÂN TRỌNG CẢM ƠN</p>
                            </div>
                        </div>

                    </asp:View>
                </asp:MultiView>

            </div>

            <div class="col-md-2">
             <%--   <uc1:Lefmenu runat="server" ID="Lefmenu" />--%>
            </div>
        </div>
    </div>

</div>



<style>
    .noidungtimkiem {
        text-align: left;
        width: 100%;
        margin: auto;
        line-height: 24px;
    }
</style>

<script type="text/javascript">
    function SendTuVan() {
        var obError = undefined;
        $("#nhanTuVan .required").each(function () {
            $(this).removeClass("boxFocus");
            if (obError == undefined && $(this).val() === '') {
                obError = $(this);
                return false;
            }
        });

        if (obError != undefined) {
            obError.focus();
            obError.addClass("boxFocus");
            alert("Vui lòng nhập đầy đủ thông tin trong các ô có dấu * trước khi gửi");
            return false;
        }
    };
</script>
