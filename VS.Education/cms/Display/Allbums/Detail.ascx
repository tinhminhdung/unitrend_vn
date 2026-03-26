<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Allbums.Detail" %>
<link href="/cms/Display/Allbums/FlexSlider/css/flexslider.css" rel="stylesheet" type="text/css" />
   
<div class="right-home">
<div class="rows-home">
<p class="linktag"><a href="/">Trang chủ </a>/ <span><asp:Literal ID="ltcatename" runat="server"></asp:Literal></span></p>
<div class="region region-content">
  <div class="block block-system" id="block-system-main">
    <div class="content">
<div id="box_center">
    <div id="bor_centers">
     <h1><asp:Literal ID="lttitle" runat="server"></asp:Literal></h1>
       <div style="width: 100%">
        <section class="slider" style="width: 100%">
        <div id="slidert" class="flexslider">
            <ul class="slidesv">
               <%=ViewslideMax() %>
            </ul>
        </div>
     <div id="carouselp" class="flexslider">
          <ul class="slidesv thumnai">
            <%=ViewslideMin() %>
          </ul>
        </div>
      </section>
    </div>
    </div>
    </div>
</div>
</div>

</div>
</div>
</div>
  <%--  <script src="/cms/Display/Allbums/FlexSlider/js/flexslider.js" type="text/javascript"></script>
   <script type="text/javascript">
       $(function () {
           SyntaxHighlighter.all();
       });
       $(window).load(function () {
           $('#carouselp').flexslider({
               animation: "slide",
               controlNav: false,
               animationLoop: false,
               slideshow: false,
               itemWidth: 120,
               itemMargin: 6,
               asNavFor: '#slidert'
           });
           $('#slidert').flexslider({
               animation: "slide",
               controlNav: false,
               animationLoop: false,
               slideshow: false,
               sync: "#carouselp",
               start: function (slidert) {
                   $('body').removeClass('loading');
               }
           });
       });
    </script>--%>