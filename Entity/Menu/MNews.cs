using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class MNews
    {
        #region[Entity Private]
        private int _ID;
        private int _Menu_ID;
        private string _Title;
        private string _Brief;
        private string _Contents;
        private string _Keywords;
        private int _Equals;
        private string _Images;
        private string _ImagesSmall;
        private string _Url_Name;
        private string _User_Name;
        private string _Search;
        private int _Orders;
        private DateTime _Create_Date;
        private DateTime _Modified_Date;
        private int _Views;
        private string _Tags;
        private string _Lang;
        private int _Types;
        private int _Status;
        private string _TangName;
        private int _CheckBox1;
        private int _CheckBox2;
        private int _CheckBox3;
        private int _CheckBox4;
        private int _CheckBox5;
        private int _CheckBox6;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int Menu_ID { get { return _Menu_ID; } set { _Menu_ID = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Brief { get { return _Brief; } set { _Brief = value; } }
        public string Contents { get { return _Contents; } set { _Contents = value; } }
        public string Keywords { get { return _Keywords; } set { _Keywords = value; } }
        public int Equals { get { return _Equals; } set { _Equals = value; } }
        public string Images { get { return _Images; } set { _Images = value; } }
        public string ImagesSmall { get { return _ImagesSmall; } set { _ImagesSmall = value; } }
        public string Url_Name { get { return _Url_Name; } set { _Url_Name = value; } }
        public string User_Name { get { return _User_Name; } set { _User_Name = value; } }
        public string Search { get { return _Search; } set { _Search = value; } }
        public int Orders { get { return _Orders; } set { _Orders = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public DateTime Modified_Date { get { return _Modified_Date; } set { _Modified_Date = value; } }
        public int Views { get { return _Views; } set { _Views = value; } }
        public string Tags { get { return _Tags; } set { _Tags = value; } }
        public string Lang { get { return _Lang; } set { _Lang = value; } }
        public int Types { get { return _Types; } set { _Types = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string TangName { get { return _TangName; } set { _TangName = value; } }
        public int CheckBox1 { get { return _CheckBox1; } set { _CheckBox1 = value; } }
        public int CheckBox2 { get { return _CheckBox2; } set { _CheckBox2 = value; } }
        public int CheckBox3 { get { return _CheckBox3; } set { _CheckBox3 = value; } }
        public int CheckBox4 { get { return _CheckBox4; } set { _CheckBox4 = value; } }
        public int CheckBox5 { get { return _CheckBox5; } set { _CheckBox5 = value; } }
        public int CheckBox6 { get { return _CheckBox6; } set { _CheckBox6 = value; } }
        #endregion
    }
}
