using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class KategoriaDTO
    {
        public int Id { get; set; }
        [Required] public string Nev { get; set; }
    }
}
