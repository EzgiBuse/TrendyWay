﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyWay.Order.Application.Features.CQRS.Results.AddressResults;
using TrendyWay.Order.Application.Interfaces;
using TrendyWay.Order.Domain.Entities;

namespace TrendyWay.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values .Select(x=>new GetAddressQueryResult
            {
                AddressID= x.AddressID,
                City = x.City,
                Detail= x.Detail,
                District = x.District,
                UserID = x.UserID
            }).ToList();
        }
    }
}