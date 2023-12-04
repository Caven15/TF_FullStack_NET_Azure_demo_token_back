using Demo.BLL.Interfaces;
using Demo.BLL.Mapper;
using Demo.BLL.Models;
using Demo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _utilisateurRepository;

        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        public UtilisateurModel LoginUtilisateur(string email, string password)
        {
            return _utilisateurRepository.LoginUtilisateur(email, password)?.DalToBll();
        }

        public void RegisterUtilisateur(UtilisateurModel model)
        {
            _utilisateurRepository.RegisterUtilisateur(model.BllToDal());
        }
    }
}
