using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class Livraison : AuditableBaseEntity
    {
        public string Libelle { get; set; }
        public bool EtatLivraison { get; set; }
        
        public int ColisId { get; set; }
        public Colis Colis { get; set; }
        
        public int TypeLivraisonId { get; set; }
        public TypeLivraison TypeLivraison { get; set; }

        public int MoyenTransportId { get; set; }
        public MoyenTransport MoyenTransport { get; set; }

        public string LivreurId { get; set; }
        public ApplicationUser Livreur { get; set; }
    }
}