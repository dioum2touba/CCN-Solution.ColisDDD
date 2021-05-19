namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IRepositoryWrapper
    {
        IAgenceRepository Agence { get; }
        IClientRepository Client { get; }
        IColisRepository Colis { get; }
        IImageRepository Image { get; }
        ILivraisonRepository Livraison { get; }
        IPrixVoyageRegionRepository PrixVoyageRegion { get; }
        IRegionRepository Region { get; }
        IRoleRepository Role { get; }
        ITypeDeColisRepository TypeDeColis { get; }
        IUserRepository User { get; }
        void Save();
    }
}