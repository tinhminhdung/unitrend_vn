<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cart.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Cart" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="/cms/display/contact/Resources/css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function giam(str) {
        var abc = document.getElementsByName(str);
        abc[0].value = parseInt(abc[0].value) - 1;
    }
    function Tang(str) {
        var Tbc = document.getElementsByName(str);
        Tbc[0].value = parseInt(Tbc[0].value) + 1;
    }
</script>
<style>
    input[type="radio"], input[type="checkbox"] {
        line-height: normal;
        margin: 1px 5px 2px !important;
    }
</style>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
        <section class="main-product-home block-home">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="product-home-title clearfix">
                            <h3><%=label("Giohang") %></h3>
                        </div>
                        <div class="clearfix">
                            <div class="col-md-12 col-sm-12 col-xs-12 no-padding">
                                <asp:Panel ID="pnmessage" runat="server">
                                    <table style="border-collapse: collapse" bordercolor="#c3c3c3" cellpadding="0" width="99%" border="0">
                                        <tr>
                                            <td height="40" align="center">
                                                <span style="color: Red; text-align: center; font-weight: bold; line-height: 22px;">
                                                    <asp:Literal ID="ltnoiteminyourcart" runat="server"></asp:Literal><%=label("Not_empty_cart")%> </span>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>

                                <asp:Panel ID="pnOrder" runat="server" Visible="false">
                                    <div class="table-responsive">
                                        <div class='frm_cart'>

                                            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="ItemDataBound_RP">
                                                <HeaderTemplate>
                                                    <table cellpadding="0" class="table" cellspacing="0" class="dcart" width="100%">
                                                        <tr class="procart">
                                                            <td align="left"><strong>STT</strong></td>
                                                            <td align="center"><strong><%=label("l_images")%></strong></td>
                                                            <td align="center"><strong><%=label("l_productid")%></strong></td>
                                                            <td align="center"><strong><%=label("l_producttitle")%></strong></td>
                                                            <td align="center"><strong><%=label("Dongian")%></strong></td>
                                                            <td align="center"><strong>VAT</strong></td>
                                                            <td align="center"><strong><%=label("lquantity")%></strong></td>
                                                            <td align="center"><strong><%=label("donvitinh")%></strong></td>
                                                            <td align="center"><strong><%=label("trongluong")%></strong></td>
                                                            <td align="center"><strong><%=label("l_tomoney")%></strong></td>
                                                            <%--    <td align="center"><strong><%=label("trongluong")%></strong></td>--%>
                                                            <%-- <td align="center"><strong><%=label("ghichu")%></strong></td>--%>
                                                            <td align="right"><strong>[<%=label("ldelete")%>]</strong></td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td height="30" align="center" class="TitleItem">
                                                            <asp:Label ID="lb_tt" runat="server"></asp:Label><asp:HiddenField ID="hiID" Value='<%# Eval("PID") %>' runat="server" />
                                                        </td>
                                                        <td align="left" class="TitleItem">
                                                            <img src="<%#Eval("Vimg")%>" style="width: 77px; height: auto; border: solid 1px #d7d7d7" /></td>
                                                        <td align="left" class="TitleItem"><%#Code(Eval("PID").ToString())%></td>
                                                        <td align="left" class="TitleItem" style=" width:350px"><strong><%#Eval("Name")%></strong></td>
                                                        <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_NO(Eval("Price").ToString())%> </td>
                                                        <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_NO(Eval("VATAmount").ToString())%> </td>
                                                        <td align="center" class="TitleItem">
                                                            <asp:TextBox ID="txtxQuantity" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity")%>' CssClass="txt_css" Width="40px" runat="server" OnTextChanged="txtxQuantity_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                                        <td align="center" class="TitleItem"><%#Donvitinh(Eval("PID").ToString())%> </td>
                                                        <td align="center" class="TitleItem"><%#Eval("Tongsocan")%> Gram</td>
                                                        <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_NO(Eval("Money").ToString())%> </td>
                                                        <%--    <td align="center" class="TitleItem"><%#Eval("TongTrongluong")%> -- tien:<%#Eval("TienTrongluong")%>--- <%#Eval("Tongsocan")%></td>--%>
                                                        <%--   <td align="center" class="TitleItem"><asp:TextBox ID="txtghichu"  Text='<%#DataBinder.Eval(Container.DataItem, "Ghichu")%>' CssClass="txt_css" runat="server" OnTextChanged="txtghichu_TextChanged" AutoPostBack="true" Height="50px" Width="100px" TextMode="MultiLine"></asp:TextBox></td>--%>
                                                        <td align="center">
                                                            <asp:LinkButton ID="LinkButton4" CommandName="delete" OnLoad="Delete_Load" CssClass="lnk" CommandArgument='<%#Eval("PID")%>' runat="server"><span class="cmdxoa"></span></asp:LinkButton></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <tr style="background: #fff5ee;">
                                                        <td height="30" align="center" class="TitleItem">
                                                            <asp:Label ID="lb_tt" runat="server"></asp:Label><asp:HiddenField ID="hiID" Value='<%# Eval("PID") %>' runat="server" />
                                                        </td>
                                                        <td align="left" class="TitleItem">
                                                            <img src="<%#Eval("Vimg")%>" style="width: 77px; height: auto; border: solid 1px #d7d7d7" /></td>
                                                        <td align="left" class="TitleItem"><%#Code(Eval("PID").ToString())%></td>
                                                        <td align="left" class="TitleItem"  style=" width:350px"><strong><%#Eval("Name")%></strong></td>
                                                        <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_NO(Eval("Price").ToString())%> </td>
                                                          <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_NO(Eval("VATAmount").ToString())%> </td>
                                                        <td align="center" class="TitleItem">
                                                            <asp:TextBox ID="txtxQuantity" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity")%>' CssClass="txt_css" Width="40px" runat="server" OnTextChanged="txtxQuantity_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                                        <td align="center" class="TitleItem"><%#Donvitinh(Eval("PID").ToString())%> </td>
                                                        <td align="center" class="TitleItem"><%#Eval("Tongsocan")%> Gram</td>
                                                        <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_NO(Eval("Money").ToString())%> </td>
                                                        <%--    <td align="center" class="TitleItem"><%#Eval("TongTrongluong")%> -- tien:<%#Eval("TienTrongluong")%>--- <%#Eval("Tongsocan")%></td>--%>
                                                        <%--        <td align="center" class="TitleItem"><asp:TextBox ID="txtghichu"  Text='<%#DataBinder.Eval(Container.DataItem, "Ghichu")%>' CssClass="txt_css"  runat="server" OnTextChanged="txtghichu_TextChanged" AutoPostBack="true" Height="50px" Width="100px" TextMode="MultiLine"></asp:TextBox></td>--%>
                                                        <td align="center">
                                                            <asp:LinkButton ID="LinkButton4" CommandName="delete" OnLoad="Delete_Load" CssClass="lnk" CommandArgument='<%#Eval("PID")%>' runat="server"><span class="cmdxoa"></span></asp:LinkButton></td>
                                                    </tr>
                                                </AlternatingItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr style="background: #eee">
                                                <td align="left" colspan="6"><span style="font-weight: bold; font-size: 15px; color: Red"><%=label("ltotal") %>:</span></td>
                                                <td align="left" colspan="2"><span style="color: Red; font-weight: bold; text-align: center; font-size: 15px; float: left; padding-left: 32px;">
                                                    <asp:Literal ID="ltProdinCart" runat="server"></asp:Literal></span></td>
                                                <td align="left"><span style="color: Red; font-weight: bold; text-align: center; padding-left: 10px; font-size: 15px; float: left;">
                                                    <asp:Literal ID="lttrongluong" runat="server"></asp:Literal>
                                                    Gram</span> </td>
                                                <td align="left" colspan="3"><span style="color: Red; font-weight: bold; text-align: center; padding-left: 10px; font-size: 15px; float: left;">
                                                    <asp:Literal ID="ltTotalOrder" runat="server"></asp:Literal></span>  </td>
                                            </tr>
                                            </table>
                                        </div>

                                    </div>

                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-4 col-sm-12 col-xs-12 no-padding">
                                                <div class="bacoc">
                                                    <span class="order-header"><%=label("ttkhachhang")%> </span>
                                                    <div class="maunen">
                                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                        <div class='frm-contact'>
                                                            <div style="width: 100%">
                                                                <div>
                                                                    <div class="labelll">
                                                                        <%=label("lt_fullname")%>:
                                                                    </div>
                                                                    <div>
                                                                        <asp:TextBox ID="txtName" CssClass="CSTextBox" ValidationGroup="GInfo" runat="server" Width="264px"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div style="width: 100%; float: left;">
                                                                    <div style="width: 50%; float: left;">
                                                                        <div class="labelll">
                                                                            <%=label("l_phone")%> 1:
                                                                        </div>
                                                                        <div>
                                                                            <asp:TextBox ID="txtPhone" CssClass="CSTextBox" ValidationGroup="GInfo" runat="server" Width="124px"></asp:TextBox>
                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtPhone"></cc1:FilteredTextBoxExtender>
                                                                        </div>
                                                                    </div>
                                                                    <div style="width: 50%; float: left;">
                                                                        <div class="labelll">
                                                                            <%=label("l_phone")%> 2:
                                                                        </div>
                                                                        <div>
                                                                            <asp:TextBox ID="txtPhone2" CssClass="CSTextBox" ValidationGroup="GInfo" runat="server" Width="124px"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    <div class="labelll">
                                                                        Tỉnh thành:
                                                                    </div>
                                                                    <div>
                                                                        <asp:DropDownList ID="ddlcountry" runat="server" AutoPostBack="false" CssClass="ddltthanh" ClientIDMode="Static"></asp:DropDownList>

                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    <div class="labelll">
                                                                        Quyện huyện:
                                                                    </div>
                                                                    <div>
                                                                        <asp:DropDownList ID="ddlstate" runat="server" CssClass="ddltthanh" ClientIDMode="Static">
                                                                            <asp:ListItem Text="-- Chọn quận huyện --" Value="0" />
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hdnStateValue" runat="server" ClientIDMode="Static" />



                                                                    </div>
                                                                </div>

                                                                <script type="text/javascript">
        $(document).ready(function () {

                                                                             $('#ddlcountry').change(function () {
                                                                                 var countryId = $(this).val();

                                                                                 if (countryId !== "0") {
                                                                                     $.ajax({
                                                                                         type: "POST",
                                                                                         url: "/AjaxAPI.aspx/GetStatesByCountry",
                                                                                         data: JSON.stringify({ countryId: countryId }),
                                                                                         contentType: "application/json; charset=utf-8",
                                                                                         dataType: "json",
                                                                                         success: function (response) {
                                                                                             var states = response.d;
                                                                                             var ddlState = $('#ddlstate');
                                                                                             ddlState.empty();
                                                                                             ddlState.append('<option value="0">-- Chọn quận huyện --</option>');

                                                                                             $.each(states, function (index, item) {
                                                                                                 ddlState.append($('<option></option>').val(item.Value).html(item.Text));
                                                                                             });
                                                                                         },
                                                                                         error: function (xhr, status, error) {
                                                                                             console.error("Lỗi khi load quận huyện: ", error);
                                                                                         }
                                                                                     });
                                                                                 }
                                                                             });
                                                                         });
                                                                         $('#ddlstate').on('change', function () {
                                                                             $('#hdnStateValue').val($(this).val());
                                                                         });

                                                                </script>

                                                                <div>
                                                                    <div class="labelll">
                                                                        <%=label("l_address")%>:
                                                                    </div>
                                                                    <div>
                                                                        <asp:TextBox ID="txtAddress" CssClass="CSTextBox" ValidationGroup="GInfo" runat="server" Width="264px"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div>
                                                                    <div class="labelll">
                                                                        <%=label("l_email")%>:
                                                                    </div>
                                                                    <div>
                                                                        <asp:TextBox ID="txtEmail" CssClass="CSTextBox" ValidationGroup="GInfo" runat="server" Width="264px"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    <div class="labelll">
                                                                        <%=label("l_content")%>:
                                                                    </div>
                                                                    <div>
                                                                        <asp:TextBox ID="txtnoidung" ValidationGroup="GInfo" CssClass="CSTextBox" runat="server" Width="264px" Height="87px" TextMode="MultiLine"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-8 col-sm-12 col-xs-12 no-padding">
                                                <div class="bacoc">
                                                    <span class="order-header"><%=label("phthanhtoan")%> </span>
                                                    <div class="maunen">
                                                        <div class="cus-payment">
                                                            <p class="clearfix">
                                                                <label class="borderPayment">
                                                                    <asp:RadioButton ID="rdcuahang" AutoPostBack="true" runat="server" Text="Chuẩn bị hàng để khách qua lấy và thanh toán tại cửa hàng" GroupName="payments" Checked="true"></asp:RadioButton>
                                                                </label>
                                                                <label class="borderPayment">
                                                                    <asp:RadioButton ID="rdATM" runat="server" GroupName="payments" Text="Ship hàng cho khách (áp dụng với khách tại Hà Nội)" />
                                                                </label>
                                                                <label class="borderPayment">
                                                                    <asp:RadioButton ID="rdCOD" runat="server" GroupName="payments" Text="Chuyển khoản trước - Gửi hàng qua chuyển phát (ViettelPost)" />
                                                                </label>
                                                                
                                                                <label class="borderPayment">
                                                                    <asp:RadioButton ID="rdCOD2" runat="server" GroupName="payments" Text="Ship COD - Nhận hàng và thanh toán cho nhân viên giao hàng" />
                                                                </label>

                                                                <div style="background: #eee; border: 1px solid #ccc; padding: 5px 10px; display: none">
                                                                    <i class="clgray s11"><span class="marker"><span style="margin: 0px; padding: 0px; word-wrap: break-word;"><strong style="margin: 0px; padding: 0px; word-wrap: break-word;"><%=label("tt5")%>:</strong> </span></span>
                                                                        <asp:Literal ID="txtgiohang" runat="server"></asp:Literal>
                                                                </div>
                                                        </div>
                                                    </div>

                                                    <div style=" clear:both ; height:20px;"></div>

                                                    <div class="note-box">
    <strong>Lưu ý:</strong><br />
    <span class="note-text">
        Quý khách vui lòng nhập đúng và đầy đủ thông tin để shop gọi lại xác nhận đơn hàng trước khi gửi hàng
    </span>
