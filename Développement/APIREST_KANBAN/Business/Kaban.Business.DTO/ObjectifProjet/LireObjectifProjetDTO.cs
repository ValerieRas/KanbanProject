﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.ObjectifProjetDTO
{
    public class LireObjectifProjetDTO
    {
        public int IdObjectifProjet { get; set; }

        public string? DescriptionObjectif { get; set; }

        public bool? Complete { get; set; }

        public int IdProjet { get; set; }
    }
}
