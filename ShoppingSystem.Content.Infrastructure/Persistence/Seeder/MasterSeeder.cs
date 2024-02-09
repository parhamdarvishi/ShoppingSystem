using ShoppingSystem.Content.Domain.Entities;
using ShoppingSystem.Content.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Content.Infrastructure.Persistence.Seeder;

public class MasterSeeder : IBaseSeeder<Master>
{
    public IEnumerable<Master> GetSeedData()
    {
        return new[]
        {
            new Master { Id = 1,FirstName = "Parham",LastName = "Darvishi",JobTitle = "Software Eng"}
        };
    }
}
