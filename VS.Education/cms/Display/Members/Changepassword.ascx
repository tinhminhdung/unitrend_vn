<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Changepassword.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Members.Changepassword" %>


<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
	<div class="container">
		<div class="row">
			<div class="col-md-9">
				<div class="blog-home-title clearfix">
					<h1><%=label("lt_changepassword")%></h1>
				</div>
				<div class="blog-article clearfix">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   <div style="padding-left:20px; padding-left:140px; clear:both; padding-top:10px;"><asp:Label ID="ltmsg" runat="server" ForeColor=Red></asp:Label></div>
   <div class="frm-add" style=" padding:10px">
            <div class="gachke">
        <div class="tenthanhvien">
                    <%=label("lt_oldpassword")%></div>
                <div>
                    <asp:TextBox CssClass='contact3' ID="txtcurrentpass" runat="server"  TextMode="Password" Width="250px"></asp:TextBox> 
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="GInfo" ControlToValidate="txtcurrentpass" ErrorMessage="Mật khẩu không được để trống !" ></asp:RequiredFieldValidator>
                    </div>
            </div>
            <div class="gachke">
        <div class="tenthanhvien">
                  <%=label("lt_newpassword") %></div>
                <div>
                    <asp:TextBox CssClass='contact3' ID="txtnewpassword" runat="server"  TextMode="Password" Width="250px"></asp:TextBox> 
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="GInfo" ControlToValidate="txtnewpassword" ErrorMessage="Mật khẩu không được để trống !" ></asp:RequiredFieldValidator>
                       </div>
            </div>
            <div class="gachke">
        <div class="tenthanhvien" style="">
                     <%=label("lt_checkpassword")%></div>
                <div>
                    <asp:TextBox CssClass='contact3' ID="txtnewpasswordconfirm" runat="server"  TextMode="Password" Width="250px"></asp:TextBox> 
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="GInfo" ControlToValidate="txtnewpasswordconfirm" ErrorMessage="Mật khẩu không được để trống !" ></asp:RequiredFieldValidator>
                    </div>
            </div>
           </div>    

           <div style="clear:both; padding-top:10px;">
            <asp:Button ID="btnchangepassword"  ValidationGroup="GInfo" runat="server" CssClass="btnadd" Text="Đổi mật khẩu" OnClick="btnchangepassword_Click" />
       </div>
    </ContentTemplate>
</asp:UpdatePanel>
</div>
			</div>
			<div class="col-md-3">
                <uc1:Lefmenu runat="server" ID="Lefmenu" />
</div>
		</div>
	</div>
</div>

