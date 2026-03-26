<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DCategory.ascx.cs" Inherits="VS.E_Commerce.cms.Display.News.DCategory" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten" />
<div class="main-content">
	<div class="container">
		<div class="row">
			<div class="col-md-9">
				<div class="article-cate clearfix">
					<div class="pull-left">
						<h3><i class="fa fa-caret-right"></i> <asp:Literal ID="ltcatename" runat="server"></asp:Literal></h3>
					</div>
				</div>
				<div class="article">
					<h1 class="article-name"><asp:Literal ID="lttitle" runat="server"></asp:Literal></h1>
					<div class="article-info">
						<p class="blog-info"><asp:Literal ID="ltdate" runat="server"></asp:Literal></p>	
					</div>
					<div class="News-content">
<div><asp:Literal ID="ltFacebook" runat="server"></asp:Literal></div>
<div class="des-news"><asp:Literal ID="ltdesc" runat="server"></asp:Literal></div>
<div class="Other"><asp:Literal ID="ltTinlienquan" runat="server"></asp:Literal></div>
<div class="contents">    
<asp:Literal ID="ltcontent" runat="server"></asp:Literal>
<div style=" text-align:left; padding-bottom:20px ; padding-top:10px">
<asp:Literal ID="ltchiase" runat="server"></asp:Literal>
</div>
<div style=" height:10px"></div>
<div class="list-more-news"  style=" display:none">
<asp:Repeater ID="rpitems2" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintruoc")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html" title="<%#Eval("Title")%>"><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div> 
<div class="list-more-news"  style=" display:none">
<asp:Repeater ID="rpitems" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintieptheo")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html" title="<%#Eval("Title")%>"><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a></div>                                                                                            
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
