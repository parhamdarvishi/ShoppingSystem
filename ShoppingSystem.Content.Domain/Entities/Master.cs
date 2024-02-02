using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Content.Domain.Entities;

public class Master
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
    public string LinkedInLink { get; set; }
    public string YoutubeLink { get; set; }
    public string TelegramLink { get; set; }
    public string InstgramLink { get; set; }
}
