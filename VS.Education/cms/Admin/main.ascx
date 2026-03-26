<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="main.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.main" %>
<%@ Register Src="u_admin_hr.ascx" TagName="u_admin_hr" TagPrefix="uc1" %>
<%@ Register Src="u_admin_ftr.ascx" TagName="u_admin_ftr" TagPrefix="uc2" %>

<uc1:u_admin_hr ID="U_admin_hr1" runat="server" />
<div class="Menu Menus">
    <ul>
        <li>
            <a>CÀI ĐẶT HỆ THỐNG</a>
            <ul>
                <li>
                    <asp:LinkButton ID="lnksettings"  runat="server" OnClick="lnksettings_Click"><%=label("lt_systemmanagement")%></asp:LinkButton></li>
                 <li><a class='linkmainmenu'  href='?u=set&su=CuocPhiVanChuyen'>Cước phí vận chuyển</a></li>
               <%-- <li>
                    <asp:LinkButton ID="lnkmenuchinh"  runat="server" OnClick="lnkmenuchinh_Click">Cước phí vận chuyển </asp:LinkButton></li>--%>
                <li>
                    <asp:LinkButton ID="lnkthongtin"  runat="server" OnClick="lnkthongtin_Click">Thông tin chân trang </asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnkWebAnalytics"  runat="server" OnClick="lnkWebAnalytics_Click">Biểu đồ thống kê</asp:LinkButton></li>
            </ul>
        </li>
        <li>
            <a>QUẢN LÝ SẢN PHẨM
            </a>
            <ul>
                <li>
                    <li><a href="admin.aspx?u=pro&su=items">Danh sách sản phẩm</a></li>
                <li><a href="admin.aspx?u=pro&amp;su=pro">Phân loại sản phẩm</a></li>
                <li><a href="admin.aspx?u=pro&amp;su=thuoctinhsosanh">Thuộc tính so sánh</a></li>
              <%--  <li><a href="?u=pro&amp;su=ManagementPrice">Bảng giá Trọng lượng</a></li>--%>
             <%--   <li><a href="?u=pro&amp;su=Manufacturer">Thương hiệu</a></li>
                <li><a href="?u=pro&amp;su=ThoiGianBaoHanh">Thời gian bảo hành</a></li>--%>
            </ul>
        </li>

        <li>
            <a>QUẢN LÝ ĐƠN HÀNG
            </a>
            <ul>
                <li><a href="admin.aspx?u=carts">Đơn đặt hàng</a></li>
                <li><a class='Menu_title' href='?u=BaoGia'>Yêu cầu báo giá</a></li>
                <li><a class='Menu_title' href='?u=tuvan'>Yêu cầu tư vấn</a></li>
            </ul>
        </li>
        <li><asp:LinkButton ID="ltthanhvien"  runat="server" OnClick="ltthanhvien_Click">QUẢN LÝ THÀNH VIÊN</asp:LinkButton></li>
        <li>
            <a>QUẢN LÝ THƯ VIỆN
            </a>
            <ul>
                <li><asp:LinkButton ID="lnknew"  runat="server" OnClick="lnknew_Click">Tin tức</asp:LinkButton></li>
                  <li><a href="admin.aspx?u=Video&su=items">Video</a></li>
                <li><asp:LinkButton ID="lnkGioithieu"  runat="server" OnClick="lnkGioithieu_Click">Giới thiệu</asp:LinkButton></li>
                <li><asp:LinkButton ID="lnkDownloadFile"  runat="server" OnClick="lnkDownloadFile_Click">Tài liệu - Download</asp:LinkButton></li>
            </ul>
        </li>
        <li>
            <a>THÔNG TIN TIỆN ÍCH
            </a>
            <ul>

                <li><asp:LinkButton ID="lnklienhe"  runat="server" OnClick="lnklienhe_Click">Liên hệ</asp:LinkButton></li>
                    <li><asp:LinkButton ID="lnkAdvertisings"  runat="server" OnClick="lnkAdvertisings_Click">Hình ảnh – Quảng cáo </asp:LinkButton></li>
            </ul>
        </li>

    </ul>
</div>
<div style="clear: both"></div>
<div style="padding: 5px;">
    <asp:PlaceHolder ID="phcontrol" runat="server"></asp:PlaceHolder>
</div>

<div style="display: none">
                    <asp:LinkButton ID="lnkpro"  runat="server" OnClick="lnkpro_Click">Danh sách sản phẩm</asp:LinkButton></li>
    <asp:LinkButton ID="lnkTienich" Visible="false"  runat="server" OnClick="lnkTienich_Click">Modul - <%=label("I_Utilities")%></asp:LinkButton>
    <asp:LinkButton ID="lnkMarketing"  runat="server" OnClick="lnkMarketing_Click">Modul - Marketing</asp:LinkButton>
</div>
