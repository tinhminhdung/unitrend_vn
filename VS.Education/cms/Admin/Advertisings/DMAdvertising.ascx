<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DMAdvertising.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Advertisings.DMAdvertising" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
<div class="frm_search"  style="margin-top:10px;">
<asp:DropDownList ID="ddlvalue" runat="server" AutoPostBack="true"  style=" width:auto" OnSelectedIndexChanged="ddlvalue_SelectedIndexChanged">
</asp:DropDownList>
<asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack=true  Width="125px" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Button ID="bthienthi" runat="server" Text="Hiển thị" OnClick="bthienthi_Click" Width="74px" />
    <asp:Button ID="btinsert" runat="server" Text="Thêm mới" OnClick="btinsert_Click" Width="93px" />
    <asp:Button ID="btdelete" runat="server"  ToolTip="Xóa những lựa chọn !"  OnClientClick=" return confirmDelete(this);"  Text="Xóa" OnClick="btdelete_Click" Width="37px" />
       <asp:Label ID="ltthongbao" runat="server"  Font-Bold=true ForeColor=Red></asp:Label>
</div>
<div  class="list_item">
<asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
    <ItemTemplate>
	<tr style="background-color:#f1f1f1"  height="40">
        <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("images") %>' runat="server" /></td>
        <td align="center">
           <a href="<%#Eval("Path")%>" target="_blank"><%#Image(Eval("vimg").ToString(), Eval("Type").ToString())%></a>
        </td>
        <td>
           <b><%#Eval("Name")%></b>
        </td>
       <td align="center">
          <%#Vitri(Eval("Text").ToString())%>
        </td>
         <td align="center">
        <asp:TextBox ID="TextBox1"  Text='<%#DataBinder.Eval(Container.DataItem, "Width")%>'  onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')"  CssClass="txt_cssb" Width="30px" runat="server" OnTextChanged="txtxWidth_TextChanged" AutoPostBack="true"></asp:TextBox>
        </td> 
        <td align="center">
          <asp:TextBox ID="TextBox2"  Text='<%#DataBinder.Eval(Container.DataItem, "Height")%>'  onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')"  CssClass="txt_cssb" Width="30px" runat="server" OnTextChanged="txtxHeight_TextChanged" AutoPostBack="true"></asp:TextBox>
        </td>
        <td>
            <a href="<%#Eval("Path")%>" target="_blank"><%#Eval("Path")%></a>
        </td>
        <td align="center">
           <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Create_Date"))%>
           <div><%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></div>
        </td>
        <td align="center">
           <%#DataBinder.Eval(Container.DataItem,"Views")%>
        </td>
        <td align="center">
           <%#DataBinder.Eval(Container.DataItem,"Orders")%>
        </td>
        <td align="center">
          <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("images")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton3"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
        </td>
        <td align="center">
          <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("images")%>' CommandName="update">[<%#label("lt_edit")%>]</asp:LinkButton>
        </td>
        <td align="center">
           <div class="del"><asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("images")%>' CommandName="delete" OnLoad="Delete_Load">[<%#label("ldelete")%>]</asp:LinkButton></div>
        </td>
        </tr>
	</ItemTemplate>
    <AlternatingItemTemplate>
<tr style="background-color: #ffff" height="40">
<td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("images") %>' runat="server" /></td>
<td align="center">
    <a href="<%#Eval("Path")%>" target="_blank"><%#Image(Eval("vimg").ToString(), Eval("Type").ToString())%></a>
</td>
<td>
   <b><%#Eval("Name")%></b>
</td>
 <td align="center">
           <%#Vitri(Eval("Text").ToString())%>
        </td>
         <td align="center">
        <asp:TextBox ID="TextBox1"  Text='<%#DataBinder.Eval(Container.DataItem, "Width")%>'  onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')"  CssClass="txt_cssb" Width="30px" runat="server" OnTextChanged="txtxWidth_TextChanged" AutoPostBack="true"></asp:TextBox>
        </td> 
        <td align="center">
          <asp:TextBox ID="TextBox2"  Text='<%#DataBinder.Eval(Container.DataItem, "Height")%>'  onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')"  CssClass="txt_cssb" Width="30px" runat="server" OnTextChanged="txtxHeight_TextChanged" AutoPostBack="true"></asp:TextBox>
        </td>
<td>
    <a href="<%#Eval("Path")%>" target="_blank"><%#Eval("Path")%></a>
