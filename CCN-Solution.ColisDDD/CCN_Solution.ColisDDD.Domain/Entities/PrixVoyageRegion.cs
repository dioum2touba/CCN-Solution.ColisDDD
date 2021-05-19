using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class PrixVoyageRegion : BaseEntity
    {
        public int RegionDepartId { get; set; }
        public Region RegionDepart { get; set; }

        public int RegionArriveeId { get; set; }
        public Region RegionArrivee { get; set; }

        public double Prix { get; set; }
    }
}