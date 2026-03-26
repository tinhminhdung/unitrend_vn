<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Control" %>
<%@ Register src="index.ascx" tagname="index" tagprefix="uc1" %>
<%@ Register src="Lefmenu.ascx" tagname="Lefmenu" tagprefix="uc2" %>
<%@ Register src="Control_All.ascx" tagname="Control_All" tagprefix="uc3" %>

<%--<% if (Request["su"] == "resetpassword" || Request["su"] == "GioiThieu" || Request["su"] == "Download" || Request["su"] == "prd" || Request["su"] == "Searchtag" || Request["su"] == "khuyenmai" || Request["su"] == "SPMoi" || Request["su"] == "SPBanchay" || Request["su"] == "Infos" || Request["su"] == "changinfo" || Request["su"] == "Login" || Request["su"] == "changepass" || Request["su"] == "Register" || Request["su"] == "nws" || Request["su"] == "contact" || Request["su"] == "Page404" || Request["su"] == "viewcart" || Request["su"] == "msg" || Request["su"] == "Search" || Case == "0" || Case == "100" || Case == "1" || Case == "2" || Case == "3" || Case == "4" || Case == "5" || Case == "6" || Case == "7" || Case == "8" || Case == "20" || Case == "21" || Case == "22" || Case == "24" || Case == "11")
  { %>
    <uc3:Control_All ID="Control_All1" runat="server" />
<% }%>
<%if (Request["su"] == null && Case == ""){%>                                    
<uc1:index ID="index1" runat="server" />
<%} %>--%>
<%if (Request["su"] == null && Case == ""){%>                                    

<div class="nenall">
<uc1:index ID="index1" runat="server" />
    </div>
<%} else{%>
<div class="nenall">
<uc3:Control_All ID="Control_All1" runat="server" />
    </div>
<%} %>