﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyWay.Order.Application.Features.CQRS.Commands.AddressCommands;
using TrendyWay.Order.Application.Interfaces;
using TrendyWay.Order.Domain.Entities;

namespace TrendyWay.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressID);
            values.Detail = command.Detail;
            values.District = command.District;
            values.City = command.City;
            values.UserID = command.UserID;
            await _repository.UpdateAsync(values);
        }
    }
}
