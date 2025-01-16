using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForml3iage
{
    internal class Personne
    {
        public string prenom {  get; set; }

        public string nom { get; set; }

        public String tel { get; set; }

        public String sexe { get; set; }

        public String competences { get; set; }

        public String classe { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public Personne()
        {
        }
    }
}
