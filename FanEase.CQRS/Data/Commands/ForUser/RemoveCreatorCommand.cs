using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class RemoveCreatorCommand : IRequest<bool>
    {
        public string CreatorId { get; set; }

        public RemoveCreatorCommand(string creatorId)
        {
            CreatorId = creatorId;
        }
    }
}
