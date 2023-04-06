using HMS.DAL.Entities;

namespace HMS.DAL.Dtos.Requests
{
    public class ProviderDto
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
}
