<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GioiThieu.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.GioiThieu.GioiThieu" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div class="frm_search">
                    <div>
                        <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
                        <asp:LinkButton ID="lnksearch" runat="server" OnClick="lnksearch_Click"><img src="/Resources/admin/images/btt_search.png" border=0 /></asp:LinkButton>
                    </div>
                    <div style="margin-top: 10px;">
                        <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" CssClass="txt"
                            Width="125px" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="True">Tất cả các mục</asp:ListItem>
                            <asp:ListItem Value="1">Hiển thị</asp:ListItem>
                            <asp:ListItem Value="0">Ẩn</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlorderby" runat="server" AutoPostBack="true" CssClass="txt"
                            OnSelectedIndexChanged="ddlorderby_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Create_Date">S.xếp:Ngày cập nhật</asp:ListItem>
                            <asp:ListItem Value="Modified_Date">S.xếp:Ngày hết hạn</asp:ListItem>
                            <asp:ListItem Value="Views">S.xếp:Lần xem</asp:ListItem>
                            <asp:ListItem Value="Title">S.xếp:Tiêu đề (ABC)</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlordertype" runat="server" AutoPostBack="True" CssClass="txt"
                            OnSelectedIndexChanged="ddlordertype_SelectedIndexChanged">
                            <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                            <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="bthienthi" runat="server" Text="Hiển thị" OnClick="bthienthi_Click"
                            Width="70px" />
                        <%if (ShowThem == "1")
                            {%>
                        <asp:Button ID="btthemmoi" runat="server" Text="Thêm mới" OnClick="btthemmoi_Click" Width="91px" />
                        <%} %>
                        <%if (ShowXoa == "1")
                            {%>
                        <asp:Button ID="btDeleteall" ToolTip="Xóa những lựa chọn !" OnClientClick=" return confirmDelete(this);" runat="server" Text="Xóa" OnClick="btDeleteall_Click" Width="34px" />
                        <%} %>
                    </div>
                </div>
                <div class="list_item">
                    <asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
                        <ItemTemplate>
                            <tr style="background-color: #f1f1f1" height="45">
                                <td align="center">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                        ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                </td>
                                <td>
                                    <b>
                                        <%#Eval("Title")%></b>
                                </td>
                                <td align="center">
                                    <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date"))%>
                                    <div>
                                        <asp:LinkButton ID="LinkButton5" CssClass="lnk" CommandName="Chekdata" CommandArgument='<%#Eval("ID") %>'
                                            runat="server"> <%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></asp:LinkButton>
                                    </div>
                                </td>
                                <td align="center">
                                    <%#DataBinder.Eval(Container.DataItem,"Views")%>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="LinkButton1" CssClass="lnk" CommandName="updat_date" CommandArgument='<%#Eval("ID") %>'
                                        runat="server"><img src="/Resources/admin/images/refesh.png" border=0></asp:LinkButton>
                                </td>
                                <td align="center">
                                    <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                        runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                </td>
                                <td align="center"><%if (ShowSua == "1")
                                                       {%>
                                    <asp:LinkButton ID="LinkButton2" CssClass="lnk" CommandName="EditDetail" CommandArgument='<%#Eval("ID") %>'
                                        runat="server">[ <%=label("lt_edit")%>]</asp:LinkButton>
                                    <%} %>
                                </td>
                                <td align="center">
                                    <%if (ShowXoa == "1")
                                        {%>
                                    <div class="del">
                                        <asp:LinkButton CssClass="lnk" ID="LinkButton3" OnLoad="Delete_Load" CommandName="Delete"
                                            CommandArgument='<%#Eval("ID") %>' runat="server">[<%=label("ldelete")%>]</asp:LinkButton>
                                    </div>
                                    <%} %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #ffff" height="45">
                                <td align="center">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                        ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                </td>
                                <td>
                                    <b>
                                        <%#Eval("Title")%></b>
                                </td>
                                <td align="center">
                                    <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Create_Date"))%>
                                    <div>
                                        <asp:LinkButton ID="LinkButton5" CssClass="lnk" CommandName="Chekdata" CommandArgument='<%#Eval("ID") %>'
                                            runat="server"> <%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></asp:LinkButton>
                                    </div>
                                </td>
                                <td align="center">
                                    <%#DataBinder.Eval(Container.DataItem,"Views")%>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="LinkButton1" CssClass="lnk" CommandName="updat_date" CommandArgument='<%#Eval("ID") %>'
                                        runat="server"><img src="/Resources/admin/images/refesh.png" border=0></asp:LinkButton>
                                </td>
                                <td align="center">
                                    <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                        runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                </td>
                                <td align="center"><%if (ShowSua == "1")
                                                       {%>
                                    <asp:LinkButton ID="LinkButton2" CssClass="lnk" CommandName="EditDetail" CommandArgument='<%#Eval("ID") %>'
                                        runat="server">[ <%=label("lt_edit")%>]</asp:LinkButton>
                                    <%} %>
                                </td>
                                <td align="center">
                                    <%if (ShowXoa == "1")
                                        {%>
                                    <div class="del">
                                        <asp:LinkButton CssClass="lnk" ID="LinkButton3" OnLoad="Delete_Load" CommandName="Delete"
                                            CommandArgument='<%#Eval("ID") %>' runat="server">[<%=label("ldelete")%>]</asp:LinkButton>
                                    </div>
                                    <%} %>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <HeaderTemplate>
                            <table width="100%" cellpadding="10" cellspacing="0">
                                <tr>
                                    <td class="header">
                                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" />
                                    </td>
                                    <td class="header">
                                        <%=label("answers_title")%>
                                    </td>
                                    <td class="header">
                                        <%=label("l_createdate")%>
                                    </td>
                                    <td class="header">
                                        <%=label("l_view")%>
                                    </td>
                                    <td class="header">Làm mới
                                    </td>
                                    <td class="header">
                                        <%=label("lt_display")%>
                                    </td>
                                    <td class="header">Hiệu chỉnh
                                    </td>
                                    <td class="header">Xóa
                                    </td>
                                </tr>
                        </HeaderTemplate>
                    </asp:Repeater>
                </div>
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <tr height="20">
                        <td align="center">
                            <div class="phantrang">
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
                    <tr bgcolor="whitesmoke" height="25">
                        <td style="height: 25px">
                            <%if (ShowThem == "1")
                                {%>
                            <b>
                                <asp:LinkButton ID="lnkcreatenew" runat="server" CssClass="lnk" Font-Bold="True" OnClick="lnkcreatenew_Click">[<%=label("l_createnew")%>]</asp:LinkButton></b>
                            <%} %>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class='frm-add'>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td></td>
                            <td style="width: 110px"></td>
                            <td></td>
                            <td>
                                <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <%=label("answers_title")%>
                            </td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="txtname" runat="server" CssClass="txt_css" Width="99%"></asp:TextBox>
                            </td>
                        </tr>

                        <tr style="display: none">
                            <td valign="top"></td>
                            <td valign="top">Ảnh
                            </td>
                            <td></td>
                            <td>
                                <div>
                                    <div align="left" style="float: left; width: 700px">
                                        <asp:RadioButton ID="rdFromComputer" runat="server" CssClass="txt_css2" AutoPostBack="True" Checked="true" GroupName="FromType" OnCheckedChanged="rdFromComputer_CheckedChanged" Text="Từ máy tính của bạn" ValidationGroup="downloadtype" />
                                        <asp:RadioButton ID="rdFromLinks" runat="server" CssClass="txt_css2" AutoPostBack="True" GroupName="FromType" OnCheckedChanged="rdFromLinks_CheckedChanged" Text="Từ 1 liên kết" />&nbsp;&nbsp;
                                        <asp:Button ID="btDeleteimages" CssClass="txt_css" runat="server" Text="Delete" OnClick="btDeleteimages_Click" Width="75px" /><br />
                                        <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="vwFromComputer" runat="server">
                                                <asp:FileUpload ID="flimage" runat="server" Width="323px" />
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
                                </div>
                            </td>
                        </tr>

                        <tr style="display: none">
                            <td valign="top"></td>
                            <td valign="top">Mô tả
                            </td>
                            <td></td>
                            <td>
                                <CKEditor:CKEditorControl ID="txtdesc" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td valign="top">
                                <%=label("l_content")%>
                            </td>
                            <td></td>
                            <td>
                                <CKEditor:CKEditorControl ID="txtcontent" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <asp:TextBox Visible="false" ID="txttags" runat="server" CssClass="txt_css" Width="99%"></asp:TextBox>
                        <tr>
                            <td></td>
                            <td>Thời gian
                            </td>
                            <td></td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkdaytype" runat="server" Text="Hiển thị trong thời gian" AutoPostBack="True"
                                            OnCheckedChanged="chkdaytype_CheckedChanged" />
                                        <asp:Panel ID="pnadddate" Visible="false" runat="server">
                                            Ngày đăng tin
                                            <br />
                                            <asp:TextBox ID="txtfromday" runat="server" CssClass="txt" Height="22px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtfromday_CalendarExtender0" runat="server" TargetControlID="txtfromday">
                                            </cc1:CalendarExtender>
                                            tồn tại trong
                                            <asp:TextBox ID="txtindays" runat="server" CssClass="txt" Width="48px">365</asp:TextBox>
                                            ngày
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td valign="top">Tính năng seo
                            </td>
                            <td></td>
                            <td></td>
                        </tr>


                        <tr>
                            <td valign="top"></td>
                            <td valign="top" colspan="3">
                                <div style="background: #f7f7f7; border: 1px solid #d7d7d7; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; width: 700px; margin-left: 110px">
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
                            <td></td>
                            <td>
                                <%=label("l_option")%>
                            </td>
                            <td></td>
                            <td>
                                <asp:CheckBox ID="chkstatus" runat="server" Visible="True" CssClass="txt_css2" Text="Chọn: kích hoạt"></asp:CheckBox>
                                <asp:CheckBox ID="chknews" Visible="false" runat="server" CssClass="txt_css2" Text="Trang chủ - giới thiệu" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="padding-left: 100px; padding-top: 10px;">
                    <asp:Button ID="btnsave" runat="server" Text="Thêm - hiệu chỉnh" OnClick="btnsave_Click" Width="122px" />
                    <asp:Button ID="btncancel" runat="server" Text="Hủy bỏ" OnClick="btncancel_Click" Width="93px" />
                </div>


                <asp:TextBox ID="txtauthor" CssClass="txt_css" runat="server" Width="16%" Visible="False"></asp:TextBox>
                <asp:HiddenField ID="hdinsertupdate" runat="server" Value="insert" />
                <asp:HiddenField ID="hdid" runat="server" />
                <asp:HiddenField ID="hdimg" runat="server" />
                <asp:HiddenField ID="hdcid" runat="server" />
                <asp:HiddenField ID="hdino" runat="server" />
                <asp:HiddenField ID="hd_id" runat="server" />
                <asp:HiddenField ID="hdFileName" runat="server" />
            </asp:View>


        </asp:MultiView>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnsave" />
    </Triggers>
</asp:UpdatePanel>
