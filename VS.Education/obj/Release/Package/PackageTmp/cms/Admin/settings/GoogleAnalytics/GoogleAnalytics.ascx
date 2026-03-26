<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleAnalytics.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.settings.GoogleAnalytics.GoogleAnalytics" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class='frm-add'>
        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td style="height: 16px">
                    <strong><font color="#006633"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" style=" text-transform:uppercase"><img src="/Resources/admin/images/bullet-red.png" border=0 /> <strong>Cài đặt hệ thống GoogleAnalytics</strong>
                </td>
            </tr>
             <tr>
                <td style=" padding-left:15px" colspan="3">
                - Yêu cầu bạn vào trang <a target="_blank" href="https://www.google.com/accounts/ServiceLogin?service=analytics&passive=true&nui=1&continue=https://www.google.com/analytics/settings/&followup=https://www.google.com/analytics/settings/"><span style=" font-size:12px; font-weight:bold">GoogleAnalytics</span></a> để đăng ký,sau khi đăng ký xong bạn coppy đoạn javascript vào ô TextBox ở dưới
                </td>
            </tr>
                   <tr>
                <td style="padding-left:15px" colspan="3">
               - Xem Ví dụ : <a target="_blank" href=cms/admin/GoogleAnalytics/GoogleAnalytics.htm><span style=" font-size:12px; font-weight:bold">Click vào đây</span></a>
                </td>
            </tr>
            
            <tr>
                <td>
                </td>
                <td style="padding-left:15px"> 
                   Đoạn javascript
                </td>
                <td>
                     <asp:TextBox CssClass="txt_css"  ID="txtwebname" runat="server"  TextMode="MultiLine" Width="700px" Height="250px"></asp:TextBox>
                     <br />
                    <span style="font-size: 7pt; color: dimgray"><em>(Lưu ý:chỉ được coppy đoạn javascript)</em></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button  CssClass="txt_css"  ID="btnsetup" runat="server" Text="Update" Font-Bold="True" Font-Size="8pt" OnClick="btnsetup_Click" Width="123px"></asp:Button>
                </td>
            </tr>
        </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>