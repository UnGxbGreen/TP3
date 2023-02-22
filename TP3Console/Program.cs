using Microsoft.EntityFrameworkCore;
using TP3Console.Models.EntityFramework;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TP3Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* using(var ctx = new FilmsDbContext())
             {
                 //Désactivation du tracking => Aucun changement dans la base ne sera effectué
                *//* ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;*//*

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

                 *//*//Chargement de la catégorie Action
                 Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
                 Console.WriteLine("Categorie : " + categorieAction.Nom);
                 Console.WriteLine("Films : ");
                 //Chargement des films de la catégorie Action.
                 foreach (var film in ctx.Films.Where(f => f.CategorieNavigation.Nom ==
                categorieAction.Nom).ToList())
                 {
                     Console.WriteLine(film.Nom);
                 }*/


            /*  Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
              Console.WriteLine("Categorie : " + categorieAction.Nom);
              //Chargement des films dans categorieAction
              ctx.Entry(categorieAction).Collection(c => c.Films).Load();
              Console.WriteLine("Films : ");
              foreach (var film in categorieAction.Films)
              {
                  Console.WriteLine(film.Nom);
              }*//*

              //Chargement de la catégorie Action et des films de cette catégorie
              Categorie categorieAction = ctx.Categories
              .Include(c => c.Films)
              .First(c => c.Nom == "Action");
              Console.WriteLine("Categorie : " + categorieAction.Nom);
              Console.WriteLine("Films : ");
              foreach (var film in categorieAction.Films)
              {
                  Console.WriteLine(film.Nom);
              }
          }*/

            //Exo2Q1();
            //Exo2Q2();
            //Exo2Q3();
            //Exo2Q4();
            //Exo2Q5();
            //Exo2Q6();
            //Exo2Q7();
            //Exo2Q8();
            //Exo2Q9();
            //AddUser();
            //Update();
            Delete();
            Console.ReadKey();

            
        }

        public static void Exo2Q1()
        {
            var ctx = new FilmsDbContext();
            foreach (var film in ctx.Films)
            {
                Console.WriteLine(film.ToString());
            }
        }

        public static void Exo2Q2()
        {
            var ctx = new FilmsDbContext();
            foreach (var utilisateur in ctx.Utilisateurs)
            {
                Console.WriteLine(utilisateur.ToString());
            }
        }
        public static void Exo2Q3()
        {
            var ctx = new FilmsDbContext();

            var utilisateurRequest = ctx.Utilisateurs.OrderBy(x => x.Login).ToList();
            foreach (var utilisateur in utilisateurRequest)
            {
                Console.WriteLine(utilisateur.ToString());
            }
        }
        public static void Exo2Q4()
        {
            var ctx = new FilmsDbContext();

            var filmsRequested = ctx.Films.Where(x=>x.CategorieNavigation.Nom=="Action").ToList();
            foreach (var films in filmsRequested)
            {
                Console.WriteLine(films.ToString());
            }
        }

        public static void Exo2Q5()
        {
            var ctx = new FilmsDbContext();

            var catRequested = ctx.Categories.Count();
            Console.WriteLine(catRequested);
        }

        public static void Exo2Q6()
        {
            var ctx = new FilmsDbContext();

            var noteMin = ctx.Avis.Min(x => x.Note);
            Console.WriteLine(noteMin);
        }

        public static void Exo2Q7()
        {
            var ctx = new FilmsDbContext();

            var requestedFilm = ctx.Films.Where(x => x.Nom.ToLower().StartsWith("le"));

            foreach (var films in requestedFilm)
            {
                Console.WriteLine(films.ToString());
            }
           
        }

        public static void Exo2Q8()
        {
            var ctx = new FilmsDbContext();

            var moyenneFilm = ctx.Avis.Where(x => x.FilmNavigation.Nom.ToLower().Contains("pulp fiction")).Average(x => x.Note);
            Console.WriteLine(moyenneFilm);

        }

        public static void Exo2Q9()
        {
            var ctx = new FilmsDbContext();

            var bestUser = ctx.Utilisateurs.Where(x => x.Avis.Max(c => c.Note) == ctx.Avis.Max(c => c.Note)).First();
            Console.WriteLine(bestUser?.Login);

        }

        public static void AddUser()
        {
            var ctx = new FilmsDbContext();

            var user = new Utilisateur()
            {
                Login = "Babaz",
                Email = "babaDeDonnee@gmail.com",
                Pwd="123456789"
                

            };

            ctx.Utilisateurs.Add(user);
            ctx.SaveChanges();
        }
        public static void Update()
        {

            var ctx = new FilmsDbContext();
            var filmModify = ctx.Films.Where(x => x.Nom.ToLower().Contains("l'armee des douze singes")).First();
            filmModify.Description = "JEN AI RIEN A FOUTRE DE LA DESCRIPTION";
            var catId = ctx.Categories.Where(x => x.Nom == "Drame").First().Id;
            filmModify.Categorie = catId;

            ctx.SaveChanges();
        }

        public static void Delete()
        {

            var ctx = new FilmsDbContext();
            var filmModify = ctx.Films.Where(x => x.Nom.ToLower().Contains("l'armee des douze singes")).First();
            var avisFilmSinge = ctx.Avis.Where(x=>x.FilmNavigation.Nom.ToLower().Contains("l'armee des douze singes"));

         

            ctx.RemoveRange(avisFilmSinge);
            ctx.Remove(filmModify);






            ctx.SaveChanges();
        }

    }
}