using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCity
{
    public class CityUpdateCommand : IRequest<ResponseModel<bool>>
    {
        public CityUpdateCommand(City city)
        {
            City = city;
        }

        public City City { get; set; }
    }
}
