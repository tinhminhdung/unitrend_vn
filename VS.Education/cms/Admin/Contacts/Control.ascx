<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Contacts.Control" %>
<table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                    <a class='linkmainmenu' style="<%=returnCSS("Contacts") %>" href='?u=Contacts&su=Contacts'>
                        Thông tin liên hệ</a>&nbsp;| 
                        <a class='linkmainmenu' style="<%=returnCSS("setting") %>"
                            href='?u=Contacts&su=setting'>Cấu hình</a>&nbsp;| <a class='linkmainmenu' style="<%=returnCSS("Posts") %>"
                                href='?u=Contacts&su=Posts'>Hướng dẫn bài viết</a>
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