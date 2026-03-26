<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.News.Detail1" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<div style="display: none">
    <asp:Literal ID="ltcatename" runat="server" Visible="true"></asp:Literal></div>
<uc1:Nav_conten runat="server" ID="Nav_conten" />
<div class="main-content">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="blog-home-title clearfix">
                    <h1 class="article-name">
                        <asp:Literal ID="lttitle" runat="server"></asp:Literal></h1>

                </div>

                <div class="article">

                    <div class="article-info">
                        <p class="blog-info">
                            <asp:Literal ID="ltdate" runat="server"></asp:Literal></p>
                    </div>
                    <div style="clear: both"></div>
                    <div class="News-content">
                        <div>
                            <asp:Literal ID="ltFacebook" runat="server"></asp:Literal></div>
                        <div class="des-news">
                            <asp:Literal ID="ltdesc" runat="server"></asp:Literal></div>
                        <div class="Other">
                            <asp:Literal ID="ltTinlienquan" runat="server"></asp:Literal></div>
                        <div class="contents">
                            <asp:Literal ID="ltcontent" runat="server"></asp:Literal>
                            <div style="text-align: left; padding-bottom: 20px; padding-top: 10px">
                                <asp:Literal ID="ltchiase" runat="server"></asp:Literal>
                            </div>
                            <div style="height: 10px"></div>
                            <div class="list-more-news">
                                <asp:Repeater ID="rpitems2" runat="server">
                                    <HeaderTemplate>
                                        <div class="title-more-news"><%=label("cactintruoc")%></div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div><a href="<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html" title="<%#Eval("Title")%>"><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a></div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="list-more-news">
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
                    <div style="clear: both"></div>
                </div>
            </div>
            <%--<div class="col-md-3">
                <uc1:Lefmenu runat="server" ID="Lefmenu" />
            </div>--%>
        </div>
    </div>
</div>



