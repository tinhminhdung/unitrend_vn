<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Allbums.Category" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<div class="right-home">
<div class="rows-home">
<p class="linktag"><a href="/">Trang chủ </a>/ <span><asp:Literal ID="ltcatename" runat="server"></asp:Literal></span></p>
<ul class="Album ">
<asp:Repeater ID="rpcates" runat="server">
<ItemTemplate>
<li class=" abcolmd">
<div class="abitem">
<div class="img">
<a title="<%#(Eval("Title").ToString())%>" href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html'><%#MoreAll.MoreImage.Image_width_height_Title_Alt(Eval("ImagesSmall").ToString(), "285", "106", Eval("Title").ToString(), Eval("Title").ToString())%><div class="imghover"></div></a> </div>
<div class="tiemtitle">
    <h2><a title="<%#(Eval("Title").ToString())%>" href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html'><%#Eval("Title") %></a></h2>
</div>
</div>
</li>
</ItemTemplate>
</asp:Repeater>
   </ul>
<asp:Literal ID="lterr" runat="server"></asp:Literal>
<div style="clear: both;"></div>
<div class="pager" style="margin-left:10px; margin-right:10px;color: #999;">
<cc1:CollectionPager id="CollectionPager1" runat="server"  BackNextDisplay="HyperLinks" BackNextLocation="Split"
BackText="◄" ShowFirstLast="True" ResultsLocation="None" PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"  IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;color:red" LabelText="" LastText="Cuối cùng" NextText="►" PageNumbersDisplay="Numbers" 
ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="FONT-WEIGHT: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="&nbsp;">
</cc1:CollectionPager></div>

 
 </div>
 </div>