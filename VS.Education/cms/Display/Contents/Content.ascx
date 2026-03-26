<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Content.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Contents.Content" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<link href="/cms/display/Contents/Resources/css/StyleSheet.css" rel="stylesheet" type="text/css" />
<%--<script type="text/javascript" src="/cms/display/Contents/Resources/JS/jquery.js"></script>--%>
<script type="text/javascript" src="/cms/display/Contents/Resources/js/ddaccordion.js"></script>
<script type="text/javascript">
    ddaccordion.init({ headerclass: "mypets", contentclass: "thepet", revealtype: "click", mouseoverdelay: 200, collapseprev: true, defaultexpanded: [0], onemustopen: false, animatedefault: false, scrolltoheader: false, persiststate: true, toggleclass: ["", "openpet"], togglehtml: ["none", "", ""], animatespeed: "fast", oninit: function (expandedindices) { }, onopenclose: function (header, index, state, isuseractivated) { } })
</script>
<div class="span9">
	<div class="row-fluid introduction">
		<div class="row-fluid title-catpro-left bold uppercase">
			<span>
    <asp:Literal ID="ltcatename" runat="server"></asp:Literal></span>
		</div>
		<div class="row-fluid content-detail-new">
			<div class="row-fluid sub-content-detail-new">


<asp:MultiView ID="MultiView1" runat="server">
<%--Hiển thị trên cùng từng trang riêng biệt Type=0--%>
<asp:View ID="vwpage" runat="server">
<div class="News-content">
    <div class="title"><asp:Literal ID="lttitle" runat="server"></asp:Literal></div>
    <div class="contents"><asp:Literal ID="ltcontent" runat="server"></asp:Literal></div>
    
    <div class="list-more-news">
<asp:Repeater ID="rpOtherPage" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintruoc")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="<%#Eval("Url_Name")%>.html" title="<%#Eval("Title")%>"><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div> 



    
</asp:View>

<%--Hiển thị trên cùng 1 trang Type=1--%>
<asp:View ID="vwpages" runat="server">
    <div class="News-content">
        <asp:Repeater ID="rppages" runat="server">
            <ItemTemplate>
                <div class="title"><%#Eval("Title") %></div>
                <div class="contents"><%#Eval("Contents") %></div>
                <div class="textright"><span class="gototop"></span><a  href='javascript:window.scrollTo(0,0)'>Gotop </a></div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:View>
                
<%--Hiển thị theo danh sách  Type=2--%>
<asp:View ID="vwpagetitlelist" runat="server">
        <asp:Repeater ID="rp_pagetitlelist" runat="server">
            <ItemTemplate>
                <div class="mypets" style="border-bottom:#eee solid 1px"><span class="type2title"><%#Eval("Title") %></span></div>
                <div class="thepet" style="padding-left:10px; padding-top:10px">
                    <%#Eval("Contents") %>
                </div>
            </ItemTemplate>
        </asp:Repeater>
</asp:View>
                
<%--Hiển thị theo danh sách Collap Type=3--%>
<asp:View ID="vwpageCollap" runat="server">
    <script language="javascript">
        function showhidediv(name) {
            var obj = document.getElementById(name);
            if (obj.style.display == "")
                obj.style.display = "none";
            else
                obj.style.display = ""
        }
    </script>
        <asp:Repeater ID="rpPageCollap" runat="server">
            <ItemTemplate>
                <div class="News-content">
                    <div class="titleType3"><a  href="javascript:showhidediv('Collap<%#Eval("ID") %>');"><%#Eval("Title") %> </a></div>
                    <div class="contents" id='Collap<%#Eval("ID") %>' style="display: none"><%#Eval("Contents")%> 
                    <div class="textright"><span class="gototop"></span><a  href='javascript:window.scrollTo(0,0)'>Gotop </a></div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
</asp:View>
                            
<%--Hiển thị theo danh sách tin (List tin) 4--%>
<asp:View ID="ViewListNews" runat="server">
    <div class="News">
    <asp:Repeater ID="rpcates" runat="server">
    <ItemTemplate>
    <div class="item-news">
        <a href='/<%#Eval("Url_Name")%>.html'><%#MoreAll.MoreNews.ImageDisplay(Eval("Images").ToString())%></a>
        <div class="title-news"><a href='/<%#Eval("Url_Name")%>.html'><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a></div>
        <div class="des-news"><%#MoreAll.MoreNews.Substring_Mota(Eval("Title").ToString())%></div>
        <div  class="chitiet"><a href="/<%#Eval("Url_Name")%>.html"><%=label("l_viewdetail")%></a></div>
    </div>
    </ItemTemplate>
    </asp:Repeater>
        <asp:Literal ID="lterr" runat="server"></asp:Literal>
        <div class="pager" style="margin-left:10px; margin-right:10px;color: #999;">
        <cc1:CollectionPager id="CollectionPager1" runat="server"  BackNextDisplay="HyperLinks" BackNextLocation="Split"
        BackText="◄" ShowFirstLast="True" ResultsLocation="None" PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"  IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;color:red" LabelText="" LastText="Cuối cùng" NextText="►" PageNumbersDisplay="Numbers" 
        ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="FONT-WEIGHT: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="&nbsp;">
        </cc1:CollectionPager></div>
    </div>
</asp:View>
</asp:MultiView>

<div style=" clear:both; height:10px;"></div> 
<div class="OtherChuyenMuc">  
<asp:Repeater ID="rpchildcate" runat="server">
    <HeaderTemplate>
        <div style="font-size: 14px; padding: 10px 0px; color: black;">
        <div style="padding-left: 15px;">
        </div>
    </HeaderTemplate>
    <ItemTemplate>
           <div><a href='<%#MenuLink(Eval("Type").ToString(),Eval("ID").ToString(),Eval("Link").ToString(),Eval("Url_Name").ToString(),Eval("Styleshow").ToString()) %>'> <%#Eval("Name") %></a></div> 
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
</div>


</div>
</div>
</div>
</div>
