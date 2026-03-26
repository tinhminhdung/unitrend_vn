<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CuocPhiVanChuyen.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.settings.CuocPhiVanChuyen" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>
<asp:panel id="pn_list" runat="server" Width="100%">
    <div class="frm_search">
        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
    <tr>
        <td style=" width:200px">
            <asp:UpdatePanel ID="countrypanel" runat="server">
                    <ContentTemplate>
                               <asp:DropDownList ID="ddlcountry" AutoPostBack="true" AppendDataBoundItems="true" runat="server"  CssClass="ddltthanh" ValidationGroup="GInfo" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged"></asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlcountry" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
       <td style=" width:200px">
             <asp:UpdatePanel ID="statepanel" runat="server">
                    <ContentTemplate>
                              <asp:DropDownList ID="ddlstate" AutoPostBack="true" AppendDataBoundItems="true" runat="server" ValidationGroup="GInfo" CssClass="ddltthanh" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"></asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlstate" />
                    </Triggers>
                </asp:UpdatePanel>
        </td>
        <td></td>
         <td></td>
         <td></td>
         <td></td>
        </tr>
            </table>
          
               
      </div>


<div style="margin-top:10px;"  class="frm_search">
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
    <tr>
        <td>
            <asp:Label ID="lbl_curpage" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
            <asp:Literal ID="ltmsg" runat="server"></asp:Literal>&nbsp;
        </td>
      <td class="topcontent" style="width: 50%">
                            <%if (ShowThem == "1")
                                {%>
                              &nbsp;<asp:Button ID="btthemmoi" runat="server" ForeColor="Green" OnClick="btthemmoi_Click" Text="Thêm mới" Width="87px" />
                            <%} %>
                            <asp:Button ID="btn_Homepage" runat="server" OnClick="btn_Homepage_Click" Text="Root Cate" Width="92px" ForeColor="Green" />
                            <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="<<< Back" Width="96px" ForeColor="Green" />
                            <%if (ShowXoa == "1")
                                {%>
                            <asp:Button ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="35px" ForeColor="Green" />
                            <%} %>
                        </td>
    </tr>
</table>
</div>
<div  class="list_item">
 <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
	<ItemTemplate>
	<tr style="background-color:#f1f1f1"  height="40">
           <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
            <td>
              <%#DataBinder.Eval(Container.DataItem,"Name")%> Gram
           </td>
         <td>
              <%#Name(Eval("Views").ToString())%> / <%#Name(Eval("Parent_ID").ToString())%> 
           </td>
            <td align="center">
              <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Noidung1").ToString())%>
           </td>
             <td align="center">
              <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Noidung2").ToString())%>
           </td>
             <td align="center">
              <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Noidung3").ToString())%>
           </td>
             <td align="center">
              <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Noidung4").ToString())%>
           </td>
            <td align="center">
                <asp:LinkButton ID="LinkButton7" CommandName="Tang"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' Runat="server">[Tăng]</asp:LinkButton>
                <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                <asp:LinkButton ID="LinkButton8" CommandName="Giam"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' Runat="server">[Giảm]</asp:LinkButton>
           </td>
           <td align="center">
               <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
           </td>
        <td align="center">
                                <%if (ShowSua == "1")
                                    {%>
                                <asp:LinkButton ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[<%=label("lt_edit")%>]</asp:LinkButton>

                                <%} %>
                            </td>
                            <td align="center">
                                <%if (ShowXoa == "1")
                                    {%>
                                <div class="del">
                                    <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">[<%=label("ldelete")%>]</asp:LinkButton>
                                </div>
                                <%} %>
                            </td>
     </tr>
	</ItemTemplate>
	<AlternatingItemTemplate>
	<tr style="background-color: #ffff" height="40">
		<td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
            <td>
            <%#DataBinder.Eval(Container.DataItem,"Name")%> Gram
           </td>
          <td>
              <%#Name(Eval("Views").ToString())%> / <%#Name(Eval("Parent_ID").ToString())%> 
           </td>
            <td align="center">
              <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Noidung1").ToString())%>
           </td>
             <td align="center">
              <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Noidung2").ToString())%>
           </td>
             <td align="center">
              <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Noidung3").ToString())%>
           </td>
             <td align="center">
              <%#MoreAll.MorePro.FormatMoney_Cart(Eval("Noidung4").ToString())%>
           </td>
          <td align="center">
                <asp:LinkButton ID="LinkButton7" CommandName="Tang"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' Runat="server">[Tăng]</asp:LinkButton>
                <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                <asp:LinkButton ID="LinkButton8" CommandName="Giam"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' Runat="server">[Giảm]</asp:LinkButton>
           </td>
           <td align="center">
               <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
           </td>
         <td align="center">
                                <%if (ShowSua == "1")
                                    {%>
                                <asp:LinkButton ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server">[<%=label("lt_edit")%>]</asp:LinkButton>

                                <%} %>
                            </td>
                            <td align="center">
                                <%if (ShowXoa == "1")
                                    {%>
                                <div class="del">
                                    <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">[<%=label("ldelete")%>]</asp:LinkButton>
                                </div>
                                <%} %>
                            </td>
     </tr>
	</AlternatingItemTemplate>
	<HeaderTemplate>
		<table  border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
			 <tr bgcolor="#C4C4C4" height="22">
			    <td class="header"><input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
				<td class="header"><%=label("answers_title")%></td>
                 	<td class="header">Tỉnh thành</td>
				<td class="header">ATM- Nhanh</td>
                 <td class="header">ATM- Chậm</td>
                 <td class="header">COD - Nhanh</td>
                 <td class="header">COD - Chậm</td>
				<td class="header"><%=label("lt_order")%></td>
				<td class="header"><%=label("l_status")%></td>
				<td class="header"><%=label("lt_edit")%></td>
				<td class="header"><%=label("ldelete")%></td>
			</tr>
	</HeaderTemplate>
