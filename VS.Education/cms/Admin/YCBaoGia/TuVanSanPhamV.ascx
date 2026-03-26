<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TuVanSanPhamV.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.YCBaoGia.TuVanSanPhamV" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <div style="margin-top: 10px;" class="frm_search">

            <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
            <asp:Button ID="lnksearch" runat="server" OnClick="lnksearch_Click" Text="Tìm kiếm" />
            <asp:DropDownList ID="ddlstatus" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="-1">Tất cả</asp:ListItem>
                <asp:ListItem Value="0">Chưa kiểm duyệt</asp:ListItem>
                <asp:ListItem Value="1">Đã kiểm duyệt &amp; trả lời</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlorderby" runat="server" AutoPostBack="true" CssClass="txt" Width="140px" OnSelectedIndexChanged="ddlorderby_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="dcreatedate">S.xếp:Ngày cập nhật</asp:ListItem>
                <asp:ListItem Value="vname">S.xếp:Tiêu đề (ABC)</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlordertype" runat="server" AutoPostBack="True" CssClass="txt" Width="100px" OnSelectedIndexChanged="ddlordertype_SelectedIndexChanged">
                <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btndisplay" runat="server" OnClick="btndisplay_Click" Text="Hiển thị" Width="94px" />

            <%if (ShowXoa == "1")
                {%>
            <asp:Button ID="btdelete" runat="server" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" OnClick="btdelete_Click" Width="44px" />
            <%} %>
        </div>
        <div class="list_item">
            <asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
                <ItemTemplate>
                    <tr style="background-color: #f1f1f1" height="40">
                        <td align="center">
                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ino") %>' runat="server" />
                        </td>
                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465">

                            <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Mã báo giá</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#Eval("MaBaoGia") %>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Khách hàng</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#Eval("vname") %>
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
                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465">

                            <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Ngày liên hệ</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"dcreatedate"))%>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Tên sản phẩm</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <b style="color: #67c2ca"><%#DataBinder.Eval(Container.DataItem, "vtitle")%></b>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center">
                            <%if (ShowXuLy == "1")
                                {%>
                            <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ino")+"|"+Eval("istatus")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable_trangthai(DataBinder.Eval(Container.DataItem, "istatus").ToString())%></asp:LinkButton>
                            <%} %>
                        </td>
                        <td align="center">
                            <%if (ShowXoa == "1")
                                {%>
                            <div class="del">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ino")%>' CommandName='delete' OnLoad="Delete_Load">[Xóa]</asp:LinkButton>
                            </div>
                            <%} %>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #fff" height="40">
                        <td align="center">
                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ino") %>' runat="server" />
                        </td>
                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465">

                            <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Mã báo giá</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#Eval("MaBaoGia") %>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Khách hàng</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#Eval("vname") %>
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
                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465">
                            <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Ngày yêu cầu</b>:
                                    </td>
                                    <td style="border: none !important">
                                        <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"dcreatedate"))%>
                                    </td>
                                </tr>
                                <tr style="border: none !important">
                                    <td style="width: 97px; border: none !important">
                                        <b>Tên sản phẩm </b>:
                                    </td>
                                    <td style="border: none !important">
                                        <b style="color: #67c2ca"><%#DataBinder.Eval(Container.DataItem, "vtitle")%></b>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center">
                            <%if (ShowXuLy == "1")
                                {%>
                            <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ino")+"|"+Eval("istatus")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable_trangthai(DataBinder.Eval(Container.DataItem, "istatus").ToString())%></asp:LinkButton>
                            <%} %>
                        </td>
                        <td align="center">
                            <%if (ShowXoa == "1")
                                {%>
                            <div class="del">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ino")%>' CommandName='delete' OnLoad="Delete_Load">[Xóa]</asp:LinkButton>
                            </div>
                            <%} %>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <HeaderTemplate>
                    <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                        <tr bgcolor="#C4C4C4" height="22">
                            <td class="header">
                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" /></td>
                            <td class="header" style="text-transform: uppercase; color: #fff !important">Thông tin khách hàng</td>
                            <td class="header" style="text-transform: uppercase; color: #fff !important">Nội dung/sản phẩm</td>
                            <td class="header" style="text-transform: uppercase; color: #fff !important"><%=label("l_status")%></td>
                            <td class="header" style="text-transform: uppercase; color: #fff !important">Xử lý</td>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>				
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
            <tr height="20">
                <td align="center">
                    <div class="phantrang" style="">
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks"
                            BackNextLocation="Split" BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom"
                            PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"
                            IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText=""
                            LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers" ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})"
                            ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False"
                            ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass=""
                            ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                        </cc1:CollectionPager>
                    </div>
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <div style="height: 10px"></div>
        <asp:Button ID="btnback" runat="server" OnClick="btnback_Click" Text="Trở lại" Width="78px" />
        <asp:Button ID="btncheck" runat="server" Text="Xác nhận kiểm tra" OnClick="btncheck_Click" />
        <asp:Button ID="btphanhoi" runat="server" Text="Phản hồi liên hệ" OnClick="btphanhoi_Click" />
        <asp:Button ID="btxoa" OnLoad="Delete_Load_Button" runat="server" Text="Xóa" OnClick="btxoa_Click" />
        <div style="line-height: 33px; padding-top: 10px">
            <span class="caption3"><%=label("l_title")%>:
                <asp:Literal ID="ltsubject" runat="server"></asp:Literal></span><br />
            <span class="caption3"><%=label("l_name")%>:</span>
            <asp:Literal ID="ltsender" runat="server"></asp:Literal><br />
            <span class="caption3"><%=label("l_address")%>:</span>
            <asp:Literal ID="ltaddress" runat="server"></asp:Literal><br />
            <span class="caption3"><%=label("l_phone")%>:</span>
            <asp:Literal ID="ltphone" runat="server"></asp:Literal><br />
            <span class="caption3"><%=label("l_email")%>:</span>
            <asp:Literal ID="ltemail" runat="server"></asp:Literal><br />
        </div>
        <div style="display: block; padding-top: 5px">
            <span class="caption3">Nội Dung</span>:
            <asp:Literal ID="ltcontent" runat="server"></asp:Literal>
        </div>
        <asp:HiddenField ID="hdid" runat="server" />
    </asp:View>
    <asp:View ID="View3" runat="server">
        <div class='frm-add'>
            <table border="0" cellpadding="0" cellspacing="0" width="99.5%">
                <tr>
                    <td colspan="3">
                        <b>PHẢN HỒI LIÊN HỆ</b>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;Gửi đến&nbsp;
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtTo" CssClass="txt_css" runat="server" Width="421px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;Tiêu đề&nbsp;
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txttitle" CssClass="txt_css" runat="server" Width="421px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">&nbsp;Nội dung&nbsp;
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtContent" CssClass="txt_css" runat="server" Width="421px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnreplyemail" CssClass="txt_css" runat="server" Text="Trả lời" Width="108px" OnClick="btnreplyemail_Click" />
                        &nbsp;<asp:Button ID="btcancelemail" CssClass="txt_css" runat="server" Text="Hủy bỏ" OnClick="btcancelemail_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:View>
</asp:MultiView>
