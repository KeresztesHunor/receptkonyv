using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Kategoria
    {
        [Key] public int Id { get; set; }
        [Required] public string Nev { get; set; }

        public List<Recept> _Receptek { get; set; }
    }
}
