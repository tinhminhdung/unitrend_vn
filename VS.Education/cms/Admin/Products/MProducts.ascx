<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MProducts.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Products.MProducts" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<link href="/cms/Admin/Products/Css/Style.css" rel="stylesheet" type="text/css" />
<script src="/cms/Admin/Products/Css/star-rating-svg/jquery.star-rating-svg.js" type="text/javascript"></script>
<link href="/cms/Admin/Products/Css/star-rating-svg/star-rating-svg.css" rel="stylesheet" type="text/css" />

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div class="frm_search">
                    <div>
                        <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
                        <asp:Button ID="lnksearch" runat="server" Text="Tìm kiếm" OnClick="lnksearch_Click" />
                        <asp:Label ID="ltthongbao" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                    </div>
                    <div style="margin-top: 10px;">
                        <asp:DropDownList ID="ddlcategories" CssClass="txt" AutoPostBack="true" runat="server" Width="148px" OnSelectedIndexChanged="ddlcategories_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlHinhAnhNoiDung" runat="server" AutoPostBack="true" CssClass="txt" Width="125px" OnSelectedIndexChanged="ddlHinhAnhNoiDung_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="True">Tất cả các nội dung</asp:ListItem>
                            <asp:ListItem Value="1">Chưa có ảnh</asp:ListItem>
                            <asp:ListItem Value="2">Chưa có nội dung</asp:ListItem>
                            <asp:ListItem Value="3">Sản phẩm đang bán</asp:ListItem>
                            <asp:ListItem Value="4">Đã có ảnh</asp:ListItem>
                            <asp:ListItem Value="5">Đã có nội dung</asp:ListItem>
                            <asp:ListItem Value="6">Sản phẩm đã ngừng bán</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="dddltailieu" runat="server" AutoPostBack="true" CssClass="txt" Width="125px" OnSelectedIndexChanged="dddltailieu_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="True">Tất cả tài liệu</asp:ListItem>
                            <asp:ListItem Value="1">Chưa có tài liệu</asp:ListItem>
                            <asp:ListItem Value="2">Đã có tài liệu</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" CssClass="txt" Width="125px" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="True">Tất cả các mục</asp:ListItem>
                            <asp:ListItem Value="1">Hiển thị</asp:ListItem>
                            <asp:ListItem Value="0">Ẩn</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlorderby" runat="server" AutoPostBack="true" CssClass="txt" OnSelectedIndexChanged="ddlorderby_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Create_Date">S.xếp:Ngày cập nhật</asp:ListItem>
                            <asp:ListItem Value="Modified_Date">S.xếp:Ngày hết hạn</asp:ListItem>
                            <asp:ListItem Value="Price">S.xếp:Theo giá hiện tại</asp:ListItem>
                            <asp:ListItem Value="Views">S.xếp:Lần xem</asp:ListItem>
                            <asp:ListItem Value="Name">S.xếp:Tiêu đề (ABC)</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlordertype" runat="server" AutoPostBack="True" CssClass="txt" OnSelectedIndexChanged="ddlordertype_SelectedIndexChanged">
                            <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                            <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlvitri" runat="server" AutoPostBack="True" CssClass="txt" OnSelectedIndexChanged="ddlvitri_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">Vị trí hiển thị</asp:ListItem>
                            <asp:ListItem Value="1">Số lượng - Hết hàng</asp:ListItem>
                            <asp:ListItem Value="2">Số lượng - Từ 0 đến 10</asp:ListItem>
                            <asp:ListItem Value="3">Số lượng - Từ 10 đến 50</asp:ListItem>
                        </asp:DropDownList>
                        <%if (ShowThem == "1")
                            {%>
                        <asp:Button ID="bthienthi" runat="server" Text="Hiển thị" OnClick="bthienthi_Click" Width="70px" />
                        <%} %>

                        <asp:Button ID="btthemmoi" runat="server" Text="Thêm mới" OnClick="btthemmoi_Click" Width="91px" />
                        <%if (ShowXoa == "1")
                            {%>
                        <asp:Button ID="btDeleteall" ToolTip="Xóa những lựa chọn !" OnClientClick=" return confirmDelete(this);" runat="server" Text="Xóa" OnClick="btDeleteall_Click" Width="34px" />
                        <%} %>
                    </div>
                </div>
                <p id="message"></p>
                <div class="list_item">
                    <asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand1">
                        <ItemTemplate>
                            <tr style="background-color: #f1f1f1" height="40">
                                <td align="center">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ipid") %>' runat="server" />
                                </td>
                                <td align="center">
                                    <div style="position: relative;">
                                        <span class="anhn"><%#MoreAll.MoreImage.Image(Eval("Images").ToString())%></span>
                                        <%#Hethang(Eval("Quantity").ToString())%>
                                        <%--  <div id="copyText"><%#Eval("ipid") %></div>
                                        <a class="nutcopy_button" onclick="copyText()">Copy</a>--%>
                                    </div>
                                </td>
                                <td style="width: 350px">
                                    <b style="line-height: 18px"><a title="<%#Eval("Name")%>" target="_blank" href="/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html"><%#Eval("Name") %></a></b>
                                    <div style="height: 5px;"></div>
                                    <div style="color: #007734; font-weight: bold"><span style="color: red">Mã SP:</span> <%#Eval("Code")%></div>
                                    <div style="color: #007734; font-weight: bold"><span style="color: red">ID SP:</span> <span id="copyText"><%#Eval("ipid") %></span></div>

                                </td>
                                <td><%#MoreAll.MorePro.FormatMoney_Cart(Eval("Price").ToString())%>
                                </td>
                                <td align="center">
                                    <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date"))%>
                                    <%#MoreLisucapnhat(Eval("ipid").ToString())%>
                                    <div>
                                        <asp:LinkButton ID="LinkButton4" CssClass="lnk" CommandName="Chekdata" CommandArgument='<%#Eval("ipid") %>' runat="server"> <%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></asp:LinkButton>
                                    </div>
                                </td>
                                <td align="center">
                                    <%#DataBinder.Eval(Container.DataItem,"Views")%>
                                </td>
                                <td align="center">
                                    <div>
                                        <a class="btn" style="color: red; font-weight: bold" onclick="Show_TaiLieu('<%#Eval("ipid") %>','<%#Eval("Name") %>')">
                                            <img src="Resources/2025/ic2.jpg" style="width: 20px;" border="0" title="Tài liệu"></a>
                                    </div>
                                </td>
                                <td align="center">
                                    <div>
                                        <a class="btn2" style="color: red; font-weight: bold" onclick="Show_LienQuan('<%#Eval("ipid") %>','<%#Eval("Name") %>')">
                                            <img src="Resources/2025/lienket.png" style="width: 25px;" border="0" title="Liên quan"></a>
                                    </div>
                                </td>
                                <td align="center">
                                    <div>
                                        <a class="btn3" style="color: red; font-weight: bold" onclick="Show_SoSanh('<%#Eval("ipid") %>','<%#Eval("icid") %>','<%#Eval("Name") %>')">
                                            <img src="Resources/2025/sosanh.png" style="width: 20px;" border="0" title="So sánh"></a>
                                    </div>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="LinkButton7" CssClass="lnk" CommandName="updat_date" CommandArgument='<%#Eval("ipid") %>' runat="server"><img src="Resources/admin/images/refesh.png" border=0 title="Làm mới sản phẩm"></asp:LinkButton>
                                </td>
                                <td align="center" style="display: none">
                                    <asp:TextBox ID="TextBox1" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity")%>' CssClass="txt_css" Width="30px" runat="server" OnTextChanged="txtxQuantity_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                <td align="center">
                                    <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ipid")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton3"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                </td>
                                <td align="center">

                                    <asp:LinkButton CommandName="ChangeHome" CommandArgument='<%#Eval("ipid")+"|"+Eval("Home")%>' runat="server" ID="Linkbutton6"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Home").ToString())%></asp:LinkButton>
                                </td>
                                <%--  <td align="center">
              <asp:LinkButton CommandName="ChangeNews"  CommandArgument='<%#Eval("ipid")+"|"+Eval("News")%>' Runat="server" ID="Linkbutton7"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "News").ToString())%></asp:LinkButton>
           </td>
          <td align="center">
              <asp:LinkButton CommandName="ChangeCheck_01"  CommandArgument='<%#Eval("ipid")+"|"+Eval("Check_01")%>' Runat="server" ID="Linkbutton8"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Check_01").ToString())%></asp:LinkButton>
           </td>
           <td align="center">
              <asp:LinkButton CommandName="ChangeCheck_02"  CommandArgument='<%#Eval("ipid")+"|"+Eval("Check_02")%>' Runat="server" ID="Linkbutton9"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Check_02").ToString())%></asp:LinkButton>
           </td>--%>


                                <td align="center">
                                    <%if (ShowSua == "1")
                                        {%>
                                    <asp:LinkButton ID="LinkButton1" CssClass="lnk" CommandName="update" CommandArgument='<%#Eval("ipid") %>' runat="server"> [<%=label("lt_edit")%>]</asp:LinkButton>

                                    <%} %>
                                </td>
                                <td align="center">
                                    <%if (ShowXoa == "1")
                                        {%>
                                    <div class="del">
                                        <asp:LinkButton CssClass="lnk" OnLoad="Delete_Load" CommandName="delete" CommandArgument='<%#Eval("ipid") %>' ID="LinkButton2" runat="server">[<%=label("ldelete")%>]</asp:LinkButton>
                                    </div>

                                    <%} %>
                                </td>

                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #fff" height="40">
                                <td align="center">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ipid") %>' runat="server" />
                                </td>
                                <td align="center">
                                    <div style="position: relative;">
                                        <span class="anhn"><%#MoreAll.MoreImage.Image(Eval("Images").ToString())%></span>
                                        <%#Hethang(Eval("Quantity").ToString())%>
                                    </div>
                                </td>
                                <td style="width: 350px">
                                    <b style="line-height: 18px"><a title="<%#Eval("Name")%>" target="_blank" href="/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html"><%#Eval("Name") %></a></b>
                                    <div style="height: 5px;"></div>
                                    <div style="color: #007734; font-weight: bold"><span style="color: red">Mã SP:</span> <%#Eval("Code")%></div>
                                    <div style="color: #007734; font-weight: bold"><span style="color: red">ID SP:</span> <span id="copyText"><%#Eval("ipid") %></span></div>
                                </td>
                                <td><%#MoreAll.MorePro.FormatMoney_Cart(Eval("Price").ToString())%>
                                </td>
                                <td align="center">
                                    <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date"))%>
                                    <%#MoreLisucapnhat(Eval("ipid").ToString())%>
                                    <div>
                                        <asp:LinkButton ID="LinkButton4" CssClass="lnk" CommandName="Chekdata" CommandArgument='<%#Eval("ipid") %>' runat="server"> <%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></asp:LinkButton>
                                    </div>
                                </td>
                                <td align="center">
                                    <%#DataBinder.Eval(Container.DataItem,"Views")%>
                                </td>
                                <td align="center">
                                    <div>
                                        <a class="btn" style="color: red; font-weight: bold" onclick="Show_TaiLieu('<%#Eval("ipid") %>','<%#Eval("Name") %>')">
                                            <img src="Resources/2025/ic2.jpg" style="width: 20px;" border="0" title="Tài liệu"></a>
                                    </div>
                                </td>
                                <td align="center">
                                    <div>
                                        <a class="btn2" style="color: red; font-weight: bold" onclick="Show_LienQuan('<%#Eval("ipid") %>','<%#Eval("Name") %>')">
                                            <img src="Resources/2025/lienket.png" style="width: 25px;" border="0" title="Liên quan"></a>
                                    </div>
                                </td>
                                <td align="center">
                                    <div>
                                        <a class="btn3" style="color: red; font-weight: bold" onclick="Show_SoSanh('<%#Eval("ipid") %>','<%#Eval("icid") %>','<%#Eval("Name") %>')">
                                            <img src="Resources/2025/sosanh.png" style="width: 20px;" border="0" title="So sánh"></a>
                                    </div>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="LinkButton7" CssClass="lnk" CommandName="updat_date" CommandArgument='<%#Eval("ipid") %>' runat="server"><img src="Resources/admin/images/refesh.png" border=0 title="Làm mới sản phẩm"></asp:LinkButton>
                                </td>
                                <td align="center" style="display: none">
                                    <asp:TextBox ID="TextBox1" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity")%>' CssClass="txt_css" Width="30px" runat="server" OnTextChanged="txtxQuantity_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                <td align="center">
                                    <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ipid")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton3"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                </td>
                                <td align="center">

                                    <asp:LinkButton CommandName="ChangeHome" CommandArgument='<%#Eval("ipid")+"|"+Eval("Home")%>' runat="server" ID="Linkbutton6"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Home").ToString())%></asp:LinkButton>
                                </td>
                                <%--  <td align="center">
              <asp:LinkButton CommandName="ChangeNews"  CommandArgument='<%#Eval("ipid")+"|"+Eval("News")%>' Runat="server" ID="Linkbutton7"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "News").ToString())%></asp:LinkButton>
           </td>
          <td align="center">
              <asp:LinkButton CommandName="ChangeCheck_01"  CommandArgument='<%#Eval("ipid")+"|"+Eval("Check_01")%>' Runat="server" ID="Linkbutton8"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Check_01").ToString())%></asp:LinkButton>
           </td>
           <td align="center">
              <asp:LinkButton CommandName="ChangeCheck_02"  CommandArgument='<%#Eval("ipid")+"|"+Eval("Check_02")%>' Runat="server" ID="Linkbutton9"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Check_02").ToString())%></asp:LinkButton>
           </td>--%>

                                <td align="center">
                                    <%if (ShowSua == "1")
                                        {%>
                                    <asp:LinkButton ID="LinkButton1" CssClass="lnk" CommandName="update" CommandArgument='<%#Eval("ipid") %>' runat="server"> [<%=label("lt_edit")%>]</asp:LinkButton>

                                    <%} %>
                                </td>
                                <td align="center">
                                    <%if (ShowXoa == "1")
                                        {%>
                                    <div class="del">
                                        <asp:LinkButton CssClass="lnk" OnLoad="Delete_Load" CommandName="delete" CommandArgument='<%#Eval("ipid") %>' ID="LinkButton2" runat="server">[<%=label("ldelete")%>]</asp:LinkButton>
                                    </div>

                                    <%} %>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <HeaderTemplate>
                            <table width="100%" cellpadding="10" cellspacing="0">
                                <tr style="background-color: #d5d1d1" height="40">
                                    <td class="header">
                                        <input id="Checkbox1" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
                                    <td class="header">Hình ảnh</td>
                                    <td class="header">Tên sản phẩm</td>
                                    <td class="header"><%=label("lprice")%></td>
                                    <td class="header"><%=label("l_createdate")%></td>
                                    <td class="header"><%=label("l_view")%></td>
                                    <td class="header">Tài liệu</td>
                                    <td class="header">PK Liên quan</td>
                                    <td class="header">So sánh</td>
                                    <td class="header">Làm mới</td>
                                    <%-- <td class="header">Số lượng</td>--%>
                                    <td class="header"><%=label("lt_display")%></td>
                                    <td class="header">Trang chủ</td>
                                    <%-- <td class="header">Mới</td>
                    <td class="header">Bchạy</td>
                    <td class="header">Ngừngb</td>--%>
                                    <td class="header">Hiệu chỉnh</td>
                                    <td class="header">Xóa</td>
                                </tr>
                        </HeaderTemplate>
                        <FooterTemplate>
                            </TABLE>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Label ID="lterr" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
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
                    <tr bgcolor="whitesmoke" height="25">
                        <td style="height: 25px">
                            <%if (ShowThem == "1")
                                {%>
                            <b>
                                <asp:LinkButton ID="lnkcreatenew" runat="server" Font-Bold="True" OnClick="lnkcreatenew_Click" CssClass="lnk">[<%=label("l_createnew")%>]</asp:LinkButton></b>
                            <%} %>

                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class='frm-add  adminsp'>
                    <asp:Label ID="lbl_msg" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>

                    <div class="container">
                        <div class="row">
                            <label>Danh mục chính:</label>
                            <asp:DropDownList ID="ddlcategoriesdetail" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcategoriesdetail_SelectedIndexChanged"></asp:DropDownList>

                            <label><span style="float: left; margin-left: 52px;">Danh mục con:</span></label>
                            <asp:DropDownList ID="ddlcategoriesdetail_Con" runat="server">
                            </asp:DropDownList>
                        </div>

                        <div class="row">
                            <label style="width: auto!important; float: left;">Tên sản phẩm:</label>
                            <div style="width: 87.4%!important; float: left;">
                                <asp:TextBox ID="txtname" runat="server" Style="width: 100% !important; margin-left: -11px;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <label>Mã sản phẩm:</label>
                            <asp:TextBox ID="txtcode" runat="server"></asp:TextBox>

                            <label><span style="float: left; margin-left: 65px;">Đơn vị tính:</span></label>
                            <asp:TextBox ID="txtdonvi" runat="server" ValidationGroup="lienhe"></asp:TextBox>
                        </div>

                        <div class="row">
                            <label>Thương hiệu:</label>
                            <asp:DropDownList ID="ddlThuongHieu" runat="server"></asp:DropDownList>

                            <label><span style="float: left; margin-left: 65px;">Model:</span></label>
                            <asp:TextBox ID="Model" runat="server" ValidationGroup="lienhe"></asp:TextBox>
                        </div>

                        <div class="row">
                            <label>Thời gian bảo hành:</label>
                            <asp:DropDownList ID="ddlThoiGianBaoHanh" runat="server"></asp:DropDownList>

                            <label><span style="float: left; margin-left: 65px;">Trọng lượng:</span></label>
                            <asp:TextBox ID="txttrongluong" runat="server" ValidationGroup="lienhe"></asp:TextBox>
                        </div>
                        <div class="row">
                            <label>Giá bán mới:</label>
                            <asp:TextBox ID="txtprice" runat="server">0</asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtprice"></cc1:FilteredTextBoxExtender>

                            <label><span style="float: left; margin-left: 65px;">Hóa đơn VAT:</span></label>

                            <asp:DropDownList ID="ddlHoaDonVAT" runat="server" CssClass="txt">
                                <asp:ListItem  Value="0">Không có VAT</asp:ListItem>
                                <asp:ListItem Selected="True" Value="8">VAT 8%</asp:ListItem>
                                <asp:ListItem Value="10">VAT 10%</asp:ListItem>
                            </asp:DropDownList>
                            <div style="display: none">
                                <asp:TextBox ID="txtoldprice" runat="server"></asp:TextBox></div>


                        </div>

                        <div class="row">
                            <label>Xuất xứ:</label>
                            <asp:DropDownList ID="XuatXu" runat="server">
                                <asp:ListItem Value="Chính hãng">Chính hãng</asp:ListItem>
                                <asp:ListItem Value="Đang cập nhật">Đang cập nhật</asp:ListItem>
                            </asp:DropDownList>


                            <label><span style="float: left; margin-left: 65px;">Trạng thái:</span></label>
                            <asp:DropDownList ID="TrangThaiHang" runat="server">
                                <asp:ListItem Value="Có sẵn">Có sẵn</asp:ListItem>
                                <asp:ListItem Value="Đặt hàng">Đặt hàng</asp:ListItem>
                            </asp:DropDownList>
                        </div>


                    </div>



                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr style="display: none">
                            <td style="height: 19px; width: 20%">Mầu</td>
                            <td></td>
                            <td>
                                <div class="Maunhe">
                                    <asp:CheckBoxList ID="cblcat" runat="server" RepeatColumns="10"></asp:CheckBoxList>
                                </div>
                            </td>
                            <td></td>
                        </tr>
                        <tr style="display: none">
                            <td style="height: 19px;">Kích thước</td>
                            <td></td>
                            <td>
                                <div class="Kthuoc">
                                    <asp:CheckBoxList ID="ckichthuoc" runat="server" RepeatColumns="10"></asp:CheckBoxList>
                                </div>
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td style="height: 19px; width: 163px;">Ảnh đại diện
                            </td>
                            <td style="height: 7px"></td>
                            <td style="height: 7px">
                                <div align="left" style="float: left; width: 700px">
                                    <asp:RadioButton ID="rdFromComputer" runat="server" CssClass="txt_css2" AutoPostBack="True" Checked="true" GroupName="FromType" OnCheckedChanged="rdFromComputer_CheckedChanged" Text="Từ máy tính của bạn" ValidationGroup="downloadtype" />
                                    <asp:RadioButton ID="rdFromLinks" runat="server" CssClass="txt_css2" AutoPostBack="True" GroupName="FromType" OnCheckedChanged="rdFromLinks_CheckedChanged" Text="Từ 1 liên kết" />&nbsp;&nbsp;
 <asp:Button ID="btDeleteimages" runat="server" Text="Delete" OnClick="btDeleteimages_Click" Width="75px" /><br />
                                    <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="vwFromComputer" runat="server">
                                            <asp:FileUpload CssClass="txt_css" ID="flimage" runat="server" Width="323px" />
                                        </asp:View>
                                        <asp:View ID="vwFromLinks" runat="server">
                                            <asp:TextBox CssClass="txt_css" ID="txtvimg" runat="server" Width="99%"></asp:TextBox><br />
                                        </asp:View>
                                    </asp:MultiView>
                                </div>
                                <div style="padding: 0px 0px 0px 0px">
                                    <div class="adaidien">
                                        <asp:Literal ID="ltimg" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </td>
                            <td style="height: 7px; font-size: 12pt; font-family: Times New Roman;"></td>
                        </tr>


                        <tr>
                            <td style="height: 19px; width: 139px;">Thêm nhiều ảnh
                            </td>
                            <td style="height: 7px"></td>
                            <td style="height: 7px">
                                <div>
                                    <asp:TextBox ID="txtMImage" runat="server" CssClass="text image"></asp:TextBox>
                                    <input id="btnBrowseImage" onclick="BrowseServerNew('<%=txtMImage.ClientID %>','Adv')" type="button" value="Browse Server" class="toolbar btns btn-info" />
                                    <input id="btndelall" onclick="delall();" type="button" value="Xóa tất cả" class="toolbar btns btn-info" />
                                </div>
                                <div style="clear: both"></div>
                                <ul id="container-img"></ul>
                            </td>
                            <td style="height: 7px; font-size: 12pt; font-family: Times New Roman;"></td>
                        </tr>



                        <tr>
                        <tr>
                            <td style="height: 19px;">
                                <%=label("l_productdesc")%>
                            </td>
                            <td style="height: 7px"></td>
                            <td style="height: 7px">
                                <CKEditor:CKEditorControl ID="txtdesc" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                            </td>
                            <td style="height: 7px; font-size: 12pt; font-family: Times New Roman;"></td>
                        </tr>
                        <tr>
                            <td style="height: 19px;">
                                <%=label("l_productcontent")%>
                            </td>
                            <td></td>
                            <td>
                                <CKEditor:CKEditorControl ID="txtcontent" runat="server" Height="300px"></CKEditor:CKEditorControl>
                            </td>
                            <td></td>
                        </tr>


                        <tr>
                            <td style="height: 19px;">Thẻ tag
                            </td>
                            <td style="height: 10px"></td>
                            <td style="height: 10px">
                                <asp:TextBox ID="txttang" runat="server" Width="593px" CssClass="txt_css"></asp:TextBox>
                            </td>
                            <td style="height: 10px"></td>
                        </tr>





                        <tr>
                            <td>Tính năng seo
                            </td>
                            <td style="height: 7px"></td>
                            <td style="height: 7px">
                            <td></td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td valign="top" colspan="3">
                                <div style="background: #f7f7f7; border: 1px solid #d7d7d7; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; width: 700px; margin-left: 0px">
                                    <table>

                                        <tr>
                                            <td valign="top"></td>
                                            <td valign="top">Tiêu đề từ khóa (Title)
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txttitleseo" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top"></td>
                                            <td valign="top">Từ khóa trang web (Meta)
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtmeta" CssClass="txt_css" runat="server" Width="392px" Height="35px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top"></td>
                                            <td valign="top">Từ khóa mô tả (Keyword)
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtKeywordS" CssClass="txt_css" runat="server" Width="459px" Height="43px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>


                        <tr>
                            <td>Thời gian</td>
                            <td></td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkdaytype" runat="server" Text="Hiển thị trong thời gian" AutoPostBack="True" OnCheckedChanged="chkdaytype_CheckedChanged" />
                                        <asp:Panel ID="pnadddate" Visible="false" runat="server">
                                            Ngày đăng tin
                <br />
                                            <asp:TextBox ID="txtfromday" runat="server" CssClass="txt" Height="22px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtfromday_CalendarExtender0" runat="server" TargetControlID="txtfromday"></cc1:CalendarExtender>
                                            tồn tại trong
                <asp:TextBox ID="txtindays" runat="server" CssClass="txt" Width="48px">365</asp:TextBox>
                                            ngày
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:CheckBox ID="CheckHome" CssClass="txt_css2" runat="server" Font-Bold="False" Text="Hiển thị lên trang chủ" /><br />
                                <asp:CheckBox ID="chkstatus" CssClass="txt_css2" runat="server" Checked="True" Text="Chọn: kích hoạt" Font-Bold="False" /><br />
                                <asp:CheckBox ID="Checknews" CssClass="txt_css2" runat="server" Font-Bold="False" Text="Sản phẩm Mới" /><br />
                                <asp:CheckBox ID="Check_02" CssClass="txt_css2" runat="server" Font-Bold="False" Text="Ngừng bán sản phẩm" /><br />
                                <asp:CheckBox ID="Check_03" CssClass="txt_css2" runat="server" Font-Bold="False" Text="Đã cập nhật đủ ảnh" /><br />
                                <asp:CheckBox ID="Check_04" CssClass="txt_css2" runat="server" Font-Bold="False" Text="Đã cập nhật nội dung" />


                                <asp:CheckBox ID="Check_05" Visible="false" CssClass="txt_css2" runat="server" Font-Bold="False" Text="Sản phẩm 5" />
                                <asp:CheckBox ID="Check_01" Visible="false" CssClass="txt_css2" runat="server" Font-Bold="False" Text="Sản phẩm bán chạy" />



                            </td>
                            <td></td>
                        </tr>



                        <tr>
                            <td style="height: 19px;">ID sản phẩm thay thế
                            </td>
                            <td style="height: 10px"></td>
                            <td style="height: 10px">
                                <asp:TextBox ID="LinkSPNgungBan" runat="server" Width="593px" CssClass="txt_css"></asp:TextBox>
                            </td>
                            <td style="height: 10px"></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:TextBox ID="txtquantity" runat="server" Visible="False" Width="14px"></asp:TextBox></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdinsertupdate" runat="server" Value="insert" />
                    <asp:HiddenField ID="hdid" runat="server" />
                    <asp:HiddenField ID="hdcid" runat="server" />
                    <asp:HiddenField ID="hdipid" runat="server" />
                    <asp:HiddenField ID="hdFileName" runat="server" />
                    <asp:HiddenField ID="hdimgsmall" runat="server" />
                    <asp:HiddenField ID="hdimgMax" runat="server" />
                    <asp:HiddenField ID="hdimgMaxEdit" runat="server" />
                    <asp:HiddenField ID="hdimgsmallEdit" runat="server" />

                </div>

                <div style="height: 20px;"></div>
                <div style="padding-left: 120px;">
                    <asp:Button ID="btnsave" ValidationGroup="lienhe" runat="server" Text="Lưu Thông tin" Width="160px" OnClick="Button2_Click" />
                    <asp:Button ID="btncancel" runat="server" Text="Thoát" OnClick="Button1_Click" Width="90px" />
                </div>
            </asp:View>
        </asp:MultiView>



    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnsave" />
    </Triggers>
