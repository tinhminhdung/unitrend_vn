<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="VS.E_Commerce.cms.Display.showcontent.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title><%=MoreAll.Templates.Templates.WebTitle()%></title> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="font-size:14px;font-weight:bold;"><asp:Literal ID="lttitle" runat="server"></asp:Literal></span>
        <br />
        <asp:Literal ID="ltcontent" runat="server"></asp:Literal></div>
    </form>
</body>
</html>