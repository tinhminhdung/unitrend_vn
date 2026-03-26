<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.NewsFooter.Detail" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
	<div class="container">
		<div class="row">
			<div class="col-md-9">
				<div class="blog-article clearfix">
<div class="News-content">
<div class="title"><h1><asp:Literal ID="lttitle" runat="server"></asp:Literal></h1></div>
<div><asp:Literal ID="ltFacebook" runat="server"></asp:Literal></div>
<div class="contents">    
<asp:Literal ID="ltcontent" runat="server"></asp:Literal>
<div style=" text-align:left; padding-bottom:20px ; padding-top:10px">
<asp:Literal ID="ltchiase" runat="server"></asp:Literal>
</div>
<div style=" height:10px"></div>
<div class="list-more-news">
<asp:Repeater ID="rpitems2" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintruoc")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html" title="<%#Eval("Title")%>"><%#Eval("Title")%></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div> 
<div class="list-more-news">
<asp:Repeater ID="rpitems" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintieptheo")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html" title="<%#Eval("Title")%>"><%#Eval("Title")%></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div>
 </div>
</div>
				</div>
			</div>
			<div class="col-md-3">
                <uc1:Lefmenu runat="server" ID="Lefmenu" />
</div>
		</div>
	</div>
</div>




        