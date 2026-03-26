using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SMenu
    {
        private static FMenu db = new FMenu();
        #region Updatemenu
        public static bool Updatemenu(string ino, string Giatri, string Giatritruyen)
        {
            return db.Updatemenu(ino, Giatri, Giatritruyen);
        }
        #endregion
        #region Parent_ID
        public static List<Menu> Parent_ID(string _parent_ID)
        {
            return db.Parent_ID(_parent_ID);
        }
        #endregion

        #region DETAIL CAPP PARENT ID
        public static List<Menu> DETAIL_CAPP_PARENTID(string Parent_ID, string capp)
        {
            return db.DETAIL_CAPP_PARENTID(Parent_ID, capp);
        }
        #endregion

        #region GET BY ID capp, lang, Parent_ID, status
        public static List<Menu> capp_Lang_Parent_ID_Status(string capp, string lang, string Parent_ID, string status)
        {
            return db.LOAD_CATES_PARENTID(capp, lang, Parent_ID, status);
        }
        public static List<Menu> capp_Lang_Parent_ID_Status_v2(string capp, string lang, string Parent_ID, string status)
        {
            return db.LOAD_CATES_PARENTID_v2(capp, lang, Parent_ID, status);
        }
        #endregion

        #region GET BY ID capp, lang, ID, status
        public static List<Menu> capp_Lang_MoreIn_ID_Status(string capp, string lang, string ID, string status)
        {
            return db.capp_Lang_MoreIn_ID_Status(capp, lang, ID, status);
        }
        #endregion

        #region GET BY ID capp, lang, ID, status
        public static List<Menu> capp_Lang_ID_Status(string capp, string lang, string ID, string status)
        {
            return db.capp_Lang_ID_Status(capp, lang, ID, status);
        }
        #endregion


        #region capp_Lang_Parent_ID_Home_Status
        public static List<Menu> capp_Lang_Parent_ID_Home_Status(string capp, string Lang, string Parent_ID, string page_Home, string Status)
        {
            return db.capp_Lang_Parent_ID_Home_Status(capp, Lang, Parent_ID, page_Home, Status);
        }
        #endregion

        #region GET BY ID
        public static List<Menu> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region Detail
        public static List<Menu> Detail(string ID)
        {
            return db.Detail(ID);
        }
        #endregion

        #region ID_Parent_ID
        public static List<Menu> ID_Parent_ID(string ID, string Parent_ID)
        {
            return db.ID_Parent_ID(ID, Parent_ID);
        }
        #endregion

        #region LOAD CATES PARENT ID
        public static List<Menu> LOAD_CATESPARENT_ID(string capp, string Lang, string Parent_ID, string Status)
        {
            return db.LOAD_CATES_PARENTID(capp, Lang, Parent_ID, Status);
        }
        #endregion

        #region UPDATE STATUS
        public static bool UPDATESTATUS(string ino, string istatus)
        {
            return db.UPDATESTATUS(ino, istatus);
        }
        #endregion


        #region UPDATESHOME
        public static bool UPDATESHOME(string ino, string Home)
        {
            return db.UPDATESHOME(ino, Home);
        }
        #endregion

        #region CATE LOAD ALL NEWS
        public static List<Menu> CATE_LOADALL_NEWS(string capp, string Lang, string Parent_ID)
        {
            return db.LOAD_ALL_MENU(capp, Lang, Parent_ID);
        }
        #endregion

        #region GET PARENT ID
        public static List<Menu> GETPARENT_ID(string ID, string Parent_ID)
        {
            return db.GETPARENT_ID(ID, Parent_ID);
        }
        #endregion

        #region UPDATE VIEWS Tang
        public static bool UPDATEVIEWS_T(string ID)
        {
            return db.UPDATEVIEWS_T(ID);
        }
        #endregion

        #region UPDATE VIEWS Giam
        public static bool UPDATEVIEWS_G(string ID)
        {
            return db.UPDATEVIEWS_G(ID);
        }
        #endregion

        #region GET BY TOP
        public static List<Menu> GETBYTOP(string Top, string Where, string Order)
        {
            return db.GETBYTOP(Top, Where, Order);
        }
        #endregion

        #region GET BY ALL
        public static List<Menu> GETBYALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region PAGING
        public static List<Menu> PAGING(string CurentPage, string PageSize, string Lang)
        {
            return db.PAGING(CurentPage, PageSize, Lang);
        }
        #endregion

        #region INSERT
        public static bool Insert(Menu Obj)
        {
            return db.INSERT(Obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(Menu Obj)
        {
            return db.UPDATE(Obj);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region DELETE PARENT
        public static void DELETE_PARENT(string ID)
        {
            db.DELETE_PARENT(ID);
        }
        #endregion

        #region UPDATE IMG
        public static bool UPDATEIMG(string ID, string image)
        {
            return db.UPDATEIMG(ID, image);
        }
        #endregion

        #region CATE LOAD ALL MENU
        public static List<Menu> CATE_LOADALL_MENU(string capp, string Lang, string Parent_ID)
        {
            return db.CATE_LOADALLNEWS(capp, Lang, Parent_ID);
        }

        #endregion

        #region MENU UPDATE ORDERS
        public static bool UPDATE_ORDERS(string ID, string up_down)
        {
            return db.UPDATE_ORDERS(ID, up_down);
        }
        #endregion

        #region[Menu_More_ID]
        public static List<Menu> MORE_ID(string ID)
        {
            return db.MORE_ID(ID);
        }
        #endregion


        #region[Pages_Home]
        public static List<Menu> Pages_Home(string capp, string Lang, string page_Home)
        {
            return db.Pages_Home(capp, Lang, page_Home);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<Menu> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<Menu> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