</td>
<td align="center">
   <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Create_Date"))%>
   <div><%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></div>
</td>
<td align="center">
   <%#DataBinder.Eval(Container.DataItem,"Views")%>
</td>
<td align="center">
   <%#DataBinder.Eval(Container.DataItem,"Orders")%>
</td>
<td align="center">
  <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("images")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton3"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
</td>
<td align="center">
  <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("images")%>' CommandName="update">[<%#label("lt_edit")%>]</asp:LinkButton>
</td>
<td align="center">
   <div class="del"><asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("images")%>' CommandName="delete" OnLoad="Delete_Load">[<%#label("ldelete")%>]</asp:LinkButton></div>
</td>
</tr>
</AlternatingItemTemplate> 
    <HeaderTemplate>
    <table  border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
	<tr bgcolor="#C4C4C4" height="22">
        <td class="header"><input id="Checkbox1" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
        <td class="header">Hình ảnh</td>
        <td class="header"><%=label("l_title")%></td>
        <td class="header">Vị trí</td>
        <td class="header">Độ Rộng</td>
        <td class="header">Độ cao</td>
        <td class="header"><%=label("lt_url")%></td>
        <td class="header"><%=label("l_createdate")%></td>
        <td class="header"><%=label("l_view")%></td>
        <td class="header"><%=label("lt_order")%></td>
        <td class="header"><%=label("lt_display")%></td>
        <td class="header">Hiệu chỉnh</td>
        <td class="header">Xóa</td>     
    </tr>