</asp:UpdatePanel>


<style>
    .chucnang {
        border-bottom: 1px groove #dbdbdb;
        border-right: medium none !important;
    }

    .chucnangtd {
        border-right: medium none !important;
        font-size: 12px;
        border-bottom: 1px solid #fff;
        color: #fff !important
    }

    .label-sale {
        background: #ea2e49 none repeat scroll 0 0;
        color: #fff !important;
        display: block;
        padding: 5px 13px 6px;
        position: absolute;
        right: 0;
        text-align: center;
        text-decoration: none !important;
        top: 11px;
        transition: opacity 0.2s ease 0s;
        width: 50px;
        z-index: 999;
    }
</style>
<%--
<div class="my-rating5"></div>
<script>
    $(".my-rating5").starRating({
        initialRating: 4,
        strokeColor: '#894A00',
        strokeWidth: 10,
        starSize: 25,
         readOnly: true
    });
</script>
--%>


<script type="text/javascript">
    $('[id*=btnBrowseImage]').each(function () {
        $(this).click(function () {
            BrowseServerNew(<%=txtMImage.ClientID%>, '');
        });
    });
    $("#container-img").sortable({
        stop: function (event, ui) {
            $('#<%=txtMImage.ClientID%>').val(GetStringImg());
        }
    });
    function delall() {
        $("#container-img").html('');
        $('#<%=txtMImage.ClientID%>').val(GetStringImg());
    }
    function BrowseServerNew(functionData, startupPath) {

        var finder = new CKFinder();
        finder.basePath = '~/scripts/ckfinder/';
        finder.startupPath = startupPath;
        finder.selectActionFunction = SetFileFieldNew;
        finder.selectActionData = functionData;
        finder.popup();
    }
    function SetFileFieldNew(fileUrl, data, allFiles) {
        var str = "";
        var strimg = "";
        allFiles.forEach(function (item) {
            strimg += "<li class='ui-state-default'><div class='box-img'><a href='javascript:void(0)' onclick=\"delimg($(this),'" + data["selectActionData"] + "');\" class='btn-close'>x</a> <img src='" + item.url + "' /> </div></li>";
        })
        $("#container-img").html($("#container-img").html() + strimg);
        $("#container-img").sortable({
            stop: function (event, ui) {
                $('#<%=txtMImage.ClientID%>').val(GetStringImg());
            }
        });
        $("#container-img").disableSelection();
        $('#' + data["selectActionData"]).val(GetStringImg());
    }
    function LoadStringImg(strImg, inputimg) {
        var arr = strImg.split(',');
        var strimg = "";
        arr.forEach(function (item) {
            strimg += "<li class='ui-state-default'><div class='box-img'><a href='javascript:void(0)' onclick=\"delimg($(this),'" + inputimg + "');\" class='btn-close'>x</a> <img src='" + item + "' /> </div></li>";
        })
        $("#container-img").html($("#container-img").html() + strimg);
        $("#container-img").sortable({
            stop: function (event, ui) {
                $('#<%=txtMImage.ClientID%>').val(GetStringImg());
            }
        });
        $("#container-img").disableSelection();
        $('#<%=txtMImage.ClientID%>').val(GetStringImg());
    }
    function GetStringImg() {
        var str = "";
        $(".box-img img").each(function () {
            str += $(this).attr('src') + ',';
        })
        return str;
    }
    function delimg(img, inputimg) {
        img.parent().parent().remove();
        $('#' + inputimg).val(GetStringImg());
    }
