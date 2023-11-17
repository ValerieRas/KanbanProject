using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.StatutDTO
{
    public class ModifierStatutDTO
    {
        public int IdStatut { get; set; }

        public string DescriptionStatus { get; set; } = null!;
    }
}
