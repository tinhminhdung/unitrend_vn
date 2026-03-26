using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SGoogleMap
    {
        private static FGoogleMap db = new FGoogleMap();

        #region INSERT
        public static bool INSERT(GoogleMap data)
        {
            return  db.Insert(data);
        }
        #endregion
        #region UPDATE
        public static bool UPDATE(GoogleMap data)
        {
            return  db.UPDATE(data);
        }
        #endregion

        #region DELETE
        public static void DELETE(string igm)
        {
             db.DELETE(igm);
        }
        #endregion

        #region Category
        public static List<GoogleMap> Category(string lang, string Status)
        {
            return db.Category(lang, Status);
        }
        #endregion

        #region CATEGORY ADMIN
        public static List<GoogleMap> CATEGORY_ADMIN(string lang, string Status)
        {
            return db.CATEGORY_ADMIN(lang, Status);
        }
        #endregion

        #region DETAIL
        public static List<GoogleMap> DETAIL(string igm)
        {
            return  db.Detail(igm);
        }
        #endregion

        #region UPDATE STATUS
        public static bool UPDATE_STATUS(string igm, string status)
        {
            return  db.UPDATESTATUS(igm, status);
        }
        #endregion

        #region UPDATE IMG
        public static bool UPDATE_IMG(string igm, string vimg)
        {
            return  db.UPDATEIMG(igm, vimg);
        }
        #endregion
    }
}
