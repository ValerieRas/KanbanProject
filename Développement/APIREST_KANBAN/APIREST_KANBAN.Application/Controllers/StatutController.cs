using Kaban.Business.DTO.StatutDTO;
using Kaban.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIREST_KANBAN.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatutController : ControllerBase
    {
        private readonly IStatutService _StatutService;
        public StatutController(IStatutService StatutService)
        {
            _StatutService = StatutService;
        }


        /// <summary>
        /// Insertion d'un nouveau Statut dans la BDD
        /// </summary>
        /// <param name="StatutDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreerStatutAsync([FromBody] CreerStatutDTO StatutDTO)
        {
            if (string.IsNullOrEmpty(StatutDTO?.DescriptionStatus))
            {
                return BadRequest(
                    new { Error = "Veuillez remplir tous les champs" });
            }
            try
            {
                var StatutAjoute = await _StatutService.CreerStatutAsync(StatutDTO).ConfigureAwait(false);
        
                return Ok(StatutAjoute);
            }
            catch (Exception)
            {
                return BadRequest(
                   new { Error = "Une erreur s'est produite lors de la création du Statut" });
            }

        }

        /// <summary>
        /// Suppression d'un Statut dans la table Statut 
        /// </summary>
        /// <param name="IdStatut">identifiant du Statut à supprimer</param>
        /// <returns></returns>
        [HttpDelete("{IdStatut}")]
        public async Task<ActionResult> SupprimerStatutAsync(int IdStatut)
        {
            try
            {
                LireStatutDTO StatutSuppr = await _StatutService.SupprimerStatutAsync(IdStatut).ConfigureAwait(false);
          
                return Ok(StatutSuppr);
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
        /// Permet de modifer les information du Statut 
        /// </summary>
        /// <param name="idStatut"></param>
        /// <param name="StatutDTO"></param>
        /// <returns></returns>
        [HttpPut("{idStatut}")]
        [ProducesResponseType(typeof(ModifierStatutDTO), 200)]
        public async Task<ActionResult> ModifierStatutAsync(int idStatut, [FromBody] ModifierStatutDTO StatutDTO)
        {
            if (string.IsNullOrEmpty(StatutDTO?.DescriptionStatus))
            {
                return BadRequest(new { Error = "Veuillez remplir tous les champs" });
            }

            try
            {
                var StatutModif = await _StatutService.ModifierStatutAsync(idStatut, StatutDTO).ConfigureAwait(false);
         

                return Ok(StatutModif);
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
