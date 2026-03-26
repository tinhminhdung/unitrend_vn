<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cart.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.ProductsCarts.Cart" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <div class="frm_search">
            <%=label("l_status")%>
            <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" Width="144px">
                <asp:ListItem Selected="True" Value="-1">Tất cả</asp:ListItem>
                <asp:ListItem Value="0">Chưa duyệt</asp:ListItem>
                <asp:ListItem Value="1">Đã duyệt</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt" Width="209px"></asp:TextBox>
            <asp:Button ID="btnshow" runat="server" Text="Hiển thị" OnClick="btnshow_Click" Width="91px"></asp:Button>
            <asp:Button ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="56px" />

            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" Width="110px"
                runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="0">Chọn ngày</asp:ListItem>
                <asp:ListItem Value="01">01</asp:ListItem>
                <asp:ListItem Value="02">02</asp:ListItem>
                <asp:ListItem Value="03">03</asp:ListItem>
                <asp:ListItem Value="04">04</asp:ListItem>
                <asp:ListItem Value="05">05</asp:ListItem>
                <asp:ListItem Value="06">06</asp:ListItem>
                <asp:ListItem Value="07">07</asp:ListItem>
                <asp:ListItem Value="08">08</asp:ListItem>
                <asp:ListItem Value="09">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="26">26</asp:ListItem>
                <asp:ListItem Value="27">27</asp:ListItem>
                <asp:ListItem Value="28">28</asp:ListItem>
                <asp:ListItem Value="29">29</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="31">31</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList2" AutoPostBack="true" Width="110px"
                runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem Value="0">Chọn tháng</asp:ListItem>
                <asp:ListItem Value="01">01</asp:ListItem>
                <asp:ListItem Value="02">02</asp:ListItem>
                <asp:ListItem Value="03">03</asp:ListItem>
                <asp:ListItem Value="04">04</asp:ListItem>
                <asp:ListItem Value="05">05</asp:ListItem>
                <asp:ListItem Value="06">06</asp:ListItem>
                <asp:ListItem Value="07">07</asp:ListItem>
                <asp:ListItem Value="08">08</asp:ListItem>
                <asp:ListItem Value="09">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList3" AutoPostBack="true" Width="80px" runat="server"
                OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
            <%if (ShowExel == "1")
                {%>
            <asp:LinkButton CssClass="import" ID="lbtExport" runat="server" OnClick="Export_Click">Export dữ liệu</asp:LinkButton>
            <%} %>
            <asp:Literal ID="lttotal1" runat="server"></asp:Literal>
        </div>
        <div class="list_item">
            <asp:Repeater ID="rp_items" runat="server" OnItemCommand="rp_items_ItemCommand">
                <ItemTemplate>
                    <tr style="background-color: #f1f1f1" height="40">
                        <td align="center">
                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                        </td>
                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465" width="450px">
                            <%=label("l_name")%>:<span style="color: #444444; padding-left: 27px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Name")%></span><br />
                            <%=label("l_address")%>:<span style="color: #444444; padding-left: 40px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Address")%></span><br />
                            <%=label("l_phone")%>:<span style="color: #444444; padding-left: 22px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Phone")%> --- <%#DataBinder.Eval(Container.DataItem, "Phone2")%></span><br />
                            <%=label("l_email")%>:<span style="color: #444444; padding-left: 15px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Email")%></span><br />

                            Hình thức vận chuyển:<span style="color: #444444; padding-left: 15px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Hinhthucvanchuyen")%></span><br />
                            Nội Dung : <%#DataBinder.Eval(Container.DataItem, "Contents")%>
                        </td>
                        </td>
            <td align="center" style="font-weight: bold">
                <%#MoreAll.MorePro.FormatMoney(Eval("Money").ToString())%><br />
                <%--  <strong style=" color:Red; font-size:14px;">Chiết khấu: <%#MoreAll.MorePro.FormatMoney(Eval("Chietkhau").ToString())%></strong>--%>
            </td>
                        <td align="center">
                            <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date").ToString())%>
                        </td>
                        <td align="center">
                            <a onclick="NewWindow_('cms/admin/ProductsCarts/Cartdetail.aspx?ID_Cart=<%#DataBinder.Eval(Container.DataItem,"ID")%>','Process','800','450','true','true')" href='javascript:void(0)'>
                                <img src="Resources/admin/images/chitiet.png" border="0" /></a>
                            <div style="padding-top: 10px">
                                <%if (ShowDuyet == "1")
                                    {%>
                                <asp:LinkButton CommandName="Check" OnLoad="Pass_Load" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" Visible='<%#Visible(DataBinder.Eval(Container.DataItem,"Status").ToString())%>'>[Duyệt]</asp:LinkButton>
                                <%} %>
                                <%if (ShowHuy == "1")
                                    {%>
                                <asp:LinkButton CommandName="UnCheck" OnLoad="UnPass_Load" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton4" Visible='<%#Visible_(DataBinder.Eval(Container.DataItem,"Status").ToString())%>'>[Hủy bỏ]</asp:LinkButton>
                                <%} %>
                            </div>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="LinkButton5" CommandName="SendMail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server"><img src="Resources/admin/images/email.png" border=0 /></asp:LinkButton>
                        </td>
                        <td align="center">
                            <%if (ShowXoa == "1")
                                {%>
                            <div class="del">
                                <asp:LinkButton ID="LinkButton2" OnLoad="Delete_Load" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[<%=label("ldelete") %>]</asp:LinkButton>
                            </div>
                            <%} %>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #ffff" height="40">
                        <td align="center">
                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                        </td>
                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465" width="450px">
                            <%=label("l_name")%>:<span style="color: #444444; padding-left: 27px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Name")%></span><br />
                            <%=label("l_address")%>:<span style="color: #444444; padding-left: 40px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Address")%></span><br />
                            <%=label("l_phone")%>:<span style="color: #444444; padding-left: 22px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Phone")%> --- <%#DataBinder.Eval(Container.DataItem, "Phone2")%></span><br />
                            <%=label("l_email")%>:<span style="color: #444444; padding-left: 15px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Email")%></span><br />
                            Hình thức vận chuyển:<span style="color: #444444; padding-left: 15px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Hinhthucvanchuyen")%></span><br />
                            Nội Dung : <%#DataBinder.Eval(Container.DataItem, "Contents")%>
                        </td>
                        <td align="center" style="font-weight: bold">
                            <%#MoreAll.MorePro.FormatMoney(Eval("Money").ToString())%><br />
                            <%-- <strong style=" color:Red; font-size:14px;">Chiết khấu: <%#MoreAll.MorePro.FormatMoney(Eval("Chietkhau").ToString())%></strong>--%>
                        </td>
                        <td align="center">
                            <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date").ToString())%>
                        </td>
                        <td align="center">
                            <a onclick="NewWindow_('cms/admin/ProductsCarts/Cartdetail.aspx?ID_Cart=<%#DataBinder.Eval(Container.DataItem,"ID")%>','Process','800','450','true','true')" href='javascript:void(0)'>
                                <img src="Resources/admin/images/chitiet.png" border="0" /></a>
                            <div style="padding-top: 10px">
                                <%if (ShowDuyet == "1")
                                    {%>
                                <asp:LinkButton CommandName="Check" OnLoad="Pass_Load" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" Visible='<%#Visible(DataBinder.Eval(Container.DataItem,"Status").ToString())%>'>[Duyệt]</asp:LinkButton>
                                <%} %>
                                <%if (ShowHuy == "1")
                                    {%>
                                <asp:LinkButton CommandName="UnCheck" OnLoad="UnPass_Load" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton4" Visible='<%#Visible_(DataBinder.Eval(Container.DataItem,"Status").ToString())%>'>[Hủy bỏ]</asp:LinkButton>
                                <%} %>
                            </div>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="LinkButton5" CommandName="SendMail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server"><img src="Resources/admin/images/email.png" border=0 /></asp:LinkButton>
                        </td>
                        <td align="center">
                            <%if (ShowXoa == "1")
                                {%>
                            <div class="del">
                                <asp:LinkButton ID="LinkButton2" OnLoad="Delete_Load" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[<%=label("ldelete") %>]</asp:LinkButton>
                            </div>
                            <%} %>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <HeaderTemplate>
                    <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                        <tr style="background-color: #d5d1d1" height="40">
                            <td class="header">
                                <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
                            <td class="header">Thông tin khách hàng</td>
                            <td class="header"><%=label("l_ordervalues") %></td>
                            <td class="header"><%=label("l_datesend")%></td>
                            <td class="header">Xem chi tiết</td>
                            <td class="header">Gửi mail</td>
                            <td class="header"><%=label("ldelete")%></td>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <SeparatorTemplate>
                    <tr>
                        <td bgcolor="#30a72f" colspan="7" height="1"></td>
                    </tr>
                </SeparatorTemplate>
            </asp:Repeater>
        </div>
        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
            <tr height="20">
                <td align="center">
                    <div class="phantrang" style="">
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                            BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
                            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                        </cc1:CollectionPager>
                    </div>
                </td>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <div class='frm-add'>
            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="red"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td>Tiêu đề</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txttitle" runat="server" Width="350px" CssClass="txt_css"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>Tên người nhận</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txttoname" runat="server" CssClass="txt_css" Width="350px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 24px"></td>
                    <td style="height: 24px">Email đến</td>
                    <td style="height: 24px"></td>
                    <td style="height: 24px">
                        <asp:TextBox ID="txtTo" runat="server" CssClass="txt_css" Width="350px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>Nội dung<br />
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3">
                        <CKEditor:CKEditorControl ID="txtContent" runat="server" Height="300px"></CKEditor:CKEditorControl>
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding-left: 100px; height: 100px;">
            <asp:Button ID="btnSend" runat="server" Text="Gửi mail" OnClick="btnSend_Click" Width="87px" />
            <asp:Button ID="btncancel" runat="server" Text="Hủy bỏ" OnClick="btncancel_Click" Width="67px" />
        </div>
    </asp:View>
</asp:MultiView>

