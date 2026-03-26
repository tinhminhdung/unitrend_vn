<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Message.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Message" %>
<section class="main-product-home block-home">
<div class="container">
<div class="row">
<div class="col-md-12">
	<div class="product-home-title clearfix">
		<h3><%=label("lt_cartbox") %></h3>
    </div>
	<div class="clearfix">
		<div class="col-md-12 col-sm-12 col-xs-12 no-padding">
<div style="line-height: 22px; text-align: center; padding-top: 20px; padding-left: 10px">
<asp:Literal ID="ltmessage" runat="server"></asp:Literal>
</div>
</div>
</div>
    </div>
</div>
</div>
</section>
