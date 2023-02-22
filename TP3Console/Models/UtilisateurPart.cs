using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Console.Models.EntityFramework
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {

        }
        public Utilisateur(int id, string login, string email, string pwd, ICollection<Avi> avis)
        {
            Id = id;
            Login = login;
            Email = email;
            Pwd = pwd;
            Avis = avis;
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
            return $"{this.Id}:{this.Email}";
        }
    }
}
