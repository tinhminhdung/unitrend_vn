using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SOnlyitems
    {
        private static Fonlyitems db = new Fonlyitems();

        #region GET BY ID
        public static List<onlyitems> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region LIST ADMIn
        public static List<onlyitems> LIST_ADMIN(string istatus, string lang)
        {
            return db.LISTADMIN(istatus, lang);
        }
        #endregion

        #region GET BY ALL
        public static List<onlyitems> GET_BY_ALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region INSERT
        public static bool INSERT(onlyitems Obj)
        {
            return db.INSERT(Obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(onlyitems Obj)
        {
            return db.UPDATE(Obj);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.onlyitems_DELETE(ID);
        }
        #endregion
    }
}
