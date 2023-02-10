using Microsoft.EntityFrameworkCore;
using TP3Console.Models.EntityFramework;

namespace TP3Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new FilmsDbContext())
            {
                //Désactivation du tracking => Aucun changement dans la base ne sera effectué
               /* ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;*/

                //Requête SELECT
                Film titanic = (from f in ctx.Films.AsNoTracking()
                                where f.Nom == "Titanic"
                                select f
                                ).First();


                //Modification de l'entité
                titanic.Description = "Un bateau échoué en Date : " + DateTime.Now +"RIP";


                //Sauvegarde du contexte => Application de la modification dans la BD

                int nbchnages = ctx.SaveChanges();


                Console.WriteLine("Nombres d'enregistrements modifié ou ajoutés:"+nbchnages);
            }
            Console.ReadKey();
        }
    }
}