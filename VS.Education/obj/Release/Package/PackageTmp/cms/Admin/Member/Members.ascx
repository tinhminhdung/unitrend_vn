<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Members.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Member.Members" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<script type="text/javascript" src="/cms/Admin/Member/Horver/js/JScript1.js"></script>
<script type="text/javascript" src="/cms/Admin/Member/Horver/js/stickytooltip.js"></script>
<link rel="stylesheet" type="text/css" href="/cms/Admin/Member/Horver/js/stickytooltip.css" />
<div class="Sub_menu_top_right">
    <a class='linkmainmenu' style="color: Red" href='/admin.aspx?u=Thanhvien'>Quản lý thành viên</a>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="margin-top: 10px" class="frm_search">
            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td valign="top">
                            <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
                            <asp:Button ID="lnksearch" runat="server" Text="Tìm kiếm" OnClick="lnksearch_Click" />
                            <asp:DropDownList ID="ddlstatus" runat="server" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="ddlorderby" runat="server" AutoPostBack="true" CssClass="txt"
                                OnSelectedIndexChanged="ddlorderby_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="dcreatedate">S.xếp:Ngày cập nhật</asp:ListItem>
                                <asp:ListItem Value="iuser_id">S.xếp:Tăng dần</asp:ListItem>
                                <asp:ListItem Value="vlname">S.xếp:Tên (ABC)</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlordertype" runat="server" AutoPostBack="True" CssClass="txt"
                                OnSelectedIndexChanged="ddlordertype_SelectedIndexChanged">
                                <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                                <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btndisplay" OnClick="btndisplay_Click" runat="server" Text="Hiển thị"></asp:Button>

                            <%if (ShowXoa == "1")
                           {%>
                            <asp:Button ID="btxoa" runat="server" Text="Xóa" OnClick="btxoa_Click" />
                            <%} %>
                            <div style="float: right; padding-top: 6px;">Mật khẩu mặc định: 123456</div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>


        <div class="list_item">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                        <tr bgcolor="#C4C4C4" height="22">
                            <td class="header">
                                <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
                            <td class="header">Thông tin thành viên</td>
                            <td class="header">Ngày đăng ký</td>
                            <td class="header">Tình trạng</td>
                            <td class="header"><%=label("l_status")%></td>
                            <td class="header">RESET mật khẩu</td>
                            <td class="header">Xóa tài khoản</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: #ececec" height="40">
                        <td align="center">
                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("iuser_id") %>' runat="server" />
                        </td>
                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465" width="450px">
                            <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Mã Khách hàng</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <b style="color: #67c2ca"><%#DataBinder.Eval(Container.DataItem, "iuser_id")%></b>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Khách hàng</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#Eval("vfname") %>
                                        <%-- <a onclick="NewWindow_('cms/admin/Member/Cartdetail.aspx?ID_Cart=<%#DataBinder.Eval(Container.DataItem,"iuser_id")%>','Process','1000','450','true','true')" href='javascript:void(0)'><%#Eval("vfname") %></a>--%>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Mật khẩu</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#Eval("vuserpwd") %>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b><%=label("l_phone")%></b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#DataBinder.Eval(Container.DataItem, "vphone")%> 
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Email:</b>
                                    </td>
                                    <td style="border: none !important">
                                        <%#DataBinder.Eval(Container.DataItem, "vemail")%>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b><%=label("l_address")%></b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#DataBinder.Eval(Container.DataItem, "vaddress")%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center">
                            <%#MoreAll.MoreAll.FormatDate(Eval("dlastvisited").ToString())%>
                        </td>
                        <td align="center">
                            <%#Status(Eval("istatus").ToString())%>
                        </td>
                        <td align="center">
                            <%if (ShowKhoa == "1")
                                {%>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="lock" CommandArgument='<%#Eval("iuser_id")%>' OnLoad="Lock_Load" Visible='<%#EnableLock(Eval("istatus").ToString())%>'>[Lock]</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton5" runat="server" CommandName="unlock" CommandArgument='<%#Eval("iuser_id")%>' Visible='<%#EnableUnLock(Eval("istatus").ToString())%>'>[Unlock]</asp:LinkButton>
                            <%} %> </td>
                        <td align="center">
                            <%if (ShowRS == "1")
                                {%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("iuser_id")%>' CommandName="Pass">[Pas Mặc định]</asp:LinkButton>
                            <%} %>
                        </td>
                        <td align="center">
                            <%if (ShowXoa == "1")
                                {%>
                            <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%#Eval("iuser_id")%>' CommandName="delete" OnLoad="Delete_Load">[<%=label("ldelete") %>]</asp:LinkButton>
                            <%} %>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #ffff" height="40">
                        <td align="center">
                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("iuser_id") %>' runat="server" />
                        </td>
                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465" width="450px">
                            <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Mã Khách hàng</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <b style="color: #67c2ca"><%#DataBinder.Eval(Container.DataItem, "iuser_id")%></b>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Khách hàng</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#Eval("vfname") %>
                                        <%-- <a onclick="NewWindow_('cms/admin/Member/Cartdetail.aspx?ID_Cart=<%#DataBinder.Eval(Container.DataItem,"iuser_id")%>','Process','1000','450','true','true')" href='javascript:void(0)'><%#Eval("vfname") %></a>--%>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Mật khẩu</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#Eval("vuserpwd") %>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b><%=label("l_phone")%></b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#DataBinder.Eval(Container.DataItem, "vphone")%> 
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Email:</b>
                                    </td>
                                    <td style="border: none !important">
                                        <%#DataBinder.Eval(Container.DataItem, "vemail")%>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b><%=label("l_address")%></b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#DataBinder.Eval(Container.DataItem, "vaddress")%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center">
                            <%#MoreAll.MoreAll.FormatDate(Eval("dlastvisited").ToString())%>
                        </td>
                        <td align="center">
                            <%#Status(Eval("istatus").ToString())%>
                        </td>
                        <td align="center">
                            <%if (ShowKhoa == "1")
                                {%>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="lock" CommandArgument='<%#Eval("iuser_id")%>' OnLoad="Lock_Load" Visible='<%#EnableLock(Eval("istatus").ToString())%>'>[Lock]</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton5" runat="server" CommandName="unlock" CommandArgument='<%#Eval("iuser_id")%>' Visible='<%#EnableUnLock(Eval("istatus").ToString())%>'>[Unlock]</asp:LinkButton>
                            <%} %> </td>
                        <td align="center">
                            <%if (ShowRS == "1")
                                {%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("iuser_id")%>' CommandName="Pass">[Pas Mặc định]</asp:LinkButton>
                            <%} %>
                        </td>
                        <td align="center">
                            <%if (ShowXoa == "1")
                                {%>
                            <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%#Eval("iuser_id")%>' CommandName="delete" OnLoad="Delete_Load">[<%=label("ldelete") %>]</asp:LinkButton>
                            <%} %>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
            <tr height="20">
                <td align="right">
                    <div class="phantrang" style="">
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                            BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
                            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                        </cc1:CollectionPager>
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<style>
    .item {
        color: #000;
        line-height: 22px;
    }
</style>
