using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public class Vampire : Monstre, IString
    {
        double indiceLuminosite;
        public Vampire(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, string affectation, double indiceLuminosite) : base(matricule, nom, prenom, sexe, fonction, affectation, cagnotte)
        {
            this.indiceLuminosite = indiceLuminosite;
        }
        //Accesseur dont on a besoin
        public double INDICELUMINOSITE
        {
            get { return indiceLuminosite; }
            set { indiceLuminosite = value; }
        }
        //Implémente l'interface
        public override string ToString()
        {
            return "Monstre : Vampire " + base.nom + " " + base.prenom + "\n\t  Cagnotte : " + base.CAGNOTTE + "\n\t  Fonction : " + base.fonction + "\n\t  Affectation : " + base.AFFECTATION + "\n\t  Indice Luminosité : " + indiceLuminosite;
        }
    }
}
