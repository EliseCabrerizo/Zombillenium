using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; //a ajouter
using System.Collections; //A ajouter

namespace Zombillenium
{

   public class Parc
    {
        private List<Personnel> toutLePersonnel = new List<Personnel>();
        private List<Attraction> attractions = new List<Attraction>();

        public Parc(List<Personnel> toutLePersonnel, List<Attraction> attractions)
        {
            this.attractions = attractions;
            this.toutLePersonnel = toutLePersonnel;
        }
        public Parc()
        {
        }

        //Accesseurs dont on a besoin
        public List<Attraction> Attractions { get { return attractions; } }
        public List<Personnel> Personnels { get { return toutLePersonnel; } }

        //Permet d'ajouter ou supprimer des attractions/personnels grace aux propriétés de la liste
        public void AjouterPersonnel(Personnel P)
        {
            if (TrouverPersonnel(P.NOM, P.PRENOM) == "")
            {
                toutLePersonnel.Add(P);
                if(P is Monstre)
                    GererCagnotte(P as Monstre);
            }
        }
        public void SupprimerPersonnel(Personnel P)
        {
            toutLePersonnel.Remove(P);
        }
        public void SupprimerPersonnelNom(string nomP, string prenommP)
        {
            for (int i = 0; i < toutLePersonnel.Count; i++)
            {
                if (toutLePersonnel[i].NOM == nomP&& toutLePersonnel[i].PRENOM == prenommP)
                    SupprimerPersonnel(toutLePersonnel[i]);
            }
        }
        public void AjouterAttraction(Attraction A)
        {
            if (TrouverAttraction(A.Nom) == "")
                attractions.Add(A);
        }
        public void SupprimerAttraction(Attraction A)
        {
            attractions.Remove(A);
        }
        public void SupprimerAttractionNom(string nomA, int identifiant)
        {
            for(int i=0; i<attractions.Count;i++)
            {
                if (attractions[i].Nom == nomA && attractions[i].Identifiant == identifiant)
                    SupprimerAttraction(attractions[i]);
            }
        }
        //Permet de trouver une attraction/Personnel en particulier
        public string TrouverAttraction(string nom)
        {
            string str = "";
            bool trouver = false;
            for (int i = 0; i < attractions.Count() && !trouver; i++)
            {
                if (attractions[i].Nom == nom)
                {
                    str = attractions[i].ToString() + "\n";
                    trouver = true;
                }
            }
            return str;
        }
        public string TrouverPersonnel(string nom, string prenom)
        {
            string str = "";
            bool trouver = false;
            for (int i = 0; i < toutLePersonnel.Count() && !trouver; i++)
            {
                if (toutLePersonnel[i].NOM == nom && toutLePersonnel[i].PRENOM == prenom)
                {
                    str = toutLePersonnel[i].ToString() + "\n";
                    trouver = true;
                }
            }
            return str;
        }
        //Lis un fichier puis convertis les données ou les attractions selon le document données par Mme.Branchet et les types
        public void LectureFichier(string nomFichier)
        {
            StreamReader monStreamReader = new StreamReader(nomFichier);
            string ligne = monStreamReader.ReadLine();

            while (ligne != null)
            {

                string[] temp = ligne.Split(';');

                if (temp[0] == "Sorcier")
                {
                    List<string> listeTemp = new List<string>();
                    listeTemp.Add(temp[7]);
                    Sorcier S = new Sorcier(Convert.ToInt32(temp[1]), temp[2], temp[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), temp[4]), temp[5], (Grade)Enum.Parse(typeof(Grade), temp[6]), listeTemp);
                    toutLePersonnel.Add(S);
                }
                else if (temp[0] == "Monstre")
                {
                    Monstre M = new Monstre(Convert.ToInt32(temp[1]), temp[2], temp[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), temp[4]), temp[5], temp[7], Convert.ToInt32(temp[6]));
                    toutLePersonnel.Add(M);
                }
                else if (temp[0] == "Vampire")
                {
                    Vampire V = new Vampire(Convert.ToInt32(temp[1]), temp[2], temp[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), temp[4]), temp[5], Convert.ToInt32(temp[6]), temp[7], Convert.ToDouble(temp[8]));
                    toutLePersonnel.Add(V);
                }
                else if (temp[0] == "Zombie")
                {
                    Zombie Z = new Zombie(Convert.ToInt32(temp[1]), temp[2], temp[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), temp[4]), temp[5], Convert.ToInt32(temp[6]), temp[7], Convert.ToInt32(temp[9]), (CouleurZ)Enum.Parse(typeof(CouleurZ), temp[8]));
                    toutLePersonnel.Add(Z);
                }
                else if (temp[0] == "Demon")
                {
                    Demon D = new Demon(Convert.ToInt32(temp[1]), temp[2], temp[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), temp[4]), temp[5], Convert.ToInt32(temp[6]), temp[7], Convert.ToInt32(temp[8]));
                    toutLePersonnel.Add(D);
                }
                else if (temp[0] == "Fantome")
                {
                    Fantome F = new Fantome(Convert.ToInt32(temp[1]), temp[2], temp[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), temp[4]), temp[5], Convert.ToInt32(temp[6]), temp[7]);
                    toutLePersonnel.Add(F);
                }
                else if (temp[0] == "LoupGarou")
                {
                    LoupGarou LG = new LoupGarou(Convert.ToInt32(temp[1]), temp[2], temp[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), temp[4]), temp[5], Convert.ToInt32(temp[6]), temp[7], Convert.ToDouble(temp[8]));
                    toutLePersonnel.Add(LG);
                }
                else if (temp[0] == "RollerCoaster")
                {
                    RollerCoaster RC = new RollerCoaster(Convert.ToBoolean(temp[4]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[3]), temp[2], temp[5], Convert.ToInt32(temp[7]), (TypeCategorie)Enum.Parse(typeof(TypeCategorie), temp[6]), Convert.ToDouble(temp[8]));
                    attractions.Add(RC);
                }
                else if (temp[0] == "Spectacle")
                {
                    List<DateTime> listeTemp = new List<DateTime>();
                    string[] temp2 = temp[8].Split(' ');
                    for (int k = 0; k < temp2.Length; k++)
                        listeTemp.Add(Convert.ToDateTime(temp2[k]));
                    Spectacle Sp = new Spectacle(Convert.ToBoolean(temp[4]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[3]), temp[2], temp[5], listeTemp, Convert.ToInt32(temp[7]), temp[6]);
                    attractions.Add(Sp);
                }
                else if (temp[0] == "DarkRide")
                {
                    DarkRide Dr = new DarkRide(Convert.ToBoolean(temp[4]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[3]), temp[2], temp[5], TimeSpan.Parse(temp[6]), Convert.ToBoolean(temp[7]));
                    attractions.Add(Dr);
                }
                else if (temp[0] == "Boutique")
                {
                    Boutique B = new Boutique(Convert.ToBoolean(temp[4]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[3]), temp[2], temp[5], (TypeBoutique)Enum.Parse(typeof(TypeBoutique), temp[6]));
                    AjouterAttraction((Attraction)B);
                }

                ligne = monStreamReader.ReadLine();
            }
            monStreamReader.Close();
            //Une fois que tout est créé on ajoute dans les attractions le personnel correspondant
            for (int i = 0; i < toutLePersonnel.Count(); i++)
            {
                for (int j = 0; j < attractions.Count(); j++)
                {
                    if (toutLePersonnel[i] is Monstre)
                    {
                        if ((toutLePersonnel[i] as Monstre).AFFECTATION == Convert.ToString(attractions[j].Identifiant))
                            attractions[j].AjouterEquipe(toutLePersonnel[i] as Monstre);

                    }
                }

            }
        }

        //Permet de rechercher les attractions qui sont libres
        public Attraction RechercherAttraction()
        {
            Attraction aRetourner = null;
            //Recherche d'abord les attractions qui n'ont pas assez de personnel
            for (int i = 0; i < attractions.Count() && aRetourner == null; i++)
            {
                if (attractions[i].NombreMinMonstre > attractions[i].Equipe.Count())
                    aRetourner = attractions[i];
            }
            //Puis s'il n'y en a aucune celles qui ont le moins de personnes
            if (aRetourner == null)
            {
                int index = 0;
                int ecartMin = (attractions[0].Equipe.Count() - attractions[0].NombreMinMonstre);
                for (int i = 0; i < attractions.Count(); i++)
                {
                    if ((attractions[i].Equipe.Count() - attractions[i].NombreMinMonstre) < ecartMin)
                    {
                        ecartMin = (attractions[i].Equipe.Count() - attractions[i].NombreMinMonstre);
                        index = i;
                    }
                }
                aRetourner = attractions[index];
            }
            return aRetourner;
        }

        //Fonction qu'on appelle lorsque de l'ajout/suppression de points est fait
        //Elle vérifie que le monstre a la bonne affectation
        public void GererCagnotte(Monstre M)
        {
            if (M.CAGNOTTE < 50)
            {
                bool rechercher = false;
                for (int j = 0; j < attractions.Count() && rechercher == false; j++)
                {
                    if (attractions[j] is Boutique && (attractions[j] as Boutique).Type.ToString() == "barbeAPapa")
                    {
                        M.ChangerAffectation(attractions[j].Nom);
                        attractions[j].AjouterEquipe(M);
                        rechercher = true;
                    }
                }

            }
            if (M.CAGNOTTE > 500 && M.AFFECTATION != "parc" && M.AFFECTATION != "neant")
            {
                bool rechercher = false;

                for (int j = 0; j < attractions.Count() && rechercher == false; j++)
                {
                    if (attractions[j].Nom == M.AFFECTATION)
                    {
                        if (attractions[j].NombreMinMonstre < attractions[j].Equipe.Count())
                        {
                            M.ChangerAffectation("parc");
                            attractions[j].SupprimerEquipe(M);
                        }
                        rechercher = true;
                    }
                }
            }
            if (M.CAGNOTTE < 500 && M.CAGNOTTE > 50 && M.AFFECTATION == "parc" || M.CAGNOTTE < 500 && M.CAGNOTTE > 50 && M.AFFECTATION == "")
            {
                Attraction temp = RechercherAttraction();
                M.ChangerAffectation(temp.Nom);

                bool rechercher = false;
                for (int j = 0; j < attractions.Count() && rechercher == false; j++)
                {
                    if (attractions[j].Nom == temp.Nom)
                    {
                        attractions[j].AjouterEquipe(M);
                        rechercher = true;
                    }
                }
            }
        }
        //Deux prochaines fonctions utilisées par Rose seulement
        public void AjouterCagnotte(Monstre M, int nbPoint)
        {
            M.AjouterPoint(nbPoint);
            GererCagnotte(M);
        }

        public void SupprimerCagnotte(Monstre M, int nbPoint)
        {
            M.SupprimerPoint(nbPoint);
            GererCagnotte(M);
        }
        //Différents type de tri selon les caractériques voulues
        //On utilise des delegates
        //Ce n'est que des exemples il faudra demander au client ce qu'il souhaite
        public void trierPersonnelParMatricule()
        {
            toutLePersonnel.Sort(delegate (Personnel X, Personnel Y)
            { return X.MATRICULE.CompareTo(Y.MATRICULE); });
        }
        public void trierPersonnelParNom()
        {
            toutLePersonnel.Sort();
        }

        public void AfficherClassement()
        {
            List<Monstre> listMonstre = new List<Monstre>();
            for (int i = 0; i < toutLePersonnel.Count; i++)
            {
                if (toutLePersonnel[i] is Monstre)
                {
                    Monstre M = (Monstre)toutLePersonnel[i];
                    listMonstre.Add(M);
                }
            }
            listMonstre.Sort(delegate (Monstre X, Monstre Y)
            { return X.CAGNOTTE.CompareTo(Y.CAGNOTTE); });
            for (int i = 0; i < listMonstre.Count; i++)
            {

                Console.WriteLine(listMonstre[i].NOM + " " + listMonstre[i].PRENOM + " " + listMonstre[i].CAGNOTTE);

            }
        }
        public List<Demon> trierDemonParForce()
        {
            List<Demon> listDemon = new List<Demon>();
            for (int i = 0; i < toutLePersonnel.Count; i++)
            {
                if (toutLePersonnel[i] is Demon)
                {
                    Demon D = (Demon)toutLePersonnel[i];
                    listDemon.Add(D);
                }
            }
            listDemon.Sort(delegate (Demon X, Demon Y)
            { return X.FORCE.CompareTo(Y.FORCE); });
            return listDemon;
        }
        public List<LoupGarou> trierLoupParCruaute()
        { 
            List<LoupGarou> listLG = new List<LoupGarou>();
            for (int i = 0; i < toutLePersonnel.Count; i++)
            {
                if (toutLePersonnel[i] is LoupGarou)
                {
                    LoupGarou LG = (LoupGarou)toutLePersonnel[i];
                    listLG.Add(LG);
                }
            }
            listLG.Sort(delegate (LoupGarou X, LoupGarou Y)
            { return X.CRUAUTE.CompareTo(Y.CRUAUTE); });
            return listLG;
        }
        public List<Vampire> trierVampParIndLum()
        {
            List<Vampire> listv = new List<Vampire>();
            for (int i = 0; i < toutLePersonnel.Count; i++)
            {
                if (toutLePersonnel[i] is Vampire)
                {
                    Vampire V = (Vampire)toutLePersonnel[i];
                    listv.Add(V);
                }
            }

            listv.Sort(delegate (Vampire X, Vampire Y)
            { return X.INDICELUMINOSITE.CompareTo(Y.INDICELUMINOSITE); });
            return listv;
        }
        public List<Zombie> trierZombie()
        {
            List<Zombie> ListeZ = new List<Zombie>();
            for (int i = 0; i < toutLePersonnel.Count; i++)
            {
                if (toutLePersonnel[i] is Zombie)
                {
                    Zombie Z = (Zombie)toutLePersonnel[i];
                    ListeZ.Add(Z);
                }
            }
            ListeZ.Sort(delegate (Zombie X, Zombie Y)
            { return X.DEGREDECOMPOSITION.CompareTo(Y.DEGREDECOMPOSITION); });
            ListeZ.Sort(delegate (Zombie X, Zombie Y)
            { return X.TEINT.CompareTo(Y.TEINT); });
            return ListeZ;

        }
        public List<Sorcier> trierSorcier()
        {
            List<Sorcier> ListeS = new List<Sorcier>();
            for (int i = 0; i < toutLePersonnel.Count; i++)
            {
                if (toutLePersonnel[i] is Sorcier)
                {
                    Sorcier S = (Sorcier)toutLePersonnel[i];
                    ListeS.Add(S);
                }
            }
            ListeS.Sort(delegate (Sorcier X, Sorcier Y)
            { return X.GRADE.CompareTo(Y.GRADE); });
            return ListeS;


        }
        //Tri tout le personnel dans la grande liste (regroupe les genres puis tri entre eux)
        public void TrierPersonnel()
        {

            List<Personnel> listetemp = new List<Personnel>();
            //Créer une nouvelle liste tri puis l'ajoute à une liste temporaire (Pour chaque)
            List<Demon> listDemon = trierDemonParForce();
            for (int i = 0; i < listDemon.Count; i++)
                listetemp.Add(listDemon[i]);

            List<LoupGarou> listLG = trierLoupParCruaute();
            for (int i = 0; i < listLG.Count; i++)
                listetemp.Add(listLG[i]);

            List<Vampire> listv = trierVampParIndLum();
            for (int i = 0; i < listv.Count; i++)
                listetemp.Add(listv[i]);

            List<Zombie> ListeZ = trierZombie();
            for (int i = 0; i < ListeZ.Count; i++)
                listetemp.Add(ListeZ[i]);

            List<Fantome> ListeF = new List<Fantome>();
            for (int i = 0; i < toutLePersonnel.Count; i++)
            {
                if (toutLePersonnel[i] is Fantome)
                {
                    Fantome F = (Fantome)toutLePersonnel[i];
                    ListeF.Add(F);
                }
            }
            ListeF.Sort();

            for (int i = 0; i < ListeF.Count; i++)
                listetemp.Add(ListeF[i]);

            List<Sorcier> ListeS = trierSorcier();
            for (int i = 0; i < ListeS.Count; i++)
                listetemp.Add(ListeS[i]);

            //Liste temporaire et finalement la liste finale
            toutLePersonnel = listetemp;

        }

        //Permet d'écrire en console ou dans un fichier selon certaines conditions
        //Il faudra demander aux clients pour améliorer ce qu'il veut afficher
        public void Ecriture(bool fichier, string nomFichier, string triSur, string condition)
        {
            //Ecriture dans fichier
            if (fichier == true)
            {
                StreamWriter fichEcr = new StreamWriter(nomFichier, true);
                string str = "";
                //On vérifie si ça concerne une attraction
                if (triSur.ToUpper() == "ATTRACTION")
                {
                    //Puis on vérifie la condition
                    //Des conditions pourront être rajoutées selon les envies du client
                    if (condition == "")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            str = attractions[i].Nom;
                            fichEcr.WriteLine(str);
                        }
                    }
                    if (condition.ToUpper() == "MAINTENANCE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].Maintenance)
                            {
                                str = attractions[i].Nom;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "OUVERT")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].Ouvert)
                            {
                                str = attractions[i].Nom;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "BESOIN SPECIFIQUE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].BesoinSpecifique)
                            {
                                str = attractions[i].Nom;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "NOMBRE MIN ATTEINT")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].Equipe.Count() >= attractions[i].NombreMinMonstre)
                            {
                                str = attractions[i].Nom;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "NOMBRE MIN PAS ATTEINT")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].Equipe.Count() < attractions[i].NombreMinMonstre)
                            {
                                str = attractions[i].Nom;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                }
                //On vérifie si ça concerne une personnel
                else
                {
                    //Puis on vérifie la condition
                    //Des conditions pourront être rajoutées selon les envies du client
                    if (condition == "")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                            fichEcr.WriteLine(str);
                        }
                    }
                    if (condition.ToUpper() == "SORCIER")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Sorcier)
                            {
                                str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "VAMPIRE")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Vampire)
                            {
                                str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "DEMON")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Demon)
                            {
                                str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "LOUPGAROU")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is LoupGarou)
                            {
                                str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "FANTOME")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Fantome)
                            {
                                str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "ZOMBIE")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Zombie)
                            {
                                str = toutLePersonnel[i].NOM + " " + toutLePersonnel[i].PRENOM;
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "FEMELLE")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i].SEXE == (TypeSexe)Enum.Parse(typeof(TypeSexe), "femelle"))
                            {
                                str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "MALE")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i].SEXE == (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"))
                            {
                                str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "DIRECTION")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i].FONCTION.Contains("d"))
                            {
                                str = toutLePersonnel[i].NOM + ";" + toutLePersonnel[i].PRENOM;
                                fichEcr.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "ROLLER COASTER")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i] is RollerCoaster)
                            {
                                for (int j = 0; j < attractions[i].Equipe.Count(); j++)
                                {
                                    str = attractions[i].Equipe[j].NOM + ";" + attractions[i].Equipe[j].PRENOM;
                                    fichEcr.WriteLine(str);
                                }

                            }
                        }
                    }
                    if (condition.ToUpper() == "BOUTIQUE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i] is Boutique)
                            {
                                for (int j = 0; j < attractions[i].Equipe.Count(); j++)
                                {
                                    str = attractions[i].Equipe[j].NOM + ";" + attractions[i].Equipe[j].PRENOM;
                                    fichEcr.WriteLine(str);
                                }

                            }
                        }
                    }
                    if (condition.ToUpper() == "DARK RIDE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i] is DarkRide)
                            {
                                for (int j = 0; j < attractions[i].Equipe.Count(); j++)
                                {
                                    str = attractions[i].Equipe[j].NOM + ";" + attractions[i].Equipe[j].PRENOM;
                                    fichEcr.WriteLine(str);
                                }

                            }
                        }
                    }
                    if (condition.ToUpper() == "SPECTACLE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i] is Spectacle)
                            {
                                for (int j = 0; j < attractions[i].Equipe.Count(); j++)
                                {
                                    str = attractions[i].Equipe[j].NOM + ";" + attractions[i].Equipe[j].PRENOM;
                                    fichEcr.WriteLine(str);
                                }

                            }
                        }
                    }
                }
                fichEcr.Close();
            }

            //Ecriture en console
            //On fait exactement pareil qu'avant sauf en console
            else
            {
                string str = "";
                if (triSur.ToUpper() == "ATTRACTION")
                {
                    if (condition == "")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            str = attractions[i].ToString();
                            Console.WriteLine(str);
                        }
                    }
                    if (condition.ToUpper() == "MAINTENANCE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].Maintenance)
                            {
                                str = attractions[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "OUVERT")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].Ouvert)
                            {
                                str = attractions[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "BESOIN SPECIFIQUE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].BesoinSpecifique)
                            {
                                str = attractions[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "NOMBRE MIN ATTEINT")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].Equipe.Count() >= attractions[i].NombreMinMonstre)
                            {
                                str = attractions[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "NOMBRE MIN PAS ATTEINT")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i].Equipe.Count() < attractions[i].NombreMinMonstre)
                            {
                                str = attractions[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }


                }
                else
                {
                    if (condition == "")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            str = toutLePersonnel[i].ToString();
                            Console.WriteLine(str);
                        }
                    }
                    if (condition.ToUpper() == "SORCIER")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Sorcier)
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "VAMPIRE")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Vampire)
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "DEMON")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Demon)
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "LOUPGAROU")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is LoupGarou)
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "FANTOME")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Fantome)
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "ZOMBIE")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i] is Zombie)
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "FEMELLE")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i].SEXE == (TypeSexe)Enum.Parse(typeof(TypeSexe), "femelle"))
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "MALE")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i].SEXE == (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"))
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "DIRECTION")
                    {
                        for (int i = 0; i < toutLePersonnel.Count(); i++)
                        {
                            if (toutLePersonnel[i].FONCTION.Contains("d"))
                            {
                                str = toutLePersonnel[i].ToString();
                                Console.WriteLine(str);
                            }
                        }
                    }
                    if (condition.ToUpper() == "ROLLER COASTER")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i] is RollerCoaster)
                            {
                                for (int j = 0; j < attractions[i].Equipe.Count(); j++)
                                {
                                    str = attractions[i].Equipe[j].ToString();
                                    Console.WriteLine(str);
                                }

                            }
                        }
                    }
                    if (condition.ToUpper() == "BOUTIQUE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i] is Boutique)
                            {
                                for (int j = 0; j < attractions[i].Equipe.Count(); j++)
                                {
                                    str = attractions[i].Equipe[j].ToString();
                                    Console.WriteLine(str);
                                }

                            }
                        }
                    }
                    if (condition.ToUpper() == "DARK RIDE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i] is DarkRide)
                            {
                                for (int j = 0; j < attractions[i].Equipe.Count(); j++)
                                {
                                    str = attractions[i].Equipe[j].ToString();
                                    Console.WriteLine(str);
                                }

                            }
                        }
                    }
                    if (condition.ToUpper() == "SPECTACLE")
                    {
                        for (int i = 0; i < attractions.Count(); i++)
                        {
                            if (attractions[i] is Spectacle)
                            {
                                for (int j = 0; j < attractions[i].Equipe.Count(); j++)
                                {
                                    str = attractions[i].Equipe[j].ToString();
                                    Console.WriteLine(str);
                                }

                            }
                        }
                    }
                }
            }
        }

    }
}
