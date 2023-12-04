using Demo.API.Infrastructure;
using Demo.API.Mapper;
using Demo.API.models.Dto;
using Demo.API.models.Forms;
using Demo.BLL.Interfaces;
using Demo.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;
        private readonly TokenManager _tokenManager;

        public AuthController(IUtilisateurService utilisateurService, TokenManager tokenManager)
        {
            _utilisateurService = utilisateurService;
            _tokenManager = tokenManager;
        }

        [HttpPost(nameof(Register))]
        public IActionResult Register(UtilisateurRegisterForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _utilisateurService.RegisterUtilisateur(form.ApiToBll());
            return Ok();
        }

        [HttpPost(nameof(Login))]
        public IActionResult Login(UtilisateurLoginForm form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UtilisateurModel currentUser = _utilisateurService.LoginUtilisateur(form.Email, form.Password);

                if (currentUser is null)
                {
                    return NotFound("L'utilisateur n'existe pas...");
                }

                string nom = currentUser.Nom is null ? string.Empty : currentUser.Nom;
                string prenom = currentUser.Prenom is null ? string.Empty : currentUser.Prenom;
                string email = currentUser.Email is null ? string.Empty : currentUser.Email;
                UtilisateurWithToken user = new UtilisateurWithToken()
                {
                    Id = currentUser.Id,
                    Nom = currentUser.Nom,
                    Prenom = currentUser.Prenom,
                    Email = currentUser.Email,
                    DateNaissance = currentUser.DateNaissance,
                    Token = _tokenManager.GenerateJwt(currentUser)
                };

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
