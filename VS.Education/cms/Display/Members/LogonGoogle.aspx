<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogonGoogle.aspx.cs" Inherits="VS.E_Commerce.cms.Display.Members.LogonGoogle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="google-signin-scope" content="profile email">
    <meta name="google-signin-client_id" content="799254431895-bd2d9ufqe82r3tpl9j7d8plqvg09mge2.apps.googleusercontent.com">
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    <script src="/Resources/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="g-signin2" data-onsuccess="onSignIn" data-theme="dark">
        </div>
       <%-- <%if (Session["Google"] == null)
          { %>
        <script>
            function onSignIn(googleUser) {
                var profile = googleUser.getBasicProfile();
                $.ajax({
                    url: '<%=ResolveUrl("~/index.aspx/LogonGoogle") %>',
                    data: "{ 'ID': '" + profile.getId() + "','FullName': '" + profile.getName() + "','Email': '" + profile.getEmail() + "','Image': '" + profile.getImageUrl() + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                      //  window.location.href = "/";
                    }
                });
            };
        </script>
        <%} %>--%>

          <script>
              function onSignIn(googleUser) {
                  // Useful data for your client-side scripts:
                  var profile = googleUser.getBasicProfile();
                  console.log("ID: " + profile.getId()); // Don't send this directly to your server!
                  console.log('Full Name: ' + profile.getName());
                  console.log('Given Name: ' + profile.getGivenName());
                  console.log('Family Name: ' + profile.getFamilyName());
                  console.log("Image URL: " + profile.getImageUrl());
                  console.log("Email: " + profile.getEmail());

                  // The ID token you need to pass to your backend:
                  var id_token = googleUser.getAuthResponse().id_token;
                  console.log("ID Token: " + id_token);
              };
    </script>
    </div>
    </form>
</body>
</html>
