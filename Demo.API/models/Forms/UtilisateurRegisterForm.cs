namespace Demo.API.models.Forms
{
    public class UtilisateurRegisterForm
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
