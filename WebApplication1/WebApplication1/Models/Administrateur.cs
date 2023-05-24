namespace WebApplication1.Models
{
    public class Administrateur

    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Administrateur() 
        {
        }
    }
}
