using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface ICommunicationLogData
    {
        Task<int> CreateCommunicationLog(CommunicationLogModel communication);
        Task<List<CommunicationLogModel>> GetCommunicationLog(int? logId, int? custId, int? templId);
    }
}