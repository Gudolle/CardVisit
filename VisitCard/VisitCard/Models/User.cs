using System;
using System.Collections.Generic;
using System.Text;

namespace VisitCard.Models
{
    public class User
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool IsAuth { get; set; }

        public string Email { get; set; }
        public string Mdp { get; set; }
    }
}
