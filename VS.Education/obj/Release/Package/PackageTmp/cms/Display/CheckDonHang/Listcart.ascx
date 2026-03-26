<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Listcart.ascx.cs" Inherits="VS.E_Commerce.cms.Display.CheckDonHang.Listcart" %>

<div class="main-content">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="blog-home-title clearfix">
					<h1>Lịch sử mua hàng</h1>
				</div>
				<div class="blog-article clearfix">
          <div style=" clear:both"></div>
  <div class='frm_cart'>
<div class="bgContent">
	<div class="borderBlock_ListPro">

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
    <asp:repeater id="rp_items" runat="server" OnItemCommand="rp_items_ItemCommand">
<ItemTemplate>
    <tr>
    <td height="30" align="center" class="TitleItem"><%= i++ %></td>
    <td align="left" class="TitleItem">0000<%# Eval("ID") %></td>
    <td align="center" class="TitleItem"><%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date").ToString())%></td>
    <td align="center" class="TitleItem"> <%#Soluong(Eval("ID").ToString())%></td>
    <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney(Eval("Money").ToString())%></td>
    <td align="center" class="TitleItem"> <%#Status(Eval("ID").ToString())%></td>
    <td align="center">
    <asp:LinkButton ID="LinkButton5" CommandName="Chitiet" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' Runat="server">Xem chi tiết</asp:LinkButton>
    </td>
    </tr>
</ItemTemplate>
<AlternatingItemTemplate>
    <tr style="background:#fff5ee;">
    <td height="30" align="center" class="TitleItem"><%= i++ %></td>
    <td align="left" class="TitleItem">0000<%# Eval("ID") %></td>
    <td align="center" class="TitleItem"><%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date").ToString())%></td>
    <td align="center" class="TitleItem"> <%#Soluong(Eval("ID").ToString())%></td>
    <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney(Eval("Money").ToString())%></td>
    <td align="center" class="TitleItem"> <%#Status(Eval("ID").ToString())%></td>
    <td align="center">
    <asp:LinkButton ID="LinkButton5" CommandName="Chitiet" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' Runat="server">Xem chi tiết</asp:LinkButton>
    </td>
    </tr>
</AlternatingItemTemplate>

<HeaderTemplate>
 <table  cellpadding="0" cellspacing="0" class="dcart" width="100%" bgcolor="#FFFFFF" bordercolor="#C3C3C3">
<tr class="procart">
	     <td align="left"><strong>STT</strong></td>
        <td align="center"><strong>Mã đơn</strong></td>
        <td align="center"><strong>Ngày đặt hàng</strong></td>
        <td align="center"><strong>Số lượng SP</strong></td>
        <td align="center"><strong>Tổng giá tiền</strong></td>
        <td align="center"><strong>Tình trạng xử lý</strong></td>
          <td align="center"><strong>Chi tiết</strong></td>
        </tr>
</HeaderTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:repeater>
    </asp:View>
     <asp:View ID="View2" runat="server">
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <table  cellpadding="0" cellspacing="0" class="dcart" width="100%" bgcolor="#FFFFFF" bordercolor="#C3C3C3">
    <asp:Repeater id="rpcartdetail" runat="server"  OnItemDataBound="ItemDataBound_RP" OnItemCommand="rpcartdetail_ItemCommand" >
	<HeaderTemplate>
	    <tr class="procart">
        <td align="left"><strong>STT</strong></td>
        <td align="left"><strong>Hinh Ảnh</strong></td>
        <td align="center"><strong>Mã sản phẩm</strong></td>
        <td align="center"><strong>Tên sản phẩm</strong></td>
        <td align="center"><strong>Ngày đặt hàng</strong></td>
        <td align="center"><strong>Giá</strong></td>
        <td align="center"><strong>Số lượng</strong></td>
        <td align="center"><strong>Thành tiền</strong></td>
        <td align="center"><strong>Trạng thái</strong></td>
        <td align="right"><strong>[<%=label("ldelete")%>]</strong></td>
        </tr>
	</HeaderTemplate> 
	<ItemTemplate>
	   <tr  align=center>
        <td height="30" align="center" class="TitleItem"> <asp:Label ID="lb_tt" runat="server"></asp:Label><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
        <td align="left" class="TitleItem"> <%#Images(Eval("ID").ToString())%></td>
        <td align="center" class="TitleItem"><%#Code(Eval("ID").ToString())%></td>
        <td align="center" class="TitleItem"> <%#Name(Eval("ID").ToString())%></td>
        <td align="center" class="TitleItem"> <%#CreateDate(Eval("ID_Cart").ToString())%></td>
        <td align="center" class="TitleItem"> <%#Price(Eval("ipid").ToString())%></td>
         <td align="center" class="TitleItem"> 
            <div id="Div1" runat=server  Visible='<%#Anhien(Eval("ID_Cart").ToString())%>'>
            <asp:TextBox ID="txtxQuantity" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity")%>' CssClass="txt_css" Width="40px" runat="server" OnTextChanged="txtxQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
            <div id="Div3" runat=server  Visible='<%#Anhien2(Eval("ID_Cart").ToString())%>'>
            <%#DataBinder.Eval(Container.DataItem, "Quantity")%>
            </div>
        </td>
        <td align="center" class="TitleItem"><b><%#MoreAll.MorePro.FormatMoney(Eval("Money").ToString())%></b></td>
        <td align="center" class="TitleItem"> <span><%#Status(Eval("ID_Cart").ToString())%></span></td>
        <td align="center"><div id="Div2" runat=server  Visible='<%#EnableUnLock(Eval("ID_Cart").ToString())%>'><asp:LinkButton ID="LinkButton4" CommandName="delete" OnLoad="Delete_Load"  CssClass="lnk" CommandArgument='<%#Eval("id")%>' runat=server>[Xóa]</asp:LinkButton></div></td>
        </div>
        </tr>
	</ItemTemplate> 
	<AlternatingItemTemplate>
		 <tr style="background:#fff5ee;">
         <td height="30" align="center" class="TitleItem"> <asp:Label ID="lb_tt" runat="server"></asp:Label><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
        <td align="left" class="TitleItem"> <%#Images(Eval("ID").ToString())%></td>
        <td align="center" class="TitleItem"> <%#Code(Eval("ID").ToString())%></td>
        <td align="center" class="TitleItem"> <%#Name(Eval("ID").ToString())%></td>
        <td align="center" class="TitleItem"> <%#CreateDate(Eval("ID_Cart").ToString())%></td>
        <td align="center" class="TitleItem"> <%#Price(Eval("ipid").ToString())%></td>
       <td align="center" class="TitleItem"> 
            <div id="Div1" runat=server  Visible='<%#Anhien(Eval("ID_Cart").ToString())%>'>
            <asp:TextBox ID="txtxQuantity" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity")%>' CssClass="txt_css" Width="40px" runat="server" OnTextChanged="txtxQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
            <div id="Div3" runat=server  Visible='<%#Anhien2(Eval("ID_Cart").ToString())%>'>
            <%#DataBinder.Eval(Container.DataItem, "Quantity")%>
            </div>
        </td>
        <td align="center" class="TitleItem"><b><%#MoreAll.MorePro.FormatMoney(Eval("Money").ToString())%></b></td>
        <td align="center" class="TitleItem"> <span><%#Status(Eval("ID_Cart").ToString())%></span></td>
        <td align="center"><div id="Div4" runat=server  Visible='<%#EnableUnLock(Eval("ID_Cart").ToString())%>'><asp:LinkButton ID="LinkButton4" CommandName="delete" OnLoad="Delete_Load"  CssClass="lnk" CommandArgument='<%#Eval("id")%>' runat=server>[Xóa]</asp:LinkButton></div></td>
        </tr>
	</AlternatingItemTemplate>     
    </asp:Repeater>
</table>


         <div class="bacoc" style="width:100%">
