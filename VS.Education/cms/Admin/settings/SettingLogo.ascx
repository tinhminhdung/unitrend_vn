<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingLogo.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.settings.SettingLogo" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class='frm-add'>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 215px">
                    </td>
                    <td>
                    </td>
                    <td>
                        <strong><font color="#006633">
                            <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />Cài đặt khi không
                            có ảnh</strong>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px; width: 215px;">
                        Ảnh logo (No Img)
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Literal ID="ltcurrentpic" runat="server"></asp:Literal><br />
                        <asp:FileUpload ID="flimg" CssClass="txt_css" runat="server" Width="243px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkbannerdelete" CssClass="txt_css" runat="server" OnClick="lnkbannerdelete_Click">Delete</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px; width: 215px;">
                        <%=label("lt_size") %>
                    </td>
                    <td>
                    </td>
                    <td style="padding-left: 15px;">
                        <%=label("l_width")%><asp:TextBox CssClass="txt" ID="txtbannerwidth" runat="server"
                            Width="45px">1</asp:TextBox>px&nbsp;&nbsp;
                        <%=label("l_height")%><asp:TextBox CssClass="txt" ID="txtbannerheight" runat="server"
                            Width="45px">1</asp:TextBox>px
                    </td>
                </tr>


                <tr>
                    <td style="width: 215px">
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
        <asp:HiddenField ID="hdimage" runat="server" />
         <asp:HiddenField ID="hdimage2" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnsetup" />
    </Triggers>
</asp:UpdatePanel>