<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contact.ascx.cs" Inherits="VS.E_Commerce.cms.Display.contact.contact" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="/cms/display/contact/Resources/css/StyleSheet.css" rel="stylesheet" type="text/css" />
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:nav_conten runat="server" id="Nav_conten1" />
<div class="main-content">
    <div class="container">
        <div class="row">
              <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <asp:updatepanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
                        <div class='frm-contact'>
                            <div style="padding-top: 10px; line-height: 22px">
                                <asp:literal id="ltcontactcontent" runat="server"></asp:literal>
                            </div>
                            <div class="Anhmap">
                                <%=MoreAll.Other.Giatri("txtbando")%>
                            </div>
                            <div style="padding: 10px 10px 10px 10px">
                                <asp:label id="ltmsg" runat="server" font-bold="true" forecolor="red"></asp:label>
                            </div>
                            <div style="width: 100%">
                                <div class="tbinput">
                                    <div class="labelll">
                                        <%=label("l_name")%>:
                                    </div>
                                    <div>
                                        <asp:textbox id="txtfullname" runat="server" validationgroup="GInfo" class="textarea" width="270px"></asp:textbox>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" validationgroup="GInfo" controltovalidate="txtfullname" errormessage="*"></asp:requiredfieldvalidator>
                                    </div>
                                </div>
                                <div class="tbinput">
                                    <div class="labelll">
                                        Email:
                                    </div>
                                    <div style=" height: 21px; ">
                                        <asp:textbox id="txtemail" runat="server" validationgroup="GInfo" class="textarea" width="270px"></asp:textbox>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="txtemail" display="Dynamic" errormessage="*" setfocusonerror="True" validationgroup="GInfo"></asp:requiredfieldvalidator>
                                        <asp:regularexpressionvalidator id="RequiredFieldValidator4" validationgroup="GInfo" runat="server" controltovalidate="txtemail" errormessage="Vui lòng nhập email hợp lệ." validationexpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="valRegExResource1"></asp:regularexpressionvalidator>
                                    </div>
                                </div>
                                <div class="tbinput">
                                    <div class="labelll">
                                        <%=label("l_phone")%>:
                                    </div>
                                    <div>
                                        <asp:textbox id="txtphone" runat="server" validationgroup="GInfo" class="textarea" width="270px"></asp:textbox>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="txtphone" display="Dynamic" errormessage="*" setfocusonerror="True" validationgroup="GInfo"></asp:requiredfieldvalidator>
                                        <asp:regularexpressionvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="txtphone" display="Dynamic" errormessage="Số điện thoại phải là số !" setfocusonerror="True" validationexpression="\d*" validationgroup="GInfo"></asp:regularexpressionvalidator>
                                    </div>
                                </div>
                                <div class="tbinput">
                                    <div class="labelll">
                                        <%=label("l_address")%>:
                                    </div>
                                    <div>
                                        <asp:textbox id="txtaddress" runat="server" validationgroup="GInfo" class="textarea" width="270px"></asp:textbox>
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" validationgroup="GInfo" controltovalidate="txtaddress" errormessage="*"></asp:requiredfieldvalidator>
                                    </div>
                                </div>
                                <div class="tbinput">
                                    <div class="labelll">
                                        <%=label("l_title")%>:
                                    </div>
                                    <div class="txt_file">
                                        <asp:textbox id="txttieude" runat="server" validationgroup="GInfo" class="textarea" width="270px"></asp:textbox>
                                    </div>
                                </div>
                                <div style="clear: both">
                                    <div class="labelll">
                                        <%=label("l_content")%>:
                                    </div>
                                    <div>
                                        <asp:textbox id="txtcontent" runat="server" height="111px" textmode="MultiLine" validationgroup="GInfo" class="textarea" width="270px"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <asp:updateprogress id="UpdateProgress1" runat="server" associatedupdatepanelid="UpdatePanel1">
                            <progresstemplate>
                                <div id="loadingAjax">
                                    <div class="inner">
                                        <img src="/Resources/ShopCart/images/ajax-loader_2.gif"><p><%=label("dangxuly") %>...</p>
                                    </div>
                                </div>
                            </progresstemplate>
                        </asp:updateprogress>
                        <div class="khoangcbut">
                            <asp:button id="btgui" runat="server" onclick="btgui_Click" validationgroup="GInfo" text="Gửi liên hệ" cssclass="btnadd" />
                        </div>
                    </contenttemplate>
                </asp:updatepanel>
            </div>
            <div class="col-md-4">
               <%-- <uc1:lefmenu runat="server" id="Lefmenu" />--%>
            </div>
        </div>
    </div>
</div>



