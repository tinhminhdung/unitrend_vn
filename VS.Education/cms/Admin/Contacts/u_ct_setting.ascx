<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_ct_setting.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Contacts.u_ct_setting" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<asp:updatepanel ID="UpdatePanel1" runat="server">
    <contenttemplate>
<div class='frm-add'>
    <table  border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 215px"></td>
                    <td></td>
                    <td>
                        <strong><font color="#006633"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                    </td>
                </tr>
         <tr style=" display:none">
        <td colspan="3">
            <strong style=" text-transform:uppercase"><img src="/Resources/admin/images/bullet-red.png" border=0 />Cài đặt bản đồ</strong>
        </td>
    </tr>
    <tr>
        <td style=" padding-left:15px; width: 215px;">
           Bản đồ
        </td>
        <td>
        </td>
        <td>

        <CKEditor:CKEditorControl ID="txtbando" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
       
        </td>
    </tr>
                <tr>
                    <td style="width: 215px"><strong style="text-transform:uppercase"><img src="/Resources/admin/images/bullet-red.png" border=0 /> Kích hoạt hệ thống Email </strong></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                     <td style=" padding-left:15px; width: 215px;">
                       Tự động gửi mail khi có liên hệ 
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdcommentoptioncheckcomments" runat="server" Checked="true"  GroupName="co" Text="kích hoạt hệ thống Email" />
                        <asp:RadioButton ID="rdcommentoptionnotcheckcomments" runat="server" GroupName="co" Text="Không kích hoạt hệ thống Email" /><br />
                        <span style="font-size: 7pt; color: dimgray"><em>(Tự động gửi mail khi có liên hệ ở ngoài trang hiển thị)</em></span>
                    </td>
                </tr>
                 <tr>
                     <td style=" padding-left:15px; width: 215px;">
                        Gửi liên hệ đến Email
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtEmail" CssClass=txt runat="server"  Width="230px"></asp:TextBox>
                    </td>
                </tr>
                 <%--<tr>
                     <td style=" padding-left:15px; width: 215px;">
                        Tự động gửi xác nhận Email
                    </td>
                    <td></td>
                    <td>--%>
                    <CKEditor:CKEditorControl Visible=false ID="txtxacnhanemail" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                    <%--</td>
                </tr>--%>
                <tr>
                    <td style="width: 215px">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnsetup" runat="server" OnClick="btnsetup_Click" Text="Cập nhật" Width="150px" />
                    </td>
                </tr>
            </table>
</div>
<asp:HiddenField ID="hdimage" runat="server" />
</contenttemplate>
 <Triggers>
<asp:PostBackTrigger ControlID="btnsetup" />
</Triggers>
</asp:updatepanel>