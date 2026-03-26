<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sitemap.ascx.cs" Inherits="VS.E_Commerce.cms.Display.SiteMap.Sitemap" %>
<link href="/cms/display/SiteMap/Resources/css/jquery.treeview.css" rel="stylesheet" type="text/css" />
<script src="/cms/display/SiteMap/Resources/js/lib/jquery.cookie.js" type="text/javascript"></script>
<script src="/cms/display/SiteMap/Resources/js/jquery.treeview.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#tree").treeview({
            collapsed: true,
            animated: "medium",
            control: "#sidetreecontrol",
            persist: "location"
        });
    })
</script>
<div id="mdlsitemap">
    <div id="sidetreecontrol">
        <a href="?#">Collapse All</a> | <a href="#">Expand All</a></div>
    <ul id="tree">
        <asp:Repeater ID="rpitems" runat="server">
            <ItemTemplate>
			<li><a href="/homepage.aspx"><%=label("l_home")%></a></li>
                <li><a target='<%#Eval("Styleshow") %>' href='<%#link("",Eval("Name").ToString(),Eval("Type").ToString(),Eval("Link").ToString()) %>' class="asmn">
                    <%#Eval("Name") %>
                </a>
                    <%#sub(Eval("id").ToString(), Eval("Type").ToString(), Eval("Link").ToString(), "asubsm", Eval("Styleshow").ToString())%>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
