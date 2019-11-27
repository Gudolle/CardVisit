using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Status { get; set; }
        public List<Skills> Competences { get; set; }
        public string Image { get; set; }
        public static List<User> ListUser() => new List<User>()
        {
            new User()
            {
                Email = "Yann4@gmail.com",
                Mdp = "Test",
                Nom = "Gbedo",
                Prenom = "Yann",
                Status = "Concepteur Développeur d'application",
                Competences = Skills.ListSkillsYann,
                Image = "CardDemoYann.png"
            },
            new User()
            {
                Email = "Pierre@gmail.com",
                Mdp = "Test",
                Nom = "Tixier",
                Prenom = "Pierre",
                Status = "Technicien infrastructure réseau",
                Competences = Skills.ListSkillsPierre,
                Image = "CardDemoPierre.png"
            }
        };
        public static User GetUser(string Email, string Mdp) => ListUser().SingleOrDefault(x => x.Email == Email && x.Mdp == Mdp);
    }
}
