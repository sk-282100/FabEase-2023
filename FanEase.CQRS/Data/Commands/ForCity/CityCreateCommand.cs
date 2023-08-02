using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCity
{
    public class CityCreateCommand : IRequest<ResponseModel<bool>>
    {
        public CityCreateCommand(string cityName, int stateId)
        {
            CityName = cityName;
            StateId = stateId;
        }
        public string CityName { get; set; }
        public int StateId { get; set; }
    
    }
}
