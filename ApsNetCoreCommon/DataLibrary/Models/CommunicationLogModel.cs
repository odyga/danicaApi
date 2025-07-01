using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models;

public class CommunicationLogModel
{
    public int Id { get; set; }
    public required int CustomerId { get; set; }
    public required int TemplateId { get; set; }
    public required DateTime SentDate { get; set; } = DateTime.UtcNow;
    public required string Status { get; set; } = "Sent";

    [MaxLength(998, ErrorMessage = "Max 998 symbols, please")]
    [MinLength(1, ErrorMessage = "At least 1 symbol, please")]
    [DisplayName("Message Body")]
    public required string MsgBody { get; set; }

}
