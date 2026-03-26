using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Entity
{
    public class Carts
    {
        #region[Entity Private]
        private int _ID;
        private string _Name;
        private string _Address;
        private string _Phone;
        private string _Email;
        private string _Contents;
        private DateTime _Create_Date;
        private DateTime _Modified_Date;
        private Double _Money;
        private string _lang;
        private int _Status;
        private int _IDUser;
        private Double _Chietkhau;
        private string _Phuongthucthanhtoan;
        private string _Hinhthucvanchuyen;
        private string _Phone2;
        private string _Tongtrongluong;
        private string _TongTienthanhtoan;

        private int _Tinhthanh;
        private int _hinhthuc;
        private int _nhanhhaycham;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Contents { get { return _Contents; } set { _Contents = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public DateTime Modified_Date { get { return _Modified_Date; } set { _Modified_Date = value; } }
        public Double Money { get { return _Money; } set { _Money = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int IDUser { get { return _IDUser; } set { _IDUser = value; } }
        public Double Chietkhau { get { return _Chietkhau; } set { _Chietkhau = value; } }
        public string Phuongthucthanhtoan { get { return _Phuongthucthanhtoan; } set { _Phuongthucthanhtoan = value; } }
        public string Hinhthucvanchuyen { get { return _Hinhthucvanchuyen; } set { _Hinhthucvanchuyen = value; } }
        public string Phone2 { get { return _Phone2; } set { _Phone2 = value; } }
        public string Tongtrongluong { get { return _Tongtrongluong; } set { _Tongtrongluong = value; } }
        public string TongTienthanhtoan { get { return _TongTienthanhtoan; } set { _TongTienthanhtoan = value; } }
        public int Tinhthanh { get { return _Tinhthanh; } set { _Tinhthanh = value; } }
        public int hinhthuc { get { return _hinhthuc; } set { _hinhthuc = value; } }
        public int nhanhhaycham { get { return _nhanhhaycham; } set { _nhanhhaycham = value; } }

        #endregion
    }
}