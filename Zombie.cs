using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public enum CouleurZ { bleuatre, grisatre };
    public class Zombie : Monstre, IString
    {
        private int degreeDecomposition;
        private CouleurZ teint;
        public Zombie(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, string affectation, int degreeDecomposition, CouleurZ teint) : base(matricule, nom, prenom, sexe, fonction, affectation, cagnotte)
        {
            this.degreeDecomposition = degreeDecomposition;
            this.teint = teint;
        }
        //Accesseurs dont on a besoin
        public int DEGREDECOMPOSITION { get { return degreeDecomposition; } set { degreeDecomposition = value; } }
        public CouleurZ TEINT { get { return teint; } set { teint = value; } }

        //Implémente l'interface
        public override string ToString()
        {
            return "Monstre : Zombie " + base.nom + " " + base.prenom + "\n\t  Cagnotte : " + base.CAGNOTTE + "\n\t  Fonction : " + base.fonction + "\n\t  Affectation : " + base.AFFECTATION + "\n\t  Teint : " + teint + "\n\t  Degree Decomposition : " + degreeDecomposition;
        }
    }
}
