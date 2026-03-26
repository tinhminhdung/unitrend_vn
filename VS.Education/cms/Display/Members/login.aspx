<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="VS.E_Commerce.cms.Display.Members.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Resources/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Resources/js/Facebook.js"></script>
<script src="https://apis.google.com/js/api:client.js"></script>

<script type="text/javascript">
    var googleUser = {};
    var startApp = function () {
        gapi.load('auth2', function () {
            // Retrieve the singleton for the GoogleAuth library and set up the client.
            auth2 = gapi.auth2.init({
            // link tạo ra mã như simgiare4g https://console.developers.google.com/apis/credentials?project=singiare4gcom
                // client_id: '799254431895-4kndkikql1c3nk5c2oidfr0dlfk2k18s.apps.googleusercontent.com',
                client_id: '799254431895-bd2d9ufqe82r3tpl9j7d8plqvg09mge2.apps.googleusercontent.com',
                cookiepolicy: 'single_host_origin',
            });
            attachSignin(document.getElementById('customBtn'));
        });
    };
    function attachSignin(element) {
        console.log(element.id);
        auth2.attachClickHandler(element, {},
           function (googleUser) {
//             var profile = googleUser.getBasicProfile();
//            $.ajax({
//                url: '<%=ResolveUrl("~/index.aspx/LogonGoogle") %>',
//                data: "{ 'ID': '" + profile.getId()+ "','FullName': '" + profile.getName() + "','Email': '" + profile.getEmail() + "','Image': '" + profile.getImageUrl() + "' }",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//            });
//            window.location.href = "/";
            window.location.href = "/CheckGoogle/" + googleUser.getBasicProfile().getId() + "-" + googleUser.getBasicProfile().getName() + "-" + googleUser.getBasicProfile().getEmail();
            }, function (error) {
                alert(JSON.stringify(error, undefined, 2));
            });
    }
</script>
    // + googleUser.getBasicProfile().getlink() +  googleUser.getBasicProfile().getpicture() +  googleUser.getBasicProfile().getgender() +  googleUser.getBasicProfile().getlocale() + ""
</head>
<body>

    <form id="form1" runat="server">
    <div>

    <style type="text/css">
    #customBtn {
      display: inline-block;
      background: #4285f4;
      color: white;
      width: 190px;
      border-radius: 5px;
      white-space: nowrap;
    }
    #customBtn:hover {
      cursor: pointer;
    }
    span.label {
      font-weight: bold;
    }
    span.icon {
      background: url('/identity/sign-in/g-normal.png') transparent 5px 50% no-repeat;
      display: inline-block;
      vertical-align: middle;
      width: 42px;
      height: 42px;
      border-right: #2265d4 1px solid;
    }
    span.buttonText {
      display: inline-block;
      vertical-align: middle;
      padding-left: 42px;
      padding-right: 42px;
      font-size: 14px;
      font-weight: bold;
      /* Use the Roboto font that is loaded in the <head> */
      font-family: 'Roboto', sans-serif;
    }
  </style>


    <div class="noidung">
        <p>
            <img style="cursor: pointer; width: 235px; margin-top: 0px; margin-bottom: 0px; padding-bottom: 0px; border-bottom-width: 0px; padding-top: 51px;" onclick="openWindow(linkFaceBook,'Login',415,305)" src="/Resources/images/log3.png">
        </p>
        <p>
            <br />
            <div style="clear: both; height: 20px"></div>
            <span class="label">Sign in with:</span>
            <div id="gSignInWrapper">
                <div id="customBtn" class="customGPlusSignIn">
                    <span class="icon"></span>
                    <span class="buttonText">Google</span>
                </div>
            </div>
            <div id="name"></div>
            <script>startApp();</script>
        </p>
        <div>
            <ul>
                <li>Tạo tài khoản dễ dàng chỉ với click chuột</li>
                <li>Dễ dàng chia sẻ với bạn bè</li>
            </ul>
            <div style="clear: both"></div>
        </div>
    </div>
    
    </div>
    </form>
</body>
</html>
