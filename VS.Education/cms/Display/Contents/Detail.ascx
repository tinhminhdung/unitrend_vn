<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Contents.Detail" %>
<div class="span9">
	<div class="row-fluid introduction">
		<div class="row-fluid title-catpro-left bold uppercase">
			<span>
    <asp:Literal ID="ltcatename" runat="server"></asp:Literal></span>
		</div>
		<div class="row-fluid content-detail-new">
			<div class="row-fluid sub-content-detail-new">

<div class="News-content">
<div class="title"><h1><asp:Literal ID="lttitle" runat="server"></asp:Literal></h1></div>
<div class="des-news"><asp:Literal ID="ltdesc" runat="server"></asp:Literal></div>
<div class="Other"><asp:Literal ID="ltTinlienquan" runat="server"></asp:Literal></div>
<div class="contents">    
<asp:Literal ID="ltcontent" runat="server"></asp:Literal>
<div style=" text-align:left; padding-bottom:20px ; padding-top:10px">
<asp:Literal ID="ltchiase" runat="server"></asp:Literal>
</div>

<div class="list-more-news">
<asp:Repeater ID="rpitems2" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintruoc")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href='/<%#Eval("Url_Name")%>.html'><%#Eval("Title") %></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div> 
<div class="list-more-news">
<asp:Repeater ID="rpitems" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintieptheo")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href='/<%#Eval("Url_Name")%>.html'><%#Eval("Title") %></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div>
 </div>
</div>



</div>
</div>
</div>
</div>
