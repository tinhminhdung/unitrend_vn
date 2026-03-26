<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Tienich.Control" %>
<TABLE style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%" border="0">
<TR height="25" align=left>
	<TD>
        <b>
         <div class="Sub_menu_top_right">
         <a class='linkmainmenu'  style="<%=returnCSS("Tienich") %>"  href='?u=Tienich&su=Tienich'>Hỗ trợ trực tuyến</a>&nbsp;|
         <a class='linkmainmenu'  style="<%=returnCSS("contentpages") %>"  href='?u=Tienich&su=contentpages'>Quản lý Trang hiển thị độc lập</a>&nbsp;|
         <a class='linkmainmenu'  style="<%=returnCSS("Posts") %>"  href='?u=Tienich&su=Posts'>Hướng dẫn bài viết</a>
         </div>
         </b>
	</TD>
</TR>
<TR>
	<TD height="1"></TD>
</TR>
<TR>
	<TD>
        <asp:PlaceHolder ID="phcontrol" runat="server"></asp:PlaceHolder>
    </TD>
</TR>
</TABLE>