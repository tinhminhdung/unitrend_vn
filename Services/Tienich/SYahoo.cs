using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;


namespace Services
{
    public class SYahoo
    {
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
                return language;
            }
        }
        #endregion
        private static FYahooMessenger db = new FYahooMessenger();

        #region GET BY ID
        public static List<YahooMessenger> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<YahooMessenger> GET_BY_ALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region INSERT
        public static bool INSERT(YahooMessenger Obj)
        {
            return db.INSERT(Obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(YahooMessenger Obj)
        {
            return db.UPDATE(Obj);
        }
        #endregion

        #region CATE UPDATE
        public static bool CATE_UPDATE(string inick, string Status)
        {
            return db.CATEUPDATE(inick, Status);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        //#region YahooMessengers
        //public static string YahooMessengers()
        //{
        //    System.Text.StringBuilder strb = new System.Text.StringBuilder();
        //    List<Entity.YahooMessenger> dt = SYahoo.GET_BY_ALL(Language);
        //    if (dt.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Count; i++)
        //        {
        //            strb.AppendLine("<div class=\"hotline-item\">");
        //            strb.AppendLine("<h4><i class=\"fa fa-life-ring\"></i>" + dt[i].Title + "</h4>");
        //            strb.AppendLine("<div class=\"hot_sup\">");
        //            strb.AppendLine("<a href=\"skype:" + dt[i].Skype + "?chat\">");
        //            strb.AppendLine("<img src=\"/Resources/images/skype.png\" alt=\"" + dt[i].Title + "\" title=\"" + dt[i].Title + "\" width=\"65\"/>");
        //            strb.AppendLine("</a>");
        //            strb.AppendLine("</div>");
        //            strb.AppendLine("<div class=\"hot_sup\">");
        //            strb.AppendLine("<a title=\"" + dt[i].Title + "\" href=\"zalo:" + dt[i].Nick + "?chat\"><img class=\"zalo\" src=\"/Resources/images/icon-zalo.png\" style=\"width:30px; height: 30px;\" alt=\"" + dt[i].Title + "\" title=\"" + dt[i].Title + "\"></a>");
        //            strb.AppendLine("</div>");
        //            strb.AppendLine("<div style=\"clear:both\"></div>");
        //            strb.AppendLine("<p>Mobile: " + dt[i].Phone + "</p>");
        //            strb.AppendLine("</div>");
        //        }
        //    }
        //    return strb.ToString();
        //}
        //#endregion

        #region YahooMessengers
        public static string YahooMessengers()
        {
            System.Text.StringBuilder strb = new System.Text.StringBuilder();
            List<Entity.YahooMessenger> dt = SYahoo.GET_BY_ALL(Language);
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    strb.AppendLine(" <div class=\"tongya\">");
                    strb.AppendLine(" <div class=\"trai\">");
                    strb.AppendLine(dt[i].Title);
                    strb.AppendLine(" </div>");
                    strb.AppendLine(" <div class=\"phai\">");
                    strb.AppendLine("  <div class=\"tren\">");
                    strb.AppendLine("  <span>" + dt[i].Phone + "</span>");
                    strb.AppendLine("  </div>");
                    strb.AppendLine("  <div class=\"duoi\">");
                    if (dt[i].Skype.Length > 0)
                    {
                        strb.AppendLine("<a title=\"" + dt[i].Title + "\" href=\"skype:" + dt[i].Skype + "?chat\"><img class='skype' src=\"/Resources/images/skype.png\" alt=\"" + dt[i].Skype + "\" title=\"" + dt[i].Skype + "\" /></a>");
                    }
                    strb.AppendLine("<a title=\"" + dt[i].Title + "\" href=\"zalo:" + dt[i].Email + "?chat\"><img class='zalo' src=\"/Resources/images/icon-zalo.png\"  style='width:25px; height: 25px; margin-left: 7px;' alt=\"" + dt[i].Email + "\" title=\"" + dt[i].Email + "\" /></a>");
                    strb.AppendLine(" </div>");
                    strb.AppendLine("  </div>");
                    strb.AppendLine("  </div>");
                }
            }
            return strb.ToString();
        }
        #endregion
        #region Name_StoredProcedure
        public static List<YahooMessenger> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<YahooMessenger> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
