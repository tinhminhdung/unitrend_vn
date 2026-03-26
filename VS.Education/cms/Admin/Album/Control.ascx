<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Album.Control" %>
<table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                    <a class='linkmainmenu' style="<%=returnCSS("Album") %>" href='?u=Album&su=Album'>Danh  mục Thư viện ảnh</a>&nbsp;| <a class='linkmainmenu' style="<%=returnCSS("items") %>"  href='?u=Album&su=items'>Danh sách Thư viện ảnh</a>&nbsp;| <a class='linkmainmenu'   style="<%=returnCSS("set") %>" href='?u=Album&su=set'>Cấu hình</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("Posts") %>" href='?u=Album&su=Posts'>Hướng dẫn bài viết</a>&nbsp;|
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
