using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Entity;
using Framework;
using Services;
using MoreAll;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Globalization;


#region Url
public class Url
{
    public static string Url1(string Css, string Url, string ID1, string UrlName, string Name, string Alt, string Title)
    {
        return "<a  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"   " + Css + " href='/" + Url + "/" + ID1 + "/" + RewriteURL.GetRewriteURL(UrlName) + "'>" + Name + "</a>";
    }
    public static string Url2(string Css, string Url, string ID1, string ID2, string UrlName, string Name, string Alt, string Title)
    {
        return "<a alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"   " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + RewriteURL.GetRewriteURL(UrlName) + "'>" + Name + "</a>";
    }
    public static string Url3(string Css, string Url, string ID1, string ID2, string ID3, string UrlName, string Name, string Alt, string Title)
    {
        return "<a alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"   " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + ID3 + "/" + RewriteURL.GetRewriteURL(UrlName) + "'>" + Name + "</a>";
    }
    public static string Url4(string Css, string Url, string ID1, string ID2, string ID3, string ID4, string UrlName, string Name, string Alt, string Title)
    {
        return "<a alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"  " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + ID3 + "/" + ID4 + "/" + RewriteURL.GetRewriteURL(UrlName) + "'>" + Name + "</a>";
    }

    //------------ Hình ảnh/

    public static string Url_Images1(string Css, string Url, string ID1, string UrlName, string Images)
    {
        return "<a " + Css + " href='/" + Url + "/" + ID1 + "/" + RewriteURL.GetRewriteURL(UrlName) + "'>" + Images + "</a>";
    }
    public static string Url_Images2(string Css, string Url, string ID1, string ID2, string UrlName, string Images)
    {
        return "<a " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + RewriteURL.GetRewriteURL(UrlName) + "'>" + Images + "</a>";
    }
    public static string Url_Images3(string Css, string Url, string ID1, string ID2, string ID3, string UrlName, string Images)
    {
        return "<a " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + ID3 + "/" + RewriteURL.GetRewriteURL(UrlName) + "'>" + Images + "</a>";
    }
    public static string Url_Images4(string Css, string Url, string ID1, string ID2, string ID3, string ID4, string UrlName, string Images)
    {
        return "<a " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + ID3 + "/" + ID4 + "/" + RewriteURL.GetRewriteURL(UrlName) + "'>" + Images + "</a>";
    }
}
#endregion
namespace MoreAll
{

