using System;
using System.Collections.Generic;
using System.Linq;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public Dictionary<int, List<Note>> notesParMatiere { get; private set; }
        private bool aAfficheLimite = false;
        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            notesParMatiere = new Dictionary<int, List<Note>>();
        }

        public void ajouterNote(Note note)
        {
            int totalNotes = notesParMatiere.Values.Sum(liste => liste.Count);
            if (totalNotes >= 200)
            {
                if (!aAfficheLimite)
                {
                    Console.WriteLine($"Limite atteinte : {prenom} {nom} ne peut pas recevoir plus de 200 notes !");
                    aAfficheLimite = true; // Marque que l'élève a atteint la limite
                }
                return;
            }

            if (!notesParMatiere.ContainsKey(note.matiere))
                notesParMatiere[note.matiere] = new List<Note>();

            notesParMatiere[note.matiere].Add(note);
        }
        public float moyenneMatiere(int matiere)
        {
            if (!notesParMatiere.ContainsKey(matiere) || notesParMatiere[matiere].Count == 0)
                return 0;
            float moyenne = notesParMatiere[matiere].Average(n => n.note);
            return (float)Math.Truncate(moyenne * 100) / 100; // Tronquer à 2 chiffres après la virgule
        }
        public float moyenneGeneral()
        {
            if (notesParMatiere.Count == 0)
                return 0;
            float moyenne = notesParMatiere.Values.Average(notes => notes.Average(n => n.note));
            return (float)Math.Truncate(moyenne * 100) / 100;
        }
    }
}
