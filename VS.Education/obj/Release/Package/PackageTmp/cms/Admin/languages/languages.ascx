<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="languages.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.languages.languages" %>
<asp:Literal ID="lt_info" Visible=false runat="server"></asp:Literal>
<asp:HiddenField ID="hdlangid" runat="server" />
<asp:HiddenField ID="hdvalue" runat="server" />
<asp:Panel ID="pn_list" runat="server">
<div  class="list_item">
<asp:Repeater ID="rp_lans" runat="server" OnItemCommand="rp_lans_ItemCommand">
<HeaderTemplate>
		<table  border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
			 <tr bgcolor="#C4C4C4" height="22">
				<td class="header"><%=label("lt_key")%></td>
				<td class="header"><%=label("lt_name")%></td>
				<td class="header"><%=label("lt_displaytitle")%></td>
				<td class="header"><%=label("lt_order")%></td>
				<td class="header">Ngôn ngữ mặc định</td>
				<td class="header"><%=label("l_status")%></td>
				<td class="header"><%=label("lt_edit")%></td>
				<td class="header">Danh sách</td>
				<td class="header"><%=label("ldelete")%></td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
	<tr style="background-color:#ececec"  height="40">
           <td>
               <%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>
           </td>
           <td align="center">
              <%#DataBinder.Eval(Container.DataItem,"VLAN_NAME_VIE")%>
           </td>
           <td align="center">
              <%#DataBinder.Eval(Container.DataItem,"VLAN_NAME")%>
           </td>
           <td align="center">
              <%#DataBinder.Eval(Container.DataItem,"ILAN_ORDER")%>
           </td>
            <td align="center">
             <%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem,"MacDinh").ToString())%>
            </td>
         <td align="center">
             <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("VLAN_ID")+"|"+Eval("ILAN_LOCKED")%>' runat="server" ID="Linkbutton5" NAME="Linkbutton1"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "ILAN_LOCKED").ToString())%></asp:LinkButton>
            </td>
             <td align="center">
                <asp:LinkButton CommandName="Update" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>' runat="server" ID="Linkbutton1" NAME="Linkbutton1" ToolTip="Add/Edit Content">[<%=label("lt_edit")%>]</asp:LinkButton>
            </td>
            <td align="center">
            <asp:LinkButton CommandName="ValuesList" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>' runat="server" ID="Linkbutton6" NAME="Linkbutton1" ToolTip="Danh sách giá trị">[Danh sách giá trị]</asp:LinkButton>
                </td>
           <td align="center">
                <div class="del"> <asp:LinkButton OnLoad="Delete_Load" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>'  runat="server" ID="Linkbutton2" >[<%=label("ldelete")%>]</asp:LinkButton></div>
           </td>
     </tr>
	</ItemTemplate>
	<AlternatingItemTemplate>
	<tr   height="40">
           <td>
               <%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>
           </td>
           <td align="center">
              <%#DataBinder.Eval(Container.DataItem,"VLAN_NAME_VIE")%>
           </td>
           <td align="center">
              <%#DataBinder.Eval(Container.DataItem,"VLAN_NAME")%>
           </td>
           <td align="center">
              <%#DataBinder.Eval(Container.DataItem,"ILAN_ORDER")%>
           </td>
              <td align="center">
             <%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem,"MacDinh").ToString())%>
            </td>
         <td align="center">
             <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("VLAN_ID")+"|"+Eval("ILAN_LOCKED")%>' runat="server" ID="Linkbutton5" NAME="Linkbutton1"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "ILAN_LOCKED").ToString())%></asp:LinkButton>
            </td>
             <td align="center">
                <asp:LinkButton CommandName="Update" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>' runat="server" ID="Linkbutton1" NAME="Linkbutton1" ToolTip="Add/Edit Content">[<%=label("lt_edit")%>]</asp:LinkButton>
            </td>
            <td align="center">
            <asp:LinkButton CommandName="ValuesList" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>' runat="server" ID="Linkbutton6" NAME="Linkbutton1" ToolTip="Danh sách giá trị">[Danh sách giá trị]</asp:LinkButton>
                </td>
           <td align="center">
                <div class="del"> <asp:LinkButton OnLoad="Delete_Load" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>'  runat="server" ID="Linkbutton2" >[<%=label("ldelete")%>]</asp:LinkButton></div>
           </td>
     </tr>
	</AlternatingItemTemplate>
</asp:Repeater>
</div>
<table  style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%"	border="0">
    <tr height="20"><td></td></tr>
	<tr height="25" bgcolor="WhiteSmoke">
		<td>
		<asp:LinkButton ID="lnk_insertnewlanguage" runat="server" Font-Bold="True" OnClick="lnk_insertnewlanguage_Click">[<%=label("lt_admnewlanguage")%>]</asp:LinkButton>
		</td>
	</tr>
