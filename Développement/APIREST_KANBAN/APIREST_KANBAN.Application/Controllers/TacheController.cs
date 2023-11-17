using Kaban.Business.DTO.TacheDTO;
using Kaban.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIREST_KANBAN.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        private readonly ITacheService _TacheService;
        public TacheController(ITacheService TacheService)
        {
            _TacheService = TacheService;
        }

        /// <summary>
        /// Renvoie la liste de Tache récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet("{IdUtilisateur}")]
        [ProducesResponseType(typeof(List<LireTacheDTO>), 200)]
        public async Task<ActionResult> AfficherTacheAvecIdUtilisateurAsync([FromRoute] int IdUtilisateur)
        {
            var TacheDTO = await _TacheService.AfficherTacheAvecIdUtilisateur(IdUtilisateur).ConfigureAwait(false);
   
            return Ok(TacheDTO);
        }

        /// <summary>
        /// Renvoie la liste de Tache par projet récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet("Projet/{idProjet}")]
        [ProducesResponseType(typeof(List<LireTacheDTO>), 200)]
        public async Task<ActionResult> AfficherTacheAvecIdProjetAsync([FromRoute] int idProjet)
        {
            var TacheDTO = await _TacheService.AfficherTacheAvecIdProjet(idProjet).ConfigureAwait(false);

            return Ok(TacheDTO);
        }


        /// <summary>
        /// Renvoie la liste de Tache par projet récupérer depuis la BDD
        /// </summary>
        /// <returns></returns>
        [HttpGet("Statut/{idStatut}")]
        [ProducesResponseType(typeof(List<LireTacheDTO>), 200)]
        public async Task<ActionResult> AfficherTacheAvecIdStatut([FromRoute] int idStatut)
        {
            var TacheDTO = await _TacheService.AfficherTacheAvecIdStatut(idStatut).ConfigureAwait(false);

            return Ok(TacheDTO);
        }



        /// <summary>
        /// Insertion d'un nouveau Tache dans la BDD
        /// </summary>
        /// <param name="TacheDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreerTacheAsync([FromBody] CreerTacheDTO TacheDTO)
        {
            if (string.IsNullOrEmpty(TacheDTO?.TitreTache) || string.IsNullOrEmpty(TacheDTO?.DescriptionTache))
            {
                return BadRequest(
                    new { Error = "Veuillez remplir tous les champs" });
            }
            try
            {
                var TacheAjoute = await _TacheService.CreerTacheAsync(TacheDTO).ConfigureAwait(false);
         
                return Ok(TacheAjoute);
            }
            catch (Exception)
            {
                return BadRequest(
                   new { Error = "Une erreur s'est produite lors de la création du Tache" });
            }

        }

        /// <summary>
        /// Suppression d'un Tache dans la table Tache 
        /// </summary>
        /// <param name="IdTache">identifiant du Tache à supprimer</param>
        /// <returns></returns>
        [HttpDelete("{IdTache}")]
        public async Task<ActionResult> SupprimerTacheAsync(int IdTache)
        {
            try
            {
                LireTacheDTO TacheSuppr = await _TacheService.SupprimerTacheAsync(IdTache).ConfigureAwait(false);
      
                return Ok(TacheSuppr);
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
        /// Permet de modifer les information du Tache 
        /// </summary>
        /// <param name="idTache"></param>
        /// <param name="TacheDTO"></param>
        /// <returns></returns>
        [HttpPut("{idTache}")]
        [ProducesResponseType(typeof(ModifierTacheDTO), 200)]
        public async Task<ActionResult> ModifierTacheAsync(int idTache, [FromBody] ModifierTacheDTO TacheDTO)
        {
            if (string.IsNullOrEmpty(TacheDTO?.TitreTache) || string.IsNullOrEmpty(TacheDTO?.DescriptionTache))
            {
                return BadRequest(new { Error = "Veuillez remplir tous les champs" });
            }

            try
            {
                var TacheModif = await _TacheService.ModifierTacheAsync(idTache, TacheDTO).ConfigureAwait(false);
           

                return Ok(TacheModif);
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
