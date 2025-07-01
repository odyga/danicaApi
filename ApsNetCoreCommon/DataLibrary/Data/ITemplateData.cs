using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface ITemplateData
    {
        Task<int> CreateTemplate(TemplateModel template);
        Task<int> DeleteTemplate(int templateId);
        Task<TemplateModel> GetTemplateById(int templateId);
        Task<List<TemplateModel>> GetTemplates();
        Task<int> UpdateTemplate(TemplateModel template);
    }
}