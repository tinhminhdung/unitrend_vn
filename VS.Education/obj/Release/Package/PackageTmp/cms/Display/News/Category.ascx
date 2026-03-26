<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="VS.E_Commerce.cms.Display.News.Category1" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
	<div class="container">
		<div class="row">
			<div class="col-md-9">
				<div class="blog-home-title clearfix">
					<h1><asp:Literal ID="ltcatename" runat="server"></asp:Literal></h1>
				</div>
                	

				<div class="blog-article clearfix">
 <asp:Repeater ID="rpcates" runat="server">
<ItemTemplate>
<div class="blog-item">
	<div class="row">
		<div class="col-md-4 col-sm-4 col-xs-4">
            <a href="<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html"><%#MoreAll.MoreNews.Image_Title_Alt(Eval("ImagesSmall").ToString(), Eval("Title").ToString(), Eval("Title").ToString())%></a>
		</div>
		<div class="col-md-8 col-sm-8 col-xs-8">
			<h3 class="blog-name"><a href="<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html"><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a></h3>
			<p class="blog-info"><%#MoreAll.FormatDateTime.FormatDate(Eval("Create_Date").ToString())%></p>
			<p class="blog-description"><%#MoreAll.MoreNews.Substring_Mota(Eval("Brief").ToString())%></p>
		</div>
	</div>
</div>
</ItemTemplate>
</asp:Repeater>
<asp:Literal ID="lterr" runat="server"></asp:Literal>
<div class="pager" style="margin-left:10px; margin-right:10px;color: #999;">
<cc1:CollectionPager id="CollectionPager1" runat="server"  BackNextDisplay="HyperLinks" BackNextLocation="Split"
BackText="◄" ShowFirstLast="True" ResultsLocation="None" PagingMode="PostBack" MaxPages="50"  HideOnSinglePage="True"  IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;color:red" LabelText=""  NextText="►" PageNumbersDisplay="Numbers" 
ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="FONT-WEIGHT: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="&nbsp;">
</cc1:CollectionPager></div>
				</div>
			</div>
			<div class="col-md-3">
                <uc1:Lefmenu runat="server" ID="Lefmenu" />
</div>
		</div>
	</div>
</div>