</table>
</asp:Panel>
<asp:Panel ID="pn_detail" runat="server" Visible="False">
<div class='frm-add'>
<input id="id" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden1" runat="server">
<input id="hd_insertnew" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden1" runat="server">
    <table  style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
<tr>
            <td>
                
            </td>
            <td>
                <strong>
                    <%=label("lt_key")%></strong>
            </td>
            <td>
                
                <asp:DropDownList ID="txt_shortname" runat="server">
                    <asp:ListItem Value="VIE">VIE</asp:ListItem>
                    <asp:ListItem Value="ENG">ENG</asp:ListItem>
                    <asp:ListItem Value="FRA">FRA</asp:ListItem>
                    <asp:ListItem Value="GER">GER</asp:ListItem>
                    <asp:ListItem Value="JAN">JAN</asp:ListItem>
                    <asp:ListItem Value="CHI">CHI</asp:ListItem>
                    <asp:ListItem Value="KOR">KOR</asp:ListItem>
                    <asp:ListItem Value="ESP">ESP</asp:ListItem>
                    <asp:ListItem Value="NED">NED</asp:ListItem>
                    <asp:ListItem Value="ARA">ARA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <strong>
                    <%=label("lt_name")%></strong>
            </td>
            <td>
                
                <asp:TextBox ID="txt_showinvie" runat="server" Width="249px"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <strong>
                    <%=label("lt_displaytitle")%></strong>
            </td>
            <td>
                
                <asp:TextBox ID="txt_name_inother" runat="server" Width="248px"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <strong>
                    <%=label("lt_order")%></strong>
            </td>
            <td>
                
                <asp:TextBox ID="txt_order" runat="server" Width="48px"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <strong>
                    <%=label("lt_enable")%></strong>
            </td>
            <td>
                
                <asp:CheckBox ID="chk_show" runat="server" Text="Trạng thái"></asp:CheckBox>   <asp:CheckBox ID="chk_MacDinh" Text="Mặc định chạy đầu tiên" runat="server"></asp:CheckBox> 
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                
                <asp:Button ID="btn_update" runat="server" Font-Bold="True" Text="Insert/Update"
                    BackColor="#E0E0E0" OnClick="btn_update_Click"></asp:Button>
                <asp:Button ID="btn_cancel" runat="server" Font-Bold="True" Text="Cancel" BackColor="#E0E0E0"
                    OnClick="btn_cancel_Click"></asp:Button>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    </div>
</asp:Panel>
<asp:Panel ID="pnvalue" runat="server" Width="100%">
<asp:MultiView ID="MultiView1" runat="server">
<asp:View ID="View1" runat="server">
<table  style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%"	border="0">
    <tr height="20"><td></td></tr>
	<tr height="25" bgcolor="WhiteSmoke">
		<td>
		<asp:LinkButton ID="lnk_back" runat="server" OnClick="lnk_back_Click"><%=label("l_back")%></asp:LinkButton>
		</td>
	</tr>
</TABLE>
<div class='frm-add'>

    <asp:Repeater ID="rpvalues" runat="server" OnItemCommand="rpvalues_ItemCommand">
        <HeaderTemplate>
            <table  style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td width="100" align="center">
                    <asp:LinkButton ID="Linkbutton4" CommandName="ValuesList" CommandArgument='<%#Eval("ID")%>' runat="server"><%=label("lt_edit")%></asp:LinkButton>
                </td>
                <td>
                    <%#Eval("VALUE") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
  </div>
</asp:View>
<asp:View ID="View2" runat="server">
<div class='frm-add'>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td width=200px>
            </td>
            <td width=5px>
            </td>
            <td>
                <asp:Label ID="ltmsg" runat="server"  Font-Bold=true ForeColor=red></asp:Label>
            </td>
        </tr>
        <tr>
            <td width=200px>
                &nbsp;<%=label("l_content")%></td>
            <td width=5px>
            </td>
            <td>
        <asp:textbox id="txtvalues" runat="server" height="150px" textmode="MultiLine" width="500px"></asp:textbox></td>
        </tr>
        <tr>
            <td width="200">
            </td>
            <td width="5">
            </td>
            <td>
        <asp:button id="btnupdatevalue" runat="server" onclick="btnupdatevalue_Click" text="Cập nhật" />
        <asp:button id="btncancelvalue" runat="server" onclick="btncancelvalue_Click" text="Hủy bỏ" /></td>
        </tr>
    </table>
</div>
</asp:View>
</asp:MultiView>
</asp:Panel>