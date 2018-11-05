using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public class Fantome : Monstre, IString
    {
        public Fantome(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, string affectation) : base(matricule, nom, prenom, sexe, fonction, affectation, cagnotte)
        {
        }
        //Implementation de l'interface
        public override string ToString()
        {
            return "Monstre : Fantome " + base.nom + " " + base.prenom + "\n\t  Cagnotte : " + base.CAGNOTTE + "\n\t  Fonction : " + base.fonction + "\n\t  Affectation : " + base.AFFECTATION;
        }
    }
}
