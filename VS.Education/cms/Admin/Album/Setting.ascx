<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Album.Setting" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class='frm-add'>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="400px">
                    </td>
                    <td>
                    </td>
                    <td>
                        <strong><font color="#006633">
                            <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                    </td>
                </tr>
                <tr height="40px" valign="bottom">
                    <td>
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            <%=label("l_displayinindnex")%>
                        </strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        <%=label("l_iteminpage")%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpagenews" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                        &nbsp;&nbsp; <span style="font-size: 7pt; color: dimgray"><em>(là chỉ số để phân trang
                            cho danh sản phẩm - Ex:Trang: 1 2 3 4 5 tiếp theo)</em></span>
                    </td>
                </tr>
                <tr height="40px" valign="bottom">
                    <td>
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            Cấu hình kích thước hình ảnh </strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Rộng
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtwidth" runat="server" CssClass="txt" Width="50px">130</asp:TextBox>
                        px &nbsp;&nbsp; <span style="font-size: 7pt; color: dimgray"><em>((<%=label("l_0pxshowtruesizeimage")%>)
                            - chiều rộng của hình ảnh trong danh sản phẩm)</em></span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Cao
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtheight" runat="server" CssClass="txt" Width="50px">100</asp:TextBox>
                        px &nbsp;&nbsp; <span style="font-size: 7pt; color: dimgray"><em>((<%=label("l_0pxshowtruesizeimage")%>)
                            - chiều cao của hình ảnh trong danh sách sản phẩm)</em></span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnsetup" runat="server" OnClick="btnsetup_Click" Text="Cập nhật"
                            Width="150px" />
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
