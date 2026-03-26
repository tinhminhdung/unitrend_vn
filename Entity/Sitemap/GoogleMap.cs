using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class GoogleMap
    {
        #region[Declare variables]
        private int _igm;
        private string _Name;
        private string _Degrees;
        private string _vimg;
        private string _lang;
        private int _Orders;
        private DateTime _Createdate;
        private int _Status;
        #endregion

        #region[Public Properties]
        public int igm { get { return _igm; } set { _igm = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Degrees { get { return _Degrees; } set { _Degrees = value; } }
        public string vimg { get { return _vimg; } set { _vimg = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int Orders { get { return _Orders; } set { _Orders = value; } }
        public DateTime Createdate { get { return _Createdate; } set { _Createdate = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        #endregion

    }
}
