<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_menu_mainheader.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Menus.u_menu_mainheader" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<div style="margin-top: 10px;">
    <asp:Literal ID="lt_info" runat="server"></asp:Literal>
</div>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="viwList" runat="server">
                <asp:Panel ID="pn_list" runat="server" Width="100%">
                 <div class="frm_search">
                    <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                        <tr>
                            <td>
                                <asp:LinkButton ID="btn_Homepage" class="root" OnClick="btn_Homepage_Click" runat="server">Top Menu</asp:LinkButton>
                                <asp:Literal ID="lbl_curpage" runat="server"></asp:Literal>
                                <div class="menun"><asp:Literal ID="lbl_cur" runat="server"></asp:Literal></div>
                                <asp:Literal ID="ltmsg" runat="server"></asp:Literal>
                            </td>
                            <td class="topcontent" style="width: 50%">
                                &nbsp;<asp:Button ID="btthemmoi1" runat="server" ForeColor="Green" Text="Thêm mới"
                                    Width="87px" OnClick="btthemmoi1_Click" />
                                <asp:Button ID="btn_Homepage1" runat="server" Text="Root Cate" Width="92px" ForeColor="Green"
                                    OnClick="btn_Homepage1_Click" />
                                <asp:Button ID="btn1_back" runat="server" Text="<<< Back" Width="96px" ForeColor="Green"
                                    OnClick="btn1_back_Click" />
                                <asp:Button ID="btxoa2" runat="server" OnClick="btxoa2_Click" OnClientClick=" return confirmDelete(this);"
                                    Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="35px" ForeColor="Green" />
                            </td>
                        </tr>
                    </table>
                </div>
                    <div class="list_item">
                        <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                            <ItemTemplate>
                                <tr style="background-color: #f1f1f1" height="40">
                                    <td align="center">
                                        <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                            ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                    </td>
                                    <td style="padding-left: 10px">
                                        <b>
                                            <asp:LinkButton CommandName="ListChildren" CommandArgument='<%#Eval("ID")%>' runat="server"
                                                ID="Linkbutton7"><%#Eval("Name")%></asp:LinkButton></b><br>
                                        URL:<i><%#Eval("link")%></i></td>
                                    <td align="center">
                                        <%#TypeMenu(Eval("Type").ToString(), Eval("Styleshow").ToString())%>
                                    </td>
                                    <td align="center">
                                        <%#TypeMenu_Styleshow(Eval("Type").ToString(), Eval("Styleshow").ToString())%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                            runat="server" ID="Linkbutton8"><%#MoreAll.MoreAll.Enable(Eval("Status").ToString())%></asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="moveup" CommandArgument='<%#Eval("ID") %>'>[<%=label("l_up")%>]</asp:LinkButton>
                                        <%#Eval("Orders")%>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="movedown" CommandArgument='<%#Eval("ID") %>'>[<%=label("l_down")%>]</asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton2" CommandName="EditContent" CommandArgument='<%#Eval("ID")%>'
                                            Visible='<%#EnableButtonContent(Eval("Type").ToString()) %>' runat="server">[Nội dung]</asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton4" CommandName="EditDetail" CommandArgument='<%#Eval("ID")%>'
                                            runat="server">[<%=label("lt_edit")%>]</asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <div class="del">
                                            <asp:LinkButton CommandName="Delete" CommandArgument='<%#Eval("ID")%>' runat="server"
                                                ID="Linkbutton5" OnLoad="Delete_Load">[<%=label("ldelete")%>]</asp:LinkButton></div>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr style="background-color: #ffff" height="40">
                                    <td align="center">
                                        <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                            ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                    </td>
                                    <td style="padding-left: 10px">
                                        <b>
                                            <asp:LinkButton CommandName="ListChildren" CommandArgument='<%#Eval("ID")%>' runat="server"
                                                ID="Linkbutton7"><%#Eval("Name")%></asp:LinkButton></b><br>
                                        URL:<i><%#Eval("link")%></i></td>
                                    <td align="center">
                                        <%#TypeMenu(Eval("Type").ToString(), Eval("Styleshow").ToString())%>
                                    </td>
                                    <td align="center">
                                        <%#TypeMenu_Styleshow(Eval("Type").ToString(), Eval("Styleshow").ToString())%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                            runat="server" ID="Linkbutton8"><%#MoreAll.MoreAll.Enable(Eval("Status").ToString())%></asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="moveup" CommandArgument='<%#Eval("ID") %>'>[<%=label("l_up")%>]</asp:LinkButton>
                                        <%#Eval("Orders")%>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="movedown" CommandArgument='<%#Eval("ID") %>'>[<%=label("l_down")%>]</asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton2" CommandName="EditContent" CommandArgument='<%#Eval("ID")%>'
                                            Visible='<%#EnableButtonContent(Eval("Type").ToString()) %>' runat="server">[Nội dung]</asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton4" CommandName="EditDetail" CommandArgument='<%#Eval("ID")%>'
                                            runat="server">[<%=label("lt_edit")%>]</asp:LinkButton>
                                    </td>
                                    <td align="center">
                                        <div class="del">
                                            <asp:LinkButton CommandName="Delete" CommandArgument='<%#Eval("ID")%>' runat="server"
                                                ID="Linkbutton5" OnLoad="Delete_Load">[<%=label("ldelete")%>]</asp:LinkButton></div>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <HeaderTemplate>
                                <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                    <tr bgcolor="#C4C4C4" height="22">
                                        <td class="header">
                                            <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" />
                                        </td>
                                        <td class="header">
                                            <%=label("admin_title")%>
                                        </td>
                                        <td class="header">
                                            Kiểu
                                        </td>
                                        <td class="header">
                                            Kiểu Nội dung
                                        </td>
                                        <td class="header">
                                            <%=label("l_status")%>
                                        </td>
                                        <td class="header">
                                            <%=label("lt_order")%>
                                        </td>
                                        <td class="header">
                                            Nội dung
                                        </td>
                                        <td class="header">
                                            <%=label("lt_edit")%>
                                        </td>
                                        <td class="header">
                                            <%=label("ldelete")%>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <SeparatorTemplate>
                                <tr>
                                    <td bgcolor="#ffffff" colspan="9" height="1">
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#30a72f" colspan="9" height="1">
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#ffffff" colspan="9" height="1">
                                    </td>
                                </tr>
                            </SeparatorTemplate>
                            <FooterTemplate>
                                </TABLE>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div style="height: 20px">
                    </div>
                    <div style="height: 25px; line-height: 25px; font-weight: bold; background-color: WhiteSmoke;
                        padding-left: 5px;">
                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">[<%=label("l_createnewmenu")%>]</asp:LinkButton>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pn_insert" runat="server" Visible="False" Width="100%">
                    <div class='frm-add'>
                        <div>
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></div>
                        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                    <asp:RadioButton ID="rdcontentmenu" runat="server" GroupName="linktype" AutoPostBack="True"
                                        OnCheckedChanged="rdcontentmenu_CheckedChanged" />
                                    <asp:RadioButton ID="rdlinkmenu" runat="server" Checked="True" GroupName="linktype"
                                        AutoPostBack="True" OnCheckedChanged="rdlinkmenu_CheckedChanged" />
                                    <asp:RadioButton ID="rdmodulelink" runat="server" GroupName="linktype" AutoPostBack="True"
                                        OnCheckedChanged="rdmodulelink_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>
                                        <%=label("admin_title")%>
                                    </b>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_title" runat="server" Width="316px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>
                                        <asp:Literal ID="lturl" runat="server" Text="URL"></asp:Literal></b>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txturl" runat="server" Width="316px" Visible="False"></asp:TextBox>
                                    <asp:DropDownList ID="ddlmodulelinks" runat="server" Visible="False" Width="192px">
                                        <asp:ListItem Value="/">Trang chủ</asp:ListItem>
                                        <asp:ListItem Value="tin-tuc.html">Tin tức</asp:ListItem>
                                        <asp:ListItem Value="san-pham.html">Sản phẩm</asp:ListItem>
                             <%--           <asp:ListItem Value="tai-du-lieu.html">Thư viện tài liệu</asp:ListItem>
                                        <asp:ListItem Value="thu-vien-video.html">Thư viện Video</asp:ListItem>
                                        <asp:ListItem Value="thu-vien-anh.html">Thư viện Album</asp:ListItem>--%>
                                        <asp:ListItem Value="lien-he.html">Liên hệ</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    <b>
                                        <asp:Literal ID="ltcontentpagestype" runat="server" Text="Kiểu trang nội dung hiển thị"
                                            Visible="False"></asp:Literal>
                                    </b>
                                </td>
                                <td style="height: 20px">
                                </td>
                                <td style="line-height: 25px">
                                    <asp:Panel ID="Panelrdlis" runat="server">
                                    <asp:RadioButton ID="rdseperatepages" runat="server" GroupName="contentpagetype"
                                            Text="Hiển thị ra tiêu đề và các tin khác" Visible="False" /><span style="font-size: 10pt;
                                                color: #ff3a00"><em> (Hiển thị ra tiêu đề và các tin khác)</em></span>
                                        <br />
                                        <asp:RadioButton ID="rdlistcontentpages" runat="server" Checked="True" GroupName="contentpagetype"
                                            Text="Hiển thị theo tiêu đề" Visible="False" />
                                        <span style="font-size: 10pt; color: #ff3a00"><em> (Hiển thị ra 1 danh sách tiêu đề tin)</em></span>
                                        <br />
                                        <asp:RadioButton ID="rdinsamepage" runat="server" GroupName="contentpagetype" Text="Hiển thị trên cùng một trang"
                                            Visible="False" /><span style="font-size: 10pt; color: #ff3a00"><em> (Hiển thị ra tiêu
                                                đề và chi tiết Ví dụ: áp dụng cho faq)</em></span>
                                        <br />
                                        
                                        <asp:RadioButton ID="rdinsamepageCollapPanel" runat="server" GroupName="contentpagetype"
                                            Text="Hiển thị trên cùng một trang - Collap" Visible="False" /><span style="font-size: 10pt;
                                                color: #ff3a00"><em> (Hiển thị ra tiêu đề và chi tiết Ví dụ: áp dụng cho faq)</em></span>
                                        <br />
                                        <asp:RadioButton ID="rdinLisnews" runat="server" GroupName="contentpagetype" Text="Hiển thị danh theo danh sách tin(List tin)"
                                            Visible="False" /><span style="font-size: 10pt; color: #ff3a00"><em> (Hiển thị List danh
                                                sách tin)</em></span>
                                        <br />
                                       <span style=" display:none"> <asp:CheckBox ID="chkenablechildcate" Visible=false runat="server" Text="Hiển thị danh mục con"/></span>
                                       </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px" align="right">
                                    <b>
                                        <%=label("lt_order")%>
                                    </b>
                                </td>
                                <td style="height: 18px">
                                </td>
                                <td style="height: 18px">
                                    <asp:TextBox ID="txt_order" runat="server" Width="32px">1</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>
                                        <%=label("lt_enable")%>
                                    </b>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chck_Enable" runat="server" Visible="True"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong></strong>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btn_InsertUpdate" runat="server" OnClick="btn_InsertUpdate_Click"
                                        Width="120px" />
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Width="56px" />
                                </td>
                        </table>
                    </div>
                </asp:Panel>
        
    </asp:View>
    <asp:View ID="View2" runat="server">
        <div style="margin-top: 10px;" class="frm_search">
            <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                <tr>
                    <td>
                     <asp:Literal ID="ltrnav1" runat="server"></asp:Literal>
                    </td>
                    <td class="topcontent" style="width: 50%">
                        <%-- &nbsp;
            <asp:Button ID="btn_back"  runat="server" OnClick="btn_back_Click" Text="<<< Back" Width="96px" ForeColor="Green" />--%>
                        <asp:Button ID="btthemmoind" runat="server" ForeColor="Green" OnClick="btthemmoind_Click"
                            Text="Thêm mới" Width="87px" />
                        <asp:Button ID="btroot_Homepage" runat="server" Text="Root Cate" Width="92px" ForeColor="Green"
                            OnClick="btroot_Homepage_Click" />
                        <asp:Button ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);"
                            Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="35px" ForeColor="Green" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="list_item">
            <asp:Repeater ID="rppages" runat="server" OnItemCommand="rp_newslist_ItemCommand">
                <HeaderTemplate>
                    <table width="100%" cellpadding="10" cellspacing="0">
                        <tr>
                            <td class="header">
                                <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" />
                            </td>
                            <%--<td class="header">Hình ảnh</td>--%>
                            <td class="header">
                                Tiêu đề tin
                            </td>
                            <td class="header">
                                <%=label("l_createdate")%>
                            </td>
                            <td class="header">
                                <%=label("l_view")%>
                            </td>
                            <td class="header">
                                <%=label("lt_display")%>
                            </td>
                            <td class="header">
                                Hiệu chỉnh
                            </td>
                            <td class="header">
                                Xóa
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: #f1f1f1" height="40">
                        <td align="center">
                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                ID="hiID" Value='<%# Eval("id") %>' runat="server" />
                        </td>
                        <%--<td align="center">
              <%#MoreImage.Image(Eval("Images").ToString()) %>
           </td>--%>
                        <td>
                            <b>
                                <%#DataBinder.Eval(Container.DataItem,"Title")%></b>
                        </td>
                        <td align="center">
                            <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Create_Date"))%>
                        </td>
                        <td align="center">
                            <%#DataBinder.Eval(Container.DataItem,"Views")%>
                        </td>
                        <td align="center">
                        <asp:LinkButton CommandName="ChangeStatusi" CommandArgument='<%#Eval("id")+"|"+Eval("Status")%>'   runat="server" ID="Linkbutton9"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="LinkButton2" CssClass="lnk" CommandName="Edit" CommandArgument='<%#Eval("id") %>'
                                runat="server">[ <%=label("lt_edit")%>]</asp:LinkButton>
                        </td>
                        <td align="center">
                            <div class="del">
                                <asp:LinkButton CssClass="lnk" ID="LinkButton3" OnLoad="Delete_Load" CommandName="Delete"
                                    CommandArgument='<%#Eval("id") %>' runat="server">[<%=label("ldelete")%>]</asp:LinkButton></div>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #ffff" height="45">
                        <td align="center">
                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                ID="hiID" Value='<%# Eval("id") %>' runat="server" />
                        </td>
                        <%-- <td align="center">
              <%#MoreImage.Image(Eval("Images").ToString()) %>
           </td>--%>
                        <td>
                            <b>
                                <%#DataBinder.Eval(Container.DataItem,"Title")%></b>
                        </td>
                        <td align="center">
                            <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Create_Date"))%>
                        </td>
                        <td align="center">
                            <%#DataBinder.Eval(Container.DataItem,"Status")%>
                        </td>
                       <td align="center"> 
                        <asp:LinkButton CommandName="ChangeStatusi" CommandArgument='<%#Eval("id")+"|"+Eval("Status")%>'   runat="server" ID="Linkbutton9"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="LinkButton2" CssClass="lnk" CommandName="Edit" CommandArgument='<%#Eval("id") %>'
                                runat="server">[ <%=label("lt_edit")%>]</asp:LinkButton>
                        </td>
                        <td align="center">
                            <div class="del">
                                <asp:LinkButton CssClass="lnk" ID="LinkButton3" OnLoad="Delete_Load" CommandName="Delete"
                                    CommandArgument='<%#Eval("id") %>' runat="server">[<%=label("ldelete")%>]</asp:LinkButton></div>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
            <div style="height: 20px">
            </div>
            <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                <tr height="20">
                    <td align="right">
                        <div class="phantrang" style="">
                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks"
                                BackNextLocation="Split" BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom"
                                PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"
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
                        <b>
                            <asp:LinkButton ID="lnkaddpagecontent" runat="server" OnClick="lnkaddpagecontent_Click"
                                Font-Bold="True">[<%=label("l_createnew")%>]</asp:LinkButton></b>
                    </td>
                </tr>
            </table>
        </div>
    </asp:View>
    <asp:View ID="View3" runat="server">
      <div class="frm_search">
                    <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                        <tr>
                            <td>
                            <asp:Literal ID="ltrnav" runat="server"></asp:Literal>
                            </td>
                            <td class="topcontent" style="width: 50%">
                              sss
                            </td>
                        </tr>
                    </table>
                </div>
        <div class='frm-add'>
            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td>
                    </td>
                    <td style="width: 110px">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <%=label("answers_title")%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="txt_css" Width="99%"></asp:TextBox>
                    </td>
                </tr>
                <asp:Panel ID="PanelTextBox" runat="server">
                    <tr>
                        <td>
                        </td>
                        <td>
                            Hình ảnh
                        </td>
                        <td>
                        </td>
                        <td>
                            <div>
                                <div align="left" style="float: left; width: 700px">
                                    <asp:RadioButton ID="rdFromComputer" runat="server" CssClass="txt_css2" AutoPostBack="True"
                                        Checked="true" GroupName="FromType" OnCheckedChanged="rdFromComputer_CheckedChanged"
                                        Text="Từ máy tính của bạn" ValidationGroup="downloadtype" />
                                    <asp:RadioButton ID="rdFromLinks" runat="server" CssClass="txt_css2" AutoPostBack="True"
                                        GroupName="FromType" OnCheckedChanged="rdFromLinks_CheckedChanged" Text="Từ 1 liên kết" />&nbsp;&nbsp;<br />
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
                                    <div  class="adaidien"><asp:Literal ID="ltimg" runat="server"></asp:Literal></div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <%=label("l_description")%>
                        </td>
                        <td>
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtBrief" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                            <%--AutoConfigure="Simple"--%>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td valign="top">
                    </td>
                    <td valign="top">
                        <%=label("l_content")%>
                    </td>
                    <td>
                    </td>
                    <td>
                            <CKEditor:CKEditorControl ID="txtContents" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <%=label("l_option")%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkcontentstatus" runat="server" Visible="True" CssClass="txt_css2"
                            Text="Chọn: kích hoạt"></asp:CheckBox>

                             <asp:CheckBox ID="CheckBox1"  Visible=false runat="server" CssClass="txt_css2" Text="Trang chủ" />
                                <asp:CheckBox ID="CheckBox2"  Visible=false runat="server" CssClass="txt_css2" Text="Trang chủ" />
                                <asp:CheckBox ID="CheckBox3"  Visible=false runat="server" CssClass="txt_css2" Text="Trang chủ" />
                                <asp:CheckBox ID="CheckBox4"  Visible=false runat="server" CssClass="txt_css2" Text="Trang chủ" />
                                <asp:CheckBox ID="CheckBox5"  Visible=false runat="server" CssClass="txt_css2" Text="Trang chủ" />
                                <asp:CheckBox ID="CheckBox6" Visible=false runat="server" CssClass="txt_css2" Text="Trang chủ" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btncontentsave" runat="server" OnClick="btncontentsave_Click" Text="Thêm - hiệu chỉnh" />
                        <asp:Button ID="btncontentcancel" runat="server" Text="Hủy bỏ" OnClick="btncancelcontent_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:View>
</asp:MultiView>

         
<asp:HiddenField ID="hdFileName" runat="server" />
<asp:HiddenField ID="hdimgsmall" runat="server" />
<asp:HiddenField ID="hdimgMax" runat="server" />
<asp:HiddenField ID="hdimgMaxEdit" runat="server" />
<asp:HiddenField ID="hdimgsmallEdit" runat="server" />
<asp:HiddenField ID="hdid" runat="server" />
<asp:HiddenField ID="hdcontentid" runat="server" />
<asp:HiddenField ID="hdcontentinsertupdate" runat="server" />
<input id="hd_insertupdate" type="hidden" size="1" name="Hidden1" runat="server">
<input id="hd_id" type="hidden" size="1" name="Hidden2" runat="server">
<input id="hd_par_id" type="hidden" size="1" name="Hidden2" runat="server">
<input id="hd_page_edit_id" type="hidden" size="1" name="Hidden2" runat="server">
<div style="clear: both">
</div>

</ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="btn_InsertUpdate" />
             <asp:PostBackTrigger ControlID="btncontentsave" />
            </Triggers>
        </asp:UpdatePanel>
