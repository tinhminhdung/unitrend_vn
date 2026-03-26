<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Members.Register" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="/cms/display/contact/Resources/css/StyleSheet.css" rel="stylesheet" type="text/css" />
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
	<div class="container">

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div class="frm-addDK">
                    <div style="">
                        <div style="clear: both"></div>
                        <div class="maudangky">
                            <div class="logodangkythanhvien">
                                <img src="/Resources/2025/user-icon.png" />
                            </div>
                            <div class="thfffngitn">
                                Đăng ký thành viên để đặt hàng dễ dàng<br />
                                lưu giỏ hàng và quản lý đơn hàng
                            </div>
                            <div class="dangkysttt">Đăng ký tài khoản</div>
                            <div>
                                <div class="labelll"></div>
                                <div>
                                    <asp:Label ID="ltmsg" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div style="clear: both"></div>

                             <div>
                                <div class="labelll">
                                    Điện thoại
                                </div>
                                <div class="ipTextBox">
                                    <asp:TextBox ID="txt_phone" runat="server" class="textarea" ValidationGroup="GInfo" MaxLength="11"></asp:TextBox><span style=" color:#ff0000">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_phone" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="GInfo"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_phone" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationExpression="\d*" ValidationGroup="GInfo"></asp:RegularExpressionValidator>

                                </div>
                            </div>

                             <div>
                                <div class="labelll">
                                    <%=label("lt_password")%>:
                                </div>
                                <div class="ipTextBox">
                                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" ValidationGroup="GInfo" class="textarea"></asp:TextBox><span style=" color:#ff0000">*</span>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="GInfo" ControlToValidate="txtpassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div>
                                <div class="labelll">
                                    Họ và tên:
                                </div>
                                <div class="ipTextBox">
                                    <asp:TextBox ID="txtlastname" runat="server" ValidationGroup="GInfo" class="textarea"></asp:TextBox><span style=" color:#ff0000">*</span>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="GInfo" ControlToValidate="txtlastname" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                          
                            <asp:UpdatePanel ID="countrypanel" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <div class="labelll">
                                            Tỉnh / Thành phố:
                                        </div>
                                        <div class="ipTextBox">
                                            <asp:DropDownList ID="ddlcountry" AutoPostBack="true" AppendDataBoundItems="true" runat="server" CssClass="ddltthanhdk" ValidationGroup="GInfo" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged"></asp:DropDownList><span style=" color:#ff0000">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" Text="*" InitialValue="0" ControlToValidate="ddlcountry" ValidationGroup="GInfo"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div>
                                        <div class="labelll">
                                            Quận / Huyện:
                                        </div>
                                        <div class="ipTextBox">
                                            <asp:DropDownList ID="ddlstate" runat="server" ValidationGroup="GInfo" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" CssClass="ddltthanhdk"></asp:DropDownList><span style=" color:#ff0000">*</span>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Text="*" InitialValue="0" ControlToValidate="ddlstate" ValidationGroup="GInfo"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div>
                                        <div class="labelll">
                                            Phường xã:
                                        </div>
                                        <div class="ipTextBox">
                                            <asp:DropDownList ID="ddlcity" ValidationGroup="GInfo" AutoPostBack="true" AppendDataBoundItems="true" runat="server" CssClass="ddltthanhdk">
                                            </asp:DropDownList><span style=" color:#ff0000">*</span>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Text="*" InitialValue="0" ControlToValidate="ddlcity" ValidationGroup="GInfo"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlcountry" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlstate" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlcity" />
                                </Triggers>
                            </asp:UpdatePanel>
                                <div>
                                    <div class="labelll">
                                       Số nhà, đường:
                                    </div>
                                    <div class="ipTextBox">
                                        <asp:TextBox ID="txt_add" runat="server" class="textarea" placeholder="Số nhà, ngõ, ngách, thôn xóm" ValidationGroup="GInfo"></asp:TextBox><span style=" color:#ff0000">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="GInfo" ControlToValidate="txt_add" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                             <div>
                                <div class="labelll">
                                    Email
                                </div>
                                <div class="ipTextBox">
                                    <asp:TextBox ID="txtemail" runat="server" ValidationGroup="GInfo" class="textarea"></asp:TextBox>
                                </div>
                            </div>
                            <div style=" clear:both"></div>
                        </div>
                          <div style="height: 10px; clear: both"></div>
                         <div class="gachhhh1 Destop"></div>
                        <div style="height: 10px; clear: both" class="Destop"></div>
                        <div class="maudangky Destop">
                            <div class="dangkysttt">Thông tin công ty</div>
                            <div class="mau2"><i>(Không bắt buộc - chỉ dùng trong trường hợp khách cần hóa đơn)</i></div>
                            <div>
                                <div class="labelll">
                                    Tên công ty:
                                </div>
                                <div class="ipTextBox">
                                    <asp:TextBox ID="txttencongty" runat="server" class="textarea" ValidationGroup="GInfo"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <div class="labelll">
                                    Địa chỉ công ty:
                                </div>
                                <div class="ipTextBox">
                                    <asp:TextBox ID="txtdiachicongty" runat="server" class="textarea" ValidationGroup="GInfo"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <div class="labelll">
                                    Email công ty:
                                </div>
                                <div class="ipTextBox">
                                    <asp:TextBox ID="txtsodienthoaicongty" runat="server" class="textarea" ValidationGroup="GInfo"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <div class="labelll">
                                    Mã số thuế:
                                </div>
                                <div class="ipTextBox">
                                    <asp:TextBox ID="txtmasothuecongty" runat="server" class="textarea" ValidationGroup="GInfo"></asp:TextBox>
                                </div>
                            </div>

                            </div>
                        <div class="maudangky">
                            <div>
                                <div class="labelll">
                                </div>
                                <div class="ipTextBox">
                                    <div class="nutdangky">
                                        <asp:Button ID="btnregister" ValidationGroup="GInfo" runat="server" Text="Đăng ký" OnClick="Button1_Click" class="btnadddk" />
                                        <asp:Button ID="btncancel" runat="server" Text="Làm lại" class="btnadddk" OnClick="btncancel_Click" />
                                    </div>

                                </div>
                            </div>
                            <br />
                            <br />

                        </div>
                    </div>
                </div>


            </asp:View>
            <asp:View ID="View2" runat="server">
                <div style="line-height: 22px; padding: 10px">
                    <div>Đăng ký thành công.</div>
                    <div>Bạn có thể sử dụng thông tin đăng ký của mình để sử dụng các tính năng trong website của chúng tôi.</div>
                </div>
            </asp:View>
        </asp:MultiView>

    </div>
</div>


<style>
    .gnv-body .right-home .rows-home {
        width: 100%;
        height: auto;
        float: left;
        margin-bottom: 7px;
        background: #fff;
        padding-bottom: 30px;
    }
</style>