</HeaderTemplate>
<SeparatorTemplate>
<tr><td bgcolor="#ffffff" colspan="10" height="1"></td> </tr>
<tr><td bgcolor="#30a72f" colspan="10" height="1"></td> </tr>
<tr><td bgcolor="#ffffff" colspan="10" height="1"></td> </tr>
</SeparatorTemplate>
<FooterTemplate>
</table>				
</FooterTemplate>
</asp:Repeater>
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
        <table id="tblinput" border="0" cellpadding="1" cellspacing="0" class="all" width="100%">
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
                <tr style=" display:none">
                <td align="right">
                </td>
                <td align="right">
                   Loại quảng cáo 
                </td>
                <td>
                </td>
                <td>
                <asp:DropDownList ID="ddltype" AutoPostBack=true runat="server" CssClass="txt_adn" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                      <asp:ListItem Value="1" Selected=True>Image</asp:ListItem>
                    <asp:ListItem Value="0">Text</asp:ListItem>
                    <asp:ListItem Value="2">Video Youtube</asp:ListItem>
                    <asp:ListItem Value="3">Flash</asp:ListItem>
                 </asp:DropDownList>
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
                <td align="right" style="width: 100px">
                </td>
                <td align="right">
                    <%=label("lt_url")%>
                </td>
                <td>
                </td>
                <td>
                   <asp:TextBox ID="txtSupport" runat="server" Width="420px">http://</asp:TextBox>
                </td>
            </tr>
                 <asp:Panel ID="PanelLink03" runat="server"></asp:Panel>
                 <tr>
                <td align="right" height="3" style="width: 100px">
                </td>
                <td align="right" height="3">
                 Mô tả
                </td>
                <td>
                </td>
                <td> <asp:TextBox ID="txtmota" runat="server" Width="446px" Height="101px" TextMode="MultiLine"></asp:TextBox><span style="font-size: 7pt; color: dimgray"><em></em></span></td>
            </tr>
                 
            <asp:Panel ID="PanelLink01" runat="server">
            </asp:Panel>
            
            
            <tr>
                <td align="right" style="width: 100px; height: 43px">
                </td>
                <td align="right" style="height: 43px">
                    <%=label("l_images")%>
                </td>
                <td style="height: 43px">
                </td>
                <td style="height: 43px">
                    <asp:RadioButton ID="rdFromComputer" runat="server" AutoPostBack="True" Checked="true"  GroupName="FromType" OnCheckedChanged="rdFromComputer_CheckedChanged" Text="Từ máy tính của bạn" ValidationGroup="downloadtype" />
                    <asp:RadioButton ID="rdFromLinks" runat="server" AutoPostBack="True" GroupName="FromType" OnCheckedChanged="rdFromLinks_CheckedChanged" Text="Từ 1 liên kết trên Internet" />
                    &nbsp; &nbsp;&nbsp;<asp:LinkButton ID="lnkxoa" runat="server" OnClick="lnkxoa_Click" ForeColor="#FF0000">Xóa ảnh</asp:LinkButton><br />
                    <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                        <asp:View ID="vwFromComputer" runat="server">
                            <asp:FileUpload ID="flimage" runat="server" Width="323px" />
                            <br />
                            <span style="font-size: 7pt; color: dimgray"><em>(Chỉ hỗ trợ định dạng *.jpg,*.gif,*.bmp,*.png,*.swf)</em></span><br />
                            <asp:Literal ID="ltimg" runat="server"></asp:Literal></asp:View>
                         <asp:View ID="vwFromLinks" runat="server">
                            <asp:TextBox ID="txtvimg" runat="server" Width="99%"></asp:TextBox><br />
                            </asp:View>
                    </asp:MultiView>
              </td>
            </tr>
            
         
            <asp:Panel ID="PanelYoutube" Visible=false runat="server">
            <tr>
                <td align="right" height="3" style="width: 100px">
                </td>
                <td align="right" height="3">
                 Link Youtube
                </td>
                <td>
                </td>
                <td>
                   <asp:TextBox ID="txtYoutube" runat="server" Width="446px" Height="101px" TextMode="MultiLine"></asp:TextBox><span style="font-size: 7pt; color: dimgray"><em></em></span></td>
            </tr>
             </asp:Panel>
            <tr>
                <td align="right" style="width: 100px">
                </td>
                <td align="right">
                    Theo danh mục
                </td>
                <td>
                </td>
                <td>
                   <asp:DropDownList ID="ddllocal" runat="server" style=" width:auto">
                    </asp:DropDownList>
                </td>
            </tr>
          <tr>
                            <td align="right" style="width: 100px">
                            </td>
                            <td align="right">
                                Vị trí hiển thị
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlvitri" runat="server" style=" width:auto"> 
                                    <asp:ListItem Value="1">Hiển thị theo danh sách</asp:ListItem>
                                    <asp:ListItem Value="2">Hiển thị theo trang nhóm</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>   
            
            
             <asp:Panel ID="PanelLink04" runat="server"></asp:Panel>
            <tr>
                <td align="right" style="width: 100px">
                </td>
                <td align="right">
                    <%=label("l_width")%>
                </td>
                <td>
                </td>
                <td>
                   <asp:TextBox ID="txtwidth" runat="server" Width="45px">1</asp:TextBox>px<%=label("l_height")%><asp:TextBox ID="txtheight" runat="server" Width="45px">1</asp:TextBox>px (Default 0px) <span style="font-size: 7pt; color: dimgray"><em>((<%=label("l_0pxshowtruesizeimage")%>) - Sau khi chọn vị trí quảng cáo, Chép lại chiều cao và rộng vào ô)</em></span>
                </td>
            </tr>
            
            
            <asp:Panel ID="PanelLink02" runat="server">
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    <%=label("l_openpagetype")%>
                </td>
                <td>
                </td>
                <td>
                   <asp:DropDownList ID="ddlopentype" runat="server">
                        <asp:ListItem Value="0">Mở trong trang hiện tại</asp:ListItem>
                        <asp:ListItem Value="1">Mở trang mới</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
           </asp:Panel>
               
            <tr>
                <td align="right" height="3" style="width: 100px">
                </td>
                <td align="right" height="3">
                    <%=label("lt_order")%>
                </td>
                <td>
                </td>
                <td>
                   <asp:TextBox ID="txtoder" runat="server" Width="60px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                            <td align="right" style="width: 100px">
                                &nbsp;
                            </td>
                            <td align="right">
                                Thời gian&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkdaytype" runat="server" AutoPostBack="True" OnCheckedChanged="chkdaytype_CheckedChanged" Text="Hiển thị trong thời gian" />
                                        &nbsp;
                                        <asp:Panel ID="pnadddate" runat="server" Visible="false">
                                            &nbsp;Ngày đăng tin
                                            <br />
                                            &nbsp;<asp:TextBox ID="txtfromday" runat="server" CssClass="txt" Height="22px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtfromday_CalendarExtender0" runat="server" TargetControlID="txtfromday">
                                            </cc1:CalendarExtender>
                                            &nbsp;tồn tại trong
                                            <asp:TextBox ID="txtindays" runat="server" CssClass="txt" Width="48px">365</asp:TextBox>
                                            &nbsp;ngày</asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
            <tr>
                <td align="right" style="width: 100px">
                </td>
                <td align="right">
                    <%=label("l_status")%>
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
