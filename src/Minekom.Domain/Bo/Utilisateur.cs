namespace Minekom.Domain.Bo
{
    public class Utilisateur : IBOEntity
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateOnly DateDeNaissance { get; set; }

        public string Email { get; set; }

        public string MotDePasse { get; set; }

        public string Telephone { get; set; }

    }
}
