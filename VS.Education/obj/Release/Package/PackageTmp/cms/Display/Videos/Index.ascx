<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Videos.Index" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <div class="blog-home-title clearfix">
                    <h1>Thư viện video</h1>
                </div>
                <div class="blog-article clearfix">
                    <div class="Videohome">
                        <div class="video-container">
                            <%=VideoTabVideo() %>
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