<span class="order-header"><%=label("phthanhtoan")%> </span>
<div class="maunen" style="width:100%">
<div class="cus-payment">
  <p class="clearfix">
    <label class="borderPayment">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                     <asp:RadioButton ID="rdcuahang" AutoPostBack="true" runat="server" Text="Thanh toán và giao hàng tại cửa hàng" GroupName="payments" Checked="true" OnCheckedChanged="rdcuahang_CheckedChanged"></asp:RadioButton> <span style="color:red">(<%=label("Thanhtoann2") %>)</span>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rdcuahang" />
                    </Triggers>
                </asp:UpdatePanel>
    </label>
          <label class="borderPayment">
          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
                  <asp:RadioButton ID="rdATM" runat="server" AutoPostBack="true" GroupName="payments" OnCheckedChanged="rdATM_CheckedChanged" Text="Thanh toán qua ngân hàng và nhận hàng qua dịch vụ chuyển phát" />
              </ContentTemplate>
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="rdATM" />
              </Triggers>
          </asp:UpdatePanel>
          </label>
      <asp:Panel ID="PlATM"  Visible="false" runat="server">
          <div style=" margin-left:20px">
              <label class="borderPayment">
              <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                  <ContentTemplate>
                      <asp:RadioButton ID="rdChuyennhanhATM" runat="server" AppendDataBoundItems="true" AutoPostBack="true" Checked="true" GroupName="ATM" OnCheckedChanged="rdChuyennhanhATM_CheckedChanged" Text="Chuyển Nhanh" /><span style=" color:red"><asp:Literal ID="txtatmlnhanh" runat="server"></asp:Literal></span>
                  </ContentTemplate>
                  <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="rdChuyennhanhATM" />
                  </Triggers>
              </asp:UpdatePanel>
              </label>
              <label class="borderPayment">
              <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                  <ContentTemplate>
                      <asp:RadioButton ID="rdChuyenchamATM" runat="server" AppendDataBoundItems="true" AutoPostBack="true" GroupName="ATM" OnCheckedChanged="rdChuyenchamATM_CheckedChanged" Text="Chuyển chậm" /><span style=" color:red"><asp:Literal ID="ltatmlcham" runat="server"></asp:Literal></span>
                  </ContentTemplate>
                  <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="rdChuyenchamATM" />
                  </Triggers>
              </asp:UpdatePanel>
              </label>
          </div>
      </asp:Panel>
          </label>
              <label class="borderPayment">
              <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                  <ContentTemplate>
                      <asp:RadioButton ID="rdCOD" runat="server" AppendDataBoundItems="true" AutoPostBack="true" GroupName="payments" OnCheckedChanged="rdCOD_CheckedChanged" Text="COD - Nhận hàng và thanh toán cho nhân viên giao hàng" />
                  </ContentTemplate>
                  <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="rdCOD" />
                  </Triggers>
              </asp:UpdatePanel>
              </label>

      <asp:Panel ID="PlCODE"  Visible="false" runat="server">
              <div style=" margin-left:20px">
                  <label class="borderPayment">
                  <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                      <ContentTemplate>
                          <asp:RadioButton ID="rdChuyennhanhCOD" runat="server" AppendDataBoundItems="true" AutoPostBack="true" Checked="true" GroupName="COD" OnCheckedChanged="rdChuyennhanhCOD_CheckedChanged" Text="Chuyển Nhanh" /><span style=" color:red"><asp:Literal ID="ltcodenhanh" runat="server"></asp:Literal></span>
                      </ContentTemplate>
                      <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="rdChuyennhanhCOD" />
                      </Triggers>
                  </asp:UpdatePanel>
                  </label>
                  <label class="borderPayment">
                  <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                      <ContentTemplate>
                          <asp:RadioButton ID="rdChuyenchamCOD" runat="server" AppendDataBoundItems="true" AutoPostBack="true" GroupName="COD" OnCheckedChanged="rdChuyenchamCOD_CheckedChanged" Text="Chuyển chậm" /><span style=" color:red"><asp:Literal ID="ltcodecham" runat="server"></asp:Literal></span>
                      </ContentTemplate>
                      <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="rdChuyenchamCOD" />
                      </Triggers>
                  </asp:UpdatePanel>
                  </label>
              </div>
           </asp:Panel>
              <div style="background: #eee; border: 1px solid #ccc; padding: 5px 10px; display: none">
                  <i class="clgray s11"><span class="marker"><span style="margin: 0px; padding: 0px; word-wrap: break-word;"><strong style="margin: 0px; padding: 0px; word-wrap: break-word;"><%=label("tt5")%>:</strong> </span></span>
                  <asp:Literal ID="txtgiohang" runat="server"></asp:Literal>
</div></div>
 </div>


             </div>
                <asp:HiddenField ID="hdgiohang" Value="0" runat="server" />

                <asp:HiddenField ID="ATMNhanh" Value="0" runat="server" />
        <asp:HiddenField ID="ATMCham" Value="0" runat="server" />
        <asp:HiddenField ID="CodeNhanh" Value="0" runat="server" />
        <asp:HiddenField ID="CodeCham" Value="0" runat="server" />

         <asp:HiddenField ID="hdtinhthanh" Value="0" runat="server" />

    <asp:HiddenField ID="hdtongGram" runat="server" />
    <asp:HiddenField ID="hdtongtien" runat="server" />
        <br />
   <div style=" color:red; padding-bottom:5px;">Tổng tiền: <asp:Literal ID="ltTotalOrder" runat="server"></asp:Literal></div>
   <div style=" color:red; padding-bottom:5px;">Tổng Trọng lượng: <asp:Literal ID="lttrongluong" runat="server"></asp:Literal></div>
   <div style=" color:red; padding-bottom:5px;"> Tổng thanh toán: <asp:Literal ID="ltthanhtoan" runat="server"></asp:Literal></div>  
         
        <br />
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
<div id="loadingAjax">
<div class="inner"><img src="/Resources/ShopCart/images/ajax-loader_2.gif"><p><%=label("dangxuly") %>...</p></div>
</div>
</ProgressTemplate>
</asp:UpdateProgress>
</ContentTemplate>
<Triggers>
</Triggers>
</asp:UpdatePanel>

   </asp:View>
    </asp:MultiView>
   
</div>
</div>                      
</div>
</div>

                </div>
            </div>
        </div>
    </div>

