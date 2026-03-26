<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Menus.Control" %>
<table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                   <a class='linkmainmenu' style="<%=returnCSS("Menuchinh") %>" href='?u=Menuchinh&su=Menuchinh'>Quản lý menu chính</a>&nbsp;|
                    <%--<a class='linkmainmenu' style="<%=returnCSS("topstaticmenu") %>" href='?u=Menuchinh&su=topstaticmenu'>Quản lý Thực đơn trên cùng</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("botstaticmenu") %>" href='?u=Menuchinh&su=botstaticmenu'>Quản lý Thực đơn dưới cùng</a>--%>
                </div>
            </b>
        </td>
    </tr>
    <tr>
        <td height="1">
        </td>
    </tr>
    <tr>
        <td>
            <asp:PlaceHolder ID="phcontrol" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</table>