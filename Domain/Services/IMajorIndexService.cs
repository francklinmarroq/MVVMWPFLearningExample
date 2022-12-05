using Domain.Models;

namespace Domain.Services
{
    public interface IMajorIndexService
    {
        public Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);
    }
}
