using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class AdminUser
    {
        #region[Declare variables]
        private int _ID;
        private string _VUSER_NAME;
        private string _VUSER_PWD;
        private string _VROLE;
        private int _IASSIGN;
        private DateTime _DASSIGN_DATE;
        private int _ILOCKED;

        private string _HoVaTen;
        private string _AnhDaiDien;
        private int _IsChechNghi;
        private string _MaNV;
        private int _Vaitro;
        private string _SoDienThoai;
        #endregion

        #region [Public Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public string VUSER_NAME { get { return _VUSER_NAME; } set { _VUSER_NAME = value; } }
        public string VUSER_PWD { get { return _VUSER_PWD; } set { _VUSER_PWD = value; } }
        public string VROLE { get { return _VROLE; } set { _VROLE = value; } }
        public int IASSIGN { get { return _IASSIGN; } set { _IASSIGN = value; } }
        public DateTime DASSIGN_DATE { get { return _DASSIGN_DATE; } set { _DASSIGN_DATE = value; } }
        public int ILOCKED { get { return _ILOCKED; } set { _ILOCKED = value; } }
        public string HoVaTen { get { return _HoVaTen; } set { _HoVaTen = value; } }
        public string AnhDaiDien { get { return _AnhDaiDien; } set { _AnhDaiDien = value; } }
        public int IsChechNghi { get { return _IsChechNghi; } set { _IsChechNghi = value; } }
        public string MaNV { get { return _MaNV; } set { _MaNV = value; } }
        public int Vaitro { get { return _Vaitro; } set { _Vaitro = value; } }
        public string SoDienThoai { get { return _SoDienThoai; } set { _SoDienThoai = value; } }
        #endregion

    }
}
