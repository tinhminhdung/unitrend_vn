<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Footer" %>
<footer class="footer">
    <div class="footer-top">
        <div class="container">
            <div>
                <div class="row">
                    <div class="col-md-4 col-sm-6 hidden-xs">
                        <h4><%=label("dangkytin")%></h4>
                    </div>
                    <div class="col-md-5 col-sm-6">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="tbEmailNewsletter" ValidationGroup="emaildk" class="input-text required-entry" runat="server"></asp:TextBox>
                                <asp:Button ID="bttheodoi" OnClick="bttheodoi_Click" class="btn-cart" ValidationGroup="emaildk" runat="server" />
                                <asp:RegularExpressionValidator ID="RequiredFieldValidator4" ValidationGroup="emaildk" runat="server" ControlToValidate="tbEmailNewsletter" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="valRegExResource1"></asp:RegularExpressionValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-3 hidden-sm hidden-xs foo-phone">
                        <i class="fa fa-microphone"></i><%=MoreAll.Other.Giatri("Hotline")%>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="footer-content">
        <div class="container">
            <div class="row">
                <div class="col-lg-4 col-md-6 col-sm-6 col-xs-6">
                    <div class="footer-info">
                        <asp:Literal ID="ltfootercontent" runat="server"></asp:Literal>
                    </div>
                </div>
                <asp:Repeater ID="rpcates" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 col-sm-6 col-xs-6">
                            <div class="footer-info">
                                <h3><%#Eval("Name")%></h3>
                                <ul class="foo-list">
                                    <asp:Repeater ID="Repeater2" DataSource='<%#FooterInCate(Eval("id").ToString()) %>' runat="server">
                                        <ItemTemplate>
                                            <li><a href="/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>.html"><i class="icons icon-right-dir"></i><%#Eval("Title")%></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="col-lg-4 col-md-6 col-sm-6 col-xs-6">
                    <div class="footer-info">
                        <h3>KẾT NỐI VỚI CHÚNG TÔI</h3>
                        <ul class="foo-social">
                            <%=Advertisings.Ad_vertisings.Advertisings("88") %>
                        </ul>
                        <div style="height: 20px;"></div>
                        <div  class="sohuu1">Website thuộc sở hữu và vận hành bởi</div>
                        <div  class="sohuu2">CÔNG TY TNHH GIẢI PHÁP ĐIỆN TỬ NHẬT MINH</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</footer>
<div id="back-top"><i class="fa fa-angle-up"></i></div>




<div style="overflow: hidden; display: none;">
    <div itemscope="" itemtype="http://schema.org/Recipe">
        <img alt="UNI-TREND VIET NAM" itemprop="image" src="http://uni-trend.vn/Resources/logosao.jpg" style="float: left; display: block; clear: both;" width="60" /><br />
        <span itemprop="name" style="float: left; clear: left">UNI-TREND VIET NAM</span>
        <div class="keng" itemprop="aggregateRating" itemscope="" itemtype="http://schema.org/AggregateRating" style="float: left; clear: left"><span itemprop="ratingValue">85</span>/<span itemprop="bestRating">100</span><span itemprop="ratingCount">100</span> bình chọn</div>
    </div>

</div>

 

# Nút Zalo Góc Phải Website (Có Preview)

## Preview

<div style="position:relative;height:220px;background:#f5f7fb;border-radius:16px;overflow:hidden;border:1px solid #ddd;">

<div style="position:absolute;right:20px;bottom:20px;display:flex;align-items:center;gap:10px;background:linear-gradient(135deg,#0084ff,#00a6ff);padding:10px 18px;border-radius:60px;color:#fff;font-family:Arial,sans-serif;font-weight:600;box-shadow:0 8px 25px rgba(0,132,255,0.35);">
    <div style="width:42px;height:42px;background:#fff;border-radius:50%;display:flex;align-items:center;justify-content:center;">
        <img src="https://upload.wikimedia.org/wikipedia/commons/9/91/Icon_of_Zalo.svg" width="26">
    </div>
    Chat Zalo
</div>

</div>


<!-- Nút Zalo Góc Phải -->
<a href="https://zalo.me/<%=MoreAll.Other.Giatri("ZALO")%>" class="zalo-float" target="_blank" aria-label="Chat Zalo">
    <div class="zalo-icon">
        <img src="https://upload.wikimedia.org/wikipedia/commons/9/91/Icon_of_Zalo.svg" alt="Zalo">
    </div>
    <span>Chat Zalo</span>
</a>

<style>
/* Zalo Floating Button */
.zalo-float{
    position:fixed;
    right:20px;
    bottom:25px;
    z-index:9999;

    display:flex;
    align-items:center;
    gap:10px;

    background:linear-gradient(135deg,#0084ff,#00a6ff);
    color:#fff;
    text-decoration:none;

    padding:5px 5px;
    border-radius:60px;

    box-shadow:0 8px 25px rgba(0,132,255,0.35);
    transition:all .3s ease;

    font-family:Arial,sans-serif;
    font-size:15px;
    font-weight:600;

    animation:zaloRing 1.5s infinite;
}

.zalo-float:hover{
    transform:translateY(-3px) scale(1.03);
    box-shadow:0 12px 30px rgba(0,132,255,0.45);
}

.zalo-icon{
    width:42px;
    height:42px;
    background:#fff;
    border-radius:50%;

    display:flex;
    align-items:center;
    justify-content:center;

    overflow:hidden;
}

.zalo-icon img{
    width:26px;
    height:26px;
    object-fit:contain;
}

/* Hiệu ứng rung nhẹ */
@keyframes zaloRing{
    0%{transform:scale(1);} 
    50%{transform:scale(1.06);} 
    100%{transform:scale(1);} 
}

/* Mobile */
@media(max-width:768px){
    .zalo-float{
        right:15px;
        bottom:20px;
        padding:8px 14px;
        font-size:14px;
    }

    .zalo-icon{
        width:38px;
        height:38px;
    }
}
</style>
