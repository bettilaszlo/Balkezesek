using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    class balkezesek
    {
        public string Nev { get; private set; }
        public string Elso { get; private set; }
        public string Utolso { get; private set; }
        public int Suly { get; private set; }
        public int Magassag { get; private set; }
        
        public balkezesek(string nev, string elso, string utolso, int suly, int magassag)
        {
            this.Nev = nev;
            this.Elso = elso;
            this.Utolso = utolso;
            this.Suly = Convert.ToInt32(suly);
            this.Magassag = Convert.ToInt32(magassag);
        }
    }
}
