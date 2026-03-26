<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.M_News.Setting" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class='frm-add'>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="400px">
                    </td>
                    <td>
                    </td>
                    <td>
                        <strong><font color="#006633"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong style="text-transform: uppercase"><img src="/Resources/admin/images/bullet-red.png" border="0" /><%=label("l_displayinindnex")%> </strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td style="padding-left: 15px"><%=label("l_iteminpage")%></td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpagenews" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                        <span style="font-size: 7pt; color: dimgray"><em>(là chỉ số để phân trang cho danh sách tin - Ex:Trang: 1 2 3 4 5 tiếp theo)</em></span>
                    </td>
                </tr>
                 <tr>
                    <td style="padding-left: 15px">Phân trang (menu phải)</td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpagenews2" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                        <span style="font-size: 7pt; color: dimgray"><em>(là chỉ số để phân trang cho danh sách tin - Ex:Trang: 1 2 3 4 5 tiếp theo)</em></span>
                    </td>
                </tr>


                <tr>
                    <td>
                        <strong style="text-transform: uppercase"> <img src="/Resources/admin/images/bullet-red.png" border="0" /> Cắt chuỗi </strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Cắt chuỗi tiêu đề
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubstring" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                        <span style="font-size: 7pt; color: dimgray"><em>((Để 0 là mặc định không cắt chuỗi)  - Cắt chuỗi trong tiêu đề tin tức)</em></span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Cắt chuỗi mô tả
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubstring_Mota" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                        <span style="font-size: 7pt; color: dimgray"><em>((Để 0 là mặc định không cắt chuỗi) - Cắt chuỗi trong mô tả tin tức)</em></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            Cấu hình kích thước của ảnh </strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Rộng
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtwidth" runat="server" CssClass="txt" Width="50px">130</asp:TextBox> px <span style="font-size: 7pt; color: dimgray"><em>(Chiều rộng của hình ảnh trong danh  sách tin)</em></span>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Cao
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtheight" runat="server" CssClass="txt" Width="50px">100</asp:TextBox>
                        px <span style="font-size: 7pt; color: dimgray"><em>(Chiều cao của hình ảnh trong danh
                            sách tin)</em></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" /> Cấu hình trong phần chi tiết</strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Số tin hiển thị trong các tin khác
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtnewsother" runat="server" CssClass="txt" Width="50px">7</asp:TextBox>
                        <span style="font-size: 7pt; color: dimgray"><em>(được hiển thị bao nhiêu tin khác trong phần chi tiết bài)</em></span>
                    </td>
                </tr>
                      <tr>
                     <td style=" padding-left:15px">
                     Hiển thị Phản hồi
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButton ID="Radio_CommentCo" runat="server" Checked="true"  GroupName="Comment" Text="Có hiển thị" />
                        <asp:RadioButton ID="Radio_CommentKhong" runat="server" GroupName="Comment" Text="Không hiển thị" />  <span style="font-size: 7pt; color: dimgray"><em>(Commnets có hay không hiển thị ngoài trang tin tức)</em></span>
                    </td>
                </tr>
                 <tr>
                     <td style=" padding-left:15px">
                    Trạng thái Phản hồi
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioC0" runat="server" Checked="true"  GroupName="StatusComment" Text="Phản hồi tự do" />
                        <asp:RadioButton ID="RadioKhong" runat="server" GroupName="StatusComment" Text="Admin duyệt" /> <span style="font-size: 7pt; color: dimgray"><em>(Phản hồi tự do là không thông qua admin duyệt)</em></span>
                    </td>
                </tr>
               
                <tr valign="bottom" height="40">
                        <td style="width: 294px">
                            <strong style="text-transform: uppercase">
                                <img src="Resources/admin/images/bullet-red.png" border="0" /> Cấu hình Like Button - Facebook
                            </strong>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px; width: 294px;">
                          Cấu hình Like Button - Facebook
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:RadioButton ID="Facebook1" runat="server" Text="Không kích hoạt"  GroupName="Facebook" Checked="true"></asp:RadioButton>
                            <asp:RadioButton ID="Facebook2" runat="server" Text="Hiển thị không có hình đại diện"  GroupName="Facebook"></asp:RadioButton>
                            <asp:RadioButton ID="Facebook3" runat="server" Text="Hiển thị kèm theo  hình đại diện"  GroupName="Facebook"></asp:RadioButton>
                            <span style="font-size: 7pt; color: dimgray"><em>(Hiển thị hình ảnh - và mô tả)</em></span>
                        </td>
                    </tr>
                     <tr>
                    <td>
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" /> Thông tin chia sẻ</strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Chia sẻ bài viết
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdcommentoptioncheckcomments" runat="server" Checked="true" GroupName="co" Text="Hiển thị thông tin chia sẻ bài viết" />
                        <asp:RadioButton ID="rdcommentoptionnotcheckcomments" runat="server" GroupName="co" Text="Không hiển thị chia sẻ bài viết" /><br />
                        <span style="font-size: 7pt; color: dimgray"><em>(Xuất hiện các icon để chia sẻ (Bookmark & Share) - Ex:facebook,Tweet this,vv...)<img src="Uploads/pic/web/chiase.jpg" border="0" /></em></span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnsetup" runat="server" OnClick="btnsetup_Click" Text="Cập nhật" Width="150px" />
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
