using Kaban.Business.DTO.ObjectifProjetDTO;
using Kaban.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIREST_KANBAN.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectifProjetController : ControllerBase
    {
        private readonly IObjectifProjetService _ObjectifProjetService;
        public ObjectifProjetController(IObjectifProjetService ObjectifProjetService)
        {
            _ObjectifProjetService = ObjectifProjetService;
        }

        /// <summary>
        /// Renvoie la liste de ObjectifProjet par ObjectifProjet récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet("{idObjectifProjet}")]
        [ProducesResponseType(typeof(List<LireObjectifProjetDTO>), 200)]
        public async Task<ActionResult> AfficherObjectifProjetAvecIdProjetAsync([FromRoute] int idObjectifProjet)
        {
            var ObjectifProjetDTO = await _ObjectifProjetService.AfficherObjectifProjetAvecIdProjetAsync(idObjectifProjet).ConfigureAwait(false);
    
            return Ok(ObjectifProjetDTO);
        }



        /// <summary>
        /// Insertion d'un nouveau ObjectifProjet dans la BDD
        /// </summary>
        /// <param name="ObjectifProjetDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreerObjectifProjetAsync([FromBody] CreerObjectifProjetDTO ObjectifProjetDTO)
        {
            if (string.IsNullOrEmpty(ObjectifProjetDTO?.DescriptionObjectif))
            {
                return BadRequest(
                    new { Error = "Veuillez remplir tous les champs" });
            }
            try
            {
                var ObjectifProjetAjoute = await _ObjectifProjetService.CreerObjectifProjetAsync(ObjectifProjetDTO).ConfigureAwait(false);
    
                return Ok(ObjectifProjetAjoute);
            }
            catch (Exception)
            {
                return BadRequest(
                   new { Error = "Une erreur s'est produite lors de la création du ObjectifProjet" });
            }

        }

        /// <summary>
        /// Suppression d'un ObjectifProjet dans la table ObjectifProjet 
        /// </summary>
        /// <param name="IdObjectifProjet">identifiant du ObjectifProjet à supprimer</param>
        /// <returns></returns>
        [HttpDelete("{IdObjectifProjet}")]
        public async Task<ActionResult> SupprimerObjectifProjetAsync(int IdObjectifProjet)
        {
            try
            {
                LireObjectifProjetDTO ObjectifProjetSuppr = await _ObjectifProjetService.SupprimerObjectifProjetAsync(IdObjectifProjet).ConfigureAwait(false);
       
                return Ok(ObjectifProjetSuppr);
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
        /// Permet de modifer les information du ObjectifProjet 
        /// </summary>
        /// <param name="idObjectifProjet"></param>
        /// <param name="ObjectifProjetDTO"></param>
        /// <returns></returns>
        [HttpPut("{idObjectifProjet}")]
        [ProducesResponseType(typeof(ModifierObjectifProjetDTO), 200)]
        public async Task<ActionResult> ModifierObjectifProjetAsync(int idObjectifProjet, [FromBody] ModifierObjectifProjetDTO ObjectifProjetDTO)
        {
            if (string.IsNullOrEmpty(ObjectifProjetDTO ?.DescriptionObjectif))
            {
                return BadRequest(new { Error = "Veuillez remplir tous les champs" });
            }

            try
            {
                var ObjectifProjetModif = await _ObjectifProjetService.ModifierObjectifProjetAsync(idObjectifProjet, ObjectifProjetDTO).ConfigureAwait(false);
      
                return Ok(ObjectifProjetModif);
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
