<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Lefmenu.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Lefmenu" %>
<div style="clear: both"></div>
<%if (Request["su"] == "Infos" || Request["su"] == "changepass" || Request["su"] == "changinfo" || Request["su"] == "Check" || Request["su"] == "TrackOrder" || Request["su"] == "Listcart")
    {%>
<div class="blog-cata block">
    <h2 class="blog-heading"><i class="fa fa-caret-right"></i> <%=label("l_members") %></h2>
    <div class="blog-cata-content">
        <ul>
            <li class="items-product"><a href="/danh-sach-mua-hang.html">Kiểm tra đơn hàng của bạn</a> </li>
            <li><a href="/thong-tin-thanh-vien.html"><%=label("ttthanhvien") %></a> </li>
            <li><a href="/xem-thong-tin-thanh-vien.html"><%=label("capthanhvien") %></a></li>
            <li><a href="/thay-doi-mat-khau.html"><%=label("thaydoimk") %></a></li>
        </ul>
    </div>
</div>
<%}%>

<%if (Case == "1" || Case == "2" || Request["su"] == "nws")
    { %>
<div class="blog-cata block">
    <h2 class="blog-heading"><i class="fa fa-caret-right"></i> Danh sách tin tức</h2>
    <div class="blog-cata-content">
        <ul>
            <%=MenuNews() %>
        </ul>
    </div>
</div>
<%}%>

<%if (Request["su"] == "Videos")
    { %>
<div class="blog-cata block">
    <h2 class="blog-heading"><i class="fa fa-caret-right"></i> Danh sách video</h2>
    <div class="blog-cata-content Videohome">
        <div class="video-list">
            <div id="video-links">
                <!-- Danh sách video sẽ được thêm bằng JavaScript -->
            </div>
            <div class="pagination" id="pagination">
                <!-- Phân trang sẽ được thêm bằng JavaScript -->
            </div>
        </div>
    </div>
</div>
<%}%>

<%=Videolst() %>
<script>
    $(document).ready(function () {
        var videosPerPage = 10; // Số video trên mỗi trang
        var currentPage = 1;
        var totalPages = Math.ceil(videos.length / videosPerPage);

        function renderVideos(page) {
            $("#video-links").html("");
            var start = (page - 1) * videosPerPage;
            var end = start + videosPerPage;
            var pageVideos = videos.slice(start, end);

            pageVideos.forEach(function (video) {
                $("#video-links").append(
                    `<a href="#" data-video-id="${video.id}" data-title="${video.title}" data-description="${video.desc}">${video.title}</a>`
                );
            });

            $(".video-list a").click(function (e) {
                e.preventDefault();
                var videoId = $(this).data("video-id");
                var videoTitle = $(this).data("title");
                var videoDescription = $(this).data("description");

                $("#main-video").attr("src", "https://www.youtube.com/embed/" + videoId);
                $(".video-title").text(videoTitle);
                $(".video-description").text(videoDescription);
            });
        }

        function renderPagination() {
            $("#pagination").html("");
            for (let i = 1; i <= totalPages; i++) {
                $("#pagination").append(
                    `<button class="${i === currentPage ? "active" : ""}" data-page="${i}">${i}</button>`
                );
            }
            $(".pagination button").click(function () {
                currentPage = parseInt($(this).data("page"));
                renderVideos(currentPage);
                renderPagination();
            });
        }

        renderVideos(currentPage);
        renderPagination();
    });
</script>


<%if (Case == "20" || Case == "21" || Case == "23")
    { %>
<div class="features-container">
    <div class="feature-item">
        <img src="/Resources/2025/spchinhhang.png" alt="Sản phẩm chính hãng">
        <div class="feature-content">
            <h3>SẢN PHẨM CHÍNH HÃNG</h3>
            <p>Hàng mới 100%, xuất xứ chính hãng Uni-Trend</p>
        </div>
    </div>

    <div class="feature-item">
        <img src="/Resources/2025/spchinhhang1.png" alt="Chứng nhận">
        <div class="feature-content">
            <h3>ĐẦY ĐỦ CHỨNG NHẬN</h3>
            <p>CO, CQ, Test Report và giấy tờ cho dự án</p>
        </div>
    </div>

    <div class="feature-item">
        <img src="/Resources/2025/spchinhhang2.png" alt="Giao hàng toàn quốc">
        <div class="feature-content">
            <h3>GIAO HÀNG TOÀN QUỐC</h3>
            <p>Bằng nhiều hình thức vận chuyển tận nơi</p>
        </div>
    </div>

    <div class="feature-item">
        <img src="/Resources/2025/spchinhhang5.png" alt="Bảo hành điện tử">
        <div class="feature-content">
            <h3>BẢO HÀNH ĐIỆN TỬ</h3>
            <p>Tra cứu và quản lý bảo hành điện tử</p>
        </div>
    </div>

    <div class="feature-item">
        <img src="/Resources/2025/spchinhhang4.png" alt="Bảo trì trọn đời">
        <div class="feature-content">
            <h3>BẢO TRÌ TRỌN ĐỜI</h3>
            <p>Đầy đủ linh kiện và phụ kiện chính hãng bảo trì trọn đời</p>
        </div>
    </div>

    <div class="feature-item">
        <img src="/Resources/2025/spchinhhang3.png" alt="Hỗ trợ 24/7">
        <div class="feature-content">
            <h3>TƯ VẤN - HỖ TRỢ 24/7</h3>
            <p>Hỗ trợ trực tiếp hoặc qua điện thoại, Zalo, website</p>
        </div>
    </div>
</div>

<div style="clear: both; height: 10px"></div>

<div class="blog-new block">
    <h2 class="blog-heading">PHỤ KIỆN LIÊN QUAN</h2>
    <asp:Repeater ID="rplienquan" runat="server">
        <ItemTemplate>
            <div class="media products">
                <div class="media-left">
                    <a href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html'><%#MoreAll.MoreImage.Image_width_height_Title_Alt_css("media-object", Eval("ImagesSmall").ToString(), "80", "70", Eval("Name").ToString(), Eval("Name").ToString())%></a>
                </div>
                <div class="media-body">
                    <a href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html'>
                        <h4 class="media-heading"><%#MoreAll.MorePro.Substring_Title(Eval("Name").ToString())%></h4>
                    </a>
                    <span class="media-price"><%#MoreAll.MorePro.FormatMoney(Eval("Price").ToString())%></span>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="blog-new block">
    <h2 class="blog-heading">SẢN PHẨM ĐÃ XEM</h2>
    <asp:Repeater ID="rpdaxem" runat="server">
        <ItemTemplate>
            <div class="media products">
                <div class="media-left">
                    <a href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html'><%#MoreAll.MoreImage.Image_width_height_Title_Alt_css("media-object", Eval("ImagesSmall").ToString(), "80", "70", Eval("Name").ToString(), Eval("Name").ToString())%></a>
                </div>
                <div class="media-body">
                    <a href='/<%#MoreAll.AddURL.ToSlug(Eval("TangName").ToString()) %>_id<%#Eval("ipid")%>.html'>
                        <h4 class="media-heading"><%#MoreAll.MorePro.Substring_Title(Eval("Name").ToString())%></h4>
                    </a>
                    <span class="media-price"><%#MoreAll.MorePro.FormatMoney(Eval("Price").ToString())%></span>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>



<%}%>