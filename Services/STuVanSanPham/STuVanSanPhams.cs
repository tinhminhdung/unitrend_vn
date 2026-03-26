using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class STuVanSanPham
    {
        private static FTuVanSanPhams db = new FTuVanSanPhams();

        #region GET BY ID
        public static List<TuVanSanPham> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region CATEGORY ADMIN
        public static List<TuVanSanPham> CATEGORYADMIN(string lang, string istatus)
        {
            return db.CATEGORY_ADMIN(lang, istatus);
        }
        #endregion

        #region GET BY ALL
        public static List<TuVanSanPham> GET_BY_ALl(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region INSERT
        public static bool INSERT(TuVanSanPham data)
        {
            return db.Insert(data);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(TuVanSanPham data)
        {
            return db.Update(data);
        }
        #endregion

        #region UPDATE STATUS
        public static bool UPDATE_STATUS(string ino, string istatus)
        {
            return db.UPDATESTATUS(ino, istatus);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<TuVanSanPham> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<TuVanSanPham> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
