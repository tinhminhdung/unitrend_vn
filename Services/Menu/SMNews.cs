using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SMNews
    {
        private static FMNews db = new FMNews();

        #region GET BY ID
        public static List<MNews> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region IN ID
        public static List<MNews> IN_ID(string ID)
        {
            return db.IN_ID(ID);
        }
        #endregion

        #region GET BY TOP
        public static List<MNews> GET_BY_TOP(string Top, string Where, string Order)
        {
            return db.GETBYTOP(Top, Where, Order);
        }
        #endregion

        #region GET BY ALL
        public static List<MNews> GET_BYALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region INSERT
        public static bool INSERT(MNews data)
        {
            return db.INSERT(data);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(MNews data)
        {
            return db.UPDATE(data);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELET(ID);
        }
        #endregion

        #region UPDATE STATUS
        public static bool UPDATE_STATUS(string ID, string status)
        {
            return db.UPDATE_STATUS(ID, status);
        }
        #endregion

        #region GET DETAIl BY ID
        public static List<MNews> GET_DETAIL_BYID(string ID)
        {
            return db.GET_DETAIL_BYID(ID);
        }
        #endregion

        #region GET DETAIL BY MENU ID
        public static List<MNews> GET_DETAIL_BYMENUID(string Menu_ID, string imcID)
        {
            return db.GET_DETAIL_BYMENUID(Menu_ID, imcID);
        }
        #endregion

        #region CATE DELETE MENU ID
        public static void CATE_DELETE_MENUID(string Menu_ID)
        {
            db.CATE_DELETE_MENUID(Menu_ID);
        }
        #endregion

        #region CATEGORY
        public static List<MNews> CATEGORY(string Menu_ID, string Lang, string Status)
        {
            return db.CATEGORY(Menu_ID, Lang, Status);
        }
        #endregion


        #region NEWS_OTHERLAST
        public static List<MNews> NEWS_OTHERLAST(string ID, int top, string lang, string Menu_ID)
        {
            return db.NEWS_OTHERLAST(ID, top, lang, Menu_ID);
        }
        #endregion
        #region GET DETAIL BY MENU ID
        public static List<MNews> NEWS_OTHERFIRST(string ID, int top, string lang, string Menu_ID)
        {
            return db.NEWS_OTHERFIRST(ID, top, lang, Menu_ID);
        }
        #endregion
        #region UPDATE_VIEW_TIME
        public static List<MNews> UPDATE_VIEW_TIME(string ID)
        {
            return db.UPDATE_VIEW_TIME(ID);
        }
        #endregion

        #region Name_Text
        public static List<MNews> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion

    }
}
