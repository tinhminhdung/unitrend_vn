using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class onlyitems
    {
        #region[Entity Private]
        private int _idl;
        private string _vtitle;
        private string _vcontent;
        private DateTime _dcreatedate;
        private string _lang;
        private int _display;
        private int _istatus;
        #endregion

        #region[Properties]
        public int idl { get { return _idl; } set { _idl = value; } }
        public string vtitle { get { return _vtitle; } set { _vtitle = value; } }
        public string vcontent { get { return _vcontent; } set { _vcontent = value; } }
        public DateTime dcreatedate { get { return _dcreatedate; } set { _dcreatedate = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int display { get { return _display; } set { _display = value; } }
        public int istatus { get { return _istatus; } set { _istatus = value; } }
        #endregion

    }
}
