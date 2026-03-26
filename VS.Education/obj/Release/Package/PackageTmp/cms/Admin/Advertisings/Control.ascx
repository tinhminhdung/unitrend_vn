<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Advertisings.Control" %>
<TABLE style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%" border="0">
<TR height="25" align=left>
	<TD>
        <b>
         <div class="Sub_menu_top_right">
             <a class='linkmainmenu'  style="<%=returnCSS("Advertisings") %>" href='?u=Advertisings&su=Advertisings'>Danh sách quảng cáo</a>&nbsp;|
             <a class='linkmainmenu'  style="<%=returnCSS("DMAdvertising") %>" href='?u=Advertisings&su=DMAdvertising'>Quảng cáo theo nhóm </a>&nbsp;|
             <a class='linkmainmenu'  style="<%=returnCSS("Posts") %>" href='?u=Advertisings&su=Posts'>Hướng dẫn bài viết</a>&nbsp;|
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