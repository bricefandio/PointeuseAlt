using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Eleve
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        [ForeignKey("Promotion")]
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }

        [ForeignKey("Groupe")]
        public int GroupeId { get; set; }
        public Groupe Groupe { get; set; }

    }
}
