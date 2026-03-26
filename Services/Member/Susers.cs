using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class Susers
    {
        private static Fusers db = new Fusers();

        #region UPDATE STATUS
        public static bool UPDATE_STATUS(string vuserun, string istatus)
        {
            return db.UPDATE_STATUS(vuserun, istatus);
        }
        #endregion

        #region GET BY ID
        public static List<users> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region CATEGORY
        public static List<users> CATEGORY(string istatus)
        {
            return db.CATEGORY(istatus);
        }
        #endregion

        #region GET BY ALL
        public static List<users> GET_BY_ALL()
        {
            return db.GETBYALL();
        }
        #endregion

        #region INSERT
        public static bool INSERT(users data)
        {
            return db.INSERT(data);
        }
        #endregion

        #region UPDATE
        public static bool users_update(users data)
        {
            return db.users_update(data);
        }
        #endregion
        #region UPDATE
        public static bool UPDATE(users data)
        {
            return db.UPDATE(data);
        }
        #endregion

        #region users_update_updateavatar
        public static bool users_update_updateavatar(users data)
        {
            return db.users_update_updateavatar(data);
        }
        #endregion

        public static List<users> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string lang, string Status)
        {
            return db.CATEGORY_ADMIN(orderby, searchkeyword, searchfields, lang, Status);
        }

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<users> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<users> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
