using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public class DarkRide : Attraction
    {
        private TimeSpan duree;
        private bool vehicule;

        public DarkRide(bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin, TimeSpan duree, bool vehicule) : base(besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.duree = duree;
            this.vehicule = vehicule;
        }
        public DarkRide(bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin, TimeSpan duree, bool vehicule) : base(besoinSpecifique, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.duree = duree;
            this.vehicule = vehicule;
        }
        public DarkRide(bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin, TimeSpan duree, bool vehicule) : base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.duree = duree;
            this.vehicule = vehicule;
        }

        public TimeSpan Duree { get { return duree; } set { duree = value; } }
        public bool Vehicule { get { return vehicule; } set { vehicule = value; } }
        //Implementation de la fonction abstract de la classe mère
        public override string ToString()
        {
            return "DarkRide : " + base.Nom + "\n\tNombre Min personnel : " + base.nbMinMonstre + "\n\tNombre prsonnel : " + base.equipe.Count() + "\n\tOuverte : " + base.ouvert + "\n\tEn Maintenance : " + base.EstMaintenance() + "\n\tBesoin vehicule : " + vehicule + "\n\tDuree : " + duree.ToString();
        }
    }
}
