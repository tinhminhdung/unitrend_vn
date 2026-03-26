<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="VS.E_Commerce.cms.Display.Vote.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::.<%=MoreAll.Templates.Templates.WebTitle()%>.::</title>
</head>
<body style="padding:5px;margin:0;font-size:13px;background-color:#e0e0e0">
    <form id="form1" runat="server">
    <div style="height:30px;">
    <div style="float:left;font-size:18px;">Cám ơn bạn đã quan tâm tới câu hỏi này</div>
    <div style="float:right;"><a href="#" onclick="window.close();">Đóng cửa sổ</a></div></div>
    <div>
        <div style="padding:8px 0; font-size:16px;font-weight:bold;color:#006b2a;"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
        <div>
            <asp:Repeater ID="rpvotelist" runat="server">
            <HeaderTemplate>
                <table  width="100%" cellpadding="2" border="1" cellspacing="0" style="border-collapse:collapse;background-color:#fcefff;border:solid 1px #f0f0f0;">
            </HeaderTemplate>
            <ItemTemplate>
                <tr valign="middle" height="25px">
                    <td><%#Eval("Name").ToString() %></td>
                    <%#Statistic(Eval("Views").ToString(), Eval("Description").ToString())%>
                    <td align="right"><%#Eval("Views").ToString()%> phiếu chọn&nbsp;</td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
            </asp:Repeater>
            <div style="text-align:right;background-color:#e9caef;padding:5px 4px;border:solid 1px #f0f0f0;font-size:13px;">Tổng cộng:<b>
                <asp:Literal ID="lttotalvote" runat="server"></asp:Literal></b> phiếu chọn&nbsp;</div>
        </div>
    </div>
    </form>
</body>
</html>
