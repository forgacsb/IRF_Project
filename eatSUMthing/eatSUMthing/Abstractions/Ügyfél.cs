using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eatSUMthing.Abstractions
{
    public abstract class Ügyfél
    {
        public string Név { get; set; }

        public DateTime Születési_idő { get; set; }

        public string Lakcím { get; set; }

        public int Ár { get; set; }
    }
}
