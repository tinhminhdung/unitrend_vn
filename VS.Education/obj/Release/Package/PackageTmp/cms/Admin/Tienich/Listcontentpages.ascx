<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Listcontentpages.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Tienich.Listcontentpages" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View2" runat="server">
        <div style="margin-top:10px;"  class="frm_search">
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
    <tr>
        <td>
                <asp:DropDownList ID="ddlstatus" AutoPostBack=true runat="server" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" Width="126px">
                </asp:DropDownList>
               <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" Text="Hiển thị" Width="74px" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Tạo trang độc lập mới" Width="144px" />
            <asp:Button ID="btxoa"  runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);"  Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="45px" />
        </td>
    </tr>
</table>
</div>
<div  class="list_item">
<asp:Repeater ID="rppages" runat="server" OnItemCommand="rp_newslist_ItemCommand">
<ItemTemplate>
<tr style="background-color:#f1f1f1"  height="40">
   <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("idl") %>' runat="server" /></td>
   <td>
       <%#Eval("vtitle") %>  
   </td>
   <td align="center">
     <a href='cms/display/showcontent/index.aspx?idl=<%#Eval("idl") %>' target=_blank>[<%#label("l_gotosite") %>]</a>
   </td>
   <td align="center">
      <%#Eval("dcreatedate")%>
   </td>
   <td align="center">
       <%#Enable(DataBinder.Eval(Container.DataItem,"istatus").ToString())%>
   </td>
 <td align="center">
     <asp:LinkButton ID="Linkbutton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"idl")%>' CommandName="Edit">[<%=label("lt_edit")%>]</asp:LinkButton>
    </td>
   <td align="center">
<asp:LinkButton ID="Linkbutton2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"idl")%>' CommandName="Delete" OnLoad="Delete_Load">[<%=label("ldelete")%>]</asp:LinkButton></div>
   </td>
</tr>
</ItemTemplate>
<AlternatingItemTemplate>
<tr  height="40">
   <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("idl") %>' runat="server" /></td>
   <td>
       <%#Eval("vtitle") %>  
   </td>
   <td align="center">
     <a href='cms/display/showcontent/index.aspx?idl=<%#Eval("idl") %>' target=_blank>[<%#label("l_gotosite") %>]</a>
   </td>
   <td align="center">
      <%#Eval("dcreatedate")%>
   </td>
   <td align="center">
       <%#Enable(DataBinder.Eval(Container.DataItem,"istatus").ToString())%>
   </td>
 <td align="center">
     <asp:LinkButton ID="Linkbutton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"idl")%>' CommandName="Edit">[<%=label("lt_edit")%>]</asp:LinkButton>
    </td>
   <td align="center">
<asp:LinkButton ID="Linkbutton2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"idl")%>' CommandName="Delete" OnLoad="Delete_Load">[<%=label("ldelete")%>]</asp:LinkButton></div>
   </td>
</tr>
</AlternatingItemTemplate>	
<HeaderTemplate>
<table  border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
	 <tr bgcolor="#C4C4C4" height="22">
	    <td class="header"><input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
		<td class="header"><%=label("answers_title")%></td>
		<td class="header">Url</td>
		<td class="header"><%=label("l_createdate")%></td>
		<td class="header"><%=label("l_status")%></td>
		<td class="header"><%=label("lt_edit")%></td>
		<td class="header"><%=label("ldelete")%></td>
	</tr>
</HeaderTemplate>
</asp:Repeater>
</div>
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
<tr height="20">
    <td align=right>
        <div class="phantrang" style=" ">
        <cc1:CollectionPager id="CollectionPager1" runat="server"  BackNextDisplay="HyperLinks" BackNextLocation="Split"
            BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"  IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers" 
            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
        </cc1:CollectionPager>
        </div>
    </td>
    </tr>
    <tr bgcolor="whitesmoke" height="25">
    <td style="height: 25px"><b><asp:LinkButton ID="lnkcreatenew" runat="server" Font-Bold="True" OnClick="lnkcreatenew_Click" CssClass="lnk">[<%=label("l_createnew")%>]</asp:LinkButton></b></td>
</tr>
</table>

</asp:View>
<asp:View ID="View3" runat="server">
<div class='frm-add'>
<div align=center><asp:Label ID="lblmsg" runat="server"  Font-Bold=true  ForeColor=red></asp:Label></div>
    <table cellpadding=0 cellspacing=0 border=0 width=100%>
            <tr>
            <td>
                <%=label("answers_title")%></td>
            <td></td>
            <td>
                <asp:TextBox ID="txtcontenttitle" CssClass="txt_css" runat="server" Width="98%"></asp:TextBox></td>
        </tr>
         <tr>
            <td>
                <%=label("l_content")%>
            </td>
            <td></td>
            <td>
<CKEditor:CKEditorControl ID="txtcontentcontent" runat="server" ></CKEditor:CKEditorControl>

            </td>
        </tr>
         <tr>
            <td>
               <%=label("l_option")%> </td>
            <td></td>
            <td>
                <asp:CheckBox ID="chkdisplaytitle" CssClass="txt_css2" runat="server" Text="Hiển thị tiêu đề" Font-Bold="True" /></td>
        </tr>
         <tr>
            <td>
                <%=label("lt_display")%> </td>
            <td></td>
            <td>
                <asp:CheckBox ID="chkcontentstatus" CssClass="txt_css2" Text="Hiển thị" runat="server" /></td>
        </tr>
         <tr>
            <td></td>
            <td></td>
            <td>
                <asp:Button ID="btncontentsave" CssClass="txt_css" runat="server" OnClick="btncontentsave_Click" Text="Lưu thông tin" />
                <asp:Button ID="btncontentcancel" CssClass="txt_css" runat="server"  OnClick="btncancelcontent_Click" Text="Hủy bỏ" /></td>
        </tr>
         <tr>
            <td></td>
            <td></td>
            <td>
                <asp:HiddenField ID="hdcontentid" runat="server" />
                <asp:HiddenField ID="hdcontentinsertupdate" runat="server" />
            </td>
        </tr>
        </table>
</div>
</asp:View>
</asp:MultiView>