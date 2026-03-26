<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MapGoogle.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Sitemap.MapGoogle" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:updatepanel ID="UpdatePanel2" runat="server">
    <contenttemplate>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
<div class="frm_search"  style="margin-top:10px;">
<asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack=true  Width="125px" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Button ID="bthienthi" runat="server" Text="Hiển thị" OnClick="bthienthi_Click" Width="74px" />
    <asp:Button ID="btinsert" runat="server" Text="Thêm mới" OnClick="btinsert_Click" Width="93px" />
    <asp:Button ID="btdelete" runat="server"  ToolTip="Xóa những lựa chọn !"  OnClientClick=" return confirmDelete(this);"  Text="Xóa" OnClick="btdelete_Click" Width="37px" />
</div>
<div class="list_item">
<asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
    <ItemTemplate>
	<tr style="background-color:#f1f1f1"  height="40">
        <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("igm") %>' runat="server" /></td>
        <td align="center">
          <%#MoreAll.MoreImage.Image(Eval("vimg").ToString()) %>
        </td>
        <td>
           <b><%#Eval("Name")%></b>
        </td>
        <td align="center">
           <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Createdate"))%>
        </td>
        <td align="center">
           <%#DataBinder.Eval(Container.DataItem,"Orders")%>
        </td>
        <td align="center">
          <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("igm")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton3"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
        </td>
        <td align="center">
          <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("igm")%>' CommandName="update">[<%#label("lt_edit")%>]</asp:LinkButton>
        </td>
        <td align="center">
           <div class="del"><asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("igm")%>' CommandName="delete" OnLoad="Delete_Load">[<%#label("ldelete")%>]</asp:LinkButton></div>
        </td>
        </tr>
	</ItemTemplate>
    <SeparatorTemplate>
        <tr><td bgcolor="#ffffff" colspan="10" height="1"></td> </tr>
        <tr><td bgcolor="#30a72f" colspan="10" height="1"></td> </tr>
        <tr><td bgcolor="#ffffff" colspan="10" height="1"></td> </tr>
    </SeparatorTemplate>
    <AlternatingItemTemplate>
<tr style="background-color: #ffff" height="45">
<td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("igm") %>' runat="server" /></td>
<td align="center">
  <%#MoreAll.MoreImage.Image(Eval("vimg").ToString())%>
</td>
<td>
   <b><%#Eval("Name")%></b>
</td>
<td align="center">
   <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Createdate"))%>
</td>
<td align="center">
   <%#DataBinder.Eval(Container.DataItem,"Orders")%>
</td>
<td align="center">
  <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("igm")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton3"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
</td>
<td align="center">
  <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("igm")%>' CommandName="update">[<%#label("lt_edit")%>]</asp:LinkButton>
</td>
<td align="center">
   <div class="del"><asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("igm")%>' CommandName="delete" OnLoad="Delete_Load">[<%#label("ldelete")%>]</asp:LinkButton></div>
</td>
</tr>
</AlternatingItemTemplate> 
    <SeparatorTemplate>
    <tr><td bgcolor="#ffffff" colspan="10" height="1"></td> </tr>
    <tr><td bgcolor="#30a72f" colspan="10" height="1"></td> </tr>
    <tr><td bgcolor="#ffffff" colspan="10" height="1"></td> </tr>
</SeparatorTemplate>
    <HeaderTemplate>
    <table  border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
		<tr bgcolor="#C4C4C4" height="22">
        <td class="header"><input id="Checkbox1" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
        <td class="header">Hình ảnh</td>
        <td class="header"><%=label("l_title")%></td>
        <td class="header"><%=label("l_createdate")%></td>
        <td class="header"><%=label("lt_order")%></td>
        <td class="header"><%=label("lt_display")%></td>
        <td class="header">Hiệu chỉnh</td>
        <td class="header">Xóa</td>     
    </tr>
</HeaderTemplate>
<FooterTemplate>
</TABLE>
</FooterTemplate> 
</asp:Repeater>
<asp:Label ID="lterr" runat="server" Font-Bold=true ForeColor=red></asp:Label>
</div>
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
<tr align=center><td>
<div class="phantrang">
 <cc1:CollectionPager id="CollectionPager1" runat="server"  BackNextDisplay="HyperLinks" BackNextLocation="Split"
            BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"  IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers" 
            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
        </cc1:CollectionPager>
</div>
</td></tr>
    <tr bgcolor="whitesmoke" height="25">
        <td>
           <b>
                <asp:LinkButton ID="linkcreatenew" runat="server" CssClass="underline" Font-Bold="True" OnClick="linkcreatenew_Click">[<%=label("l_createnew")%>]</asp:LinkButton>
            </b>
        </td>
    </tr>
</table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <div class='frm-add'>
        <table border="0" cellpadding="1" cellspacing="0" class="all" width="100%">
            <tr>
                <td>
                </td>
                <td width="97">
                </td>
                <td width="5">
                </td>
                <td>
                    <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    <%=label("l_title")%>
                </td>
                <td>
                </td>
                <td>
                   <asp:TextBox ID="txtname" runat="server" Width="420px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="right">
                </td>
                <td align="right">
                   Tọa độ
                </td>
                <td>
                </td>
                <td>
                   <asp:TextBox ID="txttoado" runat="server" Width="420px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 43px">
                </td>
                <td align="right" style="height: 43px">
                   Ảnh cửa hàng / Công ty
                </td>
                <td style="height: 43px">
                </td>
                <td style="height: 43px">
                   <asp:LinkButton ID="lnkxoa" runat="server" OnClick="lnkxoa_Click" ForeColor="#FF0000">Xóa ảnh</asp:LinkButton><br />
                    <asp:FileUpload ID="flimage" runat="server" Width="323px" />
                     <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" controltovalidate="flimage" errormessage="Không phải file ảnh" validationexpression="^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png| .PNG)$"> </asp:regularexpressionvalidator>
                     <br />
                    <div  class="adaidien"><asp:Literal ID="ltimg" runat="server"></asp:Literal></div>
              </td>
            </tr>
            <tr>
                <td align="right" height="3" style="width: 100px">
                </td>
                <td align="right" height="3">
                    Thứ tự
                </td>
                <td>
                </td>
                <td>
                   <asp:TextBox ID="txtoder" runat="server" Width="60px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                </td>
                <td align="right">
                    Thứ tự
                </td>
                <td>
                </td>
                <td>
                   <asp:CheckBox ID="chkstatus" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 100px"></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Lưu thông tin" />
                    <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" Text="Hủy bỏ" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
               <asp:HiddenField ID="hdinsertupdate" runat="server" Value="insert" />
                    <asp:HiddenField ID="hdid" runat="server" Value="-1" />
                    <asp:HiddenField ID="hdimages" runat="server" />
                    <asp:HiddenField ID="hhdimages" runat="server" />
                    <asp:HiddenField ID="hdFileName" runat="server" />
                    <asp:HiddenField ID="hdimg" runat="server" />
                </td>
            </tr>
        </table>
        </div>
    </asp:View>
</asp:MultiView>
</contenttemplate>
 <Triggers>
<asp:PostBackTrigger ControlID="btnsave" />
</Triggers>
</asp:updatepanel>