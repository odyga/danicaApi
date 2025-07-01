using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data;

public class CommunicationLogData : ICommunicationLogData
{
    private readonly IDataAccess dataAccess;
    private readonly ConnectionStringData connectionString;

    public CommunicationLogData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        this.dataAccess = dataAccess;
        this.connectionString = connectionString;
    }

    public async Task<int> CreateCommunicationLog(CommunicationLogModel communication)
    {
        var templateMessage = dataAccess.LoadData<TemplateModel, dynamic>("dbo.spTemplate_GetById",
                                                           new { Id = communication.TemplateId },
                                                           connectionString.SqlConnectionName).Result.FirstOrDefault()?.Body;

        var fullCustomerName = dataAccess.LoadData<CustomerModel, dynamic>("dbo.spCustomer_GetById",
                                                           new { Id = communication.CustomerId },
                                                           connectionString.SqlConnectionName).Result.FirstOrDefault()?.Name
                               + " " + dataAccess.LoadData<CustomerModel, dynamic>("dbo.spCustomer_GetById",
                                                           new { Id = communication.CustomerId },
                                                           connectionString.SqlConnectionName).Result.FirstOrDefault()?.Surname;

        communication.MsgBody = templateMessage?.Replace("PLACEHOLDER", fullCustomerName ?? "customer") ?? string.Empty;


        DynamicParameters p = new();
        p.Add("CustomerId", communication.CustomerId);
        p.Add("TemplateId", communication.TemplateId);
        p.Add("SentDate", communication.SentDate);
        p.Add("Status", communication.Status);
        p.Add("MsgBody", communication.MsgBody);

        p.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

        await dataAccess.SaveData("dbo.spCommunication_Insert", p, connectionString.SqlConnectionName);
        return p.Get<int>("Id");
    }

    public Task<List<CommunicationLogModel>> GetCommunicationLog(int? logId, int? custId, int? templId)
    {
        return dataAccess.LoadData<CommunicationLogModel, dynamic>("dbo.spCommunication_All",
                                                           new
                                                           {
                                                               Id = logId,
                                                               CustomerId = custId,
                                                               TemplateId = templId
                                                           },
                                                           connectionString.SqlConnectionName);
    }
}
