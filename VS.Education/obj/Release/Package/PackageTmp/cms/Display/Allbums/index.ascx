<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="index.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Allbums.index" %>
<asp:Repeater ID="rpcates" runat="server">
<ItemTemplate>
 <div class="nhomnhe"><h2 class="title"><%#MoreAll.MorePro.Substring_Title(Eval("Name").ToString())%></h2></div> 
 <div style=" clear:both"></div>
   <ul class="Album ">
         <asp:Repeater ID="Repeater2" DataSource='<%#AlbumInCate(Eval("id").ToString()) %>' runat="server">
        <ItemTemplate>
        <li class=" abcolmd">
<div class="abitem">
<div class="img">
<a title="<%#(Eval("Title").ToString())%>" href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html'><%#MoreAll.MoreImage.Image_width_height_Title_Alt(Eval("ImagesSmall").ToString(), "140", "89", Eval("Title").ToString(), Eval("Title").ToString())%><div class="imghover"></div></a> </div>
<div class="tiemtitle">
    <h2><a title="<%#(Eval("Title").ToString())%>" href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html'><%#Eval("Title") %></a></h2>
</div>
</div>
</li>
</ItemTemplate>
    </asp:Repeater>
      </ul>
       <div style=" clear:both"></div>
</ItemTemplate>
</asp:Repeater>

