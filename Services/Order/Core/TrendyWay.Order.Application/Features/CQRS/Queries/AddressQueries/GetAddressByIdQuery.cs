﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyWay.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public int ID { get; set; }

        public GetAddressByIdQuery(int id)
        {
            ID = id;
        }
    }
}
