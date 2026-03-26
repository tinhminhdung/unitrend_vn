<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sitemaps.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Sitemap.sitemaps" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>
  <input id="hd_insertupdate" type="hidden" size="1" name="Hidden1" runat="server">
<input id="hd_id" type="hidden" size="1" name="Hidden2" runat="server">
<input id="hd_par_id" type="hidden" size="1" name="Hidden2" runat="server">
<input id="hd_page_edit_id" type="hidden" size="1" name="Hidden2" runat="server">
<input id="hd_imgpath" type="hidden" size="1" name="Hidden2" runat="server">
<input id="hd_rootpic" type="hidden" size="1" runat="server">
<table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tbody>
        <tr class="bgTitle" height="25">
            <td>
                <asp:Literal ID="lt_info" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Panel ID="pn_list" runat="server" Width="100%">
                    <div style="margin-top: 10px;" class="frm_search">
                        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_curpage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="topcontent" style="width: 50%">
                                    <asp:Button ID="btn_Homepage" runat="server" Width="96px" ForeColor="Green" OnClick="btn_Homepage_Click">
                                    </asp:Button>
                                    <asp:Button ID="btn_back" runat="server" Text="<<< Back" Width="96px" ForeColor="Green"
                                        OnClick="btn_back_Click"></asp:Button>
                                        <asp:Button ID="btxoa"  runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);"  Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="35px" ForeColor="Green" />
                                    <asp:Literal ID="ltmsg" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="list_item">
                        <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                            <ItemTemplate>
                               <tr style="background-color:#f1f1f1"  height="40">
                                    <td align="center">
                                        <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField  ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                    </td>
                                    <td>
                                        <b><asp:LinkButton CommandName="ListChildren" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton2" NAME="Linkbutton2"><%#DataBinder.Eval(Container.DataItem,"Name")%></asp:LinkButton></b>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Link") %>
                                    </td>
                                    <td align="center">
                                        <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                            runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton6" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                            runat="server" ToolTip="Add/Edit Content">[<%=label("lt_edit")%>]</asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <div class="del">
                                            <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                                runat="server" ID="Linkbutton3" OnLoad="Delete_Load" ToolTip="Delete this">[Xóa]</asp:LinkButton></div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr style="background-color: #ffff" height="40">
                                    <td align="center">
                                        <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                            ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                    </td>
                                    <td>
                                        <b>
                                            <asp:LinkButton CommandName="ListChildren" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                                runat="server" ID="Linkbutton2" NAME="Linkbutton2"><%#DataBinder.Eval(Container.DataItem,"Name")%></asp:LinkButton></b>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Link") %>
                                    </td>
                                    <td align="center">
                                        <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                            runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton6" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                            runat="server" ToolTip="Add/Edit Content">[<%=label("lt_edit")%>]</asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <div class="del">
                                            <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                                runat="server" ID="Linkbutton3" OnLoad="Delete_Load" ToolTip="Delete this">[Xóa]</asp:LinkButton></div>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <HeaderTemplate>
                                <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                    <tr bgcolor="#C4C4C4" height="22">
                                        <td class="header">
                                            <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
                                        <td class="header">
                                            <%=label("answers_title")%></td>
                                        <td class="header">
                                            Đường dẫn</td>
                                        <td class="header">
                                            <%=label("lt_order")%>
                                        </td>
                                        <td class="header">
                                            <%=label("l_status")%>
                                        </td>
                                        <td class="header">
                                            <%=label("lt_edit")%>
                                        </td>
                                        <td class="header">
                                            <%=label("ldelete")%>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                        <tr height="20">
                            <td>
                            </td>
                        </tr>
                        <tr height="25" bgcolor="whitesmoke">
                            <td>
                                <b>
                                    <asp:LinkButton ID="LinkButton5" OnClick="LinkButton4_Click" runat="server">[<%=label("l_createnew")%>]</asp:LinkButton></b></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pn_insert" runat="server" Visible="False" Width="100%">
                    <div class='frm-add'>
                        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
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
                                    <b>
                                        <%=label("answers_title")%>
                                    </b>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_title" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>Đường dẫn</b>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdmain" GroupName="GG" runat="server" Text="Tính năng có sẵn"
                                        AutoPostBack="True" Checked="True" OnCheckedChanged="rdmain_CheckedChanged" />&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdurl" GroupName="GG" runat="server" Text="Đường dẫn" AutoPostBack="True"  OnCheckedChanged="rdurl_CheckedChanged" /><br />
                                    <asp:DropDownList ID="ddlmain" runat="server" Width="200px">
                                        <asp:ListItem Value="index">Homepage</asp:ListItem>
                                        <asp:ListItem Value="news">News</asp:ListItem>
                                        <asp:ListItem Value="shop">Products</asp:ListItem>
                                        <asp:ListItem Value="videos">Videos</asp:ListItem>
                                        <asp:ListItem Value="download">Files Library</asp:ListItem>
                                        <asp:ListItem Value="photos">Photo Album</asp:ListItem>
                                        <asp:ListItem Value="sitemap">SiteMap</asp:ListItem>
                                        <asp:ListItem Value="contact">Contact Page</asp:ListItem>
                                        <asp:ListItem Value="membership">Membership</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txturl" runat="server" Width="195px" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>
                                        <%=label("lt_order")%>
                                    </strong>
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
                                        <%=label("lt_display")%>
                                    </strong>
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlopen" runat="server" Width="176px">
                                        <asp:ListItem Value="_parent">Mở trong trang hiện tại</asp:ListItem>
                                        <asp:ListItem Value="_blank">Mở sang trang mới</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr height="10px">
                                <td align="right">
                                    Tùy chọn
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chck_Enable" runat="server" Visible="True" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btn_InsertUpdate" runat="server"  OnClick="btn_InsertUpdate_Click" Text="Insert/Update" Width="120px" />
                                    <asp:Button ID="btnCancel" runat="server"  OnClick="btnCancel_Click" Text="Cancel" Width="56px" />
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
  </ContentTemplate>
</asp:UpdatePanel> 