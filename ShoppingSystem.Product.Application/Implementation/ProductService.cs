using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Product.Application.Implementation;

public class ProductService : IProductService
{
    public bool Add(Domain.Entities.Product entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Domain.Entities.Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Domain.Entities.Product GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Domain.Entities.Product Select(Expression<Func<Domain.Entities.Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public bool Update(Domain.Entities.Product entity)
    {
        throw new NotImplementedException();
    }
}
