using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class StatisticsLink
    {
        #region[Entity Private]
        private int _ID;
        private string _IP;
        private string _Link;
        private string _NameUser;
        private DateTime _Create_Date;
        private int _IDDate;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public string IP { get { return _IP; } set { _IP = value; } }
        public string Link { get { return _Link; } set { _Link = value; } }
        public string NameUser { get { return _NameUser; } set { _NameUser = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public int IDDate { get { return _IDDate; } set { _IDDate = value; } }
        #endregion

    }
}
