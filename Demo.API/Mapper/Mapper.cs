using Demo.API.models.Dto;
using Demo.API.models.Forms;
using Demo.BLL.Models;
using Demo.DAL.Data;

namespace Demo.API.Mapper
{
    public static class Mapper
    {
        internal static UtilisateurModel ApiToBll(this UtilisateurRegisterForm form)
        {
            return new UtilisateurModel()
            {
                Nom = form.Nom,
                Prenom = form.Prenom,
                Email = form.Email,
                DateNaissance = form.DateNaissance,
                Password = form.Password,
            };
        }

        internal static UtilisateurModel ApiToBll(this UtilisateurDto dto)
        {
            return new UtilisateurModel()
            {
                Id = dto.Id,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                DateNaissance = dto.DateNaissance,
                Password = dto.Password,
                IsAdmin = dto.IsAdmin,
            };
        }

        internal static UtilisateurDto BllToApi(this UtilisateurModel model)
        {
            if (model is null)
            {
                return null;
            }
            return new UtilisateurDto()
            {
                Id = model.Id,
                Nom = model.Nom,
                Prenom = model.Prenom,
                Email = model.Email,
                DateNaissance = model.DateNaissance,
                Password = model.Password,
                IsAdmin = model.IsAdmin,
            };
        }
    }
}
