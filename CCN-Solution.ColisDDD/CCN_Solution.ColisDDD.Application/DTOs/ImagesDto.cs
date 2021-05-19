using CCNSolution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class ImagesDto : BaseEntityDto
    {
        public string Label { get; set; }
        public string Content { get; set; }

        public ClientDto Client { get; set; }
    }
}