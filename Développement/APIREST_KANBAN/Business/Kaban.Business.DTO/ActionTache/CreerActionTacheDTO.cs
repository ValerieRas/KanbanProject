using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.ActionTacheDTO
{
    public class CreerActionTacheDTO
    {
        public string? DescriptionAction { get; set; }

        public int IdTache { get; set; }

        public bool? Complete { get; set; }
    }
}
