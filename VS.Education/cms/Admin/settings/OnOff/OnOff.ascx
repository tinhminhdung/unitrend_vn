<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnOff.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.settings.OnOff.OnOff" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    </ContentTemplate>
</asp:UpdatePanel>
<div class='frm-add'>
    <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="width: 78px">
            </td>
            <td>
            </td>
            <td style="height: 16px">
                <strong><font color="#006633">
                    <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-transform: uppercase">
                <img src="/Resources/admin/images/bullet-red.png" border="0" />
                <strong>Tắt mở trang web ở ngoài</strong>
            </td>
        </tr>
        <tr>
            <td style="width: 78px">
                Nội Dung
            </td>
            <td style="padding-left: 15px">
            </td>
            <td>
<CKEditor:CKEditorControl ID="txtOnOff" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                <span style="font-size: 7pt; color: dimgray"><em>(Khi mở web ra sẽ xuất hiện dòng thông
                    báo này ở ngoài trang web)</em></span>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px; width: 78px;">
                Trạng thái
            </td>
            <td>
            </td>
            <td>
                <asp:RadioButton ID="rdcommentoptioncheckcomments" runat="server" Checked="true"
                    GroupName="co" Text="Trạng thái mở" />
                <asp:RadioButton ID="rdcommentoptionnotcheckcomments" runat="server" GroupName="co"
                    Text="Trạng thái tắt" /><br />
            </td>
        </tr>
        <tr>
            <td style="width: 78px">
            </td>
            <td>
            </td>
            <td>
                <asp:Button CssClass="txt_css" ID="btnsetup" runat="server" Text="Update" Font-Bold="True"
                    Font-Size="8pt" OnClick="btnsetup_Click" Width="123px"></asp:Button>
            </td>
        </tr>
    </table>
</div>