</script>


<style>
    .adminsp .container {
        max-width: 100%;
    }



    .adminsp .row {
        display: flex;
        justify-content: space-between;
        align-items: center;
        gap: 10px;
        padding: 5px;
    }

        .adminsp .row label {
            flex: 0.6;
        }

        .adminsp .row input {
            flex: 2;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 3px;
            height: 20px;
        }

        .adminsp .row select {
            flex: 2;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 3px;
            height: 32px;
        }
    /* Ô nhập tên sản phẩm trải dài toàn form */
    .adminsp .full-width {
        display: flex;
        width: 100%;
    }

        .adminsp .full-width label {
            width: 15%;
        }

        .adminsp .full-width input {
            width: 85%;
        }

    .adminsp .file-upload {
        flex: 2;
    }

        .adminsp .file-upload input[type="file"] {
            margin-top: 5px;
        }

    .adminsp button {
        padding: 5px 10px;
        border: none;
        border-radius: 3px;
        cursor: pointer;
        font-weight: bold;
    }

    .adminsp .delete-btn {
        background: red;
        color: white;
    }

    .adminsp .browse-btn {
        background: blue;
        color: white;
    }

    .adminsp .clear-btn {
        background: gray;
        color: white;
    }
</style>



<asp:Label ID="listItems" runat="server"></asp:Label>


