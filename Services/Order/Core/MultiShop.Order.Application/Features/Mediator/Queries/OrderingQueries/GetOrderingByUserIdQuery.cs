using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery: IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public string Id { get; set; }
        public GetOrderingByUserIdQuery(string id)
        {
            Id = id;
        }
    }
}
