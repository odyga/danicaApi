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

public class TemplateData : ITemplateData
{
    private readonly IDataAccess dataAccess;
    private readonly ConnectionStringData connectionString;

    public TemplateData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        this.dataAccess = dataAccess;
        this.connectionString = connectionString;
    }

    public async Task<int> CreateTemplate(TemplateModel template)
    {
        DynamicParameters p = new();
        p.Add("Name", template.Name);
        p.Add("Subject", template.Subject);
        p.Add("Body", template.Body);
        p.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

        await dataAccess.SaveData("dbo.spTemplate_Insert", p, connectionString.SqlConnectionName);
        return p.Get<int>("Id");
    }

    //could be done to update separate fields
    public Task<int> UpdateTemplate(TemplateModel template)
    {
        DynamicParameters p = new();
        p.Add("Id", template.Id);
        p.Add("Name", template.Name);
        p.Add("Subject", template.Subject);
        p.Add("Body", template.Body);

        return dataAccess.SaveData("dbo.spTemplate_Update", p, connectionString.SqlConnectionName);
    }

    public Task<int> DeleteTemplate(int templateId)
    {
        return dataAccess.SaveData("dbo.spTemplate_Delete",
                                   new { Id = templateId },
                                   connectionString.SqlConnectionName);
    }

    public Task<List<TemplateModel>> GetTemplates()
    {
        return dataAccess.LoadData<TemplateModel, dynamic>("dbo.spTemplate_All",
                                                           new { },
                                                           connectionString.SqlConnectionName);
    }

    public async Task<TemplateModel> GetTemplateById(int templateId)
    {
        var results = await dataAccess.LoadData<TemplateModel, dynamic>("dbo.spTemplate_GetById",
                                                                        new { Id = templateId },
                                                                        connectionString.SqlConnectionName);
        return results.FirstOrDefault();
    }

}
