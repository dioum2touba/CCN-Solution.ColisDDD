﻿using CCNSolution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class LivraisonDto : AuditableBaseEntity
    {
        public string Libelle { get; set; }
        public bool EtatLivraison { get; set; }
        
        public int ColisId { get; set; }
        public ColisDto Colis { get; set; }

        public int MoyenTransportId { get; set; }
        public MoyenTransportDto MoyenTransport { get; set; }

        public int TypeLivraisonId { get; set; }
        public TypeLivraisonDto TypeLivraison { get; set; }

        public string LivreurId { get; set; }
        public UserDto Livreur { get; set; }
    }
}