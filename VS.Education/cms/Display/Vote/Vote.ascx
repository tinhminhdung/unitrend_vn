<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Vote.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Vote.Vote" %>
  <script language="javascript" src="/Resources/js/newwindow.js"></script>
<script src="../../../Resources/js/newwindow.js" type="text/javascript"></script>
<asp:Literal ID="lttitlecate" runat="server"></asp:Literal>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <ContentTemplate>
 <center>
<asp:HiddenField ID="hdvoteid" runat="server" />
<div class="textcenter">    
    <div style="color:Red;"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></div>
    <div  class="textleft">
        <asp:RadioButtonList ID="rblvotelist" runat="server" RepeatLayout="Flow">
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:Button ID="Button1"  runat="server" Text="Biểu quyết" OnClick="Button1_Click" />
         <a onclick="NewWindow_('/cms/Display/Vote/index.aspx','Process','800','450','true','true')" href='javascript:void(0)' >Kết quả</a>
    </div>
</div>
</center>
</ContentTemplate>
</asp:UpdatePanel>
