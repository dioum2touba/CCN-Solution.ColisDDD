using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class Client: BaseEntity
    {
        public Client()
        {
            Images = new HashSet<Images>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Telephone { get; set; }
        public string Adresse { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public virtual ICollection<Images> Images { get; set; }
    }
}