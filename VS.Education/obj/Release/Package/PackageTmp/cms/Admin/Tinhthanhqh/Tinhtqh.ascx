<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tinhtqh.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Tinhthanhqh.Tinhtqh" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pn_list" runat="server" Width="100%">
            <div style="margin-top: 10px;" class="frm_search">
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lbl_curpage" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
                            <asp:Literal ID="ltmsg" runat="server"></asp:Literal>&nbsp;
                        </td>
                        <td class="topcontent" style="width: 50%">

                            <%if (ShowThem == "1")
                                {%>
                          &nbsp;<asp:Button ID="btthemmoi" runat="server" ForeColor="Green" OnClick="btthemmoi_Click" Text="Thêm mới" Width="87px" />
                            <%} %>
                            <asp:Button ID="btn_Homepage" runat="server" OnClick="btn_Homepage_Click" Text="Root Cate" Width="92px" ForeColor="Green" />
                            <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="<<< Back" Width="96px" ForeColor="Green" />
                            <%if (ShowXoa == "1")
                                {%>
                            <asp:Button ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="35px" ForeColor="Green" />
                            <%} %>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="list_item">
                <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                    <ItemTemplate>
                        <tr style="background-color: #f1f1f1" height="40">
                            <td align="center">
                                <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                            </td>
                            <td>
                                <asp:LinkButton CommandName="ListChildren" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton2" NAME="Linkbutton2"><%#DataBinder.Eval(Container.DataItem,"Name")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton7" CommandName="Tang" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[Tăng]</asp:LinkButton>
                                <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                <asp:LinkButton ID="LinkButton8" CommandName="Giam" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[Giảm]</asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <%if (ShowSua == "1")
                                    {%>
                                <asp:LinkButton ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[<%=label("lt_edit")%>]</asp:LinkButton>

                                <%} %>
                            </td>
                            <td align="center">
                                <%if (ShowXoa == "1")
                                    {%>
                                <div class="del">
                                    <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">[<%=label("ldelete")%>]</asp:LinkButton>
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
                            <td>
                                <asp:LinkButton CommandName="ListChildren" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton2" NAME="Linkbutton2"><%#DataBinder.Eval(Container.DataItem,"Name")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton7" CommandName="Tang" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[Tăng]</asp:LinkButton>
                                <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                <asp:LinkButton ID="LinkButton8" CommandName="Giam" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[Giảm]</asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <%if (ShowSua == "1")
                                    {%>
                                <asp:LinkButton ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[<%=label("lt_edit")%>]</asp:LinkButton>

                                <%} %>
                            </td>
                            <td align="center">
                                <%if (ShowXoa == "1")
                                    {%>
                                <div class="del">
                                    <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">[<%=label("ldelete")%>]</asp:LinkButton>
                                </div>
                                <%} %>
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
                                    <%=label("answers_title")%>
                                </td>
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
                    <td></td>
                </tr>
                <tr height="25" bgcolor="whitesmoke">
                    <td>
                        <%if (ShowThem == "1")
                            {%>
                        <asp:LinkButton ID="LinkButton5" Font-Bold="true" OnClick="LinkButton4_Click" runat="server">[<%=label("l_createnew")%>]</asp:LinkButton>
                        <%} %>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pn_insert" runat="server" Visible="False" Width="100%">
            <div class='frm-add'>
                <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="right" width="175"></td>
                        <td width="10"></td>
                        <td>
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <%=label("answers_title")%>
                        </td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txt_title" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right">Phí vận chuyển
                        </td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txtgia" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right">icon
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
                                            <asp:FileUpload CssClass="txt_css" ID="flimage" runat="server" Width="323px" />
                                        </asp:View>
                                        <asp:View ID="vwFromLinks" runat="server">
                                            <asp:TextBox CssClass="txt_css" ID="txtvimg" runat="server" Width="99%"></asp:TextBox><br />
                                        </asp:View>
                                    </asp:MultiView>
                                </div>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:Literal ID="ltimg" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right">
                            <%=label("answers_title")%>
                        </td>
                        <td></td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtcontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right">Tính năng seo
                        </td>
                        <td></td>
                        <td>

                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <img src="/Resources/admin/images/loading.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:Button ID="btseo" runat="server" Text="Tính năng seo" OnClick="btseo_Click" />
                        </td>
                    </tr>
                    <asp:Panel ID="pnseo" runat="server" Visible="False" Width="100%">
                        <tr>
                            <td align="left" colspan="3">
                                <div style="background: #f7f7f7; border: 1px solid #d7d7d7; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; width: 700px; margin-left: 180px">
                                    <table>
                                        <tr>
                                            <td align="left">Tiêu đề từ khóa (Title)
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txttitleseo" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">Từ khóa trang web (Meta)
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtmeta" CssClass="txt_css" runat="server" Width="392px"
                                                    Height="35px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">Từ khóa mô tả (Keyword)
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtKeyword" CssClass="txt_css" runat="server" Width="459px"
                                                    Height="43px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            </td>
                        </tr>
                    </asp:Panel>
                    <tr style="display: none">
                        <td align="right">Tùy chọn</td>
                        <td></td>
                        <td>
                            <asp:CheckBox ID="chknews" Visible="false" CssClass="txt_css2" runat="server" Text="Mới" />
                            <asp:CheckBox ID="chkTrangChu" Visible="false" CssClass="txt_css2" runat="server" Text="Trang chủ" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <%=label("lt_order")%>
                        </td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txt_order" runat="server" CssClass="txt_css" Width="32px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <%=label("lt_display")%>
                        </td>
                        <td></td>
                        <td>
                            <asp:CheckBox ID="chck_Enable" CssClass="txt_css2" runat="server" Visible="True" />
                    </tr>
                </table>
            </div>
            <div style="padding-left: 150px; padding-top: 10px;">
                <asp:Button ID="btn_InsertUpdate" runat="server" OnClick="btn_InsertUpdate_Click" Text="Insert/Update" Width="120px" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="56px" />
            </div>
            <asp:HiddenField ID="hdFileName" runat="server" />
            <asp:HiddenField ID="hdid" runat="server" />
        </asp:Panel>
        <input id="hd_insertupdate" type="hidden" size="1" name="Hidden1" runat="server">
        <input id="hd_id" type="hidden" size="1" name="Hidden2" runat="server">
        <input id="hd_page_edit_id" type="hidden" size="1" name="Hidden2" runat="server">
        <input id="hd_imgpath" type="hidden" size="1" name="Hidden2" runat="server">
        <input id="hd_rootpic" type="hidden" size="1" runat="server">
        <input id="hd_par_id" type="hidden" size="1" name="Hidden2" runat="server">
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_InsertUpdate" />
        <asp:PostBackTrigger ControlID="btDeleteimages" />
    </Triggers>
</asp:UpdatePanel>
