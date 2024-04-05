using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyWay.Order.Application.Features.Mediator.Results.OrderingResults;

namespace TrendyWay.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult> { 
    
        public int ID { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            ID = id;
        }
    }
}
