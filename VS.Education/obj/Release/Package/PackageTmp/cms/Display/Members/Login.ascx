<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Members.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="blog-home-title clearfix">
                    <h1><%=label("login1") %></h1>
                </div>
                <div class="blog-article clearfix">


                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="container" style="margin-top: 5%">
                                <div class="row">
                                    <div class="col-sm-6 col-md-4 col-md-offset-4">
                                        <div class="panel-body paneddd">
                                            <fieldset>
                                                <div class="row">
                                                    <div class="center-block">
                                                        <img class="profile-img" src="/Resources/2025/user-icon.png" alt="User">
                                                    </div>
                                                </div>
                                                <div style="text-align: center">
                                                    <asp:Label ID="ltmsg" runat="server" ForeColor="Red"></asp:Label></div>
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-10  col-md-offset-1 ">
                                                        <div class="form-group">
                                                            <div class="input-group">
                                                                <span class="input-group-addon"><i class="fa fa-phone"></i></span>
                                                                <asp:TextBox ID="txt_Uname" placeholder="Số điện thoại hoặc Email" runat="server" Style="width: 240px !important" class="form-control" ValidationGroup="GInfo"></asp:TextBox>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="GInfo" ControlToValidate="txt_Uname" ErrorMessage="Phải là số điện thoại hoặc email  !"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="input-group">
                                                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                                                <asp:TextBox ID="txt_password" runat="server" placeholder="Mật khẩu" TextMode="password" Style="width: 240px !important" ValidationGroup="GInfo" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="GInfo" ControlToValidate="txt_password" ErrorMessage="Mật khẩu không được để trống !"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:Button ID="btnlogin" runat="server" Text="Đăng nhập" Style="width: 275px !important" class="btn btn-lg btn-primary btn-block" ValidationGroup="GInfo" OnClick="btnlogin_Click" CssClass="btnadd" />
                                                        </div>
                                                        <div class="login-help">
                                                            <a href="/Dang-ky.aspx" class="Danglogin">Đăng ký</a>  <a class="Doilogin" href="/Doi-mat-khau.aspx">Quên mật khẩu</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </fieldset>

                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <style>
                                .form-group {
                                    margin-bottom: -1px !important;
                                }

                                .input-group-addon {
                                    border-radius: initial !important;
                                    -webkit-border-top-left-radius: 3px !important;
                                    -webkit-border-bottom-left-radius: 3px !important;
                                    -moz-border-radius-topleft: 3px !important;
                                    -moz-border-radius-bottomleft: 3px !important;
                                    border-top-left-radius: 3px !important;
                                    border-bottom-left-radius: 3px !important;
                                }

                                .panel {
                                    border-radius: 5px;
                                }

                                .panel-heading {
                                    padding: 10px 15px;
                                }

                                .panel-title {
                                    text-align: center;
                                    font-size: 15px;
                                    font-weight: bold;
                                    color: #17568C;
                                }

                                .panel-footer {
                                    padding: 1px 15px;
                                    color: #A0A0A0;
                                }

                                .profile-img {
                                    width: 120px;
                                    height: 120px;
                                    margin: 0 auto 10px;
                                    display: block;
                                    -moz-border-radius: 50%;
                                    -webkit-border-radius: 50%;
                                    border-radius: 50%;
                                }
                            </style>
                            <div style="clear: both"></div>



                        </ContentTemplate>
                    </asp:UpdatePanel>





                </div>
            </div>
        </div>
    </div>
</div>


