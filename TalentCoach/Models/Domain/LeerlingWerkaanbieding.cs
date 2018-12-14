using Newtonsoft.Json;

namespace TalentCoach.Models.Domain
{
    public class LeerlingWerkaanbieding
    {
        public int LeerlingId { get; set; }
        [JsonIgnore]
        public Leerling Leerling { get; set; }
        public int WerkaanbiedingId { get; set; }
        public Werkaanbieding Werkaanbieding { get; set; }
        public Like Like { get; set; }

        public LeerlingWerkaanbieding(Leerling leerling, Werkaanbieding werkaanbieding, Like like)
        {
            LeerlingId = leerling.Id;
            Leerling = leerling;
            WerkaanbiedingId = werkaanbieding.Id;
            Werkaanbieding = werkaanbieding;
            Like = like;
        }

        public LeerlingWerkaanbieding()
        {

        }

    }
}
