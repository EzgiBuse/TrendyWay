﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyWay.Order.Application.Features.CQRS.Queries.AddressQueries;
using TrendyWay.Order.Application.Features.CQRS.Results.AddressResults;
using TrendyWay.Order.Application.Interfaces;
using TrendyWay.Order.Domain.Entities;

namespace TrendyWay.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.ID);
            return new GetAddressByIdQueryResult
            {
                AddressID = values.AddressID,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserID = values.UserID,
            };
        }
    }
}
