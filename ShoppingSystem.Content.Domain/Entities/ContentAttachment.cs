using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Content.Domain.Entities;

public class ContentAttachment
{
    public int Id { get; set; }
    public string downloadToken { get; set; }
    public string downloadPath { get; set; }
}