</div>



                                                    <style>
                                                        .note-box {
    border: 1px solid #ccc;
    padding: 20px;
    width: fit-content;
    background-color: #fff;
    font-family: Arial, sans-serif;
   font-size: 17px;
    width: 98%;
}

.note-text {
    color: blue;
    font-weight: bold;
}

                                                    </style>

                                                    <div class='frm_cart' style="margin-top: 0 !important; display:none">
                                                        <div class="borderBlock_ListPro">
                                                            <table cellpadding="0" class="table" cellspacing="0" class="dcart" width="100%">
                                                                <tr height="22">
                                                                <tr height="22">
                                                                    <td align="right">
                                                                        <div style="font-weight: bold; padding-right: 10px; padding-top: 5px; font-size: 15px; text-align: center;"><%=label("phaithanhtoan") %>:</div>
                                                                        <asp:Literal ID="lttthanhtoan" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <span style="color: Red; font-weight: bold; text-align: center; padding-left: 10px; font-size: 15px;">
                                                                            <asp:Literal ID="ltthanhtoan" runat="server"></asp:Literal></span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>




                                                    <%--		<div class="row">
<div class="col-md-6 col-sm-6 col-xs-6 no-padding">
   <div class="thanhtoan1">
        <span style=" color:red; font-size:15px;"><%=label("phaithanhtoan") %>:</span>
    <br /><span style="font-style:initial; font-size:12px;">(<%=label("phaithanhtoan1")%>)</span>
   </div>
