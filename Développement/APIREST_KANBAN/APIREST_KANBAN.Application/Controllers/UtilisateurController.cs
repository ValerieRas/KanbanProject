using Kaban.Business.DTO.UtilisateurDTO;
using Kaban.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIREST_KANBAN.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurService _UtilisateurService;
        public UtilisateurController(IUtilisateurService UtilisateurService)
        {
            _UtilisateurService = UtilisateurService;
        }

        /// <summary>
        /// Renvoie la liste de Utilisateur récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<LireUtilisateurDTO>), 200)]
        public async Task<ActionResult> AfficherUtilisateurAsync()
        {
            var UtilisateurDTO = await _UtilisateurService.AfficherUtilisateurAsync().ConfigureAwait(false);
        
            return Ok(UtilisateurDTO);
        }

        /// <summary>
        /// Renvoie la liste de Utilisateur par projet récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet("{idProjet}")]
        [ProducesResponseType(typeof(List<LireUtilisateurDTO>), 200)]
        public async Task<ActionResult> AfficherUtilisateurAvecIdProjetAsync([FromRoute] int idProjet)
        {
            var UtilisateurDTO = await _UtilisateurService.AfficherUtilisateurAvecIdProjetAsync(idProjet).ConfigureAwait(false);

            return Ok(UtilisateurDTO);
        }


        /// <summary>
        /// Insertion d'un nouveau Utilisateur dans la BDD
        /// </summary>
        /// <param name="UtilisateurDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreerUtilisateurAsync([FromBody] CreerUtilisateurDTO UtilisateurDTO)
        {
            if (string.IsNullOrEmpty(UtilisateurDTO?.Nom) || string.IsNullOrEmpty(UtilisateurDTO?.Prenom))
            {
                return BadRequest(
                    new { Error = "Veuillez remplir tous les champs" });
            }
            try
            {
                var UtilisateurAjoute = await _UtilisateurService.CreerUtilisateurAsync(UtilisateurDTO).ConfigureAwait(false);
         
                return Ok(UtilisateurAjoute);
            }
            catch (Exception)
            {
                return BadRequest(
                   new { Error = "Une erreur s'est produite lors de la création du Utilisateur" });
            }

        }

        /// <summary>
        /// Suppression d'un Utilisateur dans la table Utilisateur 
        /// </summary>
        /// <param name="IdUtilisateur">identifiant du Utilisateur à supprimer</param>
        /// <returns></returns>
        [HttpDelete("{IdUtilisateur}")]
        public async Task<ActionResult> SupprimerUtilisateurAsync(int IdUtilisateur)
        {
            try
            {
                LireUtilisateurDTO UtilisateurSuppr = await _UtilisateurService.SupprimerUtilisateurAsync(IdUtilisateur).ConfigureAwait(false);
        
                return Ok(UtilisateurSuppr);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message,
                });
            }
        }

        /// <summary>
        /// Permet de modifer les information du Utilisateur 
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <param name="UtilisateurDTO"></param>
        /// <returns></returns>
        [HttpPut("{idUtilisateur}")]
        [ProducesResponseType(typeof(ModifierUtilisateurDTO), 200)]
        public async Task<ActionResult> ModifierUtilisateurAsync(int idUtilisateur, [FromBody] ModifierUtilisateurDTO UtilisateurDTO)
        {
            if (string.IsNullOrEmpty(UtilisateurDTO?.Nom) || string.IsNullOrEmpty(UtilisateurDTO?.Prenom))
            {
                return BadRequest(new { Error = "Veuillez remplir tous les champs" });
            }

            try
            {
                var UtilisateurModif = await _UtilisateurService.ModifierUtilisateurAsync(idUtilisateur, UtilisateurDTO).ConfigureAwait(false);
           

                return Ok(UtilisateurModif);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message,
                });
            }

        }
    }
}
