<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GioiThieu.ascx.cs" Inherits="VS.E_Commerce.cms.Display.GioiThieu.GioiThieu" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<div class="main-breadcrumb">
	<div class="container">
		<div class="row">
			<div class="col-lg-12">
				<ol class="breadcrumb">
					<li><a href="/">Trang chủ</a></li>
                    <li><a>Giới thiệu</a></li>
				</ol>
			</div>
		</div>
	</div>
</div>
<div class="main-content">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="blog-home-title clearfix">
					<h1><asp:Literal ID="ltcatename" runat="server"></asp:Literal></h1>
				</div>
				<div class="blog-article clearfix">
<div class="News-content">

<div><asp:Literal ID="ltFacebook" runat="server"></asp:Literal></div>
<div class="des-news"><asp:Literal ID="ltdesc" runat="server"></asp:Literal></div>
<div class="Other"><asp:Literal ID="ltTinlienquan" runat="server"></asp:Literal></div>
<div class="contents">    
<asp:Literal ID="ltcontent" runat="server"></asp:Literal>
<div style=" text-align:left; padding-bottom:20px ; padding-top:10px">
<asp:Literal ID="ltchiase" runat="server"></asp:Literal>
</div>
 </div>
</div>
				</div>
			</div>
			
		</div>
	</div>
</div>



<div class="title" style=" display:none"><asp:Literal ID="lttitle" runat="server"></asp:Literal></div>