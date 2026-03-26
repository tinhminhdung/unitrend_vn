<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Header" %>
<header class="header">
    <div class="header-top">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <ul class="header-top-right">
                        <li class="box-n"><i class="fa fa-shopping-cart"></i><a href="/gio-hang.html" class="cart-icon"><b><%=Services.SessionCarts.LoadCart() %></b> <%=label("lproducts") %></a></li>
                        <%if (HttpContext.Current.Request.Cookies["Members"] == null) %>
                        <%{%>
                        <li class="box-n"><a href="/Dang-nhap.html"><i class="fa fa-user"></i><%=label("l_login") %></a></li>
                        <p>|</p>
                        <li class="box-n"><a href="/Dang-ky.html"><i class="fa fa-user-plus"></i><%=label("l_register") %></a></li>
                        <%}
                            else
                            {%>
                        <li class="box-n"><a href="/thong-tin-thanh-vien.html"><i class="fa fa-edit"></i><%=label("xinchao") %>, <%= MoreAll.MoreAll.GetCookies("Members").ToString()%></a></li>
                        <li>
                            <asp:LinkButton ID="lnkthoat" runat="server" OnClick="lnkthoat_Click"><i class="fa fa-close"></i> [<%=label("lt_exit") %>]</asp:LinkButton></li>
                        <%}%>

                        <%--   <li class="box-n"><i class="fa fa-language"></i> Ngôn ngữ:  
                        <a href="http://uni-trend.vn"><img src="/Uploads/pic/web/languages/VIE.gif" title="Việt Nam" alt="Việt Nam" style="margin-right:5px;margin-right: 5px; margin-top: -1px;"></a>
                        <a href="https://translate.google.com/translate?sl=auto&tl=zh-en&u=http://uni-trend.vn/"><img src="/Uploads/pic/web/languages/ENG.gif" title="English" alt="English" style="margin-top: -1px;"></a>
                        <a href="https://translate.google.com/translate?sl=auto&tl=zh-CN&u=http://uni-trend.vn/"><img src="/Uploads/pic/web/languages/CHI.gif" title="China " alt="China" style="margin-top: -1px; width: 29px; height: 17px;"></a>
                        </li>--%>

                        <%--<li class="box-n"><i class="fa fa-language"></i><%=label("l_language") %>:  
                           
                            <asp:LinkButton ID="lnkVIE" runat="server" OnClick="lnkVIE_Click"><img src="/Uploads/pic/web/languages/VIE.gif" title="Việt Nam" alt="Việt Nam" style="margin-right:5px;margin-right: 5px; margin-top: -1px;" /></asp:LinkButton>
                            <asp:LinkButton ID="lnkEnglish" runat="server" OnClick="lnkEnglish_Click"><img src="/Uploads/pic/web/languages/ENG.gif" title="English" alt="English" style="margin-top: -1px;" /></asp:LinkButton>
                            <asp:LinkButton ID="lnkchina" runat="server" OnClick="lnkchina_Click"><img src="/Uploads/pic/web/languages/CHI.gif" title="China " alt="China" style="margin-top: -1px; width: 29px; height: 17px;" /></asp:LinkButton>
                        </li>--%>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="header-content">
        <div class="container">
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <%=MoreAll.Banner.Banners() %>
                </div>
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <div class="header-content-right">
                        <div class="row">
                            <div class="col-md-7 col-sm-12 col-xs-12">
                                <div class="header-search">
                                    <div id="header-search search-container">

                                            <asp:TextBox ID="txtkeyword" ClientIDMode="Static" CssClass="header-search-input" runat="server"></asp:TextBox>
                                            <asp:LinkButton ID="lnksearch" CssClass="header-search-btn" runat="server" OnClick="lnksearch_Click"><span><%=label("tim") %></span></asp:LinkButton>
                                            <div class="suggestions" id="suggestions-list"></div>
                                    </div>
                                </div>
                                <div class="hidden-lg hidden-md col-sm-2 col-xs-2">
                                    <div class="menu-button">
                                        <span class="fa fa-bars fa-2x"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6 col-xs-6 no-padding">
                                <div class="header-hotline">
                                    Hotline: <strong><%=MoreAll.Other.Giatri("Hotline")%></strong>
                                </div>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-4">
                                <div class="header-cart">
                                    <a href="/gio-hang.html" class="cart-icon"><b><%=Services.SessionCarts.LoadCart() %></b> <%=label("lproducts") %></a>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</header>
