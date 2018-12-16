using System;
using Newtonsoft.Json;

namespace TalentCoach.Models.Domain
{
    public class Interesse
    {
        public int Id
        {
            get;
            set;
        }

        public string InteresseTekst
        {
            get;
            set;
        }

        [JsonConstructor]
        public Interesse()
        {
        }
    }
}
