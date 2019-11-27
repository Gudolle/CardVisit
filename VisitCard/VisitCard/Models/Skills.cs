using System;
using System.Collections.Generic;
using System.Text;

namespace VisitCard.Models
{
    public class Skills
    {
        public static int Compteur = 0;
        public string Name { get; set; }
        public int ID { get; private set; }
        public Skills(string _name)
        {
            ID = Compteur++;
            Name = _name;
        }

        public static List<Skills> ListSkillsYann() => new List<Skills>()
        {
            new Skills("C#"),
            new Skills("SQL")
        };
        public static List<Skills> ListSkillsPierre() => new List<Skills>()
        {
            new Skills("Windows"),
            new Skills("Linux")
        };
    }
}
