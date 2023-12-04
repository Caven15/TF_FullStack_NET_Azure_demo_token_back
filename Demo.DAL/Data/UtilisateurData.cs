using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data
{
    public class UtilisateurData
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
