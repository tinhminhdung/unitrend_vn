<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Changinfo.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Members.Changinfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<style>
.blog-home-title h1:after {

    border-left: 0px solid #fff;

}
</style>

<div class="main-content">
	<div class="container">
		<div class="row">
			<div class="col-md-9">
				<div class="blog-home-title clearfix">
					<h1><%=label("login6") %></h1>
				</div>
				<div class="blog-article clearfix">
<div class="item-ct">
     <div style="padding-left:20px; padding-left:140px; clear:both; padding-top:10px;"><asp:Label ID="ltmsg" runat="server" ForeColor=Red></asp:Label></div>
  <div class="frm-add" style=" padding:10px">
     <div class="gachke">
        <div class="tenthanhvien"><%=label("l_name")%> :</div>
        <div><asp:TextBox CssClass='contact3' ID="txtname" runat="server" Width="160px" ></asp:TextBox></div>                    
    </div>
    <div class="gachke">
        <div class="tenthanhvien"><%=label("lt_birthday") %></div>
        <div><asp:TextBox CssClass='contact3' ID="txtbirthday" runat="server" Width="157px" ></asp:TextBox>
            <span style="font-size: 7pt; font-family: Tahoma">(yyyy-mm-dd)</span><cc1:calendarextender id="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtbirthday"></cc1:calendarextender>
        </div> 
       </div>                  
     <div class="gachke">
        <div class="tenthanhvien"><%=label("l_address") %></div>
        <div><asp:TextBox CssClass='contact3' ID="txtaddress" runat="server" Width="358px" ></asp:TextBox></div>                    
    </div>
     <div class="gachke">
        <div class="tenthanhvien"> <%=label("l_phone")%></div>
        <div><asp:TextBox CssClass='contact3' ID="txtphone" runat="server" Width="233px" ></asp:TextBox></div>                    
    </div>
     <div class="gachke" style=" display:none">
        <div class="tenthanhvien">Ảnh đại diện</div>
        <div>
            <asp:FileUpload ID="flavatar" runat="server" CssClass="contact3" Height="20px" Width="250px" /><br />
            <div  class="adaidien"><asp:Literal ID="ltimg" runat="server"></asp:Literal></div>
        </div>
    </div>
    </div>
    <div style="padding-left:0px; padding-left:0px; clear:both; padding-top:10px;">
            <asp:Button ID="btnsave"  ValidationGroup="GInfo" runat="server" CssClass="btnadd" Text="Lưu thông tin" OnClick="btnsave_Click" />
       </div>
         
            <asp:HiddenField ID="hdid" runat="server" />
            <asp:HiddenField ID="hdimg" runat="server" />
</div>
</div>
			</div>
			<div class="col-md-3">
                <uc1:Lefmenu runat="server" ID="Lefmenu" />
</div>
		</div>
	</div>
</div>

