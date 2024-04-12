using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class ReceptDTO
    {
        public int Id { get; set; }
        [Required] public string Nev { get; set; }
        [Required] public int KatId { get; set; }
        [Required] public string KepEleresiUt { get; set; }
        [Required] public string Leiras { get; set; }
    }
}