<FooterTemplate>
</table>				
</FooterTemplate>
</asp:Repeater>

</div>
<table  style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%"	border="0">
    <tr height="20"><td></td></tr>
	<tr height="25" bgcolor="whitesmoke">
	<td>
                         <%if (ShowThem == "1")
                            {%>
                        <asp:LinkButton ID="LinkButton5" Font-Bold="true" OnClick="LinkButton4_Click" runat="server">[<%=label("l_createnew")%>]</asp:LinkButton>
                        <%} %>
                    </td></tr>
</TABLE>
</asp:panel>

<asp:panel id="pn_insert" runat="server" Visible="False" Width="100%">
<div class='frm-add'>
<table  style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
<tr>
    <td align="right" width="175"></td>
    <td width="10"></td>
    <td>
        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    </td>
</tr>

<tr>
    <td align="right">Tỉnh thành</td>
    <td></td>
    <td>
       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                               <asp:DropDownList ID="ddltinhthanh" AutoPostBack="true" AppendDataBoundItems="true" runat="server"  CssClass="ddltthanh" ValidationGroup="themmoitt" OnSelectedIndexChanged="ddltinhthanh_SelectedIndexChanged"></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Text="*" InitialValue="0" ControlToValidate="ddltinhthanh" ValidationGroup="themmoitt"></asp:RequiredFieldValidator> 
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddltinhthanh" />
                    </Triggers>
                </asp:UpdatePanel>
    </td>
</tr>
<tr>
    <td align="right">Quận huyện</td>
    <td></td>
    <td>
          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                              <asp:DropDownList ID="ddlquanhuyen" runat="server" ValidationGroup="themmoitt" CssClass="ddltthanh" ></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Text="*" InitialValue="0" ControlToValidate="ddlquanhuyen" ValidationGroup="themmoitt"></asp:RequiredFieldValidator> 
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlquanhuyen" />
                    </Triggers>
                </asp:UpdatePanel>
    </td>
