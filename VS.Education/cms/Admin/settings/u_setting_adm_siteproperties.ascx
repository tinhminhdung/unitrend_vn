<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_setting_adm_siteproperties.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.settings.u_setting_adm_siteproperties" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<div class='frm-add'>
    <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
            </td>
            <td style="width: 143px">
            </td>
            <td style="height: 16px">
                <strong><font color="#006633">
                    <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <strong style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                    <%=label("lt_startmodule")%></strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="padding-left: 15px; width: 143px;">
                Logo
            </td>
            <td>
                <asp:Literal ID="ltcurrentpic" runat="server"></asp:Literal><br />
                <asp:FileUpload ID="flimg" CssClass="txt_css" runat="server" Width="243px" />
                &nbsp;
                <asp:LinkButton ID="lnkbannerdelete" CssClass="txt_css" runat="server" OnClick="lnkbannerdelete_Click"><span style=" font-size:12px">Delete</span></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="padding-left: 15px; width: 143px;">
                <%=label("lt_size") %>
            </td>
            <td align="left">
                <%=label("l_width")%>
                <asp:TextBox CssClass="txt_css" ID="txtbannerwidth" runat="server" Width="45px">1</asp:TextBox>px&nbsp;
                &nbsp;<%=label("l_height")%><asp:TextBox CssClass="txt_css" ID="txtbannerheight"
                    runat="server" Width="45px">1</asp:TextBox>px <span style="font-size: 7pt; color: dimgray">
                        <em>(<%=label("l_0pxshowtruesizeimage")%>
                            - Thông tin chiều cao, rộng của logo)</em></span>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <strong style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                    Cấu hình favicon (Icon)</strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="padding-left: 15px; width: 143px;">
                <span style="font-size: 10px; font-style: italic">(Sẽ hiển thị ở trên thanh toolbar
                    của trang)</span>
            </td>
            <td>
                <strong><font color="#e2131b">
                    <asp:Literal ID="lticon" runat="server"></asp:Literal></font></strong>
                <br />
                <asp:FileUpload CssClass="txt_css" ID="flimgicon" runat="server" />
                <span style="font-size: 10px; font-style: italic">(Chỉ hỗ trợ định dạng .ico , Default:
                    16px 16px OR 32px 32px)</span> &nbsp;&nbsp;
                <asp:LinkButton CssClass="txt_css" ID="lnkDeleteicon" runat="server" OnClick="lnkDeleteicon_Click"><span style=" font-size:12px">Delete</span></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 143px">
                <%=label("l_content")%>
                <%=label("lt_cartbox")%>
                <br />
                <span style="font-size: 10px; font-style: italic">(Hiển thị nội dung trong phần đặt
                    hàng)</span>
            </td>
            <td>
                  <CKEditor:CKEditorControl ID="txtgiohang" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 143px">
                <%=label("lt_contentfooter")%><br />
                <span style="font-size: 10px; font-style: italic">(Hiển thị nội dung dưới chân trang
                    web)</span>
            </td>
            <td>
               <CKEditor:CKEditorControl ID="txtfootercontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
            </td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 143px">
                <%=label("lt_contentcontact")%><br />
                <span style="font-size: 10px; font-style: italic">(Hiển thị nội dung ở phần liên hệ)</span>
            </td>
            <td>
                  <CKEditor:CKEditorControl ID="txtcontactcontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 143px">
            </td>
            <td>
                <asp:Button ID="btnsetup" runat="server" Text="Update" Font-Bold="True" Font-Size="8pt"
                    OnClick="btnsetup_Click" Width="123px"></asp:Button>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdimage" runat="server" />
    <asp:HiddenField ID="hdbgimg" runat="server" />
    <asp:HiddenField ID="hdicon" runat="server" />
</div>