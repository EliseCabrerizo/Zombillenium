using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombillenium
{
    public abstract class Attraction
    {
        protected bool besoinSpecifique;
        protected List<Monstre> equipe = new List<Monstre>();
        protected int identifiant;
        protected int nbMinMonstre;
        protected string nom;
        protected bool ouvert = false;
        protected string typeDeBesoin;
        protected bool maintenance = false;
        protected string natureMaintenance = null;
        protected TimeSpan dureeMaintenance;

        public Attraction(bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.identifiant = identifiant;
            this.nom = nom;
            this.nbMinMonstre = nbMinMonstre;
            this.equipe = equipe;
            this.typeDeBesoin = typeDeBesoin;
        }
        public Attraction(bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.identifiant = identifiant;
            this.nom = nom;
            this.nbMinMonstre = nbMinMonstre;
            this.typeDeBesoin = typeDeBesoin;

        }
        public Attraction(bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.dureeMaintenance = dureeMaintenance;
            this.natureMaintenance = natureMaintenance;
            this.identifiant = identifiant;
            this.nom = nom;
            this.ouvert = ouvert;
            this.maintenance = maintenance;
            this.nbMinMonstre = nbMinMonstre;
            this.equipe = equipe;
            this.typeDeBesoin = typeDeBesoin;

        }
        //On code tous les accesseurs dont on a besoin
        public int Identifiant
        {
            get { return identifiant; }
            set { identifiant = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public bool Ouvert
        {
            get { return ouvert; }
            set { ouvert = value; }
        }
        public int NombreMinMonstre
        {
            get { return nbMinMonstre; }
            set { nbMinMonstre = value; }
        }
        public List<Monstre> Equipe
        {
            get { return equipe; }
            set { equipe = value; }
        }
        public string TypeDeBesoin
        {
            get { return typeDeBesoin; }
            set { typeDeBesoin = value; }
        }
        public bool BesoinSpecifique
        {
            get { return besoinSpecifique; }
            set { besoinSpecifique = value; }
        }
        public bool Maintenance
        {
            get { return maintenance; }
            set { maintenance = value; }
        }

        //Modifie si l'attraction est ouverte ou non
        public void EstOuverte(bool ouvert)
        {
            this.ouvert = ouvert;
        }
        //Ajoute un montre à l'attraction grâce aux propriétés de la liste
        public void AjouterEquipe(Monstre M)
        {
            equipe.Add(M);
        }
        //Supprime un montre à l'attraction grâce aux propriétésde la liste
        public void SupprimerEquipe(Monstre M)
        {
            bool supprimer = false;
            for (int i = 0; i < equipe.Count() && supprimer == false; i++)
            {
                if (equipe[i].NOM == M.NOM && equipe[i].PRENOM == M.PRENOM)
                {
                    equipe.Remove(M);
                    supprimer = true;
                }
            }
        }

        //Fonction sur maintenance comprehensible dans le nom
        //On n'utilise que des affectations
        public void AjouterMaintenance(string NatureMaintenance, TimeSpan dureemaintenance)
        {
            maintenance = true;
            natureMaintenance = NatureMaintenance;
            dureeMaintenance = dureemaintenance;
        }
        public void SupprimerMaintenance()
        {
            maintenance = false;
            natureMaintenance = null;
            dureeMaintenance = new TimeSpan(0, 0, 0);
        }
        public void ModifierNatureMaintenance(string NatureMaintenance)
        {
            natureMaintenance = NatureMaintenance;
        }
        public void ModifierTotalMaintenance(string type, TimeSpan duree)
        {
            natureMaintenance = type;
            dureeMaintenance = duree;
        }
        public void ModifierDureeMaintenance(TimeSpan dureemaintenance)
        {
            dureeMaintenance = dureemaintenance;

        }
        //Renvoie si l'attraction est en maintenance ou non
        public string EstMaintenance()
        {
            string aRetourner = "";
            if (maintenance)
            {
                aRetourner = "En Maintenance, type : " + natureMaintenance + ", duree : " + dureeMaintenance.ToString();
            }
            else aRetourner = "Pas en maintenance";
            return aRetourner;
        }


        //Fonction abstact qui sera définie dans les classes filles
        abstract public string ToString();
    }
}
