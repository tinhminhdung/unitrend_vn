<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Download.Control" %>
<table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                      <a class='linkmainmenu' style="<%=returnCSS("nhomtaiieu") %>" href='?u=Download&su=nhomtaiieu'>Phân loại tài liệu</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("Download") %>" href='?u=Download&su=Download'>Danh sách tài liệu</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("set") %>"
                        href='?u=Download&su=set'>Cấu hình</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("Posts") %>"
                            href='?u=Download&su=Posts'>Hướng dẫn bài viết</a>
                </div>
            </b>
        </td>
    </tr>
    <tr>
        <td height="1"></td>
    </tr>
    <tr>
        <td>
            <asp:placeholder id="phcontrol" runat="server"></asp:placeholder>
        </td>
    </tr>
</table>