</div>
<div class="col-md-6 col-sm-6 col-xs-6 no-padding">
     <span class="thanhtoanp"><asp:Literal id="ltthanhtoan" runat="server"></asp:Literal></span> 
</div>
</div>--%>
                                                </div>
                                            </div>
                                            <div style="white-space: 100%">
                                                <div style="width: 100%; float: left">
                                                    <asp:Button ID="btnSendOrder" ValidationGroup="GInfo" CssClass="btnaddd" runat="server" Text="Đặt hàng" OnClick="btnSendOrder_Click" />
                                                    <asp:Button ID="_btctnew" CssClass="btnadds" runat="server" Text="Mua thêm" OnClick="_btctnew_Click" />
                                                    <asp:Button ID="btnCancelOrder" CssClass="btnadd" runat="server" Text="Hủy đặt hàng" OnClick="btnCancelOrder_Click" />
                                                    <asp:LinkButton ID="lnkprint" runat="server" OnClick="lnkprint_Click"><img src="/Resources/images/prin.png" style=" width:70px" /></asp:LinkButton>
                                                    <asp:Button ID="btnEditCart" Visible="false" CssClass="btnadd" runat="server" Text="Sửa lại giỏ hàng" OnClick="btnEditCart_Click" />
                                                </div>
                                            </div>
                                </asp:Panel>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </section>
        <asp:HiddenField ID="ATMNhanh" Value="0" runat="server" />
        <asp:HiddenField ID="ATMCham" Value="0" runat="server" />
        <asp:HiddenField ID="CodeNhanh" Value="0" runat="server" />
        <asp:HiddenField ID="CodeCham" Value="0" runat="server" />



        <asp:HiddenField ID="hdtinhthanh" Value="0" runat="server" />
        <asp:HiddenField ID="hdTong" Value="0" runat="server" />

        <asp:HiddenField ID="hdtongGram" Value="0" runat="server" />
        <asp:HiddenField ID="hfiduser" Value="0" runat="server" />
        <asp:HiddenField ID="hdtongtien" Value="0" runat="server" />



        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
<div id="loadingAjax">
<div class="inner"><img src="/Resources/ShopCart/images/ajax-loader_2.gif"><p><%=label("dangxuly") %>...</p></div>
</div>
</ProgressTemplate>
</asp:UpdateProgress>--%>
  <%--  </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="lnkprint" />
        <asp:PostBackTrigger ControlID="btnSendOrder" />
    </Triggers>
</asp:UpdatePanel>--%>