<script>
    $(document).ready(function () {
        var modal = $('.modal');
        var btn = $('.btn');
        var span = $('.close');

        btn.click(function () {
            modal.show();
        });

        span.click(function () {
            modal.hide();
        });

        $(window).on('click', function (e) {
            if ($(e.target).is('.modal')) {
                modal.hide();
            }
        });
    });
    function Show_TaiLieu(ID, NamePro) {
        $('#ID').val(ID);
        $('#NamePro').html(NamePro);
        $.ajax({
            type: "POST",
            url: '/index.aspx/Get_TaiLieu',
            data: JSON.stringify({ id: ID }),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: "true",
            success: function (response) {
                $("#table_PriceMulti tbody").empty();
                $("#table_PriceMulti tbody").append(response.d);
                js_add_Price();
            },
            error: function (response) {
                // alert("222");
            },
            beforeSend: function () {
                //   alert("33");
            },
            complete: function () {
                // alert("44");
            }
        });
    }
</script>



<div class="modal">
    <div class="modal-content">
        <div class="PopUp">
            <div class="col-md-5  ShowInPut">
                <div style="font-size: 17px; padding-bottom: 9px;"><b>Tên sản phẩm :</b> <span id="NamePro" style="color: red; font-weight: bold"></span></div>
                <table class="table table-bordered" cellpadding="5" cellspacing="0" id="table_PriceMulti">
                    <thead>
                        <tr style="background: #c4c4c4; font-weight: bold; text-align: center">
                            <td>LOẠI TÀI LIỆU - PHẦN MỀM</td>
                            <td>LINK TÀI LIỆU - PHẦN MỀM</td>
                            <td style="text-align: center">Thêm</td>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div class="col-md-12  ShowInPut">
                <div style="padding-top: 2px">
                    <a href="#" onclick="Save_Tailieu_Sanphams()" class="btn_Gui" style="margin-right: 0px;">Lưu lại</a>
                    <a href="#" class="close btn_Gui">Đóng </a>
                </div>
            </div>
        </div>
    </div>
