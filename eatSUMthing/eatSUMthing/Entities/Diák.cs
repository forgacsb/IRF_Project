using eatSUMthing.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eatSUMthing.Entities
{
    class Diák : Partner
    {
        private string _Anyja_neve;

        public string Anyja_neve
        {
            get { return _Anyja_neve; }
            set { _Anyja_neve = value; }
        }
        private string _Osztály;

        public string Osztály
        {
            get { return _Osztály; }
            set { _Osztály = value; }
        }

        private Boolean _TB;

        public Boolean TB
        {
            get { return _TB; }
            set { _TB = value; }
        }

        private Boolean _NCS;

        public Boolean NCS
        {
            get { return _NCS; }
            set { _NCS = value; }
        }

        private Boolean _GYVK;

        public Boolean GYVK
        {
            get { return _GYVK; }
            set { _GYVK = value; }
        }

        private Boolean _Diétás;

        public Boolean Diétás
        {
            get { return _Diétás; }
            set { _Diétás = value; }
        }

    }
}
