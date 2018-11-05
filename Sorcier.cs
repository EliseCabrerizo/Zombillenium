using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public enum Grade { novice, mega, giga, strata };
    public class Sorcier : Personnel, IString
    {
        private Grade tatouage;
        private List<string> Pouvoirs = new List<string>();

        public Sorcier(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, Grade tatouage, List<string> Pouvoirs) : base(matricule, nom, prenom, sexe, fonction)
        {
            this.tatouage = tatouage;
            this.Pouvoirs = Pouvoirs;
        }
        public Sorcier(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, Grade tatouage) : base(matricule, nom, prenom, sexe, fonction)
        {
            this.tatouage = tatouage;
        }
        //Accesseur dont on a besoun
        public Grade GRADE
        {
            get { return tatouage; }
            set { tatouage = value; }
        }

        //Permet d'ajouter ou supprimer un pouvoir
        public void AjouterPouvoir(string nomPouvoir)
        {
            Pouvoirs.Add(nomPouvoir);
        }
        public void SupprimerPouvoir(string nomPouvoir)
        {
            Pouvoirs.Remove(nomPouvoir);
        }
        //Liste tous les pouvoirs qu'à le sorcier
        public string ListerPouvoir()
        {
            string str = "";
            for (int i = 0; i < Pouvoirs.Count(); i++)
                str += Pouvoirs[i];
            return str;
        }
        public void ModifierGrade(Grade nouveauTatouage)
        {
            tatouage = nouveauTatouage;
        }

        //Implemente l'interface
        public override string ToString()
        {
            string str= "Sorcier : " + nom + " " + prenom + "\n\t  Fonction : " + base.fonction + " \n\t  Grade : " + tatouage + " \n\t  Pouvoir : ";
            for (int i = 0; i < Pouvoirs.Count; i++)
                str += Pouvoirs[i] + " ; ";
            return str;
        }
    }
}
