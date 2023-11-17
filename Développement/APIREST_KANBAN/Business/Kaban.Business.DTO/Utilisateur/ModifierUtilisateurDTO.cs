﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.UtilisateurDTO
{
    public class ModifierUtilisateurDTO
    {
        public int IdUtilisateur { get; set; }

        public string Nom { get; set; } = null!;

        public string Prenom { get; set; } = null!;

        public string? Email { get; set; }
    }
}
