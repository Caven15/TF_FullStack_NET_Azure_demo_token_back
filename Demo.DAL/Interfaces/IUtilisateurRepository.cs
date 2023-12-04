using Demo.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Interfaces
{
    public interface IUtilisateurRepository
    {
        void RegisterUtilisateur(UtilisateurData data);

        UtilisateurData LoginUtilisateur(string email, string password);
    }
}
