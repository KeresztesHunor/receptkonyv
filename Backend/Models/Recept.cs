using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Recept
    {
        [Key] public int Id { get; set; }
        [Required] public string Nev { get; set; }
        [Required] public int KatId { get; set; }
        [Required] public string KepEleresiUt { get; set; }
        [Required] public string Leiras { get; set; }

        [ForeignKey(nameof(KatId))] public Kategoria _KatId { get; set; }
    }
}
