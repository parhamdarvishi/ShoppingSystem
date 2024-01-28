using ShoppingSystem.Product.Application.Contracts;
using ShoppingSystem.Product.Domain.Contracts;
using ShoppingSystem.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Product.Application.Implementation;

public class CatgeoryService: ICategoryService
{
    public bool Add(Category entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetAll()
    {
        throw new NotImplementedException();
    }

    public Category GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Category Select(Expression<Func<Category, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public bool Update(Category entity)
    {
        throw new NotImplementedException();
    }
}
