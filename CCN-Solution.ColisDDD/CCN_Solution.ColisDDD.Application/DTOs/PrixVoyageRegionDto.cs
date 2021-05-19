using CCNSolution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class PrixVoyageRegionDto : BaseEntityDto
    {
        public int RegionDepartId { get; set; }
        public RegionDto RegionDepart { get; set; }

        public int RegionArriveeId { get; set; }
        public RegionDto RegionArrivee { get; set; }

        public double Prix { get; set; }
    }
}