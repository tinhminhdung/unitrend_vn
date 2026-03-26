<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Search" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<section class="main-product-home block-home">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="product-home-title clearfix">
					<h3><%=label("l_search") %></h3>
                </div>
				<div class="product-home-content clearfix">
					<div class="col-md-12 col-sm-12 col-xs-12 no-padding">
         <asp:Repeater ID="rpcates"  runat="server">
        <ItemTemplate>
       <div class="col-md-2 col-sm-3 col-xs-12 no-padding">
        <div class="product-item">
        <div class="pro-image">
        <%--<div class="sale-label sale-top-right">Sale</div>--%>
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
        <div class="link-detail"><span><a href="/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html"><%=label("chitiet") %></a></span></div>
        </div>
        </div>
                   </div>
            </ItemTemplate>
    </asp:Repeater>
        <div style=" clear:both"></div>
    <asp:Literal ID="lterr" runat="server"></asp:Literal>
    <div class="pager" style="margin-left:10px; margin-right:10px;color: #999;">
        <cc1:CollectionPager id="CollectionPager1" runat="server"  BackNextDisplay="HyperLinks" BackNextLocation="Split"
        BackText="◄" ShowFirstLast="True" ResultsLocation="None" PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"  IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;color:red" LabelText="" LastText="Cuối cùng" NextText="►" PageNumbersDisplay="Numbers" 
        ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="FONT-WEIGHT: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="&nbsp;">
        </cc1:CollectionPager>
 </div> 
  
      </div>

</div>
                </div>
            </div>
        </div>
        </section>