<div class="Mobile">
    <nav>
        <ul data-breakpoint="1025" class="flexnav">
            <li><a class="<%=index() %>" href="/"><%=label("l_home") %></a></li>
            <li class="level0 "><a>Giới thiệu</a>
                <ul>
                    <%=MenuGioithieu() %>
                    <a href="/lien-he.html"><%=label("l_contact") %></a>
                </ul>
            </li>
            <li>
                <a href="/san-pham.html"><%=label("lproducts") %></a>
                <ul><%=MenuPro() %> </ul>
            </li>
            <li><a href="/bao-gia.html">Báo giá</a></li>
            <li><a href="http://baohanh.nhatminhesc.com/" target="_blank">Bảo hành</a></li>
            <li>
                <a>Thư viện</a>
                <ul>
                    <li><a href="/tin-tuc.html"><%=label("l_news") %></a></li>
                    <li><a href="/video.html">Video</a></li>
                    <li><a href="/tai-du-lieu.html">Download</a></li>
                </ul>
            </li>

        </ul>
    </nav>
</div>
<div class="Menutop Destop">
    <div class="container">
        <div class="row">
            <div class="verticalmenu">
                <div class="verticalcontent">
                    <ul class="list-child">
                        <li class="level0 "><a class="<%=index() %>" href="/"><%=label("l_home") %></a></li>
                        <li class="level0 "><a>Giới thiệu</a>
                            <ul class="submenu submenu2">
                                <%=MenuGioithieu() %>
                                <li><a href="/lien-he.html"><%=label("l_contact") %></a></li>
                            </ul>
                        </li>
                        <li class="level0 ">
                            <a href="/san-pham.html"><%=label("lproducts") %></a>
                            <ul class="submenu sub02" style="padding-top: 0px;"><%=MenuPro() %> </ul>
                        </li>
                        <li class="level0 "><a href="/bao-gia.html">Báo giá</a></li>
                        <li class="level0 "><a href="http://baohanh.nhatminhesc.com/" target="_blank">Bảo hành</a></li>

                        <li class="level0 " style="border: none">
                            <a>Thư viện</a>
                            <ul class="submenu submenu3" style="padding-top: 0px;">
                                <li><a href="/tin-tuc.html"><%=label("l_news") %></a></li>
                                <li><a href="/video.html">Video</a></li>
                                <li><a href="/tai-du-lieu.html">Download</a></li>
                            </ul>
                        </li>

                    </ul>
                </div>
            </div>
            <li class="timkiem">
                <asp:TextBox OnLoad="Text_Load" ID="txtkeyword1"  ClientIDMode="Static" Style="width: 218px!important" class="header-search-input" runat="server"></asp:TextBox>
                <asp:LinkButton ID="lnksearch1" CssClass="header-search-btn1" runat="server" OnClick="lnksearch1_Click"><span><%=label("tim") %></span></asp:LinkButton>
             <div class="suggestions" id="suggestions-list1"></div>
            </li>
            <li class="giohang">
                <div class="grid__item  large--one-sixth medium-down--hide">
                    <div class="group-icons ">
                        <div class="group-icons2">
                            <div class="header-carts">
                                <a href="/gio-hang.html" class="site-header__cart-toggle js-drawer-open-right" aria-controls="CartDrawer" aria-expanded="false">
                                    <span class="fa fa-shopping-cart "></span>
                                    <span class="cart-text"><%=label("Giohang") %></span>
                                    <span id="CartCount"><%=Services.SessionCarts.LoadCart() %>  
						</span>
                                    <%=label("lproducts") %>
                                    <%--<span id="CartCost">0₫</span> --%>
					</a>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </div>
</div>



