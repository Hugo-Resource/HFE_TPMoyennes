using System;
using System.Collections.Generic;
using System.Linq;

namespace HNI_TPmoyennes
{
    class Classe
    {
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }
        public Classe(string nom)
        {
            nomClasse = nom;
            eleves = new List<Eleve>();
            matieres = new List<string>();
        }
        public void ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count < 30) // Max 30 élèves
                eleves.Add(new Eleve(prenom, nom));
        }

        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count < 10) // Max 10 matières
                matieres.Add(matiere);
        }
        public float moyenneMatiere(int matiereIndex)
        {
            if (eleves.Count == 0 || matiereIndex >= matieres.Count)
                return 0;
            float moyenne = eleves.Average(eleve => eleve.moyenneMatiere(matiereIndex));
            return (float)Math.Truncate(moyenne * 100) / 100;
        }
        public float moyenneGeneral()
        {
            if (eleves.Count == 0)
                return 0;
            float moyenne = eleves.Average(eleve => eleve.moyenneGeneral());
            return (float)Math.Truncate(moyenne * 100) / 100;
        }
    }
}
