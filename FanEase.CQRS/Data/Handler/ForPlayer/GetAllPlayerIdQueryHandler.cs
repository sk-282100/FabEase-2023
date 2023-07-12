using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForPlayer;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForPlayer
{
    public class GetAllPlayerIdQueryHandler : IRequestHandler<GetAllPlayerIdQuery, Response>
    {
        private readonly IPlayerRepository _playerRepository;
        public GetAllPlayerIdQueryHandler(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }

        public async Task<Response> Handle(GetAllPlayerIdQuery request, CancellationToken cancellationToken)
        {
            players  player = await _playerRepository.GetPlayerById(request.palyerId);
            Response data = new Response
            {
                Result = player,
                Message = "Player found",
                IsSuccess = true
            };
            return data;
        }
    }
}
