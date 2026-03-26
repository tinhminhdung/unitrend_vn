<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMap.ascx.cs" Inherits="VS.E_Commerce.cms.Display.SiteMap.GoogleMap" %>
<div class="inner-content-page" style=" padding-top:10px;">
<script type="text/javascript" src="/cms/Display/SiteMap/Resources/JS/jquery.js"></script>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
<asp:Literal ID="ltjavascript" runat="server"></asp:Literal>
<link href="/cms/display/SiteMap/Resources/css/jstyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">    $(document).ready(function () { ugm_newgmap(); });</script>
<div id="ugm_main">
<div class="ugm_see-all" style="cursor: pointer;">QUAY VỀ TRẠNG THÁI BAN ĐẦU</div>
<div id="ugm_list-l">
    <ul>
        <asp:Literal ID="ltbando" runat="server"></asp:Literal>
    </ul>
</div>
<div id="ugm_map" style="position: relative; background-color: rgb(229, 227, 223); overflow: hidden;">
</div>
</div>
</div>