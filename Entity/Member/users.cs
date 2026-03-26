using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class users
    {
        #region[Entity Private]
        private int _iuser_id;
        private string _vuserun;
        private string _vuserpwd;
        private string _vfname;
        private string _vlname;
        private int _igender;
        private DateTime _dbirthday;
        private string _vidcard;
        private string _vaddress;
        private string _vphone;
        private string _vemail;
        private int _iregionid;
        private string _vavatar;
        private string _vavatartitle;
        private DateTime _dcreatedate;
        private DateTime _dlastvisited;
        private string _vvalidatekey;
        private int _istatus;
        private string _lang;

        private string _Thanhpho;
        private string _Quanhuyen;
        private string _Phuongxa;
        private string _Tencongty;
        private string _Diachicongty;
        private string _Dienthoaicongty;
        private string _Masothuecongty;
        #endregion

        #region[Properties]
        public int iuser_id { get { return _iuser_id; } set { _iuser_id = value; } }
        public string vuserun { get { return _vuserun; } set { _vuserun = value; } }
        public string vuserpwd { get { return _vuserpwd; } set { _vuserpwd = value; } }
        public string vfname { get { return _vfname; } set { _vfname = value; } }
        public string vlname { get { return _vlname; } set { _vlname = value; } }
        public int igender { get { return _igender; } set { _igender = value; } }
        public DateTime dbirthday { get { return _dbirthday; } set { _dbirthday = value; } }
        public string vidcard { get { return _vidcard; } set { _vidcard = value; } }
        public string vaddress { get { return _vaddress; } set { _vaddress = value; } }
        public string vphone { get { return _vphone; } set { _vphone = value; } }
        public string vemail { get { return _vemail; } set { _vemail = value; } }
        public int iregionid { get { return _iregionid; } set { _iregionid = value; } }
        public string vavatar { get { return _vavatar; } set { _vavatar = value; } }
        public string vavatartitle { get { return _vavatartitle; } set { _vavatartitle = value; } }
        public DateTime dcreatedate { get { return _dcreatedate; } set { _dcreatedate = value; } }
        public DateTime dlastvisited { get { return _dlastvisited; } set { _dlastvisited = value; } }
        public string vvalidatekey { get { return _vvalidatekey; } set { _vvalidatekey = value; } }
        public int istatus { get { return _istatus; } set { _istatus = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }

        public string Thanhpho { get { return _Thanhpho; } set { _Thanhpho = value; } }
        public string Quanhuyen { get { return _Quanhuyen; } set { _Quanhuyen = value; } }
        public string Phuongxa { get { return _Phuongxa; } set { _Phuongxa = value; } }
        public string Tencongty { get { return _Tencongty; } set { _Tencongty = value; } }
        public string Diachicongty { get { return _Diachicongty; } set { _Diachicongty = value; } }
        public string Dienthoaicongty { get { return _Dienthoaicongty; } set { _Dienthoaicongty = value; } }
        public string Masothuecongty { get { return _Masothuecongty; } set { _Masothuecongty = value; } }
        #endregion
    }
}
