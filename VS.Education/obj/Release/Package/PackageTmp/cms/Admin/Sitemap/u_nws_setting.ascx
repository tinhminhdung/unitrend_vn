<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_nws_setting.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Sitemap.u_nws_setting" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>

<div class='frm-add'>
    <table  border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 300px"></td>
                    <td></td>
                    <td>
                        <strong><font color="#006633"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                    </td>
                </tr>
       <tr>
        <td colspan="3">
            <strong style=" text-transform:uppercase"><img src="/Resources/admin/images/bullet-red.png" border=0 />Cài đặt bản đồ Map Google</strong>
        </td>
    </tr>
    <tr>
                     <td style=" padding-left:15px;">
                       Tọa độ đầu tiên
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txttoado" CssClass=txt runat="server"   Width="230px"></asp:TextBox> <span style="font-size: 7pt; color: dimgray"><em>(Khi vào trang googlemap bạn muốn đầu tiên nhìn thấy thành phố nào trước thì bạn hãy điền tọa độ đó vào đây)</em></span>
                    </td>
                </tr>
                <tr>
                     <td style=" padding-left:15px;">
                       Zoom ( + / - )
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtzoom" CssClass=txt runat="server"  Width="70px"></asp:TextBox> <span style="font-size: 7pt; color: dimgray"><em>(Độ Zoom của Map Google)</em></span>
                    </td>
                </tr>
                <tr>
                    <td style=" padding-left:15px;">
                      Icon trong bản đồ
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Literal ID="ltcurrentpic" runat="server"></asp:Literal><br />
                        <asp:FileUpload ID="flimg"  CssClass="txt_css"  runat="server" Width="243px" />
                       <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" controltovalidate="flimg" errormessage="Không phải file ảnh" validationexpression="^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png| .PNG)$"> </asp:regularexpressionvalidator>
                     <br /> &nbsp;<span style="font-size: 7pt; color: dimgray"><em>(Kích thước tối đa của Icon(Rộng:30px - Cao:60px))</em></span>
                        <asp:LinkButton ID="lnkbannerdelete"  CssClass="txt_css"  runat="server" OnClick="lnkbannerdelete_Click">Delete</asp:LinkButton>
                    </td>
                </tr>
                
                 
                <tr>
                    <td>
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
</asp:UpdatePanel>