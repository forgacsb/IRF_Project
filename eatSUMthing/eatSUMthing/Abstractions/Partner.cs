using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eatSUMthing.Abstractions
{
    public abstract class Partner
    {
        private string _Név;

        public string Név
        {
            get { return _Név; }
            set { _Név = value; }
        }

        private DateTime _Születési_idő;

        public DateTime Születési_idő
        {
            get { return _Születési_idő; }
            set { _Születési_idő = value; }
        }

        private string _Lakcím;

        public string Lakcím
        {
            get { return _Lakcím; }
            set { _Lakcím = value; }
        }

        private string _Intézmény;

        public string Intézmény
        {
            get { return _Intézmény; }
            set { _Intézmény = value; }
        }


    }
}
