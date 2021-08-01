using System;

namespace NHLAPI
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string ShootsCatches { get; set; }
        public Guid TeamId { get; set; }
    }
}