</div>


<script>
    $(document).ready(function () {

        $('.btn2').click(function () {
            $('.modal2').show();
        });

        $('.close2').click(function () {
            $('.modal2').hide();
        });

        $(window).on('click', function (e) {
            if ($(e.target).is('.modal2')) {
                $('.modal2').hide();
            }
        });
    });
    function Show_LienQuan(ID, NamePro) {
        $('#ID').val(ID);
        $('#NamePro2').html(NamePro);

        $.ajax({
            type: "POST",
            url: '/index.aspx/Get_lienquan',
            data: JSON.stringify({ id: ID }),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: "true",
            success: function (response) {
                $("#table_LienQuan tbody").empty();
                $("#table_LienQuan tbody").append(response.d);
                js_add_lienquan();
            },
            error: function (response) {
                // alert("222");
            },
            beforeSend: function () {
                //   alert("33");
            },
            complete: function () {
                // alert("44");
            }
        });
    }
</script>


<div class="modal2">
    <div class="modal-content">
        <div class="PopUp2">
            <div class="col-md-9  ShowInPut">
                <div style="font-size: 17px; padding-bottom: 9px;"><b>Tên sản phẩm :</b> <span id="NamePro2" style="color: red; font-weight: bold"></span></div>
                <table class="table table-bordered" cellpadding="5" cellspacing="0" id="table_LienQuan">
                    <thead>
                        <tr style="background: #c4c4c4; font-weight: bold;">
                            <td style="text-align: center; font-size: 15px; font-weight: bold">ID sản phẩm liên quan</td>
                            <td style="text-align: center; font-size: 15px; font-weight: bold">Thêm</td>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div class="col-md-12  ShowInPut">
                <div style="padding-top: 2px">
                    <a href="#" onclick="Save_lienquan_Sanpham()" class="btn_Gui" style="margin-right: 0px;">Lưu lại</a>
                    <a href="#" class="close2 btn_Gui">Đóng </a>
                </div>
            </div>
        </div>
    </div>
