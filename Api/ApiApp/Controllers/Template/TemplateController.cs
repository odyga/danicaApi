using ApiApp.Models;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ApiApp.Controllers.Template;

[Route("api/[controller]")]
[ApiController]
public class TemplateController : ControllerBase
{
    private readonly ITemplateData templateData;

    public TemplateController(ITemplateData templateData)
    {
        this.templateData = templateData;
    }

    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(TemplateModel template)
    {
        var id= await templateData.CreateTemplate(template);

        return Ok(new { Id = id });
    }

    [HttpGet]
    public async Task<List<TemplateModel>> Get()
    {
        return await templateData.GetTemplates();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var template = await templateData.GetTemplateById(id);

        return template == null ? NotFound() : Ok(template);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] TemplateUpdateModel data)
    {
        await templateData.UpdateTemplate(new TemplateModel
                                          {
                                              Id = data.Id,
                                              Name = data.Name,
                                              Subject = data.Subject,
                                              Body = data.Body
                                          });
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        await templateData.DeleteTemplate(id);

        return Ok();
    }
}
