<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Faq.Control" %>
       <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                    <a class='linkmainmenu' style="<%=returnCSS("items") %>" href='?u=faq&su=items'>Danh sách hỏi đáp</a>&nbsp;|
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
