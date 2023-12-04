namespace Demo.API.models.Dto
{
    public class UtilisateurDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
