<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="VS.E_Commerce.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Resources/js/jquery-1.7.1.min.js"></script>
     <script type="text/javascript" src="https://unica.vn/media/js/readmore.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <li video-url="8486">
            <a>
                <span class="thoigian">
                    <button onclick="preview_freetrial(this);" class="hoc-thu-btn">Học thử</button>
                </span>
            </a>
        </li>
         <script language="javascript" type="text/javascript">
             function preview_freetrial(obj) {
                 debugger;
                 var url = $(obj).parent().parent().parent().attr('video-url');
                 $.ajax({
                     url: 'https://unica.vn/course_action/preview',
                     type: 'POST',
                     data: { id: url },
                     success: function (result) {
                         if (result.success) {
                             $('.popup_success').append("" + result.data.html + "");
                         }
                     }
                 });

             }

    </script>
     <div class="popup_success" style="width:650px;height:500px;margin:auto;">
            </div>
    </div>
    </form>
</body>
</html>
