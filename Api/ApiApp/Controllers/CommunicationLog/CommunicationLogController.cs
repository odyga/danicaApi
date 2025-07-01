using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiApp.Controllers.CommunicationLog;

[Route("api/[controller]")]
[ApiController]
public class CommunicationLogController : ControllerBase
{
    private readonly ICommunicationLogData communicationLog;

    public CommunicationLogController(ICommunicationLogData communicationLog)
    {
        this.communicationLog = communicationLog;
    }

    //could be separate routs, but does the job
    [HttpGet("{id}/{customerId}/{templateId}")]
    public async Task<List<CommunicationLogModel>> Get(int? id, int? customerId, int? templateId)
    {
        return await communicationLog.GetCommunicationLog(id, customerId, templateId);
    }

    //TODO POST method
}
