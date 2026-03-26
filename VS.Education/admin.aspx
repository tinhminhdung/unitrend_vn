<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="VS.E_Commerce.admin1" ValidateRequest="false" enableeventvalidation="false" viewStateEncryptionMode="Never" EnableViewStateMac="false"%>


<%@ Register src="Cms/Admin/Control.ascx" tagname="Control" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>::. HỆ THỐNG QUẢN TRỊ WEBSITE Vision 4.0 .::</title>
    <meta name="generator" content="Tịnh Minh Dũng (0976.658.433)" />
    <meta name="copyright" content="Tịnh Minh Dũng (0976.658.433)" />
    <meta name="author" content="Tịnh Minh Dũng (0976.658.433)" />    <link href="/Resources/admin/css/dialog.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/admin/css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/admin/css/Manager.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/admin/PopUp/css/publish.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/admin/PopUp/css/style.css" rel="stylesheet" type="text/css" />
<%--    <link href="/Resources/admin/js/Loadpage/pace-theme-flash.css" rel="stylesheet" type="text/css" />--%>
    <script src="/Resources/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Resources/admin/js/jquery-ui.js" type="text/javascript"></script>
    <script language="javascript" src="/Resources/js/newwindow.js"></script>
    <link href="/Resources/admin/css/Menu.css" rel="stylesheet" />

    <style type="text/css">
        #toTop
        {
            width: 100px;
            text-align: center;
            font-size: 12px;
            padding: 5px;
            position: fixed;
            bottom: 10px;
            right: 10px;
            cursor: pointer;
            font-weight: bold;
            text-decoration: none;
        }
    </style>
</head>
<body>
   
    <script language="javascript" src="/Resources/js/Top/jquery.easing.js" type="text/javascript"></script>
    <script language="javascript" src="/Resources/js/Top/jquery.scroll.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#toTop").scrollToTop({ speed: 1000, ease: "easeOutExpo", start: 150 });
        });
    </script>

<%--    <script type="text/javascript" src="/Resources/admin/js/Loadpage/pace.js"></script>--%>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
    function confirmDelete(spanChk)
     {
        var oItem = spanChk.children;
        var theBox= (spanChk.type=="checkbox")?spanChk : spanChk.children.item[0];
        var elm=<%=checkboxs.ClientID %>.getElementsByTagName("input");
        var haveChoose = new Boolean();
        haveChoose = true;
        var ok = new Boolean();
        ok == false;
        for(i=0;i<elm.length;i++)                   
            if(elm[i].type=="checkbox")                         
                if(elm[i].checked == haveChoose) ok = true;
        if(ok == haveChoose)
            return confirm('Bạn muốn xóa những thông tin này ?');
        else
            return confirm('Bạn chưa chọn thông tin nào để xóa !');                       
     }     
    function changeColor(CheckBoxObj,color) 
    {         
        if (CheckBoxObj.checked == true) 
        {
            CheckBoxObj.parentNode.parentNode.style.backgroundColor='#e6f5de'; 
        }else
         if (CheckBoxObj.checked == false) 
        {
            CheckBoxObj.parentNode.parentNode.style.backgroundColor='#FAF9FA'; 
        }
    }    
   function SelectAllCheckboxes(spanChk){
   // Added as ASPX uses SPAN for checkbox
   var oItem = spanChk.children;
   var theBox= (spanChk.type=="checkbox") ? 
        spanChk : spanChk.children.item[0];
   xState=theBox.checked;
   elm=theBox.form.elements;

   for(i=0;i<elm.length;i++)
     if(elm[i].type=="checkbox" && 
              elm[i].id!=theBox.id)
     {
       //elm[i].click();
       if(elm[i].checked!=xState)
         elm[i].click();
       //elm[i].checked=xState;
     } 
     } 
    </script>
    <div id="checkboxs" runat="server">
        <uc1:control id="Control1" runat="server" />
    </div>
    </form>
    <a href="#" id="toTop"><span style="color: Red">
        <img src="/Resources/images/top_page.png" /></span>
    </a>
</body>
</html>
