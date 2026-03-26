using System;
using System.Text.RegularExpressions;
using System.Web;

public static class WebFirewall
{
    // kiểm tra request hợp lệ
    public static bool IsValidRequest(HttpRequest request)
    {
        string hp = request["hp"] ?? "";
        string ipid = request["ipid"] ?? "";

        // ipid phải là số
        if (!string.IsNullOrEmpty(ipid))
        {
            if (!int.TryParse(ipid, out _))
                return false;
        }

        // hp chỉ cho phép chữ số và -
        if (!string.IsNullOrEmpty(hp))
        {
            if (!Regex.IsMatch(hp, @"^[a-zA-Z0-9\-/]+$"))
                return false;
        }

        // query quá dài (scan bot)
        if (request.Url.Query.Length > 300)
            return false;

        // chặn ký tự nguy hiểm
        string raw = request.RawUrl.ToLower();
        if (raw.Contains("<script") || raw.Contains("select ") || raw.Contains("drop "))
            return false;

        return true;
    }

    public static void Show400(HttpContext context)
    {
        context.Response.Clear();
        context.Response.StatusCode = 400;
        context.Server.Transfer("~/page-400.html");
    }

    public static void Show404(HttpContext context)
    {
        context.Response.Clear();
        context.Response.StatusCode = 404;
        context.Response.TrySkipIisCustomErrors = true;
        context.Response.Redirect("/page-404.html", false);
        context.ApplicationInstance.CompleteRequest();
    }
}