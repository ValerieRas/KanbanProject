using Kaban.Business.DTO.ActionTacheDTO;
using Kaban.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIREST_KANBAN.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionTacheController : ControllerBase
    {
        private readonly IActionTacheService _ActionTacheService;
        public ActionTacheController(IActionTacheService ActionTacheService)
        {
            _ActionTacheService = ActionTacheService;
        }

        /// <summary>
        /// Renvoie la liste de ActionTache par ActionTache récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet("{idTache}")]
        [ProducesResponseType(typeof(List<LireActionTacheDTO>), 200)]
        public async Task<ActionResult> AfficherActionTacheAvecIdTacheAsync([FromRoute] int idTache)
        {
            var ActionTacheDTO = await _ActionTacheService.AfficherActionTacheAvecIdTacheAsync(idTache).ConfigureAwait(false);

            return Ok(ActionTacheDTO);
        }



        /// <summary>
        /// Insertion d'un nouveau ActionTache dans la BDD
        /// </summary>
        /// <param name="ActionTacheDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreerActionTacheAsync([FromBody] CreerActionTacheDTO ActionTacheDTO)
        {
            if (string.IsNullOrEmpty(ActionTacheDTO?.DescriptionAction))
            {
                return BadRequest(
                    new { Error = "Veuillez remplir tous les champs" });
            }
            try
            {
                var ActionTacheAjoute = await _ActionTacheService.CreerActionTacheAsync(ActionTacheDTO).ConfigureAwait(false);

                return Ok(ActionTacheAjoute);
            }
            catch (Exception)
            {
                return BadRequest(
                   new { Error = "Une erreur s'est produite lors de la création du ActionTache" });
            }

        }

        /// <summary>
        /// Suppression d'un ActionTache dans la table ActionTache 
        /// </summary>
        /// <param name="IdActionTache">identifiant du ActionTache à supprimer</param>
        /// <returns></returns>
        [HttpDelete("{IdActionTache}")]
        public async Task<ActionResult> SupprimerActionTacheAsync(int IdActionTache)
        {
            try
            {
                LireActionTacheDTO ActionTacheSuppr = await _ActionTacheService.SupprimerActionTacheAsync(IdActionTache).ConfigureAwait(false);
       
                return Ok(ActionTacheSuppr);
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
        /// Permet de modifer les information du ActionTache 
        /// </summary>
        /// <param name="idActionTache"></param>
        /// <param name="ActionTacheDTO"></param>
        /// <returns></returns>
        [HttpPut("{idActionTache}")]
        [ProducesResponseType(typeof(ModifierActionTacheDTO), 200)]
        public async Task<ActionResult> ModifierActionTacheAsync(int idActionTache, [FromBody] ModifierActionTacheDTO ActionTacheDTO)
        {
            if (string.IsNullOrEmpty(ActionTacheDTO?.DescriptionAction))
            {
                return BadRequest(new { Error = "Veuillez remplir tous les champs" });
            }

            try
            {
                var ActionTacheModif = await _ActionTacheService.ModifierActionTacheAsync(idActionTache, ActionTacheDTO).ConfigureAwait(false);
   

                return Ok(ActionTacheModif);
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
