<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DCategory.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.DCategory" %>
  <asp:Repeater ID="rpcatestop" runat="server">
<ItemTemplate>
<section class="main-product-home block-home">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="product-home-title clearfix">
					<h3><a href="/<%#MoreAll.RewriteURL.GetRewriteURL(Eval("Name").ToString())%>_s<%#Eval("id") %>.aspx"><%#Eval("Name") %></a></h3>
                </div>
				<div class="product-home-content clearfix">
					<div class="col-md-12 col-sm-12 col-xs-12 no-padding">
         <asp:Repeater ID="Repeater2" DataSource='<%#NewProductInCate(Eval("id").ToString()) %>' runat="server">
        <ItemTemplate>
          <div class="col-md-2 col-sm-3 col-xs-12 no-padding">
        <div class="product-item">
        <div class="pro-image">
            <a  href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html'><%#MoreAll.MorePro.Image_width_height_Title_Alt_css("img-responsive",Eval("ImagesSmall").ToString(),"240","240",Eval("Name").ToString(),Eval("Name").ToString())%></a>
        </div>
         <div class="biz-qv-button-wrap" > <a href="javascript:void(0)" rel="popuprel3" class="popup biz-qv-button"  onclick="Xemnhanh(<%#Eval("ipid")%>,'<%#Eval("Name")%>')"><%=label("xemnhanh") %></a></div>
        <div class="pro-content">
        <h4 class="pro-name">
            <a  href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html'><%#Eval("Name") %></a>
        </h4>
        <div class="pro-price">
	        <p class="price-new"><%#MoreAll.MorePro.FormatMoney(Eval("Price").ToString())%></p>
	        <p class="price-old"><del><%#MoreAll.MorePro.Detail_Price(Eval("OldPrice").ToString())%></del></p>
        </div>
        <div class="link-detail"><span><a href="<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html"><%=label("chitiet") %></a></span></div>
        </div>
        </div>
                   </div>
            </ItemTemplate>
    </asp:Repeater>
     </div>
				</div>
			</div>
		</div>
	</div>
</section>
</ItemTemplate>
</asp:Repeater>

<asp:Repeater ID="rpcates" runat="server">
<ItemTemplate>
<section class="main-product-home block-home">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="product-home-title clearfix">
					<h3><a href="/<%#MoreAll.RewriteURL.GetRewriteURL(Eval("Name").ToString())%>_s<%#Eval("id") %>.aspx"><%#Eval("Name") %></a></h3>
                </div>
				<div class="product-home-content clearfix">
					<div class="col-md-12 col-sm-12 col-xs-12 no-padding">
         <asp:Repeater ID="Repeater2" DataSource='<%#NewProductInCate(Eval("id").ToString()) %>' runat="server">
        <ItemTemplate>
               <div class="col-md-2 col-sm-3 col-xs-12 no-padding">
        <div class="product-item">
        <div class="pro-image">
        <%--<div class="sale-label sale-top-right">Sale</div>--%>
            <a  href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html'><%#MoreAll.MorePro.Image_width_height_Title_Alt_css("img-responsive",Eval("ImagesSmall").ToString(),"240","240",Eval("Name").ToString(),Eval("Name").ToString())%></a>
        </div>
      <div class="biz-qv-button-wrap" > <a href="javascript:void(0)" rel="popuprel3" class="popup biz-qv-button"  onclick="Xemnhanh(<%#Eval("ipid")%>,'<%#Eval("Name")%>')"><%=label("xemnhanh") %></a></div>
        <div class="pro-content">
        <h4 class="pro-name">
            <a  href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html'><%#Eval("Name") %></a>
        </h4>
        <div class="pro-price">
	        <p class="price-new"><%#MoreAll.MorePro.FormatMoney(Eval("Price").ToString())%></p>
	        <p class="price-old"><del><%#MoreAll.MorePro.Detail_Price(Eval("OldPrice").ToString())%></del></p>
        </div>
        <div class="link-detail"><span><a href="<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html"><%=label("chitiet") %></a></span></div>
        </div>
        </div>
                   </div>
            </ItemTemplate>
    </asp:Repeater>
    </div>
				</div>
			</div>
		</div>
	</div>
</section>
</ItemTemplate>
</asp:Repeater>
