using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Console.Models.EntityFramework
{
    public partial class Film
    {
        public Film()
        {

        }
        public Film(int id, string nom, string? description, int categorie, ICollection<Avi> avis, Categorie categorieNavigation)
        {
            Id = id;
            Nom = nom;
            Description = description;
            Categorie = categorie;
            Avis = avis;
            CategorieNavigation = categorieNavigation;
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
            return $"{this.Id}:{this.Nom}";
        }
    }
}
