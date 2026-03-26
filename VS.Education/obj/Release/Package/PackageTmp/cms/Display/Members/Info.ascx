<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Info.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Members.Info" %>
<%@ Register Src="~/cms/Display/Nav_conten.ascx" TagPrefix="uc1" TagName="Nav_conten" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<uc1:Nav_conten runat="server" ID="Nav_conten1" />
<style>
    .blog-home-title h1:after {
        border-left: 0px solid #fff;
    }
</style>

<div class="main-content">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <div class="blog-home-title clearfix">
                    <h1><%=label("ttthanhvien") %>
                    </h1>
                </div>
                <div class="blog-article clearfix">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="frm-add" style="padding: 10px">
                                <div class="gachke">
                                    <div class="tenthanhvien"><%=label("l_username")%> :</div>
                                    <div>
                                        <asp:Literal ID="ltnickname" runat="server"></asp:Literal></div>
                                </div>
                                <div class="gachke">
                                    <div class="tenthanhvien"><%=label("lt_fullname")%> :</div>
                                    <div>
                                        <asp:Literal ID="ltlname" runat="server"></asp:Literal></div>
                                </div>
                               
                                <div class="gachke">
                                    <div class="tenthanhvien"><%=label("l_phone")%> :</div>
                                    <div>
                                        <asp:Literal ID="ltphone" runat="server"></asp:Literal></div>
                                </div>
                                <div class="gachke">
                                    <div class="tenthanhvien">Email :</div>
                                    <div>
                                        <asp:Literal ID="ltemail" runat="server"></asp:Literal></div>
                                </div>


                                <div class="gachke">
                                    <div class="tenthanhvien">Địa chỉ (Tỉnh/TP):</div>
                                    <div >
                                        <asp:Literal ID="ltdiachithanhpho" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="gachke">
                                    <div class="tenthanhvien">Quận/ Huyện/ Thị xã:</div>
                                    <div>
                                        <asp:Literal ID="ltquanhuyen" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="gachke">
                                    <div class="tenthanhvien">Phường xã:</div>
                                    <div>
                                        <asp:Literal ID="ltphuongxa" runat="server"></asp:Literal>
                                    </div>
                                </div>

                              <div class="gachke">
     <div class="tenthanhvien"><%=label("l_address")%> :</div>
     <div>
         <asp:Literal ID="ltaddress" runat="server"></asp:Literal></div>
 </div>
                                <asp:Literal ID="ltregion" runat="server"></asp:Literal>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="col-md-3">
                <uc1:Lefmenu runat="server" ID="Lefmenu" />
            </div>
        </div>
    </div>


</div>
