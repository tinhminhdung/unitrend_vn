<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Footer" %>
<footer class="footer">
	<div class="footer-top">
		<div class="container">
			<div >
			<div class="row">
				<div class="col-md-4 col-sm-6 hidden-xs">
					<h4><%=label("dangkytin")%></h4>
				</div>
				<div class="col-md-5 col-sm-6">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="tbEmailNewsletter" ValidationGroup="emaildk" class="input-text required-entry"  runat="server"></asp:TextBox>
                <asp:Button ID="bttheodoi" onclick="bttheodoi_Click" class="btn-cart" ValidationGroup="emaildk"  runat="server" />
                <asp:RegularExpressionValidator ID="RequiredFieldValidator4" ValidationGroup="emaildk"  runat="server" ControlToValidate="tbEmailNewsletter"  ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  meta:resourcekey="valRegExResource1"></asp:RegularExpressionValidator>
                </ContentTemplate>
                </asp:UpdatePanel>
                </div>
				<div class="col-md-3 hidden-sm hidden-xs foo-phone">
					<i class="fa fa-microphone"></i> <%=MoreAll.Other.Giatri("Hotline")%>
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
						<div style="height:20px;"></div>
						<div>Bản quyền thuộc về Uni-Trend.vn</div>
                    </div>
				</div>
			</div>
		</div>
	</div>
</footer>
<div id="back-top"><i class="fa fa-angle-up"></i></div>

<a style="display:none" href='http://dichvulamwebsite.com'>dichvulamwebsite.com</a>



<div style="overflow: hidden; display: none;">	  
<div itemscope="" itemtype="http://schema.org/Recipe"><img alt="UNI-TREND VIET NAM" itemprop="image" src="http://uni-trend.vn/Resources/logosao.jpg" style="float: left; display: block; clear: both;" width="60" /><br />
<span itemprop="name" style="float:left;clear:left">UNI-TREND VIET NAM</span>
<div class="keng" itemprop="aggregateRating" itemscope="" itemtype="http://schema.org/AggregateRating" style="float:left;clear:left"><span itemprop="ratingValue">85</span>/<span itemprop="bestRating">100</span><span itemprop="ratingCount">100</span> bình chọn</div>
</div>

</div>


