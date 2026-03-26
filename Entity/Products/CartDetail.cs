using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Entity
{
    public class CartDetail
    {
        #region[Entity Private]
        private int _ID;
        private int _ID_Cart;
        private int _ipid;
        private Double _Price;
        private int _Quantity;
        private Double _Money;
        private string _Name;
        private string _Ghichu;

        private string _Donvitinh;
        private string _Trongluong;

        #endregion
        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int ID_Cart { get { return _ID_Cart; } set { _ID_Cart = value; } }
        public int ipid { get { return _ipid; } set { _ipid = value; } }
        public Double Price { get { return _Price; } set { _Price = value; } }
        public int Quantity { get { return _Quantity; } set { _Quantity = value; } }
        public Double Money { get { return _Money; } set { _Money = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Ghichu { get { return _Ghichu; } set { _Ghichu = value; } }
   
        public string Donvitinh { get { return _Donvitinh; } set { _Donvitinh = value; } }
        public string Trongluong { get { return _Trongluong; } set { _Trongluong = value; } }

        #endregion

    }
}