</div>



<script>
    $(document).ready(function () {
        var modal = $('.modal3');
        var btn = $('.btn3');
        var span = $('.close3');

        btn.click(function () {
            modal.show();
        });

        span.click(function () {
            modal.hide();
        });

        $(window).on('click', function (e) {
            if ($(e.target).is('.modal3')) {
                modal.hide();
            }
        });
    });

    function Show_SoSanh(ID, icid, NamePro) {
        $('#ID').val(ID);
        $('#icid').val(icid);
        $('#NamePro3').html(NamePro);

        $.ajax({
            type: "POST",
            url: '/index.aspx/Get_SoSanh',
            data: JSON.stringify({ id: ID, icid: icid }),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: "true",
            success: function (response) {
                $("#table_SoSanhMulti tbody").empty();
                $("#table_SoSanhMulti tbody").append(response.d);
            },
            error: function (response) {
                // alert("222");
            },
            beforeSend: function () {
                //   alert("33");
            },
            complete: function () {
                // alert("44");
            }
        });
    }
</script>
<div class="modal3">
    <div class="modal-content">
        <div class="PopUp3">
            <div class="col-md-9 ShowInPut">
                <div style="font-size: 17px; padding-bottom: 9px;">
                    <b>Tên sản phẩm :</b>
                    <span id="NamePro3" style="color: red; font-weight: bold"></span>
                </div>

                <div class="table-container">
                    <table class="table table-bordered" id="table_SoSanhMulti">
                        <%--<thead>
                            <tr>
                                <td style="text-align: center;font-size: 15px;font-weight:bold">Thuộc tính</td>
                                <td style="text-align: center;font-size: 15px;font-weight:bold">Nội dung</td>
                                <td style="text-align: center;font-size: 15px;font-weight:bold">Thêm</td>
                            </tr>
                        </thead>--%>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="col-md-12 ShowInPut">
                <div style="padding-top: 2px">
                    <a href="#" onclick="Save_SoSanh_Sanphams()" class="btn_Gui">Lưu lại</a>
                    <a href="#" class="close3 btn_Gui">Đóng</a>
                </div>
            </div>
        </div>
    </div>
