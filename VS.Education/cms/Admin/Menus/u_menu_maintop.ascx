<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_menu_maintop.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Menus.u_menu_maintop" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>
    <asp:Literal ID="lt_info" Visible=false runat="server"></asp:Literal>
    <input id="hd_insertupdate" type="hidden" size="1" name="Hidden1" runat="server">
    <input id="hd_id" type="hidden" size="1" name="Hidden2" runat="server">
    <input id="hd_page_edit_id" type="hidden" size="1" name="Hidden2" runat="server">
    <input id="hd_imgpath" type="hidden" size="1" name="Hidden2" runat="server">
    <input id="hd_rootpic" type="hidden" size="1" runat="server">
    <input id="hd_par_id"  type="hidden" size="1" name="Hidden2" runat="server">
 <table  style="border-collapse: collapse" cellpadding="0"  width="100%" border="0">
    <tbody>
        <tr>
            <td valign="top">
                <asp:Panel ID="pn_list" runat="server" Width="100%">
                <div class="frm_search">
                 <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <tr>
                        <td>
                        </td>
                       <td class="topcontent" style="width: 50%">
                            <asp:Button ID="btxoa2"  runat="server" OnClick="btxoa2_Click" OnClientClick=" return confirmDelete(this);"  Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="35px" ForeColor="Green" />
                        </td>
                    </tr>
                </table>
                 </div>
                    <div  class="list_item">
                    <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                        <ItemTemplate>
	                     	<tr style="background-color:#f1f1f1"  height="40">
                                   <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
                                   <td>
                                     <b><%#DataBinder.Eval(Container.DataItem,"Name")%></b><br>
                                      <%#DataBinder.Eval(Container.DataItem,"Link")%>
                                   </td>
                                    <td align="center">
                                        <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                   </td>
                                   <td align="center">
                                     <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("id")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                    </td>
                                 <td align="center">
                                     <asp:LinkButton ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>' runat="server" ToolTip="Add/Edit Content">[ <%=label("lt_edit")%>]</asp:LinkButton>
                                    </td>
                                   <td align="center">
                                        <div class="del"><asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>'  runat="server" ID="Linkbutton3" OnLoad="Delete_Load" ToolTip="Delete this">[<%=label("ldelete")%>]</asp:LinkButton></div>
                                   </td>
                             </tr>
	                        </ItemTemplate>
	                        <AlternatingItemTemplate>
	                            <tr style="background-color: #ffff" height="40">
                                   <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
                                   <td>
                                     <b><%#DataBinder.Eval(Container.DataItem,"Name")%></b><br>
                                      <%#DataBinder.Eval(Container.DataItem,"Link")%>
                                   </td>
                                    <td align="center">
                                        <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                   </td>
                                   <td align="center">
                                     <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("id")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                    </td>
                                 <td align="center">
                                     <asp:LinkButton ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>' runat="server" ToolTip="Add/Edit Content">[ <%=label("lt_edit")%>]</asp:LinkButton>
                                    </td>
                                   <td align="center">
                                        <div class="del"><asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>'  runat="server" ID="Linkbutton3" OnLoad="Delete_Load" ToolTip="Delete this">[<%=label("ldelete")%>]</asp:LinkButton></div>
                                   </td>
                             </tr>
	                        </AlternatingItemTemplate>
                           <HeaderTemplate>
                        <table  border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                         <tr bgcolor="#C4C4C4" height="22">
                            <td class="header"><input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
	                        <td class="header"><%=label("l_linkmenu")%></td>
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
                    <table  style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%"	border="0">
                        <tr height="20"><td></td></tr>
	                    <tr height="25" bgcolor="whitesmoke">
		                    <td> <b><asp:LinkButton ID="LinkButton5" OnClick="LinkButton4_Click" runat="server">[<%=label("l_createnew")%>]</asp:LinkButton></b></td>
	                    </tr>
                    </TABLE>

                               
                           
                </asp:Panel>
                <asp:Panel ID="pn_insert" runat="server" Visible="False" Width="100%">
                <div class='frm-add'>
                    <table style="border-collapse: collapse" cellpadding="0"
                        width="100%" border="0">
                        <tr>
                            <td align="right" width="175">
                                
                            </td>
                            <td width="10">
                            </td>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <b></b>
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <b>
                                    <%=label("answers_title")%></b>
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                <asp:TextBox ID="txt_title" runat="server" Width="231px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 18px" align="right">
                                <b>
                                    <%=label("lt_url")%></b>
                            </td>
                            <td style="height: 18px">
                            </td>
                            <td style="height: 18px">
                                <asp:TextBox ID="txturl" runat="server" Width="292px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>
                                    <%=label("l_linkopentype")%></strong>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlopentype" runat="server">
                                    <asp:ListItem Value="0">Mở trong trang hiện tại</asp:ListItem>
                                    <asp:ListItem Value="1">Mở trong trang mới</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>
                                    <%=label("lt_order")%></strong>
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                <asp:TextBox ID="txt_order" runat="server" Width="32px">1</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>
                                    <%=label("lt_display")%></strong>
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                <asp:CheckBox ID="chck_Enable" runat="server" Visible="True"></asp:CheckBox>
                                <asp:CheckBox ID="chkupdateimg" runat="server" Visible="False" Text="Update Image" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                <asp:Button ID="btn_InsertUpdate" runat="server" Text="Insert/Update" Width="120px" OnClick="btn_InsertUpdate_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="56px" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </tbody>
</table>
</contenttemplate>
</asp:UpdatePanel>