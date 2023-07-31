using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForState
{
    public class StateCreateCommand : IRequest<ResponseModel<bool>>
    {
        public StateCreateCommand(string stateName, int countryId) 
        { 
            StateName = stateName;
            CountryId = countryId;
        }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