</div>

<script src="/Resources/2025/SoSanh_admin.js"></script>
<script src="/Resources/2025/SPLienQuan_admin.js"></script>
<script src="/Resources/2025/ThemGia_admin.js"></script>
<input value="0" type="hidden" name="ID" id="ID">
<input value="0" type="hidden" name="icid" id="icid">

<script>
    function copyText() {
        const textElement = document.getElementById("copyText").innerText; // Lấy nội dung trong div
        const textarea = document.createElement("textarea"); // Tạo thẻ textarea ẩn
        textarea.value = textElement;
        document.body.appendChild(textarea);
        textarea.select();
        document.execCommand("copy"); // Thực hiện copy
        document.body.removeChild(textarea); // Xóa textarea sau khi copy

        // Hiển thị thông báo copy thành công
        const message = document.getElementById("message");
        message.innerText = "Copy thành công!";
        setTimeout(() => {
            message.innerText = "";
        }, 2000); // Ẩn thông báo sau 2 giây
    }
</script>

<%--  <style>
        #copyText {
            display: inline-block;
            padding: 10px;
            background: #f3f3f3;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 20px;
            margin-bottom: 10px;
        }

        .nutcopy_button {
            background: #008CBA;
            color: white;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            font-size: 16px;
            border-radius: 5px;
        }

        .nutcopy_button:hover {
            background: #005f7f;
        }
        #message {
            color: green;
            margin-top: 10px;
            font-weight: bold;
        }
    </style>--%>



