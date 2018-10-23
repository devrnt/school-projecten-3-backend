using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public class Werkspreuk
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public string Body { get; set; }
        public DateTime Aangemaakt { get; set; }
        public Werkspreuk(int week, string body)
        {
            Week = week;
            Body = body;
            Aangemaakt = DateTime.Now;
        }
    }
}
