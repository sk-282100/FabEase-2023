using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForVideo
{
    public class DeleteVideoCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteVideoCommand(int id)
        {
            Id = id;
        }
    }
}
