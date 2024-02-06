using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Product.Application.Usecases.Product.Queries;

public record GetAllProductsQuery() : IRequest<IQueryable<Domain.Entities.Product>>;