    public class AddURL
    {
        public static string ToSlug(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            str = str.ToLowerInvariant();
            str = RemoveDiacritics(str);

            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", "-").Trim();
            str = Regex.Replace(str, @"-+", "-");

            return str;
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string SeoURL(string inputstring)
        {
            if (inputstring.Length > 0)
            {
                return (RewriteURL.GetNewTitle(inputstring));
            }
            return (RewriteURL.GetNewTitle(inputstring));
        }
        public static string Menu(string Name)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where Url_Name='" + Name + "'");
            if (dt.Count > 0)
            {
                str += dt[0].ID.ToString();
            }
            return str.ToString();
        }
        public static string Menu_Name(string Name)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where id='" + Name + "'");
            if (dt.Count > 0)
            {
                str += dt[0].Url_Name.ToString();
            }
            return str.ToString();
        }
        public static string Products(string Name)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [products]  where Name='" + Name + "'");
            if (dt.Count > 0)
            {
                str += dt[0].ipid.ToString();
            }
            return str.ToString();
        }
    }
    public class Hamdoisorachu
    {
        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }
        private static string Donvi(string so)
        {
            string Kdonvi = "";
            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }
        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";
            }
            return Ktach;
        }
        public static string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";
            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";
            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";
            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();
            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai
            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";
            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";
            return lso_chu.ToString().Trim();
        }
    }

    #region MoreAll
    public class MoreAll
    {
        public static string Enable_trangthai(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "Chưa xử lý";
            }
            return "Đã xử lý";
        }
        public static string RunScriptFile_New(string fileName, bool blnShowMsg = true)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                //chi chay file script co duoi .txt, cac file co duoi sql va gan ma version duoc chay trong phan Upgrade Version
                return "ERROR";
            }
            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand dbCmd = new SqlCommand();
                dbCmd.CommandType = CommandType.Text;
                dbCmd.Connection = dbConn;
                dbConn.Open();
                dbCmd.CommandText = fileName.ToString().Replace("\r\n\t", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                dbCmd.ExecuteNonQuery();
                dbConn.Close();
            }
            return "";
        }
        public static string RunScriptFile(string fileName, bool blnShowMsg = true)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                //chi chay file script co duoi .txt, cac file co duoi sql va gan ma version duoc chay trong phan Upgrade Version
                return "ERROR";
            }
            string stLog = "";
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(Path.Combine(HttpContext.Current.Server.MapPath("/Uploads/sql"), fileName));
            }
            catch
            {
                return "ERROR";
            }

            string line = null;
            StringBuilder sql = new StringBuilder();

            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                bool hasError = false;
                SqlCommand dbCmd = new SqlCommand();
                dbCmd.CommandType = CommandType.Text;
                dbCmd.Connection = dbConn;
                dbConn.Open();
                do
                {
                    if (sr == null)
                    {
                        break;
                    }
                    line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (line.Trim().ToUpper() == "GO" & sql.Length > 0)
                    {
                        dbCmd.CommandText = sql.ToString();
                        try
                        {
                            stLog = stLog + dbCmd.CommandText + Environment.NewLine;
                            dbCmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        sql.Length = 0;
                    }
                    else
                    {
                        sql.AppendLine(line.Trim());
                    }
                } while (!(line == null));
                //cho lenh cuoi cung
                if (sql.Length > 0)
                {
                    try
                    {
                        dbCmd.CommandText = sql.ToString();
                        stLog = stLog + dbCmd.CommandText + Environment.NewLine;
                        dbCmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
                dbConn.Close();
                if ((sr != null))
                {
                    sr.Close();
                }
            }
            return stLog;
        }

        #region Romove HTML Tag
        public static string RemoveHTMLTags(string content)
        {
            var cleaned = string.Empty;
            try
            {
                StringBuilder textOnly = new StringBuilder();
                using (var reader = XmlNodeReader.Create(new System.IO.StringReader("<xml>" + content + "</xml>")))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Text)
                            textOnly.Append(reader.ReadContentAsString());
                    }
                }
                cleaned = textOnly.ToString();
            }
            catch
            {
                string textOnly = string.Empty;
                Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                Regex compressSpaces = new Regex(@"[\s\r\n]+");
                textOnly = tagRemove.Replace(content, string.Empty);
                textOnly = compressSpaces.Replace(textOnly, " ");
                cleaned = textOnly;
            }

            return cleaned;
        }
        #endregion

        #region #
        public static string RequestUrl(string url)//Request.Url.ToString() ví dụ: MoreAll.RequestUrl(Request.Url.ToString());
        {
            string str = url;
            int index = str.IndexOf('?');
            if (index >= 0)
            {
                str = str.Substring(0, index);
            }
            return str;
        }
        public static string NamNam(object date)
        {
            return (Convert.ToDateTime(date).ToString("yyyy"));
        }
        public static string Date_ngay(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd"));
        }
        public static string Date_Thang(object date)
        {
            return Thang((Convert.ToDateTime(date).ToString("MM")));
        }
        private static string Thang(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "01":
                    result = "JAN";
                    break;
                case "02":
                    result = "Feb";
                    break;
                case "03":
                    result = "Mar";
                    break;
                case "04":
                    result = "Apr";
                    break;
                case "05":
                    result = "May";
                    break;
                case "06":
                    result = "Jun";
                    break;
                case "07":
                    result = "Jul";
                    break;
                case "08":
                    result = "Aug";
                    break;
                case "09":
                    result = "Sep";
                    break;
                case "10":
                    result = "Oct";
                    break;
                case "11":
                    result = "Now";
                    break;
                case "12":
                    result = "Dec";
                    break;
            }
            return result;
        }
        public static string FormatDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy hh:mm"));
        }
        public static string Date(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy"));
        }
        public static string IDDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("ddMMyyyy"));
        }
        public static string Date_Time(string DateHientai, string DateKetthuc)
        {
            TimeSpan ist = Convert.ToDateTime(DateKetthuc) - Convert.ToDateTime(DateHientai);
            int day = Convert.ToInt32(ist.Days) <= 0 ? 0 : Convert.ToInt32(ist.Days);
            int Hours = Convert.ToInt32(ist.Hours);
            int TotalMinutes = Convert.ToInt32(ist.Minutes);
            return day.ToString() + "Ngày : " + Hours.ToString() + " Giờ :" + TotalMinutes.ToString() + " Phút ";
        }
        public static string VipDateTime(string DateHientai, string DateKetthuc)
        {
            TimeSpan ist = Convert.ToDateTime(DateKetthuc) - Convert.ToDateTime(DateHientai);
            int day = Convert.ToInt32(ist.Days) <= 0 ? 0 : Convert.ToInt32(ist.Days);
            int Hours = Convert.ToInt32(ist.Hours);
            int TotalMinutes = Convert.ToInt32(ist.Minutes);
            return day.ToString() + " Ngày";
        }
        #endregion

        #region ImageAdmin
        public static string ChilGood(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<img src='/Uploads/pic/web/icon/action_delete.jpg' border='0'>";
            }
            return "<img src='/Uploads/pic/web/icon/ChilGood.png'  border='0'>";
        }
        public static string Enable(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<img src='/Resources/admin/images/key-locked.png'  border='0'>";
            }
            return "<img src='/Resources/admin/images/key.png' border='0'>";
        }
        public static string Enable_Date(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "";
            }
            return "<img src='/Uploads/pic/web/icon/badvote.gif'  border='0'>";
        }

        #endregion

        #region Style_Width Style_Height
        public static string Style_Width(string width)
        {
            if (width.Length > 0)
            {
                if (width.Equals("0"))
                {
                    return "width:auto";
                }
                else
                {
                    return "width:" + width + "px";
                }
            }
            return "";
        }
        public static string Style_Height(string height)
        {
            if (height.Length > 0)
            {
                if (height.Equals("0"))
                {
                    return "height:auto";
                }
                else
                {
                    return "height:" + height + "px";
                }
            }
            return "";
        }
        #endregion

        #region Substring
        public static string Substring_Length_setup(string number, string input, int length)
        {
            if (number.Length > 0)
            {
                if (number.Equals("0"))
                {
                    return input;
                }
                else
                {
                    if (input.Length <= length)
                    {
                        return input;
                    }
                    else
                    {
                        return input.Substring(0, length) + "...";
                    }
                }
            }
            return "";
        }
        public static string Substring(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
        #endregion

        #region language
        public static string Language
        {
            get
            {
                string language = "VIE";
                if (System.Web.HttpContext.Current.Session["language"] != null)
                {
                    language = System.Web.HttpContext.Current.Session["language"].ToString();
                }
                else
                {
                    System.Web.HttpContext.Current.Session["language"] = language;
                }
                return language;
            }
        }
        public static string LanguageAdmin
        {
            get
            {
                string language = Captionlanguage.Language;
                if (System.Web.HttpContext.Current.Session["lang"] != null)
                {
                    language = System.Web.HttpContext.Current.Session["lang"].ToString();
                }
                return language;
            }
        }
        #endregion

        #region Request  Cookies Session
        public static string GetCookies(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Cookies[name].Value;
        }
        public static void SetCookie(string name, string val)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Request.Cookies[name].Value = val;
                HttpContext.Current.Response.Cookies[name].Value = val;
            }
            else
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = val;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public static string GetParamValue(string var_name)
        {
            if (HttpContext.Current.Request.QueryString[var_name] != null)
            {
                return HttpContext.Current.Request.QueryString[var_name].Trim();
            }
            return "";
        }
        public static string CurrentModuleCode
        {
            get
            {
                return GetParamValue("u");
            }
        }
        public static void SetCookie(string name, string val, int minutes)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Request.Cookies[name].Value = val;
                HttpContext.Current.Request.Cookies[name].Expires = DateTime.Now.AddMinutes((double)minutes);
                HttpContext.Current.Response.Cookies[name].Value = val;
                HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddMinutes((double)minutes);
            }
            else
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = val;
                cookie.Expires = DateTime.Now.AddMinutes((double)minutes);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public static void SetSession(string name, string val)
        {
            HttpContext.Current.Session[name] = val;
        }
        public static void DestroySession(string name)
        {
            if (HttpContext.Current.Session[name] != null)
            {
                HttpContext.Current.Session[name] = null;
            }
        }
        public static void DelCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Request.Cookies[name].Expires = DateTime.Now.AddDays(-1.0);
                HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1.0);
            }
        }
        public static string GetCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Cookies[name].Value;
        }
        public static string GetSession(string name)
        {
            if (HttpContext.Current.Session[name] != null)
            {
                return HttpContext.Current.Session[name].ToString();
            }
            return "";
        }
        #endregion
    }
    #endregion

    #region Banner
    public class Banner
    {
        #region Width Height
        public static string Width()
        {
            string Width = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "bannerwidth")
                    {
                        Width = its.Value;
                    }
                }
            }
            return Width.ToString();
        }
        public static string Height()
        {
            string Height = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "bannerheight")
                    {
                        Height = its.Value;
                    }
                }
            }
            return Height.ToString();
        }
        public static string path()
        {
            string item = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "bannerpath")
                    {
                        item = its.Value;
                    }
                }
            }
            return item.ToString();
        }
        #endregion
        public static string Banners()
        {
            string item = "";
            string str = Width();
            string str2 = Height();
            string str3 = path();
            if (str3.Equals(""))
            {
                item = "<a title=\"" + Other.TitleWebname() + "\"  href='/' class=\"header-logo\"><img src='/Uploads/pic/web/logo/logo.png' border=0 width=" + str + "px  height=" + str2 + "px title=\"" + Other.TitleWebname() + "\" alt=\"" + Other.TitleWebname() + "\" /></a>";
            }
            else if (str3.Length > 4)
            {
                string str4 = str3.Substring(str3.IndexOf(".")).ToLower();
                if ((str4.Equals(".jpg") || str4.Equals(".gif")) || str4.Equals(".png"))
                {
                    item = "<a title=\"" + Other.TitleWebname() + "\" href='/'  class=\"header-logo\"><img src='/Uploads/pic/web/logo/" + str3 + "' border=0 style='" + MoreAll.Style_Width((str)) + ";" + MoreAll.Style_Height((str2)) + "'   title=\"" + Other.TitleWebname() + "\" alt=\"" + Other.TitleWebname() + "\"/></a>";
                }
                else if (str4.Equals(".swf"))
                {
                    item = "<embed style='" + MoreAll.Style_Width(str) + ";" + MoreAll.Style_Height((str2)) + "' align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='/Uploads/pic/web/logo/" + str3 + "'>";
                }
            }
            return item.ToString();
        }
    }
    #endregion

    #region MoreNews
    public class MoreNews
    {
        public static string page2()
        {
            string Pages = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "pagenews2")
                    {
                        Pages = its.Value;
                    }
                }
            }
            return Pages.ToString();
        }public static string page()
        {
            string Pages = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "pagenews")
                    {
                        Pages = its.Value;
                    }
                }
            }
            return Pages.ToString();
        }

        #region Width Height
        public static string Width()
        {
            string Width = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "newswidth")
                    {
                        Width = its.Value;
                    }
                }
            }
            return Width;
        }

        public static string Height()
        {
            string Height = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "newsheight")
                    {
                        Height = its.Value;
                    }
                }
            }
            return Height;
        }
        #endregion

        #region Substring
        public static string Substring_Title(string input)
        {
            string number = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "News_titile_Substring")
                    {
                        number = its.Value;
                    }
                }
            }
            return MoreAll.Substring_Length_setup(number, input, Convert.ToInt32(number));
        }

        public static string Substring_Mota(string input)
        {
            string number = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "News_Mota_Substring")
                    {
                        number = its.Value;
                    }
                }
            }
            return MoreAll.Substring_Length_setup(number, input, Convert.ToInt32(number));
        }
        #endregion

        #region image
        public static string ImageDisplay(string image)
        {
            if (image.Length > 0)
            {
                return "<img  src='" + image + "' style='" + MoreAll.Style_Width(Width()) + ";" + MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Display_IMG(MoreNews.Width(), MoreNews.Height());
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img class='img-responsive' alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"  src='" + image + "' style='" + MoreAll.Style_Width(Width()) + ";" + MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Display_IMG(MoreNews.Width(), MoreNews.Height());
        }
        #endregion

        #region other
        public static string Newsother()
        {
            string Newsother = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "newsother")
                    {
                        Newsother = its.Value;
                    }
                }
            }
            return Newsother.ToString();
        }

        public static string Newschiase()
        {
            string Newschiase = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "newschiase")
                    {
                        Newschiase = its.Value;
                    }
                }
            }
            return Newschiase.ToString();
        }
        #endregion

        #region AllRelated
        public static string AllRelated(string Url, string nid)
        {
            string str = "";
            List<News> table = SNews.DETAIL_NEWS_RELATED(Sub_MenuRelated(nid));
            for (int i = 0; i < table.Count; i++)
            {
                string str2 = str;
                str = str2 + " > <a href='/" + Url + "/" + table[i].icid.ToString() + "/" + table[i].inid.ToString() + "/" + RewriteURL.GetRewriteURL(table[i].Title.ToString()) + "'>" + table[i].Title.ToString() + "</a></br>";
            }
            return str;
        }
        public static string Sub_MenuRelated(string nid)
        {
            string submn = "0";
            List<Entity.News_Related> dt = SNews_Related.DETAIL_INID(nid);
            for (int i = 0; i < dt.Count; i++)
            {
                submn = submn + "," + dt[i].irelated.ToString();
            }
            return submn;
        }
        #endregion

        #region AllComments
        public static string AllComments(string nid, string status)
        {
            List<Comments> table = SComments.NEWS_TOTALS(nid, status);
            if (table.Count > 0)
            {
                return table.Count.ToString();
            }
            else return "0";
        }
        #endregion

        #region StatusComment
        public static string StatusComment()
        {
            string StatusComment = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "StatusComment")
                    {
                        StatusComment = its.Value;
                    }
                }
            }
            return StatusComment.ToString();
        }
        #endregion

        #region Comment
        public static string Comment()
        {
            string Comment = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Comment")
                    {
                        Comment = its.Value;
                    }
                }
            }
            return Comment.ToString();
        }
        #endregion
    }

    #endregion

    #region MorePro
    public class MorePro
    {
        public static string FormatMoneyCart(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                if (str.Length > 0)
                {
                    return str.Replace(",", ",") + " đ";
                }
                else { return "0 đ"; }
            }
            else
            {
                return "";
            }
        }
        public static string giamgia(string ID)
        {
            string Width = "";
            List<Products> str = SProducts.GetById(ID);
            if (str.Count >= 1)
            {
                if (str[0].Price.ToString() == "" || str[0].OldPrice.ToString() == "")
                {
                }
                else if (Convert.ToDouble(str[0].OldPrice.ToString()) > Convert.ToDouble(str[0].Price.ToString()))
                {
                    double cu = Convert.ToDouble(str[0].OldPrice.ToString());
                    double hientai = Convert.ToDouble(str[0].Price.ToString());
                    double Tong = (((cu - hientai) / cu) * 100);
                    Tong = System.Math.Round(Tong, 0);
                    Width += "<span class='save_price'>-" + Tong.ToString() + "%</span>";
                }
            }
            return Width.ToString();
        }
        #region proother
        public static string proother()
        {
            string item = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "proother")
                    {
                        item = its.Value;
                    }
                }
            }
            return item.ToString();
        }
        #endregion
        #region HomePage
        public static string HomePage()
        {
            string Page = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "HomePage")
                    {
                        Page = its.Value;
                    }
                }
            }
            return Page.ToString();
        }
        #endregion
        #region Page
        public static string Pages()
        {
            string Page = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "pagepro")
                    {
                        Page = its.Value;
                    }
                }
            }
            return Page.ToString();
        }
        #endregion
        #region emailpro
        public static string emailpro()
        {
            string email = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "emailpro")
                    {
                        email = its.Value;
                    }
                }
            }
            return email.ToString();
        }
        #endregion
        #region SenEmailPro
        public static string SenEmailPro()
        {
            string SenEmai = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "SenEmailPro")
                    {
                        SenEmai = its.Value;
                    }
                }
            }
            return SenEmai.ToString();
        }
        #endregion
        #region Width Height
        public static string Width()
        {
            string Width = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "prowidth")
                    {
                        Width = its.Value;
                    }
                }
            }
            return Width.ToString();
        }
        public static string Height()
        {
            string Height = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "proheight")
                    {
                        Height = its.Value;
                    }
                }
            }
            return Height.ToString();
        }
        #endregion
        #region Width Height Thumbnail
        public static string WidthThumbnail()
        {
            string Width = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "prowidthThumbnail")
                    {
                        Width = its.Value;
                    }
                }
            }
            return Width.ToString();
        }
        public static string HeightThumbnail()
        {
            string Height = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "proheightThumbnail")
                    {
                        Height = its.Value;
                    }
                }
            }
            return Height.ToString();
        }
        #endregion
        #region Dongiapro
        public static string Dongiapro()
        {
            string Dongia = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Dongiapro")
                    {
                        Dongia = its.Value;
                    }
                }
            }
            return Dongia.ToString();
        }
        #endregion
        #region TieudeGia
        public static string TieudeGia()
        {
            string TieudeGia = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "TieudeGia")
                    {
                        TieudeGia = its.Value;
                    }
                }
            }
            return TieudeGia.ToString();
        }
        #endregion
        #region color
        public static string color()
        {
            string color = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "color")
                    {
                        color = its.Value;
                    }
                }
            }
            return color.ToString();
        }

        #endregion
        #region Pro_titile_Substring
        public static string Pro_titile_Substring()
        {
            string Pro_titile_Substring = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Pro_titile_Substring")
                    {
                        Pro_titile_Substring = its.Value;
                    }
                }
            }
            return Pro_titile_Substring.ToString();
        }

        #endregion
        #region AllProduct_Products
        public static string AllProduct_Products()
        {
            List<Products> table = SProducts.GetByAll(MoreAll.Language);
            if (table.Count > 0)
            {
                return table.Count.ToString();
            }
            else return "0";
        }
        #endregion
        #region Substring_Title
        public static string Substring_Title(string input)
        {
            string number = Pro_titile_Substring().ToString();
            return MoreAll.Substring_Length_setup(number, input, Convert.ToInt32(number));
        }

        #endregion
        #region FormatMoney
        public static string FormatMoney(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return TieudeGia().ToString() + str.Replace(",", ",") + MorePro.Dongiapro();
            }
            else
            {
                return Lienhevnd().ToString();
            }
        }
        #endregion
        #region Lienhevnd
        public static string Lienhevnd()
        {
            string Lienhevnd = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Lienhevnd")
                    {
                        Lienhevnd = "<a style='text-align:none;color:" + color() + "' href='/lien-he.html'><b  style='text-align:none;color:" + color() + "' >" + its.Value + " </b></a>";
                    }
                }
            }
            return Lienhevnd.ToString();
        }
        #endregion
        #region FormatMoney_Detail
        public static string FormatMoney_Detail(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return TieudeGia() + "<span style='color:#" + color() + "'>" + str.Replace(",", ",") + " </span>" + MorePro.Dongiapro();
            }
            else
            {
                return "";
            }
        }
        public static string Detail_Price(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",");
            }
            else
            {
                return "";
            }
        }

        #endregion
        #region FormatMoney_Cart
        public static string FormatMoney_Cart(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",");
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region FormatMoney_Cart_Total
        public static string FormatMoney_Cart_Total(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                if (str.Length > 0)
                {
                    return str.Replace(",", ",") + " " + Dongiapro();
                }
                else { return "0 đ"; }

            }
            else
            {
                return "";
            }
        }
        #endregion
        //News
        #region FormatMoney_NO
        public static string FormatMoney_NO(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",");
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region FormatMoney_VND
        public static string FormatMoney_VND(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",") + " " + Dongiapro();
            }
            else
            {
                return "";
            }
        }
        #endregion
        public static string FormatMoney_Full(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return TieudeGia() + "<span style='color:#" + color() + "'>" + str.Replace(",", ",") + " </span>" + MorePro.Dongiapro();
            }
            else
            {
                return "";
            }
        }
        public static string FormatMoney_Full_lh(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return TieudeGia().ToString() + str.Replace(",", ",") + MorePro.Dongiapro();
            }
            else
            {
                return Lienhevnd().ToString();
            }
        }
        public static string Fo_rmat_Price(string strTemp)
        {
            string strTextPrice = "";
            strTemp = strTemp.Replace("/,/g", "");
            if (strTemp == "" || strTemp == "0")
            { }
            else
            {
                try
                {

                    Double priceTy = (Convert.ToDouble(strTemp) / Convert.ToDouble("1000000000"));
                    priceTy = Math.Truncate(priceTy);
                    Double priceTrieu = ((Convert.ToDouble(strTemp) % Convert.ToDouble("1000000000")) / Convert.ToDouble("1000000"));
                    priceTrieu = Math.Truncate(priceTrieu);
                    Double priceNgan = (((Convert.ToDouble(strTemp) % Convert.ToDouble("1000000000"))) % Convert.ToDouble("1000000") / Convert.ToDouble("1000"));
                    priceNgan = Math.Round(priceNgan, 0);
                    Double priceDong = (((Convert.ToDouble(strTemp) % Convert.ToDouble("1000000000"))) % Convert.ToDouble("1000000") % Convert.ToDouble("1000"));
                    priceDong = Math.Round(priceDong, 0);
                    string getTrieu = "";
                    string getNgan = "";
                    string getDong = "";
                    if (priceTy > 0 && Convert.ToDouble(strTemp) > Convert.ToDouble("900000000"))
                    {
                        if (priceTrieu > 0)
                        {
                            getTrieu = "," + priceTrieu / Convert.ToDouble("100");
                        }
                        else
                        {
                            getTrieu = "";
                        }
                        strTextPrice = strTextPrice + priceTy + getTrieu + " Tỷ VNĐ";
                    }
                    if (priceTy == 0 && priceTrieu > 0)
                    {
                        if (priceNgan > 0)
                        {
                            getNgan = "," + priceNgan / Convert.ToDouble("100");
                        }
                        else
                        {
                            getNgan = "";
                        }
                        strTextPrice = strTextPrice + priceTrieu + getNgan + " Triệu VNĐ";
                    }
                    if (priceTrieu == 0 && priceNgan > 0)
                    {
                        if (priceDong > 0)
                        {
                            getDong = "," + priceDong / Convert.ToDouble("100");
                        }
                        else
                        {
                            getDong = "";
                        }
                        strTextPrice = strTextPrice + priceNgan + getDong + " Ngàn VNĐ";
                    }
                    if (priceNgan == 0 && priceDong > 0)
                    {
                        strTextPrice = strTextPrice + priceDong + " Đồng VNĐ";
                    }
                }
                catch (Exception)
                {
                }
            }
            //strTextPrice = strTextPrice.Replace("/\./g", "");
            return strTextPrice;

        }
        //End
        #region ToolTip
        public static string ToolTip(string lang)
        {
            #region Seting ToolTip
            string ToolTip = "";
            List<Setting> str2 = SSetting.GETBYALL(MoreAll.Language);
            if (str2.Count >= 1)
            {
                foreach (Setting its in str2)
                {
                    if (its.Properties == "ToolTip")
                    {
                        ToolTip = its.Value;
                    }
                }
            }
            #endregion
            List<Products> dt = SProducts.List_ToolTip(lang);
            string str = "<script type=\"text/javascript\" src=\"/cms/Display/Products/Resources/js/stickytooltip.js\"></script>";
            str += "<link rel=\"stylesheet\" type=\"text/css\" href=\"/cms/Display/Products/Resources/css/stickytooltip.css\" />";
            str += "<div id=\"mystickytooltip\" class=\"stickytooltip\">";
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    if (ToolTip.Equals("1"))
                    {
                        str += "<div id=\"sticky" + dt[i].ipid.ToString() + "\" class=\"atip\">";
                        str += "<div class=\"protip-img\">";
                        str += MoreImage.Image_width_height(dt[i].Images.ToString(), "350", "0");
                        str += "</div>";
                        str += "</div>";
                    }
                    else if (ToolTip.Equals("2"))
                    {
                        str += "<div id=\"sticky" + dt[i].ipid.ToString() + "\" class=\"atip\">";
                        str += "<div class=\"Tooltip\">";
                        str += "<div class=\"protip-title\">" + dt[i].Name.ToString() + "</div>";
                        str += "<div class=\"protip-content\">";
                        str += "<p class=\"protip-summary\">";
                        str += "<b  class=\"icon\">Tính năng cơ bản:</b><br></p><div style=\" padding-left:5px; padding-right:5px; line-height:20px;\">" + dt[i].Brief.ToString() + "</div>";
                        str += "</div>";
                        str += "</div>";
                        str += "</div>";
                    }
                }
            }
            str += "<div class=\"stickystatus\"></div>";
            str += "</div>";
            return str.ToString();
        }
        #endregion

        #region image
        public static string Banner_sanpham(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='width: 100%;height: auto;margin-top: -4px;'  border=0>";
            }
            return "";
        }
        public static string ImageDisplay(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.Style_Width(Width()) + ";" + MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Display_IMG(Width(), Height());
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img   alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.Style_Width(Width()) + ";" + MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Display_IMG(MorePro.Width(), MorePro.Height());
        }
        #endregion
        public static string Image_width_height_Title_Alt_css(string css, string image, string width, string height, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img class=\"" + css + "\"  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.Style_Width(Width()) + ";" + MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Display_IMG(Width(), Height());
        }
        public static string CC_Image_Title_Alt(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img  class=\"" + css + "\"  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.Style_Width(Width()) + ";" + MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Display_IMG(MoreNews.Width(), MoreNews.Height());
        }
        public static string Image_width_height_gallery(string image, string title)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "'  style='" + MoreAll.Style_Width(WidthThumbnail()) + ";" + MoreAll.Style_Height(HeightThumbnail()) + "' border=0>";
            }
            return MoreNoimg.Display_IMG(Width(), Height());
        }

        public static string ImageDetail(string image)
        {
            if (image.Length > 0)
            {
                return "<a id=\"gdBigImg\" rel=\"imgEx\" href=\"" + image + "\"><img alt=\"imgEx\" src='" + image + "'  style='" + MoreAll.Style_Width(WidthThumbnail()) + ";" + MoreAll.Style_Height(HeightThumbnail()) + "' border=0></a>";
            }
            return MoreNoimg.Display_IMG(Width(), Height());
        }
        public static string Giamgia(string ID)
        {
            string Width = "";
            List<Entity.Products> str = SProducts.GetById(ID);
            if (str.Count >= 1)
            {
                if (str[0].Price.ToString() == "" || str[0].OldPrice.ToString() == "")
                {
                }
                else if (Convert.ToDouble(str[0].OldPrice.ToString()) > Convert.ToDouble(str[0].Price.ToString()))
                {
                    double cu = Convert.ToDouble(str[0].OldPrice.ToString());
                    double hientai = Convert.ToDouble(str[0].Price.ToString());
                    double Tong = (((cu - hientai) / cu) * 100);
                    Tong = System.Math.Round(Tong, 0);
                    Width += "<span class=\"label-sale\">-" + Tong.ToString() + "%</span>";
                }
            }
            return Width.ToString();
        }
        public static string Tietkiem(string ID)
        {
            string Width = "";
            List<Entity.Products> str = SProducts.GetById(ID);
            if (str.Count >= 1)
            {
                if (str[0].Price.ToString() == "" || str[0].OldPrice.ToString() == "")
                {

                }
                else if (Convert.ToDouble(str[0].OldPrice.ToString()) > Convert.ToDouble(str[0].Price.ToString()))
                {
                    double cu = Convert.ToDouble(str[0].OldPrice.ToString());
                    double hientai = Convert.ToDouble(str[0].Price.ToString());
                    double Tong = (((cu - hientai)));
                    Tong = System.Math.Round(Tong, 0);
                    Width += "<span class=\"Tietkiem\">-" + MorePro.Detail_Price(Tong.ToString()) + " đ</span>";
                }
            }
            return Width.ToString();
        }
        public static string Tietkiems(string ID)
        {
            string Width = "";
            List<Entity.Products> str = SProducts.GetById(ID);
            if (str.Count >= 1)
            {
                if (str[0].Price.ToString() == "" || str[0].OldPrice.ToString() == "")
                {

                }
                else if (Convert.ToDouble(str[0].OldPrice.ToString()) > Convert.ToDouble(str[0].Price.ToString()))
                {
                    double cu = Convert.ToDouble(str[0].OldPrice.ToString());
                    double hientai = Convert.ToDouble(str[0].Price.ToString());
                    double Tong = (((cu - hientai)));
                    Tong = System.Math.Round(Tong, 0);
                    Width += "<span class=\"Tietkiem\">Tiết kiệm: " + MorePro.Detail_Price(Tong.ToString()) + " đ</span>";
                }
            }
            return Width.ToString();
        }
        public static string NameProducts(string ID)
        {
            string Width = "";
            List<Entity.Products> dts = SProducts.GetById(ID);
            if (dts.Count > 0)
            {
                Width += dts[0].Name;
            }
            return Width.ToString();
        }
        public string NameMenu(string ID)
        {
            string Width = "";
            List<Entity.Menu> dts = SMenu.Detail(ID);
            if (dts.Count > 0)
            {
                Width += dts[0].Name;
            }
            return Width.ToString();
        }
        public static string LoadLink(string ID)
        {
            string Width = "";
            List<Entity.Products> dts = SProducts.GetById(ID);
            if (dts.Count > 0)
            {
                Width += dts[0].TangName.ToString() + ".html";
            }
            return Width.ToString();
        }
    }
    #endregion

    #region MoreNoimg
    public class MoreNoimg
    {
        public static string IMG_Birthday()
        {
            string path = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Noimgpath")
                    {
                        path = its.Value;
                    }
                }
            }
            return "/Uploads/pic/Noimg/" + path.ToString();
        }
        public static string Display_IMG(string Width, string Height)
        {
            string path = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Noimgpath")
                    {
                        path = its.Value;
                    }
                }
            }
            return "<img src='/Uploads/pic/Noimg/" + path.ToString() + "' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width(Width) + ";" + MoreAll.Style_Height(Height) + "'>";
        }
        public static string Imgpath()
        {
            string path = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "imgpath")
                    {
                        path = its.Value;
                    }
                }
            }
            return "/Uploads/pic/Noimg/" + path.ToString();
        }
        public static string Noimgpath()
        {
            string path = "";
            string Width = "";
            string Height = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Noimgwidth")
                    {
                        Width = its.Value;
                    }
                    else if (its.Properties == "Noimgheight")
                    {
                        Height = its.Value;
                    }
                    else if (its.Properties == "Noimgpath")
                    {
                        path = its.Value;
                    }
                }
            }
            return "<img src='/Uploads/pic/Noimg/" + path.ToString() + "' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width(Width) + ";" + MoreAll.Style_Height(Height) + "'>";
        }
        public static string Noimgpath_w_h(string Height, string Width)
        {
            string path = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Noimgpath")
                    {
                        path = its.Value;
                    }
                }
            }
            return "<img src='/Uploads/pic/Noimg/" + path.ToString() + "' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width(Width) + ";" + MoreAll.Style_Height(Height) + "'>";
        }
        public static string NoimgpathAdmin()
        {
            string path = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Noimgpath")
                    {
                        path = its.Value;
                    }
                }
            }
            return "<img src='/Uploads/pic/Noimg/" + path.ToString() + "' style='border:1px solid #9EC3CB;width:100px;height:65px'>";
        }
    }
    #endregion

    #region MoreImage
    public class MoreImage
    {
        public static string IMG_Birthday(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' />";
            }
            return "<img src='" + MoreNoimg.IMG_Birthday() + "' />";
        }
        public static string IMG_Birthday_Hover(string image)
        {
            if (image.Length > 0)
            {
                return image;
            }
            return MoreNoimg.IMG_Birthday();
        }
        public static string Image(string image)
        {
            if (image.Length > 0)
            {
                return ("<img src='" + image + "' style='border:1px solid #9EC3CB;' width=100px  height=65px>");
            }
            return MoreNoimg.NoimgpathAdmin();
        }
        public static string DisplayImage(string image)
        {
            if (image.Length > 0)
            {
                return ("<img src='" + image + "' style='border:1px solid #9EC3CB;' width=100px  height=65px>");
            }
            return MoreNoimg.NoimgpathAdmin();
        }
        public static string Image_width_height_gallery(string image, string width, string height, string title)
        {
            if (image.Length > 0)
            {
                return "<a href=\"" + image + "\" rel=\"gallery\"   title=\"" + title + "\"  class=\"pirobox_gall\"><img src='" + image + "'  style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "' border=0></a>";
            }
            return MoreNoimg.Noimgpath();
        }
        public static string Image_width_height(string image, string width, string height)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "' border=0>";
            }
            return MoreNoimg.Noimgpath_w_h(height, width);
        }
        //Seo
        public static string Image_width_height_Title_Alt(string image, string width, string height, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img   src='" + image + "' style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "'  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    border=0>";
            }
            return MoreNoimg.Noimgpath_w_h(height, width);
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img   src='" + image + "' alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    border=0>";
            }
            return MoreNoimg.Noimgpath_w_h("0", "0");
        }
        public static string Image_width_height_Title_Alt_css(string css, string image, string width, string height, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img class=\"" + css + "\"  src='" + image + "' style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "'  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    border=0>";
            }
            return MoreNoimg.Noimgpath_w_h(height, width);
        }

    }
    #endregion

    #region MoreDownload
    public class MoreDownload
    {
        #region Width Height
        public static string Width()
        {
            string Width = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Downloadwidth")
                    {
                        Width = its.Value;
                    }
                }
            }
            return Width.ToString();
        }
        public static string Height()
        {
            string Height = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Downloadheight")
                    {
                        Height = its.Value;
                    }
                }
            }
            return Height.ToString();
        }
        #endregion
        #region ImagesDisplay
        public static string ImagesDisplay(string Images)
        {
            if (Images.Length > 4)
            {
                string str = Images.Substring(Images.IndexOf(".")).ToLower();
                if (str.Equals(".doc"))
                {
                    return "<img src='/Uploads/pic/Download/Icon/Word.png' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width((Width())) + ";" + MoreAll.Style_Height((Height())) + "' />";
                }
                else if (str.Equals(".rar"))
                {
                    return "<img src='/Uploads/pic/Download/Icon/rar.png' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width((Width())) + ";" + MoreAll.Style_Height((Height())) + "' />";
                }
                else if (str.Equals(".xls"))
                {
                    return "<img src='/Uploads/pic/Download/Icon/Exel.png' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width((Width())) + ";" + MoreAll.Style_Height((Height())) + "' />";
                }
                else if (str.Equals(".pdf"))
                {
                    return "<img src='/Uploads/pic/Download/Icon/pdf.png' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width((Width())) + ";" + MoreAll.Style_Height((Height())) + "' />";
                }
                else if (str.Equals(".ppt"))
                {
                    return "<img src='Uploads/pic/Download/Icon/power.png' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width((Width())) + ";" + MoreAll.Style_Height((Height())) + "' />";
                }
            }
            return "<img src='/Uploads/pic/Noimg/titleNoimg4.gif'  style='border:1px solid #9EC3CB;" + MoreAll.Style_Width((Width())) + ";" + MoreAll.Style_Height((Height())) + "' />";
        }
        #endregion
        #region ImagesDownload
        public static string ImagesDownload(string Images)
        {
            if (Images.Length > 4)
            {
                string str = Images.Substring(Images.IndexOf(".")).ToLower();
                if (str.Equals(".doc"))
                {
                    return "<img src='/Uploads/pic/Download/Icon/Word.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
                else if (str.Equals(".rar"))
                {
                    return "<img src='/Uploads/pic/Download/Icon/rar.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
                else if (str.Equals(".xls"))
                {
                    return "<img src='/Uploads/pic/Download/Icon/Exel.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
                else if (str.Equals(".pdf"))
                {
                    return "<img src='/Uploads/pic/Download/Icon/pdf.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
                else if (str.Equals(".ppt"))
                {
                    return "<img src='Uploads/pic/Download/Icon/power.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
            }
            return "<img src='/Uploads/pic/Noimg/titleNoimg4.gif'  style='border:1px solid #9EC3CB;' width=100px  height=65px />";
        }
        #endregion
        #region Pagedownload
        public static string Pagedownload()
        {
            string Pagedownload = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "pageDownload")
                    {
                        Pagedownload = its.Value;
                    }
                }
            }
            return Pagedownload.ToString();
        }
        #endregion
    }
    #endregion

    #region Email
    public class Email
    {
        public static string email()
        {
            string Chuoi = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "sysemail")
                    {
                        Chuoi = its.Value;
                    }
                }
            }
            return Chuoi.ToString();
        }
        public static string password()
        {
            string Chuoi = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "sysemailpass")
                    {
                        Chuoi = its.Value;
                    }
                }
            }
            return Chuoi.ToString();
        }
        public static string port()
        {
            string Chuoi = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "smtpport")
                    {
                        Chuoi = its.Value;
                    }
                }
            }
            return Chuoi.ToString();
        }
        public static string host()
        {
            string Chuoi = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "smtp")
                    {
                        Chuoi = its.Value;
                    }
                }
            }
            return Chuoi.ToString();
        }
    }
    #endregion

    #region MoreAllBum
    public class MoreAllBum
    {
        #region Width Height
        public static string Width()
        {
            string Width = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Photowidth")
                    {
                        Width = its.Value;
                    }
                }
            }
            return Width.ToString();
        }
        public static string Height()
        {
            string Height = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Photoheight")
                    {
                        Height = its.Value;
                    }
                }
            }
            return Height.ToString();
        }
        #endregion
        #region ImageDisplay
        public static string ImageDisplay(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.Style_Width((Width())) + ";" + MoreAll.Style_Height((Height())) + "' border=0  align=left>";
            }
            return MoreNoimg.Noimgpath();
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.Style_Width(Width()) + ";" + MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Display_IMG(MoreNews.Width(), MoreNews.Height());
        }
        #endregion
        #region Image_AllBum
        public static string Image_AllBum(string Thumbnail, string image, string id, string title, string alt)
        {
            if (image.Length > 0)
            {
                return "<a href='" + image + "'><img title='" + title + "' alt='" + alt + "' src='" + Thumbnail + "' class='image" + id + "'></a>";
            }
            return MoreNoimg.Display_IMG(MoreAllBum.Width(), MoreAllBum.Height());
        }
        public static string Image_DTAllBum(string image, string title, string alt)
        {
            if (image.Length > 0)
            {
                return "<img title='" + title + "' alt='" + alt + "' src='" + image + "' />";
            }
            return MoreNoimg.Display_IMG(MoreAllBum.Width(), MoreAllBum.Height());
        }
        #endregion

        #region Pageallbum
        public static string Pageallbum()
        {
            string Pageallbum = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "pagePhoto")
                    {
                        Pageallbum = its.Value;
                    }
                }
            }
            return Pageallbum.ToString();
        }
        #endregion
        #region Allbumother
        public static string Allbumother()
        {
            string Allbumother = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "allbumother")
                    {
                        Allbumother = its.Value;
                    }
                }
            }
            return Allbumother.ToString();
        }
        #endregion
        #region Allbumchiase
        public static string Allbumchiase()
        {
            string Allbumchiase = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "allbumchiase")
                    {
                        Allbumchiase = its.Value;
                    }
                }
            }
            return Allbumchiase.ToString();
        }
        #endregion
    }
    #endregion

    #region MoreVideoClip
    public class MoreVideoClip
    {
        #region Width Height
        public static string Width()
        {
            string Widths = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "videowidth")
                    {
                        Widths = its.Value;
                    }
                }
            }
            return Widths.ToString();
        }
        public static string Height()
        {
            string Heights = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "videoheight")
                    {
                        Heights = its.Value;
                    }
                }
            }
            return Heights.ToString();
        }
        #endregion
        #region Width Height
        public static string Width_Img()
        {
            string Widths = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "videoimgwidth")
                    {
                        Widths = its.Value;
                    }
                }
            }
            return Widths.ToString();
        }
        public static string Height_Img()
        {
            string Heights = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "videoimgheight")
                    {
                        Heights = its.Value;
                    }
                }
            }
            return Heights.ToString();
        }
        #endregion
        #region ImageDisplay
        public static string ImageDisplay(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.Style_Width((Width_Img())) + ";" + MoreAll.Style_Height((Height_Img())) + "' border=0  align=left>";
            }
            return MoreNoimg.Display_IMG(MoreVideoClip.Width_Img(), MoreVideoClip.Height_Img());
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.Style_Width(Width()) + ";" + MoreAll.Style_Height((Height())) + "'  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"     border=0>";
            }
            return MoreNoimg.Display_IMG(MoreNews.Width(), MoreNews.Height());
        }
        #endregion
        #region Pagevideo
        public static string Pagevideo()
        {
            string page = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "pagevideo")
                    {
                        page = its.Value;
                    }
                }
            }
            return page.ToString();
        }
        #endregion
        #region Videoother
        public static string Videoother()
        {
            string Video = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "videoother")
                    {
                        Video = its.Value;
                    }
                }
            }
            return Video.ToString();
        }
        #endregion
        #region Videochiase
        public static string Videochiase()
        {
            string chiase = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "videochiase")
                    {
                        chiase = its.Value;
                    }
                }
            }
            return chiase.ToString();
        }
        #endregion
        public static string GetYouTubeID(string youTubeUrl)
        {
            //RegEx to Find YouTube ID
            Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*", RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return "http://www.youtube.com/v/" + regexMatch.Groups[1].Value + "&hl=en&fs=1";
            }
            return youTubeUrl;
        }
    }
    #endregion

    #region Others
    public class Other
    {
        public static string RequestMenu(string Request)
        {
            string Modul = "21";
            List<Entity.Menu> str = SMenu.Name_Text("SELECT top 1 * FROM [Menu]  where TangName=N'" + Request + "'");
            if (str != null && str.Count > 0)
            {
                Modul = str[0].Module.ToString();
            }
            return Modul;
        }
        public static string Giatri(string giatri)
        {
            string item = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == giatri)
                    {
                        item = its.Value;
                    }
                }
            }
            return item.ToString();
        }
        public static string website()
        {
            string Facebooks = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "website")
                    {
                        Facebooks = its.Value;
                    }
                }
            }
            return Facebooks.ToString();
        }
        public static string NFacebook()
        {
            string Facebooks = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "NFacebook")
                    {
                        Facebooks = its.Value;
                    }
                }
            }
            return Facebooks.ToString();
        }
        public static string Facebook()
        {
            string Facebooks = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Facebook")
                    {
                        Facebooks = its.Value;
                    }
                }
            }
            return Facebooks.ToString();
        }
        public static string Icon()
        {
            string Icon = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Icon")
                    {
                        Icon = its.Value;
                    }
                }
            }
            return Icon.ToString();
        }
        public static string GoogleAnalytics()
        {
            string Analytics = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "GoogleAnalytics")
                    {
                        Analytics = its.Value;
                    }
                }
            }
            return Analytics.ToString();
        }
        public static string TitleWebname()
        {
            string Titlename = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "webname")
                    {
                        Titlename = its.Value;
                    }
                }
            }
            return Titlename.ToString();
        }
        public static string Titlesearchkeyword()
        {
            string ist = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "searchkeyword")
                    {
                        ist = its.Value;
                    }
                }
            }
            return ist.ToString();
        }
        public static string Titlekeyworddescription()
        {
            string ist = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "keyworddescription")
                    {
                        ist = its.Value;
                    }
                }
            }
            return ist.ToString();
        }
        public static string Popup_TrangThai()
        {
            string Popup = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Popup_TrangThai")
                    {
                        Popup = its.Value;
                    }
                }
            }
            return Popup.ToString();
        }

        public static string GioHang()
        {
            string item = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "GioHang")
                    {
                        item = its.Value;
                    }
                }
            }
            return item.ToString();
        }
        public static string Hotline()
        {
            string item = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Hotline")
                    {
                        item = its.Value;
                    }
                }
            }
            return item.ToString();
        }
        public static string Facebook_comments(string Url, string Width)
        {
            string Facebooks = "";
            {
                Facebooks += " <div class='fb-comments' data-href='" + Url + "' data-width=" + Width + "  data-num-posts='2'></div>";
                Facebooks += " <div class='addthis_toolbox addthis_default_style '><a class='addthis_button_preferred_1'></a><a class='addthis_button_preferred_2'></a><a class='addthis_button_preferred_3'></a><a class='addthis_button_preferred_4'></a><a class='addthis_button_compact'></a><a class='addthis_counter addthis_bubble_style'></a></div><script type='text/javascript' src='http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4e2a6c617ab55718'></script>";
            }
            return Facebooks.ToString();
        }
    }



    #endregion

    #region Contact
    public class Contacts
    {
        public static string Status()
        {
            string ist = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "EmailLienhe")
                    {
                        ist = its.Value;
                    }
                }
            }
            return ist.ToString();
        }
        public static string Emailden()
        {
            string ist = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Emailden")
                    {
                        ist = its.Value;
                    }
                }
            }
            return ist.ToString();
        }
    }
    #endregion

    #region Senmai
    public class SenmaiConten
    {
        public static string SenmaiTitle()
        {
            string Title = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "SenmaiTitle")
                    {
                        Title = its.Value;
                    }
                }
            }
            return Title.ToString();
        }
        public static string SenmailConten()
        {
            string Conten = "";
            List<Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "SenmailConten")
                    {
                        Conten = its.Value;
                    }
                }
            }
            return Conten.ToString();
        }

    }
    #endregion

    #region GoogleMap
    public class GoogleMaps
    {
        public static string Degrees()
        {
            string ist = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Degrees")
                    {
                        ist = its.Value;
                    }
                }
            }
            return ist.ToString();
        }
        public static string Zoom()
        {
            string ist = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Zoom")
                    {
                        ist = its.Value;
                    }
                }
            }
            return ist.ToString();
        }
        public static string MapGooglepath()
        {
            string ist = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "MapGooglepath")
                    {
                        ist = its.Value;
                    }
                }
            }
            return ist.ToString();
        }
    }
    #endregion

    #region OnOffs
    public class OnOffs
    {
        public static string OnOff()
        {
            string Pages = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "OnOff")
                    {
                        Pages = its.Value;
                    }
                }
            }
            return Pages.ToString();
        }
        public static string StatusOnOff()
        {
            string Pages = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "StatusOnOff")
                    {
                        Pages = its.Value;
                    }
                }
            }
            return Pages.ToString();
        }
    }
    #endregion

    #region Ngan_Luong
    public class Ngan_Luong
    {
        public static string CheckOutUrl()
        {
            string stt = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "CheckOutUrl")
                    {
                        stt = its.Value;
                    }
                }
            }
            return stt.ToString();
        }
        public static string MerchantSiteCode()
        {
            string stt = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "MerchantSiteCode")
                    {
                        stt = its.Value;
                    }
                }
            }
            return stt.ToString();
        }
        public static string Receive()
        {
            string stt = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Receive")
                    {
                        stt = its.Value;
                    }
                }
            }
            return stt.ToString();
        }
        public static string PasswordNL()
        {
            string stt = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "PasswordNL")
                    {
                        stt = its.Value;
                    }
                }
            }
            return stt.ToString();
        }

    }
    #endregion
}