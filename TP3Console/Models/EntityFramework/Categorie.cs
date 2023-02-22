using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TP3Console.Models.EntityFramework;

[Table("categorie")]
public partial class Categorie
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nom")]
    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    /*[InverseProperty("CategorieNavigation")]
    public virtual ICollection<Film> Films { get; } = new List<Film>();
*/
    private ICollection<Film> films; //Doit être écrit de la même façon que la property Films mais en minuscule
    [InverseProperty("CategorieNavigation")]
    public virtual ICollection<Film> Films
    {
        get
        {
            return _lazyLoader.Load(this, ref films);
        }
        set { films = value; }
    }

    private ILazyLoader _lazyLoader;
    public Categorie(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }
}
