using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public enum TypeBoutique { souvenir, barbeAPapa, nourriture };
    public class Boutique : Attraction
    {
        private TypeBoutique type;


        public Boutique(bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin, TypeBoutique type) : base(besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.type = type;
        }
        public Boutique(bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin, TypeBoutique type) : base(besoinSpecifique, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.type = type;
        }
        public Boutique(bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin, TypeBoutique type) : base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.type = type;
        }

        //Accesseur dont on a besoin
        public TypeBoutique Type { get { return type; } set { type = value; } }

        //Implémentation de la fonction abstract de la classe mere
        public override string ToString()
        {
            return "Boutique : " + base.Nom + "\n\tNombre Min personnel : " + base.nbMinMonstre + "\n\tNombre prsonnel : " + base.equipe.Count() + "\n\tOuverte : " + base.ouvert + "\n\tEn Maintenance : " + base.EstMaintenance();
        }
    }
}
