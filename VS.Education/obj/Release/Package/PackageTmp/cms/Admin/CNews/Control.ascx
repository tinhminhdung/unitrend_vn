<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.M_News.Control" %>
       <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                    <%--<a class='linkmainmenu' style="<%=returnCSS("news") %>" href='?u=news&su=news'>Quản lý phân mục tin</a>&nbsp;|--%>
                    <a class='linkmainmenu' style="<%=returnCSS("items") %>" href='?u=news&su=items'>Danh sách tin tức</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("set") %>" href='?u=news&su=set'>Cấu hình</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("Posts") %>" href='?u=news&su=Posts'>Hướng dẫn bài viết</a>
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
