using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{

    public class Demon : Monstre, IString
    {
        private int force;
        public Demon(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, string affectation, int force) : base(matricule, nom, prenom, sexe, fonction, affectation, cagnotte)
        {
            this.force = force;
        }
        //Accesseur dont on a besoin
        public int FORCE
        {
            get { return force; }
            set { force = value; }
        }
        //Implementation de l'interface
        public override string ToString()
        {
            return "Monstre : Demon " + base.nom + " " + base.prenom + "\n\t  Cagnotte : " + base.CAGNOTTE + "\n\t  Fonction : " + base.fonction + "\n\t  Affectation : " + base.AFFECTATION + "\n\t  Force : " + force;
        }
    }
}
