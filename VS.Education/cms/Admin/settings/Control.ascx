<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.settings.Control" %>
<TABLE style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%" border="0">
	<TR height="25" align=left>
		<TD>
			<b>
            <div class="Sub_menu_top_right">
                <a class='linkmainmenu' style="<%=returnCSS("set") %>" href='?u=set&su=set'>Cài đặt hệ thống</a>&nbsp;|
                  <a class='linkmainmenu' style="<%=returnCSS("CuocPhiVanChuyen") %>" href='?u=set&su=CuocPhiVanChuyen'>Cước phí vận chuyển</a>&nbsp;|
                 <a class='linkmainmenu' style="<%=returnCSS("Noimg") %>" href='?u=set&su=Noimg'>Logo Noimg</a>&nbsp;|
                <%-- <a class='linkmainmenu' style="<%=returnCSS("Vote") %>"  href='?u=set&su=Vote'>Vote</a>&nbsp;|--%>
                <a class='linkmainmenu' style="<%=returnCSS("pr") %>"  href='?u=set&su=pr'>Cài đặt thuộc tính</a>&nbsp;|
                <a class='linkmainmenu' style="<%=returnCSS("OnOff") %>"  href='?u=set&su=OnOff'>Tắt mở trang web</a>&nbsp;|
                <a class='linkmainmenu' style="<%=returnCSS("PopUp") %>" href='?u=set&su=PopUp'>Quảng cáo PopUp</a>&nbsp;|
                <a class='linkmainmenu' style="<%=returnCSS("Screen") %>"  href='?u=set&su=Screen'>Quảng cáo 2 bên lề</a>&nbsp;|
                <a class='linkmainmenu' style="<%=returnCSS("GoogleAnalytics") %>" href='?u=set&su=GoogleAnalytics'>GoogleAnalytics</a>&nbsp;|
                <a class='linkmainmenu' style="<%=returnCSS("AdminUser") %>" href='?u=set&su=AdminUser'>Tài khoản hệ thống</a>&nbsp;|
                <a class='linkmainmenu' style="<%=returnCSS("languages") %>" href='?u=set&su=languages'>Ngôn ngữ</a>&nbsp;|
                <%-- <a class='linkmainmenu' style="<%=returnCSS("login") %>" href='?u=set&su=login'>History Login</a>&nbsp;|--%>
                <a class='linkmainmenu' style="<%=returnCSS("Guide_Posts") %>" href='?u=set&su=Guide_Posts'>Hướng dẫn</a>
                
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