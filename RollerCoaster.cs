using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public enum TypeCategorie { assise, inversee, bobsleigh };
    public class RollerCoaster : Attraction
    {
        private TypeCategorie categorie;
        private double tailleMin;
        private int ageMin;


        public RollerCoaster(bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin, int ageMin, TypeCategorie categorie, double tailleMin) : base(besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.categorie = categorie;
            this.tailleMin = tailleMin;
            this.ageMin = ageMin;
        }
        public RollerCoaster(bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin, int ageMin, TypeCategorie categorie, double tailleMin) : base(besoinSpecifique, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.categorie = categorie;
            this.tailleMin = tailleMin;
            this.ageMin = ageMin;
        }
        public RollerCoaster(bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin, int ageMin, TypeCategorie categorie, float tailleMin) : base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.categorie = categorie;
            this.tailleMin = tailleMin;
            this.ageMin = ageMin;
        }

        //Accesseurs dont on a besoin 
        public TypeCategorie Categorie { get { return categorie; } set { categorie = value; } }
        public double TailleMin { get { return tailleMin; } set { tailleMin = value; } }
        public int AgeMin { get { return ageMin; } set { ageMin = value; } }


        //Implementation de la fonction abstract de la classe mère
        public override string ToString()
        {
            return "RollerCoaster : " + base.Nom + "\n\tNombre Min personnel : " + base.nbMinMonstre + "\n\tNombre prsonnel : " + base.equipe.Count() + "\n\tOuverte : " + base.ouvert + "\n\tEn Maintenance : " + base.EstMaintenance() + "\n\tCategorie : " + categorie.ToString() + "\n\tTaille Min : " + tailleMin + "\n\tAge Min : " + ageMin;
        }
    }
}
