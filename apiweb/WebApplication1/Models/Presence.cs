using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Presence
    {
        [Key]
        public int Id { get; set; }
        public DateTime HeureDate { get; set; }

        [ForeignKey("Eleve")]

        public int EleveId { get; set; }

        public Eleve Eleve { get; set; }
    }
}
