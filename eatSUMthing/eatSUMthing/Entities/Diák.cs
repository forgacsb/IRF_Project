using eatSUMthing.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eatSUMthing.Entities
{
    class Diák : Ügyfél
    {
        public string Anyja_neve { get; set; }

        public string Osztály { get; set; }

        public Boolean TB { get; set; }

        public Boolean NCS { get; set; }

        public Boolean GYVK { get; set; }

        public Boolean Diétás { get; set; }

        public string Intézmény { get; set; }

    }
}
