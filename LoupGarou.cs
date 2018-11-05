using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public class LoupGarou : Monstre, IString
    {
        double indiceCruaute;
        public LoupGarou(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, string affectation, double indiceCruaute) : base(matricule, nom, prenom, sexe, fonction, affectation, cagnotte)
        {
            this.indiceCruaute = indiceCruaute;
        }

        //Accesseur dont on a besoin
        public double CRUAUTE { get { return indiceCruaute; } set { indiceCruaute = value; } }
        //Implementation de l'interface
        public override string ToString()
        {
            return "Monstre : LoupGarou " + base.nom + " " + base.prenom + "\n\t  Cagnotte : " + base.CAGNOTTE + "\n\t  Fonction : " + base.fonction + "\n\t  Affectation : " + base.AFFECTATION + "\n\t  Cruaute : " + CRUAUTE;
        }
    }
}
