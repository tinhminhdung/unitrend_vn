<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Sitemap.Control" %>
<table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                    <a class='linkmainmenu'  style="<%=returnCSS("Sitemap") %>" href='?u=Sitemap&su=Sitemap'>Danh sách sơ đồ web site</a>&nbsp;|
                    <a class='linkmainmenu'  style="<%=returnCSS("items") %>" href='?u=Sitemap&su=items'>Danh sách sơ đồ googlemap</a>&nbsp;|
                    <a class='linkmainmenu'  style="<%=returnCSS("set") %>" href='?u=Sitemap&su=set'>Cấu hình</a>&nbsp;|
                    <a class='linkmainmenu'  style="<%=returnCSS("Posts") %>" href='?u=Sitemap&su=Posts'>Hướng dẫn bài viết</a>&nbsp;|
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
