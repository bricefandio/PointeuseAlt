using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Groupe
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; }

    }
}
