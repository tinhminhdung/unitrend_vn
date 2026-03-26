<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_adm_systemsetting.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.settings.u_adm_systemsetting" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td style="height: 26px">
                    <strong><font color="#006633">
                        <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                    <strong>
                        <%=label("lt_configsystem")%></strong>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    <%=label("lt_pagetitle")%>
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtwebname" runat="server" TextMode="MultiLine"
                        Width="408px" Height="40px"></asp:TextBox>
                    <span style="font-size: 7pt; color: dimgray"><em>(<%=label("lt_pagetitle_intro")%>)</em></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    <%=label("lt_keywebsite")%>
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtsearchkeyword" runat="server" TextMode="MultiLine"
                        Width="408px" Height="40px"></asp:TextBox>
                    <span style="font-size: 7pt; color: dimgray"><em>(<%=label("lt_keywebsite_intro")%>)</em></span>
                </td>
            </tr>
            <tr style="height: 7px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    <%=label("lt_websitedesckeyword")%>
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtsitekeyworddescription" runat="server" TextMode="MultiLine"
                        Width="408px" Height="40px"></asp:TextBox>
                    <span style="font-size: 7pt; color: dimgray"><em>(<%=label("lt_keywebsite_intro")%>)</em></span>
                </td>
            </tr>
            <tr style="height: 7px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 7px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <strong style="text-transform: uppercase">
                        <img src="/Resources/admin/images/bullet-red.png" border="0" />
                        Email hệ thống</strong> <span style="font-size: 7pt; color: dimgray"><em>(Hệ thống sử
                            dụng smtp.gmail.com của google)</em></span>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="30">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    SMTP Server
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtsmtp" runat="server" Width="250px"></asp:TextBox>
                    <span style="font-size: 7pt; color: dimgray"><em>(Cài đặt SMTP server - Ex:smtp.gmail.com)</em></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    SmtpPort
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtsmtpport"  runat="server" Width="250px"></asp:TextBox>
                    <span style="font-size: 7pt; color: dimgray"><em>(Cài đặt SMTP Port - Ex:587)</em></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    Email
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtsysemail" runat="server" Width="250px"></asp:TextBox>
                    <span style="font-size: 7pt; color: dimgray"><em>(Tên đăng nhập email - Ex:abc@gmail.com)</em></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    Mật khẩu
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtsysemailpass" runat="server" Width="250px"
                        TextMode="Password"></asp:TextBox>
                    <asp:CheckBox ID="chkChangePass" runat="server" Text="Cập nhật mật khẩu" Font-Bold="True"
                        ForeColor="#FF0000" />
                    <span style="font-size: 7pt; color: dimgray"><em>(Mật khẩu email của bạn - Ex:123456)</em></span>
                </td>
            </tr>
         <tr>
          <tr style="height: 7px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <strong style="text-transform: uppercase">
                        <img src="/Resources/admin/images/bullet-red.png" border="0" />Cấu hình Facebook</strong> <span style="font-size: 7pt; color: dimgray"><em>(Phục vụ chia sẻ facebook)</em></span>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="30">
                </td>
            </tr>
         <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                fb:app_id
                </td>
                <td>
                <asp:TextBox CssClass="txt_css" ID="txtfbapp_id" runat="server" Width="200px" ></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
               Fanpage Facebook
                </td>
                <td>
                <asp:TextBox CssClass="txt_css" ID="txtfacebook" runat="server" Width="550px" ></asp:TextBox>
                </td>
            </tr>
         <tr>
          <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                Kích thước like box:
                </td>
                <td>
                    <%=label("l_width")%>
                <asp:TextBox CssClass="txt_css" ID="txtfbwidth" runat="server" Width="45px">1</asp:TextBox>px&nbsp;
                &nbsp;<%=label("l_height")%><asp:TextBox CssClass="txt_css" ID="txtfbheight"
                    runat="server" Width="45px">1</asp:TextBox>px 
                </td>
            </tr>
            <tr style="height: 7px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <strong style="text-transform: uppercase">
                        <img src="/Resources/admin/images/bullet-red.png" border="0" />Cấu hình Khác</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="30">
                </td>
            </tr>
             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
               Hotline
                </td>
                <td>
                <asp:TextBox CssClass="txt_css" ID="txthostline" runat="server" Width="200px" ></asp:TextBox>
                </td>
            </tr>
            
             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                  Livechat
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtLivechat" runat="server" Width="550px" 
                        Height="46px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                 Giờ làm việc
                </td>
                <td>
                <CKEditor:CKEditorControl ID="txtgiolamviec" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                </td>
            </tr>



              <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                 Seo , h1,h2,h3,h4
                </td>
                <td>
                <CKEditor:CKEditorControl ID="txtseo" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                </td>
            </tr>
             
              <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
             Lỗi 404
                </td>
                <td>
                <CKEditor:CKEditorControl ID="Editor1" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                </td>
                </td>
            </tr>
            
<%--            <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    Google+
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtGoogle" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    Facebook
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtFacebooks" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    Youtube
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtYoutube" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    Twitter
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="twitter" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    Pinterest
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="pinterest" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
--%>

             <tr>
                <td colspan="3">
                    <strong style="text-transform: uppercase">
                        <img src="/Resources/admin/images/bullet-red.png" border="0" />Hướng dẫn mua hàng - chi tiết sản phẩm</strong>
                </td>
            </tr>






             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    HƯỚNG DẪN MUA HÀNG
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txthdmuahang" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    HƯỚNG DẪN THANH TOÁN
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txthdthanhtoan" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                    PHƯƠNG THỨC VẬN CHUYỂN
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txthinhthucvanchuyen" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                Thông tin tài khoản ngân hàng
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txttttk" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnsetup" runat="server" Text="Update" Font-Bold="True" Font-Size="8pt"
                        OnClick="btnsetup_Click" Width="123px"></asp:Button>
                        <asp:Button ID="btsitemap" runat="server" Text="Sitemap" Font-Bold="True" Font-Size="8pt"
                    OnClick="btsitemap_Click" Width="123px"></asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
