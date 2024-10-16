
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Common.DTOs.Commands.EntryComment.Create;

public class EntryCommentCommandRequest { 
    public string Content { get; set; }


    public int UserId { get; set; }

    public int EntryId { get; set; }

}
public class EntryCommentCommandResponse
{
    public bool IsAdd { get; set; }
}