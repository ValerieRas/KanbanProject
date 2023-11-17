using Kaban.Business.DTO.UtilisateurDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Service.Contrat
{
    public interface IUtilisateurService
    {
        Task<List<LireUtilisateurDTO>> AfficherUtilisateurAsync();
        Task<LireUtilisateurDTO> AfficherUtilisateurAvecIdUtilisateurAsync(int IdUtilisateur);
        Task<List<LireUtilisateurDTO>> AfficherUtilisateurAvecIdProjetAsync(int IdProjet);

        Task<LireUtilisateurDTO> CreerUtilisateurAsync(CreerUtilisateurDTO UtilisateurDTO);

        Task<LireUtilisateurDTO> SupprimerUtilisateurAsync(int IdUtilisateur);
        Task<LireUtilisateurDTO> ModifierUtilisateurAsync(int IdUtilisateur, ModifierUtilisateurDTO UtilisateurDTO);

    }
}
