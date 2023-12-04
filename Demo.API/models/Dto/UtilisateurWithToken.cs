namespace Demo.API.models.Dto
{
    public class UtilisateurWithToken
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
