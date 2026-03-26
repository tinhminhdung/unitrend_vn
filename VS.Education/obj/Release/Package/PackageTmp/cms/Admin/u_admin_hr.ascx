<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_admin_hr.ascx.cs"  Inherits="VS.E_Commerce.cms.Admin.u_admin_hr" %>
<%--<div id="VStop">
    <div class="VSTop_Left_One">
        <a href="admin.aspx">VS.Manager</a>
    </div>
    <div class="VSTop_Left_Two">
        <span class="info">Xin chào : <strong>
            <asp:Literal ID="ltadmin" runat="server"></asp:Literal></strong></span>
        <div class="lang">
            <%=label("l_language")%>:
            <asp:Repeater ID="rplangs" runat="server" OnItemCommand="rplangs_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" CssClass='<%#langcss(Eval("VLAN_ID").ToString()) %>'
                        CommandName="change" CommandArgument='<%#Eval("VLAN_ID")%>' runat="server"><%#Eval("VLAN_ID")%></asp:LinkButton></ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="VSTop_Right">
        <div class="mail-top">
            <div class="Header_top">
                <div class="new-cart">
                    <a href="admin.aspx?u=pro&su=carts">
                        <asp:Literal ID="ltProduct_Carts" runat="server"></asp:Literal></a></div>
                <div class="new-mail">
                    <a href="admin.aspx?u=Contacts">
                        <asp:Literal ID="ltcontacts" runat="server"></asp:Literal></a></div>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkdangxuat_Click"><span class="bt_logout" title="Thoát"></span></asp:LinkButton>
            </div>
        </div>
    </div>
</div>
<div class="linde">
</div>--%>


 <header>
        <div class="logo">
            <span class="uni-t"><a href="/admin.aspx"><img style=" width: 100px; " src="/Resources/2025/log1.png" /></a></span>
            <span class="title">HỆ THỐNG QUẢN TRỊ WEBSITE UNI-TREND VIỆT NAM</span>
        </div>
        <div class="top-menu">
            <ul>
                <li><a href="/" target="_blank"><img src="/Resources/2025/1.png" /><br />Xem website</a></li>
                <li><a href="/admin.aspx?u=carts"><span style="color:red;padding-right: 3px;float: left">(<asp:Label ID="lt_Carts" runat="server" ForeColor="red"></asp:Label>)</span><img src="/Resources/2025/2.png" /><br />Đơn hàng </a></li>
                <li><a href="/admin.aspx?u=BaoGia"><span style="color:red;padding-right: 3px;float: left">(<asp:Label ID="lt_baogia" runat="server" ForeColor="red"></asp:Label>)</span><img src="/Resources/2025/3.png" /><br />Báo giá </a></li>
                <li><a href="/admin.aspx?u=tuvan"><span style="color:red;padding-right: 3px;float: left">(<asp:Label ID="lt_tuvan" runat="server" ForeColor="red"></asp:Label>)</span><img src="/Resources/2025/4.png" /><br />Tư vấn </a></li>
                <li><a href="/admin.aspx?u=Contacts"><span style="color:red;padding-right: 3px;float: left">(<asp:Label ID="lt_lienhe" runat="server" ForeColor="red"></asp:Label>)</span><img src="/Resources/2025/5.png" /><br />Liên hệ </a></li>
                <li> <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkdangxuat_Click"  class="logout"><img src="/Resources/2025/6.png" /><br /> Thoát</asp:LinkButton></li>
            </ul>
        </div>
    </header>