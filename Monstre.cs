using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public class Monstre : Personnel, IString
    {
        private string affectation;
        private double cagnotte;

        public Monstre(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, string affectation, int cagnotte) : base(matricule, nom, prenom, sexe, fonction)
        {
            this.affectation = affectation;
            this.cagnotte = cagnotte;
        }
        //Accesseurs dont on a besoin
        public double CAGNOTTE { get { return cagnotte; } set { cagnotte = value; } }
        public string AFFECTATION { get { return affectation; } set { value = affectation; } }

        //Les deux prochaines fonctions ne sont réservées que pour Rose
        public void AjouterPoint(int nombrePoint)
        {
            cagnotte += nombrePoint;
        }
        public void SupprimerPoint(int nombrePoint)
        {
            cagnotte -= nombrePoint;
        }
        //Réserver qu'à la RH ou lors du changement de cagnotte
        public void ChangerAffectation(string newA)
        {
            this.affectation = newA;
        }

        //Implémentation de l'interface
        public override string ToString()
        {
            return "Monstre : " + base.nom + " " + base.prenom + "\n\t  Cagnotte : " + CAGNOTTE + "\n\t  Fonction : " + base.fonction + "\n\t  Affectation : " + AFFECTATION;
        }
    }

}

