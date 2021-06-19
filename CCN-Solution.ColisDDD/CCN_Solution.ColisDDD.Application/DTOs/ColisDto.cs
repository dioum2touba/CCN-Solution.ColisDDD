using System;
using CCNSolution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class ColisDto : AuditableBaseEntity
    {
        public string Libelle { get; set; }
        public string  Description { get; set; }
        public DateTime DateEnvoie { get; set; }
        public DateTime DateArrivée { get; set; }
        public bool ReceptionAgence { get; set; }
        public bool EtatClient { get; set; }

        public int MoyenTransportId { get; set; }
        public MoyenTransportDto MoyenTransport { get; set; }

        public int ClientSourceId { get; set; }
        public ClientDto ClientSource { get; set; }

        public int ClientRecepteurId { get; set; }
        public ClientDto ClientRecepteur { get; set; }

        public int AgenceDepartId { get; set; }
        public AgenceDto AgenceDepart { get; set; }

        public int AgenceRecepteurId { get; set; }
        public AgenceDto AgenceRecepteur { get; set; }

        public int RegionRecepteurId { get; set; }
        public RegionDto RegionRecepteur { get; set; }

        public int RegionDepartId { get; set; }
        public RegionDto RegionDepart { get; set; }

        public int TypeDeColisId { get; set; }
        public TypeDeColisDto TypeDeColis { get; set; }
    }
}