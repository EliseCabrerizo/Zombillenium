using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public class Spectacle : Attraction
    {
        private string nomSalle;
        private int nbPlaces;
        private List<DateTime> horaires;


        public Spectacle(bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin, List<DateTime> horaires, int nbPlaces, string nomSalle) : base(besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.nomSalle = nomSalle;
            this.nbPlaces = nbPlaces;
            this.horaires = horaires;
        }

        public Spectacle(bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin, List<DateTime> horaires, int nbPlaces, string nomSalle) : base(besoinSpecifique, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.nomSalle = nomSalle;
            this.nbPlaces = nbPlaces;
            this.horaires = horaires;
        }
        public Spectacle(bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin, List<DateTime> horaires, int nbPlaces, string nomSalle) : base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.nomSalle = nomSalle;
            this.nbPlaces = nbPlaces;
            this.horaires = horaires;
        }

        //Accesseurs dont on a besoin 
        public string NomSalle { get { return nomSalle; } set { nomSalle = value; } }
        public int NbPlaces { get { return nbPlaces; } set { nbPlaces = value; } }
        public List<DateTime> Horaires { get { return horaires; } set { horaires = value; } }

        //Implementation de la fonction abstract de la classe mère
        public override string ToString()
        {
            string str= "Spectacle : " + base.Nom + "\n\tNombre Min personnel : " + base.nbMinMonstre + "\n\tNombre prsonnel : " + base.equipe.Count() + "\n\tOuverte : " + base.ouvert + "\n\tEn Maintenance : " + base.EstMaintenance() + "\n\tNombre places : " + nbPlaces + "\n\tSalle : " + nomSalle + "\n\tHoraires : ";
            for (int i = 0; i < horaires.Count; i++)
                str += horaires[i]+" ";
            return str;
        }
    }
}
