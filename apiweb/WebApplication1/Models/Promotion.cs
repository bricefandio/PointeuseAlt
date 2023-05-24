using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public int Annee { get; set; }
    }
}
