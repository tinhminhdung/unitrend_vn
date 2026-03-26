<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Download.Category" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<div class="main-content">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="blog-home-title clearfix timkiemdow">
                    <div class="col-md-3">
                        <h1>Thư viện download</h1>
                    </div>
                    <div class="col-md-9">
                        <div class="search-containerdo">
                            <asp:TextBox ID="txtkeywordDL" runat="server" CssClass="search-input" Placeholder="Tìm kiếm..."></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" CssClass="search-btn" Text="TÌM KIẾM" OnClick="btnSearch_Click" />
                            <asp:DropDownList ID="ddlcategories" runat="server" CssClass="search-dropdown">
                                <asp:ListItem Text="Tất cả tài liệu - Phần mềm" Value="all"></asp:ListItem>
                                <asp:ListItem Text="Phần mềm" Value="software"></asp:ListItem>
                                <asp:ListItem Text="Tài liệu" Value="documents"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="blog-article clearfix">

                    <div class="News" style="padding-top: 0px; margin-top: 0px">
                        <asp:Repeater ID="rpcates" runat="server">
                            <ItemTemplate>
                                <div class="item-news">
                                    <a target="_blank" href="/cms/display/Download/Defaul.aspx?id=<%#Eval("ID") %>"><%#Image_cate(Eval("icid").ToString())%></a>
                                    <div class="title-news"><a target="_blank" href="/cms/display/Download/Defaul.aspx?id=<%#Eval("ID") %>"><%#(Eval("Title").ToString())%></a></div>
                                    <div class="des-news"><%#(Eval("Brief"))%></div>
                                    <div class="des-news">
                                        <span style="float: left; color: #6087fc;">
                                            <img src="/Resources/2025/File2.png" style="width: 30px; border: none; margin-right: 4px;" /><span style="float: left; padding-top: 5px;">1 file(s)</span></span>
                                        <span style="float: left; color: #6087fc; margin-left: 20px;">
                                            <img src="/Resources/2025/File3.png" style="width: 30px; border: none; margin-right: 4px;" /><span style="float: left; padding-top: 5px;"><%#getKichThuoc(Eval("Images").ToString())%></span></span>
                                    </div>
                                    <div class="chitiet canccan"><a target="_blank" href="/cms/display/Download/Defaul.aspx?id=<%#Eval("ID") %>"><i style="font-size: 26px;" class="fa fa-download"></i></a></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:Literal ID="lterr" runat="server"></asp:Literal>
                    <div class="pager" style="margin-left: 10px; margin-right: 10px; color: #999;">
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                            BackText="◄" ShowFirstLast="True" ResultsLocation="None" PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;color:red" LabelText="" LastText="Cuối cùng" NextText="►" PageNumbersDisplay="Numbers"
                            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="FONT-WEIGHT: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="&nbsp;">
                        </cc1:CollectionPager>
                    </div>

                </div>
            </div>

        </div>
    </div>
</div>