</tr>
<tr>
    <td align="right"><%=label("answers_title")%>/ Gram</td>
    <td></td>
    <td>
        <asp:TextBox ID="txt_title" CssClass="txt_css" runat="server" Width="150px"></asp:TextBox>
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers" TargetControlID="txt_title"></cc1:FilteredTextBoxExtender>
    </td>
</tr>
    <tr>
    <td align="left" colspan="3">
       Thanh toán qua ngân hàng và nhận hàng qua dịch vụ chuyển phát</td>
</tr>

<tr>
    <td align="right">
      Giá tiền/Chuyển nhanh</td>
    <td>
    </td>
    <td>
        <asp:TextBox ID="txttu" runat="server" CssClass="txt_css" Width="150px"></asp:TextBox>đ
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txttu"></cc1:FilteredTextBoxExtender>
    </td>
</tr>
<tr>
    <td align="right">
        Giá tiền/Chuyển chậm</td>
    <td>
    </td>
    <td>
        <asp:TextBox ID="txtden" runat="server" CssClass="txt_css" Width="150px"></asp:TextBox>đ
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers" TargetControlID="txtden"></cc1:FilteredTextBoxExtender>
    </td>
</tr>


     <tr>
    <td align="left" colspan="3">
       COD - Nhận hàng và thanh toán cho nhân viên giao hàng</td>
</tr>

<tr>
    <td align="right">
      Giá tiền/Chuyển nhanh</td>
    <td>
    </td>
    <td>
        <asp:TextBox ID="txtnhanh" runat="server" CssClass="txt_css" Width="150px"></asp:TextBox> đ
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers" TargetControlID="txtnhanh"></cc1:FilteredTextBoxExtender>
    </td>
</tr>
<tr>
    <td align="right">
        Giá tiền/Chuyển chậm</td>
    <td>
    </td>
    <td>
        <asp:TextBox ID="txtcham" runat="server" CssClass="txt_css" Width="150px"></asp:TextBox>đ
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers" TargetControlID="txtcham"></cc1:FilteredTextBoxExtender>
    </td>
</tr>




        <asp:CheckBox ID="chknews"  Visible=false CssClass="txt_css2" runat="server" Text="Mới" />
          <asp:CheckBox ID="chkTrangChu"   Visible=false  CssClass="txt_css2" runat="server" Text="Trang chủ" />  
<tr>
    <td align="right">
        <%=label("lt_order")%>
    </td>
    <td></td>
    <td>
        <asp:TextBox ID="txt_order" runat="server" CssClass="txt_css" Width="32px"></asp:TextBox>
    </td>
</tr>
<tr>
    <td align="right">
        <%=label("lt_display")%>
    </td>
    <td></td>
    <td>
        <asp:CheckBox ID="chck_Enable" CssClass="txt_css2"  runat="server" Visible="True" />
</tr>
<tr>
    <td align="right"></td>
    <td></td>
    <td>
        <asp:Button ID="btn_InsertUpdate" ValidationGroup="themmoitt"  runat="server"  OnClick="btn_InsertUpdate_Click" Text="Insert/Update" Width="120px" />
        <asp:Button ID="btnCancel" runat="server"   OnClick="btnCancel_Click" Text="Cancel" Width="56px" />
    </td>
</tr>
</table>
</div>
<asp:HiddenField ID="hdFileName" runat="server" />
<asp:HiddenField ID="hdid" runat="server" />
</asp:panel>                                  
<INPUT id="hd_insertupdate" type="hidden" size="1" name="Hidden1" runat="server">
<INPUT id="hd_id" type="hidden" size="1" name="Hidden2" runat="server">
<INPUT id="hd_page_edit_id" type="hidden" size="1" name="Hidden2"	runat="server">
<INPUT id="hd_imgpath" type="hidden" size="1" name="Hidden2" runat="server">
<INPUT id="hd_rootpic" type="hidden" size="1" runat="server">
<INPUT id="hd_par_id" type="hidden" size="1" name="Hidden2" runat="server">
   </contenttemplate>
     <Triggers>
<asp:PostBackTrigger ControlID="btn_InsertUpdate" />
</Triggers>
</asp:UpdatePanel>