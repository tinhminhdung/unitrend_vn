<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YahooMessenger.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Tienich.YahooMessenger" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<asp:panel id="pn_list" runat="server">  
<div style="margin-top:10px;" align=left  class="frm_search">
<asp:Button ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="60px" />
</div>
<div  class="list_item">
<asp:repeater id="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
	<ItemTemplate>
	<tr style="background-color:#f1f1f1"  height="40">
           <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("inick") %>' runat="server" /></td>
           <td>
               <%#DataBinder.Eval(Container.DataItem,"Title")%>
           </td>
           <td align="center">
               <%#DataBinder.Eval(Container.DataItem,"Nick")%>
           </td>
               <td align="center">
               <%#DataBinder.Eval(Container.DataItem,"Phone")%>
           </td>
           <td align="center">
               <%#DataBinder.Eval(Container.DataItem, "Orders")%>
           </td>
           <td align="center">
               <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("inick")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
           </td>
         <td align="center">
             <asp:LinkButton ID="LinkButton1" CommandName="EditDetail"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"inick")%>' Runat="server"><%=label("lt_edit")%></asp:LinkButton>
            </td>
           <td align="center">
                <div class="del"><asp:LinkButton CommandName="Delete"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"inick")%>' Runat="server" ID="Linkbutton3" OnLoad="Delete_Load"><%=label("ldelete")%></asp:LinkButton></div>
           </td>
     </tr>
	</ItemTemplate>
	<AlternatingItemTemplate>
	<tr style="background-color: #ffff" height="40">
		<td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("inick") %>' runat="server" /></td>
           <td>
               <%#DataBinder.Eval(Container.DataItem,"Title")%>
           </td>
              <td align="center">
               <%#DataBinder.Eval(Container.DataItem,"Nick")%>
           </td>
           <td align="center">
               <%#DataBinder.Eval(Container.DataItem,"Phone")%>
           </td>
           <td align="center">
               <%#DataBinder.Eval(Container.DataItem,"Orders")%>
           </td>
           <td align="center">
               <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("inick")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
           </td>
         <td align="center">
             <asp:LinkButton ID="LinkButton1" CommandName="EditDetail"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"inick")%>' Runat="server"><%=label("lt_edit")%></asp:LinkButton>
            </td>
           <td align="center">
                <div class="del"><asp:LinkButton CommandName="Delete"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"inick")%>' Runat="server" ID="Linkbutton3" OnLoad="Delete_Load"><%=label("ldelete")%></asp:LinkButton></div>
           </td>
     </tr>
	</AlternatingItemTemplate>
	<HeaderTemplate>
		<table  border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
			 <tr bgcolor="#C4C4C4" height="22">
			    <td class="header"><input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" Type="checkbox" /></td>
				<td class="header"><%=label("answers_title")%></td>
				<td class="header">Nick</td>
				<td class="header">Phone</td>
				<td class="header"><%=label("lt_order")%></td>
				<td class="header"><%=label("l_status")%></td>
				<td class="header"><%=label("lt_edit")%></td>
				<td class="header"><%=label("ldelete")%></td>
			</tr>
	</HeaderTemplate>
<FooterTemplate>
</table>				
</FooterTemplate>
</asp:Repeater>
</div>

<table style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%" border="0">
<tr height="20">
		<td></td>
	</tr>
	<tr height="25" bgcolor="whitesmoke">
		<td><asp:LinkButton ID="LinkButton5"  OnClick="LinkButton4_Click" Runat="server">[<%=label("l_createnew")%>]</asp:LinkButton></td>
	</tr>
</TABLE>
</asp:panel>
                
<asp:panel id="pn_insert" runat="server" Visible="False">
<div class='frm-add'>
<TABLE style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%" border="0">
		<TR>
			<TD  width=200></TD>
			<TD></TD>
			<TD>
				<asp:Label id="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></TD>
		</TR>
         <asp:DropDownList ID="ddltype"  Visible=false runat="server" Width="184px" >
                    <asp:ListItem Value="1">Yahoo Messenger</asp:ListItem>
                    <asp:ListItem Value="2">Skype</asp:ListItem>
                </asp:DropDownList>
<%--		<TR>
			<TD><%=label("l_NickchatType")%></TD>
			<TD></TD>
			<TD>
               </TD>
		</TR>--%>
		<TR>
			<TD>
                <%=label("l_title")%>
                </TD>
			<TD></TD>
			<TD>
                <asp:TextBox ID="txttitle" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD> Tên Nick</TD>
			<TD></TD>
			<TD>
				<asp:TextBox id="txtname" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></TD>
		</TR>
        <TR>
			<TD>Tên Skype</TD>
			<TD></TD>
			<TD>
				<asp:TextBox id="txtSkype" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></TD>
		</TR>
        <TR>
			<TD>Zalo</TD>
			<TD></TD>
			<TD>
				<asp:TextBox id="txtEmail" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></TD>
		</TR>
        <tr>
            <td>
                <%=label("l_Phone")%> </td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtphone" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></td>
        </tr>
         <asp:DropDownList ID="ddlsize" Visible=false runat="server" Width="41px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
        <%--<tr>
            <td>
                
                    <%=label("lt_size")%>
                    </td>
            <td>
            </td>
            <td>
               
                <br /><br /><div  class="adaidien"><asp:Literal ID="ltimg" runat="server"></asp:Literal></div></td>
        </tr>--%>
		<TR>
			<TD><%=label("lt_order")%></TD>
			<TD></TD>
			<TD>
				<asp:TextBox id="txt_order" CssClass="txt_css" runat="server" Width="40px">1</asp:TextBox></TD>
		</TR>
		<TR>
			<TD><%=label("lt_display")%></TD>
			<TD></TD>
			<TD>
				<asp:CheckBox id="chck_Enable" runat="server" Visible="True"></asp:CheckBox></TD>
		</TR>
		<TR>
			<TD></TD>
			<TD></TD>
			<TD>
				<asp:Button id="btn_InsertUpdate" runat="server" Text="Insert/Update" Width="120px" onclick="btn_InsertUpdate_Click"></asp:Button>
				<asp:Button id="btnCancel" runat="server" Text="Cancel" Width="56px" onclick="btnCancel_Click"></asp:Button></TD>
		</TR>
		<TR>
	</TABLE>
 </div>
</asp:panel>                                  

<INPUT id="hd_insertupdate" style="WIDTH: 24px; HEIGHT: 22px" Type="hidden" size="1" name="Hidden1" runat="server">
<INPUT id="hd_id" style="WIDTH: 24px; HEIGHT: 22px" Type="hidden" size="1" name="Hidden2" runat="server">
<INPUT id="hd_par_id" style="WIDTH: 24px; HEIGHT: 22px" Type="hidden" size="1" name="Hidden2" runat="server">
<INPUT id="hd_page_edit_id" style="WIDTH: 24px; HEIGHT: 22px" Type="hidden" size="1" name="Hidden2" runat="server">
<INPUT id="hd_imgpath" style="WIDTH: 24px; HEIGHT: 22px" Type="hidden" size="1" name="Hidden2" runat="server">
<INPUT id="hd_rootpic" style="WIDTH: 24px; HEIGHT: 22px" Type="hidden" size="1" runat="server">
</ContentTemplate>
</asp:UpdatePanel>

