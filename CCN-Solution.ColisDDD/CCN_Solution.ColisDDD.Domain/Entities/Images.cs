using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class Images : BaseEntity
    {
        public string Label { get; set; }
        public string Content { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}