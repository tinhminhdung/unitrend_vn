<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Download.Detail" %>

<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <div class="blog-home-title clearfix">
                    <h1>Thư viện download</h1>
                </div>
                <div class="blog-article clearfix">



                    <div class="News-content">
                        <div class="title">
                            <asp:Literal ID="lttitle" runat="server"></asp:Literal></div>
                        <div class="des-news">
                            <asp:Literal ID="ltdesc" runat="server"></asp:Literal></div>
                        <div class="chitiettf" style="font-size: 12px; font-weight: bold; float: right; color:#428bca">
                            <asp:Literal ID="lttaifile" runat="server"></asp:Literal></div>
                        <div class="contents">
                            <asp:Literal ID="ltcontent" runat="server"></asp:Literal>
                            <div style="height: 10px"></div>
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


