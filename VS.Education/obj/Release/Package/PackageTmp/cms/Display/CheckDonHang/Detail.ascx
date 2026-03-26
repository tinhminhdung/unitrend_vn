<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.CheckDonHang.Detail" %>
                    <div class="woocommerce">
                        <p>Cảm ơn bạn. Đơn hàng của bạn đã được xác nhận.</p>
                        <asp:Repeater ID="rpcart" runat="server">
                            <HeaderTemplate>
                                <table class="shop_table thankyou">
                                    <thead>
                                        <tr>
                                            <th>
                                             Đơn hàng:
                                            </th>
                                            <th>
                                                 Ngày:
                                            </th>
                                            <th>
                                                Tổng thanh toán:
                                            </th>
                                            <th>
                                                Phương thức thanh toán:
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        #<%#Eval("ID")%>
                                    </td>
                                    <td>
                                        <%#MoreAll.MoreAll.FormatDate(Eval("Create_Date").ToString())%>
                                    </td>
                                    <td>
                                        <span class="amount">
                                            <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Money").ToString())%></span>
                                    </td>
                                    <td>
                                        <%=label("Showroomtt")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <div class="clear">
                        </div>
                        <h2>Chi tiết đơn hàng</h2>
                        <table class="shop_table order_details">
                            <thead>
                                <tr>
                                    <th class="product-name">
                                       Sản phẩm
                                    </th>
                                    <th class="product-total">
                                        Đặt đơn hàng
                                    </th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th scope="row">
                                        Tổng đơn hàng:
                                    </th>
                                    <td>
                                        <span class="amount">
                                            <asp:Literal ID="lttongq" runat="server"></asp:Literal>
                                            đ</span>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        Thành tiền:
                                    </th>
                                    <td>
                                        <span class="amount">
                                            <asp:Literal ID="lttong" runat="server"></asp:Literal>
                                            đ</span>
                                    </td>
                                </tr>
                            </tfoot>
                            <tbody>
                                <asp:Repeater ID="rpcartdetail" runat="server">
                                    <ItemTemplate>
                                        <tr class="order_table_item">
                                            <td class="product-name">
                                                <a title="<%#Ten(Eval("ipid").ToString())%>" target="_blank" href="/<%#MoreAll.AddURL.SeoURL(Ten(Eval("ipid").ToString()))%>_sp<%#Nhom(Eval("ipid").ToString()) %>_ct<%#Eval("ipid") %>.aspx">
                                                    <%#Ten(Eval("ipid").ToString())%></a> <strong class="product-quantity">×
                                                      <%#Eval("Quantity")%></strong><dl class="variation">
                                                        </dl>
                                            </td>
                                            <td class="product-total">
                                                <span class="amount"><%#MoreAll.MorePro.Detail_Price(Eval("Money").ToString())%>đ</span>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Literal ID="lterr" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="row my-account-order-details">
                                    <div class="span4">
                                        <dl class="customer_details">
                                            <header class="title">
            	<h2>Chi tiết khách hàng</h2>
            </header>
                                            <dt>Email:</dt><dd><%#Eval("Email")%></dd><dt>Điện thoại:</dt><dd><%#Eval("Phone")%></dd>
                                        </dl>
                                    </div>
                                    <div class="span4 addresses">
                                        <div>
                                            <header class="title">
    			<h3>Thông tin hóa đơn</h3>
    		</header>
                                            <address>
                                                <p>
                                                    Địa chỉ
                                                </p>
                                            </address>
                                        </div>
                                    </div>
                                    <div class="span4 addresses">
                                        <div>
                                            <header class="title">
    			<h3>Địa chỉ vận chuyển</h3>
    		</header>
                                            <address>
                                                <p>
                                                   Địa chỉ
                                                </p>
                                            </address>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                   