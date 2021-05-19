using System;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class Colis : AuditableBaseEntity
    {
        public string Libelle { get; set; }
        public string  Description { get; set; }
        public DateTime DateEnvoie { get; set; }
        public DateTime DateArrivée { get; set; }
        public bool ReceptionAgence { get; set; }
        public bool EtatClient { get; set; }

        public int ClientSourceId { get; set; }
        public Client ClientSource { get; set; }

        public int ClientRecepteurId { get; set; }
        public Client ClientRecepteur { get; set; }

        public int AgenceDepartId { get; set; }
        public Agence AgenceDepart { get; set; }

        public int AgenceRecepteurId { get; set; }
        public Agence AgenceRecepteur { get; set; }

        public int RegionRecepteurId { get; set; }
        public Region RegionRecepteur { get; set; }

        public int RegionDepartId { get; set; }
        public Region RegionDepart { get; set; }

        public int TypeDeColisId { get; set; }
        public TypeDeColis TypeDeColis { get; set; }
    }
}