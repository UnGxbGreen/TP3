using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Console.Models.EntityFramework
{
    public partial class Avi
    {
        public Avi()
        {

        }
        public Avi(int film, int utilisateur, string? avis, decimal note, Film filmNavigation, Utilisateur utilisateurNavigation)
        {
            Film = film;
            Utilisateur = utilisateur;
            Avis = avis;
            Note = note;
            FilmNavigation = filmNavigation;
            UtilisateurNavigation = utilisateurNavigation;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return this.Film + " : " + this.Avis;
        }
    }
}
