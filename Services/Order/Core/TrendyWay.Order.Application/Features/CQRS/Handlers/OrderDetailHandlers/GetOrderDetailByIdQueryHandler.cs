using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyWay.Order.Application.Features.CQRS.Queries.AddressQueries;
using TrendyWay.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using TrendyWay.Order.Application.Features.CQRS.Results.AddressResults;
using TrendyWay.Order.Application.Features.CQRS.Results.OrderDetailResults;
using TrendyWay.Order.Application.Interfaces;
using TrendyWay.Order.Domain.Entities;

namespace TrendyWay.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.ID);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailID =values.OrderDetailID,
                ProductAmount= values.ProductAmount,
                ProductID =values.ProductID,
                ProductName = values.ProductName,
                ProductTotalPrice = values.ProductTotalPrice,
                ProductPrice = values.ProductPrice,
                OrderingID=values.OrderingID

            };
        }
    }
}
