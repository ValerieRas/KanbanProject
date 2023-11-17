using Kaban.Business.DTO.ProjetDTO;
using Kaban.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIREST_KANBAN.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetController : ControllerBase
    {
        private readonly IProjetService _ProjetService;
        public ProjetController(IProjetService ProjetService)
        {
            _ProjetService = ProjetService;
        }

        /// <summary>
        /// Renvoie la liste de Projet récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet("Utilisateur/{IdUtilisateur}")]
        [ProducesResponseType(typeof(List<LireProjetDTO>), 200)]
        public async Task<ActionResult> AfficherProjetAvecIdUtilisateurAsync([FromRoute] int IdUtilisateur)
        {
            var ProjetDTO = await _ProjetService.AfficherProjetAvecIdUtilisateurAsync(IdUtilisateur).ConfigureAwait(false);
    

            return Ok(ProjetDTO);
        }

        /// <summary>
        /// Renvoie la liste de Projet par projet récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet("{idProjet}")]
        [ProducesResponseType(typeof(LireProjetDTO), 200)]
        public async Task<ActionResult> AfficherProjetAvecIdProjetAsync([FromRoute] int idProjet)
        {
            var ProjetDTO = await _ProjetService.AfficherProjetAvecIdProjetAsync(idProjet).ConfigureAwait(false);
         

            return Ok(ProjetDTO);
        }



        /// <summary>
        /// Insertion d'un nouveau Projet dans la BDD
        /// </summary>
        /// <param name="ProjetDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreerProjetAsync([FromBody] CreerProjetDTO ProjetDTO)
        {
            if (string.IsNullOrEmpty(ProjetDTO?.nomProjet))
            {
                return BadRequest(
                    new { Error = "Veuillez remplir tous les champs" });
            }
            try
            {
                var ProjetAjoute = await _ProjetService.CreerProjetAsync(ProjetDTO).ConfigureAwait(false);
          

                return Ok(ProjetAjoute);
            }
            catch (Exception)
            {
                return BadRequest(
                   new { Error = "Une erreur s'est produite lors de la création du Projet" });
            }

        }

        /// <summary>
        /// Suppression d'un Projet dans la table Projet 
        /// </summary>
        /// <param name="IdProjet">identifiant du Projet à supprimer</param>
        /// <returns></returns>
        [HttpDelete("{IdProjet}")]
        public async Task<ActionResult> SupprimerProjetAsync(int IdProjet)
        {
            try
            {
                LireProjetDTO ProjetSuppr = await _ProjetService.SupprimerProjetAsync(IdProjet).ConfigureAwait(false);
          

                return Ok(ProjetSuppr);
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
        /// Permet de modifer les information du Projet 
        /// </summary>
        /// <param name="idProjet"></param>
        /// <param name="ProjetDTO"></param>
        /// <returns></returns>
        [HttpPut("{idProjet}")]
        [ProducesResponseType(typeof(ModifierProjetDTO), 200)]
        public async Task<ActionResult> ModifierProjetAsync(int idProjet, [FromBody] ModifierProjetDTO ProjetDTO)
        {
            if (string.IsNullOrEmpty(ProjetDTO?.NomProjet) )
            {
                return BadRequest(new { Error = "Veuillez remplir tous les champs" });
            }

            try
            {
                var ProjetModif = await _ProjetService.ModifierProjetAsync(idProjet, ProjetDTO).ConfigureAwait(false);
           

                return Ok(ProjetModif);
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