<style>
    .modal {
        display: none;
        position: fixed;
        z-index: 1;
        padding-top: 100px;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        overflow: auto;
        background-color: rgb(0, 0, 0);
        background-color: rgba(0, 0, 0, .4);
    }

    .modal2 {
        display: none;
        position: fixed;
        z-index: 1;
        padding-top: 100px;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        overflow: auto;
        background-color: rgb(0, 0, 0);
        background-color: rgba(0, 0, 0, .4);
    }

    .modal3 {
        display: none;
        position: fixed;
        z-index: 1;
        padding-top: 15px;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        overflow: auto;
        background-color: rgb(0, 0, 0);
        background-color: rgba(0, 0, 0, .4);
    }

    .modal-content {
        background-color: #fefefe;
        margin: auto;
        padding: 9px;
        border: 1px solid #888;
        width: 50%;
        border-radius: 5px;
        padding-bottom: 51px;
    }

    .close:hover,
    .close:focus {
        cursor: pointer;
    }

    .close2:hover,
    .close2:focus {
        cursor: pointer;
    }

    .close3:hover,
    .close3:focus {
        cursor: pointer;
    }

    .PopUp .table > thead > tr > th {
        background: #C4C4C4;
        font-size: 12px !important;
        text-align: left;
        vertical-align: top !important;
    }

    .PopUp2 .table > thead > tr > th {
        background: #C4C4C4;
        font-size: 12px !important;
        text-align: left;
        vertical-align: top !important;
    }

    .PopUp3 .table > thead > tr > th {
        background: #C4C4C4;
        font-size: 12px !important;
        text-align: left;
        vertical-align: top !important;
    }

    .PopUp .form-control {
        font-size: 13px;
        color: #59595B;
        border-radius: 0px;
        border: 1px solid #d0cbcb;
        height: 29px;
        text-align: left;
        padding: 0px;
        padding-left: 6px;
        font-weight: bold
    }

    .PopUp2 .form-control {
        font-size: 13px;
        color: #59595B;
        border-radius: 0px;
        border: 1px solid #d0cbcb;
        height: 29px;
        text-align: left;
        padding: 0px;
        padding-left: 6px;
        font-weight: bold
    }

    .PopUp3 .form-control {
        font-size: 13px;
        color: #59595B;
        border-radius: 0px;
        border: 1px solid #d0cbcb;
        height: 32px;
        text-align: left;
        padding: 0px;
        padding-left: 6px;
    }

    [name='TieuDe'] {
        font-weight: bold;
    }

    table#table_PriceMulti {
        border: 1px solid #d7d7d7;
        background: #f1eeee;
    }

    table#table_LienQuan {
        border: 1px solid #d7d7d7;
        background: #f1eeee;
    }

    .PopUp td {
        border: 1px solid #d7d7d7;
    }

    .btn_Gui {
        background-color: #868686;
        color: #fff !important;
        padding: 6px 7px;
        margin-top: 2px;
        width: 120px;
        text-align: center;
        float: right;
        margin: 10px;
    }

    span.TieuDeCha {
        color: #ee373a;
        font-size: 18px;
        font-weight: bold;
    }

    .table-container {
        max-height: 650px; /* Giới hạn chiều cao bảng */
        overflow-y: auto; /* Bật thanh cuộn dọc */
        border: 1px solid #ddd;
    }


    #table_SoSanhMulti {
        width: 99%;
        border-collapse: collapse;
    }

        #table_SoSanhMulti thead {
            display: table;
            width: 100%;
            table-layout: fixed;
        }

        #table_SoSanhMulti td, #table_SoSanhMulti th {
            padding: 4px;
            border: 1px solid #ddd;
            text-align: left;
            width: 33.33%; /* Chia đều cột */
        }


        #table_SoSanhMulti tbody tr {
            display: table;
            width: 100%;
            table-layout: fixed;
        }
</style>
