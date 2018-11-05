using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public enum TypeSexe { male, femelle, autre };
    public abstract class Personnel : IComparable<Personnel>
    {
        protected string fonction;
        protected int matricule;
        protected string nom;
        protected string prenom;
        protected TypeSexe sexe;

        public Personnel(int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
        }
        //Accesseurs dont on a besoin
        public string NOM { get { return nom; } set { nom = value; } }
        public string PRENOM { get { return prenom; } set { prenom = value; } }
        public int MATRICULE { get { return matricule; } set { matricule = value; } }
        public string FONCTION { get { return fonction; } set { fonction = value; } }
        public TypeSexe SEXE { get { return sexe; } set { sexe = value; } }

        //Réserver pour la RH
        public void ChangerFonction(string NewF)
        {
            this.fonction = NewF;
        }

        //Implémente l'interface Icomparable afin de procéder à un tri, de base on le fait sur le nom
        public int CompareTo(Personnel other)
        {
            return this.nom.CompareTo(other.nom);
        }
    }
}
