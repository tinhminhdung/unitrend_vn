<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Products.Control" %>
<table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                    <a class='linkmainmenu' style="<%=returnCSS("pro")%>" href='?u=pro&su=pro'>Phân loại sản phẩm</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("thuoctinhsosanh")%>" href='?u=pro&su=thuoctinhsosanh'>Thuộc tính so sánh</a>&nbsp;|
         <%--     <a class='linkmainmenu' style="<%=returnCSS("ManagementPrice") %>" href='?u=pro&su=ManagementPrice'>Bảng giá Trọng lượng</a>&nbsp;|--%>
                    <a class='linkmainmenu' style="<%=returnCSS("Manufacturer")%>" href='?u=pro&su=Manufacturer'>Thương hiệu</a>&nbsp;|
        <a class='linkmainmenu' style="<%=returnCSS("ThoiGianBaoHanh")%>" href='?u=pro&su=ThoiGianBaoHanh'>Thời gian bảo hành</a>&nbsp;|
              <%--<a class='linkmainmenu' style="<%=returnCSS("Size")%>" href='?u=pro&su=Size'>Kích thước</a>&nbsp;|
            <a class='linkmainmenu' style="<%=returnCSS("Color")%>" href='?u=pro&su=Color'>Mầu sắc</a>&nbsp;|--%>
                    <a class='linkmainmenu' style="<%=returnCSS("items") %>" href='?u=pro&su=items'>Danh sách sản phẩm</a>&nbsp;|
         <%--   <a class='linkmainmenu' style="<%=returnCSS("carts") %>" href='?u=pro&su=carts'>Quản lý đơn đặt hàng</a>&nbsp;|--%>
                    <a class='linkmainmenu' style="<%=returnCSS("set") %>" href='?u=pro&su=set'>Cấu hình</a>&nbsp;|
        <%--    <a class='linkmainmenu' style="<%=returnCSS("Posts") %>" href='?u=pro&su=Posts'>Hướng dẫn bài viết</a>&nbsp;|--%>
                </div>
            </b>
        </td>
    </tr>
    <tr>
        <td height="1"></td>
    </tr>
    <tr>
        <td>
            <asp:PlaceHolder ID="phcontrol" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</table>
