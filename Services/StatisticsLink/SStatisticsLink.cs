using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SStatisticsLink
    {
        private static FStatisticsLink db = new FStatisticsLink();

        #region GET BY ID
        public static List<StatisticsLink> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region INSERT
        public static bool INSERT(StatisticsLink data)
        {
            return db.Insert(data);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion
        #region GetTopProductInCategory
        public static List<StatisticsLink> GetTopProductInCategory(string imcid)
        {
            return db.GetTopProductInCategory(imcid);
        }
        #endregion
        #region Name_Text
        public static List<StatisticsLink> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
