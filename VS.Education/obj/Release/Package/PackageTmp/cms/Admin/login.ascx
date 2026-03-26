<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.login" %>
 <div class="aspNetHidden">
        <div id="LoginMain">
            <div class="Erromessage" style="padding-bottom: 5px;">
                <span id="lberromessage"></span>
            </div>
            <div class="ContainMain" style=" line-height:25px;">
                <div style="padding-top: 10px; padding-bottom: 10px;">
                    <asp:Label ID="lt_msg" runat="server" ForeColor="red"></asp:Label></div>
                <div style="height: 22px; width: 325px;">
                    <div class="LabelLogin" style="float: left;">
                        <span id="UserNameLabel">
                            <%=label("l_username")%>:</span>
                    </div>
                    <div style="float: left;">
                        <asp:TextBox ID="txt_username" runat="server" class="Public_input" Style="width: 190px;
                            outline: none; padding-left: 10px;" Width="150px"></asp:TextBox>
                    </div>
                </div>
                 <div style="height: 22px; width: 297px; float: left;">
                    <div class="LabelLogin" style="float: left;">
                        <span id="Span1">
                            <%=label("lt_password")%>:</span>
                    </div>
                    <div style="float:right;">
                        <asp:TextBox ID="txt_pwd" class="Public_input" Style="width: 190px; border: none; outline: none; padding-left: 10px;" TextMode="Password" runat="server" Width="150px"></asp:TextBox>
                     </div>
                </div>
                <div style="width: 325px;">
                    <div style="margin-top: 18px; float: right;">
                        <asp:LinkButton ID="lnkdangnhap" runat="server" OnClick="lnkdangnhap_Click"><img src="/Resources/admin/images/iconlogin.png" border=0 /></asp:LinkButton>
                    </div>
                </div>
                <div class="Copyright">
                    <a style="margin-top: 20px;" href="#"><span id="Lb_copyright">© 2017 All rights reserved</span> - Version 4.0 </a>
                </div>
            </div>
        </div>
    </div>