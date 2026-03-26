using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SVideoClip
    {
        private static FVideoClip db = new FVideoClip();

        #region INSERT
        public static bool INSERT(VideoClip obj)
        {
            return db.INSERT(obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(VideoClip obj)
        {
            return db.UPDATE(obj);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region GET BY ID
        public static List<VideoClip> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<VideoClip> GET_BY_ALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region GET DETAIL BY MENU ID
        public static List<VideoClip> GET_DETAIL_BY_MENUID(string ID_Menu, string imicID)
        {
            return db.GETDETAIL_MENUID(ID_Menu, imicID);
        }
        #endregion

        #region DELETE MENU ID
        public static void DELETE_ID_MEUN(string Menu_ID, string imicID)
        {
            db.Video_CATE_DELETE_MENU_ID(Menu_ID, imicID);
        }
        #endregion

        #region CATEGORY ADMIN
        public static List<VideoClip> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields,  string lang, string Status)
        {
            return db.CATEGORY_ADMIN(orderby, searchkeyword, searchfields, lang, Status);
        }
        #endregion

        #region UPDATE STATUS
        public static bool VIDeo_UpdateStatus(string ID, string status)
        {
            return db.UPDATE_STATUS(ID, status);
        }
        #endregion

        #region UPDATE VIEW TIME
        public static List<VideoClip> UPDATE_VIEWS_TIMES(string ID)
        {
            return db.UPDATE_VIEWTIME(ID);
        }
        #endregion

        #region GET DETAIL BY ID
        public static List<VideoClip> GET_DETAIL_BYID(string ID)
        {
            return db.Video_GETDETAIL_BYID(ID);
        }
        #endregion

        #region UPDATE IMG
        public static bool UPDATE_IMG(string ID)
        {
            return db.UPDATEIMG(ID);
        }
        #endregion

        #region CATEGORY
        public static List<VideoClip> CATEGORY(string imID, string lang, string Status)
        {
            return db.CATEGORY(imID, lang, Status);
        }
        #endregion

        #region NEWS OTHER LAST
        public static List<VideoClip> NEWS_OTHER_LAST(string ID, int top, string lang)
        {
            return db.NEWS_OTHERLAST(ID, top, lang);
        }
        #endregion

        #region NEWS OTHER FIRST
        public static List<VideoClip> NEWS_OTHER_FIRST(string ID, int top, string lang)
        {
            return db.NEWS_OTHERFIRST(ID, top, lang);
        }
        #endregion

        #region CHECKDATA
        public static List<VideoClip> CHECKDATA(string ID, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.CHECKDATA(ID, Chekdata, Create_Date, Modified_Date);
        }
        #endregion

        #region UPDATE DATTIME
        public static List<VideoClip> UPDATE_DATETIME(string ID, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.UPDATE_DATETIME(ID, Modified_Date, Modified_Date);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<VideoClip> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<VideoClip> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
